#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports Eniac.Service.Reglas
#End Region
Public Class CambiarEstadoProductos
   Private _nota As String

   Private ReadOnly Property RecepcionNotaEstado As Eniac.Entidades.RecepcionNotaEstado
      Get
         Return DirectCast(_entidad, Entidades.RecepcionNotaEstado)
      End Get
   End Property

#Region "Constructores"

   Public Sub New(notaRecepcion As Eniac.Entidades.RecepcionNotaEstado)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Me._entidad = notaRecepcion
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.CargaComboEstados()

         Me.BindearControles(Me._entidad)

         txtCodigoProducto.Text = RecepcionNotaEstado.Nota.Producto.IdProducto
         txtNombreProducto.Text = RecepcionNotaEstado.Nota.Producto.NombreProducto
         cmbEstado.SelectedValue = RecepcionNotaEstado.Estado.IdEstado
         dtpFecha.Value = RecepcionNotaEstado.FechaEstado
         txtObservacion.Text = RecepcionNotaEstado.Observacion

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RecepcionNotasEstados()
   End Function

   Protected Overrides Sub Aceptar()

      RecepcionNotaEstado.Estado.IdEstado = Integer.Parse(cmbEstado.SelectedValue.ToString())
      RecepcionNotaEstado.FechaEstado = dtpFecha.Value
      RecepcionNotaEstado.Observacion = txtObservacion.Text
      Me._nota = New Reglas.RecepcionEstados().GetUno(Integer.Parse(cmbEstado.SelectedValue.ToString())).NombreEstado
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaComboEstados()
      Dim oEstado As Eniac.Reglas.RecepcionEstados = New Eniac.Reglas.RecepcionEstados()

      With Me.cmbEstado
         .DisplayMember = "NombreEstado"
         .ValueMember = "IdEstado"
         .DataSource = oEstado.GetTodos()
         .SelectedValue = 10
      End With

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      If Me._nota = "Entregado" Then
         If MessageBox.Show("Desea generar remito?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Dim fr As FacturacionV2 = New FacturacionV2(RecepcionNotaEstado.Nota.Cliente.IdCliente, "REMITO", RecepcionNotaEstado.Nota.Producto.IdProducto.Trim())
            fr.ConsultarAutomaticamente = True
            fr.MdiParent = Me.MdiParent
            fr.Show()
         Else
            Me.Close()
         End If
      Else
         Me.Close()
      End If

   End Sub

#End Region

End Class