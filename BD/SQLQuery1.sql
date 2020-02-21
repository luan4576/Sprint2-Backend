CREATE DATABASE Filmes;

USE  Filmes;


CREATE TABLE Genero (
	IdGenero INT PRIMARY KEY IDENTITY,
	Nome   VARCHAR (255) UNIQUE NOT NULL
	);

	
CREATE TABLE Filme (
		IdFilme INT PRIMARY KEY IDENTITY,
		Titulo VARCHAR (255) UNIQUE NOT NULL,
		IdGenero INT FOREIGN KEY REFERENCES Genero (IdGenero)
		);
		Drop table Filme;

INSERT INTO Genero (Nome)
VALUES ('Drama'),('Acao');

INSERT INTO Filme(Titulo,IdGenero)
VALUES ('A vida e bela',1) , ('Rambo',2);


SELECT * FROM Filme;


SELECT Filme.Titulo,Genero.Nome
from Filme INNER JOIN Genero on Filme.IdGenero = Genero.IdGenero;