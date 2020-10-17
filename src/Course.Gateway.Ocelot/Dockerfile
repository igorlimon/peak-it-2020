#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Course.Gateway.Ocelot/Course.Gateway.Ocelot.csproj", "Course.Gateway.Ocelot/"]
RUN dotnet restore "Course.Gateway.Ocelot/Course.Gateway.Ocelot.csproj"
COPY . .
WORKDIR "/src/Course.Gateway.Ocelot"
RUN dotnet build "Course.Gateway.Ocelot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Course.Gateway.Ocelot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ["apt-get" "--assume-yes install iputils-ping"]
ENTRYPOINT ["dotnet", "Course.Gateway.Ocelot.dll"]