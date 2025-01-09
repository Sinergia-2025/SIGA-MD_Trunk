
GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
PRINT N'Elimino todas las FKs';

GO
IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_1') )
    DROP TABLE dbo.t_Referencias_1
--
SELECT  t.[name] AS Nombre_Tabla_Dep,
        fk.name AS FK_Name,
        ' ALTER TABLE ' + SCHEMA_NAME(t.[schema_id]) + '.' + ta.[name] + ' DROP CONSTRAINT [' + fk.name + ']' AS DROP_FK
INTO    dbo.t_Referencias_1 
FROM    SYS.TABLES t
        INNER JOIN SYS.FOREIGN_KEYS fk ON (fk.referenced_object_id = t.object_id)
        INNER JOIN SYS.TABLES ta ON (ta.object_id = fk.parent_object_id)
WHERE   t.[name] IN ('ContabilidadAsientosCuentas', 
					'ContabilidadAsientosCuentasTmp',
					'ContabilidadCuentas',
					'MediosDePago',
					'ContabilidadPlanesCuentas')   -- COLOCAR UN NOMBRE DE TABLA
ORDER BY fk.name
--
GO 
--// Eliminar FKs
DECLARE @vSQL VARCHAR(MAX);
SET @vSQL = '';
--
SELECT @vSQL = @vSQL + CHAR(13) + CHAR(10) + r.DROP_FK FROM dbo.t_Referencias_1 r
--
PRINT @vSQL
EXEC (@vSQL)
--

GO
PRINT N'Elimino todas las PKs';

GO

IF EXISTS ( SELECT 1 FROM sys.tables o WHERE o.Object_id = OBJECT_ID('dbo.t_Referencias_2') )
    DROP TABLE dbo.t_Referencias_2
--
SELECT tc.Table_Name, tc.Constraint_Name,
      ' ALTER TABLE dbo.' + tc.Table_Name + ' DROP CONSTRAINT [' + tc.Constraint_Name + ']' AS DROP_PK
INTO    dbo.t_Referencias_2 
  FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
 WHERE tc.Table_Name IN 
  ('ContabilidadAsientosCuentas', 
					'ContabilidadAsientosCuentasTmp',
					'ContabilidadCuentas',
					'ContabilidadPlanesCuentas')
  AND tc.Constraint_Type = 'PRIMARY KEY'
 ORDER BY tc.Table_Name 

--
GO 
--// Eliminar FKs
DECLARE @vSQL VARCHAR(MAX);
SET @vSQL = '';
--
SELECT  @vSQL = @vSQL + CHAR(13) + CHAR(10) + r.DROP_PK
FROM    dbo.t_Referencias_2 r
--
PRINT @vSQL
EXEC (@vSQL)
--
GO

GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ContabilidadAsientosCuentas] (
    [IdPlanCuenta] INT             NOT NULL,
    [IdAsiento]    INT             NOT NULL,
    [IdCuenta]     BIGINT          NOT NULL,
    [IdRenglon]    INT             NOT NULL,
    [Debe]         DECIMAL (12, 2) NULL,
    [Haber]        DECIMAL (12, 2) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ContabilidadAsientosCuentas1] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ContabilidadAsientosCuentas])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ContabilidadAsientosCuentas] ([IdPlanCuenta], [IdAsiento], [IdCuenta], [IdRenglon], [Debe], [Haber])
        SELECT   [IdPlanCuenta],
                 [IdAsiento],
                 [IdCuenta],
                 [IdRenglon],
                 [Debe],
                 [Haber]
        FROM     [dbo].[ContabilidadAsientosCuentas]
        ORDER BY [IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC;
    END

DROP TABLE [dbo].[ContabilidadAsientosCuentas];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ContabilidadAsientosCuentas]', N'ContabilidadAsientosCuentas';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ContabilidadAsientosCuentas1]', N'PK_ContabilidadAsientosCuentas', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ContabilidadAsientosCuentasTmp]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ContabilidadAsientosCuentasTmp] (
    [IdPlanCuenta] INT             NOT NULL,
    [IdAsiento]    INT             NOT NULL,
    [IdCuenta]     BIGINT          NOT NULL,
    [IdRenglon]    INT             NOT NULL,
    [Debe]         DECIMAL (12, 2) NULL,
    [Haber]        DECIMAL (12, 2) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ContabilidadAsientosCuentasTmp1] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ContabilidadAsientosCuentasTmp])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ContabilidadAsientosCuentasTmp] ([IdPlanCuenta], [IdAsiento], [IdCuenta], [IdRenglon], [Debe], [Haber])
        SELECT   [IdPlanCuenta],
                 [IdAsiento],
                 [IdCuenta],
                 [IdRenglon],
                 [Debe],
                 [Haber]
        FROM     [dbo].[ContabilidadAsientosCuentasTmp]
        ORDER BY [IdPlanCuenta] ASC, [IdAsiento] ASC, [IdCuenta] ASC, [IdRenglon] ASC;
    END

DROP TABLE [dbo].[ContabilidadAsientosCuentasTmp];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ContabilidadAsientosCuentasTmp]', N'ContabilidadAsientosCuentasTmp';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ContabilidadAsientosCuentasTmp1]', N'PK_ContabilidadAsientosCuentasTmp', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ContabilidadAsientosModelo]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ContabilidadAsientosModelo] (
    [IdAsiento]     INT           NOT NULL,
    [NombreAsiento] NVARCHAR (50) NOT NULL,
    [IdPlanCuenta]  INT           NOT NULL,
    [IdCuenta]      BIGINT        NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ContabilidadAsientosModelo1] PRIMARY KEY CLUSTERED ([IdAsiento] ASC, [NombreAsiento] ASC, [IdPlanCuenta] ASC, [IdCuenta] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ContabilidadAsientosModelo])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ContabilidadAsientosModelo] ([IdAsiento], [NombreAsiento], [IdPlanCuenta], [IdCuenta])
        SELECT   [IdAsiento],
                 [NombreAsiento],
                 [IdPlanCuenta],
                 [IdCuenta]
        FROM     [dbo].[ContabilidadAsientosModelo]
        ORDER BY [IdAsiento] ASC, [NombreAsiento] ASC, [IdPlanCuenta] ASC, [IdCuenta] ASC;
    END

DROP TABLE [dbo].[ContabilidadAsientosModelo];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ContabilidadAsientosModelo]', N'ContabilidadAsientosModelo';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ContabilidadAsientosModelo1]', N'PK_ContabilidadAsientosModelo', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ContabilidadCuentas]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ContabilidadCuentas] (
    [IdCuenta]      BIGINT       NOT NULL,
    [NombreCuenta]  VARCHAR (50) NOT NULL,
    [Nivel]         INT          NOT NULL,
    [IdCentroCosto] INT          NOT NULL,
    [EsImputable]   BIT          NOT NULL,
    [Activa]        BIT          NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ContabilidadCuentas1] PRIMARY KEY CLUSTERED ([IdCuenta] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ContabilidadCuentas])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ContabilidadCuentas] ([IdCuenta], [NombreCuenta], [Nivel], [IdCentroCosto], [EsImputable], [Activa])
        SELECT   [IdCuenta],
                 [NombreCuenta],
                 [Nivel],
                 [IdCentroCosto],
                 [EsImputable],
                 [Activa]
        FROM     [dbo].[ContabilidadCuentas]
        ORDER BY [IdCuenta] ASC;
    END

DROP TABLE [dbo].[ContabilidadCuentas];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ContabilidadCuentas]', N'ContabilidadCuentas';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ContabilidadCuentas1]', N'PK_ContabilidadCuentas', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[ContabilidadCuentasMediosDePago]...';


GO
ALTER TABLE [dbo].[ContabilidadCuentasMediosDePago] ALTER COLUMN [IdCuentaCheques] BIGINT NULL;

ALTER TABLE [dbo].[ContabilidadCuentasMediosDePago] ALTER COLUMN [IdCuentaDolares] BIGINT NULL;

ALTER TABLE [dbo].[ContabilidadCuentasMediosDePago] ALTER COLUMN [IdCuentaPesos] BIGINT NULL;

ALTER TABLE [dbo].[ContabilidadCuentasMediosDePago] ALTER COLUMN [IdCuentaTarjetas] BIGINT NULL;

ALTER TABLE [dbo].[ContabilidadCuentasMediosDePago] ALTER COLUMN [IdCuentaTickets] BIGINT NULL;


GO
PRINT N'Starting rebuilding table [dbo].[ContabilidadCuentasRubros]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ContabilidadCuentasRubros] (
    [idRubro]      INT          NOT NULL,
    [IdCuenta]     BIGINT       NOT NULL,
    [IdPlanCuenta] INT          NOT NULL,
    [Tipo]         VARCHAR (50) NOT NULL,
    [Debe]         BIT          NULL,
    [Haber]        BIT          NULL,
    [GrupoAsiento] INT          NULL,
    [Campo]        VARCHAR (20) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ContabilidadCuentasRubros1] PRIMARY KEY CLUSTERED ([idRubro] ASC, [IdCuenta] ASC, [IdPlanCuenta] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ContabilidadCuentasRubros])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ContabilidadCuentasRubros] ([idRubro], [IdCuenta], [IdPlanCuenta], [Tipo], [debe], [haber], [grupoAsiento], [Campo])
        SELECT   [idRubro],
                 [IdCuenta],
                 [IdPlanCuenta],
                 [Tipo],
                 [debe],
                 [haber],
                 [grupoAsiento],
                 [Campo]
        FROM     [dbo].[ContabilidadCuentasRubros]
        ORDER BY [idRubro] ASC, [IdCuenta] ASC, [IdPlanCuenta] ASC;
    END

DROP TABLE [dbo].[ContabilidadCuentasRubros];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ContabilidadCuentasRubros]', N'ContabilidadCuentasRubros';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ContabilidadCuentasRubros1]', N'PK_ContabilidadCuentasRubros', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[ContabilidadPlanesCuentas]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_ContabilidadPlanesCuentas] (
    [IdPlanCuenta] INT    NOT NULL,
    [IdCuenta]     BIGINT NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_ContabilidadPlanesCuentas1] PRIMARY KEY CLUSTERED ([IdPlanCuenta] ASC, [IdCuenta] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[ContabilidadPlanesCuentas])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_ContabilidadPlanesCuentas] ([IdPlanCuenta], [IdCuenta])
        SELECT   [IdPlanCuenta],
                 [IdCuenta]
        FROM     [dbo].[ContabilidadPlanesCuentas]
        ORDER BY [IdPlanCuenta] ASC, [IdCuenta] ASC;
    END

DROP TABLE [dbo].[ContabilidadPlanesCuentas];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_ContabilidadPlanesCuentas]', N'ContabilidadPlanesCuentas';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_ContabilidadPlanesCuentas1]', N'PK_ContabilidadPlanesCuentas', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[MediosDePago]...';


GO
ALTER TABLE [dbo].[MediosDePago] ALTER COLUMN [IdCuenta] BIGINT NULL;


GO
PRINT N'Creating [dbo].[FK_ContabilidadAsientosCuentas_ContabilidadAsientos]...';


GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] WITH NOCHECK
    ADD CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos] FOREIGN KEY ([IdPlanCuenta], [IdAsiento]) REFERENCES [dbo].[ContabilidadAsientos] ([IdPlanCuenta], [IdAsiento]);


GO
PRINT N'Creating [dbo].[FK_ContabilidadAsientosCuentas_ContabilidadCuentas]...';


GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] WITH NOCHECK
    ADD CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadCuentas] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta]);


GO
PRINT N'Creating [dbo].[FK_ContabilidadAsientosCuentasTmp_ContabilidadCuentas]...';


GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] WITH NOCHECK
    ADD CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadCuentas] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta]);


GO
PRINT N'Creating [dbo].[FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp]...';


GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] WITH NOCHECK
    ADD CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp] FOREIGN KEY ([IdPlanCuenta], [IdAsiento]) REFERENCES [dbo].[ContabilidadAsientosTmp] ([IdPlanCuenta], [IdAsiento]);


GO
PRINT N'Creating [dbo].[FK_ContabilidadCuentas_ContabilidadCentrosCostos]...';


GO
ALTER TABLE [dbo].[ContabilidadCuentas] WITH NOCHECK
    ADD CONSTRAINT [FK_ContabilidadCuentas_ContabilidadCentrosCostos] FOREIGN KEY ([IdCentroCosto]) REFERENCES [dbo].[ContabilidadCentrosCostos] ([IdCentroCosto]);


GO
PRINT N'Creating [dbo].[FK_MediosDePago_ContabilidadCuentas]...';


GO
ALTER TABLE [dbo].[MediosDePago] WITH NOCHECK
    ADD CONSTRAINT [FK_MediosDePago_ContabilidadCuentas] FOREIGN KEY ([IdCuenta]) REFERENCES [dbo].[ContabilidadCuentas] ([IdCuenta]);


GO
PRINT N'Creating [dbo].[FK_ContabilidadPlanesCuentas_ContabilidadPlanes]...';


GO
ALTER TABLE [dbo].[ContabilidadPlanesCuentas] WITH NOCHECK
    ADD CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadPlanes] FOREIGN KEY ([IdPlanCuenta]) REFERENCES [dbo].[ContabilidadPlanes] ([IdPlanCuenta]);


GO
PRINT N'Altering [dbo].[ResPresup]...';


GO

GO
ALTER TABLE [dbo].[ContabilidadAsientosCuentas] WITH CHECK CHECK CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadAsientos];

ALTER TABLE [dbo].[ContabilidadAsientosCuentas] WITH CHECK CHECK CONSTRAINT [FK_ContabilidadAsientosCuentas_ContabilidadCuentas];

ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] WITH CHECK CHECK CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadCuentas];

ALTER TABLE [dbo].[ContabilidadAsientosCuentasTmp] WITH CHECK CHECK CONSTRAINT [FK_ContabilidadAsientosCuentasTmp_ContabilidadAsientosTmp];

ALTER TABLE [dbo].[ContabilidadCuentas] WITH CHECK CHECK CONSTRAINT [FK_ContabilidadCuentas_ContabilidadCentrosCostos];

ALTER TABLE [dbo].[MediosDePago] WITH CHECK CHECK CONSTRAINT [FK_MediosDePago_ContabilidadCuentas];

ALTER TABLE [dbo].[ContabilidadPlanesCuentas] WITH CHECK CHECK CONSTRAINT [FK_ContabilidadPlanesCuentas_ContabilidadPlanes];


GO
PRINT N'Update complete.';


GO
