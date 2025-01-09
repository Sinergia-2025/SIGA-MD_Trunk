Public Class AjusteMasivoDeStockMinimoPtoPedido

#Region "Campos"

   Private _publicos As Publicos
   'Private _stocks As List(Of Entidades.ProductoSucursal)
   'Private _ubicac As List(Of Entidades.ProductoSucursal)
   Private _listas As List(Of Entidades.ListaDePrecios)
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _idListaPrecios As Integer
   Private _colorColumnasEditables As Color = System.Drawing.Color.FromArgb(224, 224, 224)
   Private _decimalesEnPrecio As Integer = 2
   Private _formatoEnPrecio As String = "N" + _decimalesEnPrecio.ToString()
   Private _maskInputEnPrecio As String = Formatos.MaskInput.CustomMaskInput(9, _decimalesEnPrecio)
   Private _tit As Dictionary(Of String, String)
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()



         Me.tsbGrabar.Enabled = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Select Case keyData
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
               Return True
            End If
         Case Keys.F5
            Me.tsbRefrescar.PerformClick()
            Return True
      End Select
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click

   End Sub

#End Region
End Class