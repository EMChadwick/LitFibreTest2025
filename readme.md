You can find a simple OpenAPI specification in openapi.json and openapi.yaml (specs are identical, both formats have been provided for your convenience.)

## What the API is:
    This is a simplified representation of the kind of API you see all across the fibre industry (and telecomms in general), where retailers need to be able to manage appointments with their providers. 
    
    This API implements CRUD operations for the appointments that would be stored in a provider's scheduling database, as well as an endpoint to retrieve future dates & times that are available to be booked. For this endpoint we recommend just generating a couple of 4-hour slots per weekday, from tomorrow until 30 days in the future.
    
    Many times we'll have different appointment types: commonly we just want to book a customer in to get their fibre connection installed. However, we also need to be able to book in maintenance if a connection breaks, or a survey if the provider isn't sure if the property is fully ready to connect. As these require differently trained resources, it's important that the API validates these types when a client submits create and update requests.
    
    ## What we want from you:
    Create a mock ASP.NET API in .NET 8 that implements this Swagger schema. At a minimum, your API should validate that requests match the correct schemas, and it should respond with objects that match the corresponding response schemas.
    
    The data can be pure mock data, i.e. hard-coded, but you'll get bonus points for implementing a simple in-memory database. We don't recommend integrating a real database for the sake of the test, but hey, we're not going to tell you how to live your life if that's what you want to do.
    
    Things we'd like to see you use in your implementation:
    - Object Oriented Programming techniques.    
    - One or more examples of dependency injection.
    
    Some ideas if you want to go above and beyond:
    - API authentication.
    - An example of unit testing.
    
    Tools you'll need:
    - Visual Studio with .NET 8 tools installed.
    - [Swagger Editor](https://editor.swagger.io/).
    - A brain, or your preferred search engine.
    
    Tools we don't want you to use:
    - AI codegen. Using LLMs in the course of doing research is OK, e.g. Gemini results when using Google or for rubber ducking, but the code you submit to us should be 100% yours.
    - Swagger/OpenAPI generators. Yes, if you upload the schema to some tools they'll generate the C# controllers and models for you, which is great for productivity, not so great for showing us your problem solving skills.