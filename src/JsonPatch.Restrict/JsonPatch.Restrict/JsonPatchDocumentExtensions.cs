using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace JsonPatch.Restrict
{
    /// <summary>
    /// Contains restriction extensions for the <see cref="JsonPatchDocument"/> and the <see cref="JsonPatchDocument{TModel}"/> classes.
    /// </summary>
    public static class JsonPatchDocumentExtensions
    {
        /// <summary>
        /// Applies the <see cref="JsonPatchDocument"/> to the provided object, only allowing changes to the provided property.
        /// </summary>
        /// <param name="document">The patch to apply.</param>
        /// <param name="objectToApplyTo">The object to apply the patch to.</param>
        /// <param name="allowedProperties">An array containing all properties which are allowed to be changed by JSON Patch.</param>
        public static void ApplyToWithRestrictions(this JsonPatchDocument document, object objectToApplyTo, params string[] allowedProperties)
        {
            var adapter = new RestrictableObjectAdapter(new DefaultContractResolver(), GetHashSetFromPropsArray(allowedProperties));

            document.ApplyTo(objectToApplyTo, adapter);
        }

        /// <summary>
        /// Applies the <see cref="JsonPatchDocument"/> to the provided object, only allowing changes to the provided property.
        /// </summary>
        /// <param name="document">The patch to apply.</param>
        /// <param name="objectToApplyTo">The object to apply the patch to.</param>
        /// <param name="logErrorAction">An action to handle logging any errors.</param>
        /// <param name="allowedProperties">An array containing all properties which are allowed to be changed by JSON Patch.</param>
        public static void ApplyToWithRestrictions(this JsonPatchDocument document, object objectToApplyTo, Action<JsonPatchError> logErrorAction, params string[] allowedProperties)
        {
            var adapter = new RestrictableObjectAdapter(new DefaultContractResolver(), GetHashSetFromPropsArray(allowedProperties), logErrorAction);

            document.ApplyTo(objectToApplyTo, adapter, logErrorAction);
        }

        /// <summary>
        /// Applies the <see cref="JsonPatchDocument"/> to the provided object, only allowing changes to the provided property.
        /// </summary>
        /// <param name="document">The patch to apply.</param>
        /// <param name="objectToApplyTo">The object to apply the patch to.</param>
        /// <param name="allowedProperties">An array containing all properties which are allowed to be changed by JSON Patch.</param>
        public static void ApplyToWithRestrictions<T>(this JsonPatchDocument<T> document, T objectToApplyTo, params string[] allowedProperties)
           where T : class
        {
            var adapter = new RestrictableObjectAdapter(new DefaultContractResolver(), GetHashSetFromPropsArray(allowedProperties));

            document.ApplyTo(objectToApplyTo, adapter);
        }

        /// <summary>
        /// Applies the <see cref="JsonPatchDocument"/> to the provided object, only allowing changes to the provided property.
        /// </summary>
        /// <param name="document">The patch to apply.</param>
        /// <param name="objectToApplyTo">The object to apply the patch to.</param>
        /// <param name="logErrorAction">An action to handle logging any errors.</param>
        /// <param name="allowedProperties">An array containing all properties which are allowed to be changed by JSON Patch.</param>
        public static void ApplyToWithRestrictions<T>(this JsonPatchDocument<T> document, T objectToApplyTo, Action<JsonPatchError> logErrorAction, params string[] allowedProperties)
            where T : class
        {
            var adapter = new RestrictableObjectAdapter(new DefaultContractResolver(), GetHashSetFromPropsArray(allowedProperties), logErrorAction);

            document.ApplyTo(objectToApplyTo, adapter, logErrorAction);
        }

        private static HashSet<string> GetHashSetFromPropsArray(string[] properties)
        {
            var hashSet = new HashSet<string>(properties.Length);

            for (int i = 0; i < properties.Length; i++)
            {
                hashSet.Add(properties[i]);
            }

            return hashSet;
        }
    }
}
