FROM microsoft/dotnet:2.1-sdk-alpine AS build
WORKDIR /app/websiteGateway

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/websiteGateway
RUN dotnet build
 
FROM build AS publish
WORKDIR /app/websiteGateway
# add IL Linker package
RUN dotnet publish -c Release -o out -r linux-musl-x64

FROM microsoft/dotnet:2.1-runtime-alpine AS runtime
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
WORKDIR /app
COPY --from=publish /app/websiteGateway/out ./
ENTRYPOINT ["dotnet", "MadraCare.Services.Website.Gateway.dll"]