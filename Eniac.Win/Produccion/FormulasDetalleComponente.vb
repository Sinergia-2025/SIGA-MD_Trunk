Public Class FormulasDetalleComponente
   Private _drComponente As DataRow
   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(
      Sub()

         If _drComponente IsNot Nothing Then
            bscCodigoProducto2.Text = _drComponente.Field(Of String)("IdProductoComponente")
            bscProducto2.Text = _drComponente.Field(Of String)("NombreProducto")
            bscCodigoProducto2.Permitido = False
            bscProducto2.Permitido = False

            _publicos.CargaComboFormulasDeProductosE(cmbFormulas, bscCodigoProducto2.Text)
            cmbFormulas.SelectedValue = _drComponente.Field(Of Integer?)("IdFormulaComponente").IfNull()

            chbSegunCalculoForma.Checked = _drComponente.Field(Of Boolean)("SegunCalculoForma")
         End If
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         btnCancelar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Overloads Function ShowDialog(owner As IWin32Window, drComponente As DataRow) As DialogResult
      TryCatched(
      Sub()
         _drComponente = drComponente
      End Sub)
      Return ShowDialog(owner)
   End Function

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()
         Dim formula = cmbFormulas.ItemSeleccionado(Of Entidades.ProductoFormula)()
         If formula Is Nothing Then
            Throw New Exception("No ha seleccionado una fórmula")
         End If

         _drComponente.SetField("IdFormulaComponente", formula.IdFormula)
         _drComponente.SetField("NombreFormulaComponente", formula.NombreFormula)
         _drComponente.SetField("SegunCalculoForma", chbSegunCalculoForma.Checked)


         _drComponente.AcceptChanges()
         DialogResult = DialogResult.OK
         Close()
      End Sub,
      accionAdicionalError:=Sub() _drComponente.RejectChanges())
   End Sub
   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      TryCatched(
      Sub()
         DialogResult = DialogResult.Cancel
         Close()
      End Sub)
   End Sub

End Class