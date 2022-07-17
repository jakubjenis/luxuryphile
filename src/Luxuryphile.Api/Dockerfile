FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Luxuryphile.Api/Luxuryphile.Api.csproj", "Luxuryphile.Api/"]
RUN dotnet restore "Luxuryphile.Api/Luxuryphile.Api.csproj"
COPY . .
WORKDIR "/src/Luxuryphile.Api"
RUN dotnet build "Luxuryphile.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luxuryphile.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Luxuryphile.Api.dll"]
