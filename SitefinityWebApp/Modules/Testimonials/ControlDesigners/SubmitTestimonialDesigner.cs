using System.Collections.Generic;
using System.Web.UI;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Modules.Testimonials.ControlDesigners
{
    public class SubmitTestimonialDesigner : ControlDesignerBase
    {
        private string _layoutTemplatePath = "~/Modules/Testimonials/ControlDesigners/SubmitTestimonialDesignerTemplate.ascx";

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
        }
 
    }
}