
PRINT '1. Nuevo Menu: Fichas\Importar Fichas.'
GO

DECLARE @idPadre varchar(MAX)
DECLARE @posicion int
SELECT @idPadre = IdPadre, @posicion = Posicion FROM Funciones WHERE Id = 'FichasABM2';
-- Si tiene el menu de CRM

IF @idPadre IS NOT NULL
BEGIN

    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('ImportarFichas', 'Importar Fichas desde Excel', 'Importar Fichas desde Excel', 'True', 'False', 'True', 'True', 
          @idPadre, @posicion + 5, 'Eniac.Win', 'ImportarFichas', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ImportarFichas' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;

 END


PRINT ''
PRINT '2. Nuevo Menu: Precios\ActualizarDescuentosClientes.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'Precios')
     
    INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
      VALUES
         ('ActualizarDescuentosClientes', 'Clientes - Asignación de Descuentos por Productos (Masivo)', 'Clientes - Asignación de Descuentos por Productos (Masivo)', 'True', 'False', 'True', 'True', 
          'Precios', 130, 'Eniac.Win', 'ActualizarDescuentosClientes', NULL, NULL)
    ;

    INSERT INTO RolesFunciones (IdRol, IdFuncion)
    SELECT DISTINCT Id AS Rol, 'ActualizarDescuentosClientes' AS Pantalla FROM Roles
        WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
    ;

GO


PRINT ''
PRINT '3. Tabla CRMEstadosNovedades: Ajustar Datos de Posicion x 10.'
GO

UPDATE CRMEstadosNovedades
   SET Posicion = Posicion * 10
GO


PRINT ''
PRINT '4. Fichas.'
GO

PRINT ''
PRINT '4.1. Tabla TiposComprobantes: Ajusto Seteos de Fichas.'
GO

UPDATE TiposComprobantes
   SET EsFacturable = 'True'
     , IdTipoComprobanteContraMovInvocar = 'NCFICHAS'
 WHERE IdTipoComprobante = 'FICHAS'
GO

PRINT ''
PRINT '4.2. Tabla TiposComprobantes: Ajusto Seteos de NC Fichas.'
GO

UPDATE TiposComprobantes
   SET EsFacturable = 'False'
 WHERE IdTipoComprobante = 'NCFICHAS'
GO

PRINT ''
PRINT '5. Tabla Impresoras: Agrego NC Fichas si usa Fichas.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id = 'FichasABM2')
		UPDATE Impresoras 
		   SET ComprobantesHabilitados = ComprobantesHabilitados + ',NCFICHAS'
		 WHERE IdImpresora = 'NORMAL'
		   AND IdSucursal = 1
		;
GO

PRINT ''
PRINT '6. Tabla TiposAdjuntos: Insertar Datos.'
GO

INSERT INTO TiposAdjuntos
    (IdTipoAdjunto, NombreTipoAdjunto)
 VALUES    
    (1, 'DNI'),
    (2, 'Firma'),
    (3, 'Pagare'),
    (4, 'Contrato'),
    (5, 'Impuesto'),
    (6, 'Servicio')
GO
