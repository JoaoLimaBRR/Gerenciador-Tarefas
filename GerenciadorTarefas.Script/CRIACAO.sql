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
    IdTarefa UNIQUEIDENTIFIER PRIMARY KEY  NOT NULL,
    CpfUsuarioTarefa VARCHAR(11),
    Titulo VARCHAR(55) NOT NULL,
    Descricao VARCHAR(255) NOT NULL,
    CodigoSituacao INTEGER NOT NULL,
    CONSTRAINT fk_Tarefa_Situacao FOREIGN KEY (CodigoSituacao) REFERENCES Situacao (Codigo),
    CONSTRAINT fk_Usuario_Tarefa FOREIGN KEY (CpfUsuarioTarefa) REFERENCES Usuario (Cpf)
)

drop table tarefa

drop TABLE Usuario
drop TABLE Situacao
drop TABLE Tarefa


