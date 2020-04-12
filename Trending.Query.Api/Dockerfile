#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trending.Query.Api/Trending.Query.Api.csproj", "Trending.Query.Api/"]
RUN dotnet restore "Trending.Query.Api/Trending.Query.Api.csproj"
COPY . .
WORKDIR "/src/Trending.Query.Api"
RUN dotnet build "Trending.Query.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trending.Query.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trending.Query.Api.dll"]