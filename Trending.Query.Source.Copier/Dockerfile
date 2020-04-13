#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Trending.Query.Source.Copier/Trending.Query.Source.Copier.csproj", "Trending.Query.Source.Copier/"]
RUN dotnet restore "Trending.Query.Source.Copier/Trending.Query.Source.Copier.csproj"
COPY . .
WORKDIR "/src/Trending.Query.Source.Copier"
RUN dotnet build "Trending.Query.Source.Copier.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trending.Query.Source.Copier.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trending.Query.Source.Copier.dll"]