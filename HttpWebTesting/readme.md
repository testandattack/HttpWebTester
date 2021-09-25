# WebTestItem Files
A web test is an object that contains a series of child objects designed to represent:
- Requests to execute
- Flow control logic such as loops and conditional statements
- Transactions (sets of related requests grouped together for easier management and timing information)
- Other web tests (such as a login web test) that you may want to re-use.

Because of the need to allow complex user flows to be represented in these tests, the framework is built with a base abstract class called `WebTestItem`. This allows the framework to easily nest any of the four items listed above in any order needed to meet the requirements of the user flow. Every item created will have an ItemType associated with it as well as a couple of other shared fields. Then the final implementation of each item type will expose what other items can appear as children. The defined items types are:
```csharp
    public enum WebTestItemType
    {
        Wti_IncludedWebTestItem = 1,
        Wti_RequestObject = 2,
        Wti_Transactiontimer = 3,
        Wti_LoopControl = 4,
        Wti_Comment = 5
    };
```
When you look at the individual objects, you will see that some objects (the `Wti_IncludedWebTestItem`, `Wti_Transactiontimer`, and `Wti_LoopControl`) allow any object (or collection of objects) to be a child, but others (`Wti_RequestObject` and `Wti_Comment`) do not. It doesn't make sense to have a request or a comment be a parent item.