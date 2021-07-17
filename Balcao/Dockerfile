FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["../Balcao/Balcao.csproj", "Balcao/"]
RUN dotnet restore "../Balcao/Balcao.csproj"
COPY . .
WORKDIR "/src/Balcao"
RUN dotnet build "Balcao.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Balcao.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Balcao.dll"]
