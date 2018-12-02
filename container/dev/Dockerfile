FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["application/application.csproj", "application/"]
RUN dotnet restore "application/application.csproj"
COPY application application/
WORKDIR "/src/application"
RUN dotnet build "application.csproj" -c Debug -o /app

FROM build AS publish
RUN dotnet publish "application.csproj" -c Debug -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "application.dll"]