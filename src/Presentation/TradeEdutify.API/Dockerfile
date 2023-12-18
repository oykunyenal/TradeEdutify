FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5044

ENV ASPNETCORE_URLS=http://+:5044

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Presentation/TradeEdutify.API/TradeEdutify.API.csproj", "src/Presentation/TradeEdutify.API/"]
RUN dotnet restore "src/Presentation/TradeEdutify.API/TradeEdutify.API.csproj"

COPY ["src/Infrastructure/TradeEdutify.Persistence/TradeEdutify.Persistence.csproj", "src/Infrastructure/TradeEdutify.Persistence/"]
RUN dotnet restore "src/Infrastructure/TradeEdutify.Persistence/TradeEdutify.Persistence.csproj"

COPY ["src/Core/TradeEdutify.Application/TradeEdutify.Application.csproj", "src/Core/TradeEdutify.Application/"]
RUN dotnet restore "src/Core/TradeEdutify.Application/TradeEdutify.Application.csproj"

COPY ["src/Core/TradeEdutify.Domain/TradeEdutify.Domain.csproj", "src/Core/TradeEdutify.Domain/"]
RUN dotnet restore "src/Core/TradeEdutify.Domain/TradeEdutify.Domain.csproj"
COPY . .
WORKDIR "/src/src/Presentation/TradeEdutify.API"
RUN dotnet build "TradeEdutify.API.csproj" -c $configuration -o /app/build

ENV ASPNETCORE_ENVIRONMENT=Development

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "TradeEdutify.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradeEdutify.API.dll"]
