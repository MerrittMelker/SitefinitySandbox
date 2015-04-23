using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Telerik.Sitefinity.Data.Linq.Dynamic;
using Telerik.Sitefinity.Utilities.Json;
using MyCustomModule.Models;
using MyCustomModule.Web.Services.MyContents.ViewModels;

namespace MyCustomModule.Web.Services.MyContents
{
    public class MyContentsService
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MyContentsService" /> class.
        /// </summary>
        public MyContentsService()
        {
            manager = MyCustomModuleManager.GetManager();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the total items count.
        /// </summary>
        /// <param name="sortExpression">The sort expression.</param>
        /// <returns></returns>
        public int GetTotalItemsCount(string sortExpression)
        {
            return manager.GetMyContents().Count();
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="startRowIndex">Start index of the row.</param>
        /// <param name="maximumRows">The maximum rows.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <returns></returns>
        public IEnumerable<MyContentViewModel> GetItems(int startRowIndex, int maximumRows, string sortExpression)
        {
            var viewData = new List<MyContentViewModel>();
            var items = manager.GetMyContents().OrderBy(sortExpression).Skip(startRowIndex).Take(maximumRows);
            foreach (var item in items)
            {
                var viewModel = new MyContentViewModel();
                MyContentsViewModelTranslator.ToViewModel(item, viewModel, manager);
                viewData.Add(viewModel);
            }
            return viewData;
        }

        /// <summary>
        /// Deletes the specified ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        public void Delete(string ids)
        {
            foreach (var id in JsonUtility.FromJson<Guid[]>(ids))
            {
                var item = manager.GetMyContent(id);
                if (item != null)
                    manager.DeleteMyContent(item);
            }

            manager.SaveChanges();
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <param name="itemId">The item id.</param>
        /// <returns></returns>
        public MyContentViewModel GetItem(Guid itemId)
        {
            var item = manager.GetMyContent(itemId);
            var viewModel = new MyContentViewModel();
            MyContentsViewModelTranslator.ToViewModel(item, viewModel, manager);
            return viewModel;
        }

        /// <summary>
        /// Creates the myContent.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        public MyContent CreateItem(MyContentViewModel viewModel)
        {
            var item = manager.CreateMyContent();
            MyContentsViewModelTranslator.ToModel(viewModel, item, manager);
            manager.SaveChanges();
            return item;
        }

        /// <summary>
        /// Updates the myContent.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="viewModel">The view model.</param>
        public void UpdateItem(Guid id, MyContentViewModel viewModel)
        {
            var item = manager.GetMyContent(id);
            if (item == null)
                throw new NullReferenceException("MyContent can not be found.");
            MyContentsViewModelTranslator.ToModel(viewModel, item, manager);
            manager.UpdateMyContent(item);
            manager.SaveChanges();
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        public List<MyContentPropertyViewModel> GetProperties()
        {
            var properties = new List<MyContentPropertyViewModel>();

            foreach (PropertyInfo property in typeof(MyContent).GetProperties())
                if (!this.systemProperties.Contains(property.Name))
                    properties.Add(new MyContentPropertyViewModel() { Name = property.Name });

            return properties;
        }
        #endregion

        #region Private fields
        private readonly MyCustomModuleManager manager = null;
        private readonly IEnumerable<string> systemProperties = new List<string>()
        {
            "Id", "Transaction", "ApplicationName", "Provider",
        };
        #endregion
    }
}