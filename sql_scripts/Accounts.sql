IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Accounts')
BEGIN
    CREATE TABLE [Accounts] (
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [CompanyID] INT NOT NULL,
        [AccountType] NVARCHAR(10) CHECK (AccountType IN ('Person', 'API-Key')),
        [Name] NVARCHAR(255) NOT NULL,
        [Email] NVARCHAR(255) NOT NULL,
        [Password] NVARCHAR(255) NOT NULL,
        [APIKey] NVARCHAR(255) NULL,
        [IsDisabled] BIT NOT NULL
    );
END

