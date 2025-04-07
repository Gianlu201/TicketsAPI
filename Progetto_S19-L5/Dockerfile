# Fase di build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Imposta la cartella di lavoro
WORKDIR /app

# Copia il file .csproj e ripristina le dipendenze
COPY *.csproj ./
RUN dotnet restore

# Copia tutto il resto del progetto
COPY . ./

# Pubblica il progetto in modalità Release
RUN dotnet publish -c Release -o /app/publish

# Fase di runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Imposta la cartella di lavoro per l'immagine di runtime
WORKDIR /app

# Copia il contenuto compilato dalla fase di build
COPY --from=build /app/publish .

# Imposta l'URL di ascolto
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

# Comando per avviare l'applicazione
ENTRYPOINT ["dotnet", "MyApiProject.dll"]