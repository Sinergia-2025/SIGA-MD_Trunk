Public Class CalidadListasControl
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadListasControl_I(idListaControl As Integer, nombreListaControl As String, orden As Integer,
                                     idListaControlTipo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControl.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControl.Columnas.IdListaControl.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControl.Columnas.NombreListaControl.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControl.Columnas.Orden.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControl.Columnas.IdListaControlTipo.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idListaControl)
         .AppendFormatLine("	 , '{0}'", nombreListaControl)
         .AppendFormatLine("	 ,  {0} ", orden)
         .AppendFormatLine("	 ,  {0} ", idListaControlTipo)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControl_U(idListaControl As Integer, nombreListaControl As String, orden As Integer,
                                     idListaControlTipo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadListaControl.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadListaControl.Columnas.NombreListaControl.ToString(), nombreListaControl.Trim())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadListaControl.Columnas.Orden.ToString(), orden)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CalidadListaControl.Columnas.IdListaControlTipo.ToString(), idListaControlTipo)

         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadListaControl.Columnas.IdListaControl.ToString(), idListaControl)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControl_D(idListaControl As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CalidadListaControl.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CalidadListaControl.Columnas.IdListaControl.ToString(), idListaControl)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TA.*")
         .AppendFormatLine("     , CLCT.NombreListaControlTipo")
         .AppendFormatLine("  FROM CalidadListasControl AS TA")
         .AppendFormatLine(" INNER JOIN CalidadListasControlTipos CLCT ON TA.IdListaControlTipo = CLCT.IdListaControlTipo")
      End With
   End Sub

   Private Function CalidadListasControl_G(idListaControl As Integer, nombreListaControl As String, nombreExacto As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idListaControl <> 0 Then
            .AppendFormatLine("   AND TA.idListaControl = '{0}'", idListaControl)
         End If
         If Not String.IsNullOrWhiteSpace(nombreListaControl) Then
            If nombreExacto Then
               .AppendFormatLine("   AND TA.NombreListaControl = '{0}'", nombreListaControl)
            Else
               .AppendFormatLine("   AND TA.NombreListaControl LIKE '%{0}%'", nombreListaControl)
            End If
         End If
         .AppendLine(" ORDER BY TA.Orden")
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function CalidadListasControl_GA() As DataTable
      Return CalidadListasControl_G(idListaControl:=Nothing, nombreListaControl:=String.Empty, nombreExacto:=False)
   End Function
   Public Function CalidadListasControl_G1(idListaControl As Integer) As DataTable
      Return CalidadListasControl_G(idListaControl:=idListaControl, nombreListaControl:=String.Empty, nombreExacto:=False)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "TA.",
                    New Dictionary(Of String, String) From {{"NombreListaControlTipo", "CLCT.NombreListaControlTipo"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.CalidadListaControl.Columnas.IdListaControl.ToString(), Entidades.CalidadListaControl.NombreTabla).ToInteger()
   End Function

End Class