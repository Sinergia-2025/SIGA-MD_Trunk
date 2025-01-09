PRINT ''
PRINT '1. Nueva Tabla: CRMTiposEstadosNovedades'
CREATE TABLE CRMTiposEstadosNovedades (
	IdTipoEstadoNovedad INT NOT NULL,
	NombreTipoEstadoNovedad VARCHAR(20) NOT NULL,
	Posicion INT NOT NULL,
	IdTipoNovedad VARCHAR(10) NOT NULL,
	PRIMARY KEY (IdTipoEstadoNovedad)
)
GO

PRINT ''
PRINT '2. FK_CRMTiposEstadosNovedades_CRMTiposNovedades'
ALTER TABLE CRMTiposEstadosNovedades
	ADD CONSTRAINT FK_CRMTiposEstadosNovedades_CRMTiposNovedades
	FOREIGN KEY (IdTipoNovedad) REFERENCES CRMTiposNovedades (IdTipoNovedad)
GO

PRINT ''
PRINT '3. Registros iniciales en la tabla CRMTiposEstadosNovedades';

WITH VIN AS
(
   SELECT TN.*, NombrePosicion = sk.NombrePosicion
   FROM (VALUES ('NUEVO,10'), ('EN PROCESO,20'), ('FINALIZADO,30'), ('CANCELADO,40')) sk(NombrePosicion)
   CROSS JOIN (SELECT ROW_NUMBER() OVER(ORDER BY NombreTipoNovedad ASC) AS nrow, * FROM CRMTiposNovedades ) TN
),
VOUT AS
(
   SELECT ROW_NUMBER() OVER(ORDER BY nrow ASC) IdTipoEstadoNovedad, 
   LEFT(NombrePosicion,PATINDEX ('%,%',NombrePosicion)-1) NombreTipoEstadoNovedad, 
   RIGHT(NombrePosicion,LEN(NombrePosicion)-PATINDEX ('%,%',NombrePosicion)) Posicion,IdTipoNovedad FROM VIN)
   INSERT INTO CRMTiposEstadosNovedades SELECT * FROM VOUT;
GO

PRINT ''
PRINT '4. Nuevo Campo: IdTipoEstadoNovedad en CRMEstadosNovedades'
ALTER TABLE CRMEstadosNovedades
	ADD IdTipoEstadoNovedad INT NULL
GO

PRINT ''
PRINT '5. FK_CRMEstadosNovedades_CRMTiposEstadosNovedades'
ALTER TABLE CRMEstadosNovedades
	ADD CONSTRAINT FK_CRMEstadosNovedades_CRMTiposEstadosNovedades
	FOREIGN KEY (IdTipoEstadoNovedad) REFERENCES CRMTiposEstadosNovedades (IdTipoEstadoNovedad)
GO

PRINT ''
PRINT '6. Actualización de los registros pre-existentes'
UPDATE EN SET EN.IdTipoEstadoNovedad = TEN.IdTipoEstadoNovedad FROM CRMEstadosNovedades EN
	LEFT JOIN CRMTiposEstadosNovedades TEN ON EN.IdTipoNovedad = TEN.IdTipoNovedad
GO

PRINT ''
PRINT '7. Cambio los valores a NOT NULL'
ALTER TABLE CRMEstadosNovedades
	ALTER COLUMN IdTipoEstadoNovedad INT NOT NULL
GO


PRINT ''
PRINT '8. Nuevo Campo: FechaImpresion en Pedidos'
ALTER TABLE Pedidos ADD FechaImpresion DATETIME NULL
GO

PRINT ''
PRINT '9. Nueva Pantalla: Actualización Masiva de Códigos'
IF dbo.ExisteFuncion('Procesos') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('ProdActualizacionMasivaCodigos', 'Productos - Cambio Masivo de Códigos', 'Productos - Cambio Masivo de Códigos', 'True', 'False', 'True', 'True'
        ,'Procesos', 25, 'Eniac.Win', 'ProdActualizacionMasivaCodigos', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'ProdActualizacionMasivaCodigos' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO


PRINT ''
PRINT '10. Nuevo Campo: HorarioClienteCompleto en Clientes'
ALTER TABLE Clientes
	ADD HorarioClienteCompleto VARCHAR(130) NULL
GO

PRINT ''
PRINT '11. Nuevo Campo: HorarioClienteCompleto en Auditorias de Clientes'
ALTER TABLE AuditoriaClientes
	ADD HorarioClienteCompleto VARCHAR(130) NULL
GO

PRINT ''
PRINT '12. Nuevo Campo: HorarioClienteCompleto en Prospectos'
ALTER TABLE Prospectos
	ADD HorarioClienteCompleto VARCHAR(130) NULL
GO

PRINT ''
PRINT '13. Nuevo Campo: HorarioClienteCompleto en Audioria de Prospectos'
ALTER TABLE AuditoriaProspectos
	ADD HorarioClienteCompleto VARCHAR(130) NULL
GO

PRINT ''
PRINT '14. Actualización de registros pre-existentes'
UPDATE C SET C.HorarioClienteCompleto = 
	ISNULL((CASE WHEN C.HoraInicio <> '00:00' AND C.HoraInicio <> '' THEN 'Lun A Vie:' + C.HoraInicio + ' a ' +
			 (CASE WHEN C.HorarioCorrido = 1 THEN C.HoraFin2 ELSE C.HoraFin END) +
			 (CASE WHEN C.HoraInicio2 <> '00:00' AND C.HoraInicio2 <> '' THEN ' Y ' + C.HoraInicio2 + ' a ' + C.HoraFin2 ELSE '' END) ELSE '' END), '') +
	
	-- Sabados
	ISNULL((CASE WHEN C.HoraSabInicio <> '00:00' AND C.HoraSabInicio <> '' THEN ' - Sab:' + C.HoraSabInicio + ' a ' +
			 (CASE WHEN C.HorarioCorridoSab = 1 THEN C.HoraSabFin2 ELSE C.HoraSabFin END) +
			 (CASE WHEN C.HoraSabInicio2 <> '00:00' AND C.HoraSabInicio2 <> '' THEN ' Y ' + C.HoraSabInicio2 + ' a ' + C.HoraSabFin2 ELSE ''END) ELSE '' END), '') +
	
	-- Domingos
	ISNULL((CASE WHEN C.HoraDomInicio <> '00:00' AND C.HoraDomInicio <> '' THEN ' - Dom:' + C.HoraDomInicio + ' a ' +
			 (CASE WHEN C.HorarioCorridoDom = 1 THEN C.HoraDomFin2 ELSE C.HoraDomFin END) +
			 (CASE WHEN C.HoraDomInicio2 <> '00:00' AND C.HoraDomInicio2 <> '' THEN ' Y ' + C.HoraDomInicio2 + ' a ' + C.HoraDomFin2 ELSE ''END) ELSE '' END), '') FROM Clientes C 
GO

