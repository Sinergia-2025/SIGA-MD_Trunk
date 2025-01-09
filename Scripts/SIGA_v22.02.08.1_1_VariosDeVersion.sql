PRINT ''
PRINT '2 - Campo nuevo NroCuenta - Proveedores'
    BEGIN 
        ALTER TABLE dbo.Proveedores ADD NroCuenta Varchar(25) NULL
    END
GO