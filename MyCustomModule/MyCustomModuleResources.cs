using System;
using System.Linq;
using Telerik.Sitefinity.Localization;
using Telerik.Sitefinity.Localization.Data;

namespace MyCustomModule
{
    /// <summary>
    /// Localizable strings for the MyCustomModule module
    /// </summary>
    /// <remarks>
    /// You can use Sitefinity Thunder to edit this file.
    /// To do this, open the file's context menu and select Edit with Thunder.
    /// 
    /// If you wish to install this as a part of a custom module,
    /// add this to the module's Initialize method:
    /// App.WorkWith()
    ///     .Module(ModuleName)
    ///     .Initialize()
    ///         .Localization<MyCustomModuleResources>();
    /// </remarks>
    /// <see cref="http://www.sitefinity.com/documentation/documentationarticles/developers-guide/how-to/how-to-import-events-from-facebook/creating-the-resources-class"/>
    [ObjectInfo("MyCustomModuleResources", ResourceClassId = "MyCustomModuleResources", Title = "MyCustomModuleResourcesTitle", TitlePlural = "MyCustomModuleResourcesTitlePlural", Description = "MyCustomModuleResourcesDescription")]
    public class MyCustomModuleResources : Resource
    {
        #region Construction
        /// <summary>
        /// Initializes new instance of <see cref="MyCustomModuleResources"/> class with the default <see cref="ResourceDataProvider"/>.
        /// </summary>
        public MyCustomModuleResources()
        {
        }

        /// <summary>
        /// Initializes new instance of <see cref="MyCustomModuleResources"/> class with the provided <see cref="ResourceDataProvider"/>.
        /// </summary>
        /// <param name="dataProvider"><see cref="ResourceDataProvider"/></param>
        public MyCustomModuleResources(ResourceDataProvider dataProvider)
            : base(dataProvider)
        {
        }
        #endregion

        #region Class Description
        /// <summary>
        /// MyCustomModule Resources
        /// </summary>
        [ResourceEntry("MyCustomModuleResourcesTitle",
            Value = "MyCustomModule module labels",
            Description = "The title of this class.",
            LastModified = "2015/04/23")]
        public string MyCustomModuleResourcesTitle
        {
            get
            {
                return this["MyCustomModuleResourcesTitle"];
            }
        }

        /// <summary>
        /// MyCustomModule Resources Title plural
        /// </summary>
        [ResourceEntry("MyCustomModuleResourcesTitlePlural",
            Value = "MyCustomModule module labels",
            Description = "The title plural of this class.",
            LastModified = "2015/04/23")]
        public string MyCustomModuleResourcesTitlePlural
        {
            get
            {
                return this["MyCustomModuleResourcesTitlePlural"];
            }
        }

        /// <summary>
        /// Contains localizable resources for MyCustomModule module.
        /// </summary>
        [ResourceEntry("MyCustomModuleResourcesDescription",
            Value = "Contains localizable resources for MyCustomModule module.",
            Description = "The description of this class.",
            LastModified = "2015/04/23")]
        public string MyCustomModuleResourcesDescription
        {
            get
            {
                return this["MyCustomModuleResourcesDescription"];
            }
        }
        #endregion

        #region Labels
        /// <summary>
        /// word: Actions
        /// </summary>
        [ResourceEntry("ActionsLabel",
            Value = "Actions",
            Description = "word: Actions",
            LastModified = "2015/04/23")]
        public string ActionsLabel
        {
            get
            {
                return this["ActionsLabel"];
            }
        }

        /// <summary>
        /// Title of the link for closing the dialog and going back to the MyCustomModule module
        /// </summary>
        [ResourceEntry("BackToLabel",
            Value = "Go Back",
            Description = "Title of the link for closing the dialog and going back",
            LastModified = "2015/04/23")]
        public string BackToLabel
        {
            get
            {
                return this["BackToLabel"];
            }
        }

        /// <summary>
        /// word: Cancel
        /// </summary>
        [ResourceEntry("CancelLabel",
            Value = "Cancel",
            Description = "word: Cancel",
            LastModified = "2015/04/23")]
        public string CancelLabel
        {
            get
            {
                return this["CancelLabel"];
            }
        }

        /// <summary>
        /// word: Save
        /// </summary>
        /// <value>Save</value>
        [ResourceEntry("SaveLabel",
            Value = "Save",
            Description = "word: Save",
            LastModified = "2015/04/23")]
        public string SaveLabel
        {
            get
            {
                return this["SaveLabel"];
            }
        }

        /// <summary>
        /// phrase: Save changes
        /// </summary>
        [ResourceEntry("SaveChangesLabel",
            Value = "Save changes",
            Description = "phrase: Save changes",
            LastModified = "2015/04/23")]
        public string SaveChangesLabel
        {
            get
            {
                return this["SaveChangesLabel"];
            }
        }

        /// <summary>
        /// word: Delete
        /// </summary>
        [ResourceEntry("DeleteLabel",
            Value = "Delete",
            Description = "word: Delete",
            LastModified = "2015/04/23")]
        public string DeleteLabel
        {
            get
            {
                return this["DeleteLabel"];
            }
        }

        /// <summary>
        /// Phrase: Yes, delete these items
        /// </summary>
        /// <value>Yes, delete these items</value>
        [ResourceEntry("YesDeleteTheseItemsButton",
            Value = "Yes, delete these items",
            Description = "Phrase: Yes, delete these items",
            LastModified = "2015/04/23")]
        public string YesDeleteTheseItemsButton
        {
            get
            {
                return this["YesDeleteTheseItemsButton"];
            }
        }

        /// <summary>
        /// Text of the button that confirms deletion of an item.
        /// </summary>
        /// <value>Yes, delete this item</value>
        [ResourceEntry("YesDeleteThisItemButton",
            Value = "Yes, delete this item",
            Description = "Text of the button that confirms deletion of an item.",
            LastModified = "2015/04/23")]
        public string YesDeleteThisItemButton
        {
            get
            {
                return this["YesDeleteThisItemButton"];
            }
        }

        /// <summary>
        /// Phrase: items are about to be deleted. Continue?
        /// </summary>
        /// <value>items are about to be deleted. Continue?</value>
        [ResourceEntry("BatchDeleteConfirmationMessage",
            Value = "items are about to be deleted. Continue?",
            Description = "Phrase: items are about to be deleted. Continue?",
            LastModified = "2015/04/23")]
        public string BatchDeleteConfirmationMessage
        {
            get
            {
                return this["BatchDeleteConfirmationMessage"];
            }
        }

        /// <summary>
        /// word: Sort
        /// </summary>
        /// <value>Sort</value>
        [ResourceEntry("SortLabel",
            Value = "Sort",
            Description = "word: Sort",
            LastModified = "2015/04/23")]
        public string SortLabel
        {
            get
            {
                return this["SortLabel"];
            }
        }

        /// <summary>
        /// Phrase: Custom sorting
        /// </summary>
        /// <value>Custom sorting</value>
        [ResourceEntry("CustomSortingDialogHeader",
            Value = "Custom sorting",
            Description = "Phrase: Custom sorting",
            LastModified = "2015/04/23")]
        public string CustomSortingDialogHeader
        {
            get
            {
                return this["CustomSortingDialogHeader"];
            }
        }

        /// <summary>
        /// word: or
        /// </summary>
        /// <value>or</value>
        [ResourceEntry("OrLabel",
            Value = "or",
            Description = "word: or",
            LastModified = "2015/04/23")]
        public string OrLabel
        {
            get
            {
                return this["OrLabel"];
            }
        }

        /// <summary>
        /// Phrase: Sort by
        /// </summary>
        /// <value>Sort by</value>
        [ResourceEntry("SortByLabel",
            Value = "Sort by",
            Description = "Phrase: Sort by",
            LastModified = "2015/04/23")]
        public string SortByLabel
        {
            get
            {
                return this["SortByLabel"];
            }
        }

        /// <summary>
        /// word: Yes
        /// </summary>
        /// <value>Yes</value>
        [ResourceEntry("YesLabel",
            Value = "Yes",
            Description = "word: Yes",
            LastModified = "2013/06/26")]
        public string YesLabel
        {
            get
            {
                return this["YesLabel"];
            }
        }

        /// <summary>
        /// word: No
        /// </summary>
        /// <value>No</value>
        [ResourceEntry("NoLabel",
            Value = "No",
            Description = "word: No",
            LastModified = "2013/06/26")]
        public string NoLabel
        {
            get
            {
                return this["NoLabel"];
            }
        }
        #endregion

        #region MyContents
        /// <summary>
        /// Messsage: PageTitle
        /// </summary>
        /// <value>Title for the MyContent's page.</value>
        [ResourceEntry("MyContentGroupPageTitle",
            Value = "MyContent",
            Description = "The title of MyContent's page.",
            LastModified = "2015/04/23")]
        public string MyContentGroupPageTitle
        {
            get
            {
                return this["MyContentGroupPageTitle"];
            }
        }

        /// <summary>
        /// Messsage: PageDescription
        /// </summary>
        /// <value>Description for the MyContent's page.</value>
        [ResourceEntry("MyContentGroupPageDescription",
            Value = "MyContent",
            Description = "The description of MyContent's page.",
            LastModified = "2015/04/23")]
        public string MyContentGroupPageDescription
        {
            get
            {
                return this["MyContentGroupPageDescription"];
            }
        }

        /// <summary>
        /// The URL name of MyContent's page.
        /// </summary>
        [ResourceEntry("MyContentGroupPageUrlName",
            Value = "MyCustomModule-MyContent",
            Description = "The URL name of MyContent's page.",
            LastModified = "2015/04/23")]
        public string MyContentGroupPageUrlName
        {
            get
            {
                return this["MyContentGroupPageUrlName"];
            }
        }

        /// <summary>
        /// Message displayed to user when no myContents exist in the system
        /// </summary>
        /// <value>No myContents have been created yet</value>
        [ResourceEntry("NoMyContentsCreatedMessage",
            Value = "No myContents have been created yet",
            Description = "Message displayed to user when no myContents exist in the system",
            LastModified = "2015/04/23")]
        public string NoMyContentsCreatedMessage
        {
            get
            {
                return this["NoMyContentsCreatedMessage"];
            }
        }

        /// <summary>
        /// Title of the button for creating a new myContent
        /// </summary>
        /// <value>Create a myContent</value>
        [ResourceEntry("CreateAMyContent",
            Value = "Create a myContent",
            Description = "Title of the button for creating a new myContent",
            LastModified = "2015/04/23")]
        public string CreateAMyContent
        {
            get
            {
                return this["CreateAMyContent"];
            }
        }

        /// <summary>
        /// Label for editing a new myContent
        /// </summary>
        /// <value>Create a myContent</value>
        [ResourceEntry("EditAMyContent",
            Value = "Edit a myContent",
            Description = "Label for editing a new myContent",
            LastModified = "2015/04/23")]
        public string EditAMyContent
        {
            get
            {
                return this["EditAMyContent"];
            }
        }

        /// <summary>
        /// MyContent Title.
        /// </summary>
        /// <value>Title</value>
        [ResourceEntry("MyContentTitleLabel",
            Value = "Title",
            Description = "MyContent Title.",
            LastModified = "2015/04/23")]
        public string MyContentTitleLabel
        {
            get
            {
                return this["MyContentTitleLabel"];
            }
        }

        /// <summary>
        /// MyContent Title description.
        /// </summary>
        /// <value>Enter the item's title (required)</value>
        [ResourceEntry("MyContentTitleDescription",
            Value = "Enter the item's title (required)",
            Description = "MyContent Title description.",
            LastModified = "2015/04/23")]
        public string MyContentTitleDescription
        {
            get
            {
                return this["MyContentTitleDescription"];
            }
        }

        /// <summary>
        /// Error message displayed if the user does not enter myContent Title.
        /// </summary>
        [ResourceEntry("MyContentTitleCannotBeEmpty",
            Value = "The Title of the myContent cannot be empty.",
            Description = "Error message displayed if the user does not enter myContent Title.",
            LastModified = "2015/04/23")]
        public string MyContentTitleCannotBeEmpty
        {
            get
            {
                return this["MyContentTitleCannotBeEmpty"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters too long Title.
        /// </summary>
        /// <value>Title value is too long. Maximum allowed is 255 characters.</value>
        [ResourceEntry("MyContentTitleInvalidLength",
            Value = "Title value is too long. Maximum allowed is 255 characters.",
            Description = "Error message displayed if the user enters too long Title.",
            LastModified = "2015/04/23")]
        public string MyContentTitleInvalidLength
        {
            get
            {
                return this["MyContentTitleInvalidLength"];
            }
        }

        /// <summary>
        /// MyContent MyNumber.
        /// </summary>
        /// <value>MyNumber</value>
        [ResourceEntry("MyContentMyNumberLabel",
            Value = "MyNumber",
            Description = "MyContent MyNumber.",
            LastModified = "2015/04/23")]
        public string MyContentMyNumberLabel
        {
            get
            {
                return this["MyContentMyNumberLabel"];
            }
        }

        /// <summary>
        /// Error message displayed if the user enters invalid myContent MyNumber.
        /// </summary>
        [ResourceEntry("MyContentMyNumberIsInvalid",
            Value = "The MyNumber of the myContent is invalid.",
            Description = "Error message displayed if the user enters invalid myContent MyNumber.",
            LastModified = "2015/04/23")]
        public string MyContentMyNumberIsInvalid
        {
            get
            {
                return this["MyContentMyNumberIsInvalid"];
            }
        }

        /// <summary>
        /// MyContent MyDate.
        /// </summary>
        /// <value>MyDate</value>
        [ResourceEntry("MyContentMyDateLabel",
            Value = "MyDate",
            Description = "MyContent MyDate.",
            LastModified = "2015/04/23")]
        public string MyContentMyDateLabel
        {
            get
            {
                return this["MyContentMyDateLabel"];
            }
        }

        /// <summary>
        /// Message displayed to user when deleting a user myContent.
        /// </summary>
        [ResourceEntry("DeleteMyContentConfirmationMessage",
            Value = "Are you sure you want to delete this myContent?",
            Description = "Message displayed to user when deleting a user myContent.",
            LastModified = "2015/04/23")]
        public string DeleteMyContentConfirmationMessage
        {
            get
            {
                return this["DeleteMyContentConfirmationMessage"];
            }
        }

        /// <summary>
        /// phrase: Create this myContent
        /// </summary>
        [ResourceEntry("CreateThisMyContentButton",
            Value = "Create this myContent",
            Description = "phrase: Create this myContent",
            LastModified = "2015/04/23")]
        public string CreateThisMyContentButton
        {
            get
            {
                return this["CreateThisMyContentButton"];
            }
        }

        /// <summary>
        /// The URL name of MyContent's page.
        /// </summary>
        /// <value>MyContentMasterPageUrl</value>
        [ResourceEntry("MyContentMasterPageUrl",
            Value = "MyContentMasterPageUrl",
            Description = "The URL name of MyContent's page.",
            LastModified = "2015/04/23")]
        public string MyContentMasterPageUrl
        {
            get
            {
                return this["MyContentMasterPageUrl"];
            }
        }

        /// <summary>
        /// The URL name of MyContent's detail page.
        /// </summary>
        /// <value>MyContentDetailPageUrl</value>
        [ResourceEntry("MyContentDetailPageUrl",
            Value = "MyContentDetailPageUrl",
            Description = "The URL name of MyContent's detail page.",
            LastModified = "2015/04/23")]
        public string MyContentDetailPageUrl
        {
            get
            {
                return this["MyContentDetailPageUrl"];
            }
        }
        #endregion
    }
}