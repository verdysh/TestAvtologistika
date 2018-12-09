using System.Threading.Tasks;

namespace Test.Services
{
    public interface IHttpApiServiceBase
    {
        Task<string> Get(string request);
    }
}