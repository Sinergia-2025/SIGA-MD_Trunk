Public Class VentasTarjetas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub _Insertar(IdSucursal As Integer,
                        IdTipoComprobante As String,
                        Letra As String,
                        CentroEmisor As Integer,
                        NumeroComprobante As Long,
                        IdTarjeta As Integer,
                        IdBanco As Integer,
                        Orden As Integer,
                        Monto As Decimal,
                        Cuotas As Integer,
                        NumeroCupon As Integer,
                        NumeroLote As Integer,
                        IdTarjetaCupon As Integer)

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .Append("INSERT INTO VentasTarjetas")
         .Append("           (IdSucursal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,IdTarjeta")
         .Append("           ,IdBanco")
         .Append("           ,Orden")
         .Append("           ,Monto")
         .Append("           ,Cuotas")
         .Append("           ,NumeroCupon")
         .Append("           ,NumeroLote")
         .Append("           ,IdTarjetaCupon)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", IdSucursal)
         .AppendFormat("           ,'{0}'", IdTipoComprobante)
         .AppendFormat("           ,'{0}'", Letra)
         .AppendFormat("           ,{0}", CentroEmisor)
         .AppendFormat("           ,{0}", NumeroComprobante)
         .AppendFormat("           ,{0}", IdTarjeta)
         .AppendFormat("           ,{0}", IdBanco)
         .AppendFormat("           ,{0}", Orden)
         .AppendFormat("           ,{0}", Monto)
         .AppendFormat("           ,{0}", Cuotas)
         .AppendFormat("           ,{0}", NumeroCupon)
         .AppendFormat("           ,{0}", NumeroLote)
         .AppendFormat("           ,{0})", IdTarjetaCupon)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "VentasTarjetas")
   End Sub

   Public Sub VentasTarjetas_U(IdSucursal As Integer,
                               IdTipoComprobante As String,
                               Letra As String,
                               CentroEmisor As Integer,
                               NumeroComprobante As Long,
                               IdTarjeta As Integer,
                               IdBanco As Integer,
                               Orden As Integer,
                               Monto As Decimal,
                               Cuotas As Integer,
                               NumeroCupon As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("UPDATE VentasTarjetas")
         .Append("   SET ")
         .AppendFormat("      Monto = {0}", Monto)
         .AppendFormat("      ,Cuotas = {0}", Cuotas)
         .AppendFormat("      ,NumeroCupon = {0}", NumeroCupon)
         .AppendFormat(" WHERE ")
         .AppendFormat(" IdSucursal = {0} ", IdSucursal)
         .AppendFormat("      AND IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("      AND Letra = '{0}'", Letra)
         .AppendFormat("      AND CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("      AND NumeroComprobante = {0}", NumeroComprobante)
         .AppendFormat("      AND IdTarjeta = {0}", IdTarjeta)
         .AppendFormat("      AND IdBanco = {0}", IdBanco)
         .AppendFormat("      AND Orden = {0}", Orden)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "VentasTarjetas")
   End Sub

   Public Sub VentasTarjetas_D(idTarjetaCupon As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM VentasTarjetas")
         .AppendFormatLine(" WHERE IdTarjetaCupon = {0} ", idTarjetaCupon)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasTarjetas")
   End Sub

   Public Sub VentasTarjetas_D(IdSucursal As Integer,
                               IdTipoComprobante As String,
                               Letra As String,
                               CentroEmisor As Integer,
                               NumeroComprobante As Long,
                               IdTarjeta As Integer,
                               IdBanco As Integer,
                               Orden As Integer)

      Dim stb = New StringBuilder("")

      With stb
         .Append("DELETE FROM VentasTarjetas")
         .AppendFormat(" WHERE IdSucursal = {0} ", IdSucursal)
         .AppendFormat("   AND IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", Letra)
         .AppendFormat("   AND CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("   AND NumeroComprobante = {0}", NumeroComprobante)
         If IdTarjeta > 0 Then
            .AppendFormat("   AND IdTarjeta = {0}", IdTarjeta)
            .AppendFormat("   AND IdBanco = {0}", IdBanco)
         End If
         If Orden > 0 Then
            .AppendFormat("   AND Orden = {0}", Orden)
         End If
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "VentasTarjetas")

   End Sub

   '-- REQ-31148.- --
   Public Function VentasTarjetas_Cupon(IdSucursal As Integer,
                                        IdTipoComprobante As String,
                                        Letra As String,
                                        CentroEmisor As Integer,
                                        NumeroComprobante As Long) As DataTable

      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("          VT.IdSucursal = {0} ", IdSucursal)
         .AppendFormat("      AND VT.IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("      AND VT.Letra = '{0}'", Letra)
         .AppendFormat("      AND VT.CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("      AND VT.NumeroComprobante = {0}", NumeroComprobante)
      End With

      Return GetDataTable(stb.ToString())

   End Function

   <Obsolete("Usar VentasTarjetas_D")>
   Public Sub VentasTarjetas_D2(IdSucursal As Integer,
                              IdTipoComprobante As String,
                              Letra As String,
                              CentroEmisor As Integer,
                              NumeroComprobante As Long)
      VentasTarjetas_D(IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante, 0, 0, 0)
      'Dim stb As StringBuilder = New StringBuilder("")

      'With stb
      '   .Append("DELETE FROM VentasTarjetas")
      '   .AppendFormat(" WHERE IdSucursal = {0} ", IdSucursal)
      '   .AppendFormat("   AND IdTipoComprobante = '{0}'", IdTipoComprobante)
      '   .AppendFormat("   AND Letra = '{0}'", Letra)
      '   .AppendFormat("   AND CentroEmisor = {0}", CentroEmisor)
      '   .AppendFormat("   AND NumeroComprobante = {0}", NumeroComprobante)
      'End With

      'Me.Execute(stb.ToString())
      'Me.Sincroniza_I(stb.ToString(), "VentasTarjetas")

   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .Append("SELECT VT.IdSucursal")
         .Append("      ,VT.IdTipoComprobante")
         .Append("      ,VT.Letra")
         .Append("      ,VT.CentroEmisor")
         .Append("      ,VT.NumeroComprobante")
         .Append("      ,VT.IdTarjeta")
         .Append("      ,VT.IdBanco")
         .Append("      ,VT.Orden")
         .Append("      ,VT.Monto")
         .Append("      ,VT.Cuotas")
         .Append("      ,VT.NumeroLote") '-- REQ-31150.- -Se agrega Campo a la lista del Select-
         .Append("      ,VT.NumeroCupon")
         .Append("      ,VT.IdTarjetaCupon")
         .Append("  FROM VentasTarjetas VT ")
      End With
   End Sub

   Public Function VentasTarjetas_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function VentasTarjetas_G1(IdSucursal As Integer,
                                     IdTipoComprobante As String,
                                     Letra As String,
                                     CentroEmisor As Integer,
                                     NumeroComprobante As Long,
                                     IdTarjeta As Integer,
                                     IdBanco As Integer,
                                     Orden As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat(" VT.IdSucursal = {0} ", IdSucursal)
         .AppendFormat("      AND VT.IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("      AND VT.Letra = '{0}'", Letra)
         .AppendFormat("      AND VT.CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("      AND VT.NumeroComprobante = {0}", NumeroComprobante)
         .AppendFormat("      AND VT.IdTarjeta = {0}", IdTarjeta)
         .AppendFormat("      AND VT.IdBanco = {0}", IdBanco)
         .AppendFormat("      AND VT.Orden = {0}", Orden)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function VentasTarjetas_GxVenta(IdSucursal As Integer,
                                          IdTipoComprobante As String,
                                          Letra As String,
                                          CentroEmisor As Integer,
                                          NumeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat(" VT.IdSucursal = {0} ", IdSucursal)
         .AppendFormat("      AND VT.IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("      AND VT.Letra = '{0}'", Letra)
         .AppendFormat("      AND VT.CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("      AND VT.NumeroComprobante = {0}", NumeroComprobante)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "VT." + columna
      'If columna = "R.NombreVendedor" Then columna = "V.NombreEmpleado"
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class