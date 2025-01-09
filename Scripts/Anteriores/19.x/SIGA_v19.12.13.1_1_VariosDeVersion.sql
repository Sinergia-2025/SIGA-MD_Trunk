INSERT INTO [Funciones]
           ([Id],[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
           ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono],[Parametros]
           ,[PermiteMultiplesInstancias],[Plus],[Express],[Basica],[PV],[IdModulo])
SELECT 'OrganizarEntregasV2',[Nombre],[Descripcion],[EsMenu],[EsBoton],[Enabled],[Visible]
      ,[IdPadre],[Posicion],[Archivo],[Pantalla],[Icono],[Parametros]
      ,[PermiteMultiplesInstancias],[Plus],[Express],[Basica],[PV],[IdModulo]
  FROM Funciones
 WHERE Id = 'Organizar Entregas (V2)'

UPDATE RolesFunciones
   SET IdFuncion = 'OrganizarEntregasV2'
 WHERE IdFuncion = 'Organizar Entregas (V2)'

UPDATE Bitacora
   SET IdFuncion = 'OrganizarEntregasV2'
 WHERE IdFuncion = 'Organizar Entregas (V2)'

UPDATE Ventas
   SET IdFuncion = 'OrganizarEntregasV2'
 WHERE IdFuncion = 'Organizar Entregas (V2)'

UPDATE CuentasCorrientes
   SET IdFuncion = 'OrganizarEntregasV2'
 WHERE IdFuncion = 'Organizar Entregas (V2)'

DELETE [Funciones]
 WHERE Id = 'Organizar Entregas (V2)'


IF dbo.ExisteFuncion('FacturacionV2') = 'True'
BEGIN
    INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
        ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
        ,PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('FacturacionV2-VerRecargoVenta', 'Facturacion: Ver Recargo Ventas', 'Facturacion: Ver Recargo Ventas', 'True', 'False', 'True', 'True'
        ,'FacturacionV2', 999, NULL, NULL, NULL, NULL
        ,'True', 'S', 'N', 'N', 'N')
   
	--INSERT INTO RolesFunciones (IdRol,IdFuncion)
	--SELECT DISTINCT Id AS Rol, 'EmpresasABM' AS Pantalla FROM dbo.Roles
	-- WHERE Id IN ('Adm', 'Supervisor', 'Oficina')
END
