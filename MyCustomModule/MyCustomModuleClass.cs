using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Abstractions;
using Telerik.Sitefinity.Abstractions.VirtualPath;
using Telerik.Sitefinity.Abstractions.VirtualPath.Configuration;
using Telerik.Sitefinity.Configuration;
using Telerik.Sitefinity.Data;
using Telerik.Sitefinity.Fluent.Modules;
using Telerik.Sitefinity.Fluent.Modules.Toolboxes;
using Telerik.Sitefinity.Modules.Pages.Configuration;
using Telerik.Sitefinity.Services;
using Telerik.Sitefinity.Web.UI;
using MyCustomModule.Configuration;
using MyCustomModule.Web.Services.MyContents;
using MyCustomModule.Web.UI.MyContents;

namespace MyCustomModule
{
    /// <summary>
    /// Custom Sitefinity content module 
    /// </summary>
    public class MyCustomModuleClass : ModuleBase
    {
        #region Properties
        /// <summary>
        /// Gets the landing page id for the module.
        /// </summary>
        /// <value>The landing page id.</value>
        public override Guid LandingPageId
        {
            get
            {
                return MyCustomModuleClass.MyContentHomePageId;
            }
        }

        /// <summary>
        /// Gets the CLR types of all data managers provided by this module.
        /// </summary>
        /// <value>An array of <see cref="T:System.Type" /> objects.</value>
        public override Type[] Managers
        {
            get
            {
                return MyCustomModuleClass.managerTypes;
            }
        }
        #endregion

        #region Module Initialization
        /// <summary>
        /// Initializes the service with specified settings.
        /// This method is called every time the module is initializing (on application startup by default)
        /// </summary>
        /// <param name="settings">The settings.</param>
        public override void Initialize(ModuleSettings settings)
        {
            base.Initialize(settings);

            // Add your initialization logic here

            App.WorkWith()
                .Module(settings.Name)
                    .Initialize()
                    .Localization<MyCustomModuleResources>()
                    .Configuration<MyCustomModuleConfig>()
                    .WebService<MyContentsService>(MyCustomModuleClass.MyContentsWebServiceUrl);

            // Here is also the place to register to some Sitefinity specific events like Bootstrapper.Initialized or subscribe for an event in with the EventHub class            
            // Please refer to the documentation for additional information http://www.sitefinity.com/documentation/documentationarticles/developers-guide/deep-dive/sitefinity-event-system/ieventservice-and-eventhub
        }

        /// <summary>
        /// Installs this module in Sitefinity system for the first time.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        public override void Install(SiteInitializer initializer)
        {
            this.InstallVirtualPaths(initializer);
            this.InstallBackendPages(initializer);
        }

        /// <summary>
        /// Upgrades this module from the specified version.
        /// This method is called instead of the Install method when the module is already installed with a previous version.
        /// </summary>
        /// <param name="initializer">The Site Initializer. A helper class for installing Sitefinity modules.</param>
        /// <param name="upgradeFrom">The version this module us upgrading from.</param>
        public override void Upgrade(SiteInitializer initializer, Version upgradeFrom)
        {
            // Here you can check which one is your prevous module version and execute some code if you need to
            // See the example bolow
            //
            //if (upgradeFrom < new Version("1.0.1.0"))
            //{
            //    some upgrade code that your new version requires
            //}
        }

        /// <summary>
        /// Uninstalls the specified initializer.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        public override void Uninstall(SiteInitializer initializer)
        {
            base.Uninstall(initializer);
            // Add your uninstall logic here
        }
        #endregion

        #region Public and overriden methods
        /// <summary>
        /// Gets the module configuration.
        /// </summary>
        protected override ConfigSection GetModuleConfig()
        {
            return Config.Get<MyCustomModuleConfig>();
        }
        #endregion

        #region Virtual paths
        /// <summary>
        /// Installs module virtual paths.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallVirtualPaths(SiteInitializer initializer)
        {
            // Here you can register your module virtual paths

            var virtualPaths = initializer.Context.GetConfig<VirtualPathSettingsConfig>().VirtualPaths;
            var moduleVirtualPath = MyCustomModuleClass.ModuleVirtualPath + "*";
            if (!virtualPaths.ContainsKey(moduleVirtualPath))
            {
                virtualPaths.Add(new VirtualPathElement(virtualPaths)
                {
                    VirtualPath = moduleVirtualPath,
                    ResolverName = "EmbeddedResourceResolver",
                    ResourceLocation = typeof(MyCustomModuleClass).Assembly.GetName().Name
                });
            }
        }
        #endregion

        #region Install backend pages
        /// <summary>
        /// Installs the backend pages.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallBackendPages(SiteInitializer initializer)
        {
            // Using our Fluent Api you can add your module backend pages hierarchy in no time
            // Here is an example using resources to localize the title of the page and adding a dummy control
            // to the module page.

            initializer.Installer
                .CreateModuleGroupPage(MyCustomModuleClass.MyContentGroupPageId, "MyContent")
                    .PlaceUnder(CommonNode.TypesOfContent)
                    .LocalizeUsing<MyCustomModuleResources>()
                    .SetTitleLocalized("MyContentGroupPageTitle")
                    .SetUrlNameLocalized("MyContentGroupPageUrlName")
                    .SetDescriptionLocalized("MyContentGroupPageDescription")
                    .ShowInNavigation()
                    .AddChildPage(MyCustomModuleClass.MyContentHomePageId, "MyContent")
                        .LocalizeUsing<MyCustomModuleResources>()
                        .SetTitleLocalized("MyContentGroupPageTitle")
                        .SetHtmlTitleLocalized("MyContentGroupPageTitle")
                        .SetUrlNameLocalized("MyContentMasterPageUrl")
                        .SetDescriptionLocalized("MyContentGroupPageDescription")
                        .AddUserControl(string.Concat(MyCustomModuleClass.ModuleVirtualPath, "MyCustomModule.Web.UI.MyContents.MyContentsPage.ascx"), "Content")
                        .HideFromNavigation()
                    .Done()
                    .AddChildPage(MyCustomModuleClass.MyContentDetailPageId, "MyContentDetail")
                        .LocalizeUsing<MyCustomModuleResources>()
                        .SetTitleLocalized("MyContentGroupPageTitle")
                        .SetHtmlTitleLocalized("MyContentGroupPageTitle")
                        .SetUrlNameLocalized("MyContentDetailPageUrl")
                        .SetDescriptionLocalized("MyContentGroupPageDescription")
                        .AddUserControl(string.Concat(MyCustomModuleClass.ModuleVirtualPath, "MyCustomModule.Web.UI.MyContents.MyContentsDetails.ascx"), "Content")
                        .HideFromNavigation()
                    .Done()
                .Done();
        }
        #endregion

        #region Widgets
        /// <summary>
        /// Installs the form widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallFormWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom form widgets in the toolbox.
            // See the example below.

            //string moduleFormWidgetSectionName = "MyCustomModule";
            //string moduleFormWidgetSectionTitle = "MyCustomModule";
            //string moduleFormWidgetSectionDescription = "MyCustomModule";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.FormWidgets)
            //        .LoadOrAddSection(moduleFormWidgetSectionName)
            //            .SetTitle(moduleFormWidgetSectionTitle)
            //            .SetDescription(moduleFormWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<MyCustomModuleResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (this is optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the layout widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallLayoutWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom layout widgets in the toolbox.
            // See the example below.

            //string moduleLayoutWidgetSectionName = "MyCustomModule";
            //string moduleLayoutWidgetSectionTitle = "MyCustomModule";
            //string moduleLayoutWidgetSectionDescription = "MyCustomModule";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.Layouts)
            //        .LoadOrAddSection(moduleLayoutWidgetSectionName)
            //            .SetTitle(moduleLayoutWidgetSectionTitle)
            //            .SetDescription(moduleLayoutWidgetSectionDescription)
            //            .LoadOrAddWidget<LayoutControl>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<MyCustomModuleResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //                .SetParameters(new NameValueCollection() 
            //                { 
            //                    { "layoutTemplate", FullPathToTheLayoutWidget },
            //                })
            //            .Done()
            //        .Done()
            //    .Done();
        }

        /// <summary>
        /// Installs the page widgets.
        /// </summary>
        /// <param name="initializer">The initializer.</param>
        private void InstallPageWidgets(SiteInitializer initializer)
        {
            // Here you can register your custom page widgets in the toolbox.
            // See the example below.

            //string modulePageWidgetSectionName = "MyCustomModule";
            //string modulePageWidgetSectionTitle = "MyCustomModule";
            //string modulePageWidgetSectionDescription = "MyCustomModule";

            //initializer.Installer
            //    .Toolbox(CommonToolbox.PageWidgets)
            //        .LoadOrAddSection(modulePageWidgetSectionName)
            //            .SetTitle(modulePageWidgetSectionTitle)
            //            .SetDescription(modulePageWidgetSectionDescription)
            //            .LoadOrAddWidget<WidgetType>(WidgetNameForDevelopers)
            //                .SetTitle(WidgetTitle)
            //                .SetDescription(WidgetDescription)
            //                .LocalizeUsing<MyCustomModuleResources>()
            //                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
            //            .Done()
            //        .Done()
            //    .Done();
        }
        #endregion

        #region Upgrade methods
        #endregion

        #region Private members & constants
        public const string ModuleName = "MyCustomModule";
        internal const string ModuleTitle = "MyCustomModule";
        internal const string ModuleDescription = "This is a Custom Module which has been built with Sitefinity Thunder.";
        internal const string ModuleVirtualPath = "~/MyCustomModule/";

        private static readonly Type[] managerTypes = new Type[] { typeof(MyCustomModuleManager) };

        // Services
        public const string MyContentsWebServiceUrl = "Sitefinity/Services/MyCustomModule/MyContents.svc/";

        // Pages
        internal static readonly Guid MyContentGroupPageId = new Guid("3635a857-d5f1-4818-a821-afb844c9abd6");
        internal static readonly Guid MyContentHomePageId = new Guid("a6c496f0-42e4-40c8-85ef-e1eda401b144");
        internal static readonly Guid MyContentDetailPageId = new Guid("3f3b8413-9e96-4608-9b68-f3739464ec0b");
        #endregion
    }
}