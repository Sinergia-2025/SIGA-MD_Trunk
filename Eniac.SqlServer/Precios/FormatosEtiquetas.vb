Public Class FormatosEtiquetas
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FormatosEtiquetas_I(idFormatoEtiqueta As Integer,
                                  nombreFormatoEtiqueta As String,
                                  tipo As Entidades.FormatoEtiqueta.Tipos,
                                  archivoAImprimir As String,
                                  archivoAImprimirEmbebido As Boolean,
                                  nombreImpresora As String,
                                  imprimeLote As Boolean,
                                  maximoColumnas As Integer,
                                  utilizaCabecera As Boolean,
                                  solicitaListaPrecios2 As Boolean,
                                  activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.FormatoEtiqueta.NombreTabla)
         .AppendFormatLine("    ({0}", Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.Tipo.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimir.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimirEmbebido.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.NombreImpresora.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.ImprimeLote.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.MaximoColumnas.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.UtilizaCabecera.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.SolicitaListaPrecios2.ToString())
         .AppendFormatLine("    ,{0}", Entidades.FormatoEtiqueta.Columnas.Activo.ToString())
         .AppendFormatLine(" ) VALUES (")
         .AppendFormatLine("     {0} ", idFormatoEtiqueta)
         .AppendFormatLine("   ,'{0}'", nombreFormatoEtiqueta)
         .AppendFormatLine("   ,'{0}'", tipo)
         .AppendFormatLine("   ,'{0}'", archivoAImprimir)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(archivoAImprimirEmbebido))
         .AppendFormatLine("   ,'{0}'", nombreImpresora)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(imprimeLote))
         .AppendFormatLine("   , {0} ", maximoColumnas)
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(utilizaCabecera))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(solicitaListaPrecios2))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(activo))

         .AppendLine(" )")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub FormatosEtiquetas_U(idFormatoEtiqueta As Integer,
                                  nombreFormatoEtiqueta As String,
                                  tipo As Entidades.FormatoEtiqueta.Tipos,
                                  archivoAImprimir As String,
                                  archivoAImprimirEmbebido As Boolean,
                                  nombreImpresora As String,
                                  imprimeLote As Boolean,
                                  maximoColumnas As Integer,
                                  utilizaCabecera As Boolean,
                                  solicitaListaPrecios2 As Boolean,
                                  activo As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.FormatoEtiqueta.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString(), nombreFormatoEtiqueta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.FormatoEtiqueta.Columnas.Tipo.ToString(), tipo)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimir.ToString(), archivoAImprimir)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.ArchivoAImprimirEmbebido.ToString(), GetStringFromBoolean(archivoAImprimirEmbebido))
         .AppendFormatLine("     , {0} = '{1}'", Entidades.FormatoEtiqueta.Columnas.NombreImpresora.ToString(), nombreImpresora)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.ImprimeLote.ToString(), GetStringFromBoolean(imprimeLote))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.MaximoColumnas.ToString(), maximoColumnas)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.UtilizaCabecera.ToString(), GetStringFromBoolean(utilizaCabecera))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.SolicitaListaPrecios2.ToString(), GetStringFromBoolean(solicitaListaPrecios2))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString(), idFormatoEtiqueta)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub FormatosEtiquetas_D(idFormatoEtiqueta As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.FormatoEtiqueta.NombreTabla)
         .AppendFormat(" WHERE {0} = {1}", Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString(), idFormatoEtiqueta)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT FE.*")
         .AppendLine("  FROM FormatosEtiquetas FE")
      End With
   End Sub

   Private Function FormatosEtiquetas_G(idFormatoEtiqueta As Integer, tipo As Entidades.FormatoEtiqueta.Tipos?, activo As Boolean?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE 1 = 1")
         If idFormatoEtiqueta > 0 Then
            .AppendFormatLine("   AND FE.{0} = {1}", Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString(), idFormatoEtiqueta)
         End If
         If tipo.HasValue Then
            .AppendFormatLine("   AND FE.{0} = '{1}'", Entidades.FormatoEtiqueta.Columnas.Tipo.ToString(), tipo.Value.ToString())
         End If
         If activo.HasValue Then
            .AppendFormatLine("   AND FE.{0} = {1}", Entidades.FormatoEtiqueta.Columnas.Activo.ToString(), GetStringFromBoolean(activo))
         End If
         .AppendFormatLine("  ORDER BY FE.{0}, FE.{1}", Entidades.FormatoEtiqueta.Columnas.Tipo.ToString(), Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function FormatosEtiquetas_GA() As DataTable
      Return FormatosEtiquetas_G(idFormatoEtiqueta:=0, tipo:=Nothing, activo:=Nothing)
   End Function
   Public Function FormatosEtiquetas_GA(tipo As Entidades.FormatoEtiqueta.Tipos?, activo As Boolean?) As DataTable
      Return FormatosEtiquetas_G(idFormatoEtiqueta:=0, tipo:=tipo, activo:=activo)
   End Function

   Public Function FormatosEtiquetas_G1(idFormatoEtiqueta As Integer) As DataTable
      Return FormatosEtiquetas_G(idFormatoEtiqueta, tipo:=Nothing, activo:=Nothing)
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      columna = "FE." + columna

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString(), Entidades.FormatoEtiqueta.NombreTabla))
   End Function
End Class