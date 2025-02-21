# Instrucciones de ejecución

Este proyecto tiene dos partes: el **Frontend** y el **Backend**. A continuación se describen los pasos para ejecutar cada parte del proyecto.

## Requisitos previos

- **Node.js**: Asegúrate de tener **Node.js** instalado en tu máquina para poder ejecutar el frontend.
- **.NET Core SDK**: Asegúrate de tener **.NET Core SDK** instalado en tu máquina para poder ejecutar el backend.

## Ejecución del Frontend

1. Reemplaza en el archivo /Front/ClientPruebaDevNet/src/environments/environment.ts la propiedad apiUrl con la url en la que se ejecute la api del backend.
2. Abre una terminal o consola de comandos.
3. Navega al directorio donde se encuentra el proyecto del frontend

   ```bash
   cd Front/ClientPruebaDevNet/
   npm install
   ng serve

## Ejecución del Backend

1. Cambia la cadena de conexión de la base de datos en el archivo /Api/appsettings.Development.json en la propiedad: DefaultConnection.
2. Abre una terminal o consola de comandos.
3. Navega al directorio donde se encuentra el proyecto del backend:

   ```bash
   cd Api/
   dotnet restore
   dotnet run
