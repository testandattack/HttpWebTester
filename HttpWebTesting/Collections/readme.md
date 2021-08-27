# Collection Files
Collection Items contain various sets of other objects or properties needed by the web test. All collections are created by inheriting from an abstract class called `BaseCollection.cs` which adds the ability to use an `AddRange` method to populate the collections. The collection types include:

- WebTestItems, including:
   - Requests to execute
   - Flow control logic such as loops and conditional statements
   - Transactions (sets of related requests grouped together for easier management and timing information)
   - Other web tests (such as a login web test) that you may want to re-use.
- `ContextCollection` Context Parameters (key-value pairs) that hold extracted values, calculated values, or other dynamic values
- `DataSourceCollection` Data Sources hold the connection properties and usable fields for data that can be read by the test at execution time.
- `PropertyCollection` This is a more generic version of the ContextCollection, which gets used for any place in the test that requires the ability to store properties.
- `RuleCollection` Rules are used for validation or extraction. These collections can be defined at a Request level or at the top test level.
- `WebTestItemCollection` This collection holds all of the various <a href="../WebTestItems/readme.md">WebTestItem</a> objects that make up a webtest, or a nested set of WebTestItem objects.

NOTE: One of the biggest differences is that there is only a single ContextCollection that applies to the entire webtest (and can only be defined at the root), whereas `PropertyCollection` items can exist in multiple locations and can be cloned.