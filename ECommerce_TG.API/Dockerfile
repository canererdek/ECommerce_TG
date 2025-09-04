# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ECommerce_TG.API/ECommerce_TG.API.csproj", "ECommerce_TG.API/"]
COPY ["ECommerce_TG.Application/ECommerce_TG.Application.csproj", "ECommerce_TG.Application/"]
COPY ["Ecommerce_TG.Domain/Ecommerce_TG.Domain.csproj", "Ecommerce_TG.Domain/"]
COPY ["Ecommerce_TG.SharedKernel/Ecommerce_TG.SharedKernel.csproj", "Ecommerce_TG.SharedKernel/"]
COPY ["ECommerce_TG.Infrastructure/ECommerce_TG.Infrastructure.csproj", "ECommerce_TG.Infrastructure/"]
RUN dotnet restore "./ECommerce_TG.API/ECommerce_TG.API.csproj"
COPY . .
WORKDIR "/src/ECommerce_TG.API"
RUN dotnet build "./ECommerce_TG.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerce_TG.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce_TG.API.dll"]