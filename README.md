# What is this
me learning dotnot from https://www.youtube.com/watch?v=PmDJIooZjBE

# Lessons are in the pull requests tab
https://github.com/danielkwok21/learnDotNet6/pulls?q=is%3Apr

# Commonly used commands
```bash
# To reference api contract into project
dotnet add .\BuberBreakfast\ reference .\BuberBreakfast.Contracts\

# To start program
dotnet build # first time only
dotnet run --project BuberBreakfast # every subsequent attempt

# To start db (separete from dotnet, just using docker compose for convenience)
docker-compose -f ./docker-compose.yml up
# (go to docker desktop -> select container -> open in terminal -> mysql -u root -p -> 123456 -> observe success)

# Install nuget package
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 7.0.5
```