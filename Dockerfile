FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /api
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8081;http://+:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["NaoBinariosAPI/NaoBinariosAPI.csproj", "NaoBinariosAPI/"]
RUN dotnet restore "NaoBinariosAPI/NaoBinariosAPI.csproj"
COPY . .
WORKDIR "/src/NaoBinariosAPI"
RUN dotnet build "NaoBinariosAPI.csproj" -c $configuration -o /api/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "NaoBinariosAPI.csproj" -c $configuration -o /api/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /api
COPY --from=publish /api/publish .
ENTRYPOINT ["dotnet", "NaoBinariosAPI.dll"]
