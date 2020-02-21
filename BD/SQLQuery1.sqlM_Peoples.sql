CREATE DATABASE M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios(
	IdFuncionarios INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (255) NOT NULL,
	SobreNome VARCHAR (255) NOT NULL
);

INSERT INTO Funcionarios(Nome,SobreNome)
VALUES ('Catarina','Strada'),
		('Tadeu','Vitelli');


select * from Funcionarios;

SELECT IdFuncionarios,Nome,SobreNome FROM Funcionarios