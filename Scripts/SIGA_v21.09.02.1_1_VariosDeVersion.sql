PRINT ''
PRINT '1. Tabla CRMNovedadesCambiosEstados: Nuevo campo IdUsuarioAsignado'
ALTER TABLE dbo.CRMNovedadesCambiosEstados ADD IdUsuarioAsignado varchar(10) NULL
GO
PRINT ''
PRINT '1.1. Tabla CRMNovedadesCambiosEstados: FK_CRMNovedadesCambiosEstados_Usuarios_Asignado'
ALTER TABLE dbo.CRMNovedadesCambiosEstados ADD CONSTRAINT FK_CRMNovedadesCambiosEstados_Usuarios_Asignado
    FOREIGN KEY (IdUsuarioAsignado)
    REFERENCES dbo.Usuarios (Id)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.CRMNovedadesCambiosEstados SET (LOCK_ESCALATION = TABLE) 
GO

PRINT ''
PRINT '1.2. Tabla CRMNovedadesCambiosEstados: Ajusta registros pre-existentes'
UPDATE NCE
   SET IdUsuarioAsignado = NS.UsuarioAsignado
  FROM CRMNovedadesCambiosEstados NCE
 INNER JOIN CRMEstadosNovedades NE ON NE.IdEstadoNovedad = NCE.IdEstadoNovedad
 INNER JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = NCE.IdTipoNovedad
                                      AND NS.Letra = NCE.Letra
                                      AND NS.CentroEmisor = NCE.CentroEmisor
                                      AND NS.IdNovedad = NCE.IdNovedad
                                      AND NS.IdEstadoNovedad = NCE.IdEstadoNovedad
                                      AND NS.Comentario LIKE '%Cambió el Estado de%'  --Cambió el Estado de 3 - TRABAJANDO a 8 - ENTREGADO.
                                      AND NS.FechaSeguimiento = NCE.FechaCambioEstado

UPDATE NCE
   SET IdUsuarioAsignado = NS.UsuarioAsignado
  FROM CRMNovedadesCambiosEstados NCE
 INNER JOIN CRMEstadosNovedades NE ON NE.IdEstadoNovedad = NCE.IdEstadoNovedad
 INNER JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = NCE.IdTipoNovedad
                                      AND NS.Letra = NCE.Letra
                                      AND NS.CentroEmisor = NCE.CentroEmisor
                                      AND NS.IdNovedad = NCE.IdNovedad
                                      AND NS.IdSeguimiento = 1
 WHERE NCE.IdUsuarioAsignado IS NULL

UPDATE NCE
   SET IdUsuarioAsignado = NS.UsuarioAsignado
  FROM CRMNovedadesCambiosEstados NCE
 INNER JOIN CRMEstadosNovedades NE ON NE.IdEstadoNovedad = NCE.IdEstadoNovedad
 INNER JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = NCE.IdTipoNovedad
                                      AND NS.Letra = NCE.Letra
                                      AND NS.CentroEmisor = NCE.CentroEmisor
                                      AND NS.IdNovedad = NCE.IdNovedad
                                      AND NS.IdSeguimiento = 2
 WHERE NCE.IdUsuarioAsignado IS NULL

UPDATE NCE
   SET IdUsuarioAsignado = NS.UsuarioAsignado
  FROM CRMNovedadesCambiosEstados NCE
 INNER JOIN CRMEstadosNovedades NE ON NE.IdEstadoNovedad = NCE.IdEstadoNovedad
 INNER JOIN CRMNovedadesSeguimiento NS ON NS.IdTipoNovedad = NCE.IdTipoNovedad
                                      AND NS.Letra = NCE.Letra
                                      AND NS.CentroEmisor = NCE.CentroEmisor
                                      AND NS.IdNovedad = NCE.IdNovedad
                                      AND NS.IdSeguimiento = 3
 WHERE NCE.IdUsuarioAsignado IS NULL


PRINT ''
PRINT '2. Tabla FormatosEtiquetas: Nuevo formato 1 x Ancho (5 x 3 cm)'
DECLARE @maxId INT = (SELECT max(IdFormatoEtiqueta) FROM FormatosEtiquetas)
INSERT INTO [dbo].[FormatosEtiquetas]
           ([IdFormatoEtiqueta],[NombreFormatoEtiqueta],[Tipo],[ArchivoAImprimir],[ArchivoAImprimirEmbebido]
           ,[NombreImpresora],[ImprimeLote],[MaximoColumnas],[UtilizaCabecera],[SolicitaListaPrecios2]
           ,[Activo])
     VALUES
           (@maxId + 1, '1 x Ancho (5 x 3 cm)', 'CODIGOBARRA', 'Eniac.Win.EmisionDeEtiquetasCodBarraF13.rdlc', 1, '', 0, 1, 0, 0, 1)
GO

PRINT ''
PRINT '3. Tabla TablerosControlPaneles: Nuevos tableros Entregas Mensuales Por Estado y Coloborador'
IF dbo.BaseConCUIT('27201734687') = 1 OR dbo.BaseConCUIT('30716345501') = 1
    INSERT INTO TablerosControlPaneles
            (IdTableroControlPanel,NombrePanel,Parametros,IdController)
     VALUES (105, 'Entregas Mensuales Por Estado',              'SERVICE;151,150,161,130;False;9', 'Eniac.Win.GrillaCRMEntregasMensualesPorEstado'),
            (106, 'Entregas Mensuales Por Estado/Colaborador',  'SERVICE;151,150,161,130;True;9',  'Eniac.Win.GrillaCRMEntregasMensualesPorEstado')
GO

PRINT ''
PRINT '4. Tabla Buscadores: Nuevo buscador Reservas'
INSERT INTO [dbo].[Buscadores]
           ([IdBuscador],[Titulo],[AnchoAyuda],[IniciaConFocoEn],[ColumaBusquedaInicial])
     VALUES
           (18, 'ReservasTurismo', 1000, 'Grilla', '')
GO
INSERT INTO [dbo].[BuscadoresCampos]
          ([IdBuscador],[IdBuscadorNombreCampo],[Orden],[Titulo],[Alineacion],[Ancho],[Formato],[Condicion],[Valor],[ColorFila])
     VALUES
           (18, 'NumeroReserva', 1, 'Nro. Reserva', 64, 70, '', NULL, NULL, NULL), 
		   (18, 'IdTipoReserva', 2, 'Tipo de Reserva', 16, 200, '', NULL, NULL, NULL),
		   (18, 'Fecha', 3, 'Fecha', 16, 100, '', NULL, NULL, NULL),
		   (18, 'NombreEstablecimiento', 4, 'Establecimiento', 16, 200, '', NULL, NULL, NULL),
		   (18, 'NombrePrograma', 5, 'Programa', 16, 200, '', NULL, NULL, NULL)
GO
