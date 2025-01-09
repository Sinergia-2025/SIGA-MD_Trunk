PRINT ''
PRINT '1. Nueva opción de menú Estados de Venta'
INSERT INTO Funciones
           (Id, Nombre, Descripcion, EsMenu, EsBoton, Enabled, Visible
           ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
           ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
     VALUES
           ('EstadosVentaABM', 'Estados de Venta', 'Estados de Venta', 'True', 'False', 'True', 'True'
           ,'Archivos', 46, 'Eniac.Win', 'EstadosVentaABM', null, NULL
           ,'True', 'S', 'N', 'N', 'N')
  
INSERT INTO RolesFunciones 
            (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'EstadosVentaABM' AS Pantalla FROM dbo.Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina')

IF OBJECT_ID (N'dbo.EstadosVenta', N'U') IS NULL 
BEGIN
    PRINT ''
    PRINT '2. Nueva tabla EstadosVenta'
    CREATE TABLE [dbo].[EstadosVenta](
	    [IdEstadoVenta] [int] NOT NULL,
	    [NombreEstadoVenta] [varchar](30) NOT NULL,
     CONSTRAINT [PK_EstadosVenta] PRIMARY KEY CLUSTERED 
    ([IdEstadoVenta] ASC)
    WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

    PRINT ''
    PRINT '3. Valores iniciales para la tabla EstadosVenta'
    INSERT [dbo].[EstadosVenta] ([IdEstadoVenta], [NombreEstadoVenta]) 
    VALUES (0, N'Nota Crédito'),
           (1, N'Venta Normal'),
           (2, N'Cerrado Eventual'),
           (3, N'Completo'),
           (4, N'No Pasó'),
           (5, N'No Quiso Reponer/Comprar'),
           (6, N'Retirar Atril / Mercadería'),
           (7, N'Otro Problema'),
           (8, N'Cerrado Definitivamente'),
           (9, N'Pasar Otro día'),
           (10, N'No Repuso Galletitas'),
           (11, N'No Recibió Mercadería')
END
