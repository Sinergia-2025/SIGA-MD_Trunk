IF dbo.ExisteCampo('Clientes', 'PublicarEnGestion') = 0
BEGIN
    ALTER TABLE Clientes ADD PublicarEnGestion	bit	null
	ALTER TABLE Clientes ADD PublicarEnEmpresarial	bit	null
 	ALTER TABLE Clientes ADD PublicarEnTiendaNube	bit	null
    ALTER TABLE Clientes ADD PublicarEnMercadoLibre	bit	null
	ALTER TABLE Clientes ADD PublicarEnArborea	bit	null
    ALTER TABLE Clientes ADD PublicarEnSincronizacionSucursal	bit	null

    ALTER TABLE AuditoriaClientes ADD PublicarEnGestion	bit	null
	ALTER TABLE AuditoriaClientes ADD PublicarEnEmpresarial	bit	null
 	ALTER TABLE AuditoriaClientes ADD PublicarEnTiendaNube	bit	null
    ALTER TABLE AuditoriaClientes ADD PublicarEnMercadoLibre	bit	null
	ALTER TABLE AuditoriaClientes ADD PublicarEnArborea	bit	null
    ALTER TABLE AuditoriaClientes ADD PublicarEnSincronizacionSucursal	bit	null
	
    ALTER TABLE Prospectos ADD PublicarEnGestion	bit	null
	ALTER TABLE Prospectos ADD PublicarEnEmpresarial	bit	null
 	ALTER TABLE Prospectos ADD PublicarEnTiendaNube	bit	null
    ALTER TABLE Prospectos ADD PublicarEnMercadoLibre	bit	null
	ALTER TABLE Prospectos ADD PublicarEnArborea	bit	null
    ALTER TABLE Prospectos ADD PublicarEnSincronizacionSucursal	bit	null
    
    ALTER TABLE AuditoriaProspectos ADD PublicarEnGestion	bit	null
	ALTER TABLE AuditoriaProspectos ADD PublicarEnEmpresarial	bit	null
 	ALTER TABLE AuditoriaProspectos ADD PublicarEnTiendaNube	bit	null
    ALTER TABLE AuditoriaProspectos ADD PublicarEnMercadoLibre	bit	null
	ALTER TABLE AuditoriaProspectos ADD PublicarEnArborea	bit	null
    ALTER TABLE AuditoriaProspectos ADD PublicarEnSincronizacionSucursal	bit	null

END
GO
UPDATE Clientes SET PublicarEnGestion = 'False'
					,PublicarEnEmpresarial	= 'False'
					,  PublicarEnTiendaNube	= 'False'
					,  PublicarEnMercadoLibre	= 'False'
					,  PublicarEnArborea	= 'False' 
					,  PublicarEnSincronizacionSucursal = 'False'
GO

UPDATE AuditoriaClientes SET PublicarEnGestion = 'False'
					,PublicarEnEmpresarial	= 'False'
					,  PublicarEnTiendaNube	= 'False'
					,  PublicarEnMercadoLibre	= 'False'
					,  PublicarEnArborea	= 'False' 
					,  PublicarEnSincronizacionSucursal = 'False'
GO

UPDATE Prospectos SET PublicarEnGestion = 'False'
					,PublicarEnEmpresarial	= 'False'
					,  PublicarEnTiendaNube	= 'False'
					,  PublicarEnMercadoLibre	= 'False'
					,  PublicarEnArborea	= 'False' 
					,  PublicarEnSincronizacionSucursal = 'False'
GO


UPDATE AuditoriaProspectos SET PublicarEnGestion = 'False'
					,PublicarEnEmpresarial	= 'False'
					,  PublicarEnTiendaNube	= 'False'
					,  PublicarEnMercadoLibre	= 'False'
					,  PublicarEnArborea	= 'False' 
					,  PublicarEnSincronizacionSucursal = 'False'
GO

    ALTER TABLE Clientes  ALTER COLUMN PublicarEnGestion	bit not	null
	GO
	ALTER TABLE Clientes  ALTER COLUMN PublicarEnEmpresarial	bit not	null
	GO
 	ALTER TABLE Clientes  ALTER COLUMN PublicarEnTiendaNube	bit not	null
	GO
    ALTER TABLE Clientes  ALTER COLUMN PublicarEnMercadoLibre	bit not	null
	GO
	ALTER TABLE Clientes  ALTER COLUMN PublicarEnArborea	bit not	null
	GO
    ALTER TABLE Clientes  ALTER COLUMN PublicarEnSincronizacionSucursal	bit not	null
	GO

    ALTER TABLE AuditoriaClientes  ALTER COLUMN PublicarEnGestion	bit not	null
	GO		
	ALTER TABLE AuditoriaClientes  ALTER COLUMN PublicarEnEmpresarial	bit not	null
	GO			
 	ALTER TABLE AuditoriaClientes  ALTER COLUMN PublicarEnTiendaNube	bit not	null
	GO			
    ALTER TABLE AuditoriaClientes  ALTER COLUMN PublicarEnMercadoLibre	bit not	null
	GO			
	ALTER TABLE AuditoriaClientes  ALTER COLUMN PublicarEnArborea	bit not	null
	GO			
    ALTER TABLE AuditoriaClientes  ALTER COLUMN PublicarEnSincronizacionSucursal	bit not	null
	GO

	
    ALTER TABLE Prospectos  ALTER COLUMN PublicarEnGestion	bit not	null
	GO
	ALTER TABLE Prospectos  ALTER COLUMN PublicarEnEmpresarial	bit not	null
	GO
 	ALTER TABLE Prospectos  ALTER COLUMN PublicarEnTiendaNube	bit not	null
	GO
    ALTER TABLE Prospectos  ALTER COLUMN PublicarEnMercadoLibre	bit not	null
	GO
	ALTER TABLE Prospectos  ALTER COLUMN PublicarEnArborea	bit	not null
	GO
    ALTER TABLE Prospectos  ALTER COLUMN PublicarEnSincronizacionSucursal	bit not	null
	GO

	ALTER TABLE AuditoriaProspectos  ALTER COLUMN PublicarEnGestion	bit not	null
	GO		
	ALTER TABLE AuditoriaProspectos  ALTER COLUMN PublicarEnEmpresarial	bit not	null
	GO			
 	ALTER TABLE AuditoriaProspectos  ALTER COLUMN PublicarEnTiendaNube	bit not	null
	GO	
    ALTER TABLE AuditoriaProspectos  ALTER COLUMN PublicarEnMercadoLibre	bit not	null
	GO			
	ALTER TABLE AuditoriaProspectos  ALTER COLUMN PublicarEnArborea	bit	not null
	GO			
    ALTER TABLE AuditoriaProspectos  ALTER COLUMN PublicarEnSincronizacionSucursal	bit not	null
	GO

UPDATE Clientes SET PublicarEnGestion = 'True'
					,PublicarEnEmpresarial	= 'True'
					,  PublicarEnTiendaNube	= 'True'
					,  PublicarEnMercadoLibre	= 'True'
					,  PublicarEnArborea	= 'True' 
					,  PublicarEnSincronizacionSucursal = 'True' WHERE publicarenWeb = 'True'
GO

UPDATE AuditoriaClientes SET PublicarEnGestion = 'True'
					,PublicarEnEmpresarial	= 'True'
					,  PublicarEnTiendaNube	= 'True'
					,  PublicarEnMercadoLibre	= 'True'
					,  PublicarEnArborea	= 'True' 
					,  PublicarEnSincronizacionSucursal = 'True' WHERE publicarenWeb = 'True'
GO

UPDATE Prospectos SET PublicarEnGestion = 'True'
					,PublicarEnEmpresarial	= 'True'
					,  PublicarEnTiendaNube	= 'True'
					,  PublicarEnMercadoLibre	= 'True'
					,  PublicarEnArborea	= 'True' 
					,  PublicarEnSincronizacionSucursal = 'True' WHERE publicarenWeb = 'True'
GO


UPDATE AuditoriaProspectos SET PublicarEnGestion = 'True'
					,PublicarEnEmpresarial	= 'True'
					,  PublicarEnTiendaNube	= 'True'
					,  PublicarEnMercadoLibre	= 'True'
					,  PublicarEnArborea	= 'True' 
					,  PublicarEnSincronizacionSucursal = 'True' WHERE publicarenWeb = 'True'
GO


IF dbo.ExisteTabla('Embarcaciones') = 0
BEGIN
UPDATE Clientes SET publicarenWeb = 'False'

UPDATE AuditoriaClientes SET publicarenWeb = 'False'

UPDATE Prospectos SET publicarenWeb = 'False'

UPDATE AuditoriaProspectos SET publicarenWeb = 'False'

END