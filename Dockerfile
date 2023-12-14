FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["InterfacesLab/InterfacesLab.csproj", "InterfacesLab/"]
RUN dotnet restore "InterfacesLab/InterfacesLab.csproj"
COPY . .
WORKDIR "/src/InterfacesLab"
RUN dotnet build "InterfacesLab.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterfacesLab.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterfacesLab.dll"]
