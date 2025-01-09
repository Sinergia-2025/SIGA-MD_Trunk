PRINT ''
PRINT '1. Formatos Etiqueta: Nuevo Formato: 1 x Ancho (5 x 2.5 cm) + Lote'
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta],[NombreFormatoEtiqueta],[Tipo],
            [ArchivoAImprimir],[ArchivoAImprimirEmbebido],[NombreImpresora],
            [ImprimeLote],[MaximoColumnas],[UtilizaCabecera],[SolicitaListaPrecios2],[Activo])
     VALUES
           (14, '1 x Ancho (5 x 2.5 cm) + Lote', 'CODIGOBARRA',
            'Eniac.Win.EmisionDeEtiquetasCodBarraF8.rdlc',  'True', '',
            'True', 1, 'False', 'False', 'True')
GO

PRINT ''
PRINT '2. Tabla Clientes: Nuevos campos URLActualizadorPropio y NroVersionActualizadorPropio'
ALTER TABLE dbo.Clientes ADD URLActualizadorPropio varchar(150) NULL
ALTER TABLE dbo.Clientes ADD NroVersionActualizadorPropio varchar(50) NULL

PRINT ''
PRINT '2.1. Tabla AuditoriaClientes: Nuevos campos URLActualizadorPropio y NroVersionActualizadorPropio'
ALTER TABLE dbo.AuditoriaClientes ADD URLActualizadorPropio varchar(150) NULL
ALTER TABLE dbo.AuditoriaClientes ADD NroVersionActualizadorPropio varchar(50) NULL

PRINT ''
PRINT '2.2. Tabla Prospectos: Nuevos campos URLActualizadorPropio y NroVersionActualizadorPropio'
ALTER TABLE dbo.Prospectos ADD URLActualizadorPropio varchar(150) NULL
ALTER TABLE dbo.Prospectos ADD NroVersionActualizadorPropio varchar(50) NULL

PRINT ''
PRINT '2.3. Tabla AuditoriaProspectos: Nuevos campos URLActualizadorPropio y NroVersionActualizadorPropio'
ALTER TABLE dbo.AuditoriaProspectos ADD URLActualizadorPropio varchar(150) NULL
ALTER TABLE dbo.AuditoriaProspectos ADD NroVersionActualizadorPropio varchar(50) NULL

PRINT ''
PRINT '2.4. Tabla Clientes: Ajustar URLS de clientes'
UPDATE Clientes
   SET URLWebmovilPropio = REPLACE(URLWebmovilPropio, 'w1021701', 'wi531792')
     , URLWebmovilAdminPropio = REPLACE(URLWebmovilAdminPropio, 'w1021701', 'wi531792')
     , URLSimovilGestionPropio = REPLACE(URLSimovilGestionPropio, 'w1021701', 'wi531792')
 WHERE CodigoCliente = 204
GO
IF dbo.SoyHAR() = 'True'
BEGIN
    PRINT ''
    PRINT '2.5. HAR: Tabla Clientes: Cargar URL del actualizador automático'
    UPDATE C
       SET URLActualizadorPropio = P.ValorParametro
      FROM Parametros P
     CROSS JOIN (SELECT * FROM Clientes WHERE CodigoCliente = 204) C
     WHERE P.IdParametro = 'URLACTUALIZADOR'
END
