FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DockerSampe_1/DockerSampe_1.csproj", "DockerSampe_1/"]
RUN dotnet restore "DockerSampe_1/DockerSampe_1.csproj"
COPY . .
WORKDIR "/src/DockerSampe_1"
RUN dotnet build "DockerSampe_1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerSampe_1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerSampe_1.dll"]