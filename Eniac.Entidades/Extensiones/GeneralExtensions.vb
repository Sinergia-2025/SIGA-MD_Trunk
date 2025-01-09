#Region "Imports"
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
#End Region
Namespace Extensiones
   Public Module GeneralExtensions
      ''Cultura Argentina
      Private culturaArgentina As CultureInfo = New CultureInfo("es-AR")

      Public Enum FormatoNombres
         Minusculas
         Mayusculas
         PrimerLetra
      End Enum

      Private Function FormatearNombres(nombre As String, formato As FormatoNombres) As String
         Select Case formato
            Case FormatoNombres.Minusculas
               Return nombre.ToLower()
            Case FormatoNombres.Mayusculas
               Return nombre.ToUpper()
            Case FormatoNombres.PrimerLetra
               Return String.Format("{0}{1}", nombre.Substring(0, 1).ToUpper(), nombre.Substring(1).ToLower())
            Case Else
               Return nombre
         End Select
      End Function

      <Extension()>
      Public Function NombreDiaSemana(idDiaSemana As System.DayOfWeek) As String
         Return culturaArgentina.DateTimeFormat.GetDayName(idDiaSemana).PrimerLetraMayuscula()
      End Function

      <Extension>
      Public Function GetDiaEnEspanol(fecha As DateTime) As String
         Return GetDiaEnEspanol(fecha, FormatoNombres.PrimerLetra)
      End Function
      <Extension>
      Public Function GetDiaEnEspanol(fecha As DateTime, formato As FormatoNombres) As String
         Return FormatearNombres(culturaArgentina.DateTimeFormat.GetDayName(fecha.DayOfWeek), formato)
      End Function

      <Extension>
      Public Function GetMesEnEspanol(fecha As Date) As String
         Return GetMesEnEspanol(fecha, FormatoNombres.PrimerLetra)
      End Function
      <Extension>
      Public Function GetMesEnEspanol(fecha As Date, formato As FormatoNombres) As String
         Return fecha.Month.GetMesEnEspanol(formato)
      End Function
      <Extension>
      Public Function GetMesEnEspanol(nroMes As Integer) As String
         Return nroMes.GetMesEnEspanol(FormatoNombres.PrimerLetra)
      End Function
      <Extension>
      Public Function GetMesEnEspanol(nroMes As Integer, formato As FormatoNombres) As String
         Return FormatearNombres(culturaArgentina.DateTimeFormat.GetMonthName(nroMes), formato)
      End Function

      <Extension()>
      Public Function GetPorKind(col As Printing.PrinterSettings.PaperSizeCollection, kind As Printing.PaperKind) As Printing.PaperSize
         For Each item As Printing.PaperSize In col
            If item.Kind = kind Then
               Return item
            End If
         Next
         Return Nothing
      End Function

      <Extension()>
      Public Sub InicializaDocumento(documento As Printing.PrintDocument)
         documento.DefaultPageSettings.Margins = New Drawing.Printing.Margins(30, 30, 30, 30)
         documento.DefaultPageSettings.PaperSize = documento.PrinterSettings.PaperSizes.GetPorKind(Drawing.Printing.PaperKind.A4)
      End Sub
   End Module
End Namespace