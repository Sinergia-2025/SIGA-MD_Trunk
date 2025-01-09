Public Class TablerosControl
   Inherits Comunes

   Public Sub New(da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TablerosControl_I(idTableroControl As Integer,
                                nombreTableroControl As String,
                                idTableroControlPanel1 As Integer,
                                idTableroControlPanel2 As Integer,
                                idTableroControlPanel3 As Integer,
                                idTableroControlPanel4 As Integer,
                                idTableroControlPanel5 As Integer,
                                idTableroControlPanel6 As Integer,
                                idControllerFiltro As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.TableroControl.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.TableroControl.Columnas.IdTableroControl.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.NombreTableroControl.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdTableroControlPanel1.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdTableroControlPanel2.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdTableroControlPanel3.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdTableroControlPanel4.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdTableroControlPanel5.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdTableroControlPanel6.ToString())
         .AppendFormatLine("    ,{0}", Entidades.TableroControl.Columnas.IdControllerFiltro.ToString())
         .AppendFormatLine("    ) VALUES (")
         .AppendFormatLine("      {0} ", idTableroControl)
         .AppendFormatLine("    ,'{0}'", nombreTableroControl)
         .AppendFormatLine("    , {0} ", idTableroControlPanel1)
         .AppendFormatLine("    , {0} ", GetStringFromNumber(idTableroControlPanel2))
         .AppendFormatLine("    , {0} ", GetStringFromNumber(idTableroControlPanel3))
         .AppendFormatLine("    , {0} ", GetStringFromNumber(idTableroControlPanel4))
         .AppendFormatLine("    , {0} ", GetStringFromNumber(idTableroControlPanel5))
         .AppendFormatLine("    , {0} ", GetStringFromNumber(idTableroControlPanel6))
         .AppendFormatLine("    ,'{0}'", idControllerFiltro)
         .AppendFormatLine("    )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TablerosControl_U(idTableroControl As Integer,
                                nombreTableroControl As String,
                                idTableroControlPanel1 As Integer,
                                idTableroControlPanel2 As Integer,
                                idTableroControlPanel3 As Integer,
                                idTableroControlPanel4 As Integer,
                                idTableroControlPanel5 As Integer,
                                idTableroControlPanel6 As Integer,
                                idControllerFiltro As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("UPDATE TablerosControl ")
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.TableroControl.Columnas.NombreTableroControl.ToString(), nombreTableroControl)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControl.Columnas.IdTableroControlPanel1.ToString(), idTableroControlPanel1)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControl.Columnas.IdTableroControlPanel2.ToString(), GetStringFromNumber(idTableroControlPanel2))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControl.Columnas.IdTableroControlPanel3.ToString(), GetStringFromNumber(idTableroControlPanel3))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControl.Columnas.IdTableroControlPanel4.ToString(), GetStringFromNumber(idTableroControlPanel4))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControl.Columnas.IdTableroControlPanel5.ToString(), GetStringFromNumber(idTableroControlPanel5))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.TableroControl.Columnas.IdTableroControlPanel6.ToString(), GetStringFromNumber(idTableroControlPanel6))
         .AppendFormatLine("     , {0} ='{1}' ", Entidades.TableroControl.Columnas.IdControllerFiltro.ToString(), idControllerFiltro)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.TableroControl.Columnas.IdTableroControl.ToString(), idTableroControl)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TablerosControl_D(idTableroControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM TablerosControl WHERE {0} = {1}", Entidades.TableroControl.Columnas.IdTableroControl.ToString(), idTableroControl)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT T.*")
         .AppendFormatLine("     , P1.NombrePanel AS NombrePanel1")
         .AppendFormatLine("     , P2.NombrePanel AS NombrePanel2")
         .AppendFormatLine("     , P3.NombrePanel AS NombrePanel3")
         .AppendFormatLine("     , P4.NombrePanel AS NombrePanel4")
         .AppendFormatLine("     , P5.NombrePanel AS NombrePanel5")
         .AppendFormatLine("     , P6.NombrePanel AS NombrePanel6")
         .AppendFormatLine("  FROM TablerosControl AS T")
         .AppendFormatLine("  LEFT JOIN TablerosControlPaneles P1 ON P1.IdTableroControlPanel = T.IdTableroControlPanel1")
         .AppendFormatLine("  LEFT JOIN TablerosControlPaneles P2 ON P2.IdTableroControlPanel = T.IdTableroControlPanel2")
         .AppendFormatLine("  LEFT JOIN TablerosControlPaneles P3 ON P3.IdTableroControlPanel = T.IdTableroControlPanel3")
         .AppendFormatLine("  LEFT JOIN TablerosControlPaneles P4 ON P4.IdTableroControlPanel = T.IdTableroControlPanel4")
         .AppendFormatLine("  LEFT JOIN TablerosControlPaneles P5 ON P5.IdTableroControlPanel = T.IdTableroControlPanel5")
         .AppendFormatLine("  LEFT JOIN TablerosControlPaneles P6 ON P6.IdTableroControlPanel = T.IdTableroControlPanel6")
      End With
   End Sub

   Public Function TablerosControl_GA() As DataTable
      Return TablerosControl_G(idTableroControl:=0, nombreTableroControl:=String.Empty, nombreExacto:=False)
   End Function
   Private Function TablerosControl_G(idTableroControl As Integer, nombreTableroControl As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTableroControl <> 0 Then
            .AppendFormatLine("   AND T.IdTableroControl = {0}", idTableroControl)
         End If
         If Not String.IsNullOrWhiteSpace(nombreTableroControl) Then
            If nombreExacto Then
               .AppendFormatLine("   AND T.NombreTableroControl = '{0}'", nombreTableroControl)
            Else
               .AppendFormatLine("   AND T.NombreTableroControl LIKE '%{0}%'", nombreTableroControl)
            End If
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function TablerosControl_GA(nombreTableroControl As String, nombreExacto As Boolean) As DataTable
      Return TablerosControl_G(idTableroControl:=0, nombreTableroControl:=nombreTableroControl, nombreExacto:=nombreExacto)
   End Function

   Public Function TablerosControl_G1(idTableroControl As Integer) As DataTable
      Return TablerosControl_G(idTableroControl:=idTableroControl, nombreTableroControl:=String.Empty, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "NombrePanel1" Then
         columna = "P1.NombrePanel"
      ElseIf columna = "NombrePanel2" Then
         columna = "P2.NombrePanel"
      ElseIf columna = "NombrePanel3" Then
         columna = "P3.NombrePanel"
      ElseIf columna = "NombrePanel4" Then
         columna = "P4.NombrePanel"
      ElseIf columna = "NombrePanel5" Then
         columna = "P5.NombrePanel"
      ElseIf columna = "NombrePanel6" Then
         columna = "P6.NombrePanel"
      Else
         columna = "T." + columna
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.TableroControl.Columnas.IdTableroControl.ToString(), "TablerosControl"))
   End Function

End Class