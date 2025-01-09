INSERT INTO Funciones
   (Id, Nombre, Descripcion
   ,EsMenu, EsBoton, [Enabled], Visible, IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
			 PermiteMultiplesInstancias,Plus,Express,Basica,PV, IdModulo,EsMDIChild)
 VALUES
   ('CntbAsientosABM-EditaNoManual', 'Asientos - Edita No Manual', 'Asientos - Edita No Manual', 
    'False', 'False', 'True', 'False', 'ContabilidadAsientosABM', 10, 'Eniac.Win', 'CntbAsientosABM-EditaNoManual', NULL
    ,NULL, 1, 'S', 'N', 'N', 'N',NULL,'True')
GO

-- Aquellos Roles que pueden Actualizar los Ejercicios Contables.
INSERT INTO RolesFunciones 
           (IdRol,IdFuncion)
SELECT IdRol, 'CntbAsientosABM-EditaNoManual' AS Pantalla  FROM RolesFunciones 
 WHERE IdFuncion = 'ContabilidadEjeciciosABM'
GO
