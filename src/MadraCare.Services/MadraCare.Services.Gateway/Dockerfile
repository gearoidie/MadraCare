FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app


ENV PROJECT ./src/MadraCare.Services/MadraCare.Services.Gateway

# Copy csproj and restore as distinct layers
COPY ${PROJECT}/*.csproj ${PROJECT}/
COPY ./src/MadraCare.Clients/*.csproj ./src/MadraCare.Clients/
COPY ./src/MadraCare.Models/*.csproj ./src/MadraCare.Models/
RUN dotnet restore ${PROJECT}

# Copy everything else and build
COPY ${PROJECT}/ ${PROJECT}/
COPY ./src/MadraCare.Clients/ ./src/MadraCare.Clients/
COPY ./src/MadraCare.Models/ ./src/MadraCare.Models/
RUN dotnet publish ${PROJECT}/MadraCare.Services.Gateway.csproj -c Release -o out

# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
ENV PROJECT ./src/MadraCare.Services/MadraCare.Services.Gateway
WORKDIR /app
COPY --from=build-env /app/${PROJECT}/out .
ENTRYPOINT ["dotnet", "MadraCare.Services.Gateway.dll"]