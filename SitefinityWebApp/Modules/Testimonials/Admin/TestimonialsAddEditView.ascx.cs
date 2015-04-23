using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web;

namespace SitefinityWebApp.Modules.Testimonials.Admin
{
    public partial class TestimonialsAddEditView : UserControl
    {
        public enum AdminControlMode
        {
            Create,
            Edit
        }

        private const string UrlNameCharsToReplace = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        private const string UrlNameReplaceString = "-";
        private readonly TestimonialsContext context = TestimonialsContext.Get();
        private Guid testimonialID = Guid.Empty;
        public AdminControlMode Mode { get; set; }

        protected Guid TestimonialID
        {
            get
            {
                if (testimonialID == Guid.Empty)
                {
                    var param = Request.RequestContext.RouteData.Values["Params"] as string[];
                    if (param == null) return Guid.Empty;

                    Guid id;
                    if (!Guid.TryParse(param[0], out id)) return Guid.Empty;

                    var testimonial = context.Testimonials.FirstOrDefault(t => t.Id == id);
                    testimonialID = (testimonial == null) ? Guid.Empty : testimonial.Id;
                }
                return testimonialID;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack || Mode != AdminControlMode.Edit) return;

            var testimonial = context.Testimonials.Where(t => t.Id == TestimonialID).FirstOrDefault();
            if (testimonial == null) return;

            Name.Text = testimonial.Name;
            Summary.Text = testimonial.Summary;
            Text.Value = testimonial.Text;
            Rating.Value = testimonial.Rating;
            Published.Checked = testimonial.Published;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case AdminControlMode.Edit:

                    // update existing testimonial
                    var testimonial = context.Testimonials.Where(t => t.Id == TestimonialID).FirstOrDefault();
                    if (testimonial == null) return; // default 404 response

                    // mark route handled/found
                    RouteHelper.SetUrlParametersResolved();

                    testimonial.Name = Name.Text;
                    testimonial.UrlName = Regex.Replace(Name.Text.ToLower(), UrlNameCharsToReplace, UrlNameReplaceString);
                    testimonial.Summary = Summary.Text;
                    testimonial.Text = Text.Value.ToString();
                    testimonial.Rating = Rating.Value;
                    testimonial.Published = Published.Checked;
                    break;

                case AdminControlMode.Create:
                    // create and save new testimonial
                    var newTestimonial = new Testimonial();
                    newTestimonial.Name = Name.Text;
                    newTestimonial.UrlName = Regex.Replace(Name.Text.ToLower(), UrlNameCharsToReplace,
                        UrlNameReplaceString);
                    newTestimonial.Summary = Summary.Text;
                    newTestimonial.Text = Text.Value.ToString();
                    newTestimonial.Rating = Rating.Value;
                    newTestimonial.Published = Published.Checked;
                    context.Add(newTestimonial);
                    break;
            }

            // save and return to main view
            context.SaveChanges();
            Response.Redirect(ResolveUrl(SiteMapBase.GetActualCurrentNode().ParentNode.Url));
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (context != null)
                context.Dispose();
        }
    }
}