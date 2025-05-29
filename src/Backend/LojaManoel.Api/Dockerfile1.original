# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Backend/LojaManoel.Api/LojaManoel.Api.csproj", "src/Backend/LojaManoel.Api/"]
COPY ["src/Backend/LojaManoel.Application/LojaManoel.Application.csproj", "src/Backend/LojaManoel.Application/"]
COPY ["src/Backend/LojaManoel.Communication/LojaManoel.Communication.csproj", "src/Backend/LojaManoel.Communication/"]
COPY ["src/Backend/LojaManoel.Domain/LojaManoel.Domain.csproj", "src/Backend/LojaManoel.Domain/"]
COPY ["src/Backend/LojaManoel.Infraestructure/LojaManoel.Infraestructure.csproj", "src/Backend/LojaManoel.Infraestructure/"]
RUN dotnet restore "./src/Backend/LojaManoel.Api/LojaManoel.Api.csproj"
COPY . .
WORKDIR "/src/src/Backend/LojaManoel.Api"
RUN dotnet build "./LojaManoel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LojaManoel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaManoel.Api.dll"]