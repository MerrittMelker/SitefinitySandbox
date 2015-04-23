using System;
using System.Linq;
using Telerik.Sitefinity.Data;
using MyCustomModule.Models;

namespace MyCustomModule
{
    public abstract class MyCustomModuleDataProvider : DataProviderBase
    {
        #region Public and overriden methods
        /// <summary>
        /// Gets the known types.
        /// </summary>
        public override Type[] GetKnownTypes()
        {
            if (knownTypes == null)
            {
                knownTypes = new Type[]
                {
                    typeof(MyContent)
                };
            }
            return knownTypes;
        }

        /// <summary>
        /// Gets the root key.
        /// </summary>
        /// <value>The root key.</value>
        public override string RootKey
        {
            get
            {
                return "MyCustomModuleDataProvider";
            }
        }
        #endregion

        #region Abstract methods
        /// <summary>
        /// Creates a new MyContent and returns it.
        /// </summary>
        /// <returns>The new MyContent.</returns>
        public abstract MyContent CreateMyContent();

        /// <summary>
        /// Gets a MyContent by a specified ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>The MyContent.</returns>
        public abstract MyContent GetMyContent(Guid id);

        /// <summary>
        /// Gets a query of all the MyContent items.
        /// </summary>
        /// <returns>The MyContent items.</returns>
        public abstract IQueryable<MyContent> GetMyContents();

        /// <summary>
        /// Updates the MyContent.
        /// </summary>
        /// <param name="entity">The MyContent entity.</param>
        public abstract void UpdateMyContent(MyContent entity);

        /// <summary>
        /// Deletes the MyContent.
        /// </summary>
        /// <param name="entity">The MyContent entity.</param>
        public abstract void DeleteMyContent(MyContent entity);
        #endregion

        #region Private fields and constants
        private static Type[] knownTypes;
        #endregion
    }
}