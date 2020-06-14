#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Microservices/Order/Kanbersky.Order.Api/Kanbersky.Order.Api.csproj", "Microservices/Order/Kanbersky.Order.Api/"]
COPY ["Microservices/Order/Kanbersky.Order.Api/Kanbersky.Order.Business.csproj", "Microservices/Order/Kanbersky.Order.Business/"]
COPY ["Microservices/Order/Kanbersky.Order.Api/Kanbersky.Order.DAL.csproj", "Microservices/Order/Kanbersky.Order.DAL/"]
COPY ["Microservices/Order/Kanbersky.Order.Api/Kanbersky.Order.Entities.csproj", "Microservices/Order/Kanbersky.Order.Entities/"]
RUN dotnet restore "Microservices/Order/Kanbersky.Order.Api/Kanbersky.Order.Api.csproj"
COPY . .
WORKDIR "/src/Microservices/Order/Kanbersky.Order.Api"
RUN dotnet build "Kanbersky.Order.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanbersky.Order.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanbersky.Order.Api.dll"]