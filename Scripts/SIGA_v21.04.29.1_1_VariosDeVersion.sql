
PRINT ''
PRINT '1. Tabla Funciones: Agrego campo EsMDIChild'

ALTER TABLE Funciones ADD EsMDIChild bit null
GO
UPDATE Funciones SET EsMDIChild = 'True'
GO
ALTER TABLE Funciones ALTER COLUMN EsMDIChild bit not null
GO


PRINT ''
PRINT '2. Tabla productos: FK CalidadProductosTiposServicios y CalidadProductosModelos'

ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_CalidadProductosTiposServicios] FOREIGN KEY([IdProductoTipoServicio])
REFERENCES [dbo].[CalidadProductosTiposServicios] ([IdProductoTipoServicio])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_CalidadProductosTiposServicios]
GO


ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK_Productos_CalidadProductosModelos] FOREIGN KEY([IdProductoModelo])
REFERENCES [dbo].[CalidadProductosModelos] ([IdProductoModelo])
GO

ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK_Productos_CalidadProductosModelos]
GO


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	
	PRINT ''
    PRINT '3. Nueva función menú Calidad: Panel de Control Planta'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
      VALUES
	   ('PanelDeControlPorTipoPlanta', 'Panel de Control Planta', 'Panel de Control Planta', 'True', 'False', 'True', 'True'
        ,'Calidad', 26, 'Eniac.Win', 'PanelDeControlPorTipoPlanta', NULL, 'ocultarfiltros'
        ,'True', 'S', 'N', 'N', 'N', 'False')
         
  
END


IF dbo.BaseConCuit('33631312379') = 1 OR dbo.SoyHAR() = 1
BEGIN
	
	PRINT ''
    PRINT '1. Nueva función menú Calidad: Informe de Chasis'
    INSERT INTO [dbo].Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV, EsMDIChild)
      VALUES
	   ('InformeDeChasis', 'Informe de Chasis', 'Informe de Chasis', 'True', 'False', 'True', 'True'
        ,'Calidad', 27, 'Eniac.Win', 'InformeDeChasis', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
       
 END