# Web Test Execution Engine
The WebTestExecutionEngine provides all of the functionality needed to execute an [HttpWebTest](../HttpWebTesting/readme.md) and collect the results. 
## Execution Steps
The following describes the steps that the execution engine takes for a single web test:
- The webtest is loaded into memory.
- All data sources are loaded into memory.
- The first row of data for each data source is loaded and bound to the ContextCollection.
- The engine parses the [WebTestItemCollection](../HttpWebTesting/WebTestItems/readme.md) and starts executing the items in a recursive method called `WebTestItemExecution`, using the various item executions:
    - **Comments** are either ignored or added to the results collection (depending on the webtest property `SuppressAllCommentsInResults`).
    - **Requests** are handled as follows:
        - if the property `Enabled` is false, the request is ignored.
        - The `HttpRequestMessage` of the request is processed by the ContextBinding engine. This step locates all defined context parameters in the request and substitutes the actual values to use from the `ContextCollection`.
        - Any `PreRequestRule` objects on the request are fired.
        - The request is executed and the `HttpResponseMessage` is inspected. (**NOTE:** *If the response is null, request execution will stop. If the webtest property `Stop On Error` is true, the execution engine will exit the `WebTestItemExecution` loop and complete the steps to save the test results.*)
        - PostRequest steps are executed in the following order:
          - A request rtesults (`WTRI_Request`) item is created. A copy of the `ContextCollection` and the `HttpResponseMessage` are both stored in the results item.
          - Validation Rules are fired
          - Extraction Rules are fired
          - PostRequestRules are fired
          - The `WTRI_Request` is added to the webtest results collection
          - control is handed back to `WebTestItemExecution` loop.
    - **Transactions** are handled as follows:
      - A transaction results (`WTRI_Transaction`) object is created.
      - That object and the `WebTestItemCollection` are passed int the `WebTestItemExecution` method and process continues.
      - When all of the transaction's items are complete, the `WTRI_Transaction` object is updated with the transactional timing and summary info.
      - The `WTRI_Transaction` is added to the webtest results collection
      - control is handed back to `WebTestItemExecution` loop.

