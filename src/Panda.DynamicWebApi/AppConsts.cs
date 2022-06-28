using Panda.DynamicWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Panda.DynamicWebApi
{
    internal static class AppConsts
    {
        public static string DefaultHttpVerb { get; set; }

        public static string DefaultAreaName { get; set; } 
 
        public static string DefaultApiPreFix { get; set; }
        public static string DefaultGroupNameFormat { get; set; }
        public static ApiVersion DefaultApiVersion { get; set; }

        public static List<string> ControllerPostfixes { get; set; }
        public static List<string> ActionPostfixes { get; set; }

        public static List<Type> FormBodyBindingIgnoredTypes { get; set; }

        public static Dictionary<string,string> HttpVerbs { get; set; }

        public static Func<string, string> GetRestFulActionName { get; set; }

        public static Dictionary<Assembly, AssemblyDynamicWebApiOptions> AssemblyDynamicWebApiOptions { get; set; }

        static AppConsts()
        {
            HttpVerbs=new Dictionary<string, string>()
            {
                ["add"]="POST",
                ["create"]="POST",
                ["post"]="POST",

                ["get"]="GET",
                ["find"]="GET",
                ["fetch"]="GET",
                ["query"]="GET",

                ["update"]="PUT",
                ["put"]= "PUT",

                ["delete"] = "DELETE",
                ["remove"] = "DELETE",
            };
        }
    }
}