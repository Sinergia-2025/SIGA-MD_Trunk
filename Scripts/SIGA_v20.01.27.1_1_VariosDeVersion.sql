PRINT ''
PRINT '2. Menu Permisos - Listas de Control por Productos '
IF dbo.SoyHAR() = 'True' OR dbo.ExisteFuncion('ListasControlProductos') = 'True'     --Calidad (METALSUR)
BEGIN

    PRINT ''
    PRINT '. Menu ListasControlProductos-CF'
    INSERT INTO Funciones
       (Id, Nombre, Descripcion
       ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
            ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
       ('ListasControlProductos-CF', 'Ejecución de Listas de Control por Productos-Calidad Final', 'Ejecución de Listas de Control por Productos-Calidad Final', 
        'False', 'False', 'True', 'True', 'ListasControlProductos', 10, 'Eniac.Win', 'ListasControlProductos-CF', NULL, NULL
            ,'True', 'S', 'N', 'N', 'N')
  
    --INSERT INTO RolesFunciones (IdRol,IdFuncion)
    --SELECT DISTINCT IdRol, 'ListasControlProductos-CF' AS Pantalla FROM dbo.RolesFunciones
    --     WHERE IdRol IN ('Adm')

END


PRINT ''
PRINT '3.Tabla CalidadListasControl:Agrega Habilita Fecha Liberado'

ALTER TABLE CalidadListasControl ADD HabilitaFechaLiberado bit null
GO

UPDATE CalidadListasControl SET HabilitaFechaLiberado = 'False'
GO

ALTER TABLE CalidadListasControl ALTER COLUMN HabilitaFechaLiberado bit not null
GO

UPDATE CalidadListasControl SET HabilitaFechaLiberado = 'True' WHERE IdListaControl = 20

PRINT ''
PRINT '4. Tabla Clientes: Nuevo campo Sexo'
ALTER TABLE Clientes ADD Sexo varchar(1) null;
GO

PRINT ''
PRINT '4.1. Tabla Clientes: Valores por defecto para Sexo'
UPDATE Clientes
   SET Sexo  = 'I'
GO

PRINT ''
PRINT '4.2. Tabla Clientes: NOT NULL para Sexo'
ALTER TABLE dbo.Clientes   ALTER COLUMN Sexo varchar(1) NOT NULL

PRINT ''
PRINT '5. Tabla AuditoriaClientes: Nuevo campo Sexo'
ALTER TABLE AuditoriaClientes ADD Sexo varchar(1) null

PRINT ''
PRINT '6. Tabla Prospectos: Nuevo campo Sexo'
ALTER TABLE Prospectos ADD Sexo varchar(1) null
GO

PRINT ''
PRINT '6.1. Tabla Prospectos: Valor por defecto para Sexo'
UPDATE dbo.Prospectos
   SET Sexo  = 'I'
GO

PRINT ''
PRINT '6.2. Tabla Prospectos: NOT NULL para Sexo'
ALTER TABLE dbo.Prospectos ALTER COLUMN Sexo  varchar(1) NOT NULL


PRINT ''
PRINT '7. Tabla AuditoriaProspectos: Nuevo campo Sexo'
ALTER TABLE AuditoriaProspectos ADD Sexo varchar(1) null
