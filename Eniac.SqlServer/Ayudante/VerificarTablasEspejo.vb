Option Strict On
Option Explicit On
Namespace Ayudante
   Public Class VerificarTablasEspejo
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub


      Public Function ObtenerCamposDeTabla(tabla As String,
                                           Optional replaceOrigen As String = "",
                                           Optional replaceDestico As String = "") As Dictionary(Of String, Entidades.Ayudante.VerificarTablasEspejo.CamposTabla)
         Dim result As Dictionary(Of String, Entidades.Ayudante.VerificarTablasEspejo.CamposTabla) = New Dictionary(Of String, Entidades.Ayudante.VerificarTablasEspejo.CamposTabla)()
         Dim sql As StringBuilder = New StringBuilder()
         sql.AppendLine("SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS")
         sql.AppendFormat(" WHERE TABLE_NAME='{0}'", tabla)

         Dim dt As DataTable = Me.GetDataTable(sql.ToString())

         For Each dr As DataRow In dt.Rows
            Dim nombre As String = dr("COLUMN_NAME").ToString()
            If Not String.IsNullOrWhiteSpace(replaceOrigen) Or Not String.IsNullOrWhiteSpace(replaceDestico) Then
               nombre = nombre.Replace(replaceOrigen, replaceDestico)
            End If
            If Not result.ContainsKey(nombre) Then
               result.Add(nombre, New Entidades.Ayudante.VerificarTablasEspejo.CamposTabla(nombre, GetDataType(dr)))
            End If
         Next

         Return result
      End Function

      Private Function GetDataType(dr As DataRow) As String
         Dim data_type As String = dr("DATA_TYPE").ToString()
         Dim result As String = String.Empty
         Select Case data_type
            Case "bit"
               result = "Boolean"
            Case "int"
               result = "Integer"
            Case "bigint"
               result = "Long"
            Case "smallint"
               result = "Short"
            Case "datetime"
               result = "DateTime"
            Case "decimal"
               result = "Decimal"
               If Not String.IsNullOrWhiteSpace(dr("NUMERIC_PRECISION").ToString()) Then
                  result += String.Format("({0},{1})", dr("NUMERIC_PRECISION"), dr("NUMERIC_SCALE"))
               End If
            Case "varchar", "nvarchar"
               result = "String"
               If Not String.IsNullOrWhiteSpace(dr("CHARACTER_MAXIMUM_LENGTH").ToString()) Then
                  result += String.Format("({0})", dr("CHARACTER_MAXIMUM_LENGTH"))
               End If
            Case Else
               result = data_type
         End Select
         Return result
      End Function
   End Class
End Namespace