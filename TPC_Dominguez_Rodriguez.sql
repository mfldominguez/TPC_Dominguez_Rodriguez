
--IMPORTANTE, SE CAMBIO LAS TABLAS A PLURAL, SE AGREGA FECHA A COMENTARIO, SE CREO TABLA PRIORIDADES.

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
	IDComentario INT NOT NULL,
	Titulo VARCHAR(100),
	Descripcion VARCHAR(500),
	IDEstado INT NOT NULL,
	FechaInicio date not null,
	FechaFin date null
)
GO
CREATE TABLE Comentarios(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDUsuario BIGINT NOT NULL,
	FechaComentario date not null,
	Comentario VARCHAR(500) NOT NULL
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
Alter Table Solicitudes
Add constraint FK_Comentarios Foreign Key(IDComentario) references Comentarios(ID)
go
Alter Table Comentarios
Add constraint FK_IDUsuario Foreign Key(IDUsuario) references Usuarios(ID)
go

/* Vistas */

Create View VW_ListaUsuarios AS 
Select U.*, TU.Nombre 
FROM Usuarios AS U
INNER JOIN TipoUsuarios as TU ON TU.ID = U.IDTipodeusuario
GO

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