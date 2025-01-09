Public Class ReservasTurismoProductosFacturacion
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
   'INSERT
   Public Sub ReservasTurismoProductosFacturacion_I(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                                    idProducto As String, orden As Integer,
                                                    cantidad As Decimal, precio As Decimal, alicuotaIVA As Decimal, importeTotal As Decimal)


      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0}", Entidades.ReservaTurismoProductoFacturacion.NombreTabla)
         .AppendFormatLine("     ( {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdSucursal.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdTipoReserva.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.Letra.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.NumeroReserva.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdProducto.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.Orden.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.Cantidad.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.Precio.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.AlicuotaIVA.ToString())
         .AppendFormatLine("     , {0}", Entidades.ReservaTurismoProductoFacturacion.Columnas.ImporteTotal.ToString())
         .AppendFormatLine("     ) VALUES ( ")
         .AppendFormatLine("        {0} ", idSucursal)
         .AppendFormatLine("     , '{0}'", idTipoReserva)
         .AppendFormatLine("     , '{0}'", letra)
         .AppendFormatLine("     ,  {0} ", centroEmisor)
         .AppendFormatLine("     ,  {0} ", numeroReserva)
         .AppendFormatLine("     , '{0}'", idProducto)
         .AppendFormatLine("     ,  {0} ", orden)
         .AppendFormatLine("     ,  {0} ", cantidad)
         .AppendFormatLine("     ,  {0} ", precio)
         .AppendFormatLine("     ,  {0} ", alicuotaIVA)
         .AppendFormatLine("     ,  {0} ", importeTotal)
         .AppendFormatLine("     )")
      End With
      Execute(query)
   End Sub
   'UPDATE
   Public Sub ReservasTurismoProductosFacturacion_U(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                                    idProducto As String, orden As Integer,
                                                    cantidad As Decimal, precio As Decimal, alicuotaIVA As Decimal, importeTotal As Decimal)
      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ReservaTurismoProductoFacturacion.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.Cantidad.ToString(), cantidad)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.Precio.ToString(), precio)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.AlicuotaIVA.ToString(), alicuotaIVA)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.ImporteTotal.ToString(), importeTotal)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoProductoFacturacion.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.NumeroReserva.ToString(), numeroReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.Orden.ToString(), orden)
      End With
      Execute(query)
   End Sub
   'DELETE
   Public Sub ReservasTurismoProductosFacturacion_D(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                                    idProducto As String, orden As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE FROM {0}", Entidades.ReservaTurismoProductoFacturacion.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdTipoReserva.ToString(), idTipoReserva)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoProductoFacturacion.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.NumeroReserva.ToString(), numeroReserva)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.ReservaTurismoProductoFacturacion.Columnas.IdProducto.ToString(), idProducto)
         End If
         If orden <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.ReservaTurismoProductoFacturacion.Columnas.Orden.ToString(), orden)
         End If
      End With
      Execute(query)
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RPF.*, P.NombreProducto")
         .AppendFormatLine("  FROM {0} AS RPF", Entidades.ReservaTurismoProductoFacturacion.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} P ON P.{1} = RPF.{2}", Entidades.Producto.NombreTabla,
                           Entidades.Producto.Columnas.IdProducto.ToString(), Entidades.ReservaTurismoProductoFacturacion.Columnas.IdProducto.ToString())
      End With
   End Sub

   'G
   Private Function ReservasTurismoProductosFacturacion_G(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                                          idProducto As String, orden As Integer) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormatLine("   AND RPF.IdSucursal = {0}", idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoReserva) Then
            .AppendFormatLine("   AND RPF.IdTipoReserva = '{0}'", idTipoReserva)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND RPF.Letra = '{0}'", letra)
         End If
         If centroEmisor > 0 Then
            .AppendFormatLine("   AND RPF.CentroEmisor = {0}", centroEmisor)
         End If
         If numeroReserva > 0 Then
            .AppendFormatLine("   AND RPF.NumeroReserva = {0}", numeroReserva)
         End If
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND RPF.IdProducto = '{0}'", idProducto)
         End If
         If orden > 0 Then
            .AppendFormatLine("   AND RPF.Orden = {0}", orden)
         End If

      End With
      Return GetDataTable(query)
   End Function

   'GA
   Public Function ReservasTurismoProductosFacturacion_GA() As DataTable
      Return ReservasTurismoProductosFacturacion_G(idSucursal:=0, idTipoReserva:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroReserva:=0,
                                                   idProducto:=String.Empty, orden:=0)
   End Function
   Public Function ReservasTurismoProductosFacturacion_GA(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long) As DataTable
      Return ReservasTurismoProductosFacturacion_G(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idProducto:=String.Empty, orden:=0)
   End Function

   'G1
   Public Function ReservasTurismoProductosFacturacion_G1(idSucursal As Integer, idTipoReserva As String, letra As String, centroEmisor As Short, numeroReserva As Long,
                                                          idProducto As String, orden As Integer) As DataTable
      Return ReservasTurismoProductosFacturacion_G(idSucursal, idTipoReserva, letra, centroEmisor, numeroReserva, idProducto, orden)
   End Function

   'BUSCAR
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "RPF.")
   End Function

End Class