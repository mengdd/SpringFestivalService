# SpringFestivalService


## Tasks
* [] setup db
* [] CRUD from db

## Commands

Create a project:
```
dotnet new webapi -o SpringFestivalService
```


Add dependencies:
```
dotnet add package AWSSDK.DynamoDBv2
dotnet add package Newtonsoft.Json
```

Launch db:
* Launch Docker desktop on your pc.
* docker-compose up



## Questions
* How to query all data?
* Do I need to create table at startup? how?
* 加了注解的时候, 报错: System.InvalidOperationException: Must have one range key or a GSI index defined for the table Show 是什么意思?