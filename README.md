# Backend

Este proyecto es un ejemplo de una aplicación .NET que utiliza una base de datos SQL Server y proporciona una API.

## Requisitos previos

- [.NET Core SDK](https://dotnet.microsoft.com/download) instalado en tu máquina.
- Un servidor de base de datos SQL Server disponible.

## Pasos para ejecutar el proyecto

1. **Clonar el repositorio desde GitHub:**
git clone https://github.com/pintosoUCN/

2. **Crear las tablas en SQL Server.** Utilizar el siguiente código SQL:

-- Crear la tabla de usuarios
CREATE TABLE Usuarios (
    UsuarioID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50)
);

-- Crear la tabla de aplicaciones
CREATE TABLE Aplicaciones (
    AplicacionID INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50)
);

-- Crear la tabla de reservas
CREATE TABLE Reservas (
    ReservaID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID INT,
    AplicacionID INT,
    FechaReserva DATETIME,
    DuracionDias INT,
    CONSTRAINT FK_Usuario_Reserva FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    CONSTRAINT FK_Aplicacion_Reserva FOREIGN KEY (AplicacionID) REFERENCES Aplicaciones(AplicacionID)
);


3. **Agregar datos a las tablas en SQL Server.** Utilizar el siguiente código SQL:


-- Para registrar datos semilla manualmente
INSERT INTO Usuarios (Nombre)
VALUES ('Usuario1');

INSERT INTO Usuarios (Nombre)
VALUES ('Usuario2');

INSERT INTO Aplicaciones (Nombre)
VALUES ('Aplicación A');

INSERT INTO Aplicaciones (Nombre)
VALUES ('Aplicación B');

INSERT INTO Aplicaciones (Nombre)
VALUES ('Aplicación C');

-- Para registrar reservas
-- Usuario1 reserva Aplicación A por 30 días
INSERT INTO Reservas (UsuarioID, AplicacionID, FechaReserva, DuracionDias)
VALUES (1, 1, GETDATE(), 30);

-- Usuario2 reserva Aplicación B por 15 días
INSERT INTO Reservas (UsuarioID, AplicacionID, FechaReserva, DuracionDias)
VALUES (2, 2, GETDATE(), 15);



4. **Actualizar la conexión a la base de datos en el archivo appsettings.json** Cambiar los atributos "Server" y "Database"

5. **Si es necesario reataurar las dependencias y compilar el proyecto** Debes ejecutar en el terminal:
dotnet restore
dotnet build

6. **Para iniciar el proyecto** Ejecutar en el terminal:
dotnet run

7. **Abrir navegador web** visitar la URL http://localhost:5031/swagger/index.html


¡Listo! Ahora puedes explorar y probar la API en tu entorno local.
