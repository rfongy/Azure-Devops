FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore ModernApiApp/ModernApiApp.csproj
RUN dotnet publish ModernApiApp/ModernApiApp.csproj --output /out/ --configuration Release




FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /out .

ENV ApiAppDatabaseServer modernapiapp.database
ENV ApiAppDatabaseName ModernApiDB
ENV ApiAppDatabaseUser sa
ENV ApiAppDatabasePassword Microsoft!1
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 80

ENTRYPOINT ["dotnet", "ModernApiApp.dll"]