IF dbo.ExisteCampo('Pedidos', 'FechaActualizacion') = 0
BEGIN
    ALTER TABLE dbo.Pedidos ADD FechaActualizacion datetime NULL
    ALTER TABLE dbo.Pedidos ADD IdUsuarioActualizacion varchar(10) NULL
END
GO

UPDATE Pedidos
   SET FechaActualizacion = FechaPedido
     , IdUsuarioActualizacion = IdUsuario
 WHERE FechaActualizacion IS NULL
;

ALTER TABLE dbo.Pedidos ALTER COLUMN FechaActualizacion datetime NOT NULL
ALTER TABLE dbo.Pedidos ALTER COLUMN IdUsuarioActualizacion varchar(10) NOT NULL
GO

IF dbo.ExisteFK('FK_Pedidos_UsuariosActualizacion') = 0
BEGIN
    ALTER TABLE dbo.Pedidos ADD CONSTRAINT FK_Pedidos_UsuariosActualizacion
        FOREIGN KEY (IdUsuarioActualizacion)
        REFERENCES dbo.Usuarios (Id)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

