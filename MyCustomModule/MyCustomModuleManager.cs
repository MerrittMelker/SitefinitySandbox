using System;
using System.Linq;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using MyCustomModule.Configuration;
using MyCustomModule.Models;

namespace MyCustomModule
{
    public class MyCustomModuleManager : ManagerBase<MyCustomModuleDataProvider>
    {
        #region Construction
        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleManager" /> class.
        /// </summary>
        public MyCustomModuleManager()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        public MyCustomModuleManager(string providerName)
            : base(providerName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyCustomModuleManager" /> class.
        /// </summary>
        /// <param name="providerName">Name of the provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        public MyCustomModuleManager(string providerName, string transactionName)
            : base(providerName, transactionName)
        {
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the default provider delegate.
        /// </summary>
        /// <value>The default provider delegate.</value>
        protected override GetDefaultProvider DefaultProviderDelegate
        {
            get
            {
                return () => Config.Get<MyCustomModuleConfig>().DefaultProvider;
            }
        }

        /// <summary>
        /// Gets the name of the module.
        /// </summary>
        /// <value>The name of the module.</value>
        public override string ModuleName
        {
            get
            {
                return MyCustomModuleClass.ModuleName;
            }
        }

        /// <summary>
        /// Gets the providers settings.
        /// </summary>
        /// <value>The providers settings.</value>
        protected override ConfigElementDictionary<string, DataProviderSettings> ProvidersSettings
        {
            get
            {
                return Config.Get<MyCustomModuleConfig>().Providers;
            }
        }

        /// <summary>
        /// Get an instance of the MyCustomModule manager using the default provider.
        /// </summary>
        /// <returns>Instance of the MyCustomModule manager</returns>
        public static MyCustomModuleManager GetManager()
        {
            return ManagerBase<MyCustomModuleDataProvider>.GetManager<MyCustomModuleManager>();
        }

        /// <summary>
        /// Get an instance of the MyCustomModule manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <returns>Instance of the MyCustomModule manager</returns>
        public static MyCustomModuleManager GetManager(string providerName)
        {
            return ManagerBase<MyCustomModuleDataProvider>.GetManager<MyCustomModuleManager>(providerName);
        }

        /// <summary>
        /// Get an instance of the MyCustomModule manager by explicitly specifying the required provider to use
        /// </summary>
        /// <param name="providerName">Name of the provider to use, or null/empty string to use the default provider.</param>
        /// <param name="transactionName">Name of the transaction.</param>
        /// <returns>Instance of the MyCustomModule manager</returns>
        public static MyCustomModuleManager GetManager(string providerName, string transactionName)
        {
            return ManagerBase<MyCustomModuleDataProvider>.GetManager<MyCustomModuleManager>(providerName, transactionName);
        }

        /// <summary>
        /// Creates a MyContent.
        /// </summary>
        /// <returns>The created MyContent.</returns>
        public MyContent CreateMyContent()
        {
            return this.Provider.CreateMyContent();
        }

        /// <summary>
        /// Updates the MyContent.
        /// </summary>
        /// <param name="entity">The MyContent entity.</param>
        public void UpdateMyContent(MyContent entity)
        {
            this.Provider.UpdateMyContent(entity);
        }

        /// <summary>
        /// Deletes the MyContent.
        /// </summary>
        /// <param name="entity">The MyContent entity.</param>
        public void DeleteMyContent(MyContent entity)
        {
            this.Provider.DeleteMyContent(entity);
        }

        /// <summary>
        /// Gets the MyContent by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The MyContent.</returns>
        public MyContent GetMyContent(Guid id)
        {
            return this.Provider.GetMyContent(id);
        }

        /// <summary>
        /// Gets a query of all the MyContent items.
        /// </summary>
        /// <returns>The MyContent items.</returns>
        public IQueryable<MyContent> GetMyContents()
        {
            return this.Provider.GetMyContents();
        }
        #endregion
    }
}