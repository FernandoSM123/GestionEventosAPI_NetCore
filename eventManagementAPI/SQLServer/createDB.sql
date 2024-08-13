-- Elimina la base de datos si ya existe
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'event_management')
BEGIN
    DROP DATABASE event_management;
END
GO

-- Crea la base de datos
CREATE DATABASE event_management;
GO