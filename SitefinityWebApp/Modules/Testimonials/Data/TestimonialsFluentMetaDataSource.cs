using System.Collections.Generic;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Metadata.Fluent;

namespace SitefinityWebApp.Modules.Testimonials.Data
{
    public class TestimonialsFluentMetaDataSource : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            var mappings = new List<MappingConfiguration>();
            var testimonialMapping = MapTestimonialsTable();
            mappings.Add(testimonialMapping);
            return mappings;
        }

        private MappingConfiguration<Testimonial> MapTestimonialsTable()
        {
            // map to table
            var tableMapping = new MappingConfiguration<Testimonial>();
            tableMapping.MapType().ToTable("sf_testimonials");

            // map properties
            tableMapping.HasProperty(t => t.Id).IsIdentity(KeyGenerator.Guid);
            tableMapping.HasProperty(t => t.Name).HasLength(255).IsNotNullable();
            tableMapping.HasProperty(t => t.Summary).HasLength(255).IsNotNullable();
            tableMapping.HasProperty(t => t.Text).HasColumnType("varchar(max)");
            tableMapping.HasProperty(t => t.Rating).IsNotNullable();
            tableMapping.HasProperty(t => t.DatePosted).IsNotNullable();
            tableMapping.HasProperty(t => t.Published).IsNotNullable();
            tableMapping.HasProperty(t => t.UrlName).IsNotNullable();

            return tableMapping;
        }
    }
}