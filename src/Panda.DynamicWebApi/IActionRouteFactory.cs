using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Panda.DynamicWebApi
{
    public interface IActionRouteFactory
    {
        string CreateActionRouteModel(string areaName, string controllerName, ActionModel action);
    }

    internal class DefaultActionRouteFactory : IActionRouteFactory
    {
        private static string GetApiPreFix(ActionModel action)
        {
            var getValueSuccess = AppConsts.AssemblyDynamicWebApiOptions
                .TryGetValue(action.Controller.ControllerType.Assembly, out AssemblyDynamicWebApiOptions assemblyDynamicWebApiOptions);

            var apiPrefix = AppConsts.DefaultApiPreFix;

            if (getValueSuccess && !string.IsNullOrWhiteSpace(assemblyDynamicWebApiOptions?.ApiPrefix))
            {
                apiPrefix = assemblyDynamicWebApiOptions.ApiPrefix;
            }

            if (assemblyDynamicWebApiOptions?.ApiVersion != null && AppConsts.DefaultGroupNameFormat != null)
            {
                apiPrefix += (apiPrefix.EndsWith("/") ? "" : "/") + assemblyDynamicWebApiOptions.ApiVersion.ToString(AppConsts.DefaultGroupNameFormat);
            }

            return apiPrefix;
        }

        public string CreateActionRouteModel(string areaName, string controllerName, ActionModel action)
        {
            var apiPreFix = GetApiPreFix(action);
            var routeStr = $"{apiPreFix}/{areaName}/{controllerName}/{action.ActionName}".Replace("//", "/");
            return routeStr;
        }
    }
}