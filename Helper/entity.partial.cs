using System;
using Microsoft.Xrm.Sdk;

namespace Futurez.Entities
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Extension method that will grab an Aliased attribute value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="attributeLogicalName"></param>
        /// <returns></returns>
        public static T GetAttribValue<T>(this Entity entity, string attributeLogicalName)
        {
            try
            {
                if (null != entity && entity.Attributes.Contains(attributeLogicalName))
                {
                    return entity.GetAttributeValue<T>(attributeLogicalName);
                }

                return default(T);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("Error: Unable to load value for " + attributeLogicalName, ex);
            }
        }

        public static string GetFormattedAttribValue(this Entity entity, string attributeLogicalName)
        {
            try
            {
                if (null != entity && entity.Attributes.Contains(attributeLogicalName))
                {
                    return entity.FormattedValues[attributeLogicalName];
                }

                return default(string);
            }
            catch (Exception ex)
            {
                throw new InvalidPluginExecutionException("Error: Unable to load formatted value for " + attributeLogicalName, ex);
            }
        }



        /// <summary>
        /// Extension method that will grab an Aliased attribute value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="attribName"></param>
        /// <returns></returns>
        public static T GetAliasedAttribute<T>(this Entity entity, string attribName)
        {
            T value = default(T);
            if (entity.Attributes.ContainsKey(attribName))
            {
                value = (T)((AliasedValue)entity[attribName]).Value;
            }
            return value;
        }

        /// <summary>
        /// Extension method that will account for nullable types (should review this one)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="attribName"></param>
        /// <returns></returns>
        public static T GetAttributeValueNullCheck<T>(this Entity entity, string attribName)
        {
            T value = default(T);

            if (entity.Attributes.ContainsKey(attribName))
            {
                var type = typeof(T);
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    value = (T)entity[attribName];
                }
            }

            return value;
        }
    }
}