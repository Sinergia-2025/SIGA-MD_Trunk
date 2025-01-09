DECLARE @Funcion1 VARCHAR(MAX) = 'SubSubRubrosABM'
DECLARE @Funcion2 VARCHAR(MAX) = 'Modelos'
DECLARE @Funcion3 VARCHAR(MAX) = 'TiposMovimientosABM'

PRINT '1. Bitacora'
DELETE Bitacora
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id=@Funcion1 or IdPadre=@Funcion1
    or id=@Funcion2 or IdPadre=@Funcion2
    or id=@Funcion3 or IdPadre=@Funcion3
 )
;


PRINT ''
PRINT '2. Traducciones'
DELETE Traducciones
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id=@Funcion1 or IdPadre=@Funcion1
    or id=@Funcion2 or IdPadre=@Funcion2
    or id=@Funcion3 or IdPadre=@Funcion3
 )
;

PRINT ''
PRINT '3. RolesFunciones'
DELETE RolesFunciones 
where IdFuncion in
 (
SELECT id FROM [Funciones]
 where id=@Funcion1 or IdPadre=@Funcion1
    or id=@Funcion2 or IdPadre=@Funcion2
    or id=@Funcion3 or IdPadre=@Funcion3
 )
;

PRINT ''
PRINT '4. Funciones'
DELETE [Funciones]
 where id=@Funcion1 or IdPadre=@Funcion1
    or id=@Funcion2 or IdPadre=@Funcion2
    or id=@Funcion3 or IdPadre=@Funcion3
GO
