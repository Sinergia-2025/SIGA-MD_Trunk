
ALTER TABLE Ventas DROP CONSTRAINT FK_Ventas_IdFuncion;

ALTER TABLE Ventas DROP COLUMN MetodoGrabacion;

ALTER TABLE Ventas DROP COLUMN IdFuncion;

ALTER TABLE CuentasCorrientes DROP CONSTRAINT FK_CuentasCorrientes_IdFuncion;

ALTER TABLE CuentasCorrientes DROP COLUMN MetodoGrabacion;

ALTER TABLE CuentasCorrientes DROP COLUMN IdFuncion;

