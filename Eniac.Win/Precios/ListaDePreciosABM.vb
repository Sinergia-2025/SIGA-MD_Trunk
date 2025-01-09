Public Class ListaDePreciosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      dgvDatos.AgregarFiltroEnLinea({Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString(),
                                     Entidades.ListaDePrecios.Columnas.NombreCortoListaPrecios.ToString()})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ListaDePreciosDetalle(DirectCast(Me.GetEntidad(), Entidades.ListaDePrecios))
      End If
      Return New ListaDePreciosDetalle(New Entidades.ListaDePrecios())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ListasDePrecios()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes

         frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosListado.rdlc", "SistemaDataSet_ListasDePrecios", dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.ListasDePrecios().GetUno(Integer.Parse(.Cells("IdListaPrecios").Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns("IdListaPrecios").FormatearColumna("Número", col, 60, HAlign.Right)
         .Columns("NombreListaPrecios").FormatearColumna("Nombre de Lista", col, 180)
         .Columns("NombreCortoListaPrecios").FormatearColumna("Nombre Corto", col, 90)
         .Columns("FechaVigencia").FormatearColumna("Vigencia", col, 80, HAlign.Center, , "dd/MM/yyyy")

         .Columns("DescuentoRecargoPorc").FormatearColumna("D/R %", col, 70, HAlign.Right, , "N2")
         .Columns("Orden").FormatearColumna("Orden", col, 50, HAlign.Right)

         .Columns("Activa").FormatearColumna("Activa", col, 50, HAlign.Center)

         .Columns("IdFormasPago").FormatearColumna("Id Forma de Pago", col, 60, HAlign.Right, True)
         .Columns("DescripcionFormasPago").FormatearColumna("Forma de Pago", col, 180)

         .Columns("PublicarEnWeb").FormatearColumna("Publicar en Web", col, 70)

         .Columns("PermiteUtilidadEnCero").FormatearColumna("Permite Utilidad en Cero", col, 70)

      End With

   End Sub

   Protected Overrides Sub Borrar()
      'valido antes de borrar que la lista de precios no sea la Predeterminada
      Try
         Dim rLP = New Reglas.ListasDePrecios()
         rLP.VerificaPuedeBorrarListaDePrecios(dgvDatos.ActiveRow.Cells("IdListaPrecios").Value.ToString().ValorNumericoPorDefecto(-1I))

         Dim olistadeprecios As Reglas.ListasDePrecios = New Reglas.ListasDePrecios()
         Dim dt As DataTable = olistadeprecios.GetPedidosPorListaDePrecios(dgvDatos.ActiveRow.Cells("IdListaPrecios").Value.ToString().ValorNumericoPorDefecto(-1I))
         If dt.Count > 0 Then
            MessageBox.Show("No es posible inhabilitar la lista de precios porque hay Pedido/Presupuesto/s pendientes o en proceso.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
         End If

         MyBase.Borrar()
      Catch ex As Exception
         ShowError(ex)
         Exit Sub
      End Try
   End Sub

#End Region

End Class