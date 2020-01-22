#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Store.StoreManagement.WebApi/Store.StoreManagement.WebApi.csproj", "Store.StoreManagement.WebApi/"]
RUN dotnet restore "Store.StoreManagement.WebApi/Store.StoreManagement.WebApi.csproj"
COPY . .
WORKDIR "/src/Store.StoreManagement.WebApi"
RUN dotnet build "Store.StoreManagement.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Store.StoreManagement.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Store.StoreManagement.WebApi.dll"]