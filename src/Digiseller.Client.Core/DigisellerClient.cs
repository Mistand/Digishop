using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Digiseller.Client.Core.Enums;
using Digiseller.Client.Core.Exceptions;
using Digiseller.Client.Core.Helpers;
using Digiseller.Client.Core.Interfaces;
using Digiseller.Client.Core.Interfaces.Cart;
using Digiseller.Client.Core.Interfaces.Categories;
using Digiseller.Client.Core.Interfaces.CategoryGoods;
using Digiseller.Client.Core.Models.Request.Cart;
using Digiseller.Client.Core.Models.Request.Categories;
using Digiseller.Client.Core.Models.Request.CategoryGoods;
using Digiseller.Client.Core.Models.Request.ProductDiscount;
using Digiseller.Client.Core.Models.Request.ProductInformation;
using Digiseller.Client.Core.Models.Request.ProductReviews;
using Digiseller.Client.Core.Models.Request.ProductSearch;
using Digiseller.Client.Core.Models.Request.SellerProducts;
using Digiseller.Client.Core.Models.Request.TopTwenty;
using Digiseller.Client.Core.Models.Response.Cart;
using Digiseller.Client.Core.Models.Response.Categories;
using Digiseller.Client.Core.Models.Response.CategoryGoods;
using Digiseller.Client.Core.Models.Response.ProductDiscount;
using Digiseller.Client.Core.ViewModels.Categories;
using Digiseller.Client.Core.ViewModels.CategoryGoods;
using Digiseller.Client.Core.Models.Response.ProductInformation;
using Digiseller.Client.Core.Models.Response.ProductReviews;
using Digiseller.Client.Core.Models.Response.ProductSearch;
using Digiseller.Client.Core.Models.Response.SellerProducts;
using Digiseller.Client.Core.Models.Response.TopTwenty;
using Digiseller.Client.Core.ViewModels.Cart;
using Digiseller.Client.Core.ViewModels.ProductInformation;
using Digiseller.Client.Core.ViewModels.ProductReviews;
using Digiseller.Client.Core.ViewModels.ProductSearch;
using Digiseller.Client.Core.ViewModels.SellerProducts;

namespace Digiseller.Client.Core
{
    /// <summary>
    /// Digiseller Client
    /// </summary>
    public class DigisellerClient
    {
        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="sellerid"></param>
        /// <param name="sellerUid"></param>
        public DigisellerClient(int sellerid, string sellerUid)
        {
            SellerId = sellerid;
            SellerUid = sellerUid;
            _client = new HttpClient { BaseAddress = new Uri("http://shop.digiseller.ru/") };
        }

        /// <summary>
        /// Seller identitfier
        /// </summary>
        public int SellerId { get; set; }

        /// <summary>
        /// Sellect UID
        /// </summary>
        public string SellerUid { get; set; }

        /// <summary>
        /// HttpClient for requsts to digiseller system
        /// </summary>
        private readonly HttpClient _client;

        /// <summary>
        /// Complete status code (from DS)
        /// </summary>
        private const int RequestSuccessCode = 0;

        /// <summary>
        /// Languages codes
        /// </summary>
        private readonly Dictionary<Language, string> _languages = new Dictionary<Language, string>
        {
            {Language.Russian, "ru-RU"},
            {Language.English, "en-US"}
        };

        #region Urls Digiseller
        private const string UrlGetCategoryList = "xml/shop_categories.asp";
        private const string UrlGetCategoryGoodsList = "xml/shop_products.asp";
        private const string UrlGetFullProductInformation = "xml/shop_product_info.asp";
        private const string UrlGetProductReviews = "xml/shop_reviews.asp";
        private const string UrlGetSellerGoods = "https://api.digiseller.ru/api/seller-goods";
        private const string UrlGetProductDiscount = "xml/shop_discount.asp";
        private const string UrlGetGoodstBySearchString = "xml/shop_search.asp";
        private const string UrlGetTopTwentySale = "xml/shop_last_sales.asp";
        private const string UrlAddToCart = "xml/shop_cart_add.asp";
        private const string UrlUpdateCart = "xml/shop_cart_lst.asp";

        #endregion

        /// <summary>
        /// Get digiseller data
        /// </summary>
        /// <typeparam name="TRequest">Request object type</typeparam>
        /// <typeparam name="TResponse">Response object type</typeparam>
        /// <param name="requestObject">Request object</param>
        /// <param name="serializer">Serializer (XML/JSON)</param>
        /// <param name="requestUrl">Request URL</param>
        /// <returns></returns>
        private async Task<TResponse> GetDigisellerDataAsync<TRequest, TResponse>(TRequest requestObject, ISerializer<TRequest, TResponse> serializer,
            string requestUrl)
            where TResponse : class
        {
            var content = await serializer.Serialize(requestObject); // serialize object to HttpContent
            var response = await _client.PostAsync(requestUrl, content); // Send content


            if (!response.IsSuccessStatusCode)
                throw new DigisellerException($"Digiseller was unable to process the request. HTTP Status code: {response.StatusCode}");


            var responseData = await response.Content.ReadAsStringAsync(); // Get data
            var responseObject = await serializer.Deserialize(responseData); // Get object

            if (!(responseObject is IDigisellerResponseBase)) // if object Can not be brought to the interface
            {
                throw new DigisellerException("I can't bring the object to the Digiseller response base. Support for this developer");
            }

            if ((responseObject as IDigisellerResponseBase).GetRequestStatusCode() != RequestSuccessCode) // If digiseller system send error
            {
                throw new DigisellerException(
                    $"The request was not processed. Digiseller's system indicated the error. Request code: {(responseObject as IDigisellerResponseBase).GetRequestStatusCode()}, message: {(responseObject as IDigisellerResponseBase).GetErrorMessage()}");
            }

            return responseObject;
        }

        #region Digiseller api methods
        /// <summary>
        /// Get category catalog
        /// </summary>
        /// <param name="rootCategory">Parent category
        /// 0 - all categories
        /// </param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<IEnumerable<ICatalogCategory>> GetCategoryCatalog(int rootCategory = 0, Language language = Language.Russian)
        {
            var request = new DigisellerCategoryRequest(SellerId, rootCategory, _languages[language]);
            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerCategoryRequest, DigisellerCategoriesCatalog>(), 
                    UrlGetCategoryList);

            return response?.Categories?.Category?.Select(p => new CatalogCategoryViewModel(p));
        }

        /// <summary>
        /// Get goods from category
        /// </summary>
        /// <param name="categoryId">Category identifier
        ///  0 - Goods on main page
        ///  -1 - goods with icon "sale"
        ///  -2 - goods with icon "new"
        ///  -3 - goods with icon "popular"
        /// </param>
        /// <param name="language">Language information</param>
        /// <param name="pageNumber">Page number (pagination)</param>
        /// <param name="countGoods">Count of goods per page</param>
        /// <param name="currency">Currency for information</param>
        /// <param name="sorting">Sorting</param>
        /// <returns></returns>
        public async Task<IProductRepository> GetCategoryGoods(int categoryId = 0,
            Language language = Language.Russian,
            int pageNumber = 1, int countGoods = 50, Currency currency = Currency.RUR, Sorting sorting = Sorting.name)
        {
            var request = new DigisellerCategoryGoodsRequest(SellerId, categoryId, _languages[language], pageNumber, countGoods,
                currency, sorting);
            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerCategoryGoodsRequest, DigisellerCategoryGoodsResponseXml>(),
                    UrlGetCategoryGoodsList);

            return response != null ? new ProductRepository(response) : null;
        }

        /// <summary>
        /// Get full product information
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<Interfaces.ProductInformation.IProduct> GetFullProductInformation(int productId, Language language = Language.Russian)
        {
            var request = new DigisellerProductInfoRequest(SellerId, productId, SellerUid, _languages[language]);
            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerProductInfoRequest, DigisellerProductInfoResponseXml>(), 
                    UrlGetFullProductInformation);

            return response.Product != null ? new ProductInformation(response.Product) : null;
        }

        /// <summary>
        /// Get product reviews
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <param name="reviewType">Type of reviews</param>
        /// <param name="pageNumber">Page number (pagination)</param>
        /// <param name="rowsCount">Count of reviews per page</param>
        /// <returns></returns>
        public async Task<Interfaces.ProductReviews.IProductReviews> GetProductReviews(int productId, ReviewType reviewType = ReviewType.All, int pageNumber = 1, int rowsCount = 20)
        {
            var request = new DigisellerProductReviewsRequest(SellerId, productId, pageNumber, rowsCount, reviewType);
            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerProductReviewsRequest, DigisellerProductReviewsResponseXml>(), 
                    UrlGetProductReviews);

            return response != null ? new ProductReviews(response) : null;
        }

        /// <summary>
        /// Get products by current seller
        /// </summary>
        /// <param name="pageNumber">Page number (pagination)</param>
        /// <param name="rowsCount">Count of products per page</param>
        /// <param name="currency">Currency for prices</param>
        /// <param name="orderColumn">Sorting column</param>
        /// <param name="orderDir">Sorting by</param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<Interfaces.SellerProducts.ISellerProducts> GetSellerProducts(int pageNumber = 1, int rowsCount = 20, Currency currency = Currency.RUR,
            OrderColumn orderColumn = OrderColumn.Name, OrderDir orderDir = OrderDir.Asc,
            Language language = Language.Russian)
        {
            return await GetSellerProducts(SellerId, pageNumber, rowsCount, currency, orderColumn, orderDir, language);
        }


        /// <summary>
        /// Get products by seller id
        /// </summary>
        /// <param name="sellerId">Seller Id</param>
        /// <param name="pageNumber">Page number (pagination)</param>
        /// <param name="rowsCount">Count of products per page</param>
        /// <param name="currency">Currency for prices</param>
        /// <param name="orderColumn">Sorting column</param>
        /// <param name="orderDir">Sorting by</param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<Interfaces.SellerProducts.ISellerProducts> GetSellerProducts(int sellerId, int pageNumber = 1, int rowsCount = 20, Currency currency = Currency.RUR,
            OrderColumn orderColumn = OrderColumn.Name, OrderDir orderDir = OrderDir.Asc,
            Language language = Language.Russian)
        {
            var request = new DigisellerSellerProductsRequest(sellerId, orderColumn.ToString().ToLower(), orderDir.ToString().ToLower(), rowsCount, pageNumber,
                currency.ToString(), _languages[language]);

            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerSellerProductsRequest, DigisellerSellerProductsResponseXml>(), 
                    UrlGetSellerGoods);

            return response != null ? new SellerProducts(response) : null;
        }

        /// <summary>
        /// Get product discount by buyer email
        /// </summary>
        /// <param name="productId">Product Id</param>
        /// <param name="email">Buyer email</param>
        /// <param name="currency">Currency</param>
        /// <returns></returns>
        public async Task<Interfaces.ProductDiscount.IProductDiscount> GetProductDiscountByEmail(int productId, string email, Currency currency = Currency.RUR)
        {
            var request = new DigisellerProductDiscountRequest(productId, email, currency);
            var response =
                await GetDigisellerDataAsync(
                    request, new XmlSerializer<DigisellerProductDiscountRequest, DigisellerProductDiscountResponseXml>(),  UrlGetProductDiscount);

            return response != null ? new ViewModels.ProductDiscount.ProductDiscount(response) : null;
        }

        /// <summary>
        /// Get goods by search string
        /// </summary>
        /// <param name="searchString">Search string</param>
        /// <param name="pageNumber">Page number (pagination)</param>
        /// <param name="rowsCount">Count of goods per page</param>
        /// <param name="currency">Currency</param>
        /// <returns></returns>
        public async Task<Interfaces.ProductSearch.ISearchProduct> GetGoodsBySearchString(string searchString, int pageNumber = 1, int rowsCount = 10, Currency currency = Currency.RUR)
        {
            var request =
                new DigisellerProductSearchRequest(SellerId, searchString, currency.ToString(), pageNumber, rowsCount);
            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerProductSearchRequest, DigisellerProductSearchResponseXml>(), 
                    UrlGetGoodstBySearchString);

            return response != null ? new SearchProduct(response) : null;

        }

        /// <summary>
        /// Get last twenty sales
        /// </summary>
        /// <param name="gropping">Groupping goods</param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<IEnumerable<Interfaces.TopTwenty.ISale>> GetTwentyLastSales(bool gropping = false, Language language = Language.Russian)
        {
            var request = new DigisellerTopTwentyRequest(SellerId, SellerUid, gropping, _languages[language]);
            var response =
                await GetDigisellerDataAsync(request, new XmlSerializer<DigisellerTopTwentyRequest, DigisellerTopTwentyResponseXml>(), 
                    UrlGetTopTwentySale);

            return response?.Sales?.Sale?.Select(p => new ViewModels.TopTwenty.Sale(p));
        }

        /// <summary>
        /// Add product to cart
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <param name="productCount">Product count</param>
        /// <param name="email">Buyer email</param>
        /// <param name="cartUid">Cart UID (optional)</param>
        /// <param name="currency">Currency</param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<ICartAdd> AddToCart(int productId, int productCount, string email, string cartUid = "", Currency currency = Currency.RUR, Language language = Language.Russian)
        {
            var request = new DigisellerAddToCartRequest(productId, productCount, currency, email, _languages[language], cartUid);
            var response =
                await GetDigisellerDataAsync(request,
                    new JsonSerializer<DigisellerAddToCartRequest, DigisellerAddCartResponse>(), UrlAddToCart);
            return new AddCart(response);
        }

        /// <summary>
        /// Update cart
        /// </summary>
        /// <param name="cartUid">Cart UID</param>
        /// <param name="itemUpdate">item id for update (optional)</param>
        /// <param name="productCount">Product Count (optional, required if itemUpdate != null)</param>
        /// <param name="currency">Currency</param>
        /// <param name="language">Language information</param>
        /// <returns></returns>
        public async Task<ICartUpdate> UpdateCart(string cartUid, int? itemUpdate = null, int? productCount = null, Currency currency = Currency.RUR, Language language = Language.Russian)
        {
            if(itemUpdate!= null && productCount == null)
                throw new NullReferenceException("Product count is required if you use item update!");

            var request = new DigisellerUpdateCartRequest(cartUid, itemUpdate, productCount, currency.ToString(), _languages[language]);
            var response =
                await GetDigisellerDataAsync(request,
                    new JsonSerializer<DigisellerUpdateCartRequest, DigisellerUpdateCartResponse>(), UrlUpdateCart);
            return new CartUpdate(response);
        }
        #endregion

    }
}
