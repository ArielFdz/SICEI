FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything
COPY *.csproj ./
# Restore as distinct layers
RUN dotnet restore
COPY . ./
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SICEI.dll"]
