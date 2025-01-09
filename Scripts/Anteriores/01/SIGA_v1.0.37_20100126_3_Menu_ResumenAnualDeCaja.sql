
--Inserto la pantalla nueva a partir de la anterior, en la misma posicion

INSERT INTO Funciones
           (Id,Nombre,Descripcion,EsMenu,EsBoton,[Enabled],Visible
           ,IdPadre,Posicion,Archivo,Pantalla,Icono)
(
SELECT 'ResumenAnualDeCaja','Resumen Anual de Caja','Resumen Anual de Caja',EsMenu,EsBoton,[Enabled],Visible
           ,IdPadre,Posicion,Archivo,'ResumenAnualDeCaja',Icono
 FROM Funciones           
 WHERE Id = 'ResumenCorporativoDeCaja'
)
GO

UPDATE RolesFunciones 
  SET IdFuncion = 'ResumenAnualDeCaja'
 WHERE IdFuncion = 'ResumenCorporativoDeCaja'
GO

DELETE Funciones
 WHERE Id = 'ResumenCorporativoDeCaja'
GO
