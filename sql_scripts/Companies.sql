IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Companies')
BEGIN
    CREATE TABLE [Companies] (
        [ID] INT IDENTITY(1,1) PRIMARY KEY,
        [ParentCompanyID] INT NULL,
        [Name] NVARCHAR(255) NOT NULL,
        [INN] NVARCHAR(12) NOT NULL,
        [Phone] NVARCHAR(20) NOT NULL
    );
END
