# sports website

this is three parts

- admin dashboard
- web Api
- front end (html , js)

# Features

- admin : All crud operation on Tournaments and teams
- web APi : send Data to front end
- front end : desplay the data

# How is it works

- step one : open appsetting.json in admin then modfiy Data Source in connection string
  (repeat this step for Api project)

- migration step : from tool > NuGet > package manager console (write migration commands)
  add-migration init
  update-database

- Run admin dashboard : right click on admin project set start project then run it
  (make sure host = 44347)

- add some data from dashboard

- Run API : open cmd in the Directory of API project and write : dotnet run
  (make sure host = 5001)

- open index.html in the front end Directory
