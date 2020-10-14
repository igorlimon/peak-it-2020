FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Course.Identity/Course.Identity.csproj", "Course.Identity/"]
COPY ["Course.Common/Course.Common.csproj", "Course.Common/"]
RUN dotnet restore "Course.Identity/Course.Identity.csproj"
COPY . .
WORKDIR "/src/Course.Identity"
RUN dotnet build "Course.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Course.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Course.Identity.dll"]
