Public Class TiposDocumentosFunciones
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposDocumentosFunciones_I(idTipoLink As String,
                                         descripcion As String,
                                         descripcionAbreviada As String,
                                         orden As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.TipoDocumentoFuncion.NombreTabla)
         .AppendFormatLine("            ({0}, {1}, {2}, {3})",
                           Entidades.TipoDocumentoFuncion.Columnas.IdTipoLink.ToString(),
                           Entidades.TipoDocumentoFuncion.Columnas.Descripcion.ToString(),
                           Entidades.TipoDocumentoFuncion.Columnas.DescripcionAbreviada.ToString(),
                           Entidades.TipoDocumentoFuncion.Columnas.Orden.ToString())
         .AppendFormatLine("     VALUES ('{0}', '{1}', '{2}', {3})",
                           idTipoLink,
                           descripcion,
                           descripcionAbreviada,
                           orden)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposDocumentosFunciones_U(idTipoLink As String,
                                         descripcion As String,
                                         descripcionAbreviada As String,
                                         orden As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.TipoDocumentoFuncion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TipoDocumentoFuncion.Columnas.Descripcion.ToString(), descripcion)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TipoDocumentoFuncion.Columnas.DescripcionAbreviada.ToString(), descripcionAbreviada)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TipoDocumentoFuncion.Columnas.Orden.ToString(), orden)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.TipoDocumentoFuncion.Columnas.IdTipoLink.ToString(), idTipoLink)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposDocumentosFunciones_D(idTipoLink As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.TipoDocumentoFuncion.NombreTabla)
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.TipoDocumentoFuncion.Columnas.IdTipoLink.ToString(), idTipoLink)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT TDF.* ")
         .AppendFormatLine("  FROM {0} AS TDF", Entidades.TipoDocumentoFuncion.NombreTabla)

      End With
   End Sub

   Private _camposOrderBy__Default As String() = {"TDF.Descripcion"}
   Private _camposOrderBy__PorPosicion As String() = {"TDF.Orden"}

   Public Function TiposDocumentosFunciones_GA(ordenarPosicion As Boolean) As DataTable
      Return TiposDocumentosFunciones_G(idTipoLink:=String.Empty, camposOrderBy:=If(ordenarPosicion, _camposOrderBy__PorPosicion, _camposOrderBy__Default))
   End Function
   Public Function TiposDocumentosFunciones_GA() As DataTable
      Return TiposDocumentosFunciones_GA(ordenarPosicion:=False)
   End Function
   Public Function TiposDocumentosFunciones_G(idTipoLink As String, camposOrderBy As String()) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idTipoLink) Then
            .AppendFormat("   AND TDF.{0} = '{1}'", Entidades.TipoDocumentoFuncion.Columnas.IdTipoLink.ToString(), idTipoLink)
         End If
         ArmarOrderBy(myQuery, camposOrderBy)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TiposDocumentosFunciones_G1(idTipoLink As String) As DataTable
      Return TiposDocumentosFunciones_G(idTipoLink, _camposOrderBy__Default)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable

      'If columna = "Finalizado_SN" Then
      '   columna = "CASE WHEN EN.Finalizado = 0 THEN 'NO' ELSE 'SI' END"
      'ElseIf columna = "PorDefecto_SN" Then
      '   columna = "CASE WHEN EN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
      'ElseIf columna = "SolicitaPasajeros_SN" Then
      '   columna = "CASE WHEN EN.SolicitaPasajeros = 0 THEN 'NO' ELSE 'SI' END"
      'Else
      columna = "TDF." + columna
      'End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class