USE master
GO
-- Creating the ModernApiDB
DECLARE @dbname sysname
SET @dbname = 'ModernApiDB'

DECLARE @spid int
SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id(@dbname)
WHILE @spid IS NOT NULL
BEGIN
EXECUTE ('KILL ' + @spid)
SELECT @spid = min(spid) from master.dbo.sysprocesses where dbid = db_id(@dbname) AND spid > @spid
END
GO

DROP DATABASE ModernApiDB
GO 

CREATE DATABASE ModernApiDB
GO

