namespace Digiseller.Client.Core.Interfaces
{
    interface IDigisellerResponseBase
    {
        int GetRequestStatusCode();
        string GetErrorMessage();
    }
}
