FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Course.Files/Course.Files.csproj", "Course.Files/"]
COPY ["Course.Common/Course.Common.csproj", "Course.Common/"]
RUN dotnet restore "Course.Files/Course.Files.csproj"
COPY . .
WORKDIR "/src/Course.Files"
RUN dotnet build "Course.Files.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Course.Files.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Course.Files.dll"]
