# trending-query-service  <img src="under-construction.png" alt="under-construction" width="100" align="right" />
Trending CQRS Sample - Query microservice

---
## Goal of This
Demontsrating these architecture paterns within working code in a very simplified way.
This might help better understand them.

On the other hand, with the help of this sample code, you will ***not*** see the complictions that come with a huge, complex project.

---
## What You Need for This
 + Visual Studio 2019 - *or higher* - incl.:
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

### See Also
 + &rarr; [CQRS *(Fowler)*](https://martinfowler.com/bliki/CQRS.html)
