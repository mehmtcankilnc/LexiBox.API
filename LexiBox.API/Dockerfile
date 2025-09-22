# -------- Base (runtime) --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Cloud Run yalnýzca 8080'i dinler
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
# Reverse proxy (Cloud Run) için forwarded headers'ý otomatik aç
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

EXPOSE 8080

# -------- Build --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LexiBox.API/LexiBox.API.csproj", "LexiBox.API/"]
RUN dotnet restore "LexiBox.API/LexiBox.API.csproj"
COPY . .
WORKDIR "/src/LexiBox.API"
RUN dotnet build "LexiBox.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# -------- Publish --------
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LexiBox.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# -------- Final --------
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LexiBox.API.dll"]
