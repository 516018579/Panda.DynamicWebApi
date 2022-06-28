using Microsoft.AspNetCore.Mvc;

namespace Panda.DynamicWebApi
{
    /// <summary>
    /// Specifies the dynamic webapi options for the assembly.
    /// </summary>
    public class AssemblyDynamicWebApiOptions
    {
        /// <summary>
        /// Routing prefix for all APIs
        /// <para></para>
        /// Default value is null.
        /// </summary>
        public string ApiPrefix { get; }

        /// <summary>
        /// API HTTP Verb.
        /// <para></para>
        /// Default value is null.
        /// </summary>
        public string HttpVerb { get; }

        public ApiVersion ApiVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiPrefix">Routing prefix for all APIs</param>
        /// <param name="httpVerb">API HTTP Verb.</param>
        /// <param name="apiVersion">API Version </param>
        public AssemblyDynamicWebApiOptions(string apiPrefix = null, string httpVerb = null, ApiVersion apiVersion = null)
        {
            ApiPrefix = apiPrefix;
            HttpVerb = httpVerb;
            ApiVersion = apiVersion;
        }
    }
}