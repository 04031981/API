USE API
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'USUARIO')
BEGIN
    CREATE TABLE dbo.USUARIO(
        IdUsuario int primary key identity(1,1),
        Nombres varchar(60),
        Apellido varchar(60),
        DNI varchar(60),
        Correo varchar(60),
        Registro datetime default getdate()
    )
END
