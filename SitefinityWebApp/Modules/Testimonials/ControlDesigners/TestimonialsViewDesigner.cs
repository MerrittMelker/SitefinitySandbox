using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using AjaxControlToolkit;
using DocumentFormat.OpenXml.Wordprocessing;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
using Telerik.Sitefinity.Web.UI.Fields;
 

namespace SitefinityWebApp.Modules.Testimonials.ControlDesigners
{
    [ControlDesigner(typeof(TestimonialsViewDesigner)), PropertyEditorTitle("Testimonials")]
    public class TestimonialsViewDesigner : ControlDesignerBase
    {
        private string _layoutTemplatePath = "~/Modules/Testimonials/ControlDesigners/TestimonialsViewDesignerTemplate.ascx";

        public override string LayoutTemplatePath
        {
            get { return _layoutTemplatePath; }
            set { _layoutTemplatePath = value; }
        }

        protected override string LayoutTemplateName
        {
            get { return null; }
        }

        protected override void InitializeControls(Telerik.Sitefinity.Web.UI.GenericContainer container)
        {
            base.DesignerMode = ControlDesignerModes.Simple;

            PageSelector.RootNodeID = Telerik.Sitefinity.Abstractions.SiteInitializer.FrontendRootNodeId;
        }

        protected PageField PageSelector
        {
            get { return Container.GetControl<PageField>("PageSelector", true); }
        }

        private string _scriptPath = "~/Modules/Testimonials/ControlDesigners/TestimonialsViewDesigner.js";

        public string DesignerScriptPath
        {
            get { return _scriptPath; }
            set { _scriptPath = value; }
        }

        public override IEnumerable<ScriptReference> GetScriptReferences()
        {
            var scripts = base.GetScriptReferences() as List<ScriptReference>;
            if (scripts == null) return base.GetScriptReferences();

            scripts.Add(new ScriptReference(DesignerScriptPath));
            return scripts.ToArray();
        }

        public override IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            var descriptors = new List<ScriptDescriptor>(base.GetScriptDescriptors());
            var descriptor = (ScriptControlDescriptor)descriptors.Last();
            descriptor.AddComponentProperty("PageSelector", this.PageSelector.ClientID);
            return descriptors;
        }

    }
}