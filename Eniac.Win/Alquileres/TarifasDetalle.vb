Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class TarifasDetalle

#Region "Campos"

   Private _publicos As Publicos
   Dim dtGrilla As DataTable
   Dim CargandoForm As Boolean = True

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.AlquilerTarifaProducto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Me._publicos.CargaComboProductos(Me.cmbProducto)

      'Me.cmbProducto.SelectedValue = DirectCast(DirectCast(DirectCast(Me.cmbProducto.SelectedItem, System.Object), System.Data.DataRowView).Row, System.Data.DataRow).ItemArray(0)

      Me.BindearControles(Me._entidad)

      Me.CargarValoresIniciales()

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AlquileresTarifasProductos
   End Function

   Protected Overrides Sub Aceptar()

      DirectCast(Me._entidad, Entidades.AlquilerTarifaProducto).IdSucursal = actual.Sucursal.IdSucursal

        DirectCast(Me._entidad, Entidades.AlquilerTarifaProducto).IdProducto = Me.bscCodigoProducto2.Text

        DirectCast(Me._entidad, Entidades.AlquilerTarifaProducto).dtdetalles = DirectCast(Me.grdcostos.DataSource, DataTable)

        MyBase.Aceptar()

        If Me.StateForm = Eniac.Win.StateForm.Insertar And Not Me.HayError Then
            Me.Close()
        End If

    End Sub

    Protected Overrides Function ValidarDetalle() As String

        If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            'Me.tbcDetalle.SelectedTab = Me.tbpAgrupacion
            Me.bscCodigoProducto2.Focus()
            Return "No selecciono el Producto."
        End If

        Return MyBase.ValidarDetalle()

    End Function

#End Region

#Region "Eventos"

    Private Sub btnLimpiarProducto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiarProducto.Click
        Me.LimpiarCamposProductos()
        Me.bscCodigoProducto2.Focus()
    End Sub

    Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
        Try
            Dim oProductos As Reglas.Productos = New Reglas.Productos()
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

#End Region

#Region "Metodos"

    Private Sub CargarValoresIniciales()

        If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            dtGrilla = crearTablaGrilla()

            CargandoForm = False

            'Me.cmbProducto.SelectedIndex = 0

            Me.CargarGrillaInicial()

        ElseIf Me.StateForm = Eniac.Win.StateForm.Actualizar Then
            Me.bscCodigoProducto2.PresionarBoton()
            Me.btnLimpiarProducto.Visible = False
            dtGrilla = DirectCast(Me._entidad, Entidades.AlquilerTarifaProducto).dtdetalles
            CargandoForm = False
        End If

        Me.grdcostos.DataSource = dtGrilla
        Me.grdcostos.EditMode = DataGridViewEditMode.EditProgrammatically
        Me.grdcostos.Columns("cantDias").ReadOnly = True
        Me.grdcostos.Columns("PrecioAlquiler").ReadOnly = False

    End Sub

    Private Sub CargarGrillaInicial()

        For i As Integer = 1 To 4
            Dim fila As DataRow
            fila = dtGrilla.NewRow
            fila("cantdias") = i.ToString
            fila("PrecioAlquiler") = 0
            dtGrilla.Rows.Add(fila)
        Next

        Dim fila7 As DataRow
        fila7 = dtGrilla.NewRow
        fila7("cantdias") = "7"
        fila7("PrecioAlquiler") = 0
        dtGrilla.Rows.Add(fila7)

        Dim fila10 As DataRow
        fila10 = dtGrilla.NewRow
        fila10("cantdias") = "10"
        fila10("PrecioAlquiler") = 0
        dtGrilla.Rows.Add(fila10)

        Dim fila15 As DataRow
        fila15 = dtGrilla.NewRow
        fila15("cantdias") = "15"
        fila15("PrecioAlquiler") = 0
        dtGrilla.Rows.Add(fila15)

        Dim fila20 As DataRow
        fila20 = dtGrilla.NewRow
        fila20("cantdias") = "20"
        fila20("PrecioAlquiler") = 0
        dtGrilla.Rows.Add(fila20)

        Dim fila30 As DataRow
        fila30 = dtGrilla.NewRow
        fila30("cantdias") = "30"
        fila30("PrecioAlquiler") = 0
        dtGrilla.Rows.Add(fila30)

    End Sub

    Private Function crearTablaGrilla() As DataTable
        Dim datosGrillas As New DataTable
        'datosGrillas.Columns.Add("IdProducto", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("cantdias", System.Type.GetType("System.String"))
        datosGrillas.Columns.Add("PrecioAlquiler", System.Type.GetType("System.Decimal"))
        Return datosGrillas
    End Function

    Private Sub grdcostos_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdcostos.MouseClick

        If Me.grdcostos IsNot Nothing Then

            Dim point1 As Point = Me.grdcostos.CurrentCellAddress

            If Me.grdcostos.EditMode = DataGridViewEditMode.EditProgrammatically Then
                Me.grdcostos.BeginEdit(True)
            End If

        End If

    End Sub

    Private Sub CargarProducto(ByVal dr As DataGridViewRow)

        Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
        Me.bscCodigoProducto2.Enabled = False

        Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
        Me.bscProducto2.Enabled = False

    End Sub

    Private Sub LimpiarCamposProductos()
        Me.bscCodigoProducto2.Enabled = True
        Me.bscCodigoProducto2.Text = ""
        Me.bscCodigoProducto2.FilaDevuelta = Nothing
        Me.bscProducto2.Enabled = True
        Me.bscProducto2.Text = ""
        Me.bscProducto2.FilaDevuelta = Nothing
    End Sub

#End Region

End Class