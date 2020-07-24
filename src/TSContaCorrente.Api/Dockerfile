#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/TSContaCorrente.Api/TSContaCorrente.Api.csproj", "src/TSContaCorrente.Api/"]
RUN dotnet restore "src/TSContaCorrente.Api/TSContaCorrente.Api.csproj"
COPY . .
WORKDIR "/src/src/TSContaCorrente.Api"
RUN dotnet build "TSContaCorrente.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TSContaCorrente.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSContaCorrente.Api.dll"]