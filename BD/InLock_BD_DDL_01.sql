-- Cria o banco de dados - DDL
create database InLock_Games_M;


-- Define o banco de dados que será utilizado
use InLock_Games_M;


-- Cria a tabela Estudios
create table Estudio(
	IdEstudio	 INT PRIMARY KEY IDENTITY
	,NomeEstudio varchar (255) NOT NULL UNIQUE
);


create table Jogo(
	  IdJogo INT PRIMARY KEY IDENTITY
	, NomeJogo varchar (255) NOT NULL UNIQUE
	, Descricao varchar (255) NOT NULL 
	, DataLancamento DATE
	, Valor FLOAT 
	,IdEstudio INT FOREIGN KEY REFERENCES Estudio(IdEstudio)
);


create table TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY
	,Titulo varchar (255) NOT NULL 
);


create table Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY
	,Email		varchar (255) NOT NULL UNIQUE
	,Senha		varchar (255) NOT NULL 
	,IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);

select * from Usuario;



