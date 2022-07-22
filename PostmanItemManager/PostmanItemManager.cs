using System;
using System.Collections.Generic;
using System.Text;
using ApiTestGenerator.Models.ApiDocs;
using PostmanManager;

namespace PostmanItemManagement
{
    public class PostmanItemManager
    {
        #region -- Propertiees -----
        public PostmanCollection postmanCollection { get; set; }
        #endregion

        #region -- Constructor -----
        public PostmanItemManager() { }

        public PostmanItemManager(string fileName)
        {
            //postmanCollection = PostmanCollection.LoadCollection("Swagger Petstore.postman_collection.json");
            postmanCollection = PostmanCollection.LoadCollection(fileName);
        }
        #endregion

        #region -- public methods -----
        public void BuildPostmanCollectionFromApiSet(ApiDoc apiSet)
        {

        }

        public void SaveCollection(string fileName)
        {
            PostmanCollection.SaveCollection(postmanCollection, fileName);
        }
        #endregion


    }
}
