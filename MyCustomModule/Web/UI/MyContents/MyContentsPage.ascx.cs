using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Sitefinity.Utilities.Json;
using Telerik.Sitefinity.Web;
using Telerik.Web.UI;
using Telerik.Sitefinity.Modules.Pages;
using MyCustomModule.Web.Services.MyContents;
using MyCustomModule.Web.Services.MyContents.ViewModels;

namespace MyCustomModule.Web.UI.MyContents
{
    public partial class MyContentsPage : UserControl
    {
        #region Properties
        /// <summary>
        /// Gets the details view URL.
        /// </summary>
        /// <value>The details view URL.</value>
        private string DetailsViewUrl
        {
            get
            {
                if (this.detailsViewUrl == null)
                {
                    var sitemap = BackendSiteMap.GetCurrentProvider();
                    var node = sitemap.FindSiteMapNodeFromKey(MyCustomModuleClass.MyContentDetailPageId.ToString());
                    if (node == null)
                        return "#";
                    this.detailsViewUrl = UrlPath.ResolveUrl(node.Url);
                }
                return this.detailsViewUrl;
            }
        }
        #endregion

        #region Page events

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            PageManager.ConfigureScriptManager(this.Page, ScriptRef.JQuery);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ConfigureControls();
        }

        /// <summary>
        /// Configures the controls.
        /// </summary>
        private void ConfigureControls()
        {
            //populate sortby dropdown list
            var properties = this.service.GetProperties();
            properties.ForEach(p =>
            {
                customSortByDropdown.Items.Add(new ListItem(p.Name, p.Name));
            });

            //set paging and sorting
            if (!Page.IsPostBack)
            {
                string page = Request.QueryString["page"];
                string sort = Request.QueryString["sort"];

                if (!string.IsNullOrEmpty(page))
                    MyContentsMaster.CurrentPageIndex = int.Parse(page);

                if (!string.IsNullOrEmpty(sort))
                {
                    sortExpression.Value = sort;

                    //set visual state for the sorting drop down
                    sortDropDown.SelectedValue = "custom";
                    foreach (ListItem item in sortDropDown.Items)
                        if (item.Value == sortExpression.Value)
                            sortDropDown.SelectedValue = item.Value;
                }
            }

            //show or hide editcustom sorting option
            foreach (ListItem item in sortDropDown.Items)
                if (item.Value == "editcustom")
                    item.Enabled = (sortDropDown.SelectedValue == "custom" ||
                                    sortDropDown.SelectedValue == "editcustom");

            if (sortDropDown.SelectedValue == "editcustom")
                sortDropDown.SelectedValue = "custom";

            //set custom sorting screen
            if (sortDropDown.SelectedValue == "custom")
            {
                string[] sortParams = sortExpression.Value.Split(' ');
                string sortField = sortParams[0];
                string sortDirection = sortParams[1];

                customSortByDropdown.SelectedValue = sortField;

                ascRadioChoice.Checked = (sortDirection == "ASC");
                descRadioChoice.Checked = !ascRadioChoice.Checked;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Called when [confirm delete button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void OnConfirmDeleteButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedItemId.Value))
            {
                var ids = new List<Guid>()
                {
                    new Guid(selectedItemId.Value)
                };
                this.DeleteItems(ids);
                selectedItemId.Value = string.Empty;
            }
        }

        /// <summary>
        /// Called when [confirm batch delete button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void OnConfirmBatchDeleteButtonClicked(object sender, EventArgs e)
        {
            var ids = new List<Guid>();
            MyContentsMaster.MasterTableView.GetSelectedItems().ToList().ForEach(gridDataItem =>
            {
                var item = gridDataItem.DataItem as MyContentViewModel;
                if (item != null)
                    ids.Add(item.Id);
            });
            this.DeleteItems(ids);
        }

        /// <summary>
        /// Handles the DataBound event of the ProductsGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void MyContentsGrid_DataBound(object sender, EventArgs e)
        {
            var grid = (RadGrid)sender;
            if (grid.Items.Count == 0)
            {
                this.myContentsDecisionScreen.Style["display"] = "block";
                this.myContentsMainPage.Style["display"] = "none";
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deletes the items by id.
        /// </summary>
        protected void DeleteItems(List<Guid> ids)
        {
            myContentsDataSource.DeleteParameters["ids"].DefaultValue = JsonUtility.ToJson(ids);
            myContentsDataSource.Delete();
        }

        /// <summary>
        /// Gets the details page URL.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        protected string GetDetailsPageUrl(string id = null)
        {
            var returnUrl = Server.UrlEncode(string.Format("{0}?page={1}&sort={2}", Page.Request.Url.AbsolutePath, MyContentsMaster.CurrentPageIndex, sortExpression.Value));

            if (string.IsNullOrEmpty(id))
                return string.Format("{0}?ReturnUrl={1}", this.DetailsViewUrl, returnUrl);

            return string.Format("{0}?Id={1}&ReturnUrl={2}", this.DetailsViewUrl, id, returnUrl);
        }
        #endregion

        #region Private fields
        private string detailsViewUrl = null;
        private MyContentsService service = new MyContentsService();
        #endregion
    }
}