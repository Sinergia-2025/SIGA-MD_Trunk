Option Explicit On
Option Strict On

Imports Eniac.Service.Reglas

Public Class CambiarEstadoProductosF

#Region "Constructores"

   Public Sub New(ByVal notaRecepcion As Eniac.Entidades.RecepcionNotaEstadoF)
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
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.RecepcionNotasEstadosF()
   End Function

#End Region

#Region "Metodos"

   Private Sub CargaComboEstados()
      Dim oEstado As Eniac.Reglas.RecepcionEstadosF = New Eniac.Reglas.RecepcionEstadosF()

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
      Me.Close()
   End Sub

#End Region

End Class