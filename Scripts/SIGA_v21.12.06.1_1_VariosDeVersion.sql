/*
DELETE RF FROM RolesFunciones RF INNER JOIN Funciones F ON F.Id = RF.IdFuncion WHERE IdPadre = 'app.empresarial'
DELETE RF FROM RolesFunciones RF INNER JOIN Funciones F ON F.Id = RF.IdFuncion WHERE Id = 'app.empresarial'
DELETE Funciones WHERE IdPadre = 'app.empresarial'
DELETE Funciones WHERE Id = 'app.empresarial'
*/
IF dbo.SoyHAR() = 1
BEGIN
    MERGE INTO Funciones AS DEST
        USING (SELECT 'app.empresarial'    AS IdFuncion, 'Submenu App Empresarial'     AS Descripcion, NULL                AS IdPadre, 9999    AS Orden UNION ALL
               SELECT 'app.emp.pedidos'    AS IdFuncion, 'App Empresarial: Pedidos'    AS Descripcion, 'app.empresarial'   AS IdPadre, 10      AS Orden UNION ALL
               SELECT 'app.emp.cobranzas'  AS IdFuncion, 'App Empresarial: Cobranzas'  AS Descripcion, 'app.empresarial'   AS IdPadre, 20      AS Orden UNION ALL
               SELECT 'app.emp.turnos'     AS IdFuncion, 'App Empresarial: Turnos'     AS Descripcion, 'app.empresarial'   AS IdPadre, 30      AS Orden UNION ALL
               SELECT 'app.emp.ctasctes'   AS IdFuncion, 'App Empresarial: Ctas Ctes'  AS Descripcion, 'app.empresarial'   AS IdPadre, 40      AS Orden UNION ALL
               SELECT 'app.emp.productos'  AS IdFuncion, 'App Empresarial: Productos'  AS Descripcion, 'app.empresarial'   AS IdPadre, 50      AS Orden UNION ALL
               SELECT 'app.emp.crm'        AS IdFuncion, 'App Empresarial: CRM'        AS Descripcion, 'app.empresarial'   AS IdPadre, 60      AS Orden
               ) AS ORIG ON DEST.Id = ORIG.IdFuncion
    WHEN NOT MATCHED THEN 
        INSERT (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible
               ,IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros
               ,PermiteMultiplesInstancias,Plus,Express,Basica,PV,EsMDIChild)
        VALUES (ORIG.IdFuncion, ORIG.Descripcion, ORIG.Descripcion, 'False', 'False', 'True', 'True'
               ,ORIG.IdPadre, ORIG.Orden, '', '', NULL, NULL
               ,'True', 'X', 'N', 'N', 'N', 'True')
    ;

    MERGE INTO RolesFunciones AS DEST
        USING (SELECT DISTINCT R.Id AS Rol, F.Id
                 FROM dbo.Roles R
                CROSS JOIN (SELECT * FROM Funciones WHERE Plus = 'X') F
                WHERE R.Id IN ('Adm', 'Supervisor', 'Oficina')
               ) ORIG ON ORIG.Rol = DEST.IdRol AND ORIG.Id = DEST.IdFuncion
    WHEN NOT MATCHED THEN 
        INSERT (IdRol, IdFuncion) VALUES (ORIG.Rol, ORIG.Id)
	;
    UPDATE Funciones SET Plus = 'S' WHERE Plus = 'X';

END
