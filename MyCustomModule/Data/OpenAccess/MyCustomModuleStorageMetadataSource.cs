using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Telerik.Sitefinity.Data.OA;
using Telerik.Sitefinity.Model;

namespace MyCustomModule.Data.OpenAccess
{
    public class MyCustomModuleStorageMetadataSource : SitefinityMetadataSourceBase
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleStorageMetadataSource" /> class.
        /// </summary>
        public MyCustomModuleStorageMetadataSource()
            : base(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleStorageMetadataSource" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MyCustomModuleStorageMetadataSource(IDatabaseMappingContext context)
            : base(context)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Indicates whether the meta data source supports dynamic types.
        /// </summary>
        /// <value>The support dynamic types.</value>
        protected override bool SupportDynamicTypes
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        /// <value>The assemblies.</value>
        public override Assembly[] Assemblies
        {
            get
            {
                return new Assembly[] { this.GetType().Assembly };
            }
        }

        /// <summary>
        /// Gets the dynamic types.
        /// </summary>
        /// <value>The dynamic types.</value>
        public override DynamicTypeInfo[] DynamicTypes
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Builds the custom mappings.
        /// </summary>
        /// <returns>The custom mappings.</returns>
        protected override IList<IOpenAccessFluentMapping> BuildCustomMappings()
        {
            var sitefinityMappings = new List<IOpenAccessFluentMapping>();
            sitefinityMappings.Add(new MyCustomModuleFluentMapping(this.Context));
            return sitefinityMappings;
        }
        #endregion
    }
}