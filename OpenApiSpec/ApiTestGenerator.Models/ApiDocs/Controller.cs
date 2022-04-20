using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestGenerator.Models.ApiDocs
{
    /// <summary>
    /// An object that stores a list of certain
    /// <see cref="http://spec.openapis.org/oas/v3.0.3#operation-object"/> items
    /// grouped by the 'name' of the controller they are associated with in code. 
    /// </summary>
    public class Controller
    {
        #region -- Properties -----
        /// <summary>
        /// The name of the controller
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A collection of <see cref="EndPoint"/> objects and their names
        /// </summary>
        public Dictionary<string, EndPoint> EndPoints { get; private set; }
        #endregion

        #region -- Constructors -----
        public Controller()
        {
            Name = string.Empty;
            EndPoints = new Dictionary<string, EndPoint>();
        }
        #endregion

    }
}
