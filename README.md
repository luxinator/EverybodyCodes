# FIO
For Infi Only ;)

## CLI
For help, just run the application/project with the `-h` switch. Otherwise it will dump the entire file to stdout.
Passing arguments to the application becomes much easier if you publish the project and run the published version. 
## Api
Update the database before running the API. Do so by running:
```bash
dotnet ef database update
```
This will create a sqlite database. To populate the database run the `DatabaseLoader` program.
To run do a:
```bash
dotnet run
```
In the Api folder.

## DatabaseLoader
I could not help myself and transformed the csv file to a sqlite database. I had fun writing a little parser.
So the program has the following options:
```bash
  -d, --dbPath     Required. Path to sqlite db

  -c, --csvPath    Required. Path to csv

  --help           Display this help screen.

  --version        Display version information.

```
The paths can be relative.
Generate an empty db by doing an `dotnet ef database update` in the API folder (see above).
Passing arguments to the application becomes much easier if you publish the project and run the published version.

## WebApp
Simply run `dotnet run` in the `WebApp` folder.