#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Entidades
#End Region
Public Class AplicacionesEdicionesModulos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AplicacionesEdicionesModulos_I(idEdicion As String,
                                      idAplicacion As String,
                                      idModulo As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO AplicacionesEdicionesModulos ({0}, {1}, {2})",
                       AplicacionEdicionModulo.Columnas.IdEdicion.ToString(),
                       AplicacionEdicionModulo.Columnas.IdAplicacion.ToString(),
                       AplicacionEdicionModulo.Columnas.IdModulo.ToString()).AppendLine()
         .AppendFormat("     VALUES ('{0}', '{1}', {2})",
                       idEdicion, idAplicacion, idModulo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AplicacionesEdicionesModulos_U(idEdicion As String,
                                      idAplicacion As String,
                                      idModulo As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("UPDATE AplicacionesEdicionesModulos ")
         .AppendFormat("   SET {0} = {1}", AplicacionEdicionModulo.Columnas.IdModulo.ToString(), idModulo).AppendLine()
         .AppendFormat(" WHERE {0} = '{1}'", AplicacionEdicionModulo.Columnas.IdEdicion.ToString(), idEdicion)
         .AppendFormat("   AND {0} = '{1}'", AplicacionEdicionModulo.Columnas.IdAplicacion.ToString(), idAplicacion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AplicacionesEdicionesModulos_D(idEdicion As String,
                                      idAplicacion As String)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM AplicacionesEdicionesModulos ")
         .AppendFormat(" WHERE {0} = '{1}'", AplicacionEdicionModulo.Columnas.IdEdicion.ToString(), idEdicion)
         .AppendFormat("   AND {0} = '{1}'", AplicacionEdicionModulo.Columnas.IdAplicacion.ToString(), idAplicacion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendFormat("SELECT AEM.*, AM.NombreModulo FROM AplicacionesEdicionesModulos AS AEM").AppendLine()
         .AppendFormat(" LEFT JOIN AplicacionesModulos AS AM ON AM.IdModulo = AEM.IdModulo")
      End With
   End Sub

   'Public Function AplicacionesEdicionesModulos_GA() As DataTable
   '   Return AplicacionesEdicionesModulos_GA(idEdicion:=, idAplicacion:=)
   'End Function

   Public Function AplicacionesEdicionesModulos_GA(idEdicion As String, idAplicacion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE {0} = '{1}'", AplicacionEdicionModulo.Columnas.IdEdicion.ToString(), idEdicion)
         .AppendFormat("   AND {0} = '{1}'", AplicacionEdicionModulo.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormat(" ORDER BY AEM.IdAplicacion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AplicacionesEdicionesModulos_G1(idEdicion As String, idAplicacion As String, idModulo As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE ID.{0} = '{1}'", AplicacionEdicionModulo.Columnas.IdEdicion.ToString(), idEdicion)
         .AppendFormat("   AND ID.{0} = '{1}'", AplicacionEdicionModulo.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormat("   AND ID.{0} = {1}", AplicacionEdicionModulo.Columnas.IdModulo.ToString(), idModulo)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreModulo" Then
         columna = "AM." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(ByVal Campo As String) As Long
      Dim result As Long = 0
      Dim columnAlias As String = "Maximo"
      Dim dt As DataTable = Me.GetDataTable(String.Format("SELECT MAX({0}) AS {1} FROM AplicacionesEdicionesModulos WHERE {0} <> 999", Campo, columnAlias))
      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(columnAlias) Then
         If Not IsDBNull(dt.Rows(0)(columnAlias)) AndAlso Not String.IsNullOrWhiteSpace(dt.Rows(0)(columnAlias).ToString()) Then
            If Not Long.TryParse(dt.Rows(0)(columnAlias).ToString(), result) Then
               result = 0
            End If
         End If
      End If

      Return result
   End Function

   'Public Function GetInteres(ByVal formaPago As Integer, ByVal cuotas As Integer, ByVal IdInteres As Integer) As Decimal

   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery

   '      .Append(" SELECT * ")
   '      .Append(" FROM AplicacionesEdicionesModulos I ")
   '      .Append(" WHERE ((SELECT Dias FROM FichasFormasPago FP ")
   '      .Append(" WHERE IdFormasPago = " & formaPago & ") * " & cuotas & ") >= I.DiasDesde  ")
   '      .Append(" AND ((SELECT Dias FROM FichasFormasPago FP ")
   '      .Append(" WHERE IdFormasPago = " & formaPago & ") * " & cuotas & ") <= I.DiasHasta ")
   '      .Append(" AND IdInteres = " & IdInteres)

   '   End With
   '   Dim dt As DataTable = GetDataTable(stbQuery.ToString())
   '   If dt.Rows.Count = 0 Then
   '      Return 0
   '   Else
   '      Return Decimal.Parse(dt.Rows(0)("Interes").ToString())
   '   End If

   'End Function

   'Public Function GetInteresVentas(formaPago As Integer, cuotas As Integer, IdInteres As Integer) As Decimal

   '   Dim stbQuery As StringBuilder = New StringBuilder()
   '   With stbQuery
   '      .AppendFormat("SELECT I.* ").AppendLine()
   '      .AppendFormat("  FROM AplicacionesEdicionesModulos I ").AppendLine()
   '      .AppendFormat(" CROSS JOIN (SELECT * FROM VentasFormasPago WHERE IdFormasPago = {0}) VFP", formaPago).AppendLine()
   '      .AppendFormat(" WHERE (VFP.Dias * {0}) >= I.DiasDesde ", cuotas).AppendLine()
   '      .AppendFormat("   AND (VFP.Dias * {0}) <= I.DiasHasta ", cuotas).AppendLine()
   '      .AppendFormat("   AND IdInteres = {0}", IdInteres).AppendLine()
   '   End With
   '   Dim dt As DataTable = GetDataTable(stbQuery.ToString())
   '   If dt.Rows.Count = 0 Then
   '      Return 0
   '   Else
   '      Return Decimal.Parse(dt.Rows(0)("Interes").ToString())
   '   End If
   'End Function

   'Public Function GetInteresVentasSegunDias(dias As Integer, idInteres As Integer) As Decimal
   '   Dim stbQuery As StringBuilder = New StringBuilder()
   '   With stbQuery
   '      .AppendFormatLine("SELECT I.* ")
   '      .AppendFormatLine("  FROM AplicacionesEdicionesModulos I")
   '      .AppendFormatLine(" WHERE I.DiasDesde <= {0} And I.DiasHasta >= {0}", dias)
   '      .AppendFormatLine("   AND I.IdInteres = {0}", idInteres)
   '   End With
   '   Dim dt As DataTable = GetDataTable(stbQuery.ToString())
   '   If dt.Rows.Count = 0 Then
   '      Return 0
   '   Else
   '      Return Decimal.Parse(dt.Rows(0)("Interes").ToString())
   '   End If
   'End Function

End Class