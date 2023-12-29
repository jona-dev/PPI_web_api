#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PPI_web_Api/PPI_web_Api.csproj", "PPI_web_Api/"]
COPY ["DB/DB.csproj", "DB/"]
RUN dotnet restore "PPI_web_Api/PPI_web_Api.csproj"
COPY . .
WORKDIR "/src/PPI_web_Api"
RUN dotnet build "PPI_web_Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PPI_web_Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PPI_web_Api.dll"]