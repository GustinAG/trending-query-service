# trending-query-service
Trending CQRS Sample - Query microservice

---
## Goal of This
Demontsrating these architecture paterns within working code in a very simplified way.
This might help better understand them.

On the other hand, with the help of this sample code, you will ***not*** see the complictions that come with a huge, complex project.

---
## What You Need for This
 + Visual Studio 2019 - *or higher* - ***Run as Administrator*** - incl.:
    + C# stuff
    + .NET Core 3.1
    + Markdown Editor
 + Docker Desktop with Linux containers
 + Also recommended:
    + ReSharper
    + TortoiseGit
    + Notepad++ including XML Tools

---
## How This Was Created
&rarr; [HowCreated.md](HowCreated.md)

## How To...
### Start
```Batchfile
docker ps
docker start mongodb
docker exec -it mongodb bash
```
<center> &darr; </center>

```Bash
mongo
```
<center> &darr; </center>

```SQL
show dbs
use articletrendings
db.trendings.find()
```

### Check the Operational DB
```SQL
use trendingevents
db.articleevents.find()
```

### Check the Reporting DB
```SQL
use articletrendings
db.getCollectionInfos({ }, true)
```

### Stop
```Batchfile
docker stop mongodb
```

---
## Docker Basics
In a command prompt run as administrator:
```Batchfile
docker images
docker ps -a
docker exec -it Trending.Query.Api bash
```
<center> &darr; </center>

```Bash
hostname -i
ls -ln
```

---
## Architecture Patterns <br /> <small> *covered in this sample* </small>
 + **C**ommand **Q**uery **R**esponsibility **S**egragation
 + **D**ata **A**ccess **L**ayer
 + **D**ata **T**ransfer **O**bject
 + **E**xtract **T**ransform **L**oad 
 + Reporting Database

### See Also
 + &rarr; [CQRS *(Fowler)*](https://martinfowler.com/bliki/CQRS.html)
 + &rarr; [Data access layer *(Wikipedia)*](https://en.wikipedia.org/wiki/Data_access_layer)
 + &rarr; [Better Extract/Transform/Load (ETL) Practices in Data Warehousing (Continued) *(Goff)*](https://www.codemag.com/Article/1803051/Better-Extract-Transform-Load-ETL-Practices-in-Data-Warehousing-Continued)
 + &rarr; [MongoDB ETL Best Practices](https://www.mongodb.com/partners/partner-program/technology/certification/etl-best-practices)
 + &rarr; [MongoSyphon](https://github.com/johnlpage/MongoSyphon) - might be a better choice intead of these C# .NET Core scheduled jobs
 + &rarr; [Ofelia - a job scheduler](https://github.com/mcuadros/ofelia) - might be the choice in a real world scenario
 + &rarr; [Reporting Database *(Fowler)*](https://martinfowler.com/bliki/ReportingDatabase.html)
