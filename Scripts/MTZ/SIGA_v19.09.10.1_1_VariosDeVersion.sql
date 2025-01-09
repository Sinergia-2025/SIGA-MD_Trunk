PRINT ''
PRINT '1. Migrador Metalsur'
IF dbo.BaseConCuit('33631312379') = 'True'     --SOLO METALSUR
BEGIN

    PRINT ''
    PRINT '1.1. Migrador Metalsur: INSERT INTO [dbo].[CalidadListasControlProductosItems]'
    INSERT INTO [dbo].[CalidadListasControlProductosItems]
               ([IdProducto]
               ,[IdListaControl]
               ,[Item]
               ,[IdListaControlItem]
               ,[Ok]
               ,[NoOk]
               ,[Obs]
               ,[Mat]
               ,[NA]
               ,[Observ]
               ,[Orden]
               ,[Usuario]
               ,[FechaMod]  
		        ,[OkCalidad]
               ,[NoOkCalidad]
               ,[ObsCalidad]
               ,[MatCalidad]
               ,[NACalidad]
               ,[ObservCalidad]
               ,[UsuarioCalidad]
               ,[FechaModCalidad])
      SELECT [ProductID]
          ,[ChekListID]
          ,M.[Item]
          ,[ChekListIDItemID]
	      ,CASE WHEN [Estado] = 1 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 2 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 3 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 4 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 5 THEN 'True' ELSE 'False' END 
	      ,[Observ]
          ,M.[Orden]
          ,[Usuario]
          ,[FechaMod], 'False','False','False','False','False', null, null,null
      FROM IGC.[dbo].[IGC_CheckListsProdDet] M
        INNER JOIN Productos P ON P.IdProducto = M.ProductID COLLATE Modern_Spanish_100_CI_AS
	    INNER JOIN CalidadListasControlConfig CLCC ON CLCC.IdListaControl = M.ChekListID
	    AND CLCC.Item = M.Item


    PRINT ''
    PRINT '1.2. Migrador Metalsur: INSERT INTO [dbo].[AuditoriaCalidadListasControlProductosItems]'
    INSERT INTO [dbo].[AuditoriaCalidadListasControlProductosItems]
               ([FechaAuditoria]
               ,[OperacionAuditoria]
               ,[UsuarioAuditoria]
               ,[IdProducto]
               ,[IdListaControl]
               ,[Item]
               ,[IdListaControlItem]
               ,[Ok]
               ,[NoOk]
               ,[Obs]
               ,[Mat]
               ,[NA]
               ,[Observ]
               ,[Orden]
               ,[Usuario]
               ,[FechaMod]   
		        ,[OkCalidad]
               ,[NoOkCalidad]
               ,[ObsCalidad]
               ,[MatCalidad]
               ,[NACalidad]
               ,[ObservCalidad]
               ,[UsuarioCalidad]
               ,[FechaModCalidad])
    SELECT [FechaMod]
    ,CASE WHEN [Operacion] = 'ALTA' THEN 'A' ELSE CASE WHEN [Operacion] = 'BAJA' THEN 'B' ELSE CASE WHEN [Operacion] = 'MODIFICACION' THEN 'M' ELSE '' END END END
    ,substring(M.[Usuario],1,10)
		    ,[ProductID]
          ,[ChekListID]
          ,M.[Item]
          ,[ChekListIDItemID]
	      ,CASE WHEN [Estado] = 1 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 2 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 3 THEN 'True' ELSE 'False' END 
	      ,CASE WHEN [Estado] = 4 THEN 'True' ELSE 'False' END 
          ,CASE WHEN [Estado] = 5 THEN 'True' ELSE 'False' END 
	      ,[Observ]
          ,M.[Orden]
     	     ,substring(M.[Usuario],1,10)
		    ,[FechaMod], 'False','False','False','False','False', null, null,null
       FROM IGC.[dbo].[IGC_CheckListsProdDet_LOG] M
       INNER JOIN Productos P ON P.IdProducto = M.ProductID COLLATE Modern_Spanish_100_CI_AS
	    INNER JOIN CalidadListasControlProductos CLCP ON CLCP.IdListaControl = M.ChekListID
	    AND CLCP.IdProducto = M.ProductID  COLLATE Modern_Spanish_100_CI_AS


    PRINT ''
    PRINT '1.3. Migrador Metalsur: INSERT INTO [dbo].[ProductosLinks]'
    INSERT INTO [dbo].[ProductosLinks]
               ([IdProducto]
               ,[ItemLink]
               ,[Descripcion]
               ,[Link])
     SELECT [ProductID]
          ,[ItemLink]
          ,[Descripcion]
          ,[Link]
      FROM IGC.[dbo].[IGC_ProductoLinks] M


    PRINT ''
    PRINT '1.4. Migrador Metalsur: Actualizar CalidadListasControlProductos.IdEstadoCalidad'
    UPDATE  LCP SET  LCP.IdEstadoCalidad = 4
    FROM CalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado = 1

    PRINT ''
    PRINT '1.5. Migrador Metalsur: Cambia a Terminado si no esta Entregado pero tiene ok de Calidad'
    UPDATE  LCP SET  LCP.IdEstadoCalidad = 4
    FROM CalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado = 0
    AND LCP.CincoSC = 'Ok'

    PRINT ''
    PRINT '1.6. Migrador Metalsur: Cambia a en proceso si no esta Entregado, no tiene ok de calidad y tiene algun check'
    UPDATE  LCP SET  LCP.IdEstadoCalidad = 2
    FROM CalidadListasControlProductos LCP
    INNER JOIN  CalidadListasControlProductosItems LCPI ON LCPI.IdProducto = LCP.IdProducto 
    INNER JOIN Productos P On LCP.IdProducto = P.IdProducto
    AND LCPI.IdListaControl = LCP.IdListaControl
    WHERE P.CalidadStatusEntregado <> 1
    AND LCP.CincoSC <> 'Ok' AND (LCPI.Ok = 'True' OR LCPI.NoOk = 'True' OR LCPI.Obs = 'True' OR LCPI.Mat = 'True')

END

PRINT ''
PRINT '2. Tabla CalidadListasControlProductosItems: DROP  CONSTRAINT [FK_CalidadListasControlProductosItems_CalidadListasControlConfig]'
ALTER TABLE CalidadListasControlProductosItems DROP  CONSTRAINT [FK_CalidadListasControlProductosItems_CalidadListasControlConfig]




PRINT ''
PRINT '3. Tabla CalidadListasControlConfigLinks: DROP  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlConfig]'
ALTER TABLE CalidadListasControlConfigLinks DROP CONSTRAINT FK_CalidadListasControlConfigLinks_CalidadListasControlConfig
GO

PRINT ''
PRINT '3.1. Tabla CalidadListasControlConfigLinks: ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlConfig]'
ALTER TABLE [dbo].[CalidadListasControlConfigLinks]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControl] FOREIGN KEY([IdListaControl])
REFERENCES [dbo].[CalidadListasControl] ([IdListaControl])
GO
ALTER TABLE [dbo].[CalidadListasControlConfigLinks] CHECK CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControl]
GO

PRINT ''
PRINT '4. Tabla CalidadListasControlConfigLinks: ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlItems]'
ALTER TABLE [dbo].[CalidadListasControlConfigLinks]  WITH CHECK ADD  CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlItems] FOREIGN KEY([Item])
REFERENCES [dbo].[CalidadListasControlItems] ([IdListaControlItem])
GO
ALTER TABLE [dbo].[CalidadListasControlConfigLinks] CHECK CONSTRAINT [FK_CalidadListasControlConfigLinks_CalidadListasControlItems]
GO


PRINT ''
PRINT '5. Tabla CalidadListasControl: Nuevas Columnas ControlaProduccion, ControlaCalidad, Controla5SProduccion, Controla5SCalidad y InicioAutomatico'
ALTER TABLE CalidadListasControl ADD ControlaProduccion bit null
ALTER TABLE CalidadListasControl ADD ControlaCalidad bit null
ALTER TABLE CalidadListasControl ADD Controla5SProduccion bit null
ALTER TABLE CalidadListasControl ADD Controla5SCalidad bit null
ALTER TABLE CalidadListasControl ADD InicioAutomatico bit null
GO

PRINT ''
PRINT '5.1. Tabla CalidadListasControl: Valores por defecto para ControlaProduccion, ControlaCalidad, Controla5SProduccion, Controla5SCalidad y InicioAutomatico'
UPDATE CalidadListasControl
   SET ControlaProduccion = 'True', 
       ControlaCalidad = 'False',
       Controla5SProduccion = 'False', 
       Controla5SCalidad = 'False',
       InicioAutomatico = 'False'
GO

PRINT ''
PRINT '5.2. Tabla CalidadListasControl: NOT NULL para ControlaProduccion, ControlaCalidad, Controla5SProduccion, Controla5SCalidad y InicioAutomatico'
ALTER TABLE CalidadListasControl ALTER COLUMN ControlaProduccion bit not null
ALTER TABLE CalidadListasControl ALTER COLUMN ControlaCalidad bit not null
ALTER TABLE CalidadListasControl ALTER COLUMN Controla5SProduccion bit not null
ALTER TABLE CalidadListasControl ALTER COLUMN Controla5SCalidad bit not null
ALTER TABLE CalidadListasControl ALTER COLUMN InicioAutomatico bit not null
GO
