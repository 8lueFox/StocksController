namespace SimpleFinance.StocksService.Application.Communicators;

public interface IApiCommunicator
{
    Task<string> SendGetRequest(string parameters);
}
