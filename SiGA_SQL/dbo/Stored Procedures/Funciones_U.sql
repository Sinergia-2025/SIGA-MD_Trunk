CREATE PROCEDURE [dbo].[Funciones_U]
@id NVARCHAR (4000), @nombre NVARCHAR (4000), @descripcion NVARCHAR (4000), @esMenu BIT, @esBoton BIT, @enabled BIT, @visible BIT, @idPadre NVARCHAR (4000), @posicion INT, @archivo NVARCHAR (4000), @pantalla NVARCHAR (4000), @icono VARBINARY (8000)
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Funciones_U]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Funciones_U';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spFunciones.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Funciones_U';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 67, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Funciones_U';

