# -------- Runtime (ASP.NET 8) --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
EXPOSE 8080

# -------- Build --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# VS build context'i KÖK klasör (.) olduðu için yollarý kökten veriyoruz
COPY ["LexiBox.API/LexiBox.API.csproj", "LexiBox.API/"]
RUN dotnet restore "LexiBox.API/LexiBox.API.csproj"

# Proje kaynaklarýný kopyala (sadece projeyi)
COPY LexiBox.API/. ./LexiBox.API/

WORKDIR /src/LexiBox.API
RUN dotnet publish "LexiBox.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# -------- Final --------
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LexiBox.API.dll"]
