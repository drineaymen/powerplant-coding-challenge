#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8888
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["powerplant-coding-challenge/powerplant-coding-challenge.csproj", "powerplant-coding-challenge/"]
COPY ["powerplant-core/powerplant.core.csproj", "powerplant-core/"]
RUN dotnet restore "powerplant-coding-challenge/powerplant-coding-challenge.csproj"
COPY . .
WORKDIR "/src/powerplant-coding-challenge"
RUN dotnet build "powerplant-coding-challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "powerplant-coding-challenge.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "powerplant-coding-challenge.dll"]
