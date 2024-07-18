FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
COPY . ./

RUN dotnet restore
RUN dotnet build  -c Release -o /app/build
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /app/out .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "back.api.dll"]