FROM microsoft/dotnet:2.1.402-sdk-alpine AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app
RUN dotnet build
 
FROM build AS publish
WORKDIR /app
# add IL Linker package
RUN dotnet publish -c Release -o out -r linux-musl-x64

FROM microsoft/dotnet:2.1.4-runtime-alpine AS runtime
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
WORKDIR /app
COPY --from=publish /app/out ./
ENTRYPOINT ["dotnet", "MadraCare.Services.Kennel.dll"]