Option Strict On
Option Explicit On
Public Class TextBoxParaMostrarFiltros
   Inherits TextBox
   Protected Overrides Sub OnTextChanged(e As EventArgs)
      MyBase.OnTextChanged(e)
      RecalculaAlto()
   End Sub

   Protected Overrides Sub OnResize(e As EventArgs)
      MyBase.OnResize(e)
      RecalculaAlto()
   End Sub

   Private Sub RecalculaAlto()
      Height =
          TextRenderer.MeasureText(
               Text,
               Font,
               New Size(ClientSize.Width, 1000),
               TextFormatFlags.WordBreak
               ).Height
   End Sub

End Class