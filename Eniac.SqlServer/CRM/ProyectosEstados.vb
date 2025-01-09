Public Class ProyectosEstados
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProyectosEstados_I(idEstado As Integer,
                                  nombreEstado As String,
                                  finalizado As Boolean,
                                  color As Integer?,
                                  posicion As Integer?)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .Length = 0
         .AppendLine("INSERT INTO ProyectosEstados(")
         .AppendLine("            IdEstado")
         .AppendLine("           ,NombreEstado")
         .AppendLine("           ,Finalizado")
         .AppendLine("           ,Color")
         .AppendLine("           ,Posicion")
         .AppendLine(") VALUES (")
         .AppendFormatLine("  {0}", idEstado)
         .AppendFormatLine(",'{0}'", nombreEstado)
         .AppendFormatLine(", {0}", GetStringFromBoolean(finalizado))
         .AppendFormatLine(", {0}", GetStringFromNumber(color))
         .AppendFormatLine(", {0}", GetStringFromNumber(posicion))
         .AppendLine(")")
      End With

      Me.Execute(query.ToString())

   End Sub

   Public Sub ProyectosEstados_U(idEstado As Integer,
                                  nombreEstado As String,
                                  finalizado As Boolean,
                                  color As Integer?,
                                  posicion As Integer?)

      Dim query As StringBuilder = New StringBuilder()

      With query
         .Append("UPDATE ProyectosEstados")
         .AppendFormatLine("  SET NombreEstado = '{0}'", nombreEstado)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ProyectoEstado.Columnas.Finalizado.ToString(), GetStringFromBoolean(finalizado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ProyectoEstado.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.ProyectoEstado.Columnas.Posicion.ToString(), GetStringFromNumber(posicion))
         .AppendFormatLine(" WHERE IdEstado = {0}", idEstado)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProyectosEstados_D(idEstado As Integer)
        Dim query As StringBuilder = New StringBuilder()

        With query
            .AppendFormat("DELETE FROM ProyectosEstados WHERE IdEstado = {0}", idEstado)
        End With

        Me.Execute(query.ToString())
    End Sub

    Private Sub SelectTexto(ByVal stb As StringBuilder)

        With stb
            .Length = 0
            .AppendFormatLine("SELECT PE.*")
            .AppendFormatLine("     , {0}", ConvertirBitSiNo("PE", "Finalizado"))
            .AppendLine("FROM ProyectosEstados PE")
        End With

    End Sub

    Public Function ProyectosEstados_GA() As DataTable
        Dim query As StringBuilder = New StringBuilder()
        With query
            Me.SelectTexto(query)
            .AppendLine("  ORDER BY PE.NombreEstado")
        End With

        Return Me.GetDataTable(query.ToString())
    End Function

    Public Function ProyectosEstados_G1(idEstado As Integer) As DataTable
        Dim query As StringBuilder = New StringBuilder()
        With query
            Me.SelectTexto(query)
            .AppendFormat(" WHERE IdEstado = {0}", idEstado)
        End With

        Return Me.GetDataTable(query.ToString())
    End Function

    Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

        'columna = "TND." + columna

        If columna = "Finalizado_SN" Then
            columna = "CASE WHEN PE.Finalizado = 0 THEN 'NO' ELSE 'SI' END"
        Else
            columna = "PE." + columna
        End If

        Dim query As StringBuilder = New StringBuilder()
        With query
            Me.SelectTexto(query)
            .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
        End With

        Return Me.GetDataTable(query.ToString())
    End Function

    Public Overloads Function GetCodigoMaximo() As Integer
        Return Integer.Parse(MyBase.GetCodigoMaximo("IdEstado", "ProyectosEstados").ToString())
    End Function

End Class
