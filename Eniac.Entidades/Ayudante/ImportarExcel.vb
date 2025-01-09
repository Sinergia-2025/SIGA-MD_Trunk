Namespace Ayudante
   Public Class ImportarExcel
      Public Shared Function GetValorString(dr As DataRow, indiceColumna As Integer) As String
         Dim obj As Object = dr(indiceColumna)
         If IsDBNull(obj) Then Return String.Empty
         Return dr(indiceColumna).ToString()
      End Function

      Public Shared Function GetValorInteger(dr As DataRow, columna As Integer) As Integer
         Return Convert.ToInt32(GetValorDecimal(dr, columna, 0, False, False))
      End Function

      Public Shared Function GetValorLong(dr As DataRow, columna As Integer) As Long
         Return Convert.ToInt64(GetValorDecimal(dr, columna, 0, False, False))
      End Function

      Public Shared Function GetValorDecimal(dr As DataRow, columna As Integer) As Decimal
         Return GetValorDecimal(dr, columna, 2, False, False)
      End Function
      Public Shared Function GetValorDecimal(dr As DataRow, columna As Integer, decimales As Integer) As Decimal
         Return GetValorDecimal(dr, columna, decimales, False, False)
      End Function
      Public Shared Function GetValorDecimal(dr As DataRow, columna As Integer, decimales As Integer, errorFormato As Boolean, errorDBNull As Boolean) As Decimal
         If IsDBNull(dr(columna)) Then                            ' Valor nulo
            If errorDBNull Then Throw New FormatException(String.Format("Cadena de entrada no estaba en un formato correcto: ´{0}´", "DBNull"))
            Return 0
         End If
         'If Not IsNumeric(dr(columna)) Then                       ' El string no es numérico
         '   If errorFormato Then Throw New FormatException(String.Format("Cadena de entrada no estaba en un formato correcto: ´{0}´", dr(columna).ToString()))
         '   Return 0
         'End If
         Dim valorString As String = dr(columna).ToString().Replace("$", "")

         Dim indexComa As Integer = valorString.LastIndexOf(",")  ' Posición de la última coma del String
         Dim indexPunto As Integer = valorString.LastIndexOf(".") ' Posición del último punto del String

         Dim valorAConvertir As String

         If indexComa < 0 AndAlso indexPunto < 0 Then             '   125        ==>  125.00
            valorAConvertir = valorString
         ElseIf indexComa < 0 AndAlso indexPunto >= 0 Then        '   125.33     ==>  125.33
            valorAConvertir = valorString
         ElseIf indexComa >= 0 AndAlso indexPunto < 0 Then        '   125,33     ==>  125.33
            valorAConvertir = valorString.Replace(",", ".")
         ElseIf indexComa > indexPunto Then                       ' 1.125,33     ==> 1125.33
            valorAConvertir = valorString.Replace(".", "").Replace(",", ".")
         ElseIf indexComa < indexPunto Then                       ' 1,125.33     ==> 1125.33
            valorAConvertir = valorString.Replace(",", "")
         Else                                                     ' No debería nunca salor por acá, pero por las dudas.
            valorAConvertir = valorString
         End If

         Dim resultDecimal As Decimal
         If Decimal.TryParse(valorAConvertir, resultDecimal) Then
            Return resultDecimal
         Else
            If errorFormato Then Throw New FormatException(String.Format("Cadena de entrada no estaba en un formato correcto: ´{0}´", dr(columna)))
            Return 0
         End If
         'Return Decimal.Round(Decimal.Parse(valorAConvertir), decimales)
      End Function

      Public Shared Function GetValorDateTime(dr As DataRow, indiceColumna As Integer, formatoFechas As String) As DateTime?
         Dim obj As Object = dr(indiceColumna)
         Dim fecha As DateTime
         If IsDBNull(obj) Then Return Nothing
         If TypeOf (obj) Is DateTime Then
            Return DirectCast(obj, DateTime)
         End If
         If DateTime.TryParseExact(dr(indiceColumna).ToString(), formatoFechas,
                                   Threading.Thread.CurrentThread.CurrentCulture, Globalization.DateTimeStyles.None, fecha) Then
            Return fecha
         Else
            Return Nothing
         End If
      End Function

      Public Shared Function IsNumeric(dr As DataRow, columna As Integer) As Boolean
         Try
            GetValorDecimal(dr, columna, 2, True, True)
            Return True
         Catch ex As Exception
            Return False
         End Try
      End Function

      Public Shared Function Rango(columnaDesde As String, filaDesde As String, columnaHasta As String, filaHasta As String) As String
         Return String.Format("[{0}{1}{2}{3}]", columnaDesde.Trim(), filaDesde.Trim(), columnaHasta.Trim(), filaHasta.Trim())
      End Function

   End Class
End Namespace