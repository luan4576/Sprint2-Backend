-- Define o banco de dados que ser� utilizado - DML
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
values				 ('Diablo3' , '15/05/2012' , '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', 1 , 99)
					,('Red Dead Redemption II' , '26/10/2018' , 'jogo eletr�nico de a��o-aventura western' , 2 ,  120);


