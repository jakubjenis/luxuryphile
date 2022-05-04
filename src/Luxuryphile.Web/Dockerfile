FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Luxuryphile.Web/Luxuryphile.Web.csproj", "Luxuryphile.Web/"]
RUN dotnet restore "Luxuryphile.Web/Luxuryphile.Web.csproj"
COPY . .
WORKDIR "/src/Luxuryphile.Web"
RUN dotnet build "Luxuryphile.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luxuryphile.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Luxuryphile.Web.dll"]
