
ALTER TABLE AuditoriaClientes ADD IdCliente [bigint] NULL
GO

ALTER TABLE AuditoriaClientes ADD CodigoCliente [bigint] NULL
GO

/* --------------------- */

UPDATE AuditoriaClientes 
   SET IdCliente = 
        ( SELECT IdCliente FROM Clientes b
            WHERE AuditoriaClientes.TipoDocumento = b.TipoDocumento
              AND AuditoriaClientes.NroDocumento = b.NroDocumento
          )
 WHERE IdCliente IS NULL
GO

UPDATE AuditoriaClientes 
   SET CodigoCliente = 
        ( SELECT CodigoCliente FROM Clientes b
            WHERE AuditoriaClientes.TipoDocumento = b.TipoDocumento
              AND AuditoriaClientes.NroDocumento = b.NroDocumento
          )
 WHERE CodigoCliente IS NULL
GO

/* --------------------- */

-- AQUELLOS DADOS DE ALTA Y BORRADOS

DELETE AuditoriaClientes 
 WHERE IdCliente IS NULL OR CodigoCliente IS NULL
GO

----

ALTER TABLE AuditoriaClientes ALTER COLUMN IdCliente [bigint] NOT NULL
GO

ALTER TABLE AuditoriaClientes ALTER COLUMN CodigoCliente [bigint] NOT NULL
GO
