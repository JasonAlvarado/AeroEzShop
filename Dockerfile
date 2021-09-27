#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet AeroEzShop.dll

#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["AeroEzShop.Api/AeroEzShop.Api.csproj", "AeroEzShop.Api/"]
#RUN dotnet restore "AeroEzShop.Api/AeroEzShop.Api.csproj"
#COPY . .
#WORKDIR "/src/AeroEzShop.Api"
#RUN dotnet build "AeroEzShop.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "AeroEzShop.Api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "AeroEzShop.Api.dll"]