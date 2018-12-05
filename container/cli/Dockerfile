FROM microsoft/dotnet:2.1-sdk AS buildcli
WORKDIR /src
COPY ["application/application.csproj", "application/"]
RUN dotnet restore "application/application.csproj"
COPY application application/
WORKDIR "/src/application"
RUN rm -rf bin && rm -rf obj