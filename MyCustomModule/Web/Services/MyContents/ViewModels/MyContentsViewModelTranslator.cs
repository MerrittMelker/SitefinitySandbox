using System;
using System.Linq;
using MyCustomModule.Models;

namespace MyCustomModule.Web.Services.MyContents.ViewModels
{
    /// <summary>
    /// Provides methods for translating view models to models and vice versa for the MyCustomModule module.
    /// </summary>
    public static class MyContentsViewModelTranslator
    {
        #region MyContent
        /// <summary>
        /// Translates MyContent view model to MyContent model.
        /// </summary>
        /// <param name="source">
        /// An instance of the <see cref="MyContentViewModel"/>.
        /// </param>
        /// <param name="target">
        /// An instance of the <see cref="MyContent"/>.
        /// </param>
        public static void ToModel(MyContentViewModel source, MyContent target, MyCustomModuleManager manager)
        {
            target.Title = source.Title;
            target.MyNumber = source.MyNumber;
            target.MyDate = source.MyDate;
        }

        /// <summary>
        /// Translates MyContent to MyContent view model.
        /// </summary>
        /// <param name="source">
        /// An instance of the <see cref="MyContent"/>.
        /// </param>
        /// <param name="target">
        /// An instance of the <see cref="MyContentViewModel"/>.
        /// </param>
        public static void ToViewModel(MyContent source, MyContentViewModel target, MyCustomModuleManager manager)
        {
            target.Id = source.Id;
            target.LastModified = source.LastModified;
            target.DateCreated = source.DateCreated;

            target.Title = source.Title;
            target.MyNumber = source.MyNumber;
            target.MyDate = source.MyDate;
        }
        #endregion
    }
}
