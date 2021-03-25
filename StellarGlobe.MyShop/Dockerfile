#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["StellarGlobe.MyShop/StellarGlobe.MyShop.csproj", "StellarGlobe.MyShop/"]
RUN dotnet restore "StellarGlobe.MyShop/StellarGlobe.MyShop.csproj"
COPY . .
WORKDIR "/src/StellarGlobe.MyShop"
RUN dotnet build "StellarGlobe.MyShop.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StellarGlobe.MyShop.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StellarGlobe.MyShop.dll"]