-- CREA CAMPO DE PACKID PARA FACTURACION.- --
PRINT ''
PRINT 'C0. Crea Campo en Productos: PackIdTiendaWeb'
--  Crea campo IDPack en Pedidos Tiendas Web.- --
IF not exists ( SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'PacksIdTiendaWeb' AND TABLE_NAME = 'PedidosTiendasWeb')
    BEGIN
    BEGIN TRANSACTION
        ALTER TABLE dbo.PedidosTiendasWeb ADD
	        PacksIdTiendaWeb varchar(50) NULL
        ALTER TABLE dbo.PedidosTiendasWeb SET (LOCK_ESCALATION = TABLE)

        CREATE NONCLUSTERED INDEX IX_PacksIdTiendaWeb ON dbo.PedidosTiendasWeb
	        (
	        PacksIdTiendaWeb
	        ) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

        ALTER TABLE dbo.PedidosTiendasWeb SET (LOCK_ESCALATION = TABLE)
    COMMIT
    END
GO
----------------------------------------------------
-- CREA CAMPO DE IDCAJA PARA FACTURACION EN PEDIDOS.- --
PRINT ''
PRINT 'D0. Crea Campo en Productos: IdCaja'
--  Crea campo IDCAJA en Pedidos Tiendas Web.- --
IF not exists ( SELECT *
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE COLUMN_NAME = 'IdCaja' AND TABLE_NAME = 'Pedidos')
    BEGIN
        BEGIN TRANSACTION
            ALTER TABLE dbo.CajasNombres SET (LOCK_ESCALATION = TABLE)
        COMMIT
        BEGIN TRANSACTION
                ALTER TABLE dbo.Pedidos ADD IdCaja int NULL
                ALTER TABLE dbo.Pedidos ADD CONSTRAINT
	                FK_Pedidos_Caja FOREIGN KEY
	                (IdSucursal, IdCaja) REFERENCES dbo.CajasNombres
	                (IdSucursal, IdCaja) ON UPDATE  NO ACTION 
	                 ON DELETE  NO ACTION 
	            ALTER TABLE dbo.Pedidos SET (LOCK_ESCALATION = TABLE)
        COMMIT
    END
GO
----------------------------------------------------
