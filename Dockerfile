#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . .

# Restore project
RUN dotnet restore "FeedMessages.API/FeedMessages.API.csproj"

# Build project
RUN dotnet build "FeedMessages.API/FeedMessages.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FeedMessages.API/FeedMessages.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeedMessages.API.dll"]