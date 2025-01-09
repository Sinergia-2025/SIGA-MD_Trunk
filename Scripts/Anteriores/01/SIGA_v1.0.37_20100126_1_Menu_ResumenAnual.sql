
--Inserto la pantalla nueva a partir de la anterior, en la misma posicion

INSERT INTO Funciones
           (Id,Nombre,Descripcion,EsMenu,EsBoton,[Enabled],Visible
           ,IdPadre,Posicion,Archivo,Pantalla,Icono)
(
SELECT 'ResumenAnual','Resumen Anual','Resumen Anual',EsMenu,EsBoton,[Enabled],Visible
           ,IdPadre,Posicion,Archivo,'ResumenAnual',Icono
 FROM Funciones           
 WHERE Id = 'ResumenCorporativo'
)
GO


UPDATE RolesFunciones 
  SET IdFuncion = 'ResumenAnual'
 WHERE IdFuncion = 'ResumenCorporativo'
GO

DELETE Funciones
 WHERE Id = 'ResumenCorporativo'
GO
