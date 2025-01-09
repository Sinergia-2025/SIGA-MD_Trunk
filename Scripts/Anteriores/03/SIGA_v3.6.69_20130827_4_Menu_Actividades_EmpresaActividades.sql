
UPDATE Funciones 
 SET Nombre = 'ABM de Actividades'
    ,Descripcion = 'ABM de Actividades'
    ,IdPadre = 'AFIP'
    ,Posicion = 130
 WHERE Id = 'ActividadesABM'
GO

DELETE RolesFunciones
 WHERE IdFuncion = 'ActividadesABM'
  AND IdRol NOT IN (SELECT IdRol FROM RolesFunciones WHERE IdFuncion = 'CategoriasFiscalesABM')
GO

UPDATE Funciones 
 SET IdPadre = 'AFIP'
    ,Posicion = 140
 WHERE Id = 'EmpresaActividades'
GO

DELETE RolesFunciones
 WHERE IdFuncion = 'EmpresaActividades'
  AND IdRol NOT IN (SELECT IdRol FROM RolesFunciones WHERE IdFuncion = 'CategoriasFiscalesABM')
GO
