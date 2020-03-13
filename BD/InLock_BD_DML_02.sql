-- Define o banco de dados que será utilizado - DML
use InLock_Games_M;


-- Insere dados na tabela 

insert into TipoUsuario	(Titulo)
values				('Administrador')
					,('Cliente' );


insert into Usuario	(Email, Senha, IdTipoUsuario)
values				('admin@admin.com' ,'admin' , 1)
					,('cliente@cliente.com','cliente' , 2);


insert into Estudio	(NomeEstudio)
values				 ('Blizzard' )
					,('Rockstar Studios')
					,('Square Enix');


insert into Jogo	(NomeJogo, DataLancamento, Descricao, IdEstudio , Valor)
values				 ('Diablo3' , '15/05/2012' , 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', 1 , 99)
					,('Red Dead Redemption II' , '26/10/2018' , 'jogo eletrônico de ação-aventura western' , 2 ,  120);


