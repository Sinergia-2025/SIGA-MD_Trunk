Public Class EstadosListasControl
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadEstadosListasControl_I(idEstadoListaControl As Integer,
                                    nombreEstadoListaControl As String,
                                    posicion As Integer,
                                    finalizado As Boolean,
                                    porDefecto As Boolean,
                                    color As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO CalidadEstadosListasControl ({0}, {1}, {2}, {3}, {4}, {5})",
                           Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString(),
                           Entidades.EstadoListaControl.Columnas.NombreEstadoCalidad.ToString(),
                           Entidades.EstadoListaControl.Columnas.Posicion.ToString(),
                           Entidades.EstadoListaControl.Columnas.Finalizado.ToString(),
                           Entidades.EstadoListaControl.Columnas.PorDefecto.ToString(),
                           Entidades.EstadoListaControl.Columnas.Color.ToString())
         .AppendFormatLine("     VALUES ({0}, '{1}', {2}, {3}, {4}, {5}",
                           idEstadoListaControl, nombreEstadoListaControl, posicion,
                           GetStringFromBoolean(finalizado),
                           GetStringFromBoolean(porDefecto),
                           GetStringFromNumber(color))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CalidadEstadosListasControl_U(idEstadoListaControl As Integer,
                                    nombreEstadoListaControl As String,
                                    posicion As Integer,
                                    finalizado As Boolean,
                                    porDefecto As Boolean,
                                    color As Integer?)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadEstadosListasControl ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.EstadoListaControl.Columnas.NombreEstadoCalidad.ToString(), nombreEstadoListaControl)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoListaControl.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoListaControl.Columnas.Finalizado.ToString(), GetStringFromBoolean(finalizado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoListaControl.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.EstadoListaControl.Columnas.Color.ToString(), GetStringFromNumber(color))
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString(), idEstadoListaControl)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CalidadEstadosListasControl_D(IdEstadoCalidad As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM CalidadEstadosListasControl WHERE {0} = '{1}'", Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString(), IdEstadoCalidad)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT EN.* ")
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "Finalizado"))
         .AppendFormatLine("     , {0}", ConvertirBitSiNo("EN", "PorDefecto"))
         .AppendFormatLine("  FROM CalidadEstadosListasControl AS EN")

      End With
   End Sub

   Public Function CalidadEstadosListasControl_GA() As DataTable
      Return CalidadEstadosListasControl_GA(False)
   End Function
   Public Function CalidadEstadosListasControl_GA(ordenarPosicion As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         If ordenarPosicion Then
            .AppendFormat(" ORDER BY  EN.Posicion")
         Else
            .AppendFormat(" ORDER BY  EN.NombreEstadoCalidad")
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CalidadEstadosListasControl_G1(IdEstadoCalidad As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE EN.{0} = {1}", Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString(), IdEstadoCalidad)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If  columna = "Finalizado_SN" Then
         columna = "CASE WHEN EN.Finalizado = 0 THEN 'NO' ELSE 'SI' END"
      ElseIf columna = "PorDefecto_SN" Then
         columna = "CASE WHEN EN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
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
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString(), "CalidadEstadosListasControl"))
   End Function

   Public Function CalidadEstadosListasControl_GxDefecto() As Integer
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE PorDefecto = 'True'")
      End With

      Return Integer.Parse(Me.GetDataTable(stb.ToString()).Rows(0).Item("IdEstadoCalidad").ToString())

   End Function

   Public Function CalidadEstadosListasControl_GxNombre(Nombre As String) As Integer
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE NombreEstadoCalidad LIKE  '%" & Nombre & "%'")
      End With

      Return Integer.Parse(Me.GetDataTable(stb.ToString()).Rows(0).Item("Color").ToString())

   End Function
   Public Function CalidadEstadosListasControl_GxId(Id As Integer) As Integer
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE IdEstadoCalidad = " & Id)
      End With

      Return Integer.Parse(Me.GetDataTable(stb.ToString()).Rows(0).Item("Color").ToString())

   End Function
   Public Function CalidadEstadosListasControl_GFinalizado() As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE Finalizado = 'True'")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

End Class
