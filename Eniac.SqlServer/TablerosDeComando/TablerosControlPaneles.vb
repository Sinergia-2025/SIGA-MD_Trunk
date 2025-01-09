Public Class TablerosControlPaneles
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TablerosControlPaneles_I(idTableroControlPanel As Integer,
                                       nombrePanel As String,
                                       parametros As String,
                                       idController As String,
                                       backColor1 As Integer?,
                                       foreColor1 As Integer?,
                                       backColor2 As Integer?,
                                       foreColor2 As Integer?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6})",
            Entidades.TableroControlPanel.NombreTabla,
            Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString(),
            Entidades.TableroControlPanel.Columnas.NombrePanel.ToString(),
            Entidades.TableroControlPanel.Columnas.Parametros.ToString(),
            Entidades.TableroControlPanel.Columnas.IdController.ToString(),
            Entidades.TableroControlPanel.Columnas.BackColor1.ToString(),
            Entidades.TableroControlPanel.Columnas.ForeColor1.ToString(),
            Entidades.TableroControlPanel.Columnas.BackColor2.ToString(),
            Entidades.TableroControlPanel.Columnas.ForeColor2.ToString())
         .AppendFormatLine("  VALUES ({1}, '{2}', '{3}', '{4}', {5}, {6}, {7}, {8})",
            Entidades.TableroControlPanel.NombreTabla, idTableroControlPanel, nombrePanel, parametros, idController,
            GetStringFromNumber(backColor1), GetStringFromNumber(foreColor1), GetStringFromNumber(backColor2), GetStringFromNumber(foreColor2))
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TablerosControlPaneles_U(idTableroControlPanel As Integer,
                                       nombrePanel As String,
                                       parametros As String,
                                       idController As String,
                                       backColor1 As Integer?,
                                       foreColor1 As Integer?,
                                       backColor2 As Integer?,
                                       foreColor2 As Integer?)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TablerosControlPaneles ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TableroControlPanel.Columnas.NombrePanel.ToString(), nombrePanel)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TableroControlPanel.Columnas.Parametros.ToString(), parametros)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.TableroControlPanel.Columnas.IdController.ToString(), idController)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControlPanel.Columnas.BackColor1.ToString(), GetStringFromNumber(backColor1))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControlPanel.Columnas.ForeColor1.ToString(), GetStringFromNumber(foreColor1))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControlPanel.Columnas.BackColor2.ToString(), GetStringFromNumber(backColor2))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControlPanel.Columnas.ForeColor2.ToString(), GetStringFromNumber(foreColor2))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString(), idTableroControlPanel)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TablerosControlPaneles_D(idTableroControlPanel As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TablerosControlPaneles WHERE {0} = {1}", Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString(), idTableroControlPanel)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT P.*")
         .AppendFormatLine("  FROM TablerosControlPaneles AS P")
      End With
   End Sub
   'GA
   Public Function TablerosControlPaneles_GA() As DataTable
      Return TablerosControlPaneles_G(idTableroControlPanel:=0, nombrePanel:=String.Empty, nombreExacto:=False)
   End Function
   Public Function TiposUnidades_GA(nombrePanel As String, nombreExacto As Boolean) As DataTable
      Return TablerosControlPaneles_G(idTableroControlPanel:=0, nombrePanel:=nombrePanel, nombreExacto:=nombreExacto)
   End Function

   Private Function TablerosControlPaneles_G(idTableroControlPanel As Integer, nombrePanel As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTableroControlPanel <> 0 Then
            .AppendFormatLine("   AND P.IdTableroControlPanel = {0}", idTableroControlPanel)
         End If
         If Not String.IsNullOrWhiteSpace(nombrePanel) Then
            If nombreExacto Then
               .AppendFormatLine("   AND P.NombrePanel = '{0}'", nombrePanel)
            Else
               .AppendFormatLine("   AND P.NombrePanel LIKE '%{0}%'", nombrePanel)
            End If
         End If
         .AppendFormatLine(" ORDER BY P.NombrePanel")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TablerosControlPaneles_GA(nombrePanel As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat("   WHERE TT.NombrePanel = '{0}'", nombrePanel).AppendLine()
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TablerosControlPaneles_G1(idTableroControlPanel As Integer) As DataTable
      Return TablerosControlPaneles_G(idTableroControlPanel:=idTableroControlPanel, nombrePanel:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreTipoCalendario" Then
      '   columna = "TC." + columna
      'Else
      columna = "P." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo(Entidades.TableroControlPanel.Columnas.IdTableroControlPanel.ToString(), "TablerosControlPaneles"))
   End Function

End Class