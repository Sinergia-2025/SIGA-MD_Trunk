PRINT ''
PRINT '1. Tabla CalidadListasControl: Nueva columna DiasMaximoProceso'
ALTER TABLE CalidadListasControl ADD DiasMaximoProceso int null
GO



PRINT ''
PRINT '2. Ajustar opciones de menu de Calidad Metalsur'
UPDATE Funciones SET Nombre = 'Ejecución de Listas de Control por Productos', 
					Descripcion = 'Ejecución de Listas de Control por Productos',
					Posicion = 10
					WHERE Id = 'ListasControlProductos'

UPDATE Funciones SET Nombre = 'Panel de Control', 
					Descripcion = 'Panel de Control',
					Posicion = 20
					WHERE Id = 'PanelDeControl'

UPDATE Funciones SET Nombre = 'Informe de Listas de Control por Productos', 
					Descripcion = 'Informe de Listas de Control por Productos',
					Posicion = 30
					WHERE Id = 'InformeListasControl'

UPDATE Funciones SET Nombre = 'Informe de Items de Listas de Control', 
					Descripcion = 'Informe de Items de Listas de Control',
					Posicion = 40
					WHERE Id = 'InformeListasControlPendientes'

UPDATE Funciones SET Nombre = 'Asignar Listas de Control a Productos', 
					Descripcion = 'Asignar Listas de Control a Productos',
					Posicion = 50
					WHERE Id = 'ProductosListasControl'

UPDATE Funciones SET Nombre = 'Asignar Roles a Listas de Control', 
					Descripcion = 'Asignar Roles a Listas de Control',
					Posicion = 60
					WHERE Id = 'ListasControlRoles'

UPDATE Funciones SET Nombre = 'ABM de Items de Listas de Control', 
					Descripcion = 'ABM de Items de Listas de Control',
					Posicion = 70
					WHERE Id = 'ListasControlItemsABM'

UPDATE Funciones SET Nombre = 'ABM de Listas de Control', 
					Descripcion = 'ABM de Listas de Control',
					Posicion = 80
					WHERE Id = 'ListasControlABM'

UPDATE Funciones SET Nombre = 'ABM de Grupos de Items de Listas de Control', 
					Descripcion = 'ABM de Grupos de Items de Listas de Control',
					Posicion = 90
					WHERE Id = 'GruposListasControlItemsABM'

UPDATE Funciones SET Nombre = 'ABM de SubGrupos de Items de Listas de Control', 
					Descripcion = 'ABM de SubGrupos de Items de Listas de Control',
					Posicion = 100
					WHERE Id = 'SubGruposListasControlItemsABM'

UPDATE Funciones SET Nombre = 'ABM de Estados de Listas de Control', 
					Descripcion = 'ABM de Estados de Listas de Control',
					Posicion = 110
					WHERE Id = 'EstadosListasControlABM'

UPDATE Funciones SET Nombre = 'ABM de Plantillas de Listas de Control', 
					Descripcion = 'ABM de Plantillas de Listas de Control',
					Posicion = 120
					WHERE Id = 'PlantillasCalidadABM'

PRINT ''
PRINT '3. Cambiar colores de los estados de Calidad'
UPDATE CalidadEstadosListasControl SET Color = -32126 WHERE IdEstadoCalidad = 1
UPDATE CalidadEstadosListasControl SET Color = -107  WHERE IdEstadoCalidad = 2
UPDATE CalidadEstadosListasControl SET Color = -5308498 WHERE IdEstadoCalidad = 4
GO


PRINT ''
PRINT '4. Tabla CalidadListasControlProductos: Nuevo campo Observacion'
ALTER TABLE CalidadListasControlProductos ADD Observacion varchar(1000) null
PRINT ''
PRINT '5. Tabla AuditoriaCalidadListasControlProductos: Nuevo campo Observacion'
ALTER TABLE AuditoriaCalidadListasControlProductos ADD Observacion varchar(1000) null
GO
