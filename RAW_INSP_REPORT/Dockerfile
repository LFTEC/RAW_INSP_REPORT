# 请参阅 https://aka.ms/customizecontainer 以了解如何自定义调试容器，以及 Visual Studio 如何使用此 Dockerfile 生成映像以更快地进行调试。

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER root
RUN apt-get update
RUN apt-get install -y libc6 libicu-dev libfontconfig1 \
    fontconfig \
    && rm -rf /var/lib/apt/lists/*
COPY ["NDS_REPORT/fonts/*", "/usr/local/share/fonts/"]
RUN fc-cache -vf

FROM base AS base2
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# 此阶段用于生成服务项目
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
ARG DEVEXPRESS_LICENSE
ENV DevExpress_License=$DEVEXPRESS_LICENSE
WORKDIR /src
COPY ["NDS_REPORT/NDS_REPORT.csproj", "NDS_REPORT/"]
RUN dotnet restore "./NDS_REPORT/NDS_REPORT.csproj"
COPY . .
WORKDIR "/src/NDS_REPORT"
RUN dotnet build "./NDS_REPORT.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 此阶段用于发布要复制到最终阶段的服务项目
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
ARG DEVEXPRESS_LICENSE
ENV DevExpress_License=$DEVEXPRESS_LICENSE
RUN dotnet publish "./NDS_REPORT.csproj" -c $BUILD_CONFIGURATION -r linux-x64 -o /app/publish /p:UseAppHost=false

# 此阶段在生产中使用，或在常规模式下从 VS 运行时使用(在不使用调试配置时为默认值)
FROM base2 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NDS_REPORT.dll"]