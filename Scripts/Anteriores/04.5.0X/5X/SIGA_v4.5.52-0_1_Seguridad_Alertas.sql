
-- Permiso asociado para la persona que pueda modificar el precio del dolar del sistema

--cambiamos el ancho del campo por si en el futuro usamos 3 decimales!
ALTER TABLE Monedas ALTER COLUMN FactorConversion decimal(6,3) NOT NULL;


--Inserto la funcion
INSERT INTO Funciones
		   (Id, Nombre, Descripcion
		   ,EsMenu, EsBoton, [Enabled], Visible
		   ,IdPadre, Posicion, Archivo, Pantalla, Icono)
	 VALUES
		   ('ActualizaValorDolar', 'Permiso para Modificar el valor del Dolar', 'Permiso para Modificar el valor del Dolar'
		   ,'False', 'False', 'True', 'True'
		   ,'Configuraciones', 999, 'Eniac.Win', NULL, NULL)
;

INSERT INTO RolesFunciones 
			  (IdRol,IdFuncion)
SELECT DISTINCT Id AS Rol, 'ActualizaValorDolar' AS Pantalla FROM dbo.Roles
	WHERE Id IN ('Adm', 'Supervisor') 
;
