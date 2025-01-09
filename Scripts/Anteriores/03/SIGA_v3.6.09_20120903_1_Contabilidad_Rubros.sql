
------------------------------
INSERT INTO Funciones
         (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible, 
          IdPadre, Posicion, Archivo, Pantalla, Icono)
     VALUES
         ('ContabilidadCuentasRubro', 'Cuentas Rubros', 'Cuentas Rubros', 'True', 'False', 'True', 'True', 
          'Contabilidad', 250, 'Eniac.Win', 'ContabilidadCuentasRubro', NULL)
GO

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'ContabilidadCuentasRubro' AS Pantalla FROM Roles
GO

-----------------------------------------------------------

/****** Object:  Table [dbo].[ContabilidadCuentasRubros]    Script Date: 09/03/2012 08:57:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContabilidadCuentasRubros](
    [idRubro] [int] NOT NULL,
    [IdCuenta] [int] NOT NULL,
    [IdPlanCuenta] [int] NOT NULL,
    [idGrupo] [int] NULL,
    [debe] [bit] NULL,
    [haber] [bit] NULL,
 CONSTRAINT [PK_ContabilidadCuentasRubros] PRIMARY KEY CLUSTERED 
(
    [idRubro] ASC,
    [IdCuenta] ASC,
    [IdPlanCuenta] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

