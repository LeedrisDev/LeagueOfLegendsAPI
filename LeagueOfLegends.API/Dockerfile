FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LeagueOfLegends.API/LeagueOfLegends.API.csproj", "LeagueOfLegends.API/"]
COPY ["LeagueOfLegends.Scrapper/LeagueOfLegends.Scrapper.csproj", "LeagueOfLegends.Scrapper/"]
RUN dotnet restore "LeagueOfLegends.API/LeagueOfLegends.API.csproj"
COPY . .
WORKDIR "/src/LeagueOfLegends.API"
RUN dotnet build "LeagueOfLegends.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LeagueOfLegends.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LeagueOfLegends.API.dll"]
