-- Cerrar todas las conexiones activas a la base de datos
USE master;
GO

-- Cerrar todas las conexiones activas a la base de datos
ALTER DATABASE event_management SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

-- Elimina la base de datos si ya existe
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'event_management')
BEGIN
    DROP DATABASE event_management;
END
GO

-- Crea la base de datos
CREATE DATABASE event_management;
GO