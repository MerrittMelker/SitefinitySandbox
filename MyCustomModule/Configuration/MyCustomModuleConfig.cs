using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Modules.GenericContent.Configuration;
using Telerik.Sitefinity.Web.Configuration;
using MyCustomModule.Data.OpenAccess;

namespace MyCustomModule.Configuration
{
    /// <summary>
    /// Represents the configuration section for MyCustomModule module.
    /// </summary>
    [ObjectInfo(Title = "MyCustomModule Config Title", Description = "MyCustomModule Config Description")]
    public class MyCustomModuleConfig : ModuleConfigBase
    {
        #region Public and overriden methods
        protected override void InitializeDefaultProviders(ConfigElementDictionary<string, DataProviderSettings> providers)
        {
            providers.Add(new DataProviderSettings(providers)
            {
                Name = "MyCustomModuleOpenAccessDataProvider",
                Title = "Default Products",
                Description = "A provider that stores products data in database using OpenAccess ORM.",
                ProviderType = typeof(MyCustomModuleOpenAccessDataProvider),
                Parameters = new NameValueCollection() { { "applicationName", "/MyCustomModule" } }
            });
        }

        /// <summary>
        /// Gets or sets the name of the default data provider. 
        /// </summary>
        [DescriptionResource(typeof(ConfigDescriptions), "DefaultProvider")]
        [ConfigurationProperty("defaultProvider", DefaultValue = "MyCustomModuleOpenAccessDataProvider")]
        public override string DefaultProvider
        {
            get
            {
                return (string)this["defaultProvider"];
            }
            set
            {
                this["defaultProvider"] = value;
            }
        }
        #endregion
    }
}