# Parsing Steps
- Open Swagger doc
- Build List of controllers
    - Walk every path object in openApiDoc (ApiSet.BuildControllerList)
        - Add each path to an existing or new controller (Controller.AddEndPoints)
    - Parse all path items and add the request body info
    - Parse all path items and add the response object info
- Build List of Components
- 
- Build Summary
