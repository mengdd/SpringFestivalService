# SpringFestivalService


## Tasks
* [] setup db
* [] CRUD from db

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

## Questions
* [] How to query all data?
* [x] Do I need to create table at startup? how?
* [x] 加了注解的时候, 报错: System.InvalidOperationException: Must have one range key or a GSI index defined for the table Show 是什么意思?
* [] When run app using docker run and docker-compose: test with `http`; When run app with IDE, test with `https`, why? Both comment out `app.UseHttpsRedirection();`.
* [] If use `app.UseHttpsRedirection();` Both ways should test with `https`.