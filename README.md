# SpringFestivalService

## Getting Started
### Development
For active development stage:

Launch the db at local:
```
docker run -p 8000:8000 amazon/dynamodb-local:latest -jar DynamoDBLocal.jar -sharedDb
```

Then launch the app from IDE.


## Features
* [x] Create a show. 
  POST https://localhost:5001/Show
  
```json
{
"Id" : "103",
"Name": "hehehe"
}
```

* [x] Query all shows.
  GET https://localhost:5001/Show
  
* [x] Query a show by id.
  GET https://localhost:5001/Show/101

* [x] Vote for a show.
  POST https://localhost:5001/Vote
  
```json
{
    "id": "102"
}
```

## Tasks
* [x] setup db
* [x] CRUD from db
* [x] Vote for show

## Commands

### Dotnet
Create a project:
```
dotnet new webapi -o SpringFestivalService
```


Add dependencies:
```
dotnet add package AWSSDK.DynamoDBv2
dotnet add package Newtonsoft.Json
```

### Docker
Launch db:
* Launch Docker desktop on your pc
* Run db only:
```
docker run -p 8000:8000 amazon/dynamodb-local:latest 
```

Troubleshooting: if we launch db as above, AWS CLI can not list-tables, should use:
```
docker run -p 8000:8000 amazon/dynamodb-local:latest -jar DynamoDBLocal.jar -sharedDb
```
to launch db, then we can list tables in command line.

* Build app image:
```
docker build -t spring-festival-service .
```

* Run app from image:
```
docker run --rm -p 5001:80 --name myapp spring-festival-service
```

### Docker Compose: Run app with db
Ensure to build image with latest code change first:
```
docker build -t spring-festival-service .
```
Then run app with db dependency
```
docker-compose up
```

### AWS
```
aws configure
aws dynamodb list-tables --endpoint-url http://localhost:8000
```

## Note
If you run:
```
docker-compose up
```

The db ServiceUrl should be: `"ServiceUrl": "http://dynamodb-local:8000",`.

If you run the app from IDE:
The db ServiceUrl should be: `"ServiceUrl": "http://localhost:8000",`.


## Questions
* [] How to query all data?
* [] How to query by other conditions?
* [] How to query and sort the results? 
* [x] Do I need to create table at startup? how?
* [x] 加了注解的时候, 报错: System.InvalidOperationException: Must have one range key or a GSI index defined for the table Show 是什么意思?
* [] When run app using docker run and docker-compose: test with `http`; When run app with IDE, test with `https`, why? Both comment out `app.UseHttpsRedirection();`.
* [] If use `app.UseHttpsRedirection();` Both ways should test with `https`.