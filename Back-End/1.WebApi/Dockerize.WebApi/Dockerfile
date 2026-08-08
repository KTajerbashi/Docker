# مرحله ۱: ساخت (Build)
# از تصویر SDK کامل برای کامپایل و انتشار استفاده می‌شود
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# کپی فایل‌های پروژه و بازگردانی وابستگی‌ها (برای استفاده از کش Docker)
# نام فایل پروژه WebApi خود را به‌روز کنید
COPY ["Dockerize.WebApi/Dockerize.WebApi.csproj", "YourWebApiProject/"]
RUN dotnet restore "Dockerize.WebApi/Dockerize.WebApi.csproj"

# کپی باقی کدها و انتشار برنامه
COPY . .
WORKDIR "/src/Dockerize.WebApi"
RUN dotnet publish "Dockerize.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# مرحله ۲: اجرا (Runtime)
# از تصویر سبک‌تر ASP.NET Runtime برای اجرا استفاده می‌شود
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# استفاده از کاربر غیر ریشه (Non-root user) برای امنیت بیشتر
USER app

# کپی خروجی publish شده از مرحله ساخت
COPY --from=build /app/publish .

# پورت پیش‌فرض برنامه را مشخص می‌کند
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# تعیین نقطه ورود برای اجرای برنامه
ENTRYPOINT ["dotnet", "Dockerize.WebApi.dll"]