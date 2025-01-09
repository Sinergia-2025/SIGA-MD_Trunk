 
--Inserto la pantalla nueva a partir de la anterior, en la misma posicion

INSERT INTO Funciones
           (Id,Nombre,Descripcion,EsMenu,EsBoton,[Enabled],Visible
           ,IdPadre,Posicion,Archivo,Pantalla,Icono)
(
SELECT 'InformeChequesPropios', 'Informe de Cheques Propios', 'Informe de Cheques Propios', EsMenu, EsBoton, [Enabled],
        Visible, IdPadre, Posicion, Archivo, 'InformeChequesPropios', Icono
 FROM Funciones           
 WHERE Id = 'ChequesPropiosInf'
)
GO


UPDATE RolesFunciones 
  SET IdFuncion = 'InformeChequesPropios'
 WHERE IdFuncion = 'ChequesPropiosInf'
GO

DELETE Funciones
 WHERE Id = 'ChequesPropiosInf'
GO
