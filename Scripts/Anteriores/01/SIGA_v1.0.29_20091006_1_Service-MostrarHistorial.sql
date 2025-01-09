
ALTER TABLE RecepcionNotas ADD Usuario varchar(50) NULL
GO
UPDATE RecepcionNotas SET Usuario='Admin' WHERE Usuario IS NULL
GO
ALTER TABLE RecepcionNotas ALTER COLUMN Usuario varchar(50) NOT NULL
GO

ALTER TABLE RecepcionNotasEstados ADD Usuario varchar(50) NULL
GO
UPDATE RecepcionNotasEstados SET Usuario='Admin' WHERE Usuario IS NULL
GO
ALTER TABLE RecepcionNotasEstados ALTER COLUMN Usuario varchar(50) NOT NULL
GO


ALTER TABLE RecepcionNotasProveedores ADD Usuario varchar(50) NULL
GO
UPDATE RecepcionNotasProveedores SET Usuario='Admin' WHERE Usuario IS NULL
GO
ALTER TABLE RecepcionNotasProveedores ALTER COLUMN Usuario varchar(50) NOT NULL
GO
