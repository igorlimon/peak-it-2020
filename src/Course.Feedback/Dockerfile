FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Course.Feedback/Course.Feedback.csproj", "Course.Feedback/"]
COPY ["Course.Common/Course.Common.csproj", "Course.Common/"]
RUN dotnet restore "Course.Feedback/Course.Feedback.csproj"
COPY . .
WORKDIR "/src/Course.Feedback"
RUN dotnet build "Course.Feedback.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Course.Feedback.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Course.Feedback.dll"]
