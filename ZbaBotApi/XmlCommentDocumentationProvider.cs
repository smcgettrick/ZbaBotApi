﻿using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Xml.XPath;

namespace ZbaBotApi
{
    public class XmlCommentDocumentationProvider : IDocumentationProvider
    {
        private readonly XPathNavigator _documentNavigator;
        private const string MethodExpression = "/doc/members/member[@name='M:{0}']";
        private static readonly Regex NullableTypeNameRegex = new Regex(@"(.*\.Nullable)" + Regex.Escape("`1[[") + "([^,]*),.*");

        public XmlCommentDocumentationProvider(string documentPath)
        {
            var xpath = new XPathDocument(documentPath);
            _documentNavigator = xpath.CreateNavigator();
        }

        public virtual string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            var reflectedParameterDescriptor = parameterDescriptor as ReflectedHttpParameterDescriptor;
            if (reflectedParameterDescriptor != null)
            {
                var memberNode = GetMemberNode(reflectedParameterDescriptor.ActionDescriptor);
                if (memberNode != null)
                {
                    var parameterName = reflectedParameterDescriptor.ParameterInfo.Name;
                    var parameterNode = memberNode.SelectSingleNode(string.Format("param[@name='{0}']", parameterName));
                    if (parameterNode != null)
                        return parameterNode.Value.Trim();
                }
            }

            return "No Documentation Found.";
        }

        public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            var memberNode = GetMemberNode(actionDescriptor);
            if (memberNode != null)
            {
                var summaryNode = memberNode.SelectSingleNode("summary");
                if (summaryNode != null)
                    return summaryNode.Value.Trim();
            }

            return "No Documentation Found.";
        }

        private XPathNavigator GetMemberNode(HttpActionDescriptor actionDescriptor)
        {
            var reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
            if (reflectedActionDescriptor != null)
            {
                var selectExpression = string.Format(MethodExpression, GetMemberName(reflectedActionDescriptor.MethodInfo));
                var node = _documentNavigator.SelectSingleNode(selectExpression);
                if (node != null)
                    return node;
            }

            return null;
        }

        private static string GetMemberName(MethodBase method)
        {
            if (method.DeclaringType != null)
            {
                var name = string.Format("{0}.{1}", method.DeclaringType.FullName, method.Name);
                var parameters = method.GetParameters();
                if (parameters.Length != 0)
                {
                    string[] parameterTypeNames =
                        parameters.Select(p => ProcessTypeName(p.ParameterType.FullName)).ToArray();
                    name += string.Format("({0})", string.Join(",", parameterTypeNames));
                }

                return name;
            }

            return null;
        }

        private static string ProcessTypeName(string typeName)
        {
            var result = NullableTypeNameRegex.Match(typeName);
            return result.Success ? 
                string.Format("{0}{{{1}}}", result.Groups[1].Value, result.Groups[2].Value) : 
                typeName;
        }
    }
}