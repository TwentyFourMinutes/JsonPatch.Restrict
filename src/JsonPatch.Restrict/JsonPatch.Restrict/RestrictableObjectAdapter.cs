using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace JsonPatch.Restrict
{
    /// <summary>
    /// An implementation of <see cref="IObjectAdapter"/> that restricts the modification of specific properties
    /// before allowing a patch operation to write to a property.
    /// </summary>
    public class RestrictableObjectAdapter : ObjectAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RestrictableObjectAdapter"/> class.
        /// </summary>
        /// <param name="contractResolver">The <see cref="IContractResolver" />.</param>
        /// <param name="allowedProperties">A <see cref="HashSet{T}"/> containing all properties which are allowed to be changed by JSON Patch.</param>
        public RestrictableObjectAdapter(IContractResolver contractResolver, HashSet<string> allowedProperties)
            : base(contractResolver, _ => { }, new RestrictableObjectAdapterFactory(allowedProperties))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestrictableObjectAdapter"/> class.
        /// </summary>
        /// <param name="contractResolver">The <see cref="IContractResolver" />.</param>
        /// <param name="allowedProperties">A <see cref="HashSet{T}"/> containing all properties which are allowed to be changed by JSON Patch.</param>
        /// <param name="logErrorAction">The <see cref="Action" /> for logging a <see cref="JsonPatchError" />.</param>
        public RestrictableObjectAdapter(IContractResolver contractResolver, HashSet<string> allowedProperties, Action<JsonPatchError> logErrorAction)
            : base(contractResolver, logErrorAction, new RestrictableObjectAdapterFactory(allowedProperties))
        { }
    }
}
