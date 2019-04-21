FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["BWS.Profolio/BWS.Profolio.csproj", "BWS.Profolio/"]
RUN dotnet restore "BWS.Profolio/BWS.Profolio.csproj"
COPY . .
WORKDIR "/src/BWS.Profolio"
RUN dotnet build "BWS.Profolio.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BWS.Profolio.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BWS.Profolio.dll"]
