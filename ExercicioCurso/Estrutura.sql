CREATE TABLE pessoas(
id int PRIMARY KEY IDENTITY (1,1),
nome VARCHAR(100),
cpf VARCHAR(14),
idade SMALLINT,
pago bit,
cidade VARCHAR(100),
email VARCHAR(100),
registro_ativo bit
)

CREATE TABLE cursos(
id int PRIMARY KEY IDENTITY (1,1),
tema VARCHAR(100),
inscritos int,
data_curso DATETIME,
confirmado bit, 
estado VARCHAR(2),
cidade VARCHAR(100),
bairro VARCHAR(100),
valor DECIMAl,
registro_ativo bit
)

CREATE TABLE inscricoes(
id int PRIMARY KEY IDENTITY (1,1),  
nome VARCHAR(100),  
registro_ativo bit
)