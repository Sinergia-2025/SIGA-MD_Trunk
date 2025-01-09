Public Class TurismoTiposViajes
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TurismoTiposViajes_I(idTipoViaje As Integer,
                                   descripcionTipoViaje As String,
                                   cantidadDiasUltimaCuota As Integer,
                                   idInteres As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO TurismoTiposViajes ({0}, {1}, {2}, {3})",
                           Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString(),
                           Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString(),
                           Entidades.TurismoTipoViaje.Columnas.CantidadDiasUltimaCuota.ToString(),
                           Entidades.TurismoTipoViaje.Columnas.IdInteres.ToString())
         .AppendFormatLine(" VALUES ( ")
         .AppendFormatLine("        {0} ", idTipoViaje)
         .AppendFormatLine("     , '{0}'", descripcionTipoViaje)
         .AppendFormatLine("     ,  {0} ", cantidadDiasUltimaCuota)
         .AppendFormatLine("     ,  {0} ", GetStringFromNumber(idInteres))
         .AppendFormatLine("        ) ")
      End With
      Execute(myQuery)
   End Sub
   Public Sub TurismoTiposViajes_U(idTipoViaje As Integer,
                                   descripcionTipoViaje As String,
                                   cantidadDiasUltimaCuota As Integer,
                                   idInteres As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE TurismoTiposViajes SET")
         .AppendFormatLine("       {0} = '{1}'", Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString(), descripcionTipoViaje)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurismoTipoViaje.Columnas.CantidadDiasUltimaCuota.ToString(), cantidadDiasUltimaCuota)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TurismoTipoViaje.Columnas.IdInteres.ToString(), GetStringFromNumber(idInteres))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString(), idTipoViaje)
      End With
      Execute(myQuery)
   End Sub
   Public Sub TurismoTiposViajes_D(idTipoViaje As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE FROM TurismoTiposViajes ")
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString(), idTipoViaje)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TV.*")
         .AppendFormatLine("     , I.NombreInteres")
         .AppendFormatLine("  FROM TurismoTiposViajes AS TV")
         .AppendFormatLine(" INNER JOIN Intereses I ON I.IdInteres = TV.IdInteres")
      End With
   End Sub

   Public Function TurismoTiposViajes_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormat(" ORDER BY TV.{0}", Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function TurismoTiposViajes_G1(idTurismoTipoViaje As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE TV.{0} = {1} ", Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString(), idTurismoTipoViaje)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "TV.",
                    New Dictionary(Of String, String) From {{"NombreInteres", "I.NombreInteres"}})
   End Function
   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString(), Entidades.TurismoTipoViaje.NombreTabla).ToInteger()
   End Function
End Class