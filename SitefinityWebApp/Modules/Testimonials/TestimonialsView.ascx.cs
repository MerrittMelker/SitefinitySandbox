using System;
using System.Linq;
using SitefinityWebApp.Modules.Testimonials.ControlDesigners;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity;
using Telerik.Sitefinity.Modules.Pages;
using Telerik.Sitefinity.Web;
using Telerik.Sitefinity.Web.UI.ControlDesign;
 

namespace SitefinityWebApp.Modules.Testimonials
{
    [ControlDesigner(typeof(TestimonialsViewDesigner)), PropertyEditorTitle("Testimonials")]
    public partial class TestimonialsView : System.Web.UI.UserControl
    {
        public static readonly string ViewName = "TestimonialsView";

        private int _count = 10;
        private TestimonialsContext context = TestimonialsContext.Get();

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public enum ControlMode
        {
            List,
            Details
        }

        public ControlMode Mode
        {
            get { return TestimonialID == Guid.Empty ? ControlMode.List : ControlMode.Details; }
        }

        private Guid testimonialID = Guid.Empty;

        protected Guid TestimonialID
        {
            get
            {
                if (testimonialID == Guid.Empty)
                {
                    var param = Request.RequestContext.RouteData.Values["Params"] as string[];
                    if (param == null) return Guid.Empty;

                    var url = param[0];
                    var testimonial = context.Testimonials.FirstOrDefault(t => t.UrlName == url);
                    testimonialID = (testimonial == null) ? Guid.Empty : testimonial.Id;
                }
                return testimonialID;
            }
        }
 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            switch (Mode)
            {
                // List View
                case ControlMode.List:
                    ShowList();
                    break;

                // Details View
                case ControlMode.Details:
                    ShowDetails();
                    break;
            }
        }

        private void ShowList()
        {
            var testimonials = context.Testimonials.Where(t => t.Published).Take(Count);
            TestimonialsRepeater.DataSource = testimonials;
            TestimonialsRepeater.DataBind();
            TestimonialsMultiView.SetActiveView(ListView);
        }

        private void ShowDetails()
        {
            var testimonial = context.Testimonials.Where(t => t.Id == TestimonialID && t.Published).FirstOrDefault();
            if (testimonial == null) return; // new default 404 response

            RouteHelper.SetUrlParametersResolved();

            Name.Text = testimonial.Name;
            Text.Text = testimonial.Text;
            Rating.Value = testimonial.Rating;
            DatePosted.Text = testimonial.DatePosted.ToLongDateString();
            TestimonialsMultiView.SetActiveView(DetailsView);

            Page.Title = string.Concat("Testimonials: ", testimonial.Name);
        }

        public Guid DetailsPageID { get; set; }

        protected string DetailsPageUrl()
        {
            // check for custom details page
            var currentPageUrl = SiteMapBase.GetActualCurrentNode().Url;
            if (this.DetailsPageID == Guid.Empty)
                return currentPageUrl;

            // make sure page exists
            var page = App.WorkWith().Pages().Where(p => p.Id == this.DetailsPageID).Get().FirstOrDefault();
            if (page == null) return currentPageUrl;

            // return page url
            return page.GetFullUrl();
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (context != null)
                context.Dispose();
        }
    }
}