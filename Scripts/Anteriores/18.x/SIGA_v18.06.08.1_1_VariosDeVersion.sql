
PRINT '' 
PRINT '1. Tabla CalendariosUsuarios: Asigno Permiso de Escritura a los que tienen Turnos y todavia no lo tienen.' 
GO

INSERT INTO CalendariosUsuarios
           (IdSucursal, IdCalendario, IdUsuario, PermitirEscritura)
SELECT UR.IdSucursal, C.IdCalendario , UR.IdUsuario, 'True' AS PermitirEscritura 
  FROM UsuariosRoles UR, RolesFunciones RF,  Calendarios C
  WHERE UR.IdRol = RF.IdRol
    AND RF.IdFuncion = 'TurnosABM'
    AND NOT EXISTS
     ( SELECT * FROM CalendariosUsuarios B
       WHERE B.IdSucursal = UR.IdSucursal
         AND B.IdCalendario = C.IdCalendario
         AND B.IdUsuario = UR.IdUsuario
         )    
GO


PRINT '' 
PRINT '2. Tabla Funciones: Ajusto Descripcion de Turnos\Excepciones de Calendarios (si esta distincto).' 
GO

UPDATE Funciones
  SET Nombre = 'Excepciones de Calendarios'
    , Descripcion = 'Excepciones de Calendarios'
    , Posicion = 15
 WHERE Id =  'CalendariosExcepciones'
   AND Nombre <> 'Excepciones de Calendarios'
GO


PRINT '' 
PRINT '3. Tabla Funciones: Ajusto Padre y Posicion de Fichas (V2).' 
GO

UPDATE Funciones
  SET IdPadre = 'Ventas'
    , Posicion = 5
 WHERE Id =  'FichasABM2'
   AND IdPadre <> 'Ventas'
GO


PRINT '' 
PRINT '4. Funcion Fichas (v2): La hago Boton.' 
GO

UPDATE Funciones
  SET EsBoton = 'True'
 WHERE Id =  'FichasABM2'
GO
