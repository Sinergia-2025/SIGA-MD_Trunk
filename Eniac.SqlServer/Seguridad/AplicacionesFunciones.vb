Public Class AplicacionesFunciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub AplicacionesFunciones_I(idAplicacion As String,
                                      idFuncion As String,
                                      nombreFuncion As String,
                                      idFuncionPadre As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO {0} ", Entidades.AplicacionFuncion.NombreTabla)
         .AppendFormatLine("({0}, {1}, {2}, {3})",
                           Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString(),
                           Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(),
                           Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString(),
                           Entidades.AplicacionFuncion.Columnas.IdFuncionPadre.ToString())
         .AppendFormatLine("     VALUES ('{0}', '{1}', '{2}', {3}",
                           idAplicacion,
                           idFuncion,
                           nombreFuncion,
                           GetStringParaQueryConComillas(idFuncionPadre))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AplicacionesFunciones_U(idAplicacion As String,
                                      idFuncion As String,
                                      nombreFuncion As String,
                                      idFuncionPadre As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("UPDATE {0} ", Entidades.AplicacionFuncion.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString(), nombreFuncion)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.AplicacionFuncion.Columnas.IdFuncionPadre.ToString(), GetStringParaQueryConComillas(idFuncionPadre))
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(), idFuncion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub AplicacionesFunciones_D(idAplicacion As String, idFuncion As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.AplicacionFuncion.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString(), idAplicacion)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(), idFuncion)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT AF.*")
         .AppendFormatLine("     , AFP.NombreFuncion AS NombreFuncionPadre")
         .AppendFormatLine("  FROM {0} AS AF", Entidades.AplicacionFuncion.NombreTabla)
         .AppendFormatLine("  LEFT JOIN {0} AFP ON AFP.{1} = AF.{1} AND AFP.{2} = AF.{3}",
                           Entidades.AplicacionFuncion.NombreTabla,
                           Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString(),
                           Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(),
                           Entidades.AplicacionFuncion.Columnas.IdFuncionPadre.ToString())
      End With
   End Sub

   Public Function AplicacionesFunciones_GA() As DataTable
      Return AplicacionesFunciones_G(idAplicacion:=String.Empty, idFuncion:=String.Empty, nombreFuncion:=String.Empty, idExacto:=True, nombreExacto:=True)
   End Function
   Public Function AplicacionesFunciones_GA(idAplicacion As String) As DataTable
      Return AplicacionesFunciones_G(idAplicacion, idFuncion:=String.Empty, nombreFuncion:=String.Empty, idExacto:=True, nombreExacto:=True)
   End Function
   Public Function AplicacionesFunciones_G(idAplicacion As String,
                                           idFuncion As String,
                                           nombreFuncion As String,
                                           idExacto As Boolean,
                                           nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")

         If Not String.IsNullOrWhiteSpace(idAplicacion) Then
            .AppendFormatLine("   AND AF.{0} = '{1}'", Entidades.AplicacionFuncion.Columnas.IdAplicacion.ToString(), idAplicacion)
         End If
         If Not String.IsNullOrWhiteSpace(nombreFuncion) Then
            If idExacto Then
               .AppendFormatLine("   AND AF.{0} = '{1}'", Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString(), nombreFuncion)
            Else
               .AppendFormatLine("   AND AF.{0} LIKE '%{1}%'", Entidades.AplicacionFuncion.Columnas.NombreFuncion.ToString(), nombreFuncion)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(idFuncion) Then
            If nombreExacto Then
               .AppendFormatLine("   AND AF.{0} = '{1}'", Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(), idFuncion)
            Else
               .AppendFormatLine("   AND AF.{0} LIKE '%{1}%'", Entidades.AplicacionFuncion.Columnas.IdFuncion.ToString(), idFuncion)
            End If
         End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function AplicacionesFunciones_G1(idAplicacion As String, idFuncion As String) As DataTable
      Return AplicacionesFunciones_G(idAplicacion, idFuncion, nombreFuncion:=String.Empty, idExacto:=True, nombreExacto:=True)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreFuncionPadre" Then
         columna = "AFP.NombreFuncion"
         'ElseIf columna = "PorDefecto_SN" Then
         '   columna = "CASE WHEN TCN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
         'ElseIf columna = "VisibleParaCliente_SN" Then
         '   columna = "CASE WHEN TCN.VisibleParaCliente = 0 THEN 'NO' ELSE 'SI' END"
         'ElseIf columna = "VisibleParaRepresentante_SN" Then
         '   columna = "CASE WHEN TCN.VisibleParaRepresentante = 0 THEN 'NO' ELSE 'SI' END"
      Else
         columna = "AF." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class