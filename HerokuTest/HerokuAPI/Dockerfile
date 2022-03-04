FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HerokuAPI/HerokuAPI.csproj", "HerokuAPI/"]
RUN dotnet restore "HerokuAPI/HerokuAPI.csproj"
COPY . .
WORKDIR "/src/HerokuAPI"
RUN dotnet build "HerokuAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HerokuAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HerokuAPI.dll"]
