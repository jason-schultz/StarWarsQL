FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DotNetApi/DotNetApi.csproj", "DotNetApi/"]
RUN dotnet restore "DotNetApi\DotNetApi.csproj"
COPY . .
WORKDIR "/src/DotNetApi"
RUN dotnet build "DotNetApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetApi.dll"]
