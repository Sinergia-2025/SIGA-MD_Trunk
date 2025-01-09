PRINT ''
PRINT '1. Tabla CuentasBancariasClase: Creo Registros de Tarjeta de Credito y Fondo de Inversion.'
GO

INSERT INTO CuentasBancariasClase
           (IdCuentaBancariaClase, NombreCuentaBancariaClase)
     VALUES
           (3, 'Tarjeta de Credito'),
           (4, 'Fondo de Inversion'),
           (5, 'Cuenta Unica'),
           (6, 'Plazo Fijo'),
           (7, 'Bonos'),
           (8, 'Acciones')
GO
