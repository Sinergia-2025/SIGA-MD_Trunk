
PRINT ''
PRINT '1. Tabla TiposComprobantes: Ajusto la descripcion Provisorio.'
GO

UPDATE TiposComprobantes
   SET Descripcion = REPLACE(Descripcion, 'Provisiorio', 'Provisorio')
 WHERE Descripcion LIKE '%Provisiorio%'
GO


PRINT ''
PRINT '2. Tabla Parametros: Agrego Parametros para Web Movil Pedidos.'
GO

MERGE INTO Parametros AS P
	 USING (SELECT 'PEDIDOSURLWEBGET' AS IdParametro ,'http://sinergia-pc-04/WebMovil/api/PedidosPendientes' ValorParametro ,'PedidosWEB' AS CategoriaParametro ,'URL Web Pedidos' AS DescripcionParametro UNION
            SELECT 'PEDIDOSURLWEBPUT' AS IdParametro ,'http://sinergia-pc-04/WebMovil/api/Pedidos' ValorParametro ,'PedidosWEB' AS CategoriaParametro ,'URL Web Pedidos' AS DescripcionParametro UNION
            SELECT 'PEDIDOSWEBFORMATO' AS IdParametro ,'SiMovilPedidos' ValorParametro ,'PedidosWEB' AS CategoriaParametro ,'Formato Web Pedidos' AS DescripcionParametro) AS PT
		ON P.IdParametro = PT.IdParametro
 WHEN MATCHED THEN
	UPDATE
	   SET P.ValorParametro = PT.ValorParametro
          ,P.CategoriaParametro = PT.CategoriaParametro
 WHEN NOT MATCHED THEN
	INSERT (   IdParametro,    ValorParametro,    CategoriaParametro,    DescripcionParametro)
	VALUES (PT.IdParametro, PT.ValorParametro, PT.CategoriaParametro, PT.DescripcionParametro)
;


PRINT ''
PRINT '3. Tablas Usuarios y TiposComprobantes: Agrego Campo NivelAutorizacion.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Usuarios ADD NivelAutorizacion smallint NULL
GO
UPDATE Usuarios SET NivelAutorizacion = 1;
ALTER TABLE dbo.Usuarios ALTER COLUMN NivelAutorizacion smallint NOT NULL
GO
ALTER TABLE dbo.Usuarios SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.TiposComprobantes ADD NivelAutorizacion smallint NULL
GO
UPDATE TiposComprobantes SET NivelAutorizacion = 1;
ALTER TABLE dbo.TiposComprobantes ALTER COLUMN NivelAutorizacion smallint NOT NULL
GO
ALTER TABLE dbo.TiposComprobantes SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Empleados ADD NivelAutorizacion smallint NULL
GO
UPDATE Empleados SET NivelAutorizacion = 1;
ALTER TABLE dbo.Empleados ALTER COLUMN NivelAutorizacion smallint NOT NULL
GO
ALTER TABLE dbo.Empleados SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '4.1. Tablas MovilRutas: Creo un Transportista si no tienen registros.'
GO

IF NOT EXISTS (SELECT TOP(1) IdTransportista FROM Transportistas)
    BEGIN

		INSERT INTO Transportistas
				   (IdTransportista, NombreTransportista, DireccionTransportista, IdLocalidadTransportista
				   ,TelefonoTransportista, IdCategoriaFiscalTransportista, CuitTransportista, Observacion)
		SELECT 1, 'VEHÍCULO PROPIO/CAMIONETA', '.', IdLocalidad 
			  , '', 1, null, ''
		  FROM Sucursales WHERE EstoyAca = 'True'
		;

    END;


PRINT ''
PRINT '4.2. Tablas MovilRutas: Agrego Campos Vendedor y Transportista.'
GO

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.MovilRutas ADD TipoDocVendedor varchar(5) NULL
ALTER TABLE dbo.MovilRutas ADD NroDocVendedor varchar(12) NULL
ALTER TABLE dbo.MovilRutas ADD IdTransportista int NULL
GO

UPDATE MovilRutas
   SET TipoDocVendedor = E.TipoDocEmpleado
      ,NroDocVendedor = E.NroDocEmpleado
      ,IdTransportista = T.IdTransportista
  FROM MovilRutas
 CROSS JOIN (SELECT TOP 1 * FROM Empleados ORDER BY TipoDocEmpleado, NroDocEmpleado) E
 CROSS JOIN (SELECT TOP 1 * FROM Transportistas ORDER BY IdTransportista) T

ALTER TABLE dbo.MovilRutas ALTER COLUMN TipoDocVendedor varchar(5) NOT NULL
ALTER TABLE dbo.MovilRutas ALTER COLUMN NroDocVendedor varchar(12) NOT NULL
ALTER TABLE dbo.MovilRutas ALTER COLUMN IdTransportista int NOT NULL
GO

ALTER TABLE dbo.MovilRutas ADD CONSTRAINT FK_MovilRutas_Empleados
    FOREIGN KEY (TipoDocVendedor,NroDocVendedor)
    REFERENCES dbo.Empleados (TipoDocEmpleado,NroDocEmpleado)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO
ALTER TABLE dbo.MovilRutas ADD CONSTRAINT FK_MovilRutas_Transportistas
    FOREIGN KEY (IdTransportista)
    REFERENCES dbo.Transportistas (IdTransportista)
    ON UPDATE  NO ACTION ON DELETE  NO ACTION 
GO

ALTER TABLE dbo.MovilRutas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT


PRINT ''
PRINT '5. Tablas Funciones: Creo/Actualiza PreventaV3.'
GO

IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'PreventaV2')
BEGIN
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
         SELECT 'PreventaV3', 'Preventa (v3)', 'Preventa (v3)', EsMenu, EsBoton, [Enabled], Visible,
                IdPadre, Posicion, Archivo, 'PreventaV3', Icono, Parametros
           FROM Funciones
          WHERE Id = 'PreventaV2'
    ;

    UPDATE RolesFunciones SET IdFuncion = 'PreventaV3' WHERE IdFuncion = 'PreventaV2';

    UPDATE Bitacora SET IdFuncion = 'PreventaV3' WHERE IdFuncion = 'PreventaV2';

    DELETE Funciones WHERE Id = 'PreventaV2';
END
ELSE
BEGIN
    -- Si tiene el menu de Pedidos y es el CUIT de Generico/TUMINI

    IF EXISTS (SELECT * FROM Funciones F
                INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
                WHERE F.Id = 'Pedidos')
      AND EXISTS (SELECT ValorParametro FROM Parametros P WHERE P.IdParametro = 'CUITEMPRESA' 
                    AND P.ValorParametro IN ('50000000024', '20332782313'))
    BEGIN
      
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
             IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('PreventaV3', 'Preventa (v3)', 'Preventa (v3)', 'True', 'False', 'True', 'True', 
              'Pedidos', 120, 'Eniac.Win', 'PreventaV3', NULL, NULL)
        ;

        INSERT INTO RolesFunciones (IdRol, IdFuncion)
        SELECT DISTINCT Id AS Rol, 'PreventaV3' AS Pantalla FROM Roles
            WHERE Id IN ('Adm', 'Supervidor', 'Oficina');
    END
END
