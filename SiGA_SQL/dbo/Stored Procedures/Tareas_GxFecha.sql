﻿CREATE PROCEDURE [dbo].[Tareas_GxFecha]
@fecha DATETIME
AS EXTERNAL NAME [Eniac.Seguridad.BaseDeDatos].[Eniac.Seguridad.BaseDeDatos.StoredProcedures].[Tareas_GxFecha]


GO
EXECUTE sp_addextendedproperty @name = N'AutoDeployed', @value = N'yes', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Tareas_GxFecha';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFile', @value = N'spUsuarios.vb', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Tareas_GxFecha';


GO
EXECUTE sp_addextendedproperty @name = N'SqlAssemblyFileLine', @value = 89, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'PROCEDURE', @level1name = N'Tareas_GxFecha';
