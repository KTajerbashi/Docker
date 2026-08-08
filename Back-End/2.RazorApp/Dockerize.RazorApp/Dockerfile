# مرحله ۱: ساخت (Build)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# کپی فایل پروژه - مسیرها را ساده می‌کنیم چون فایل .csproj در همین پوشه است
COPY ["Dockerize.RazorApp.csproj", "."]
RUN dotnet restore

# کپی بقیه کدها
COPY . .
RUN dotnet publish "Dockerize.RazorApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

# مرحله ۲: اجرا (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# استفاده از کاربر غیر ریشه برای امنیت بیشتر
USER app

# کپی خروجی publish شده
COPY --from=build /app/publish .

# پورت پیش‌فرض
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# نقطه ورود
ENTRYPOINT ["dotnet", "Dockerize.RazorApp.dll"]