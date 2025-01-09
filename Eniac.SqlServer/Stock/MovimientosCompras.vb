<Obsolete("Se reemplaza por MovimientosStock", True)>
Public Class MovimientosCompras
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovimientosCompras_I(idSucursal As Integer,
                                   idTipoMovimiento As String,
                                   numeroMovimiento As Long,
                                   fechaMovimiento As DateTime,
                                   total As Double,
                                   porcentajeIVA As Double,
                                   IdProveedor As Long,
                                   idCategoriaFiscal As Short,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroComprobante As Long,
                                   idSucursal2 As Long,
                                   usuario As String,
                                   observacion As String,
                                   percepcionIVA As Decimal,
                                   percepcionIB As Decimal,
                                   percepcionGanancias As Decimal,
                                   percepcionVarias As Decimal,
                                   idProduccion As Integer,
                                   IdEmpleado As Integer,
                                   impuestosInternos As Decimal)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO MovimientosCompras")
         .AppendLine("  (IdSucursal, ")
         .AppendLine("  IdTipoMovimiento, ")
         .AppendLine("  NumeroMovimiento, ")
         .AppendLine("  FechaMovimiento, ")
         .AppendLine("  Total, ")
         .AppendLine("  PorcentajeIVA, ")
         .AppendLine("  IdProveedor,  ")
         .AppendLine("  IdCategoriaFiscal, ")
         .AppendLine("  IdTipoComprobante, ")
         .AppendLine("  Letra, ")
         .AppendLine("  CentroEmisor, ")
         .AppendLine("  NumeroComprobante, ")
         .AppendLine("  IdSucursal2,  ")
         .AppendLine("  Usuario,  ")
         .AppendLine("  Observacion,  ")
         .AppendLine("  percepcionIVA,  ")
         .AppendLine("  percepcionIB,  ")
         .AppendLine("  percepcionGanancias,  ")
         .AppendLine("  percepcionVarias,  ")
         .AppendLine("  IdProduccion  ")
         .AppendLine(" ,IdEmpleado")
         .AppendLine(" ,impuestosInternos")
         .AppendLine("  ) VALUES( ")
         .AppendLine(idSucursal & ", ")
         .AppendLine("'" & idTipoMovimiento & "', ")
         .AppendLine(numeroMovimiento & ", ")
         .AppendLine("'" & Me.ObtenerFecha(fechaMovimiento, True) & "' , ")
         .AppendLine(total.ToString() & ", ")
         .AppendLine(porcentajeIVA.ToString() & ", ")
         If IdProveedor > 0 Then
            .AppendLine(IdProveedor.ToString() & ",  ")
         Else
            .AppendLine("  null, ")
         End If
         If idCategoriaFiscal = 0 Then
            .AppendLine("  null, ")
         Else
            .AppendLine(idCategoriaFiscal & ", ")
         End If
         If String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("  null, ")
         Else
            .AppendLine("  '" & idTipoComprobante & "', ")
         End If
         If String.IsNullOrEmpty(letra) Then
            .AppendLine("  null, ")
         Else
            .AppendLine("  '" & letra & "', ")
         End If
         If centroEmisor = 0 Then
            .AppendLine("  null, ")
         Else
            .AppendLine(centroEmisor & ", ")
         End If
         If numeroComprobante = 0 Then
            .AppendLine("  null, ")
         Else
            .AppendLine(numeroComprobante & ", ")
         End If
         If idSucursal2 = 0 Then
            .AppendLine("  null, ")
         Else
            .AppendLine(idSucursal2 & ", ")
         End If
         .AppendLine("  '" & usuario & "', ")
         .AppendLine("  '" & observacion & "', ")
         .AppendFormat("    {0},", percepcionIVA)
         .AppendFormat("    {0},", percepcionIB)
         .AppendFormat("    {0},", percepcionGanancias)
         .AppendFormat("    {0},", percepcionVarias)
         If idProduccion = 0 Then
            .AppendLine("  null ")
         Else
            .AppendFormat("    {0}", idProduccion)
         End If

         If IdEmpleado > 0 Then
            .AppendFormat("   ,{0}", IdEmpleado).AppendLine()
         Else
            .AppendFormat("   ,NULL").AppendLine()
         End If
         .AppendFormat("    ,{0}", impuestosInternos)
         .AppendLine("  ) ")
      End With

      Me.Execute(myQuery.ToString())

      Me.Sincroniza_I(myQuery.ToString(), "MovimientosCompras")
   End Sub

   Public Sub MovimientosCompras_D(ByVal idSucursal As Integer,
                                            ByVal idTipoMovimiento As String,
                                            ByVal numeroMovimiento As Long)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM MovimientosCompras ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND IdTipoMovimiento = '" & idTipoMovimiento & "'")
         .AppendLine("   AND NumeroMovimiento = " & numeroMovimiento.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "MovimientosCompras")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT MC.*").AppendLine()
         .AppendFormat("  FROM MovimientosCompras AS MC").AppendLine()
         '.AppendFormat("  INNER JOIN CRMTiposNovedades TN ON TN.IdTipoNovedad = EN.IdTipoNovedad").AppendLine()
      End With
   End Sub

   Public Function MovimientosCompras_G1(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Return MovimientosCompras_G(idSucursal, idTipoMovimiento, numeroMovimiento)
   End Function

   Private Function MovimientosCompras_G(idSucursal As Integer, idTipoMovimiento As String, numeroMovimiento As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormat("   AND MC.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoMovimiento) Then
            .AppendFormat("   AND MC.IdTipoMovimiento = '{0}'", idTipoMovimiento).AppendLine()
         End If
         If numeroMovimiento <> 0 Then
            .AppendFormat("   AND MC.NumeroMovimiento = {0}", numeroMovimiento).AppendLine()
         End If
         .AppendLine(" ORDER BY MC.FechaMovimiento")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class