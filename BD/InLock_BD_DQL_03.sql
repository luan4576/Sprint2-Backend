-- DQL LINGUAGEM DE CONSULTA DE DADOS 

-- Define o banco de dados que ser� utilizado
use InLock_Games_M;

--Listar todos os usu�rios;
select * from Usuario;

--Listar todos os est�dios; 
select * from Estudio;

--Listar todos os jogos; 
select * from Jogo;


--SELECT Jogo.IdJogo, Jogo.DataLancamento, Jogo.Descricao, Jogo.NomeJogo, Jogo.Valor, Estudio.NomeEstudio from Jogo 
--inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio;
 
--Listar todos os jogos e seus respectivos est�dios; 
select Jogo.IdJogo, Jogo.NomeJogo,Estudio.NomeEstudio from Jogo 
inner join Estudio on Jogo.IdEstudio = Estudio.IdEstudio;
 
 --Buscar e trazer na lista todos os est�dios, mesmo que eles n�o contenham nenhum jogo de refer�ncia; 
select * from Estudio;

 --Buscar um usu�rio por email e senha; 
select Usuario.Email , Usuario.Senha from Usuario;

 --Buscar um jogo por IdJogo; 
select * from Jogo
where IdJogo = 3;

 --Buscar um est�dio por IdEstudio; 
 select * from Estudio
where IdEstudio = 2;


