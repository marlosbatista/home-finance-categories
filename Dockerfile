FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["home-finance-categories.csproj", "./"]
RUN dotnet restore "home-finance-categories.csproj"
COPY . .
RUN dotnet publish "home-finance-categories.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "home-finance-categories.dll"]
