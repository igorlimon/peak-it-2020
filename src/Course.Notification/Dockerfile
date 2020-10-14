FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Course.Notification/Course.Notification.csproj", "Course.Notification/"]
COPY ["Course.Common/Course.Common.csproj", "Course.Common/"]
RUN dotnet restore "Course.Notification/Course.Notification.csproj"
COPY . .
WORKDIR "/src/Course.Notification"
RUN dotnet build "Course.Notification.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Course.Notification.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Course.Notification.dll"]
