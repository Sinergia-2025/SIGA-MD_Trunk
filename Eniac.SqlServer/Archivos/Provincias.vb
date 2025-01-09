Imports Eniac.Entidades

Public Class Provincias
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT P.IdProvincia")
         .AppendLine("      ,P.NombreProvincia")
         .AppendLine("      ,P.Jurisdiccion")
         .AppendLine("      ,P.EsAgentePercepcion")
         .AppendLine("      ,P.IngBrutos")
         .AppendLine("      ,P.AgenteIngBrutos")
         .AppendLine("      ,P.IdCuentaDebe")
         .AppendLine("      ,CCD.NombreCuenta AS NombreCuentaDebe")
         .AppendLine("      ,P.IdCuentaHaber")
         .AppendLine("      ,CCH.NombreCuenta AS NombreCuentaHaber")
         .AppendLine("      ,P.IdPais, PA.NombrePais")
         .AppendFormatLine("      ,P.{0}", Entidades.Provincia.Columnas.IdAFIPProvincia.ToString())
         .AppendLine("  FROM Provincias P ")
         .AppendLine("  LEFT JOIN ContabilidadCuentas AS CCD ON CCD.idCuenta = P.IdCuentaDebe")
         .AppendLine("  LEFT JOIN ContabilidadCuentas AS CCH ON CCH.idCuenta = P.IdCuentaHaber")
         .AppendLine("  LEFT JOIN Paises AS PA ON PA.IdPais = P.IdPais")
      End With
   End Sub

   Public Function Provincias_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine("  ORDER BY PA.NombrePais, P.NombreProvincia")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Provincias_G1(ByVal IdProvincia As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE P.IdProvincia = '" & IdProvincia & "'")
         .AppendLine("  ORDER BY PA.NombrePais, P.NombreProvincia")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Sub Provincias_U(IdProvincia As String,
                           EsAgentePercepcion As Boolean,
                           IngBrutos As String,
                           AgenteIngBrutos As String,
                           IdCuentaDebe As Long,
                           IdCuentaHaber As Long,
                           Jurisdiccion As Integer,
                           IdPais As String,
                           idAFIPProvincia As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("UPDATE  ")
         .Append("Provincias  ")
         .Append("SET  ")
         .AppendFormat("   EsAgentePercepcion = '{0}',", EsAgentePercepcion)
         .AppendFormat("   IngBrutos = '{0}',", IngBrutos)
         .AppendFormat("   AgenteIngBrutos = '{0}'", AgenteIngBrutos)
         If IdCuentaDebe > 0 Then
            .AppendFormat("  ,IdCuentaDebe = {0}", IdCuentaDebe)
         Else
            .AppendFormat("  ,IdCuentaDebe = NULL")
         End If
         If IdCuentaHaber > 0 Then
            .AppendFormat("  ,IdCuentaHaber = {0}", IdCuentaDebe)
         Else
            .AppendFormat("  ,IdCuentaHaber = NULL")
         End If
         .AppendFormat("  ,Jurisdiccion = {0}", Jurisdiccion)
         .AppendFormat("  ,IdPais = '{0}'", IdPais)
         .AppendFormat("  ,IdAFIPProvincia = {0}", idAFIPProvincia)
         .Append("   WHERE ")
         .AppendFormat("IdProvincia = '{0}'", IdProvincia)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreCuentaDebe" Then
         columna = "CCD.NombreCuenta"
      ElseIf columna = "NombreCuentaHaber" Then
         columna = "CCH.NombreCuenta"
      ElseIf columna = "NombrePais" Then
         columna = "PA." + columna
      Else
         columna = "P." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
         .AppendLine("  ORDER BY PA.NombrePais, P.NombreProvincia")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   'Public Function Buscar(ByVal IdProvincia As String) As DataTable
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   If Entidad.Columna = "IdProvincia" Then Entidad.Columna = "L." + Entidad.Columna
   '   With stbQuery
   '      .Append("SELECT")
   '      .Append(" L.IdLocalidad")
   '      .Append(", L.IdProvincia")
   '      .Append(", P.NombreProvincia")
   '      .Append(", L.NombreLocalidad")
   '      .Append("FROM  ")
   '      .Append("Provincias P ")
   '      .Append("  INNER JOIN Provincias P ON L.IdProvincia = P.IdProvincia ")
   '      .Append("  WHERE ")
   '      .Append(Entidad.Columna)
   '      .Append(" LIKE '%")
   '      .Append(Entidad.Valor.ToString())
   '      .Append("%'")
   '   End With
   '   Return Me.da.GetDataTable(stbQuery.ToString())
   'End Function

End Class