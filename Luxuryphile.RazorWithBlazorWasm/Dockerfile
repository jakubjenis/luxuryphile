FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Luxuryphile.RazorWithBlazorWasm/Luxuryphile.RazorWithBlazorWasm.csproj", "Luxuryphile.RazorWithBlazorWasm/"]
RUN dotnet restore "Luxuryphile.RazorWithBlazorWasm/Luxuryphile.RazorWithBlazorWasm.csproj"
COPY . .
WORKDIR "/src/Luxuryphile.RazorWithBlazorWasm"
RUN dotnet build "Luxuryphile.RazorWithBlazorWasm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Luxuryphile.RazorWithBlazorWasm.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Luxuryphile.RazorWithBlazorWasm.dll"]
