PRINT ''
PRINT '1.Se agregan los campos faltantes de SiSeN.Categorias al SiGA'
PRINT '1 Tabla Categorias: Nuevos Campos'
ALTER TABLE Categorias ADD
    [PerteneceAlComplejo] [bit] NULL CONSTRAINT [DF_Categorias_PerteneceAlComplejo]  DEFAULT ((0)),
    [FirmaMandato] [bit] NULL,
    [AdquiereAcciones] [char](1) NULL,
    [PideConyuge] [bit] NULL,
    [TPFisicaDatosAdicionales] [bit] NULL,
    [PideEmbarcacion] [char](1)  NULL,
    [PagaAlquiler] [bit] NULL,
    [PagaExpensas] [bit] NULL,
    [ImporteGastosAdmin] [decimal](10, 2) NULL,
    [AdquiereCamas] [char](1) NULL,
    [IdCategoriaInversionista] [int] NULL,
    [LimiteMesesDeudaBotado] [int] NULL
GO

PRINT '1.1. Se agrega Foreign Key a IdCategoriaInversionista'
ALTER TABLE [dbo].[Categorias]  WITH CHECK ADD  CONSTRAINT [FK_Categorias_Categorias] FOREIGN KEY([IdCategoriaInversionista])
REFERENCES [dbo].[Categorias] ([IdCategoria])

GO

PRINT '1.2. Actualizar registros pre-existentes para los campos'
UPDATE Categorias SET 
    [PerteneceAlComplejo] = 0,
    [FirmaMandato] = 0,
    [AdquiereAcciones] = 'N', 
    [PideConyuge] = 0,
    [TPFisicaDatosAdicionales] = 0,
    [PideEmbarcacion] = 'N', 
    [PagaAlquiler] = 0,
    [PagaExpensas] = 0,
    [ImporteGastosAdmin] = 0, --decimal, deberia ser = 0?
    [AdquiereCamas] = 'N'
GO

PRINT '1.3. Tabla Categorias: NOT NULL para los campos agregados'
ALTER TABLE Categorias ALTER COLUMN [PerteneceAlComplejo] [bit] NOT NULL
ALTER TABLE Categorias ALTER COLUMN [FirmaMandato] [bit] NOT NULL
ALTER TABLE Categorias ALTER COLUMN [PideConyuge] [bit] NOT NULL
ALTER TABLE Categorias ALTER COLUMN [TPFisicaDatosAdicionales] [bit] NOT NULL
ALTER TABLE Categorias ALTER COLUMN [PideEmbarcacion] [char](1) NOT NULL
ALTER TABLE Categorias ALTER COLUMN [PagaAlquiler] [bit] NOT NULL
ALTER TABLE Categorias ALTER COLUMN [PagaExpensas] [bit] NOT NULL
ALTER TABLE Categorias ALTER COLUMN [ImporteGastosAdmin] [decimal](10, 2) NOT NULL

PRINT ''
PRINT '2. Tabla CRMTiposNovedades: Nuevo campo Solapa Por Defecto'
ALTER TABLE CRMTiposNovedades ADD SolapaPorDefecto varchar(50)
GO

PRINT ''
PRINT '2.1. Tabla CRMTiposNovedades: Setear Registros del Nuevo campo al valor por defecto (comentarios)'
UPDATE CRMTiposNovedades SET SolapaPorDefecto = 'Comentarios'
PRINT ''
PRINT '2.2. Tabla CRMTiposNovedades: NOT NULL para los campos agregados'
ALTER TABLE CRMTiposNovedades ALTER COLUMN SolapaPorDefecto varchar(50) NOT NULL

PRINT ''
PRINT '3. Tabla Nueva: Situacion de Cheques'
CREATE TABLE SituacionCheques(
    IdSituacionCheque INT, 
    NombreSituacionCheque VARCHAR(50) 
    CONSTRAINT PK_SituacionesCheques PRIMARY KEY (IdSituacionCheque))
GO

PRINT ''
PRINT '4. Tabla Cheques: Campo nuevo IdSituacionCheque'
ALTER TABLE Cheques ADD IdSituacionCheque INT
    CONSTRAINT FK_SituacionCheques FOREIGN KEY (IdSituacionCheque) REFERENCES SituacionCheques(IdSituacionCheque) NULL

IF dbo.ExisteFuncion('SituacionChequesABM') = 0 AND dbo.ExisteFuncion('Caja') = 1
BEGIN
	/*ABM Situacion de Cheques*/
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
    VALUES
        ('SituacionChequesABM', 'ABM Situación de Cheques', 'ABM Situación de Cheques', 'True', 'False', 'True', 'True'
        ,'Caja', 150, 'Eniac.Win', 'ABM SituacionChequesABM', NULL, NULL
        ,'True', 'S', 'N', 'N', 'N', 'True')
   
	INSERT INTO RolesFunciones (IdRol,IdFuncion)
	SELECT DISTINCT Id AS Rol, 'SituacionChequesABM' AS Pantalla FROM dbo.Roles
	 WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
