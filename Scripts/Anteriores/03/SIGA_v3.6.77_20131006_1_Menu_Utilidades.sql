
-- Se corre para Abajo (estaba en 400).
UPDATE Funciones
   SET Posicion = 490
 WHERE Id = 'ComisionesVendedores'
GO

--Inserto el Menu nuevo

INSERT INTO [dbo].Funciones
    (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
    ,IdPadre, Posicion, Archivo, Pantalla, Icono)
  VALUES
    ('VentasUtilidades', 'Utilidades', '', 'True', 'False', 'True', 'True',
     'Ventas', 480, NULL, NULL, NULL)
GO


/* ------- REASIGNA LA POSICION POR LAS DUDAS ---------- */ 
   
UPDATE Funciones 
   SET IdPadre = 'VentasUtilidades'
     , Posicion = 
   (CASE ID WHEN 'InfUtilidadesPorCliente' THEN 10 
            WHEN 'InfUtilidadesPorMarca' THEN 20 
            WHEN 'InfUtilidadesPorProducto' THEN 30 
            WHEN 'InfUtilidadesPorComprobantes' THEN 40
            WHEN 'InfUtilidadesPorComprobantDet' THEN 50 
    END)
  WHERE IdPadre = 'Ventas'
    AND Id IN ('InfUtilidadesPorCliente', 'InfUtilidadesPorMarca' , 'InfUtilidadesPorProducto' 
              ,'InfUtilidadesPorComprobantes', 'InfUtilidadesPorComprobantDet')
GO


/* ----------------- */

INSERT INTO RolesFunciones (IdRol,IdFuncion)
SELECT DISTINCT IdRol, 'VentasUtilidades' AS Pantalla FROM dbo.RolesFunciones
    WHERE IdFuncion = 'InfUtilidadesPorCliente'
GO

