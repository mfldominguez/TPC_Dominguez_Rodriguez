
--IMPORTANTE, SE CAMBIO LAS TABLAS A PLURAL, SE AGREGA FECHA A COMENTARIO, SE CREO TABLA PRIORIDADES.
-- SE CAMBIO COMENTARIOS A DEFAULT POR RELACION DE 1(SOLICITUD) A MUCHOS(COMENTARIOS)

use master
go
drop database TPC_Dominguez_Rodriguez
go
Create Database TPC_Dominguez_Rodriguez
go
Use TPC_Dominguez_Rodriguez
go
CREATE TABLE Usuarios(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDTipodeusuario INT NOT NULL,
	NombreU VARCHAR(50) UNIQUE NOT NULL,
	Contraseña VARCHAR(50) NOT NULL,
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	Estado BIT NOT NULL,
)
GO
CREATE TABLE TipoUsuarios(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL
)
GO
CREATE TABLE Clientes(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	Estado BIT NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FechaReg date NOT NULL
)
GO
CREATE TABLE Solicitudes(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDCliente INT NOT NULL,
	IDUsuario BIGINT NOT NULL,
	IDProblematica INT NOT NULL,
	IDPrioridad INT NOT NULL,
	Titulo VARCHAR(100),
	Descripcion VARCHAR(500),
	IDEstado INT NOT NULL,
	FechaInicio date not null,
	FechaFin date null
)
GO
CREATE TABLE Comentarios(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDSolicitud BIGINT NOT NULL,
	IDUsuario BIGINT NOT NULL,
	FechaComentario date not null,
	Comentario VARCHAR(500) NOT NULL,
	Solucion bit null
)
GO
CREATE TABLE Estado_de_Solicitud(
	ID INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	Nombre VARCHAR(50) NOT NULL
)
GO
CREATE TABLE Problematicas(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(100) NOT NULL,
	Estado bit not null
)
GO
CREATE TABLE Prioridades(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(10) NOT NULL,
)

/* Restricciones */
-- Foreign Key
Alter Table Usuarios
Add constraint FK_TipoUsuarios Foreign Key(IDTipodeusuario) references TipoUsuarios(ID)
go
Alter Table Solicitudes
Add constraint FK_Clientes Foreign Key(IDCliente) references Clientes(ID)
go
Alter Table Solicitudes
Add constraint FK_Usuarios Foreign Key(IDUsuario) references Usuarios(ID)
go
Alter Table Solicitudes
Add constraint FK_Problematicas Foreign Key(IDProblematica) references Problematicas(ID)
go
Alter Table Solicitudes
Add constraint FK_Estado Foreign Key(IDEstado) references Estado_de_Solicitud(ID)
go
Alter Table Solicitudes
Add constraint FK_Prioridades Foreign Key(IDPrioridad) references Prioridades(ID)
go
Alter Table Comentarios
Add constraint FK_IDUsuario Foreign Key(IDUsuario) references Usuarios(ID)
go
Alter Table Comentarios
Add constraint FK_IDSoliticud Foreign Key(IDSolicitud) references Solicitudes(ID)
go

/* Vistas */

Create View VW_ListaUsuarios AS 
Select U.*, TU.Nombre 
FROM Usuarios AS U
INNER JOIN TipoUsuarios as TU ON TU.ID = U.IDTipodeusuario
GO

select * from Usuarios
select * from TipoUsuarios

Create View VW_ListaClientes AS
Select * FROM Clientes
GO

Create View VW_ListaSolicitud AS
Select S.*, ES.Nombre FROM Solicitudes AS S
INNER JOIN Clientes AS C ON C.ID = S.IDCliente
INNER JOIN Usuarios AS U ON U.ID = S.IDUsuario
INNER JOIN Problematicas AS P ON P.ID = S.IDProblematica
INNER JOIN Estado_de_Solicitud AS ES ON ES.ID = S.IDEstado
GO

/* STORE PROCEDURE */

CREATE PROCEDURE SP_Solicitud(
	@ID BIGINT
)
AS
BEGIN
SELECT S.ID, S.IDCliente, S.IDUsuario, S.IDProblematica, S.Titulo, S.Descripcion, S.IDEstado, S.FechaInicio , U.Nombres, U.Apellidos, ES.Nombre
FROM Solicitudes AS S
INNER JOIN Clientes AS C ON C.ID = S.IDCliente
INNER JOIN Usuarios AS U ON U.ID = S.IDUsuario
INNER JOIN Problematicas AS P ON P.ID = S.IDProblematica
INNER JOIN Estado_de_Solicitud AS ES ON ES.ID = s.IDEstado
WHERE S.ID = @ID
END
GO

Create procedure SP_ListaSolicitud_Abierta(
	@IDCliente INT
)
AS
BEGIN
Select S.ID, S.Titulo, S.FechaInicio, ES.Nombre, P.Nombre, PRIO.Nombre FROM Solicitudes as S
INNER JOIN Estado_de_Solicitud AS ES ON ES.ID = S.IDEstado
INNER JOIN Problematicas as P ON P.ID = S.IDProblematica
INNER JOIN Prioridades AS PRIO ON PRIO.ID = S.IDPrioridad
WHERE S.IDCliente = @IDCliente AND S.IDEstado between 1 and 2 
END
GO

Create procedure SP_ListaSolicitud_Cerrada(
	@IDCliente INT
)
AS
BEGIN
Select S.ID, S.Titulo, S.FechaFin, ES.Nombre, P.Nombre, PRIO.Nombre FROM Solicitudes as S
INNER JOIN Estado_de_Solicitud AS ES ON ES.ID = S.IDEstado
INNER JOIN Problematicas as P ON P.ID = S.IDProblematica
INNER JOIN Prioridades AS PRIO ON PRIO.ID = S.IDPrioridad
WHERE S.IDCliente = @IDCliente AND S.IDEstado between 3 and 5
END
GO

Create procedure SP_Alta_Solicitud(
	@IDCliente int,
	@IDUsuario bigint,
	@IDProblematica int,
	@IDPrioridad int,
	@Titulo varchar(100),
	@Descripcion varchar(500),
	@IDEstado int,
	@FechaInicio date
)
AS 
BEGIN
INSERT INTO Solicitudes VALUES (@IDCliente, @IDUsuario, @IDProblematica, @IDPrioridad, @Titulo, @Descripcion, @IDEstado, @FechaInicio, null)
END
GO

Create Procedure SP_Solucionar(
	@ID bigint,
	@FechaFin date
)
AS
BEGIN
UPDATE Solicitudes SET IDEstado = 3, FechaFin = @FechaFin
WHERE ID = @ID
END
GO

EXEC SP_Alta_Solicitud 1,1,1,'ASD','ASD',1,'06/07/2020'

INSERT INTO Solicitudes VALUES (1,1,1,'asd','asd',1,'6/07/2020', NULL)
go

CREATE PROCEDURE SP_Validar_Usuario(
	@NombreU varchar(50),
	@Contraseña varchar(50)
)
AS
BEGIN
SELECT U.*, TU.Nombre FROM Usuarios AS U
INNER JOIN TipoUsuarios as TU ON TU.ID = U.IDTipodeusuario
WHERE NombreU = @NombreU AND Contraseña = @Contraseña
END
GO

CREATE PROCEDURE SP_Alta_Usuario(
	@IDTipodeusuario int,
	@NombreU varchar(50),
	@Contraseña varchar(50),
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Estado bit
)
AS
BEGIN
INSERT INTO Usuarios VALUES (@IDTipodeusuario, @NombreU, @Contraseña, @Nombres, @Apellidos, @Estado)
END
GO

CREATE PROCEDURE SP_Usuario_Inactivo(
	@ID BIGINT,
	@Estado bit
)
AS
BEGIN 
UPDATE Usuarios SET Estado = @Estado WHERE ID = @ID
END
GO

CREATE PROCEDURE SP_Modificar_Usuario(
	@ID BIGINT,
	@IDTipodeusuario int,
	@NombreU varchar(50),
	@Contraseña varchar(50),
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Estado bit
)
AS
BEGIN
UPDATE Usuarios SET IDTipodeusuario = @IDTipodeusuario, NombreU = @NombreU, Contraseña = @Contraseña, Nombres = @Nombres, Apellidos = @Apellidos, Estado = @Estado
WHERE ID = @ID
END
GO

CREATE PROCEDURE SP_Alta_Cliente(
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Estado bit,
	@Direccion varchar(100),
	@Telefono varchar(20),
	@FechaReg date
)
AS
BEGIN 
INSERT INTO Clientes VALUES (@Nombres, @Apellidos, @Estado, @Direccion, @Telefono, @FechaReg)
END
GO

CREATE PROCEDURE SP_Modificar_Cliente(
	@ID BIGINT,
	@Nombres varchar(50),
	@Apellidos varchar(50),
	@Estado bit,
	@Direccion varchar(100),
	@Telefono varchar(20),
	@FechaReg date
)
AS
BEGIN
UPDATE Clientes SET Nombres = @Nombres, Apellidos = @Apellidos, Estado = @Estado, Direccion = @Direccion, Telefono = @Telefono, FechaReg = @FechaReg
WHERE ID = @ID
END
GO

CREATE PROCEDURE SP_Cliente_Inactivo(
	@ID int,
	@Estado bit
)
AS
BEGIN 
UPDATE Clientes SET Estado = @Estado WHERE ID = @ID
END
GO

CREATE PROCEDURE SP_Alta_Comentario(
	@IDSolicitud bigint,
	@IDUsuario bigint,
	@FechaComentario date,
	@Comentario varchar(500)	
)
AS
BEGIN
INSERT INTO Comentarios VALUES (@IDSolicitud , @IDUsuario, @FechaComentario, @Comentario)
END
GO


Create procedure SP_Listar_Comentarios(
	@IDSolicitud BIGINT
)
AS
BEGIN
SELECT C.ID, C.IDUsuario, U.Nombres, U.Apellidos, C.Comentario, C.FechaComentario
FROM Comentarios as C
INNER JOIN Usuarios AS U ON U.ID = C.IDUsuario
WHERE C.IDSolicitud = @IDSolicitud
END
GO

Select * from Usuarios 
Select * from Clientes

/* INSERTS */

INSERT INTO Prioridades VALUES ( 'Baja' )
go
INSERT INTO Prioridades VALUES ( 'Media' )
go
INSERT INTO Prioridades VALUES ( 'Alta' )
go
INSERT INTO Prioridades VALUES ( 'Critica' )
go

INSERT INTO Problematicas VALUES ( 'Falla fisica', 1 )
go
INSERT INTO Problematicas VALUES ( 'Falla logica', 1 )
go
INSERT INTO Problematicas VALUES ( 'Solicitud de respuesto', 1)
go

INSERT INTO TipoUsuarios VALUES ( 'Administrador' )
go
INSERT INTO TipoUsuarios VALUES ( 'Gerente' )
go
INSERT INTO TipoUsuarios VALUES ( 'Operador' )
go

INSERT INTO Estado_de_Solicitud VALUES ( 'Abierto' )
go
INSERT INTO Estado_de_Solicitud VALUES ( 'En analisis' )
go
INSERT INTO Estado_de_Solicitud VALUES ( 'Solucionado' )
go
INSERT INTO Estado_de_Solicitud VALUES ( 'Rechazado' )
go
INSERT INTO Estado_de_Solicitud VALUES ( 'Cerrado' )
go

INSERT INTO Usuarios VALUES ( 1 , 'fer', '123' , 'Fernando' , 'Dominguez' , 1)
go
INSERT INTO Usuarios VALUES ( 1 , 'lean', '123' , 'Leandro' , 'Rodriguez' , 1)
go

INSERT INTO Clientes VALUES ( 'Pepe' , 'Gomez' , 1 , '1 de mayo 123' , '47442323' , '2020/11/22' )
go
INSERT INTO Clientes VALUES ( 'Nestor' , 'Vive' , 1 , 'Almirante Brown 2234' , '47152345' , '2020/11/20' )
go

INSERT INTO Solicitudes VALUES ( 1 , 1 , 1 , 1 , 'Falla en la cortadora' , 'No corta la carne' , 1 , '2020/11/22', null )
go

INSERT INTO Comentarios VALUES ( 1 , 1 , '2020/11/22', 'Se llamo al fabricante' )
go

select * from Comentarios
select * from Usuarios
