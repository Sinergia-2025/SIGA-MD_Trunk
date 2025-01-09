Public Class ImpresorasAComprobantesABM

#Region "Campos"

   Private _entidad As Entidades.TipoComprobanteLetra
   Private _pantallaDetalle As ImpresorasAComprobantesDetalle
   Private _reglas As Reglas.TiposComprobantesLetras

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
      SetCopiarVisible(True)
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ImpresorasAComprobantesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoComprobanteLetra))
      End If
      Return New ImpresorasAComprobantesDetalle(New Entidades.TipoComprobanteLetra)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Me._reglas = New Reglas.TiposComprobantesLetras()
      Return Me._reglas
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      MyBase.GetEntidad()

      With Me.dgvDatos.ActiveCell.Row
         Me._entidad = DirectCast(Me.GetReglas(), Reglas.TiposComprobantesLetras).GetUno(.Cells(Entidades.TipoComprobanteLetra.Columnas.IdTipoComprobante.ToString()).Value.ToString(), .Cells(Entidades.TipoComprobanteLetra.Columnas.Letra.ToString()).Value.ToString())
         Me._entidad.Usuario = actual.Sucursal.Usuario
      End With

      Return Me._entidad

   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.TiposComprobantesLetras).GetAll()
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.IdTipoComprobante.ToString()), "Tipo de Comprobante", col, 150)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.Letra.ToString()), "Letra", col, 45, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimir.ToString()), "Archivo a Imprimir", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirEmbebido.ToString()), "Imprimir Embebido", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAImprimir")), "Tipo Impresión Fiscal Archivo a Imprimir", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir.ToString()), "Desplazamiento X Archivo a Imprimir", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir.ToString()), "Desplazamiento Y Archivo a Imprimir", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimir2.ToString()), "Archivo a Imprimir 2", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirEmbebido2.ToString()), "Imprimir Embebido 2", col, 70)
         Ayudante.Grilla.FormatearColumna(.Columns(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAImprimir2")), "Tipo Impresión Fiscal Archivo a Imprimir 2", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir2.ToString()), "Desplazamiento X Archivo a Imprimir2", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir2.ToString()), "Desplazamiento Y Archivo a Imprimir2", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.NombreImpresora.ToString()), "Impresora", col, 180)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.CantidadItemsProductos.ToString()), "Cantidad de Items Productos", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.CantidadItemsObservaciones.ToString()), "Cantidad de Items Observaciones", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.Imprime.ToString()), "Imprime", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.CantidadCopias.ToString()), "Cantidad de Copias", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementario.ToString()), "Archivo a Imprimir Complementario", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAImprimirComplementarioEmbebido.ToString()), "Imprimir Complementario Embebido", col, 90)
         Ayudante.Grilla.FormatearColumna(.Columns(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAImprimirComplementario")), "Tipo Impresión Fiscal Archivo a Imprimir Complementario", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimirComplementario.ToString()), "Desplazamiento X Archivo a Imprimir Complementario", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimirComplementario.ToString()), "Desplazamiento Y Archivo a Imprimir Complementario", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportar.ToString()), "Archivo a Exportar", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportarEmbebido.ToString()), "Archivo a Exportar Embebido", col, 70)
         Ayudante.Grilla.FormatearColumna(.Columns(String.Concat(Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString(), "ArchivoAExportar")), "Tipo Impresión Fiscal Archivo a Exportar", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAExportar.ToString()), "Desplazamiento X Archivo a Exportar", col, 103, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAExportar.ToString()), "Desplazamiento Y Archivo a Exportar", col, 103, HAlign.Right)

         '# Esconder IDs
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir.ToString()), "IdTipoImpresionFiscal Archivo A Imprimir", col, 70, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir2.ToString()), "IdTipoImpresionFiscal Archivo A Imprimir2", col, 70, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimirComplementario.ToString()), "IdTipoImpresionFiscal Archivo A Imprimir Complementario", col, 70, HAlign.Right, True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAExportar.ToString()), "IdTipoImpresionFiscal Archivo A Exportar", col, 70, HAlign.Right, True)

         '# Filtro en Linea
         Me.dgvDatos.AgregarFiltroEnLinea({"IdTipoComprobante", "ArchivoAImprimir", "ArchivoAImprimir2", "ArchivoAImprimirComplementario", "ArchivoAExportar"})
      End With

   End Sub

#End Region

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveRow IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim rTiposComprobantesLetras As Reglas.TiposComprobantesLetras = DirectCast(Me.GetReglas(), Reglas.TiposComprobantesLetras)
               Me._entidad = DirectCast(Me.GetEntidad(), Entidades.TipoComprobanteLetra)
               rTiposComprobantesLetras.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            ShowMessage("No se puede eliminar porque esta siendo utilizado.")
         Else
            ShowError(ex)
         End If
      End Try
   End Sub

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            Dim colorColumnKey As String = Entidades.CajaNombre.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class