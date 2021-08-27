# WebTestItemManager
The purpose of this namespace is to provide a set of metadata and routines that allows an application to easily display, analyze and edit an HttpWebTest. Since the HttpWebTest design uses a nested schema that allows for several combinations of items and collections at different levels, it can be difficult to locate items, or to summarize items. This readme describes the basic workings of the Item Manager.

## WebTestItemCollection Heirarchy and the WebTestItemMetaData
When loading a webtest into the Item Manager, the manager creates a flat collection of "Web Test Item Meta Data" that has an entry for every item in the webtest. Since a web test can have multiple levels of nested objects and since the types of nested objcts can vary, this flat list of metadata gives us an easy way to search for items and retrieve them without having to do recursive searches every time. The meta data includes the following items:
```csharp
        public string sTreeLoc { get; set; }
        public int iTreeDepth { get; set; }
        public WebTestItemType wtit { get; set; }
        public WTItemSubType wtist { get; set; }
        public Guid guid { get; set; }
        public Uri Uri { get; set; }
```
The item that allows us to easily track and retrieve the actual web test items is the `sTreeLoc` string. This string tracks the location of an item by using heirarchical notation of the form `Root.x.y.z` where `Root` defines the entire collection, `x` defines the index of the main level item, `y` indicates the index of the sub item within the main level item's collection, and so on. The following shows a couple of examples:
```
Actual Item                     sTreeLoc        Uri    
============================================================
Root Item                       Root            ""
    Request 1                   Root.0          "www.contoso.com"
    Request 2                   Root.1          "www.contoso.com/home"
    Loop Control 1              Root.2          ""
        Request 3               Root.2.0        "www.contoso.com/login"
        Transaction 1           Root.2.1        ""
            Request 4           Root.2.1.0      "www.bing.com"
            Request 5           Root.2.1.1      "www.bing.com/login"
            Comment 1           Root.2.1.2      ""
        Request 6               Root.2.2        "www.contoso.com/index.htm"
    Comment 2                   Root.3          ""
    Transaction 2               Root.4          ""
        Request 7               Root.4.0        "www.contoso.com/logout"
        Request 8               Root.4.1        "www.contoso.com/confirmLogout"

```
Let's say we want to get the first page that goes to "bing.com", All I need to do is search the meta dat collection for the first url that contains "bing.com". I will get the meta data for Request 4. To retrieve Request 4, I call into 
```csharp
        public WebTestItem GetActualItem(string sTreeLoc, WebTestItemCollection wtic)
```
which takes the tree location `"Root.2.1.0"` as a string and transforms it into `IEnumerable<int>` list `{2,1,0}`. It then calls the recursive method 
```csharp
        public WebTestItem GetActualItem(IEnumerable<int> indexes, WebTestItemCollection wtic)
        {
            if (indexes.Count() == 1)
                return wtic[indexes.ElementAt(0)];

            return GetActualItem(indexes.Skip(1), GetChildItems(wtic[indexes.ElementAt(0)]));
        }
```
passing in the value {2,1,0} and the webtestitems.
The index count is greater than 1 (there are three items in the list), so the method calls itself again, but 
- removes the first entry from the list before passing in the value {1,0} `indexes.Skip(1)` 
- retrieves the webtestitem at location 2 of the root `GetChildItems(wtic[indexes.ElementAt(0)])` which happens to be `Loop Control 1`
- This time the count is still greater than 1 (there are 2 items in the list), so the method calls itself again, 
  - passing in {0} and getting the subitem at location 1 of `Loop Control 1`, which is `Transaction 1`. 
    - On this call, the index length is 1 because only the value 0 is left. So the item gets the sunItem at the index of 0 in the `Transaction 1` collection, which happens to be the request we want. 

While this may seem complex, by utilizing indexing to access the actual web test items, we achieve a much faster retrieval time for any type of search we want to perform.