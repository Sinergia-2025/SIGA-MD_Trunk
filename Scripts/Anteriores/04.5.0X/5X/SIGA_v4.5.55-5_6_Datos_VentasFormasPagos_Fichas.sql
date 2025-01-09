
-- Si tiene la pantalla de FichasABM2
IF EXISTS (SELECT * FROM Funciones F
            INNER JOIN RolesFunciones RF ON RF.IdFuncion = F.Id
            WHERE F.Id = 'FichasABM2')
BEGIN
    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (5, 'Mensual', 30, 'False', 0, 0, 1);

    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (6, 'Quincenal', 15, 'False', 0, 0, 2);

    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (7, 'Semanal', 7, 'False', 0, 0, 3);

    INSERT INTO VentasFormasPago (IdFormasPago,DescripcionFormasPago,Dias,EsTarjeta,OrdenVentas,OrdenCompras,OrdenFichas)
                          VALUES (8, 'Diario', 1, 'False', 0, 0, 4);

    UPDATE VentasFormasPago SET OrdenFichas = 5 WHERE Dias = 0;
END
