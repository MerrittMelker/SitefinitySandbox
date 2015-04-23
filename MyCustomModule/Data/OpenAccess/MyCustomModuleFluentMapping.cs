using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Model;
using MyCustomModule.Models;

namespace MyCustomModule.Data.OpenAccess
{
    public class MyCustomModuleFluentMapping : OpenAccessFluentMappingBase
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleFluentMapping" /> class.
        /// </summary>
        internal MyCustomModuleFluentMapping()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleFluentMapping" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MyCustomModuleFluentMapping(IDatabaseMappingContext context)
            : base(context)
        {
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the list of mapping configurations.
        /// </summary>
        /// <inheritdoc />
        /// <returns></returns>
        public override IList<MappingConfiguration> GetMapping()
        {
            var mappings = new List<MappingConfiguration>();

            this.MapMyContents(mappings);

            return mappings;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Maps the MyContent items.
        /// </summary>
        /// <param name="mappings">The mappings.</param>
        private void MapMyContents(List<MappingConfiguration> mappings)
        {
            var mapping = new MappingConfiguration<MyContent>();

            mapping.MapType(p => new { }).SetTableName("MyCustomModule_MyContents", this.Context);

            mapping.HasProperty(p => p.Id).IsIdentity().IsNotNullable();
            mapping.HasProperty(p => p.Title).IsNotNullable().IsText(this.Context, 255);
            mapping.HasProperty(p => p.MyNumber);
            mapping.HasProperty(p => p.MyDate);
            mapping.HasProperty(p => p.ApplicationName);
            mapping.HasProperty(p => p.LastModified);
            mapping.HasProperty(p => p.DateCreated);

            mappings.Add(mapping);
        }
        #endregion
    }
}