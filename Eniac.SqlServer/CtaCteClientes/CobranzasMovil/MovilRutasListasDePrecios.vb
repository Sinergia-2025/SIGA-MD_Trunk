Public Class MovilRutasListasDePrecios
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MovilRutasListasDePrecios_I(idRuta As Integer, idListaPrecios As Integer, porDefecto As Boolean, aplicaPreciosOferta As Boolean)
      Dim qry As StringBuilder = New StringBuilder()
      With qry
         .AppendFormatLine("INSERT INTO {0}", Entidades.MovilRutaListaDePrecios.NombreTabla)
         .AppendFormatLine("        ({0}, {1},{2},{3})",
                           Entidades.MovilRutaListaDePrecios.Columnas.IdRuta.ToString(),
                           Entidades.MovilRutaListaDePrecios.Columnas.IdListaPrecios.ToString(),
                           Entidades.MovilRutaListaDePrecios.Columnas.PorDefecto.ToString(),
                           Entidades.MovilRutaListaDePrecios.Columnas.AplicaPreciosOferta.ToString())
         .AppendFormatLine(" VALUES ({0}, {1}, {2}, {3})", idRuta, idListaPrecios, GetStringFromBoolean(porDefecto), GetStringFromBoolean(aplicaPreciosOferta))
      End With
      Me.Execute(qry.ToString())
   End Sub

   Public Sub MovilRutasListasDePrecios_U(idRuta As Integer, idListaPrecios As Integer, porDefecto As Boolean, aplicaPreciosOferta As Boolean)
      Throw New NotImplementedException("No se puede actualizar una RutaListaDePrecios")
      'Armo el método por si en el futuro se usa, por el momento lo dejo todo comentado
      'Dim qry As StringBuilder = New StringBuilder()
      'With qry
      '   .AppendFormat("UPDATE RutasListasDePrecios SET ")
      '   .AppendFormat("       {0} = '{1}'", Entidades.RutaListaDePrecios.Columnas.xxxx.ToString(), "")
      '   .AppendFormat(" WHERE {0} = {1}", Entidades.RutaListaDePrecios.Columnas.IdRuta.ToString(), IdRuta)
      '   .AppendFormat("   AND {0} = {1}", Entidades.RutaListaDePrecios.Columnas.IdListaPrecios.ToString(), IdListaPrecios)
      'End With
      'Me.Execute(qry.ToString())
   End Sub

   Public Sub MovilRutasListasDePrecios_D(idRuta As Integer, idListaPrecios As Integer)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM {0}", Entidades.MovilRutaListaDePrecios.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.MovilRutaListaDePrecios.Columnas.IdRuta.ToString(), idRuta)
         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.MovilRutaListaDePrecios.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         End If
      End With
      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT RL.*")
         .AppendFormatLine("      ,R.NombreRuta")
         .AppendFormatLine("      ,L.NombreListaPrecios")
         .AppendFormatLine("  FROM {0} RL", Entidades.MovilRutaListaDePrecios.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} R ON R.IdRuta = RL.IdRuta", Entidades.MovilRuta.NombreTabla)
         .AppendFormatLine(" INNER JOIN ListasDePrecios L ON L.IdListaPrecios = RL.IdListaPrecios")
      End With
   End Sub

   Private Function MovilRutasListasDePrecios_G(idRuta As Integer, idListaPrecios As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idRuta > 0 Then
            .AppendFormatLine("   AND RL.{0} = {1}", Entidades.MovilRutaListaDePrecios.Columnas.IdRuta.ToString(), idRuta)
         End If
         If idListaPrecios > -1 Then
            .AppendFormatLine("   AND RL.{0} = {1}", Entidades.MovilRutaListaDePrecios.Columnas.IdListaPrecios.ToString(), idListaPrecios)
         End If
         .AppendFormatLine(" ORDER BY R.NombreRuta, L.NombreListaPrecios")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function MovilRutasListasDePrecios_GA(idRuta As Integer) As DataTable
      Return MovilRutasListasDePrecios_G(idRuta, idListaPrecios:=-1)
   End Function

   Public Function MovilRutasListasDePrecios_G1(idRuta As Integer, idListaPrecios As Integer) As DataTable
      Return MovilRutasListasDePrecios_G(idRuta, idListaPrecios)
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = Entidades.MovilRuta.Columnas.NombreRuta.ToString() Then
         columna = "R." + columna
      ElseIf columna = Eniac.Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString() Then
         columna = "L." + columna
      Else
         columna = "RL." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class