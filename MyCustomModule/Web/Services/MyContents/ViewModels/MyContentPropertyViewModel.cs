using System;
using System.Linq;
using System.Runtime.Serialization;

namespace MyCustomModule.Web.Services.MyContents.ViewModels
{
    /// <summary>
    /// A view model for the myContent properties.
    /// This view model is used by the services.
    /// </summary>
    [DataContract]
    public class MyContentPropertyViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name
        {
            get;
            set;
        }
    }
}
