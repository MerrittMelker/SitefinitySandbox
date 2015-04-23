using System.Linq;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.Sitefinity.Data.OA;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
    public class TestimonialsContext : SitefinityOAContext
    {
        public TestimonialsContext(string connectionString, BackendConfiguration backendConfig,
            MetadataContainer metadataContainer)
            : base(connectionString, backendConfig, metadataContainer)
        {
        }

        public IQueryable<Testimonial> Testimonials
        {
            get { return GetAll<Testimonial>(); }
        }

        public static TestimonialsContext Get()
        {
            return
                OpenAccessConnection.GetContext(new TestimonialsMetaDataProvider(), "Sitefinity") as TestimonialsContext;
        }
    }
}