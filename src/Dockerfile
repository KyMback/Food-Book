FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# restore packages
COPY ./web/server/*.sln .
COPY ./web/server/NuGet.Config .
COPY ./web/server/FoodBook/Api/WebApi/*.csproj ./FoodBook/Api/WebApi/
COPY ./web/server/FoodBook/Application/Application.Common/*.csproj ./FoodBook/Application/Application.Common/
COPY ./web/server/FoodBook/Application/Application.GraphQL/*.csproj ./FoodBook/Application/Application.GraphQL/
COPY ./web/server/FoodBook/Domain/Domain/*.csproj ./FoodBook/Domain/Domain/
COPY ./web/server/FoodBook/Domain/Domain.Entities/*.csproj ./FoodBook/Domain/Domain.Entities/
COPY ./web/server/FoodBook/Infrastructure/Infrastructure.Common/*.csproj ./FoodBook/Infrastructure/Infrastructure.Common/
COPY ./web/server/FoodBook/Infrastructure/Infrastructure.DataAccess/*.csproj ./FoodBook/Infrastructure/Infrastructure.DataAccess/
COPY ./web/server/FoodBook/Infrastructure/Infrastructure.EFConfigs/*.csproj ./FoodBook/Infrastructure/Infrastructure.EFConfigs/
COPY ./web/server/FoodBook/Infrastructure/Infrastructure.Services/*.csproj ./FoodBook/Infrastructure/Infrastructure.Services/
COPY ./web/server/FoodBook/Database/Database.Migrations/*.csproj ./FoodBook/Database/Database.Migrations/

RUN dotnet restore

COPY ./web/server/FoodBook/ ./FoodBook/

RUN dotnet publish "./FoodBook/Database/Database.Migrations" --configuration Release --verbosity minimal --output "./../../../publish"
RUN dotnet publish "./FoodBook/Api/WebApi" --configuration Release --verbosity minimal --output "./../../../publish"

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app/publish

COPY --from=build /app/publish ./

CMD dotnet FoodBook.Database.Migrations.dll update && ASPNETCORE_URLS=http://*:$PORT dotnet FoodBook.WebApi.dll