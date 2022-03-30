#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:latest
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IkeMtz.AdventureWorks.OData/IkeMtz.AdventureWorks.OData.csproj", "IkeMtz.AdventureWorks.OData/"]
COPY ["IkeMtz.AdventureWorks.Models/IkeMtz.AdventureWorks.Models.csproj", "IkeMtz.AdventureWorks.Models/"]
RUN dotnet restore "IkeMtz.AdventureWorks.OData/IkeMtz.AdventureWorks.OData.csproj"
COPY . .
WORKDIR "/src/IkeMtz.AdventureWorks.OData"
RUN dotnet build "IkeMtz.AdventureWorks.OData.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IkeMtz.AdventureWorks.OData.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IkeMtz.AdventureWorks.OData.dll"]