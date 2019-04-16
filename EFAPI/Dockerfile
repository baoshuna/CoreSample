FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EFAPI/EFAPI.csproj", "EFAPI/"]
RUN dotnet restore "EFAPI/EFAPI.csproj"
COPY . .
WORKDIR "/src/EFAPI"
RUN dotnet build "EFAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EFAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EFAPI.dll"]