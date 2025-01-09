Public Class ModificarFormula

   Private _idProducto As String

   Public Sub New(idProducto As String, nombreProducto As String, idFormula As Integer, nombreFormula As String)
      MyBase.New()
      InitializeComponent()
      TryCatched(
      Sub()
         txtIdProducto.Text = idProducto
         txtNombreProducto.Text = nombreProducto
         txtIdFormula.Text = idFormula.ToString()
         txtNombreFormula.Text = nombreFormula.ToString()
         _idProducto = idProducto
      End Sub)
   End Sub

   Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
      TryCatched(
      Sub()
         Dim prodform = New Reglas.ProductosFormulas()
         prodform.ModificarFormula(_idProducto, txtIdFormula.ValorNumericoPorDefecto(0I), txtNombreFormula.Text, PorcentajeGanancia:=0)
         ShowMessage("Se actualizaron los datos correctamente.")
         Close(DialogResult.OK)
      End Sub)
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Close(DialogResult.Cancel)
   End Sub

End Class