# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files first (for caching)
COPY Felicity.Api/Felicity.Api.csproj Felicity.Api/
COPY Felicity.Repository/Felicity.Repository.csproj Felicity.Repository/
COPY Felicity.Domain/Felicity.Domain.csproj Felicity.Domain/

# Restore dependencies
RUN dotnet restore Felicity.Api/Felicity.Api.csproj

# Copy the rest of the source code
COPY . .

# Publish application
RUN dotnet publish Felicity.Api/Felicity.Api.csproj -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Felicity.Api.dll"]