FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

COPY ["ECom.API/ECom.API.csproj", "ECom.API/"]
COPY ["ECom.Application/ECom.Application.csproj", "ECom.Application/"]
COPY ["ECom.Infrastructure/ECom.Infrastructure.csproj", "ECom.Infrastructure/"]
COPY ["ECom.Domain/ECom.Domain.csproj", "ECom.Domain/"]

RUN dotnet restore "ECom.API/ECom.API.csproj"

COPY . .

WORKDIR "/src/ECom.API"
RUN dotnet build "ECom.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECom.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECom.API.dll"]