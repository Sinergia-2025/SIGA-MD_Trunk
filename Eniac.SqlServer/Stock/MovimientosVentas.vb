<Obsolete("Se reemplaza por MovimientosStock", True)>
Public Class MovimientosVentas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosVentas_I(ByVal IdSucursal As Integer,
                                    ByVal IdTipoMovimiento As String,
                                    ByVal NumeroMovimiento As Long,
                                    ByVal FechaMovimiento As DateTime,
                                    ByVal Neto As Decimal,
                                    ByVal Total As Decimal,
                                    ByVal IdCategoriaFiscal As Short,
                                    ByVal IdTipoComprobante As String,
                                    ByVal Letra As String,
                                    ByVal CentroEmisor As Integer,
                                    ByVal NumeroComprobante As Long,
                                    ByVal Usuario As String,
                                    ByVal Observacion As String,
                                    ByVal TotalImpuestos As Decimal,
                                    ByVal IdCliente As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("INSERT INTO MovimientosVentas (")
         .Append("           IdSucursal")
         .Append("           ,IdTipoMovimiento")
         .Append("           ,NumeroMovimiento")
         .Append("           ,FechaMovimiento")
         .Append("           ,Neto")
         .Append("           ,Total")
         .Append("           ,IdCategoriaFiscal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,Usuario")
         .Append("           ,Observacion")
         .Append("           ,TotalImpuestos")
         .Append("           ,IdCliente")

         .Append(")     VALUES(")
         .AppendFormat("           {0}", IdSucursal)
         .AppendFormat("           ,'{0}'", IdTipoMovimiento)
         .AppendFormat("           ,{0}", NumeroMovimiento)
         .AppendFormat("           ,'{0}'", FechaMovimiento.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("           ,{0}", Neto)
         .AppendFormat("           ,{0}", Total)
         If IdCategoriaFiscal = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdCategoriaFiscal)
         End If
         If String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", IdTipoComprobante)
         End If
         If String.IsNullOrEmpty(Letra) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", Letra)
         End If
         .AppendFormat("           ,{0}", CentroEmisor)
         .AppendFormat("           ,{0}", NumeroComprobante)
         .AppendFormat("           ,'{0}'", Usuario)
         If String.IsNullOrEmpty(Observacion) Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,'{0}'", Observacion)
         End If
         .AppendFormat("           ,{0}", TotalImpuestos)

         If IdCliente = 0 Then
            .AppendFormat("           ,null")
         Else
            .AppendFormat("           ,{0}", IdCliente)
         End If

         .Append(")")
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosVentas")
   End Sub

   Public Sub MovimientosVentas_U(ByVal IdSucursal As Integer,
                                  ByVal IdTipoMovimiento As String,
                                  ByVal NumeroMovimiento As Long,
                                  ByVal FechaMovimiento As DateTime,
                                  ByVal Neto As Decimal,
                                  ByVal Total As Decimal,
                                  ByVal IdCategoriaFiscal As Short,
                                  ByVal IdTipoComprobante As String,
                                  ByVal Letra As String,
                                  ByVal CentroEmisor As Integer,
                                  ByVal NumeroComprobante As Long,
                                  ByVal Usuario As String,
                                  ByVal Observacion As String,
                                  ByVal TotalImpuestos As Decimal,
                                   ByVal IdCliente As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("UPDATE MovimientosVentas SET ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      ,IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      ,NumeroMovimiento = {0}", NumeroMovimiento)
         .AppendFormat("      ,FechaMovimiento = '{0}'", FechaMovimiento.ToString("yyyyMMdd HH:mm:ss"))
         .AppendFormat("      ,Neto = {0}", Neto)
         .AppendFormat("      ,Total = {0}", Total)
         If IdCategoriaFiscal = 0 Then
            .AppendFormat("      ,IdCategoriaFiscal = null")
         Else
            .AppendFormat("      ,IdCategoriaFiscal = {0}", IdCategoriaFiscal)
         End If
         If String.IsNullOrEmpty(IdTipoComprobante) Then
            .AppendFormat("      ,IdTipoComprobante = null")
         Else
            .AppendFormat("      ,IdTipoComprobante = '{0}'", IdTipoComprobante)
         End If
         If String.IsNullOrEmpty(Letra) Then
            .AppendFormat("      ,Letra = null")
         Else
            .AppendFormat("      ,Letra = '{0}'", Letra)
         End If
         .AppendFormat("      ,CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("      ,NumeroComprobante = {0}", NumeroComprobante)
         .AppendFormat("      ,Usuario = '{0}'", Usuario)
         If String.IsNullOrEmpty(Observacion) Then
            .AppendFormat("      ,Observacion = null")
         Else
            .AppendFormat("      ,Observacion = '{0}'", Observacion)
         End If
         .AppendFormat("      ,TotalImpuestos = {0}", TotalImpuestos)
         If IdCliente = 0 Then
            .AppendFormat("      ,IdCliente = null")
         Else
            .AppendFormat("      ,IdCliente = '{0}'", IdCliente)
         End If
         .Append(" WHERE ")
         .AppendFormat("      ,IdSucursal = {0}", IdSucursal)
         .AppendFormat("      ,IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      ,NumeroMovimiento = {0}", NumeroMovimiento)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosVentas")
   End Sub

   Public Sub MovimientosVentas_D(ByVal IdSucursal As Integer, ByVal IdTipoMovimiento As String, ByVal NumeroMovimiento As Long)
      Dim qry As StringBuilder = New StringBuilder("")

      With qry
         .Append("DELETE FROM MovimientosVentas WHERE ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      AND NumeroMovimiento = {0}", NumeroMovimiento)
      End With

      Me.Execute(qry.ToString())
      Me.Sincroniza_I(qry.ToString(), "MovimientosVentas")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT ")
         .Append("           IdSucursal")
         .Append("           ,IdTipoMovimiento")
         .Append("           ,NumeroMovimiento")
         .Append("           ,FechaMovimiento")
         .Append("           ,Neto")
         .Append("           ,Total")
         .Append("           ,IdCategoriaFiscal")
         .Append("           ,IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,CentroEmisor")
         .Append("           ,NumeroComprobante")
         .Append("           ,Usuario")
         .Append("           ,Observacion")
         .Append("           ,TotalImpuestos")
         .Append("           ,IdCliente")
         .Append("  FROM MovimientosVentas")
      End With
   End Sub

   Public Function MovimientosVentas_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function MovimientosVentas_G1(ByVal IdSucursal As Integer, ByVal IdTipoMovimiento As String, ByVal NumeroMovimiento As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ")
         .AppendFormat("      IdSucursal = {0}", IdSucursal)
         .AppendFormat("      AND IdTipoMovimiento = '{0}'", IdTipoMovimiento)
         .AppendFormat("      AND NumeroMovimiento = {0}", NumeroMovimiento)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function


End Class
