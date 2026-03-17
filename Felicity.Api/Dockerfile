# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files first (for caching)
COPY Fer.Felicity.Api/Fer.Felicity.Api.csproj Fer.Felicity.Api/
COPY Fer.Felicity.Repository/Fer.Felicity.Repository.csproj Fer.Felicity.Repository/
COPY Fer.Felicity.Domain/Fer.Felicity.Domain.csproj Fer.Felicity.Domain/

# Restore dependencies
RUN dotnet restore Fer.Felicity.Api/Fer.Felicity.Api.csproj

# Copy the rest of the source code
COPY . .

# Publish application
RUN dotnet publish Fer.Felicity.Api/Fer.Felicity.Api.csproj -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Fer.Felicity.Api.dll"]