Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class ImprimirMovimientoStock
   Public Sub Imprimir(ByVal oMov As Entidades.MovimientoStock)

      'cambio los valores porque se graban segun corresponde, ej: Mota de credito u otro tipo que necesite grabarlo en forma negativa
      Dim coe As Integer = oMov.TipoMovimiento.CoeficienteStock

      Dim cabecera As System.Text.StringBuilder = New System.Text.StringBuilder()

      Dim prod As DataTable = New DataTable()
      prod.Columns.Add(New DataColumn("IdProducto", GetType(String)))
      prod.Columns.Add(New DataColumn("Cantidad", GetType(Decimal)))
      prod.Columns.Add(New DataColumn("Precio", GetType(Decimal)))
      prod.Columns.Add(New DataColumn("IdSucursal", GetType(Integer)))
      prod.Columns.Add(New DataColumn("IdTipoMovimiento", GetType(String)))
      prod.Columns.Add(New DataColumn("NumeroMovimiento", GetType(Integer)))
      prod.Columns.Add(New DataColumn("NombreProducto", GetType(String)))
      prod.Columns.Add(New DataColumn("NrosSerie", GetType(String)))
      prod.Columns.Add(New DataColumn("NombreUbicacion", GetType(String)))
      prod.Columns.Add(New DataColumn("NombreDeposito", GetType(String)))

      Dim dr As DataRow
      For Each pr In oMov.Productos
         dr = prod.NewRow()

         dr("IdProducto") = pr.IdProducto
         If pr.CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE Then
            dr("Cantidad") = pr.Cantidad * coe
         Else
            dr("Cantidad") = pr.Cantidad * coe
         End If
         dr("Precio") = pr.Precio
         dr("IdSucursal") = pr.MovimientoStock.Sucursal.Id
         dr("IdTipoMovimiento") = pr.MovimientoStock.TipoMovimiento.IdTipoMovimiento
         dr("NumeroMovimiento") = pr.MovimientoStock.NumeroMovimiento

         '-- REQ-35143.- ------------------------------------------------------------
         Dim descAtr = pr.ConcatenaAtributos()
         If Not String.IsNullOrWhiteSpace(descAtr) Then
            pr.NombreProducto = String.Format("{0} ({1})", pr.NombreProducto, descAtr)
         End If
         '-----------------------------------------------------------------------------

         If Reglas.Publicos.Compras.ComprasImpresionVisualizaNrosSerie Then
            Dim NumerosSerie As String = String.Empty
            'If pr.ProductoSucursal.Producto.NrosSeries.Count <> 0 Then
            If pr.ProductosNrosSerie.Count <> 0 Then
               Dim cant As Integer = 1
               For Each ns In pr.ProductosNrosSerie
                  If pr.ProductosNrosSerie.Count <> cant Then
                     NumerosSerie += ns.NroSerie & " // "
                     cant += 1
                  Else
                     NumerosSerie += ns.NroSerie
                  End If

               Next
               dr("NombreProducto") = pr.NombreProducto & " (" & NumerosSerie & ")"
            Else
               dr("NombreProducto") = pr.NombreProducto
            End If
         Else
            dr("NombreProducto") = pr.NombreProducto
         End If
         If oMov.TipoMovimiento.AsociaSucursal Then
            dr("NombreDeposito") = pr.NombreDeposito + " a " + pr.NombreDeposito2
            dr("NombreUbicacion") = pr.NombreUbicacion + " a " + pr.NombreUbicacion2
         Else
            dr("NombreDeposito") = pr.NombreDeposito
            dr("NombreUbicacion") = pr.NombreUbicacion
         End If

         prod.Rows.Add(dr)
      Next

      If oMov.TipoMovimiento.AsociaSucursal Then
         cabecera.AppendFormatLine("Sucursal origen: {0}", oMov.Sucursal.Nombre)
         cabecera.AppendLine()
         cabecera.AppendFormatLine("Sucursal destino: {0}", oMov.Sucursal2.Nombre)
      End If

      If oMov.TipoMovimiento.HabilitaEmpleado Then
         If cabecera.Length > 0 Then
            cabecera.AppendLine()
         End If
         cabecera.AppendFormat("Empleado - {0}", oMov.NombreEmpleado)
      End If

      If cabecera.Length = 0 Then
         cabecera.Append(" ")
      End If

      Dim parm As List(Of Microsoft.Reporting.WinForms.ReportParameter) = New List(Of Microsoft.Reporting.WinForms.ReportParameter)
      parm.Clear()
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", oMov.FechaMovimiento.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoMovimiento", oMov.TipoMovimiento.Descripcion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cabecera", cabecera.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", oMov.Observacion))

      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.MovimientoDeStock.rdlc", "SistemaDataSet_MovimientosComprasProductos", prod, parm, True, 1) '# 1 = Cantidad Copias
      frmImprime.Text = oMov.TipoMovimiento.Descripcion
      frmImprime.StartPosition = FormStartPosition.CenterScreen
      frmImprime.Show()

   End Sub
End Class