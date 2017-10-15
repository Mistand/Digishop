using Digiseller.Client.Core.Interfaces;

namespace Digiseller.Client.Core.Models.Response
{
    public class DigisellerResponseJsonTwoBase : IDigisellerResponseBase
    {
        public int cart_err_num { get; set; }
        public int GetRequestStatusCode()
        {
            return cart_err_num;
        }

        public string GetErrorMessage()
        {
            switch (cart_err_num)
            {
                case 0:
                    return "Запрос выполнен";
                case -1:
                    return "Не указан один из параметров запроса";
                case 2:
                    return "Превышено максимальное количество товаров в корзине - 50";
                case 3:
                    return "Слишком много корзин открыто за последний час с этого IP адреса";
                case 4:
                    return "Указанная корзина не найдена";
                case 5:
                    return "Товар нельзя оплатить указанным способом/валютой";
                case 8:
                    return "В корзине обнаружены товары продавцов, принимающих средства напрямую на свой кошелек";
                case 101:
                case 102:
                    return "Оплата товара временно недоступна";
                case 103:
                    return "Неизвестная ошибка";
                default:
                    return "Неизвестная ошибка (Не найдена информация по данному коду ошибки)";
            }
        }
    }
}
