﻿using Marvin.AbstractionLayer.UI.Aspects;
using Marvin.Container;

namespace Marvin.Products.UI
{
    /// <summary>
    /// Registration attribute to register <see cref="IProductAspect"/> for a product group
    /// </summary>
    public class ProductAspectRegistrationAttribute : PluginAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAspectRegistrationAttribute"/> class.
        /// </summary>
        public ProductAspectRegistrationAttribute(string name)
            : base(LifeCycle.Transient, typeof(IProductAspect), typeof(IAspect))
        {
            Name = name;
        }
    }
}
