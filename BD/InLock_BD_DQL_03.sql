-- DQL LINGUAGEM DE CONSULTA DE DADOS 

-- Define o banco de dados que será utilizado
use InLock_Games_M;

--Listar todos os usuários;
select * from Usuario;

--Listar todos os estúdios; 
select * from Estudio;

--Listar todos os jogos; 
select * from Jogo;


--SELECT Jogo.IdJogo, Jogo.DataLancamento, Jogo.Descricao, Jogo.NomeJogo, Jogo.Valor, Estudio.NomeEstudio from Jogo 
--inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio;
 
--Listar todos os jogos e seus respectivos estúdios; 
select Jogo.IdJogo, Jogo.NomeJogo,Estudio.NomeEstudio from Jogo 
inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio;
 
 --Buscar e trazer na lista todos os estúdios, mesmo que eles não contenham nenhum jogo de referência; 
select * from Estudio;

 --Buscar um usuário por email e senha; 
select Usuario.Email , Usuario.Senha from Usuario;

 --Buscar um jogo por IdJogo; 
select * from Jogo
where IdJogo = 3;

 --Buscar um estúdio por IdEstudio; 
 select * from Estudio
where IdEstudio = 2;


