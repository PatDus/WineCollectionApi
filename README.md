# WineCollectionApi

Simple Web Api application for wines collection management. The project at first phase (finished) was mostly focused on practicing: .Net Core WebApi, Entity Framework and database modeling. There are no design patterns and no clean code principles yet. Application is deployed on Azure. 

Next phase of working with the project will be consisted of code refactor, to get rid off repetition in code (follow SOLID, desingn/architectural pattern and clean code). At the same time, I am going to create front-end using React or Angular - need to consider. 

## Core Technologies

* Platform: .NET 6
* Web Framework: ASP.NET Web API 
* ORM Framework: Entity Framework
* Database: Microsoft SQL Server 
* Programming Language: C#

## How to start

 1. First step to start is create user or use test user (**mail:** test@mail.com, **password:** test).
 2. Login with email and password. In response, you will get JWT token  which need to be  			included in header (Authorization: bearer ...) You can pass it via swagger - padlock icon.
 3. Before add wine, you have to create cellar (collection). 
 4. Play with endpoints


You can test api here: [WineCollectionApi](https://wine-collection.azurewebsites.net/swagger/index.html)
	 


## To do:
- A bit of work on DTO's 
- Implement ASYNC/AWAIT mechanism 
- Add model validation and figure out why FluentValidation is not working !!!
- Similar classes replace with generic classes 
- Work on code redundancy in services 
- PUT methods not working at all !!!
- Add pagination mechanism
- Add images mechanism
- Much more, but don't remember right now..

