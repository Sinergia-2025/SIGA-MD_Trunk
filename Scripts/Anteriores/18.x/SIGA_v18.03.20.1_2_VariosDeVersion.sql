
PRINT '1. Funcion Utilidad por Marca: Ajusto Descripcion "Inf. Utilidades por Marca o Rubro".'
GO
UPDATE Funciones
   SET Nombre = 'Inf. Utilidades por Marca o Rubro'
      ,Descripcion = 'Inf. Utilidades por Marca o Rubro'
 WHERE Id = 'InfUtilidadesPorMarca'
GO


PRINT ''
PRINT '2. Creo Menu Ventas\Repartos si tiene las opciones que lo usan y asigno mismos permisos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('OrganizarRepartos','ConsultarRepartos','DespacharMercaderia') )
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('VentasRepartos', 'Repartos', 'Repartos', 'True', 'False', 'True', 'True',
              'Ventas', 470, NULL, NULL, NULL, NULL)
        ;

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'VentasRepartos' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('OrganizarRepartos','ConsultarRepartos','DespacharMercaderia')
        ;

		UPDATE Funciones
		   SET IdPadre = 'VentasRepartos'
		 WHERE Id IN ('OrganizarRepartos','ConsultarRepartos','DespacharMercaderia')
		;
		 
    END;


PRINT ''
PRINT '3. Creo Menu Ventas\Fiscal si tiene las opciones que lo usan y asigno mismos permisos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('LibrodeIvaVentas', 'InfResumenDeVentas', 'CierreZ', 'CierreZReimprimir') )
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('VentasFiscal', 'Fiscal / IVA', 'Fiscal / IVA', 'True', 'False', 'True', 'True',
              'Ventas', 460, NULL, NULL, NULL, NULL)
        ;

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'VentasFiscal' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('LibrodeIvaVentas', 'InfResumenDeVentas', 'CierreZ', 'CierreZReimprimir')
        ;

		UPDATE Funciones
		   SET IdPadre = 'VentasFiscal'
		 WHERE Id IN ('LibrodeIvaVentas', 'InfResumenDeVentas', 'CierreZ', 'CierreZReimprimir')
		;
		 
    END;


PRINT ''
PRINT '4. Creo Menu Ventas\AnularModificarEliminar si tiene las opciones que lo usan y asigno mismos permisos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('ModificarComprobantes', 'ModificarComprobantesDeVentas', 'AnularComprobantes', 'AnularComprobantesSinEmitir', 'EliminarComprobantes', 'EliminarVentas', 'ModificarNumeracionVentas', 'CopiarComprobantes') )
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('VentasAnulModifElim', 'Anular / Modificar / Eliminar', 'Anular / Modificar / Eliminar', 'True', 'False', 'True', 'True',
              'Ventas', 450, NULL, NULL, NULL, NULL)
        ;

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'VentasAnulModifElim' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('ModificarComprobantes', 'ModificarComprobantesDeVentas', 'AnularComprobantes', 'AnularComprobantesSinEmitir', 'EliminarComprobantes', 'EliminarVentas', 'ModificarNumeracionVentas', 'CopiarComprobantes')
        ;

		UPDATE Funciones
		   SET IdPadre = 'VentasAnulModifElim'
		 WHERE Id IN ('ModificarComprobantes', 'ModificarComprobantesDeVentas', 'AnularComprobantes', 'AnularComprobantesSinEmitir', 'EliminarComprobantes', 'EliminarVentas', 'ModificarNumeracionVentas', 'CopiarComprobantes')
		;
		 
    END;


PRINT ''
PRINT '5. Reasigno posiciones a las Funciones Agrupadas.'
GO
   
UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'VentasFiscal' THEN 100 
			WHEN 'VentasRepartos' THEN 110
            WHEN 'VentasAnulModifElim' THEN 450
            WHEN 'ComisionesVendedores' THEN 460
            WHEN 'Kilos' THEN 470
            WHEN 'VentasUtilidades' THEN 480
            ELSE 0 END)
  WHERE Id IN ('VentasFiscal', 'VentasRepartos', 'VentasAnulModifElim', 'ComisionesVendedores', 'Kilos','VentasUtilidades')
GO


PRINT ''
PRINT '5. Reorganizo Menu Ventas\Anular-Modificar-Eliminar.'
GO

UPDATE Funciones SET
   Posicion = 
   (CASE ID WHEN 'AnularComprobantes' THEN 10
			WHEN 'AnularComprobantesSinEmitir' THEN 20
            WHEN 'EliminarComprobantes' THEN 30
            WHEN 'EliminarVentas' THEN 40
            WHEN 'ModificarComprobantes' THEN 50
            WHEN 'ModificarComprobantesDeVentas' THEN 60
            WHEN 'ModificarNumeracionVentas' THEN 70
            WHEN 'CopiarComprobantes' THEN 80
            ELSE 0 END)
  WHERE Id IN ('AnularComprobantes', 'AnularComprobantesSinEmitir', 'EliminarComprobantes', 'EliminarVentas', 'ModificarComprobantes', 'ModificarComprobantesDeVentas', 'ModificarNumeracionVentas','CopiarComprobantes')
GO


PRINT ''
PRINT '6. Creo Menu Archivos\Tipos si tiene las opciones que lo usan y asigno mismos permisos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('TiposAdjuntosABM', 'TiposClientesABM', 'TiposComprobantesABM', 'TiposContactosABM', 'TiposDoc', 'TiposMovimientosABM') )
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ArchivosTipos', 'Tipos de ...', 'Tipos de ...', 'True', 'False', 'True', 'True',
              'Archivos', 175, NULL, NULL, NULL, NULL)
        ;

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'ArchivosTipos' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('TiposAdjuntosABM', 'TiposClientesABM', 'TiposComprobantesABM', 'TiposContactosABM', 'TiposDoc', 'TiposMovimientosABM')
        ;

		UPDATE Funciones
		   SET IdPadre = 'ArchivosTipos'
		 WHERE Id IN ('TiposAdjuntosABM', 'TiposClientesABM', 'TiposComprobantesABM', 'TiposContactosABM', 'TiposDoc', 'TiposMovimientosABM')
		;
		 
    END;



PRINT ''
PRINT '7. Creo Menu Archivos\Auditorias si tiene las opciones que lo usan y asigno mismos permisos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('InfAuditoriaClientes', 'InfAuditoriaProductos') )
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ArchivosAuditorias', 'Auditorias de ...', 'Auditorias de ...', 'True', 'False', 'True', 'True',
              'Archivos', 5, NULL, NULL, NULL, NULL)
        ;

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'ArchivosAuditorias' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('InfAuditoriaClientes', 'InfAuditoriaProductos')
        ;

		UPDATE Funciones
		   SET IdPadre = 'ArchivosAuditorias'
		 WHERE Id IN ('InfAuditoriaClientes', 'InfAuditoriaProductos')
		;
		 
    END;
    

PRINT '8. Inactivo funciones Consulta para Proveedores y Transportista (pocos practicas y antigüas).'
GO

UPDATE Funciones
   SET [Enabled] = 'False' 
      ,Visible = 'False'
 WHERE Id IN ('ProveedoresConsultas', 'TransportistasConsultas')
GO

    
PRINT ''
PRINT '9. Creo Menu Archivos\Actualizaciones Masivas si tiene las opciones que lo usan y asigno mismos permisos.'
GO

IF EXISTS (SELECT 1 FROM Funciones WHERE Id IN ('ClientesActualizacionMasiva', 'ProductosActualizacionMasiva','ProductosBajaMasiva') )
    BEGIN
        --Inserto la pantalla nueva
        INSERT INTO Funciones
             (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
             ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros)
          VALUES
             ('ArchivosActualiazMasivas', 'Actualizaciones Masivas de ...', 'Actualizaciones Masivas de ...', 'True', 'False', 'True', 'True',
              'Archivos', 3, NULL, NULL, NULL, NULL)
        ;

        INSERT INTO RolesFunciones 
              (IdRol,IdFuncion)
        SELECT DISTINCT IdRol, 'ArchivosActualiazMasivas' AS Pantalla FROM dbo.RolesFunciones
            WHERE IdFuncion IN ('ClientesActualizacionMasiva', 'ProductosActualizacionMasiva','ProductosBajaMasiva')
        ;

		UPDATE Funciones
		   SET IdPadre = 'ArchivosActualiazMasivas'
		 WHERE Id IN ('ClientesActualizacionMasiva', 'ProductosActualizacionMasiva','ProductosBajaMasiva')
		;
		 
    END;
    
