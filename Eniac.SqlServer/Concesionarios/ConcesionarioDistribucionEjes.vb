Public Class ConcesionarioDistribucionEjes
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   'INSERT 
   Public Sub DistrubicionEjes_I(idEje As Integer, nombreEje As String, descripcionEje As String, idTipoUnidad As Integer)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4})",
            Entidades.ConcesionarioDistribucionEje.NombreTabla,
            Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString(),
            Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString(),
            Entidades.ConcesionarioDistribucionEje.columnas.DescripcionEje.ToString(),
            Entidades.ConcesionarioDistribucionEje.columnas.IdTipoUnidad.ToString())

         .AppendFormat("   VALUES ({1}, '{2}', '{3}', {4})",
            Entidades.ConcesionarioDistribucionEje.NombreTabla, idEje, nombreEje, descripcionEje, idTipoUnidad)
      End With
      Me.Execute(query.ToString())
   End Sub
   'UDPATE
   Public Sub DistribucionEjes_U(idEje As Integer,
                                 nombreEje As String,
                                 descripcionEje As String,
                                 idTipoUnidad As Integer)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormatLine("UPDATE {0}", Entidades.ConcesionarioDistribucionEje.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString(), nombreEje)
         .AppendFormatLine(" , {0} = '{1}'", Entidades.ConcesionarioDistribucionEje.columnas.DescripcionEje.ToString(), descripcionEje)
         .AppendFormatLine(" , {0} = {1}", Entidades.ConcesionarioDistribucionEje.columnas.IdTipoUnidad.ToString(), idTipoUnidad)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString(), idEje)
      End With
      Me.Execute(query.ToString())
   End Sub
   'DELETE
   Public Sub DistribucionEjes_D(idEje As Integer, nombreEje As String)
      Dim query As StringBuilder = New StringBuilder()

      With query
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.ConcesionarioDistribucionEje.NombreTabla, Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString(), idEje)
      End With
      Me.Execute(query.ToString())
   End Sub
   'SELECT TXT
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ConcesionarioDistribucionEjes.*, ConcesionarioTiposUnidades.NombreTipoUnidad FROM {0} AS ConcesionarioDistribucionEjes", Entidades.ConcesionarioDistribucionEje.NombreTabla)
         .AppendLine(" INNER JOIN ConcesionarioTiposUnidades ON ConcesionarioDistribucionEjes.IdTipoUnidad = ConcesionarioTiposUnidades.IdTipoUnidad")
      End With
   End Sub
   'G
   Private Function DistribucionEjes_G(idEje As Integer,
                                       nombreEje As String,
                                       nombreExacto As Boolean,
                                       descripcionEje As String,
                                       idTipoUnidad As Integer) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE 1 = 1")
         If idEje > 0 Then
            .AppendFormatLine("   AND ConcesionarioDistribucionEjes.IdEje = {0}", idEje)
         End If
         If Not String.IsNullOrWhiteSpace(nombreEje) Then
            If nombreExacto Then
               .AppendFormatLine("   AND ConcesionarioDistribucionEjes.NombreEje = '{0}'", nombreEje)
            Else
               .AppendFormatLine("   AND ConcesionarioDistribucionEjes.NombreEje LIKE '%{0}%'", nombreEje)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcionEje) Then
            .AppendFormatLine("   AND ConcesionarioDistribucionEjes.DescripcionEje LIKE '%{0}%'", descripcionEje)
         End If
         If idTipoUnidad > 0 Then
            .AppendFormatLine("   AND ConcesionarioDistribucionEjes.IdTipoUnidad = {0}", idTipoUnidad)
         End If
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
   'GA
   Public Function DistribucionEje_GA() As DataTable
      Return DistribucionEjes_G(idEje:=0, nombreEje:=String.Empty, nombreExacto:=False, descripcionEje:=String.Empty, idTipoUnidad:=0)
   End Function
   Public Function DistribucionEje_GA(idTipoUnidad As Integer) As DataTable
      Return DistribucionEjes_G(idEje:=0, nombreEje:=String.Empty, nombreExacto:=False, descripcionEje:=String.Empty, idTipoUnidad:=idTipoUnidad)
   End Function
   'G1
   Public Function DistribucionEje_G1(idEje As Integer) As DataTable
      Return DistribucionEjes_G(idEje:=idEje, nombreEje:=String.Empty, nombreExacto:=False, descripcionEje:=String.Empty, idTipoUnidad:=0)
   End Function
   'BUSCAR 
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "ConcesionarioDistribucionEjes." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   'GET CODIGO MAXIMO
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString(), "ConcesionarioDistribucionEjes"))
   End Function
   'GET NOMBRE UNIDO
   Public Function DistribucionEjes_GetNombreUnido() As DataTable
      Dim query As StringBuilder = New StringBuilder("")

      With query
         .Length = 0
         .AppendLine("SELECT ConcesionarioDistribucionEjes.IdEje")
         .AppendLine("     ,ConcesionarioTiposUnidades.NombreTipoUnidad + ' - ' + ConcesionarioDistribucionEjes.NombreEje AS NombreCompleto")
         .AppendLine(" FROM ConcesionarioDistribucionEjes")
         .AppendLine("  INNER JOIN ConcesionarioTiposUnidades ON ConcesionarioDistribucionEjes.IdTipoUnidad = ConcesionarioTiposUnidades.IdTipoUnidad")
         .AppendLine("ORDER BY 2")
      End With
      Return Me.GetDataTable(query.ToString())
   End Function
End Class
