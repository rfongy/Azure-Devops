FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
RUN dotnet restore /app/ModernUIApp/ModernUIApp.csproj
RUN dotnet publish /app/ModernUIApp/ModernUIApp.csproj --output /out/ --configuration Release




FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /out .

ENV ApiURL http://modernapiapp/api/customers
ENV ASPNETCORE_ENVIRONMENT Development
EXPOSE 80

ENTRYPOINT ["dotnet", "ModernUIApp.dll"]