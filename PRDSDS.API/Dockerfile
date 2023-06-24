FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PRDSDS.API/PRDSDS.API.csproj", "PRDSDS.API_build/PRDSDS.API_build.csproj"]
RUN dotnet restore "PRDSDS.API_build/PRDSDS.API_build.csproj"

WORKDIR "/src/PRDSDS.API_build"
COPY . .

RUN dotnet build "PRDSDS.API_build.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PRDSDS.API_build.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PRDSDS.API_build.dll"]
