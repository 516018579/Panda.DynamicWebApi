using Panda.DynamicWebApi.Attributes;
using Panda.DynamicWebApi.Helpers;
using System;
using System.Reflection;

namespace Panda.DynamicWebApi
{
    public interface ISelectController
    {
        bool IsController(Type type);
    }

    internal class DefaultSelectController : ISelectController
    {
        public bool IsController(Type type)
        {
            var typeInfo = type.GetTypeInfo();

            if (!typeInfo.IsPublic || typeInfo.IsAbstract || typeInfo.IsGenericType || typeInfo.IsInterface)
            {
                return false;
            }


            if (ReflectionHelper.GetSingleAttributeOrDefaultByFullSearch<NonDynamicWebApiAttribute>(typeInfo) != null)
            {
                return false;
            }

            if (typeof(IDynamicWebApi).IsAssignableFrom(type))
            {
                return true;
            }

            //if (!typeof(IDynamicWebApi).IsAssignableFrom(type) ||
            //    !typeInfo.IsPublic || typeInfo.IsAbstract || typeInfo.IsGenericType)
            //{
            //    return false;
            //}


            var attr = ReflectionHelper.GetSingleAttributeOrDefaultByFullSearch<DynamicWebApiAttribute>(typeInfo);

            if (attr != null)
            {
                return true;
            }

            return false;
        }
    }
}