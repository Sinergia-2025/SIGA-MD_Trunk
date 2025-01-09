
BEGIN TRANSACTION
IF dbo.ExisteFuncion('ProdCalidadABM_AltaRepSinProd') = 0 AND dbo.ExisteFuncion('ProductosCalidadABM') = 1
--Inserto la Pantalla Nueva
BEGIN
    PRINT ''
    PRINT '1.1. Insertar funcion'
	INSERT INTO Funciones
	   (Id, Nombre, Descripcion
	   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,PV,Plus,Express,Basica, EsMDIChild)
	 VALUES
	   ('ProdCalidadABM_AltaRepSinProd', 'Productos Calidad: Alta Reparación sin Producto', 'Productos Calidad: Alta Reparación sin Producto', 
		'False', 'False', 'True', 'True', 'ProductosCalidadABM',888, 'Eniac.Win', 'ProdCalidadABM_AltaRepSinProd', null, null,'N','S','N','N', 'True')
	END;
	COMMIT
GO



PRINT ''
PRINT '. Tabla CalidadListasControlTipos: Agregar nuevo campo LeadTimeMenosDe'
ALTER TABLE CalidadListasControlTipos ADD LeadTimeMenosDe decimal(12,2) null
GO

ALTER TABLE CalidadListasControlTipos ADD DiasLeadTimeMenosDe bit null
GO
UPDATE CalidadListasControlTipos SET DiasLeadTimeMenosDe = 'False'
GO
ALTER TABLE CalidadListasControlTipos ALTER COLUMN DiasLeadTimeMenosDe bit not null
GO

ALTER TABLE CalidadListasControlTipos ADD HorasLeadTimeMenosDe bit null
GO
UPDATE CalidadListasControlTipos SET HorasLeadTimeMenosDe = 'False'
GO
ALTER TABLE CalidadListasControlTipos ALTER COLUMN HorasLeadTimeMenosDe bit not null
GO

PRINT ''
PRINT '. Tabla CalidadListasControlTipos: Agregar nuevo campo LeadTimeMasDe'
ALTER TABLE CalidadListasControlTipos ADD LeadTimeMasDe decimal(12,2) null
GO

ALTER TABLE CalidadListasControlTipos ADD DiasLeadTimeMasDe bit null
GO
UPDATE CalidadListasControlTipos SET DiasLeadTimeMasDe = 'False'
GO
ALTER TABLE CalidadListasControlTipos ALTER COLUMN DiasLeadTimeMasDe bit not null
GO

ALTER TABLE CalidadListasControlTipos ADD HorasLeadTimeMasDe bit null
GO
UPDATE CalidadListasControlTipos SET HorasLeadTimeMasDe = 'False'
GO
ALTER TABLE CalidadListasControlTipos ALTER COLUMN HorasLeadTimeMasDe bit not null
GO

ALTER TABLE dbo.TablerosControlPaneles ADD BackColor1 int NULL
ALTER TABLE dbo.TablerosControlPaneles ADD ForeColor1 int NULL
ALTER TABLE dbo.TablerosControlPaneles ADD BackColor2 int NULL
ALTER TABLE dbo.TablerosControlPaneles ADD ForeColor2 int NULL

ALTER TABLE dbo.SituacionCheques ADD PorDefecto bit NULL
GO

UPDATE SituacionCheques SET PorDefecto = 0;

ALTER TABLE dbo.SituacionCheques ALTER COLUMN PorDefecto bit NOT NULL
GO

IF NOT EXISTS (SELECT * FROM SituacionCheques)
BEGIN
    INSERT INTO [dbo].[SituacionCheques]
               ([IdSituacionCheque], [NombreSituacionCheque], [PorDefecto])
        VALUES (1, 'NORMAL', 'True')
END

UPDATE Funciones
   SET Pantalla = 'SituacionChequesABM'
 WHERE Id = 'SituacionChequesABM'