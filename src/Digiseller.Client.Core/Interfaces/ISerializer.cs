using System.Net.Http;
using System.Threading.Tasks;

namespace Digiseller.Client.Core.Interfaces
{
    /// <summary>
    /// Serializer for requests and responses
    /// </summary>
    /// <typeparam name="TRequest">Type of request</typeparam>
    /// <typeparam name="TResponse">Type of response</typeparam>
    public interface ISerializer<in TRequest, TResponse>
    {
        /// <summary>
        /// Serialize request object to HttpContent for send to digiseller system
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Task<HttpContent> Serialize(TRequest obj);

        /// <summary>
        /// Deserialize response digiseller system object to TResponse
        /// </summary>
        /// <param name="data">Serialize data from digiseller</param>
        /// <returns></returns>
        Task<TResponse> Deserialize(string data);
    }
}
