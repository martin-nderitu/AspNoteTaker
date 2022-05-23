## Asp Note Taker

A simple note taker app created using asp.net core 6 and postgres
## [**Demo**](https://asp-note-taker.herokuapp.com/)

### To get started

1. Clone this repo and ``cd NoteTaker``
2. Run ``dotnet user-secrets init`` in a powershell command prompt inside the NoteTaker folder
2. Run ``dotnet user-secrets set `"ConnectionStrings:DATABASE_URL" : "postgres://postgres_user:postgres_password@localhost:5432/notes"`` in a powershell command prompt inside the NoteTaker folder (provide your own values for postgres_user and postgres_password)
3. Run `dotnet run` in a powershell command prompt inside the NoteTaker folder to start the app

