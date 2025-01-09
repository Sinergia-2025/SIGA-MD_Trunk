Option Strict On
Option Explicit On

Imports Infragistics.Win.UltraWinGrid

Public Class GenerarAsientoHistorialVincular

   Public Property IdEjercicio As Integer
   Public Property IdPlanCuenta As Integer
   Public Property IdAsiento As Integer

   Private _publicos As Publicos
   Private _publicosContabilidad As ContabilidadPublicos

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      If _datos IsNot Nothing Then
         _publicos = New Publicos()
         Me._publicosContabilidad = New ContabilidadPublicos()

         Me._publicosContabilidad.CargaComboPlanes(Me.cmbPlan, False)
         cmbPlan.SelectedIndex = 0

         Dim dt As DataTable = _datos.dr.Table.Clone()
         dt.ImportRow(_datos.dr)
         ugMovimiento.DataSource = dt
         _datos.Formatear.Invoke(ugMovimiento)

      End If
   End Sub


   Private Sub bscNumeroAsiento_BuscadorClick() Handles bscNumeroAsiento.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos
         Dim idAsiento As Integer? = Nothing
         If IsNumeric(bscNumeroAsiento.Text) Then
            idAsiento = Integer.Parse(Me.bscNumeroAsiento.Text)
         End If
         Me.bscNumeroAsiento.Datos = oAsientos.GetManualesSinVincular(idPlanCuenta:=Integer.Parse(Me.cmbPlan.SelectedValue.ToString()),
                                                                      idAsiento:=idAsiento,
                                                                      nombreAsiento:="")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNumeroAsiento_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNumeroAsiento.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargaDatosAsiento(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'Me.Nuevo()
      End Try
   End Sub

   Private Sub bscConcepto_BuscadorClick() Handles bscConcepto.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadAsientos = New Reglas.ContabilidadAsientos
         Me.bscConcepto.Datos = oAsientos.GetManualesSinVincular(idPlanCuenta:=Nothing,
                                                                 idAsiento:=Nothing,
                                                                 nombreAsiento:=bscConcepto.Text)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            CargaDatosAsiento(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         'Me.Nuevo()
      End Try
   End Sub

   Private Sub CargaDatosAsiento(dr As DataGridViewRow)
      Me.bscConcepto.Text = dr.Cells(Entidades.ContabilidadAsiento.Columnas.NombreAsiento.ToString()).Value.ToString()
      Me.bscNumeroAsiento.Text = dr.Cells(Entidades.ContabilidadAsiento.Columnas.IdAsiento.ToString()).Value.ToString()
      Me.bscNumeroAsiento.Tag = dr.Cells(Entidades.ContabilidadAsiento.Columnas.IdEjercicio.ToString()).Value.ToString()

      Me.CargaGrillaDetalle()

   End Sub


   Private Sub CargaGrillaDetalle()


      Dim idPlan As Integer = Integer.Parse(Me.cmbPlan.SelectedValue.ToString())
      Dim Sucursales As List(Of Integer) = New List(Of Integer)

      Dim idAsiento As Integer
      idAsiento = Integer.Parse(Me.bscNumeroAsiento.Text)

      Dim reg As Reglas.ContabilidadReportes = New Reglas.ContabilidadReportes
      Dim oReporteAsiento As New Entidades.ContabilidadReporte

      Dim dtsAsientos As New dtsAsientos()
      oReporteAsiento = reg.Asiento_GetDetalle(idSucursales:={}, idPlan, idAsiento, idCentroCosto:=Nothing, fechaDesde:=Nothing, fechaHasta:=Nothing,
                                               Entidades.ContabilidadReporte.TipoRegistro.DEFINITIVO, Entidades.Publicos.SiNoTodos.TODOS)


      Me.ugDetalle.DataSource = oReporteAsiento.detallesAsiento

      If oReporteAsiento.detallesAsiento Is Nothing OrElse oReporteAsiento.detallesAsiento.Rows.Count = 0 Then
         MessageBox.Show("No se encontraron datos para los filtros seleccionados", "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      Me.FormatearGrilla()


   End Sub

   Private Sub FormatearGrilla()

      Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      'Me.dgdDatos.DisplayLayout.Bands(0).SortedColumns.Add("idAsiento", False, False)
      Me.ugDetalle.DisplayLayout.Bands(0).SortedColumns.Add("nombreAsiento", False, True)
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("idAsiento").Band.SortedColumns.RefreshSort(False)
      Me.ugDetalle.Rows.ExpandAll(False)

      With Me.ugDetalle.DisplayLayout.Bands(0)
         .Columns("idAsiento").Header.VisiblePosition = 0
         .Columns("idAsiento").Header.Caption = "Nro. Asiento"
         .Columns("idAsiento").CellAppearance.TextHAlign = HAlign.Right
         .Columns("fechaAsiento").Header.VisiblePosition = 1
         .Columns("fechaAsiento").Width = 80
         .Columns("fechaAsiento").Header.Caption = "Fecha"
         .Columns("fechaAsiento").CellAppearance.TextHAlign = HAlign.Center
         .Columns("fechaAsiento").Format = Formatos.Format.FechaSinHora
         .Columns("fechaAsiento").MaskInput = Formatos.MaskInput.FechaSinHora
         .Columns("nombreAsiento").Header.VisiblePosition = 2
         .Columns("nombreAsiento").Header.Caption = "Asiento"
         .Columns("nombreAsiento").Width = 200
         .Columns("idCuenta").Header.VisiblePosition = 3
         .Columns("idCuenta").Header.Caption = "Nro. Cuenta"
         .Columns("idCuenta").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Cuenta").Header.VisiblePosition = 4
         .Columns("Cuenta").Header.Caption = "Cuenta"
         .Columns("Cuenta").Width = 200
         .Columns("Debe").Header.VisiblePosition = 5
         .Columns("Debe").Width = 70
         .Columns("Debe").Header.Caption = "Debe"
         .Columns("Debe").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Debe").Format = "##,##0.00"
         .Columns("Haber").Header.VisiblePosition = 6
         .Columns("Haber").Width = 70
         .Columns("Haber").Header.Caption = "Haber"
         .Columns("Haber").CellAppearance.TextHAlign = HAlign.Right
         .Columns("Haber").Format = "##,##0.00"

         .Columns("CodigoReferencia").Header.VisiblePosition = 7
         .Columns("CodigoReferencia").Width = 70
         .Columns("CodigoReferencia").Header.Caption = "Referencia"
         .Columns("CodigoReferencia").CellAppearance.TextHAlign = HAlign.Right

         .Columns("NombreReferencia").Header.VisiblePosition = 8
         .Columns("NombreReferencia").Width = 170
         .Columns("NombreReferencia").Header.Caption = "Nombre Referencia"

         .Columns("idRenglon").Hidden = True
         .Columns("IdTipoReferencia").Hidden = True
         .Columns("Referencia").Hidden = True
         '

         .Columns("IdCentroCosto").Header.VisiblePosition = 9
         .Columns("IdCentroCosto").Header.Caption = "CC."
         .Columns("IdCentroCosto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("IdCentroCosto").Width = 50
         .Columns("NombreCentroCosto").Header.VisiblePosition = 10
         .Columns("NombreCentroCosto").Header.Caption = "Centro de Costos"
         .Columns("NombreCentroCosto").Width = 150

         '.Columns("IdCentroCosto").Hidden = Not _utilizaCentroCostos
         '.Columns("NombreCentroCosto").Hidden = Not _utilizaCentroCostos

         .Summaries.Clear()

         Ayudante.Grilla.AgregarTotalesSuma(ugDetalle, {"Debe", "Haber"})
         Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"nombreAsiento", "Cuenta", "NombreReferencia"})

      End With

   End Sub

   Private _datos As DatosParaVincular
   Public Overloads Function ShowDialog(owner As IWin32Window, datos As DatosParaVincular) As DialogResult
      _datos = datos
      Return ShowDialog(owner)
   End Function


   Public Class DatosParaVincular
      Public Property dr As DataRow
      Public Property Formatear As Action(Of UltraGrid)

      Public Sub New(dr As DataRow, formatear As Action(Of UltraGrid))
         Me.dr = dr
         Me.Formatear = formatear
      End Sub



   End Class

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      IdEjercicio = 0
      IdPlanCuenta = 0
      IdAsiento = 0

      If cmbPlan.SelectedIndex > -1 Then
         IdPlanCuenta = Integer.Parse(cmbPlan.SelectedValue.ToString())
      End If
      If bscNumeroAsiento.Selecciono Or bscConcepto.Selecciono Then
         If IsNumeric(bscNumeroAsiento.Text) Then
            IdAsiento = Integer.Parse(bscNumeroAsiento.Text)
         End If
         If IsNumeric(bscNumeroAsiento.Tag) Then
            IdEjercicio = Integer.Parse(bscNumeroAsiento.Tag.ToString())
         End If
      End If

      If IdEjercicio = 0 Or IdPlanCuenta = 0 Or IdAsiento = 0 Then
         ShowMessage("Por favor seleccione un asiento contable.")
         Exit Sub
      End If

      DialogResult = Windows.Forms.DialogResult.OK
      Close()
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Close()
   End Sub
End Class