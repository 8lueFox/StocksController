#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleFinance.StocksService.Application/SimpleFinance.StocksService.Application.csproj", "SimpleFinance.StocksService.Application/"]
COPY ["SimpleFinance.StocksService/SimpleFinance.StocksService.Api.csproj", "SimpleFinance.StocksService/"]

RUN dotnet restore "SimpleFinance.StocksService/SimpleFinance.StocksService.Api.csproj"
COPY . .
WORKDIR "/src/SimpleFinance.StocksService"
RUN dotnet build "SimpleFinance.StocksService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleFinance.StocksService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleFinance.StocksService.Api.dll"]