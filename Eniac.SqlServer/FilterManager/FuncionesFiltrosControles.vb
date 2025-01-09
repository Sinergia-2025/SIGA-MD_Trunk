Namespace FilterManager
   Public Class FuncionesFiltrosControles
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Sub FuncionesFiltrosControles_I(idFuncion As String,
                                             idFiltro As Integer,
                                             nombreControl As String,
                                             valorControl As String)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormat("INSERT INTO {0} ", Entidades.FilterManager.FuncionFiltroControl.NombreTabla)
            .AppendFormatLine("({0}, {1}, {2}, {3})",
                              Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFuncion.ToString(),
                              Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFiltro.ToString(),
                              Entidades.FilterManager.FuncionFiltroControl.Columnas.NombreControl.ToString(),
                              Entidades.FilterManager.FuncionFiltroControl.Columnas.ValorControl.ToString())
            .AppendFormatLine("     VALUES ('{0}', {1}, '{2}', '{3}'",
                              idFuncion,
                              idFiltro,
                              nombreControl,
                              valorControl)
            .AppendLine(")")
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosControles_U(idFuncion As String,
                                             idFiltro As Integer,
                                             nombreControl As String,
                                             valorControl As String)

         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("UPDATE {0} ", Entidades.FilterManager.FuncionFiltroControl.NombreTabla)
            .AppendFormatLine("   SET {0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.ValorControl.ToString(), valorControl)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFuncion.ToString(), idFuncion)
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFiltro.ToString(), idFiltro)
            .AppendFormatLine("   AND {0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.NombreControl.ToString(), nombreControl)
         End With
         Me.Execute(myQuery.ToString())
      End Sub

      Public Sub FuncionesFiltrosControles_D(idFuncion As String, idFiltro As Integer, nombreControl As String)
         Dim myQuery As StringBuilder = New StringBuilder()

         With myQuery
            .AppendFormatLine("DELETE FROM {0}", Entidades.FilterManager.FuncionFiltroControl.NombreTabla)
            .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFuncion.ToString(), idFuncion)
            If idFiltro > 0 Then
               .AppendFormatLine("   AND {0} =  {1} ", Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFiltro.ToString(), idFiltro)
            End If
            If Not String.IsNullOrWhiteSpace(nombreControl) Then
               .AppendFormatLine("   AND {0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.NombreControl.ToString(), nombreControl)
            End If
         End With

         Me.Execute(myQuery.ToString())
      End Sub

      Private Sub SelectTexto(stb As StringBuilder)
         With stb
            .AppendFormatLine("SELECT FFC.*")
            .AppendFormatLine("  FROM {0} AS FFC", Entidades.FilterManager.FuncionFiltroControl.NombreTabla)
         End With
      End Sub

      Public Function FuncionesFiltrosControles_GA() As DataTable
         Return FuncionesFiltrosControles_G(idFuncion:=String.Empty, idFiltro:=0, nombreControl:=String.Empty)
      End Function
      Public Function FuncionesFiltrosControles_GA(idFuncion As String,
                                                   idFiltro As Integer) As DataTable
         Return FuncionesFiltrosControles_G(idFuncion, idFiltro, nombreControl:=String.Empty)
      End Function
      Private Function FuncionesFiltrosControles_G(idFuncion As String,
                                                   idFiltro As Integer,
                                                   nombreControl As String) As DataTable
         Dim myQuery As StringBuilder = New StringBuilder()
         With myQuery
            Me.SelectTexto(myQuery)
            .AppendFormatLine(" WHERE 1 = 1")

            If Not String.IsNullOrWhiteSpace(idFuncion) Then
               .AppendFormatLine("   AND FFC.{0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFuncion.ToString(), idFuncion)
            End If
            If idFiltro > 0 Then
               .AppendFormatLine("   AND FFC.{0} =  {1} ", Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFiltro.ToString(), idFiltro)
            End If
            If Not String.IsNullOrWhiteSpace(nombreControl) Then
               .AppendFormatLine("   AND FFC.{0} = '{1}'", Entidades.FilterManager.FuncionFiltroControl.Columnas.NombreControl.ToString(), nombreControl)
            End If

         End With
         Return Me.GetDataTable(myQuery.ToString())
      End Function

      Public Function FuncionesFiltrosControles_G1(idFuncion As String,
                                                   idFiltro As Integer,
                                                   nombreControl As String) As DataTable
         Return FuncionesFiltrosControles_G(idFuncion, idFiltro, nombreControl)
      End Function

      Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

         'If columna = "NombreTipoNovedad" Then
         '   columna = "TN." + columna
         'ElseIf columna = "PorDefecto_SN" Then
         '   columna = "CASE WHEN TCN.PorDefecto = 0 THEN 'NO' ELSE 'SI' END"
         'ElseIf columna = "VisibleParaCliente_SN" Then
         '   columna = "CASE WHEN TCN.VisibleParaCliente = 0 THEN 'NO' ELSE 'SI' END"
         'ElseIf columna = "VisibleParaRepresentante_SN" Then
         '   columna = "CASE WHEN TCN.VisibleParaRepresentante = 0 THEN 'NO' ELSE 'SI' END"
         'Else
         columna = "FFC." + columna
         ''End If

         Dim stb As StringBuilder = New StringBuilder()
         With stb
            Me.SelectTexto(stb)
            .AppendFormatLine(FormatoBuscar, columna, valor)
         End With
         Return Me.GetDataTable(stb.ToString())
      End Function

   End Class
End Namespace