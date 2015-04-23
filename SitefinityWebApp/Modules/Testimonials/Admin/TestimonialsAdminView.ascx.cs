using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SitefinityWebApp.Modules.Testimonials.Data;
using Telerik.Sitefinity.Web;
using Telerik.Web.UI;

namespace SitefinityWebApp.Modules.Testimonials.Admin
{
    public partial class TestimonialsAdminView : System.Web.UI.UserControl
    {
        TestimonialsContext context = TestimonialsContext.Get();

        protected void Page_Load(object sender, EventArgs e)
        {
            var linkColumn = TestimonialsGrid.MasterTableView.Columns.FindByUniqueName("ID") as GridHyperLinkColumn;
            linkColumn.DataNavigateUrlFormatString = string.Concat(ResolveUrl(SiteMapBase.GetActualCurrentNode().Url), "/Edit/{0}");

            TestimonialsGrid.DataSource = context.Testimonials;
            TestimonialsGrid.DataBind();
        }

        protected void TestimonialsGrid_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            if (e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"] == null) return;

            Guid id;
            if (!Guid.TryParse(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"].ToString(), out id)) return;

            var item = context.Testimonials.FirstOrDefault(t => t.Id == id);
            if (item == null) return;

            context.Delete(item);
            context.SaveChanges();

            TestimonialsGrid.DataSource = context.Testimonials;
            TestimonialsGrid.DataBind();
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            if (context != null)
                context.Dispose();
        }
 
    }
}