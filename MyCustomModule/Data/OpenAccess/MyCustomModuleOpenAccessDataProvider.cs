using System;
using System.Linq;
using System.Reflection;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Data.Linq;
using Telerik.Sitefinity.Model;
using MyCustomModule.Models;

namespace MyCustomModule.Data.OpenAccess
{
    public class MyCustomModuleOpenAccessDataProvider : MyCustomModuleDataProvider, IOpenAccessDataProvider
    {
        #region Properties
        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        public OpenAccessProviderContext Context { get; set; }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the meta data source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The meta data source</returns>
        public MetadataSource GetMetaDataSource(IDatabaseMappingContext context)
        {
            return new MyCustomModuleStorageMetadataSource(context);
        }

        /// <summary>
        /// Gets a query of all the MyContent items.
        /// </summary>
        /// <returns>The MyContent items.</returns>
        public override IQueryable<MyContent> GetMyContents()
        {
            return SitefinityQuery
                .Get<MyContent>(this, MethodBase.GetCurrentMethod())
                .Where(b => b.ApplicationName == this.ApplicationName);
        }

        /// <summary>
        /// Gets a MyContent by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The MyContent.</returns>
        public override MyContent GetMyContent(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be Empty Guid");

            return this.GetContext().GetItemById<MyContent>(id.ToString());
        }

        /// <summary>
        /// Creates a new MyContent and returns it.
        /// </summary>
        /// <returns>The new MyContent.</returns>
        public override MyContent CreateMyContent()
        {
            Guid id = Guid.NewGuid();

            var item = new MyContent(id, this.ApplicationName);

            if (id != Guid.Empty)
                this.GetContext().Add(item);

            return item;
        }

        /// <summary>
        /// Updates the MyContent.
        /// </summary>
        /// <param name="entity">The MyContent entity.</param>
        public override void UpdateMyContent(MyContent entity)
        {
            entity.LastModified = DateTime.UtcNow;
        }

        /// <summary>
        /// Deletes the MyContent.
        /// </summary>
        /// <param name="entity">The MyContent entity.</param>
        public override void DeleteMyContent(MyContent entity)
        {
            this.GetContext().Remove(entity);
        }
        #endregion
    }
}