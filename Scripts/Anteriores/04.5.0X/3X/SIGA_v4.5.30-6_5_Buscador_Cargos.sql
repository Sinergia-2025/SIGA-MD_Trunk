
DECLARE @max int
SET @max = 6

INSERT INTO Buscadores (IdBuscador,Titulo,AnchoAyuda) VALUES (@max, 'Cargos', 1000);

INSERT INTO BuscadoresCampos(IdBuscador, IdBuscadorNombreCampo, Orden, Titulo, Alineacion, Ancho, Formato) 
  VALUES
  (@max, 'IdCargo',1, 'Codigo', 64, 50,''),
  (@max, 'NombreCargo',2, 'Nombre', 16, 180,''),
  (@max, 'Monto',3, 'Monto', 64, 70,''),
  (@max, 'IdProducto',4,'Producto', 64, 80,''),
  (@max, 'NombreProducto',5, 'Nombre Producto', 16, 180,''),
  (@max, 'CantidadCuotas',6, 'Cant. Cuotas', 64, 60,''),
  (@max, 'CuotaActual',7, 'Cuota Actual', 64, 60,''),
  (@max, 'CantidadMeses',8, 'Cantidad de Meses', 64, 60,''),
  (@max, 'ModificaImporte',9, 'Modifica Importe', 32, 60,''),
  (@max, 'ModificaCantidad',10, 'Modifica Cantidad', 32, 60,''),
  (@max, 'ImprimeVoucher',11, 'Voucher', 32, 40,''),
  (@max, 'Activo',12, 'Activo', 32, 40,'')
GO
