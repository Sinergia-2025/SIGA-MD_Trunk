Imports System.Runtime.CompilerServices
Public Module TextBoxExtensions
   <Extension>
   Public Function TagNumericoPorDefecto(Of T)(txt As TextBox, porDefecto As T) As T
      Return ObjectExtensions.ValorNumericoPorDefecto(txt.Tag, porDefecto)
   End Function
   <Extension>
   Public Function ValorNumericoPorDefecto(Of T)(txt As TextBox, porDefecto As T) As T
      Return Entidades.Extensiones.ObjectExtensions.ValorNumericoPorDefecto(txt.Text, porDefecto)
   End Function
   <Extension>
   Public Function ValorSeleccionado(Of T)(txt As TextBox, chb As CheckBox, porDefecto As T) As T
      If chb.Checked Then
         Return txt.ValorNumericoPorDefecto(porDefecto)
      End If
      Return porDefecto
   End Function

   <Extension>
   Public Function SetColor(txt As TextBox, dr As DataGridViewRow) As TextBox
      Return txt.SetColor(dr, "ForeColor", "BackColor")
   End Function
   <Extension>
   Public Function SetColor(txt As TextBox, dr As DataGridViewRow, foreColor As String, backColor As String) As TextBox
      Dim foreColor1 As Integer?
      Dim backColor1 As Integer?
      If Not String.IsNullOrWhiteSpace(foreColor) AndAlso IsNumeric(dr.Cells(foreColor).Value) Then
         foreColor1 = Integer.Parse(dr.Cells(foreColor).Value.ToString())
      End If
      If Not String.IsNullOrWhiteSpace(backColor) AndAlso IsNumeric(dr.Cells(backColor).Value) Then
         backColor1 = Integer.Parse(dr.Cells(backColor).Value.ToString())
      End If

      Return txt.SetColorFromInteger(foreColor1, backColor1)
   End Function
   <Extension()>
   Public Function SetColorFromInteger(txt As TextBox, foreColor As Integer?, backColor As Integer?) As TextBox
      Dim backColor1 = If(backColor.HasValue, Drawing.Color.FromArgb(backColor.Value), Nothing)
      Dim foreColor1 = If(foreColor.HasValue, Drawing.Color.FromArgb(foreColor.Value), Nothing)
      Return txt.SetColor(foreColor1, backColor1)
   End Function
   <Extension()>
   Public Function SetColor(txt As TextBox, foreColor As Color, backColor As Color) As TextBox
      txt.BackColor = backColor
      txt.ForeColor = foreColor

      Return txt
   End Function

   <Extension()>
   Public Function SetValor(txt As Controles.TextBox, valor As Decimal) As TextBox
      txt.Text = If(String.IsNullOrWhiteSpace(txt.Formato), valor.ToString(), valor.ToString(txt.Formato))
      Return txt
   End Function
   <Extension()>
   Public Function SetValor(txt As Controles.TextBox, valor As Double) As TextBox
      txt.Text = If(String.IsNullOrWhiteSpace(txt.Formato), valor.ToString(), valor.ToString(txt.Formato))
      Return txt
   End Function
   <Extension()>
   Public Function SetValor(txt As Controles.TextBox, valor As Date) As TextBox
      txt.Text = If(String.IsNullOrWhiteSpace(txt.Formato), valor.ToString("dd/MM/yyyy"), valor.ToString(txt.Formato))
      Return txt
   End Function
   <Extension()>
   Public Function SetValor(txt As Controles.TextBox, valor As String) As TextBox
      txt.Text = valor
      Return txt
   End Function

End Module