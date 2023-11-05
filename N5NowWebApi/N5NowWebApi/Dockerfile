#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["N5NowWebApi/N5NowWebApi.csproj", "N5NowWebApi/"]
COPY ["DataAccessEF/DataAccessEF.csproj", "DataAccessEF/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "N5NowWebApi/N5NowWebApi.csproj"
COPY . .
WORKDIR "/src/N5NowWebApi"
RUN dotnet build "N5NowWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "N5NowWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "N5NowWebApi.dll"]