USE MASTER;
CREATE TABLE Usuario(
    Cpf VARCHAR(11) PRIMARY KEY NOT NULL, 
    Nome VARCHAR(55) NOT NULL, 
    DataNascimento DATE NOT NULL
)

CREATE TABLE Situacao(
    Codigo INTEGER  IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Descricao VARCHAR(255) NOT NULL
)

CREATE TABLE Tarefa (
    IdTarefa UNIQUEIDENTIFIER NOT NULL,
    Descricao VARCHAR(255) NOT NULL,
    Titulo VARCHAR(55) NOT NULL,
    Cpf VARCHAR(11) NOT NULL,
    CodigoSituacao INTEGER NOT NULL,
    CONSTRAINT fk_Tarefa_Situacao FOREIGN KEY (CodigoSituacao) REFERENCES Situacao (Codigo),
    CONSTRAINT fk_Usuario_Tarefa FOREIGN KEY (Cpf) REFERENCES Usuario (Cpf)
)

drop TABLE Usuario
drop TABLE Situacao
drop TABLE Tarefa


