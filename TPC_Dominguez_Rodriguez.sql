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
CREATE TABLE TipoUsuario(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL
)
GO
CREATE TABLE Cliente(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombres VARCHAR(50) NOT NULL,
	Apellidos VARCHAR(50) NOT NULL,
	Estado BIT NOT NULL,
	Direccion VARCHAR(100) NOT NULL,
	Telefono VARCHAR(20) NOT NULL,
	FechaReg date NOT NULL
)
GO
CREATE TABLE Solicitud(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDCliente INT NOT NULL,
	IDUsuario BIGINT NOT NULL,
	IDSintoma INT NOT NULL,
	Titulo VARCHAR(100),
	Descripcion VARCHAR(500),
	IDEstado INT NOT NULL,
	FechaInicio date not null,
	FechaFin date null
)
GO
CREATE TABLE Comentarios(
	ID BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	IDSolicitud BIGINT NOT NULL,
	IDUsuario BIGINT NOT NULL,
	Comentario VARCHAR(500) NOT NULL
)
GO
CREATE TABLE EstadosdeS(
	ID INT NOT NULL PRIMARY KEY IDENTITY (1,1),
	Nombre VARCHAR(50) NOT NULL
)
GO
CREATE TABLE Sintomas(
	ID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(100) NOT NULL,
	Estado bit not null
)
GO

/* Restricciones */
-- Foreign Key
Alter Table Usuarios
Add constraint FK_TipoUsuario Foreign Key(IDTipodeusuario) references TipoUsuario(ID)
go
Alter Table Solicitud
Add constraint FK_Cliente Foreign Key(IDCliente) references Cliente(ID)
go
Alter Table Solicitud
Add constraint FK_Usuario Foreign Key(IDUsuario) references Usuarios(ID)
go
Alter Table Solicitud
Add constraint FK_Sintoma Foreign Key(IDSintoma) references Sintomas(ID)
go
Alter Table Solicitud
Add constraint FK_Estado Foreign Key(IDEstado) references EstadosdeS(ID)
go
Alter Table Comentarios
Add constraint FK_IDSolicitud Foreign Key(IDSolicitud) references Solicitud(ID)
go
Alter Table Comentarios
Add constraint FK_IDUsuario Foreign Key(IDUsuario) references Usuarios(ID)
go