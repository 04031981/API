USE API
GO

-- Eliminar procedimientos almacenados existentes si es que existen
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name IN ('API_registrar', 'API_modificar', 'API_obtener', 'API_listar', 'API_eliminar'))
BEGIN
    DROP PROCEDURE API_registrar
    DROP PROCEDURE API_modificar
    DROP PROCEDURE API_obtener
    DROP PROCEDURE API_listar
    DROP PROCEDURE API_eliminar
END
GO

-- Crear procedimientos almacenados

CREATE PROCEDURE API_registrar
(
    @nombres varchar(60),
    @apellido varchar(60),
    @dni varchar(60),
    @correo varchar(60)
)
AS
BEGIN
    INSERT INTO USUARIO (Nombres, Apellido, DNI, Correo)
    VALUES (@nombres, @apellido, @dni, @correo)
END
GO

CREATE PROCEDURE API_modificar
(
    @idusuario int,
    @nombres varchar(60),
    @apellido varchar(60),
    @dni varchar(60),
    @correo varchar(60)
)
AS
BEGIN
    UPDATE USUARIO
    SET Nombres = @nombres,
        Apellido = @apellido,
        DNI = @dni,
        Correo = @correo
    WHERE IdUsuario = @idusuario
END
GO

CREATE PROCEDURE API_obtener
(
    @idusuario int
)
AS
BEGIN
    SELECT * FROM USUARIO WHERE IdUsuario = @idusuario
END
GO

CREATE PROCEDURE API_listar
AS
BEGIN
    SELECT * FROM USUARIO
END
GO

CREATE PROCEDURE API_eliminar
(
    @idusuario int
)
AS
BEGIN
    DELETE FROM USUARIO WHERE IdUsuario = @idusuario
END
GO
