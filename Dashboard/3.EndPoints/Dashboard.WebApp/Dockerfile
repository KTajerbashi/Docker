# ==========================
# Build Stage
# ==========================
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy project files
COPY ["1.Core/Dashboard.Domain/Dashboard.Domain.csproj", "1.Core/Dashboard.Domain/"]
COPY ["1.Core/Dashboard.Application/Dashboard.Application.csproj", "1.Core/Dashboard.Application/"]
COPY ["2.Infra/Dashboard.Infrastructure/Dashboard.Infrastructure.csproj", "2.Infra/Dashboard.Infrastructure/"]
COPY ["3.EndPoints/Dashboard.WebApi/Dashboard.WebApi.csproj", "3.EndPoints/Dashboard.WebApi/"]
COPY ["3.EndPoints/Dashboard.WebApp/Dashboard.WebApp.csproj", "3.EndPoints/Dashboard.WebApp/"]

# Restore NuGet packages
RUN dotnet restore "3.EndPoints/Dashboard.WebApp/Dashboard.WebApp.csproj"

# Copy source code
COPY . .

WORKDIR "/src/3.EndPoints/Dashboard.WebApp"

# Publish
RUN dotnet publish "Dashboard.WebApp.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

# ==========================
# Runtime Stage
# ==========================
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "Dashboard.WebApp.dll"]