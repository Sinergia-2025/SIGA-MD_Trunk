Option Strict On
Option Explicit On
Public Class EstadosVentaDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.EstadoVenta)
      Me.New()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim oTipoMov As New Reglas.TiposMovimientos
      'Me.cmbTipoMovimiento.DataSource = oTipoMov.GetParaCombos()
      Me.cmbTipoMovimiento.DataSource = oTipoMov.GetTodos()
      Me.cmbTipoMovimiento.DisplayMember = "Descripcion"
      Me.cmbTipoMovimiento.ValueMember = "IdTipoMovimiento"
      Me.cmbTipoMovimiento.SelectedIndex = -1

      Me.BindearControles(Me._entidad)
      Try
         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.CargarProximoNumero()
         Else
            If DirectCast(Me._entidad, Entidades.EstadoVenta).IdTipoMovimiento <> "" Then
               Me.chbRealizaContramovStockNC.Checked = True
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.EstadosVenta()
   End Function
   Protected Overrides Function ValidarDetalle() As String

      If Me.chbRealizaContramovStockNC.Checked And Me.cmbTipoMovimiento.SelectedIndex = -1 Then
         Me.cmbTipoMovimiento.Focus()
         Return "ATENCION: No seleccionó el Tipo de Movimiento."
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      MyBase.Aceptar()
      If Not Me.HayError Then Me.Close()

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Me.txtIdEstadoVenta.Text = (New Reglas.EstadosVenta().GetCodigoMaximo() + 1).ToString()
   End Sub

#End Region

   Private Sub chbRealizaContramovStockNC_CheckedChanged(sender As Object, e As EventArgs) Handles chbRealizaContramovStockNC.CheckedChanged

      If Not Me.chbRealizaContramovStockNC.Checked Then
         DirectCast(Me._entidad, Entidades.EstadoVenta).IdTipoMovimiento = ""
         cmbTipoMovimiento.SelectedIndex = -1
      End If

      Me.cmbTipoMovimiento.Enabled = Me.chbRealizaContramovStockNC.Checked

      If Me.chbRealizaContramovStockNC.Checked Then
         Me.cmbTipoMovimiento.Focus()
      End If

   End Sub
End Class