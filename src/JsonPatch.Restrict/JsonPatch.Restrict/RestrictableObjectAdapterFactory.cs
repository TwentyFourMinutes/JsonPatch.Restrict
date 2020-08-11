using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace JsonPatch.Restrict
{
    /// <summary>
    /// An implementation of <see cref="AdapterFactory"/> replaces the standard <see cref="PocoAdapter"/> with a <see cref="RestrictableObjectAdapter"/>.
    /// </summary>
    /// <seealso cref="AdapterFactory" />
    public class RestrictableObjectAdapterFactory : AdapterFactory
    {
        private readonly HashSet<string> _allowedProperties;

        /// <summary>
        /// Initializes a new instance of the <see cref="RestrictableObjectAdapterFactory"/> class.
        /// </summary>
        /// <param name="allowedProperties">A <see cref="HashSet{T}"/> containing all properties which are allowed to be changed by JSON Patch.</param>
        public RestrictableObjectAdapterFactory(HashSet<string> allowedProperties)
        {
            _allowedProperties = allowedProperties;
        }

        /// <inheritdoc />
        public override IAdapter Create(object target, IContractResolver contractResolver)
        {
            var adapter = base.Create(target, contractResolver);
            if (adapter is PocoAdapter)
                adapter = new RestrictablePocoAdapter(_allowedProperties);

            return adapter;
        }
    }
}
