

-- CREO LOS NUEVOS ESTADOS MAS ESPACIADO PARA FUTURAS SITUACIONES.

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (10, 'Devuelto')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (20, 'Service')
GO

-- ESTADO NUEVO.
INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (25, 'Trabajando')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (30, 'Reparado')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (40, 'No reparado')
GO

INSERT INTO RecepcionEstados (IdEstado, NombreEstado) VALUES (50, 'Entregado')
GO

-- ACTUALIZO LOS REGISTROS ACTUALES.
UPDATE RecepcionNotasEstados SET IdEstado = IdEstado*10
GO

-- BORRO LOS ESTADOS VIEJOS
DELETE RecepcionEstados WHERE IdEstado BETWEEN 1 AND 5
GO

