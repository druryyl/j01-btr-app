CREATE LOGIN btrLogin
    WITH PASSWORD = 'btr123!';
GO

CREATE USER btrUser FOR LOGIN btrLogin;
GO

sp_addrolemember 'db_datareader', 'btrUser';
GO

sp_addrolemember 'db_datawriter','btrUser';
GO

sp_addrolemember 'db_ddladmin', 'btrUser';
GO
