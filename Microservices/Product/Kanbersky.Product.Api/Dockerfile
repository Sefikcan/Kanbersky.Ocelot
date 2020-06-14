#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservices/Product/Kanbersky.Product.Api/Kanbersky.Product.Api.csproj", "Microservices/Product/Kanbersky.Product.Api/"]
COPY ["Microservices/Product/Kanbersky.Product.Api/Kanbersky.Product.Business.csproj", "Microservices/Product/Kanbersky.Product.Business/"]
COPY ["Microservices/Product/Kanbersky.Product.Api/Kanbersky.Product.DAL.csproj", "Microservices/Product/Kanbersky.Product.DAL/"]
COPY ["Microservices/Product/Kanbersky.Product.Api/Kanbersky.Product.Entities.csproj", "Microservices/Product/Kanbersky.Product.Entities/"]
RUN dotnet restore "Microservices/Product/Kanbersky.Product.Api/Kanbersky.Product.Api.csproj"
COPY . .
WORKDIR "/src/Microservices/Product/Kanbersky.Product.Api"
RUN dotnet build "Kanbersky.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanbersky.Product.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanbersky.Product.Api.dll"]