Imports System.Text

Public Class Auditorias
   Inherits Comunes

   'Public Enum Operaciones
   '   Alta
   '   Baja
   '   Modificacion
   '   Correccion
   '   Inactivar
   'End Enum

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Class Campos
      Public Property CamposInsertSelect As String
      Public Property CamposComparar As String
   End Class

   Public Function Campos_G(tabla As String, camposIgnorarComparar As IEnumerable(Of String)) As Campos
      Dim stbCamposInsertSelect = New StringBuilder()
      Dim stbCamposComparar = New StringBuilder()

      'Obtengo los campos que forman esta tabla.
      Dim qry = New StringBuilder("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS")
      qry.AppendFormat(" WHERE TABLE_NAME='{0}'", tabla)
      'Dim comandoSql = String.Format("SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='{0}'", tabla)

      Using reader = ExecuteReadear(qry.ToString())
         Dim columnas = New List(Of String)()
         Do While reader.Read()
            Dim columnName = reader.GetString(0)
            Dim dataType = reader.GetString(1)
            stbCamposInsertSelect.AppendFormat(",{0}", columnName)

            'Debo tener dos strings con los campos porque a la hora de comparar no puedo comparar tipos de datos image (las fotos)
            'por lo que debo cambiar el select que compara para que lo castee a varbinary.
            If Not camposIgnorarComparar.ContainsSecure(columnName) Then
               If dataType.ToLower() = "image" Then
                  stbCamposComparar.AppendFormat(",CAST({0} AS VARBINARY(MAX)) {0}", columnName)
               Else
                  stbCamposComparar.AppendFormat(",{0}", columnName)
               End If
            End If
         Loop
         reader.Close()
         'Saco las comas y los espacios del comienzo y del final.
         Return New Campos With {
            .CamposInsertSelect = stbCamposInsertSelect.ToString().Trim().Trim(","c).Trim(),
            .CamposComparar = stbCamposComparar.ToString().Trim().Trim(","c).Trim()
         }
      End Using

   End Function

   Public Function Auditorias_Duplicado(tabla As String,
                                        campos As String,
                                        clavePrimaria As String) As Boolean
      Dim myQuery As StringBuilder = New StringBuilder()
      'Hago una unión del último y el anteúltimo registro de la auditoría
      With myQuery
         'TOP 1 Ascendente del TOP 2 Descendente me trae el anteúltimo registro.
         .AppendFormat("SELECT *")
         .AppendFormat("  FROM (SELECT TOP 1 {0}", campos)
         .AppendFormat("          FROM (SELECT TOP 2 *")
         .AppendFormat("                  FROM Auditoria{0}", tabla)
         .AppendFormat("                 WHERE {0}", clavePrimaria)
         .AppendFormat("                 ORDER BY FechaAuditoria DESC) Auditoria")
         .AppendFormat("         ORDER BY FechaAuditoria) Auditoria")
         .AppendFormat(" UNION ")      'La unión me trae un solo registro si el último y anteúltimo registros son iguales.
         'TOP 1 Descendente me trae el último registro.
         .AppendFormat("SELECT *")
         .AppendFormat("  FROM (SELECT TOP 1 {0}", campos)
         .AppendFormat("          FROM Auditoria{0}", tabla)
         .AppendFormat("         WHERE {0}", clavePrimaria)
         .AppendFormat("         ORDER BY FechaAuditoria DESC) Auditoria")
      End With

      Dim count As Integer = Me.GetDataTable(myQuery.ToString()).Rows.Count
      'Si el count = 1 los últimos dos registros son IGUALES (duplicado).
      'Si el count = 2 los últimos dos registros son DIFERENTES.
      Return count = 1
   End Function

   Public Sub Auditorias_D(tabla As String,
                           clavePrimaria As String,
                           fechaHora As DateTime)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM Auditoria{0} WHERE {1} AND FechaAuditoria = '{2}'", tabla, clavePrimaria, ObtenerFecha(fechaHora, True))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Auditorias_I(tabla As String,
                           campos As String,
                           operacion As Entidades.OperacionesAuditorias,
                           usuario As String,
                           clavePrimaria As String,
                           fechaHora As DateTime,
                           conMilisegundos As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendFormat("INSERT INTO Auditoria{0}", tabla).AppendLine()
         .AppendFormat("      (FechaAuditoria").AppendLine()
         .AppendFormat("      ,OperacionAuditoria").AppendLine()
         .AppendFormat("      ,UsuarioAuditoria").AppendLine()
         .AppendFormat("      ,{0})", campos).AppendLine()
         .AppendFormat("SELECT '{0}'", Me.ObtenerFecha(fechaHora, True, conMilisegundos)).AppendLine()
         .AppendFormat("      ,'{0}'", operacion.ToString().Substring(0, 1)).AppendLine()
         .AppendFormat("      ,'{0}'", usuario).AppendLine()
         .AppendFormat("      , {0}", campos).AppendLine()
         .AppendFormat("  FROM {0}", tabla).AppendLine()
         .AppendFormat(" WHERE {0}", clavePrimaria).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   'No lo sacamos todavía por si algún subsistema lo usa. REEMPLAZAR EN SUBSISTEMAS A LA BREVEDAD.
   <Obsolete("Usar la regla. REEMPLAZAR EN SUBSISTEMAS A LA BREVEDAD.")>
   Public Sub Auditorias_I(ByVal Tabla As String,
                           ByVal Operacion As Entidades.OperacionesAuditorias,
                           ByVal Usuario As String,
                           ByVal ClavePrimaria As String)

      Dim reader As System.Data.Common.DbDataReader
      Dim SQL As String
      Dim Campos As String = String.Empty

      'Obtengo los campos que forman esta tabla.
      SQL = "select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS "
      SQL = SQL & "where TABLE_NAME='" & Tabla & "'"

      reader = Me.ExecuteReadear(SQL)

      'Dim columnas As List(Of String) = New List(Of String)()

      Do While reader.Read()
         Campos = Campos & ", " & reader.GetString(0)
      Loop
      reader.Close()

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Auditoria" & Tabla)
         .AppendLine("      (FechaAuditoria")
         .AppendLine("      ,OperacionAuditoria")
         .AppendLine("      ,UsuarioAuditoria")
         .AppendLine("      " & Campos & ")")
         .AppendLine("SELECT '" & Me.ObtenerFecha(Date.Now, True) & "'")
         .AppendLine("    ,'" & Operacion.ToString().Substring(0, 1) & "'")
         .AppendLine("    ,'" & Usuario & "'")
         .AppendLine("    " & Campos)
         .AppendLine("  FROM " & Tabla)
         .AppendLine(" WHERE " & ClavePrimaria)
      End With

      Me.Execute(myQuery.ToString())
      'Me.Sincroniza_I(myQuery.ToString(), "Auditorias")

   End Sub

   'Public Sub Auditorias_U(ByVal idCobrador As Integer, _
   '                        ByVal nombreCobrador As String)

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("UPDATE Auditorias SET ")
   '      .AppendLine("   NombreCobrador = '" & nombreCobrador & "'")
   '      .AppendLine(" WHERE IdCobrador = " & idCobrador.ToString())
   '   End With

   '   Me.Execute(stb.ToString())

   'End Sub

   'Public Sub Auditorias_D(ByVal idCobrador As Integer)

   '   Dim stb As StringBuilder = New StringBuilder("")

   '   With stb
   '      .Length = 0
   '      .AppendLine("DELETE FROM Auditorias")
   '      .AppendLine(" WHERE IdCobrador = " & idCobrador.ToString())
   '   End With

   '   Me.Execute(stb.ToString())

   'End Sub

   'Private Sub SelectTexto(ByVal stb As StringBuilder)
   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT C.IdCobrador")
   '      .AppendLine("      ,C.NombreCobrador")
   '      .AppendLine(" FROM Auditorias C")
   '   End With
   'End Sub

   'Public Function Auditorias_GA() As DataTable
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      Me.SelectTexto(stb)
   '      .Append("  ORDER BY C.NombreCobrador")
   '   End With

   '   Return Me.GetDataTable(stb.ToString())
   'End Function

   'Public Function Auditorias_G1(ByVal idCobrador As Integer) As DataTable
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      Me.SelectTexto(stb)
   '      .AppendLine(" WHERE C.IdCobrador = " & idCobrador.ToString())
   '   End With
   '   Return Me.GetDataTable(stb.ToString())
   'End Function

   Public Function Auditorias_G1(ByVal Tabla As String,
                                 ByVal ClavePrimaria As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT TOP(1) * FROM Auditoria" & Tabla)
         .AppendLine(" WHERE " & ClavePrimaria)
         .AppendLine(" ORDER BY FechaAuditoria DESC")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function


   'Public Function GetPorNombre(ByVal nombreCobrador As String) As DataTable
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      Me.SelectTexto(stb)
   '      .AppendLine(" WHERE C.NombreCobrador LIKE '%" & nombreCobrador & "%'")
   '      .AppendLine(" ORDER BY C.NombreCobrador")
   '   End With
   '   Return Me.GetDataTable(stb.ToString())
   'End Function

   'Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
   '   columna = "C." + columna
   '   'If columna = "S.NombreLocalidad" Then columna = columna.Replace("S.", "L.")
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      Me.SelectTexto(stb)
   '      .AppendLine("  WHERE ")
   '      .Append(columna)
   '      .Append(" LIKE '%")
   '      .Append(valor)
   '      .Append("%'")
   '   End With
   '   Return Me.GetDataTable(stb.ToString())
   'End Function

   'Public Function Auditorias_GetIdMaximo() As DataTable
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT MAX(IdCobrador) AS maximo ")
   '      .AppendLine(" FROM Auditorias")
   '   End With
   '   Return Me.GetDataTable(stb.ToString())
   'End Function

End Class

