Public Class CalidadListasControlTipos
   Inherits Comunes

#Region "Constructores"
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub
#End Region

   Public Sub CalidadListasControlTipos_I(idTipoListaControl As Integer,
                                          nombreTipoListaControl As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControlTipo.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idTipoListaControl)
         .AppendFormatLine("	 , '{0}'", nombreTipoListaControl)
         .AppendFormatLine(")")
      End With

      Execute(query)
   End Sub

   Public Sub CalidadListasControlTipos_U(idTipoListaControl As Integer,
                                          nombreTipoListaControl As String)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadListaControlTipo.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString(), nombreTipoListaControl)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString(), idTipoListaControl)
      End With
      Execute(query)
   End Sub

   Public Sub CalidadListasControlTipos_D(idTipoListaControl As Integer)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("DELETE {0}", Entidades.CalidadListaControlTipo.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString(), idTipoListaControl)
      End With
      Execute(query)
   End Sub

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT LCT.*")
         .AppendFormatLine("  FROM {0} LCT", Entidades.CalidadListaControlTipo.NombreTabla)
      End With
   End Sub
   Public Function CalidadListasControlTipos_GA() As DataTable
      Return CalidadListasControlTipos_G(idTipoListaControl:=0, nombreListaControlTipo:=String.Empty, nombreExacto:=False)
   End Function
   Public Function CalidadListasControlTipos_G1(idTipoListaControl As Integer) As DataTable
      Return CalidadListasControlTipos_G(idTipoListaControl, nombreListaControlTipo:=String.Empty, nombreExacto:=False)
   End Function
   Public Function CalidadListasControlTipos_GA(nombreListaControlTipo As String, nombreExacto As Boolean) As DataTable
      Return CalidadListasControlTipos_G(idTipoListaControl:=0, nombreListaControlTipo, nombreExacto)
   End Function
   Public Function CalidadListasControlTipos_G(idTipoListaControl As Integer, nombreListaControlTipo As String, nombreExacto As Boolean) As DataTable
      Dim query = New StringBuilder()
      With query
         SelectTexto(query)
         .AppendFormatLine(" WHERE 1 = 1")
         If idTipoListaControl <> 0 Then
            .AppendFormatLine("   AND LCT.{0} = {1}", Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString(), idTipoListaControl)
         End If
         If Not String.IsNullOrWhiteSpace(nombreListaControlTipo) Then
            If nombreExacto Then
               .AppendFormatLine("   AND LCT.{0} = '{1}'", Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString(), nombreListaControlTipo)
            Else
               .AppendFormatLine("   AND LCT.{0} LIKE '%{1}%'", Entidades.CalidadListaControlTipo.Columnas.NombreListaControlTipo.ToString(), nombreListaControlTipo)
            End If
         End If
      End With
      Return GetDataTable(query)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "LCT.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.CalidadListaControlTipo.Columnas.IdListaControlTipo.ToString(), Entidades.CalidadListaControlTipo.NombreTabla).ToInteger()
   End Function

End Class