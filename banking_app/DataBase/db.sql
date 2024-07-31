-- Criar banco de dados
CREATE DATABASE BankingApp;

-- Usar o banco de dados
USE BankingApp;

-- Tabela de Usuários
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    CPF VARCHAR(14) UNIQUE NOT NULL,
    Email VARCHAR(255) UNIQUE NOT NULL,
    Senha VARCHAR(255) NOT NULL,
    Saldo DECIMAL(10, 2) NOT NULL,
    Tipo ENUM('Comum', 'Lojista') NOT NULL
);

-- Tabela de Transações
CREATE TABLE Transacoes (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    RemetenteId INT NOT NULL,
    DestinatarioId INT NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL,
    Data DATETIME NOT NULL,
    FOREIGN KEY (RemetenteId) REFERENCES Usuarios(Id),
    FOREIGN KEY (DestinatarioId) REFERENCES Usuarios(Id)
);


ALTER TABLE Usuarios
CHANGE COLUMN NomeCompleto Nome VARCHAR(255) NOT NULL;

ALTER TABLE Usuarios
CHANGE COLUMN TipoUsuario Tipo ENUM('Comum', 'Lojista') NOT NULL;
