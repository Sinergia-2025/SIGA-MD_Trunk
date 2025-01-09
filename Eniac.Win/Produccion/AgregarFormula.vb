Public Class AgregarFormula

   Private _idFormula As Integer
   Public ReadOnly Property IdFormula As Integer
      Get
         Return _idFormula
      End Get
   End Property
   Private prod As String
   Private _publicos As Publicos
   Public Sub New(idProducto As String, nombreProducto As String)
      MyBase.New()
      InitializeComponent()
      TryCatched(
      Sub()
         txtIdProducto.Text = idProducto
         txtNombreProducto.Text = nombreProducto
         txtIdFormula.Text = New Reglas.ProductosFormulas().GetIdFormulaMaximo(idProducto).ToString()
         prod = idProducto

         _publicos = New Publicos()
         _publicos.CargaComboFormulasDeProductosE(cmbCopiarFormulas, idProducto)
      End Sub)
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)
      TryCatched(Sub() txtNombreFormula.Focus())
   End Sub

   Private Sub chbCopiarFormula_CheckedChanged(sender As Object, e As EventArgs) Handles chbCopiarFormula.CheckedChanged
      TryCatched(Sub() chbCopiarFormula.FiltroCheckedChanged(cmbCopiarFormulas))
   End Sub
   Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
      TryCatched(
      Sub()
         Dim rProdform = New Reglas.ProductosFormulas()
         Dim idFormula = txtIdFormula.ValorNumericoPorDefecto(0I)
         rProdform.GrabarFormula(prod, idFormula, txtNombreFormula.Text, cmbCopiarFormulas.ValorSeleccionado(chbCopiarFormula, 0I))
         _idFormula = idFormula
         ShowMessage("Se actualizaron los datos correctamente.")
         Close(DialogResult.OK)
      End Sub)
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Close(DialogResult.Cancel)
   End Sub

End Class