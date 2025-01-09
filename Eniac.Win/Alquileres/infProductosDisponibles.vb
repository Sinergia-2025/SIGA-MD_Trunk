Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class infProductosDisponibles

   Private _publicos As Publicos
   Dim dtGrilla As DataTable
   Public _padre As System.Windows.Forms.Form

   Public Property padre() As System.Windows.Forms.Form
      Get
         Return _padre
      End Get
      Set(ByVal value As System.Windows.Forms.Form)
         _padre = value
      End Set
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.Alquiler)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Dim oProductos As Reglas.Productos = New Reglas.Productos
      'Dim dtProductos As DataTable = oProductos.GetAll()

      Me.dtpDesde.Value = Date.Now.Date
      Me.dtpHasta.Value = Me.dtpDesde.Value.AddMonths(1)

      Me.inicializarGrilla()

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Alquileres
   End Function

   Protected Overrides Sub Aceptar()
      Me.Close()
      'MyBase.Aceptar()
   End Sub

#End Region

   Private Sub inicializarGrilla()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      dtGrilla = Me.crearTablaGrilla()

      'ElseIf Me.StateForm = Eniac.Win.StateForm.Actualizar Then
      'dtGrilla = DirectCast(Me._entidad, Entidades.Asiento).detallesAsiento

      'End If

      Me.grdTurnos.DataSource = dtGrilla

      Me.grdTurnos.DisplayLayout.Bands(0).Columns("IdProducto").Hidden = True

      Me.grdTurnos.DisplayLayout.Bands(0).Columns("NombreProducto").Header.Caption = "Producto"
      Me.grdTurnos.DisplayLayout.Bands(0).Columns("NombreProducto").Width = 200

      '    CargarHorarios(dtGrilla)

   End Sub

   Private Function crearTablaGrilla() As DataTable

      Dim datosGrillas As New DataTable

      datosGrillas.Columns.Add("IdProducto", System.Type.GetType("System.String")) 'fixed, hidden
      datosGrillas.Columns.Add("NombreProducto", System.Type.GetType("System.String")) 'fixed

      Return datosGrillas

   End Function

   Private Sub cargarColumnasDias()

      Dim datosGrillas As New DataTable
      datosGrillas.Columns.Add("IdProducto", System.Type.GetType("System.String")) 'fixed, hidden
      datosGrillas.Columns.Add("NombreProducto", System.Type.GetType("System.String")) 'fixed

      Dim cantDias As Integer = Integer.Parse(Me.dtpHasta.Value.Date.Subtract(Me.dtpDesde.Value.Date).TotalDays.ToString)

      For i As Integer = 0 To cantDias
         datosGrillas.Columns.Add(Me.dtpDesde.Value.AddDays(i).ToShortDateString, System.Type.GetType("System.String")) 'fixed
      Next

      Me.grdTurnos.DisplayLayout.Bands(0).Columns("IdProducto").Hidden = True
      Me.grdTurnos.DisplayLayout.Bands(0).Columns("NombreProducto").Header.Caption = "Producto"
      Me.grdTurnos.DisplayLayout.Bands(0).Columns("NombreProducto").Width = 150

      Me.grdTurnos.DisplayLayout.UseFixedHeaders = True
      Me.grdTurnos.DisplayLayout.Bands(0).Columns("NombreProducto").Header.Fixed = True

      Dim IdProducto As String = String.Empty

      If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
        End If

        Dim oProductos As Reglas.Productos = New Reglas.Productos
        Dim dtProductos As DataTable = oProductos.GetAlquilables(IdProducto)

        ' cargo los Productos
        For Each Producto As DataRow In dtProductos.Rows
            Dim fila As DataRow
            fila = datosGrillas.NewRow
            fila("IdProducto") = Producto("IdProducto").ToString
            fila("NombreProducto") = Producto("NombreProducto").ToString
            datosGrillas.Rows.Add(fila)
        Next

        Me.grdTurnos.DataSource = datosGrillas

        For Each ColGrilla As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.grdTurnos.DisplayLayout.Bands(0).Columns
            ColGrilla.CellAppearance.BackColor = Color.LightCyan
        Next

        Me.grdTurnos.DisplayLayout.Bands(0).Columns("NombreProducto").CellAppearance.BackColor = Color.LightSteelBlue

    End Sub

    Private Sub recuperarAlquileres()

        Dim oAlquiler As Reglas.Alquileres = New Reglas.Alquileres

        'Dim dtAlquiler As DataTable = oAlquiler.GetAll2(actual.Sucursal.IdSucursal)

        Dim IdProducto As String = String.Empty

        If Me.chbProducto.Checked Then
            IdProducto = Me.bscCodigoProducto2.Text
        End If

        Dim dtAlquiler As DataTable = oAlquiler.GetContratos(actual.Sucursal.IdSucursal, Me.dtpDesde.Value, Me.dtpHasta.Value, -1, False, "TODOS", IdProducto)

        For Each filaDatos As DataRow In dtAlquiler.Rows

            For Each filaGrilla As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.grdTurnos.DisplayLayout.Rows

                For Each ColGrilla As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.grdTurnos.DisplayLayout.Bands(0).Columns

                    If Not (ColGrilla.Header.Caption = "Producto" Or ColGrilla.Header.Caption = "IdProducto" Or ColGrilla.Header.Caption = " ") Then

                        If CDate(filaDatos("FechaDesde")) = CDate(ColGrilla.Header.Caption) And _
                           filaGrilla.Cells("IdProducto").Value.ToString = filaDatos("IdProducto").ToString Then
                            Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(ColGrilla.Key).Value = "Alquilado"
                            Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(ColGrilla.Key).Appearance.BackColor = Color.LightSalmon
                        Else
                            'Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(ColGrilla.Key).Appearance.BackColor = Color.LightGreen
                            'Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(ColGrilla.Key).Value = String.Empty
                        End If
                        ' For i As Integer = 1 To integer.parse(CDate(filaDatos("FechaHasta")).Subtract(CDate(filaDatos("FechaDesde"))).TotalDays)
                        For i As Integer = 1 To CInt(CDate(filaDatos("FechaRealFin")).Subtract(CDate(filaDatos("FechaDesde"))).TotalDays)
                            If CDate(filaDatos("FechaDesde")).AddDays(i) = CDate(ColGrilla.Header.Caption) And _
                                 filaGrilla.Cells("IdProducto").Value.ToString = filaDatos("IdProducto").ToString Then
                                Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(CDate(filaDatos("FechaDesde")).AddDays(i).ToString("dd/MM/yyyy")).Value = "Alquilado"
                                Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(CDate(filaDatos("FechaDesde")).AddDays(i).ToString("dd/MM/yyyy")).Appearance.BackColor = Color.LightSalmon
                            Else
                                'Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(CDate(filaDatos("FechaDesde")).AddDays(i).ToString("dd/MM/yyyy")).Appearance.BackColor = Color.LightGreen
                                'Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(CDate(filaDatos("FechaDesde")).AddDays(i).ToString("dd/MM/yyyy")).Value = String.Empty
                            End If
                        Next

                    End If

                    'Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(ColGrilla.Key).Appearance.BackColor = Color.LightGreen
                    'Me.grdTurnos.DisplayLayout.Rows(filaGrilla.Index).Cells(ColGrilla.Key).Value = String.Empty

                Next

            Next
        Next
    End Sub

    Private Sub grdTurnos_DoubleClickCell(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles grdTurnos.DoubleClickCell

        'Cuando entro por el menu normal no tiene padre, Pero si la llame desde Alquileres si.
        If Me.padre Is Nothing Then Exit Sub

        If Not (e.Cell.Column.Header.Caption = "Producto" Or e.Cell.Column.Header.Caption = "IdProducto" Or e.Cell.Column.Header.Caption = " ") Then
            If (TypeOf (Me.padre) Is AlquilerDetalle) And Not (validarFechaReal(actual.Sucursal.IdSucursal, Me.grdTurnos.DisplayLayout.Rows(e.Cell.Row.Index).Cells("IdProducto").Value.ToString(), CDate(e.Cell.Column.Header.Caption))) Then
                DirectCast(Me.padre, AlquilerDetalle)._fechaPadre = CDate(e.Cell.Column.Header.Caption)
                DirectCast(Me.padre, AlquilerDetalle)._ProductoPadre = Me.grdTurnos.DisplayLayout.Rows(e.Cell.Row.Index).Cells("IdProducto").Value.ToString()
                Me.Close()
            Else
                MessageBox.Show("El Producto se encuentra alquilado en la fecha seleccionada", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

    End Sub

    Private Function validarFechaReal(ByVal idSucursal As Integer, _
                                      ByVal IdProducto As String, _
                                      ByVal fechaReal As Date) As Boolean

        Dim oAlquiler As Reglas.Alquileres = New Reglas.Alquileres
        Return oAlquiler.validarFechaReal(idSucursal, IdProducto, fechaReal)

    End Function

    Private Sub chbProducto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbProducto.CheckedChanged
        Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
        Me.bscProducto2.Enabled = Me.chbProducto.Checked
        If Not Me.chbProducto.Checked Then
            Me.bscCodigoProducto2.Text = String.Empty
            Me.bscProducto2.Text = String.Empty
        Else
            Me.bscCodigoProducto2.Focus()
        End If
    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
            Dim blnSoloAlquilables As Boolean = True
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , , blnSoloAlquilables)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos
            Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
            Dim blnSoloAlquilables As Boolean = True
            Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS", , blnSoloAlquilables)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
        Try
            If Not e.FilaDevuelta Is Nothing Then
                Me.CargarProducto(e.FilaDevuelta)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

        If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
        End If

        Me.cargarColumnasDias()

        Me.recuperarAlquileres()

    End Sub

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)

        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscProducto2.Enabled = False
        Me.bscCodigoProducto2.Enabled = False

    End Sub

End Class