FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Blogger.API/Blogger.API.csproj", "Blogger.API/"]
RUN dotnet restore "Blogger.API/Blogger.API.csproj"
COPY . .
WORKDIR "/src/Blogger.API"
RUN dotnet build "Blogger.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blogger.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blogger.API.dll"]
