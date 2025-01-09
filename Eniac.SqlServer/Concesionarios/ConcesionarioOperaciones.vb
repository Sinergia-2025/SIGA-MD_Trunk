Public Class ConcesionarioOperaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ConcesionarioOperaciones_I(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer, codigoOperacion As String,
                                         fechaOperacion As Date, cotizacionDolar As Decimal, idCliente As Long,
                                         tipoOperacion As Entidades.ConcesionarioTipoOperacion,
                                         idProductoCeroKilometro As String, cantidadCeroKilometro As Decimal?, precioCeroKilometro As Decimal?, importeCeroKilometro As Decimal?,
                                         patenteVehiculoUsado As String, precioListaUsado As Decimal?, importeUsado As Decimal?,
                                         idTipoUnidad As Integer, idSubTipoUnidad As Integer, idEje As Integer, caracteristicaAdicional As String,
                                         largo As String, altoCarga As String, altoPuertgaLateral As String,
                                         colorCarroceria As String, colorZocalo As String, colorBase As String,
                                         puertaTrasera As Entidades.ConcesionarioPuertaTrasera?,
                                         parante As Entidades.ConcesionarioParante?, piso As Entidades.ConcesionarioPiso?,
                                         marco As Entidades.Publicos.SiNo?, herraje As Entidades.ConcesionarioHerraje?,
                                         otrasObservaciones As String,
                                         importeTotalAdicionales As Decimal, importeTotalCaracteristicas As Decimal, importeTotal As Decimal,
                                         importePesos As Decimal, importeTarjetas As Decimal, importeCheques As Decimal,
                                         importeTransferencia As Decimal, fechaTransferencia As Date?, idCuentaBancaria As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0} (", Entidades.ConcesionarioOperacion.NombreTabla)
         .AppendFormatLine("       {0}", Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.CodigoOperacion.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.FechaOperacion.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.CotizacionDolar.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.IdCliente.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.TipoOperacion.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.IdProductoCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.CantidadCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.PrecioCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteCeroKilometro.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.PatenteVehiculoUsado.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.PrecioListaUsado.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteUsado.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.IdTipoUnidadCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.IdSubTipoUnidadCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.IdEjeCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.CaracteristicaAdicionalCeroKilometro.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.LargoCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.AltoCargaCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.AltoPuertaLateralCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ColorCarroceriaCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ColorZocaloCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ColorBaseCeroKilometro.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.PuertaTraseraCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ParanteCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.PisoCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.MarcoCeroKilometro.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.HerrajeCeroKilometro.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.OtrasObservacionesCeroKilometro.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteTotalAdicionales.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteTotalCaracteristicas.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteTotal.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImportePesos.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteTarjetas.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteCheques.ToString())

         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.ImporteTransferencia.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.FechaTransferencia.ToString())
         .AppendFormatLine("     , {0}", Entidades.ConcesionarioOperacion.Columnas.IdCuentaBancaria.ToString())

         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idMarca)
         .AppendFormatLine("     ,  {0} ", anioOperacion)
         .AppendFormatLine("     ,  {0} ", numeroOperacion)
         .AppendFormatLine("     ,  {0} ", secuenciaOperacion)
         .AppendFormatLine("     , '{0}'", codigoOperacion)

         .AppendFormatLine("     , '{0}'", ObtenerFecha(fechaOperacion, False))
         .AppendFormatLine("     ,  {0} ", cotizacionDolar)
         .AppendFormatLine("     ,  {0} ", idCliente)
         .AppendFormatLine("     , '{0}'", tipoOperacion.ToString())

         .AppendFormatLine("     ,  {0} ", GetStringParaQueryConComillas(idProductoCeroKilometro))
         .AppendFormatLine("     ,  {0} ", GetStringFromDecimal(cantidadCeroKilometro))
         .AppendFormatLine("     ,  {0} ", GetStringFromDecimal(precioCeroKilometro))
         .AppendFormatLine("     ,  {0} ", GetStringFromDecimal(importeCeroKilometro))

         .AppendFormatLine("     ,  {0} ", GetStringParaQueryConComillas(patenteVehiculoUsado))
         .AppendFormatLine("     ,  {0} ", GetStringFromDecimal(precioListaUsado))
         .AppendFormatLine("     ,  {0} ", GetStringFromDecimal(importeUsado))

         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idTipoUnidad))
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idSubTipoUnidad))
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idEje))
         .AppendFormatLine("     , '{0}'", caracteristicaAdicional)

         .AppendFormatLine("     , '{0}'", largo)
         .AppendFormatLine("     , '{0}'", altoCarga)
         .AppendFormatLine("     , '{0}'", altoPuertgaLateral)
         .AppendFormatLine("     , '{0}'", colorCarroceria)
         .AppendFormatLine("     , '{0}'", colorZocalo)
         .AppendFormatLine("     , '{0}'", colorBase)

         .AppendFormatLine("     , '{0}'", If(puertaTrasera.HasValue, puertaTrasera.Value.ToString(), String.Empty))
         .AppendFormatLine("     , '{0}'", If(parante.HasValue, parante.Value.ToString(), String.Empty))
         .AppendFormatLine("     , '{0}'", If(piso.HasValue, piso.Value.ToString(), String.Empty))
         .AppendFormatLine("     , '{0}'", If(marco.HasValue, marco.Value.ToString(), String.Empty))
         .AppendFormatLine("     , '{0}'", If(herraje.HasValue, herraje.Value.ToString(), String.Empty))

         .AppendFormatLine("     , '{0}'", otrasObservaciones)


         .AppendFormatLine("     ,  {0} ", importeTotalAdicionales)
         .AppendFormatLine("     ,  {0} ", importeTotalCaracteristicas)
         .AppendFormatLine("     ,  {0} ", importeTotal)

         .AppendFormatLine("     ,  {0} ", importePesos)
         .AppendFormatLine("     ,  {0} ", importeTarjetas)
         .AppendFormatLine("     ,  {0} ", importeCheques)

         .AppendFormatLine("     ,  {0} ", importeTransferencia)
         .AppendFormatLine("     ,  {0} ", ObtenerFecha(fechaTransferencia, True))
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idCuentaBancaria))

         .AppendFormatLine(" )")

      End With
      Execute(query)
   End Sub
   'UPDATE
   Public Sub ConcesionarioOperaciones_U(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer, codigoOperacion As String,
                                         fechaOperacion As Date, cotizacionDolar As Decimal, idCliente As Long,
                                         tipoOperacion As Entidades.ConcesionarioTipoOperacion,
                                         idProductoCeroKilometro As String, cantidadCeroKilometro As Decimal?, precioCeroKilometro As Decimal?, importeCeroKilometro As Decimal?,
                                         patenteVehiculoUsado As String, precioListaUsado As Decimal?, importeUsado As Decimal?,
                                         idTipoUnidad As Integer, idSubTipoUnidad As Integer, idEje As Integer, caracteristicaAdicional As String,
                                         largo As String, altoCarga As String, altoPuertgaLateral As String,
                                         colorCarroceria As String, colorZocalo As String, colorBase As String,
                                         puertaTrasera As Entidades.ConcesionarioPuertaTrasera?,
                                         parante As Entidades.ConcesionarioParante?, piso As Entidades.ConcesionarioPiso?,
                                         marco As Entidades.Publicos.SiNo?, herraje As Entidades.ConcesionarioHerraje?,
                                         otrasObservaciones As String,
                                         importeTotalAdicionales As Decimal, importeTotalCaracteristicas As Decimal, importeTotal As Decimal,
                                         importePesos As Decimal, importeTarjetas As Decimal, importeCheques As Decimal,
                                         importeTransferencia As Decimal, fechaTransferencia As Date?, idCuentaBancaria As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioOperacion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.FechaOperacion.ToString(), ObtenerFecha(fechaOperacion, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.CotizacionDolar.ToString(), cotizacionDolar)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdCliente.ToString(), idCliente)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.TipoOperacion.ToString(), tipoOperacion.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdProductoCeroKilometro.ToString(), GetStringParaQueryConComillas(idProductoCeroKilometro))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.CantidadCeroKilometro.ToString(), GetStringFromDecimal(cantidadCeroKilometro))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.PrecioCeroKilometro.ToString(), GetStringFromDecimal(precioCeroKilometro))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteCeroKilometro.ToString(), GetStringFromDecimal(importeCeroKilometro))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.PatenteVehiculoUsado.ToString(), GetStringParaQueryConComillas(patenteVehiculoUsado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.PrecioListaUsado.ToString(), GetStringFromDecimal(precioListaUsado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteUsado.ToString(), GetStringFromDecimal(importeUsado))

         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdTipoUnidadCeroKilometro.ToString(), GetStringFromNumber(idTipoUnidad))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdSubTipoUnidadCeroKilometro.ToString(), GetStringFromNumber(idSubTipoUnidad))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdEjeCeroKilometro.ToString(), GetStringFromNumber(idEje))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.CaracteristicaAdicionalCeroKilometro.ToString(), caracteristicaAdicional)

         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.LargoCeroKilometro.ToString(), largo.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.AltoCargaCeroKilometro.ToString(), altoCarga.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.AltoPuertaLateralCeroKilometro.ToString(), altoPuertgaLateral.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.ColorCarroceriaCeroKilometro.ToString(), colorCarroceria.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.ColorZocaloCeroKilometro.ToString(), colorZocalo.ToString())
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.ColorBaseCeroKilometro.ToString(), colorBase.ToString())

         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.PuertaTraseraCeroKilometro.ToString(), If(puertaTrasera.HasValue, puertaTrasera.Value.ToString(), String.Empty))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.ParanteCeroKilometro.ToString(), If(parante.HasValue, parante.ToString(), String.Empty))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.PisoCeroKilometro.ToString(), If(piso.HasValue, piso.ToString(), String.Empty))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.MarcoCeroKilometro.ToString(), If(marco.HasValue, marco.ToString(), String.Empty))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.HerrajeCeroKilometro.ToString(), If(herraje.HasValue, herraje.ToString(), String.Empty))

         .AppendFormatLine("     , {0} = '{1}'", Entidades.ConcesionarioOperacion.Columnas.OtrasObservacionesCeroKilometro.ToString(), otrasObservaciones)


         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteTotalAdicionales.ToString(), importeTotalAdicionales)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteTotalCaracteristicas.ToString(), importeTotalCaracteristicas)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteTotal.ToString(), importeTotal)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImportePesos.ToString(), importePesos)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteTarjetas.ToString(), importeTarjetas)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteCheques.ToString(), importeCheques)

         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.ImporteTransferencia.ToString(), importeTransferencia)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.FechaTransferencia.ToString(), ObtenerFecha(fechaTransferencia, True))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdCuentaBancaria.ToString(), GetStringFromNumber(idCuentaBancaria))


         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
      End With
      Execute(query)
   End Sub
   'DELETE
   Public Sub ConcesionarioOperaciones_D(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormat("DELETE FROM {0}", Entidades.ConcesionarioOperacion.NombreTabla)
         .AppendFormat(" WHERE {0} = {1}", Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString(), idMarca)
         .AppendFormat("   AND {0} = {1}", Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString(), anioOperacion)
         .AppendFormat("   AND {0} = {1}", Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         .AppendFormat("   AND {0} = {1}", Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
      End With
      Execute(query)
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT OP.*")
         .AppendFormatLine("     , M.{0}", Entidades.Marca.Columnas.NombreMarca.ToString())
         .AppendFormatLine("     , C.{0}", Entidades.Cliente.Columnas.CodigoCliente.ToString())
         .AppendFormatLine("     , C.{0}", Entidades.Cliente.Columnas.NombreCliente.ToString())
         .AppendFormatLine("     , C.{0}", Entidades.Cliente.Columnas.NombreDeFantasia.ToString())
         .AppendFormatLine("     , P.{0}", Entidades.Producto.Columnas.NombreProducto.ToString())
         .AppendFormatLine("     , CTU.{0}", Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString())
         .AppendFormatLine("     , CSTU.{0}", Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString())
         .AppendFormatLine("     , CE.{0}", Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString())
         .AppendFormatLine("     , CB.{0}", Entidades.CuentaBancaria.Columnas.CodigoBancario.ToString())
         .AppendFormatLine("     , CB.{0}", Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString())
         .AppendFormatLine("     , B.NombreBanco")
         .AppendFormatLine("  FROM {0} AS OP", Entidades.ConcesionarioOperacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN Marcas M ON M.IdMarca = OP.IdMarca")
         .AppendFormatLine(" INNER JOIN Clientes C ON C.IdCliente = OP.IdCliente")
         .AppendFormatLine("  LEFT JOIN Productos P ON P.IdProducto = OP.IdProductoCeroKilometro")
         .AppendFormatLine("  LEFT JOIN ConcesionarioTiposUnidades CTU ON CTU.IdTipoUnidad = OP.IdTipoUnidadCeroKilometro")
         .AppendFormatLine("  LEFT JOIN ConcesionarioSubTiposUnidades CSTU ON CSTU.IdSubTipoUnidad = OP.IdSubTipoUnidadCeroKilometro")
         .AppendFormatLine("  LEFT JOIN ConcesionarioDistribucionEjes CE ON CE.IdEje = OP.IdEjeCeroKilometro")
         .AppendFormatLine("  LEFT JOIN CuentasBancarias CB on CB.IdCuentaBancaria = OP.IdCuentaBancaria")
         .AppendFormatLine("  LEFT JOIN Bancos B ON B.IdBanco = CB.IdBanco")
      End With
   End Sub

   'G
   Private Function ConcesionarioOperaciones_G(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idMarca > 0 Then
            .AppendFormatLine("   AND OP.{0} = {1}", Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString(), idMarca)
         End If

         If anioOperacion > 0 Then
            .AppendFormatLine("   AND OP.{0} = {1}", Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString(), anioOperacion)
         End If

         If numeroOperacion > 0 Then
            .AppendFormatLine("   AND OP.{0} = {1}", Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString(), numeroOperacion)
         End If

         If secuenciaOperacion > 0 Then
            .AppendFormatLine("   AND OP.{0} = {1}", Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString(), secuenciaOperacion)
         End If

      End With
      Return GetDataTable(query)
   End Function

   'GA
   Public Function ConcesionarioOperaciones_GA() As DataTable
      Return ConcesionarioOperaciones_G(idMarca:=0, anioOperacion:=0, numeroOperacion:=0, secuenciaOperacion:=0)
   End Function

   'G1
   Public Function ConcesionarioOperaciones_G1(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer, secuenciaOperacion As Integer) As DataTable
      Return ConcesionarioOperaciones_G(idMarca, anioOperacion, numeroOperacion, secuenciaOperacion)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "OP.")
   End Function

   'GET CODIGO MAXIMO
   Public Overloads Function GetNumeroMaximo(idMarca As Integer, anioOperacion As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString(), Entidades.ConcesionarioOperacion.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = {3}",
                                                           Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString(), idMarca,
                                                           Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString(), anioOperacion)))
   End Function
   Public Overloads Function GetSecuenciaMaxima(idMarca As Integer, anioOperacion As Integer, numeroOperacion As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ConcesionarioOperacion.Columnas.SecuenciaOperacion.ToString(), Entidades.ConcesionarioOperacion.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = {3} AND {4} = {5}",
                                                           Entidades.ConcesionarioOperacion.Columnas.IdMarca.ToString(), idMarca,
                                                           Entidades.ConcesionarioOperacion.Columnas.AnioOperacion.ToString(), anioOperacion,
                                                           Entidades.ConcesionarioOperacion.Columnas.NumeroOperacion.ToString(), numeroOperacion)))
   End Function
End Class