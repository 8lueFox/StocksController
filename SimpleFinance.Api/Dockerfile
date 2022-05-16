FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleFinance.Api/SimpleFinance.Api.csproj", "SimpleFinance.Api/"]
COPY ["SimpleFinance.Infrastructure/SimpleFinance.Infrastructure.csproj", "SimpleFinance.Infrastructure/"]
COPY ["SimpleFinance.Shared.Abstractions/SimpleFinance.Shared.Abstractions.csproj", "SimpleFinance.Shared.Abstractions/"]
COPY ["SimpleFinance.Application/SimpleFinance.Application.csproj", "SimpleFinance.Application/"]
COPY ["SimpleFinance.Domain/SimpleFinance.Domain.csproj", "SimpleFinance.Domain/"]
COPY ["SimpleFinance.Shared/SimpleFinance.Shared.csproj", "SimpleFinance.Shared/"]
RUN dotnet restore "SimpleFinance.Api/SimpleFinance.Api.csproj"
COPY . .
WORKDIR "/src/SimpleFinance.Api"
RUN dotnet build "SimpleFinance.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleFinance.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleFinance.Api.dll"]
