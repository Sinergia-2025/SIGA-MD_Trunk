

PRINT ''
PRINT '3. Función Menu: Inf. Auditoría de Monedas'
IF dbo.ExisteFuncion('InfAuditoriaMonedas') = 'False' 
BEGIN
	INSERT INTO [dbo].[Funciones]
				([Id]
				,[Nombre]
				,[Descripcion]
				,[EsMenu]
				,[EsBoton]
				,[Enabled]
				,[Visible]
				,[IdPadre]
				,[Posicion]
				,[Archivo]
				,[Pantalla]
				,[Icono]
				,[Parametros]
				,[PermiteMultiplesInstancias]
				,[Plus]
				,[Express]
				,[Basica]
				,[PV]
				,[IdModulo]
				,[EsMDIChild])
			VALUES
				('InfAuditoriaMonedas',	'Inf. Auditoría de Monedas',	'Inf. de Auditoría Monedas',	1,	0,	1,	1,	'ArchivosAuditorias', 50,	'Eniac.Win',	'InfAuditoriaMonedas',
				NULL,	NULL,	1,	'S',	'N',	'N',	'N',	NULL,	1)
END
GO

MERGE INTO Impuestos AS D
USING (SELECT 'PIVA' IdTipoImpuesto, 3.0 Alicuota, 'True' Activo UNION ALL
       SELECT 'PIVA', 1.5, 'True') AS O
		ON D.IdTipoImpuesto = O.IdTipoImpuesto AND D.Alicuota = O.Alicuota
WHEN NOT MATCHED THEN 
	INSERT (  IdTipoImpuesto,   Alicuota,   Activo) 
	VALUES (O.IdTipoImpuesto, O.Alicuota, O.Activo);

IF dbo.ExisteCampo('Impuestos', 'IdTipoImpuestoPIVA') = 0
BEGIN
    ALTER TABLE dbo.Impuestos ADD
       IdTipoImpuestoPIVA varchar(5) NULL,
       AlicuotaPIVA decimal(6, 2) NULL
END
GO
IF dbo.ExisteFK('FK_Impuestos_Impuestos_PIVA') = 0
BEGIN
    ALTER TABLE dbo.Impuestos ADD CONSTRAINT FK_Impuestos_Impuestos_PIVA
        FOREIGN KEY (IdTipoImpuestoPIVA, AlicuotaPIVA)
        REFERENCES dbo.Impuestos (IdTipoImpuesto, Alicuota)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

UPDATE Impuestos
   SET IdTipoImpuestoPIVA = 'PIVA'
     , AlicuotaPIVA = CASE WHEN Alicuota = 21 THEN 3.0 ELSE 1.5 END
 WHERE IdTipoImpuesto = 'IVA'
   AND Alicuota IN (21, 10.5)

   SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
GO

IF dbo.ExisteTabla('RegimenesPercepciones') = 0
BEGIN
CREATE TABLE RegimenesPercepciones(
	IdTipoImpuesto varchar(5) NOT NULL,
	IdRegimenPercepcion int NOT NULL,
	NombreRegimenPercepcion varchar(50) NOT NULL,
	CodigoAFIP int NOT NULL,
	ImporteNetoMinimo decimal(16, 4) NOT NULL,
    ImpuestoMinimo decimal(16, 4) NOT NULL,
 CONSTRAINT PK_RegimenesPercepciones PRIMARY KEY CLUSTERED (IdTipoImpuesto ASC, IdRegimenPercepcion ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_RegimenesPercepciones_TiposImpuestos') = 0
BEGIN
    ALTER TABLE dbo.RegimenesPercepciones  WITH CHECK ADD  
    CONSTRAINT FK_RegimenesPercepciones_TiposImpuestos FOREIGN KEY(IdTipoImpuesto)
    REFERENCES dbo.TiposImpuestos (IdTipoImpuesto)

    ALTER TABLE dbo.RegimenesPercepciones CHECK CONSTRAINT FK_RegimenesPercepciones_TiposImpuestos
END
GO

IF dbo.ExisteTabla('RegimenesPercepcionesAlicuotas') = 0
BEGIN
    CREATE TABLE RegimenesPercepcionesAlicuotas(
	    IdTipoImpuesto varchar(5) NOT NULL,
	    IdRegimenPercepcion int NOT NULL,
	    AlicuotaPercepcion decimal(6, 2) NOT NULL,
     CONSTRAINT PK_RegimenesPercepcionesAlicuotas PRIMARY KEY CLUSTERED (IdTipoImpuesto ASC, IdRegimenPercepcion ASC, AlicuotaPercepcion ASC)
     WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]
END
GO

IF dbo.ExisteFK('FK_RegimenesPercepcionesAlicuotas_Impuestos') = 0
BEGIN
    ALTER TABLE dbo.RegimenesPercepcionesAlicuotas  WITH CHECK ADD  CONSTRAINT FK_RegimenesPercepcionesAlicuotas_Impuestos 
    FOREIGN KEY(IdTipoImpuesto, AlicuotaPercepcion)
    REFERENCES dbo.Impuestos (IdTipoImpuesto, Alicuota)
    ALTER TABLE dbo.RegimenesPercepcionesAlicuotas CHECK CONSTRAINT FK_RegimenesPercepcionesAlicuotas_Impuestos
END
GO

IF dbo.ExisteFK('FK_RegimenesPercepcionesAlicuotas_RegimenesPercepciones') = 0
BEGIN
    ALTER TABLE dbo.RegimenesPercepcionesAlicuotas  WITH CHECK ADD  CONSTRAINT FK_RegimenesPercepcionesAlicuotas_RegimenesPercepciones 
    FOREIGN KEY(IdTipoImpuesto, IdRegimenPercepcion)
    REFERENCES dbo.RegimenesPercepciones (IdTipoImpuesto, IdRegimenPercepcion)

    ALTER TABLE dbo.RegimenesPercepcionesAlicuotas CHECK CONSTRAINT FK_RegimenesPercepcionesAlicuotas_RegimenesPercepciones
END
GO
IF dbo.ExisteFuncion('RegimenesPercepcionesABM') = 0 AND dbo.ExisteFuncion('AFIP') = 1
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('RegimenesPercepcionesABM', 'ABM Regímenes de Percepciones', 'ABM Regímenes de Percepciones', 'True', 'False', 'True', 'True'
        ,'AFIP', 115, 'Eniac.Win', 'RegimenesPercepcionesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'RegimenesPercepcionesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
GO

DELETE FROM RegimenesPercepcionesAlicuotas
DELETE FROM RegimenesPercepciones

INSERT INTO RegimenesPercepciones
           (IdTipoImpuesto, IdRegimenPercepcion, NombreRegimenPercepcion
           ,CodigoAFIP, ImporteNetoMinimo, ImpuestoMinimo)
     VALUES
           ('PIVA', 602, 'Resolución General Nº 5329/2023', 602, 0, 60)
INSERT INTO RegimenesPercepcionesAlicuotas
           (IdTipoImpuesto, IdRegimenPercepcion, AlicuotaPercepcion)
     VALUES
           ('PIVA', 602, 3),
           ('PIVA', 602, 1.5)
GO

IF dbo.ExisteCampo('Clientes', 'EsExentoPercIVARes53292023') = 0
BEGIN
    ALTER TABLE dbo.Clientes ADD EsExentoPercIVARes53292023 bit NULL
    ALTER TABLE dbo.AuditoriaClientes ADD EsExentoPercIVARes53292023 bit NULL
    ALTER TABLE dbo.Prospectos ADD EsExentoPercIVARes53292023 bit NULL
    ALTER TABLE dbo.AuditoriaProspectos ADD EsExentoPercIVARes53292023 bit NULL
END
GO
UPDATE Clientes SET EsExentoPercIVARes53292023 = 'False';
UPDATE Prospectos SET EsExentoPercIVARes53292023 = 'False';

ALTER TABLE dbo.Clientes ALTER COLUMN EsExentoPercIVARes53292023 bit NOT NULL
ALTER TABLE dbo.Prospectos ALTER COLUMN EsExentoPercIVARes53292023 bit NOT NULL
GO
UPDATE C
   SET EsExentoPercIVARes53292023 = 'True'
  FROM Clientes C
 INNER JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = C.IdCategoriaFiscal
 WHERE CF.SolicitaCUIT = 'False';
GO

IF dbo.ExisteCampo('Productos', 'EsPerceptibleIVARes53292023') = 0
BEGIN
    ALTER TABLE dbo.Productos ADD EsPerceptibleIVARes53292023 bit NULL
    ALTER TABLE dbo.AuditoriaProductos ADD EsPerceptibleIVARes53292023 bit NULL
END
GO
UPDATE Productos SET EsPerceptibleIVARes53292023 = 'False'
ALTER TABLE dbo.Productos ALTER COLUMN EsPerceptibleIVARes53292023 bit NOT NULL
GO

IF dbo.ExisteCampo('RegimenesPercepciones', 'ImpuestoMinimo') = 0
BEGIN
    ALTER TABLE dbo.RegimenesPercepciones ADD ImpuestoMinimo decimal(16, 4) NULL
END
GO
UPDATE RegimenesPercepciones
   SET ImpuestoMinimo = 60
     , ImporteNetoMinimo = 0;

ALTER TABLE dbo.RegimenesPercepciones ALTER COLUMN ImpuestoMinimo decimal(16, 4) NOT NULL
GO

IF dbo.ExisteCampo('PercepcionVentas', 'IdRegimenPercepcion') = 0
BEGIN
    ALTER TABLE dbo.PercepcionVentas ADD IdRegimenPercepcion int NULL
END
GO
IF dbo.ExisteFK('FK_PercepcionVentas_RegimenesPercepciones') = 0
BEGIN
    ALTER TABLE dbo.PercepcionVentas ADD CONSTRAINT FK_PercepcionVentas_RegimenesPercepciones
        FOREIGN KEY (IdTipoImpuesto, IdRegimenPercepcion)
        REFERENCES dbo.RegimenesPercepciones (IdTipoImpuesto, IdRegimenPercepcion)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO

DECLARE @idParametro VARCHAR(MAX) = 'SIMOVILOFICINAURLPRODUCCION'
DECLARE @descripcionParametro VARCHAR(MAX) = 'SIMOVILOFICINAURLPRODUCCION'
DECLARE @valorParametro VARCHAR(MAX) = 'http://sinergiamovil.com.ar/simovil.oficina'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
SET @idParametro = 'SIMOVILOFICINAURLTESTING'
SET @descripcionParametro = 'SIMOVILOFICINAURLTESTING'
SET @valorParametro = 'http://sinergiamovil.com.ar/simovil.oficina.test'

MERGE INTO Parametros AS DEST
        USING (SELECT IdEmpresa, @idParametro AS IdParametro, @valorParametro ValorParametro, @descripcionParametro DescripcionParametro FROM Empresas) AS ORIG ON DEST.IdEmpresa = ORIG.IdEmpresa AND DEST.IdParametro = ORIG.IdParametro
    WHEN MATCHED THEN
        UPDATE SET DEST.ValorParametro = ORIG.ValorParametro
    WHEN NOT MATCHED THEN 
        INSERT (IdEmpresa, IdParametro, ValorParametro, CategoriaParametro, DescripcionParametro) VALUES (ORIG.IdEmpresa, ORIG.IdParametro, ORIG.ValorParametro, NULL, ORIG.DescripcionParametro)
;
GO

UPDATE RegimenesPercepciones 
   SET ImpuestoMinimo = 3000.00
 WHERE IdTipoImpuesto = 'PIVA'
   AND IdRegimenPercepcion = 602
GO

IF dbo.ExisteCampo('VentasImpuestos', 'IdRegimenPercepcion') = 0
BEGIN
    ALTER TABLE dbo.VentasImpuestos ADD IdRegimenPercepcion int NULL
END
GO
IF dbo.ExisteFK('FK_VentasImpuestos_RegimenesPercepciones') = 0
BEGIN
    ALTER TABLE dbo.VentasImpuestos ADD CONSTRAINT FK_VentasImpuestos_RegimenesPercepciones
        FOREIGN KEY (IdTipoImpuesto, IdRegimenPercepcion)
        REFERENCES dbo.RegimenesPercepciones (IdTipoImpuesto, IdRegimenPercepcion)
        ON UPDATE  NO ACTION ON DELETE  NO ACTION 
END
GO
