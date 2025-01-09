Option Explicit On
Option Strict On

Public Class ContabilidadAsientosModeloDetalle

#Region "Campos"

   Private _publicos As ContabilidadPublicos
   Private dtGrilla As DataTable

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadAsientoModelo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New ContabilidadPublicos()

      Me.BindearControles(Me._entidad)
      Me._publicos.CargaComboPlanes(cmbPlan, False)

      Me.InicializarGrilla()

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarValoresIniciales()
      Else
         ' Me.getTotalesGrilla()
      End If

      Me.Text = "Nuevo Asiento - Sucursal: " & Eniac.Entidades.Usuario.Actual.Sucursal.Id.ToString & "-" & Eniac.Entidades.Usuario.Actual.Sucursal.Nombre

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadAsientosModelos()
   End Function

   Protected Overrides Sub Aceptar()




      DirectCast(Me._entidad, Entidades.ContabilidadAsientoModelo).DetallesAsiento = DirectCast(Me.grdAsientosDetalle.DataSource, DataTable)

      'DirectCast(Me._entidad, Entidades.ContabilidadAsiento).idSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.Id

      MyBase.Aceptar()

      If Me.HayError Then Exit Sub

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Me.CargarValoresIniciales()
         DirectCast(Me.grdAsientosDetalle.DataSource, DataTable).Rows.Clear()

      End If


   End Sub

#End Region

#Region "Metodos"

   Private Sub AgregarFila()
      If bscCodCuenta.Selecciono Or bscDescripcion.Selecciono Then
         Dim fila As DataRow

         fila = dtGrilla.NewRow
         fila("Cuenta") = Me.bscCodCuenta.Text.Trim & " - " & Me.bscDescripcion.Text.Trim
         fila("idAsiento") = Me.txtidmodelo.Text
         fila("IdCuenta") = Me.bscCodCuenta.Text
         fila("IdplanCuenta") = Me.cmbPlan.SelectedValue
         fila("nombreAsiento") = Me.txtnombreModelo.Text

         dtGrilla.Rows.Add(fila)
         Me.grdAsientosDetalle.DataSource = dtGrilla
      End If
   End Sub

   Private Function crearTablaGrilla() As DataTable
      Dim datosGrillas As New DataTable

      datosGrillas.Columns.Add("Cuenta", GetType(String)) 'Cuentas.CodCuenta
      datosGrillas.Columns.Add("idAsiento", GetType(Integer))
      datosGrillas.Columns.Add("IdCuenta", GetType(Int64))
      datosGrillas.Columns.Add("nombreAsiento", GetType(String))
      datosGrillas.Columns.Add("IdPlanCuenta", GetType(Integer))

      Return datosGrillas

   End Function

   Private Sub InicializarGrilla()
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         dtGrilla = crearTablaGrilla()

      ElseIf Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         dtGrilla = DirectCast(Me._entidad, Entidades.ContabilidadAsientoModelo).DetallesAsiento

      End If

      Me.grdAsientosDetalle.DataSource = dtGrilla


      Me.grdAsientosDetalle.Columns(Entidades.ContabilidadAsientoModelo.Columnas.IdAsiento.ToString()).Visible = False
      Me.grdAsientosDetalle.Columns(Entidades.ContabilidadAsientoModelo.Columnas.idCuenta.ToString()).Visible = False
      Me.grdAsientosDetalle.Columns(Entidades.ContabilidadAsientoModelo.Columnas.IdPlanCuenta.ToString()).Visible = False
      Me.grdAsientosDetalle.Columns(Entidades.ContabilidadAsientoModelo.Columnas.NombreAsiento.ToString()).Visible = False
      'Me.grdAsientosDetalle.Columns("cuenta").Visible = True


   End Sub

   Private Sub CargarValoresIniciales()
      Me.CargarProximoNumero()


      'Me.cmbMarcaVehiculo.SelectedIndex = -1
   End Sub

   Private Sub CargarProximoNumero()
      If Me.cmbPlan.SelectedIndex = -1 Then Exit Sub
      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then Exit Sub

      Dim oAsientos As Reglas.ContabilidadAsientosModelos = New Reglas.ContabilidadAsientosModelos()
      Dim ProximoID As Integer
      ProximoID = oAsientos.GetIdMaximo(Integer.Parse(Me.cmbPlan.SelectedValue.ToString())) + 1
      Me.txtidmodelo.Text = ProximoID.ToString()
   End Sub

#End Region

#Region "Eventos"

   Private Sub cmbPlan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlan.SelectedIndexChanged

      Me.bscCodCuenta.Text = ""
      Me.bscDescripcion.Text = ""

      If Me.grdAsientosDetalle.Rows.Count > 0 Then
         DirectCast(grdAsientosDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.CargarProximoNumero()

   End Sub

   Private Sub cmdPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPlan.Click

      Try
         Using frmplan As New ContabilidadPlanesCuentasPreView()
            frmplan.IdPlanCuenta = CInt(Me.cmbPlan.SelectedValue)

            If frmplan.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso frmplan.Cuenta IsNot Nothing Then
               If Not frmplan.Cuenta.EsImputable Then
                  MessageBox.Show(String.Format("La cuenta {0} - {1} no es imputable. No puede usarse para imputar un asiento. Por favor reintente.",
                                                frmplan.Cuenta.IdCuenta, frmplan.Cuenta.NombreCuenta))
                  Exit Sub
               End If

               Me.bscCodCuenta.Text = frmplan.Cuenta.IdCuenta.ToString
               Me.bscCodCuenta.PresionarBoton()
               btnInsertar.Focus()
            End If
         End Using
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bsccodCuenta_BuscadorClick() Handles bscCodCuenta.BuscadorClick

      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicos.PreparaGrillaCuentas(Me.bscCodCuenta)
         Me.bscCodCuenta.Datos = oAsientos.GetCuentasImputablesXCodigo(Long.Parse("0" + Me.bscCodCuenta.Text.Trim()))

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodCuenta_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodCuenta.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
            AgregarFila()
            Me.bscCodCuenta.Text = String.Empty
            Me.bscDescripcion.Text = String.Empty
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorClick() Handles bscDescripcion.BuscadorClick
      Try
         Dim oAsientos As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()
         Me._publicos.PreparaGrillaCuentas(Me.bscDescripcion)
         Me.bscDescripcion.Datos = oAsientos.GetCuentasImputablesXNombre(Me.bscDescripcion.Text.Trim())

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscDescripcion_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscDescripcion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscDescripcion.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Value.ToString()
            Me.bscCodCuenta.Text = e.FilaDevuelta.Cells(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).Value.ToString()
            AgregarFila()
            Me.bscCodCuenta.Text = String.Empty
            Me.bscDescripcion.Text = String.Empty
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnInsertar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertar.Click
      Try



         Me.AgregarFila()

         Me.bscCodCuenta.Text = String.Empty
         Me.bscDescripcion.Text = String.Empty

         Me.bscCodCuenta.Focus()


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
      Try
         If Me.grdAsientosDetalle.SelectedRows.Count = 0 Then
            MessageBox.Show("Seleccione la cuenta a Eliminar", "Asientos", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            DirectCast(Me.grdAsientosDetalle.DataSource, DataTable).Rows.RemoveAt(Me.grdAsientosDetalle.SelectedCells.Item(1).RowIndex)
            Me.grdAsientosDetalle.DataSource = dtGrilla

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

   Private Sub txtnombreModelo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtnombreModelo.KeyDown
      PresionarTab(e)
   End Sub
End Class