create database db_MeusRepositoriosKria
go
use db_MeusRepositoriosKria

CREATE TABLE tb_DonoRepositorio(
	Id INT PRIMARY KEY IDENTITY(1,1),
	nomeDonoRepositorio VARCHAR(100) NOT NULL
);

CREATE TABLE tb_linguagens(
Id INT PRIMARY KEY IDENTITY(1,1),
nomeLinguagens VARCHAR(20)
);

CREATE TABLE tb_Repositorios(
Id INT PRIMARY KEY IDENTITY(1,1),
nomeRepositorio VARCHAR(100) NOT NULL,
dataUltimaAtt DATETIME NOT NULL,
idDonoRepositorio INT NOT NULL,
idLinguagem INT NOT NULL,
descricao varchar(max) Not NULL,

FOREIGN KEY (idDonoRepositorio) REFERENCES tb_DonoRepositorio(Id),
FOREIGN KEY (idLinguagem) REFERENCES tb_linguagens(Id)
);

CREATE TABLE tb_favoritos(
Id INT PRIMARY KEY IDENTITY(1,1),
idRepositorio INT NOT NULL,

FOREIGN KEY (idRepositorio) REFERENCES tb_Repositorios(Id),
)



 Go
 CREATE PROCEDURE InsertRepositorio 
@nomeRepositorio VARCHAR (max),
@dataUltimaAtt datetime,
@nomeDonoRepositorio varchar(max),
@nomelinguagens varchar(max),
@descricao varchar(max)
AS
begin
if not exists (select  tb_DonoRepositorio.nomeDonoRepositorio from tb_DonoRepositorio where tb_DonoRepositorio.nomeDonoRepositorio = @nomeDonoRepositorio)
	insert into tb_DonoRepositorio values (@nomeDonoRepositorio);
		if not exists(select  nomeLinguagens from tb_linguagens where nomeLinguagens = @nomelinguagens)
			insert into tb_linguagens values (@nomelinguagens);
INSERT INTO tb_Repositorios Values(@nomeRepositorio,@dataUltimaAtt,(select tb_DonoRepositorio.Id from tb_DonoRepositorio where nomeDonoRepositorio = @nomeDonoRepositorio), (select Id from tb_linguagens where nomeLinguagens = @nomelinguagens), @descricao);
End

GO

CREATE PROCEDURE SelectRepositoById
@Id int
AS
begin
Select r.Id, r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_Repositorios as r join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id where r.Id = @Id  order by r.Id desc
End

GO

CREATE PROCEDURE Favoritos
@Id int
AS
begin
 If exists(Select Id from tb_Repositorios where Id = @Id) and not exists(select idRepositorio from tb_favoritos where idRepositorio = @Id)
 Insert into tb_favoritos values(@Id);
 Select r.Id, r.nomeRepositorio, r.dataUltimaAtt, r.descricao, d.nomeDonoRepositorio, l.nomeLinguagens from tb_Repositorios as r join tb_DonoRepositorio as d on r.idDonoRepositorio = d.Id join tb_linguagens as l on r.idLinguagem = l.Id where r.Id = @Id  order by r.Id desc;
End

go
CREATE PROCEDURE Deletar
@Id int
AS
begin
 if exists(select * from tb_favoritos where idRepositorio = @Id)
 delete from tb_favoritos where idRepositorio = @Id
 delete from tb_Repositorios where id = @Id
End

go
CREATE PROCEDURE DeletarAll
AS
begin
 truncate table tb_favoritos;
 delete from tb_Repositorios;
End
