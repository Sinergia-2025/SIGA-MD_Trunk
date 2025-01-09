Public Class EstadosTurismo
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub EstadosTurismo_I(idEstadoTurismo As Integer,
                                    nombreEstadoTurismo As String,
                                    posicion As Integer,
                                    finalizado As Boolean,
                                    porDefecto As Boolean,
                                    solicitaPasajeros As Boolean,
                                    color As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO EstadosTurismo ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                           Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString(),
                           Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString(),
                           Entidades.EstadoTurismo.Columnas.Posicion.ToString(),
                           Entidades.EstadoTurismo.Columnas.Finalizado.ToString(),
                           Entidades.EstadoTurismo.Columnas.PorDefecto.ToString(),
                           Entidades.EstadoTurismo.Columnas.SolicitaPasajeros.ToString(),
                           Entidades.EstadoTurismo.Columnas.Color.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, {6}",
                           idEstadoTurismo, nombreEstadoTurismo, posicion,
                           GetStringFromBoolean(finalizado),
                           GetStringFromBoolean(porDefecto),
                           GetStringFromBoolean(solicitaPasajeros),
                           GetStringFromNumber(color))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EstadosTurismo_U(idEstadoTurismo As Integer,
                                    nombreEstadoTurismo As String,
                                    posicion As Integer,
                                    finalizado As Boolean,
                                    porDefecto As Boolean,
                                    solicitaPasajeros As Boolean,
                                    color As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE EstadosTurismo ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString(), nombreEstadoTurismo)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoTurismo.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoTurismo.Columnas.Finalizado.ToString(), GetStringFromBoolean(finalizado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoTurismo.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoTurismo.Columnas.SolicitaPasajeros.ToString(), GetStringFromBoolean(solicitaPasajeros))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoTurismo.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString(), idEstadoTurismo)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub EstadosTurismo_D(IdEstadoCalidad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM EstadosTurismo WHERE {0} = '{1}'", Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString(), IdEstadoCalidad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EN.* ")
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "Finalizado"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "PorDefecto"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "SolicitaPasajeros"))
         .AppendFormatLine("  FROM EstadosTurismo AS EN")

      End With
   End Sub

   Public Function EstadosTurismo_GA() As DataTable
      Return EstadosTurismo_GA(False)
   End Function
   Public Function EstadosTurismo_GA(ordenarPosicion As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If ordenarPosicion Then
            .AppendFormat(" ORDER BY  EN.Posicion")
         Else
            .AppendFormat(" ORDER BY  EN.NombreEstadoTurismo")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function EstadosTurismo_G1(IdEstadoCalidad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE EN.{0} = {1}", Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString(), IdEstadoCalidad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "Finalizado_SN" Then
         columna = "CASE WHEN EN.Finalizado = 0 THEN 'NO' ELSE 'SI' END"
      ElseIf columna = "PorDefecto_SN" Then
         columna = "CASE WHEN EN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
      ElseIf columna = "SolicitaPasajeros_SN" Then
         columna = "CASE WHEN EN.SolicitaPasajeros = 0 THEN 'NO' ELSE 'SI' END"
      Else
         columna = "EN." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString(), "EstadosTurismo"))
   End Function

   Public Function EstadosTurismo_GxDefecto() As Integer
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE PorDefecto = 'True'")
      End With

      Return Integer.Parse(Me.GetDataTable(stb.ToString()).Rows(0).Item("IdEstadoTurismo").ToString())

   End Function

   Public Function EstadosTurismo_GSolicitaPasajero() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE SolicitaPasajeros = 'True'")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function EstadosTurismo_GxNombre(Nombre As String) As Integer
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE NombreEstadoCalidad LIKE  '%" & Nombre & "%'")
      End With

      Return Integer.Parse(Me.GetDataTable(stb.ToString()).Rows(0).Item("Color").ToString())

   End Function

   Public Function EstadosTurismo_GFinalizado() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE Finalizado = 'True'")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
