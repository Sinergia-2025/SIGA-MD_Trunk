Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win

Public Class AnularProduccion

#Region "Campos"

   Private _publicos As Publicos
   Dim dtsMaster_detalle As New DataSet
   Dim dtDetalle As DataTable
   Dim dtProduccionDetalle As DataTable
   Dim primeraCarga As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
         Me._publicos.CargaComboEmpleados(Me.cmbResponsable, Entidades.Publicos.TiposEmpleados.COMPRADOR)

         Me.dtpDesde.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub InfProduccion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try

   End Sub


   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub

#End Region

#Region "Metodos"

   Private Sub Refrescar()

      Me.chkMesCompleto.Checked = False
      Me.dtpDesde.Value = Date.Today
      Me.dtpHasta.Value = Date.Today.Date.AddHours(23).AddMinutes(59).AddSeconds(59)



      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      'Limpio la Grilla.

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Rows.Clear()
         DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("detalle").Rows.Clear()
         'Lo otro da error, por ahora es lo mejor.
         'Me.ugDetalle.DataSource = Nothing
         'primeraCarga = True
      End If

      Me.dtpDesde.Focus()

   End Sub


   Private Sub CargaGrillaDetalle()

      Try

         Dim Total As Decimal = 0

         Dim Desde As Date = Nothing
         Dim Hasta As Date = Nothing
         Dim idProd_str As String = String.Empty

         Desde = Me.dtpDesde.Value
         Hasta = Me.dtpHasta.Value

         Dim reg As Reglas.Produccion = New Reglas.Produccion()
         Dim regDet As Reglas.ProduccionProductos = New Reglas.ProduccionProductos()

         If Me.ugDetalle.Rows.Count > 0 Then
            Me.dtsMaster_detalle.Tables("Cabecera").Rows.Clear()
            Me.dtsMaster_detalle.Tables("detalle").Rows.Clear()
         End If

         dtDetalle = reg.GetPorRangoFechas(actual.Sucursal.IdSucursal, Desde, Hasta)

         If dtDetalle.Rows.Count = 0 Then
            If Me.ugDetalle.Rows.Count > 0 Then
               DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Rows.Clear()
               DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("detalle").Rows.Clear()
            End If
            Exit Sub
         End If


         dtDetalle.TableName = "Cabecera"

         If primeraCarga Then
            If dtsMaster_detalle.Tables.Contains("Cabecera") Then
               If dtsMaster_detalle.Relations.Contains("Estados") Then dtsMaster_detalle.Relations.Remove("Estados")
               dtsMaster_detalle.Tables.Remove("Cabecera")
            End If
            dtsMaster_detalle.Tables.Add(dtDetalle)
         Else
            dtsMaster_detalle.Tables("Cabecera").Merge(dtDetalle)
         End If

         For Each fila As DataRow In dtDetalle.Rows
            idProd_str += idProd_str & "'" & fila("IdProduccion").ToString & "',"
         Next

         dtProduccionDetalle = regDet.GetPorRangoFechasProd(actual.Sucursal.IdSucursal, idProd_str.Substring(0, idProd_str.Length - 1))

         dtProduccionDetalle.TableName = "detalle"

         If primeraCarga Then
            If dtsMaster_detalle.Tables.Contains("detalle") Then
               If dtsMaster_detalle.Relations.Contains("Estados") Then dtsMaster_detalle.Relations.Remove("Estados")
               dtsMaster_detalle.Tables.Remove("detalle")
            End If
            dtsMaster_detalle.Tables.Add(dtProduccionDetalle)

            Dim relConstEnum As DataRelation = New DataRelation("Estados", dtsMaster_detalle.Tables("Cabecera").Columns("idProduccion"), dtsMaster_detalle.Tables("detalle").Columns("idProduccion"), False)
            dtsMaster_detalle.Relations.Add(relConstEnum)
         Else
            dtsMaster_detalle.Tables("detalle").Merge(dtProduccionDetalle)
         End If


         '############################3
         Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Cabecera")
         ' Me.ugDetalle.SetDataBinding(dtsMaster_detalle, "Estados")

         Me.ugDetalle.DataSource = dtsMaster_detalle

         Me.ugDetalle.DisplayLayout.Bands(0).Columns("anula").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Header.VisiblePosition = 1
         Me.ugDetalle.DisplayLayout.Bands(0).Columns("Anula").Width = 40


         Me.FormatearGrilla()

         primeraCarga = False


         'Me.ugDetalle.Rows.ExpandAll(True)

         'Me.tsbImprimir.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp

         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("Hora", System.Type.GetType("System.String"))
         .Columns.Add("IdProduccion", System.Type.GetType("System.Int64"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("IdFormula", System.Type.GetType("System.Int32"))
         .Columns.Add("Descripcion", System.Type.GetType("System.String"))
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Responsable", System.Type.GetType("System.String"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

#End Region

  
   Private Sub AnularProduccion()

      Dim oProduccion As Reglas.Produccion = New Reglas.Produccion()

      If Not Me.ugDetalle.DisplayLayout.ActiveRow.Band Is Nothing Then

         Dim Produccion As Entidades.Produccion = oProduccion.GetUna(actual.Sucursal.IdSucursal, _
                           Integer.Parse(Me.ugDetalle.ActiveRow.Cells("IdProduccion").Value.ToString()))

      End If

      'oProduccion.EliminarProduccion(Produccion)

      MessageBox.Show("¡¡¡ Producción Eliminada Exitosamente !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

   End Sub

   Private Sub FormatearGrilla()

      With Me.ugDetalle.DisplayLayout.Bands(1)

         .Columns("IdSucursal").Hidden = True

         .Columns("IdProduccion").Hidden = True

         .Columns("fecha").Hidden = True

         .Columns("idProducto").Header.Caption = "Cod. Producto"
         .Columns("idProducto").Width = 100
         .Columns("idProducto").CellAppearance.TextHAlign = HAlign.Right
         .Columns("idProducto").CellActivation = Activation.NoEdit

         .Columns("nombreProducto").Header.Caption = "Producto"
         .Columns("nombreProducto").Width = 230
         .Columns("nombreProducto").CellActivation = Activation.NoEdit

         .Columns("CantidadProducida").Header.Caption = "Cant. Producida"
         .Columns("CantidadProducida").Width = 85
         .Columns("CantidadProducida").Format = "N2"
         .Columns("CantidadProducida").CellAppearance.TextHAlign = HAlign.Right
         .Columns("CantidadProducida").CellActivation = Activation.NoEdit

         .Columns("IdFormula").Hidden = True

         .Columns("NombreMarca").Header.Caption = "Marca"
         .Columns("NombreMarca").Width = 120
         .Columns("NombreMarca").CellActivation = Activation.NoEdit

         .Columns("NombreRubro").Header.Caption = "Rubro"
         .Columns("NombreRubro").Width = 120
         .Columns("NombreRubro").CellActivation = Activation.NoEdit

         .Columns("NombreFormula").Header.Caption = "Formula"
         .Columns("NombreFormula").Width = 180
         .Columns("NombreFormula").CellActivation = Activation.NoEdit

         .Columns("IdLote").Header.Caption = "Lote"
         .Columns("IdLote").Width = 80
         .Columns("IdLote").CellActivation = Activation.NoEdit

         .Columns("FechaVencimiento").Header.Caption = "Vto.Lote"
         .Columns("FechaVencimiento").Width = 80
         .Columns("FechaVencimiento").CellActivation = Activation.NoEdit

      End With

   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout
      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft
      e.Layout.ViewStyle = ViewStyle.MultiBand
      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy
      e.Layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
   End Sub

   Private Sub ugDetalle_ClickCell(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles ugDetalle.ClickCell
      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      
   End Sub

   Private Sub tsbAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAnular.Click
      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try
         Me.ugDetalle.UpdateData()

         Dim tablaAnular As DataTable = DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Clone
         Dim responsable As Entidades.Empleado = New Entidades.Empleado()

         For Each fila As UltraGridRow In Me.ugDetalle.Rows
            If Boolean.Parse(fila.Cells("anula").Value.ToString) Then
               Dim filaGraba As DataRow = tablaAnular.NewRow
               filaGraba("IdSucursal") = fila.Cells("IdSucursal").Value.ToString
               filaGraba("IdProduccion") = fila.Cells("IdProduccion").Value.ToString
               tablaAnular.Rows.Add(filaGraba)
            End If
         Next
         responsable = DirectCast(Me.cmbResponsable.SelectedItem, Entidades.Empleado)

         If tablaAnular.Rows.Count = 0 Then
            MessageBox.Show("ATENCION: NO Seleccionó Ninguna Producción para Anular!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         Dim oProduccion As Reglas.Produccion = New Reglas.Produccion

         oProduccion.AnularProduccion(tablaAnular, responsable)

         MessageBox.Show("¡¡¡ Producción/nes Anulada/s Exitosamente !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

End Class