FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["AgroSpace.Api.csproj", "./"]
RUN dotnet restore "AgroSpace.Api.csproj"

COPY . .
RUN dotnet publish "AgroSpace.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_HTTP_PORTS=8080

EXPOSE 8080

COPY --from=build /app/publish .

RUN useradd -m agro_user
USER agro_user

ENTRYPOINT ["dotnet", "AgroSpace.Api.dll"]