
INSERT INTO Funciones
        (Id, Nombre, Descripcion, EsMenu, EsBoton, [Enabled], Visible,
         IdPadre, Posicion, Archivo, Pantalla, Icono, Parametros,
         PermiteMultiplesInstancias,Plus,Express,Basica,PV)
    VALUES
        ('InfCCDetClientesCobranzaYDeuda', 'Informe de Cta. Cte. Detalle de Clientes - Cobranza y Deuda', 'Informe de Cta. Cte. Detalle de Clientes - Cobranza y Deuda', 'True', 'False', 'True', 'True', 
         'CuentasCorrientes', 56, 'Eniac.Win', 'InfCCDetClientesCobranzaYDeuda', NULL, NULL,
         'True', 'S', 'N', 'N', 'N')
;

INSERT INTO RolesFunciones (IdRol, IdFuncion)
SELECT DISTINCT Id AS Rol, 'InfCCDetClientesCobranzaYDeuda' AS Pantalla FROM Roles
    WHERE Id IN ('Adm', 'Supervisor', 'Oficina', 'Soporte')
;
