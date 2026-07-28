# syntax=docker/dockerfile:1

# ---------- Stage 1: Restore & Build ----------
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# کپی csproj ها با حفظ ساختار پوشه‌ای دقیق، برای بهره‌گیری از layer caching
COPY ["Dashboard/3.EndPoints/Dashboard.WebApp/Dashboard.WebApp.csproj", "Dashboard/3.EndPoints/Dashboard.WebApp/"]
COPY ["Dashboard/3.EndPoints/Dashboard.WebApi/Dashboard.WebApi.csproj", "Dashboard/3.EndPoints/Dashboard.WebApi/"]
COPY ["Dashboard/1.Core/Dashboard.Application/Dashboard.Application.csproj", "Dashboard/1.Core/Dashboard.Application/"]
COPY ["Dashboard/1.Core/Dashboard.Domain/Dashboard.Domain.csproj", "Dashboard/1.Core/Dashboard.Domain/"]
COPY ["Dashboard/2.Infra/Dashboard.Infrastructure/Dashboard.Infrastructure.csproj", "Dashboard/2.Infra/Dashboard.Infrastructure/"]

# restore کردن WebApp به‌صورت خودکار WebApi و لایه‌های پایین‌تر رو هم resolve می‌کنه
RUN dotnet restore "Dashboard/3.EndPoints/Dashboard.WebApp/Dashboard.WebApp.csproj"

# کپی کل سورس
COPY . .

WORKDIR /src/Dashboard/3.EndPoints/Dashboard.WebApp
RUN dotnet build "Dashboard.WebApp.csproj" -c Release -o /app/build --no-restore

# ---------- Stage 2: Publish ----------
FROM build AS publish
RUN dotnet publish "Dashboard.WebApp.csproj" -c Release -o /app/publish \
    --no-restore /p:UseAppHost=false

# ---------- Stage 3: Runtime ----------
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Dashboard.WebApp.dll"]