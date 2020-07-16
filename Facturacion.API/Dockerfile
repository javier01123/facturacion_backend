#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Facturacion.API/Facturacion.API.csproj", "Facturacion.API/"]
COPY ["Facturacion.Infrastructure/Facturacion.Infrastructure.csproj", "Facturacion.Infrastructure/"]
COPY ["Facturacion.Domain/Facturacion.Domain.csproj", "Facturacion.Domain/"]
COPY ["Facturacion.Application/Facturacion.Application.csproj", "Facturacion.Application/"]
RUN dotnet restore "Facturacion.API/Facturacion.API.csproj"
COPY . .
WORKDIR "/src/Facturacion.API"
RUN dotnet build "Facturacion.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Facturacion.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Facturacion.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Facturacion.API.dll