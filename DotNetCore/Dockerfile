FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DotNetCore/DotNetCore.csproj", "DotNetCore/"]
RUN dotnet restore "DotNetCore\DotNetCore.csproj"
COPY . .
WORKDIR "/src/DotNetCore"
RUN dotnet build "DotNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetCore.dll"]
