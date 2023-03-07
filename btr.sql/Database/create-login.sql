CREATE LOGIN btrLogin
    WITH PASSWORD = 'btr123!';

CREATE USER btrUser FOR LOGIN btrLogin;

sp_addrolemember 'db_datareader', 'hlinikUser';
sp_addrolemember 'db_datawriter','hlinikUser';
sp_addrolemember 'db_ddladmin', 'hlinikUser';
