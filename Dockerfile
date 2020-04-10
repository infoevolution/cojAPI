FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 5110
EXPOSE 5111
ENV ASPNETCORE_URLS=http://+:5110

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["cojApi.csproj", "./"]
RUN dotnet restore "./cojApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "cojApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cojApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cojApi.dll"]
