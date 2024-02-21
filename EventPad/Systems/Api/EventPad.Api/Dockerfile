#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Api/EventPad.Api/EventPad.Api.csproj", "Systems/Api/EventPad.Api/"]
COPY ["Data/EventPad.Context.Migrations/EventPad.Context.Migrations.MSSQL/EventPad.Context.Migrations.MSSQL.csproj", "Data/EventPad.Context.Migrations/EventPad.Context.Migrations.MSSQL/"]
COPY ["Data/EventPad.Context/EventPad.Context.csproj", "Data/EventPad.Context/"]
COPY ["Services/EventPad.Services.Settings/EventPad.Services.Settings.csproj", "Services/EventPad.Services.Settings/"]
COPY ["Shared/EventPad.Common/EventPad.Common.csproj", "Shared/EventPad.Common/"]
COPY ["Data/EventPad.Context.Entities/EventPad.Context.Entities.csproj", "Data/EventPad.Context.Entities/"]
COPY ["Data/EventPad.Context.Migrations/EventPad.Context.Migrations.PgSQL/EventPad.Context.Migrations.PgSql.csproj", "Data/EventPad.Context.Migrations/EventPad.Context.Migrations.PgSQL/"]
COPY ["Data/EventPad.Context.Seeder/EventPad.Context.Seeder.csproj", "Data/EventPad.Context.Seeder/"]
COPY ["Services/EventPad.Services.Events/EventPad.Services.Events.csproj", "Services/EventPad.Services.Events/"]
COPY ["Services/EventPad.Services.Logger/EventPad.Services.Logger.csproj", "Services/EventPad.Services.Logger/"]
RUN dotnet restore "./Systems/Api/EventPad.Api/./EventPad.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/EventPad.Api"
RUN dotnet build "./EventPad.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EventPad.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventPad.Api.dll"]