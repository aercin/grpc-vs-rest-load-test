#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EntryPointWebApi/EntryPointWebApi.csproj", "EntryPointWebApi/"]
RUN dotnet restore "EntryPointWebApi/EntryPointWebApi.csproj"
COPY . .
WORKDIR "/src/EntryPointWebApi"
RUN dotnet build "EntryPointWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntryPointWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntryPointWebApi.dll"]