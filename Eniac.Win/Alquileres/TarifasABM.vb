Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win

Public Class TarifasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TarifasDetalle(DirectCast(Me.GetEntidad(), Entidades.AlquilerTarifaProducto))
      End If
      Return New TarifasDetalle(New Entidades.AlquilerTarifaProducto)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AlquileresTarifasProductos()
   End Function

   'Protected Overrides Sub Imprimir()
   '    MyBase.Imprimir()
   '    Try
   '        Me.Cursor = Cursors.WaitCursor
   '        Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '        parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))

   '        Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiPrueba.Win.MarcasVehiculos.rdlc", "SistemaDataSet_MarcasVehiculos", Me.dtDatos, parm, True)
   '        frmImprime.Text = Me.Text
   '        frmImprime.Show()
   '        Me.Cursor = Cursors.Default
   '    Catch ex As Exception
   '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '    End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim Tarifa As Entidades.AlquilerTarifaProducto = New Entidades.AlquilerTarifaProducto
      Dim Tarifas As Reglas.AlquileresTarifasProductos = New Reglas.AlquileresTarifasProductos

      With Me.dgvDatos.SelectedCells(0).OwningRow
         Tarifa = Tarifas.GetUna(actual.Sucursal.IdSucursal, .Cells(Entidades.AlquilerTarifaProducto.Columnas.IdProducto).Value.ToString())
      End With

      Return Tarifa

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos

         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect

         .Columns(Entidades.AlquilerTarifaProducto.Columnas.IdProducto.ToString()).HeaderText = "Codigo Prod."
         .Columns(Entidades.AlquilerTarifaProducto.Columnas.IdProducto.ToString()).Width = 100
         .Columns(Entidades.AlquilerTarifaProducto.Columnas.IdProducto.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto.ToString()).HeaderText = "Producto - Chasis - Modelo - Nro. Serie"
         .Columns(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto.ToString()).Width = 600
         .Columns(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto.ToString()).HeaderText = "Producto"
         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto.ToString()).Width = 250
         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.NombreProducto.ToString()).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.Chasis.ToString()).HeaderText = "Chasis"
         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.Chasis.ToString()).Width = 150

         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.Modelo.ToString()).HeaderText = "Modelo"
         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.Modelo.ToString()).Width = 150

         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.NumeroSerie.ToString()).HeaderText = "NumeroSerie"
         '.Columns(Entidades.AlquilerTarifaProducto.Columnas.NumeroSerie.ToString()).Width = 150

         .Columns("CantDias").HeaderText = "Cant. Dias"
         .Columns("CantDias").Width = 60
         .Columns("CantDias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns("PrecioAlquiler").HeaderText = "Precio"
         .Columns("PrecioAlquiler").Width = 70
         .Columns("PrecioAlquiler").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("PrecioAlquiler").DefaultCellStyle.Format = "##,##0.00"

      End With

   End Sub

   Protected Overrides Sub RefreshGrid()
      Try
         Dim rg As Reglas.AlquileresTarifasProductos = DirectCast(Me.GetReglas(), Reglas.AlquileresTarifasProductos)
         If Not Me.tstBuscar.Tag Is Nothing And Me.tstBuscar.Text <> "" Then
            Dim bus As Entidades.Buscar = New Entidades.Buscar
            bus.IdSucursal = Entidades.Usuario.Actual.Sucursal.Id
            bus.Columna = Me.tstBuscar.Tag.ToString()
            bus.Valor = Me.tstBuscar.Text.Trim()
            Me.dtDatos = rg.Buscar(bus)
         Else
            Me.dtDatos = rg.GetAll2(Entidades.Usuario.Actual.Sucursal.Id)
         End If
         Me.dgvDatos.DataSource = Me.dtDatos
         If Not Me.dtDatos Is Nothing Then
            Me.FormatearGrilla()
         End If
         If Me.dgvDatos.Rows.Count > 1 Then
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registros"
         Else
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registro"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class