PRINT ''
PRINT '1. Tabla VentasTarjetas: Corregir montos de tarjetas mal grabados'
UPDATE VentasTarjetas
   SET Monto = Monto * - 1
  FROM VentasTarjetas VT
 INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VT.IdTipoComprobante
 WHERE TC.CoeficienteValores < 0
   AND Monto > 0

PRINT ''
PRINT '2. Tabla VentasProductos: Nombre Producto varchar 1000'
ALTER TABLE dbo.VentasProductos ALTER COLUMN  NombreProducto varchar(1000) NOT NULL;


MERGE INTO Versiones AS D
        USING (
               SELECT VS.IdAplicacion, VS.NroVersion
                    , CONVERT(DATE, '19000101') VersionFecha, NULL IdAplicacionBase, NULL NroVersionAplicacionBase
                    , '' VersionFramework, '' VersionReportViewer, '' VersionLenguaje
                 FROM VersionesScripts VS
              ) AS O ON O.IdAplicacion = D.IdAplicacion AND O.NroVersion = D.NroVersion
    WHEN NOT MATCHED THEN
        INSERT (IdAplicacion, NroVersion, VersionFecha, IdAplicacionBase, NroVersionAplicacionBase, VersionFramework, VersionReportViewer, VersionLenguaje) 
        VALUES (O.IdAplicacion, O.NroVersion, O.VersionFecha, O.IdAplicacionBase, O.NroVersionAplicacionBase, O.VersionFramework, O.VersionReportViewer, O.VersionLenguaje)
;


PRINT ''
PRINT '3. Tabla VersionesScripts: FK a Versiones'
ALTER TABLE dbo.VersionesScripts ADD CONSTRAINT FK_VersionesScripts_Versiones
    FOREIGN KEY (IdAplicacion,NroVersion)
    REFERENCES dbo.Versiones (IdAplicacion,NroVersion)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
