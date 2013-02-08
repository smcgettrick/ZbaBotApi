using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Description;

namespace ZbaBotApi.Models.Repositories
{
    public class DocumentationRepository : IDocumentationRepository
    {
        public ApiEndPoint Get(string apiName)
        {
            return GetApiEndPoint(apiName);
        }

        public List<ApiEndPoint> Get()
        {
            var controllers = GlobalConfiguration
                .Configuration
                .Services
                .GetApiExplorer()
                .ApiDescriptions
                .GroupBy(x => x.ActionDescriptor.ControllerDescriptor.ControllerName)
                .Select(x => x.First().ActionDescriptor.ControllerDescriptor.ControllerName)
                .ToList();

            return controllers.Select(GetApiEndPoint).ToList();
        }

        private ApiEndPoint GetApiEndPoint(string controller)
        {
            var localController = controller;
            var apis = GlobalConfiguration
                .Configuration
                .Services
                .GetApiExplorer()
                .ApiDescriptions
                .Where(x => x.ActionDescriptor.ControllerDescriptor.ControllerName == localController);

            List<ApiEndPointDetail> apiEndPointDetails = null;

            var apiDescriptions = apis as IList<ApiDescription> ?? apis.ToList();
            if (apiDescriptions.Any())
                apiEndPointDetails = apiDescriptions.Select(GetApiEndPointDetail).ToList();
            else
                controller = string.Format("The {0} api does not exist.", controller);

            return new ApiEndPoint(controller, apiEndPointDetails);
        }

        private ApiEndPointDetail GetApiEndPointDetail(ApiDescription api)
        {
            if (api.ParameterDescriptions.Count > 0)
            {
                var parameters =
                    api.ParameterDescriptions.Select(
                        parameter =>
                        new ApiEndPointParameter(parameter.Name, parameter.Documentation, parameter.Source.ToString()))
                       .ToList();

                return new ApiEndPointDetail(api.RelativePath, api.Documentation, api.HttpMethod.Method, parameters);
            }

            return new ApiEndPointDetail(api.RelativePath, api.Documentation, api.HttpMethod.Method);
        }
    }

    [DataContract]
    public class ApiEndPoint 
    {
        [DataMember] public string Name { get; private set; }
        [DataMember] public List<ApiEndPointDetail> ApiEndPointDetails { get; private set; }
 
        public ApiEndPoint(string name, List<ApiEndPointDetail> apiEndPointDetails)
        {
            Name = name;
            ApiEndPointDetails = apiEndPointDetails;
        }
    }
 
    [DataContract]
    public class ApiEndPointDetail
    {
        [DataMember]
        public string RelativePath { get; private set; }
        [DataMember]
        public string Documentation { get; private set; }
        [DataMember]
        public string Method { get; private set; }
        [DataMember]
        public List<ApiEndPointParameter> Parameters { get; private set; }
 
        public ApiEndPointDetail(string relativePath, string documentation, string method, List<ApiEndPointParameter> parameters) : this(relativePath, documentation, method)
        {
            Parameters = parameters;
        }
 
        public ApiEndPointDetail(string relativePath, string documentation, string method)
        {
            RelativePath = relativePath;
            Documentation = documentation;
            Method = method;
        }
    }
 
    [DataContract]
    public class ApiEndPointParameter
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Documentation { get; private set; }
        [DataMember]
        public string Source { get; private set; }
 
        public ApiEndPointParameter(string name, string documentation, string source)
        {
            Name = name;
            Documentation = documentation;
            Source = source;
        }
    }
}
