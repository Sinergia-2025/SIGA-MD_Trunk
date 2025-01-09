IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = 'dboOficina')
BEGIN
    /****** Object:  Schema [dboOficina]    Script Date: 24/11/2022 08:45:52 ******/
    EXEC('CREATE SCHEMA dboOficina')
END
GO
