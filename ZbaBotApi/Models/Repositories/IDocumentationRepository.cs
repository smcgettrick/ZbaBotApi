using System.Collections.Generic;
using System.Web.Http.Description;

namespace ZbaBotApi.Models.Repositories
{
    public interface IDocumentationRepository
    {
        ApiEndPoint Get(string apiName);
        List<ApiEndPoint> Get();
    }
}