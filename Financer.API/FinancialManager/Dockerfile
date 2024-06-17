# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Financer.API/FinancialManager/FinancialManager.Api.csproj", "FinancialManager/"]
COPY ["Financer.API/FinancialManager.IoC/FinancialManager.IoC.csproj", "FinancialManager.IoC/"]
COPY ["Financer.API/FinancialManager.Application/FinancialManager.Application.csproj", "FinancialManager.Application/"]
COPY ["Financer.API/FinancialManager.Domain/FinancialManager.Domain.csproj", "FinancialManager.Domain/"]
COPY ["Financer.API/FinancialManager.InfraStructure/FinancialManager.InfraStructure.csproj", "FinancialManager.InfraStructure/"]
RUN dotnet restore "./FinancialManager/FinancialManager.Api.csproj"
COPY . .
WORKDIR "/src/FinancialManager"
RUN dotnet build "FinancialManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FinancialManager.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinancialManager.Api.dll"]
