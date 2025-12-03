# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src/Catalog

COPY src/Catalog/*.csproj .
RUN dotnet restore

COPY src/Catalog/. .
RUN dotnet publish -c Release -o /app --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:80
COPY --from=build /app ./

EXPOSE 80
ENTRYPOINT ["dotnet", "Catalog.dll"]
