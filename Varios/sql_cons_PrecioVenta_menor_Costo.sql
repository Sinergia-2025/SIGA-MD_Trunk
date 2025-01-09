SELECT ps.*, p.NombreProducto, m.NombreMarca, r.NombreRubro, psp.PrecioVenta 
  FROM ProductosSucursales PS, ProductosSucursalesPrecios PSP,
       Productos P, Marcas M, Rubros R
 where ps.IdSucursal = psp.IdSucursal
    and ps.idproducto = psp.idproducto
    and ps.idproducto = p.idproducto
    and p.idmarca = m.idmarca
    and p.idrubro = r.idrubro
  and ps.IdSucursal=1
  and psp.IdListaPrecios=1
  and ps.PrecioCosto>psp.PrecioVenta
 
 