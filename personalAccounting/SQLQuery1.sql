/*
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    AuthStatus BIT NOT NULL DEFAULT 0
);

CREATE TABLE Account (
    AccountId INT IDENTITY(1,1) PRIMARY KEY,
    AccountName NVARCHAR(100) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0,
    Currency NVARCHAR(10) NOT NULL,
    UserId INT NOT NULL,
    CONSTRAINT FK_Account_User FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE [Transaction] (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,
    Amount DECIMAL(18, 2) NOT NULL,
    Date DATETIME NOT NULL,
    TransactionType NVARCHAR(20) NOT NULL, 
    Category NVARCHAR(50),
    Description NVARCHAR(255),
    UserId INT NOT NULL,
    CONSTRAINT FK_Transaction_User FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE [Fund] (
    FundId INT PRIMARY KEY IDENTITY(1,1),
    FundName NVARCHAR(100) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    UserId INT NOT NULL
);

CREATE TABLE [UserAccount] (
    UserId INT NOT NULL,
    AccountId INT NOT NULL,
    PRIMARY KEY (UserId, AccountId),
    FOREIGN KEY (UserId) REFERENCES [Users](UserId),
    FOREIGN KEY (AccountId) REFERENCES [Account](AccountId)
);
*/

/*
INSERT INTO Users (UserName, Email, PasswordHash, AuthStatus)
VALUES ('Test User', 'test@test.com', '123', 1); 

INSERT INTO Account (AccountName, Balance, Currency, UserId)
VALUES ('Готівка', 5000.00, 'UAH', 1);
*/

--INSERT INTO [Account] (AccountName, Balance, Currency, UserId) 
--VALUES (N'Основний гаманець', 10000.00, N'UAH', 1);

--INSERT INTO [Fund] (FundName, Balance, UserId) 
--VALUES (N'Фонд на ремонт', 5000.00, 1); 

--INSERT INTO [UserAccount] (UserId, AccountId) 
--VALUES (1, 1);

