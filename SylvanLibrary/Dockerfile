FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SylvanLibrary/SylvanLibrary.csproj", "SylvanLibrary/"]
RUN dotnet restore "SylvanLibrary/SylvanLibrary.csproj"
COPY . .
WORKDIR "/src/SylvanLibrary"
RUN dotnet build "SylvanLibrary.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SylvanLibrary.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SylvanLibrary.dll"]
