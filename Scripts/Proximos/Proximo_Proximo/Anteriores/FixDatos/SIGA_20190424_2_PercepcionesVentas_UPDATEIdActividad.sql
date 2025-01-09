UPDATE PercepcionVentas 
   SET IdActividad = CA.IdActividad
  FROM PercepcionVentas PV 
 INNER JOIN Actividades A ON A.Porcentaje = PV.Alicuota
 INNER JOIN Clientes C ON C.IdCliente = PV.IdCliente
 INNER JOIN ClientesActividades CA ON CA.IdCliente = C.IdCliente AND CA.IdActividad = A.IdActividad
 WHERE ISNULL(PV.IdActividad, 0) = 0
