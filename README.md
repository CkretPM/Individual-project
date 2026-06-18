Multiplayer board game as desktop application in C# using .NET framework and Windows Forms libraries in Visual Studio environment and PL/pgSQL in a PostgreSQL database in a Docker container.
Winforms net8.0. 

# HOW TO RUN:
## Mandatory (in terminal):
```
docker run --name game-db -e POSTGRES_USER=gameuser -e POSTGRES_PASSWORD=gamepass -e POSTGRES_DB=gamedb -p 5432:5432 -d postgres:latest
```

Go to folder where you stored schema.sql with command 'cd'
```
docker cp schema.sql game-db:/schema.sql

docker exec -it game-db psql -U gameuser -d gamedb -f /schema.sql
```

### Optional: (to check inside DB)
```
docker exec -it game-db psql -U gameuser -d gamedb
```

There PostgreSQL commands can be used like:
```
SELECT * FROM players;
SELECT * FROM game_sessions;
SELECT * FROM turns;
```
