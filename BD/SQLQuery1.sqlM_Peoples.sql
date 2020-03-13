CREATE DATABASE M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios(
	IdFuncionarios INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (255) NOT NULL,
	SobreNome VARCHAR (255) NOT NULL
);


CREATE TABLE TipoUsuarios(
			IdTipoUsuario INT PRIMARY KEY IDENTITY,
			TituloTipoUsuario VARCHAR (200) NOT NULL UNIQUE,
			);
CREATE TABLE Usuarios (

		IdUsuario INT PRIMARY KEY IDENTITY,
		Email VARCHAR (255) NOT NULL UNIQUE,
		Senha VARCHAR (255) NOT NULL,
		IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuarios (IdTipoUsuario)
	
);

INSERT INTO Funcionarios(Nome,SobreNome)
VALUES ('Catarina','Strada'),
		('Tadeu','Vitelli');

INSERT INTO TipoUsuarios(TituloTipoUsuario)
VALUES ('Administrador'),
		('Usuario');

INSERT INTO Usuarios (Email,Senha,IdTipoUsuario)
VALUES ('Catarina@123','123',1),
	   ('Tadeu@123','123',2);




select * from Funcionarios;

SELECT IdFuncionarios,Nome,SobreNome FROM Funcionarios

select * from TipoUsuarios;

select * from Usuarios;