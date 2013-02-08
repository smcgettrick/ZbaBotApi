using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using ZbaBotApi.Models.Repositories;

namespace ZbaBotApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class DocumentationController : ApiController
    {
        private readonly IDocumentationRepository _repository;

        public DocumentationController(IDocumentationRepository repository)
        {
            _repository = repository;
        }

        public List<ApiEndPoint> Get()
        {
            return _repository.Get();
        }

        public ApiEndPoint Get(string api)
        {
            return _repository.Get(api);
        }
    }
}
