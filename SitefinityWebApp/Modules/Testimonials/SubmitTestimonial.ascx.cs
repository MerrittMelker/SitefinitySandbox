using System;
using System.Text.RegularExpressions;
using SitefinityWebApp.Modules.Testimonials.ControlDesigners;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web.UI.ControlDesign;

namespace SitefinityWebApp.Modules.Testimonials
{
    [ControlDesigner(typeof(SubmitTestimonialDesigner)), PropertyEditorTitle("Submit Testimonial")]
    public partial class SubmitTestimonial : System.Web.UI.UserControl
    {
        public static readonly string ViewName = "SubmitTestimonial";

        private bool autoPublish = false;
        public bool AutoPublish
        {
            get { return autoPublish; }
            set { autoPublish = value; }
        }
 

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private const string UrlNameCharsToReplace = @"[^\w\-\!\$\'\(\)\=\@\d_]+";
        private const string UrlNameReplaceString = "-";

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // create and save unpublished testimonial
                var context = TestimonialsContext.Get();
                var newTestimonial = new Testimonial();
                newTestimonial.Name = Name.Text;
                newTestimonial.UrlName = Regex.Replace(Name.Text.ToLower(), UrlNameCharsToReplace, UrlNameReplaceString);
                newTestimonial.Summary = Summary.Text;
                newTestimonial.Text = Text.Value.ToString();
                newTestimonial.Rating = Rating.Value;
                newTestimonial.Published = AutoPublish;
                context.Add(newTestimonial);

                context.SaveChanges();

                if (AutoPublish)
                    Status.Text = "<p><strong>Your testimonial has been submitted successfully!</p>";
                else
                    Status.Text = "<p><strong>Your testimonial has been submitted successfully! Please allow 24 hours for review by the administration.</p>";

                // reset form
                Name.Text = string.Empty;
                Summary.Text = string.Empty;
                Text.Value = string.Empty;
                Rating.Value = 0;
            }
            catch (Exception ex)
            {
                Status.Text = "<p><em>An error occurred while submitting your testimonial. Please try again.</p>";
            }
        }
    }
}