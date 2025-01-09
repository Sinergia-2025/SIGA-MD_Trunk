Imports Eniac.Entidades
Public Class Funciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Funciones_I(id As String,
                          nombre As String,
                          descripcion As String,
                          esMenu As Boolean,
                          esBoton As Boolean,
                          enabled As Boolean,
                          visible As Boolean,
                          idPadre As String,
                          posicion As Integer,
                          archivo As String,
                          pantalla As String,
                          parametros As String,
                          permiteMultiplesInstancias As Boolean,
                          Plus As String,
                          Express As String,
                          Basica As String,
                          PV As String,
                          IdModulo As Integer,
                          EsMDIChild As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO Funciones ")
         .AppendLine("  (" & Funcion.Columnas.Id.ToString())
         .AppendLine("  ," & Funcion.Columnas.Nombre.ToString())
         .AppendLine("  ," & Funcion.Columnas.Descripcion.ToString())
         .AppendLine("  ," & Funcion.Columnas.EsMenu.ToString())
         .AppendLine("  ," & Funcion.Columnas.EsBoton.ToString())
         .AppendLine("  ," & Funcion.Columnas.Enabled.ToString())
         .AppendLine("  ," & Funcion.Columnas.Visible.ToString())
         .AppendLine("  ," & Funcion.Columnas.IdPadre.ToString())
         .AppendLine("  ," & Funcion.Columnas.Posicion.ToString())
         .AppendLine("  ," & Funcion.Columnas.Archivo.ToString())
         .AppendLine("  ," & Funcion.Columnas.Pantalla.ToString())
         .AppendLine("  ," & Funcion.Columnas.Parametros.ToString())
         .AppendLine("  ," & Funcion.Columnas.PermiteMultiplesInstancias.ToString())
         .AppendLine("  ," & Funcion.Columnas.Plus.ToString())
         .AppendLine("  ," & Funcion.Columnas.Express.ToString())
         .AppendLine("  ," & Funcion.Columnas.Basica.ToString())
         .AppendLine("  ," & Funcion.Columnas.PV.ToString())
         .AppendLine("  ," & Funcion.Columnas.IdModulo.ToString())
         .AppendLine("  ," & Funcion.Columnas.EsMDIChild.ToString())

         .AppendLine("  ) VALUES ")
         .AppendLine("  ('" & id & "'")
         .AppendLine("  ,'" & nombre & "'")
         .AppendLine("  ,'" & descripcion & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(esMenu) & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(esBoton) & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(enabled) & "'")
         .AppendLine("  ,'" & GetStringFromBoolean(visible) & "'")
         If Not String.IsNullOrEmpty(idPadre) Then
            .AppendLine("  ,'" & idPadre & "'")
         Else
            .AppendLine("  ,NULL")
         End If
         .AppendLine("  ," & posicion.ToString())
         .AppendLine("  ,'" & archivo & "'")
         .AppendLine("  ,'" & pantalla & "'")
         .AppendLine("  ,'" & parametros & "'")
         .AppendFormatLine("  ,'{0}'", permiteMultiplesInstancias)
         .AppendLine("  ,'" & Plus & "'")
         .AppendLine("  ,'" & Express & "'")
         .AppendLine("  ,'" & Basica & "'")
         .AppendLine("  ,'" & PV & "'")
         If IdModulo = 0 Then
            .AppendFormatLine("  ,Null")
         Else
            .AppendFormatLine("  ,{0}", IdModulo)
         End If
         .AppendFormatLine("  ,'{0}'", EsMDIChild)
         .AppendLine("  )")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Funciones_U(id As String,
                          nombre As String,
                          descripcion As String,
                          esMenu As Boolean,
                          esBoton As Boolean,
                          enabled As Boolean,
                          visible As Boolean,
                          idPadre As String,
                          posicion As Integer,
                          archivo As String,
                          pantalla As String,
                          parametros As String,
                          permiteMultiplesInstancias As Boolean,
                          Plus As String,
                          Express As String,
                          Basica As String,
                          PV As String,
                          IdModulo As Integer,
                          EsMDIChild As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE Funciones ")
         .AppendFormatLine("   SET {0} = '{1}'", Funcion.Columnas.Nombre.ToString(), nombre)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Descripcion.ToString(), descripcion)
         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.EsMenu.ToString(), GetStringFromBoolean(esMenu))
         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.EsBoton.ToString(), GetStringFromBoolean(esBoton))
         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.Enabled.ToString(), GetStringFromBoolean(enabled))
         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.Visible.ToString(), GetStringFromBoolean(visible))
         If Not String.IsNullOrEmpty(idPadre) Then
            .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.IdPadre.ToString(), idPadre)
         Else
            .AppendFormatLine("     , {0} = NULL", Funcion.Columnas.IdPadre.ToString())
         End If

         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.Posicion.ToString(), posicion)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Archivo.ToString(), archivo)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Pantalla.ToString(), pantalla)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Parametros.ToString(), parametros)
         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.PermiteMultiplesInstancias.ToString(), GetStringFromBoolean(permiteMultiplesInstancias))
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Plus.ToString(), Plus)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Express.ToString(), Express)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.Basica.ToString(), Basica)
         .AppendFormatLine("     , {0} = '{1}'", Funcion.Columnas.PV.ToString(), PV)
         If IdModulo = 0 Then
            .AppendFormatLine("     , {0} = Null", Funcion.Columnas.IdModulo.ToString())
         Else
            .AppendFormatLine("     , {0} = {1}", Funcion.Columnas.IdModulo.ToString(), IdModulo)
         End If
         .AppendFormatLine("     , {0} =  {1} ", Funcion.Columnas.EsMDIChild.ToString(), GetStringFromBoolean(EsMDIChild))

         .AppendFormatLine(" WHERE {0} = '{1}'", Funcion.Columnas.Id.ToString(), id)
      End With
      Me.Execute(myQuery.ToString())
   End Sub


   Public Sub Funciones_D(id As String)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM Funciones ")
         .AppendFormatLine(" WHERE {0} = '{1}'", Funcion.Columnas.Id.ToString(), id)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT F.*")
         .AppendLine("      ,FP.Nombre NombrePadre, AM.NombreModulo")
         .AppendLine(" FROM Funciones F")
         .AppendLine(" LEFT JOIN Funciones FP ON FP.Id = F.IdPadre")
         .AppendLine(" LEFT JOIN AplicacionesModulos AM ON AM.IdModulo = F.IdModulo")
      End With
   End Sub

   Public Function Funciones_GA() As DataTable
      Return Funciones_GA(codigo:=String.Empty, nombre:=String.Empty, idExacto:=False)
   End Function

   Public Function Funciones_G1(idFuncion As String) As DataTable
      Return Funciones_GA(codigo:=idFuncion, nombre:=String.Empty, idExacto:=True)
   End Function

   Public Function Funciones_GA(codigo As String, nombre As String, idExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(codigo) Then
            If idExacto Then
               .AppendFormat("   AND F.Id = '{0}'", codigo).AppendLine()
            Else
               .AppendFormat("   AND F.Id LIKE '%{0}%'", codigo).AppendLine()
            End If
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND F.Nombre LIKE '%{0}%'", nombre).AppendLine()
         End If
         .AppendLine(" ORDER BY F.IdPadre, F.Posicion")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Buscar(columna As String, valor As String, igual As Boolean) As DataTable

      If columna = "NombrePadre" Then
         columna = String.Format("FP.{0}", columna)
      Else
         columna = String.Format("F.{0}", columna)
      End If

      Dim stbQuery As StringBuilder = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If igual Then
            .AppendFormatLine(" WHERE {0} = '{1}'", columna, valor)
         Else
            .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
         End If
      End With
      Return Me.GetDataTable(stbQuery.ToString())
   End Function

   Public Function ExisteFuncion(idFuncion As String) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT dbo.ExisteFuncion('{0}')", idFuncion)
      End With
      Return Boolean.Parse(GetDataTable(stb.ToString()).Rows(0)(0).ToString())
   End Function
   Public Function ExisteFuncionPorPantalla(pantalla As String) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT COUNT(1) FROM Funciones WHERE Pantalla = '{0}'", pantalla)
      End With
      Return GetDataTable(stb.ToString()).Rows(0).Field(Of Integer)(0) > 0
   End Function


   Public Function FuncionHabilitada(idFuncion As String) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT *")
         .AppendFormatLine("  FROM Funciones F")
         .AppendFormatLine("  LEFT JOIN Funciones FP ON FP.Id = F.IdPadre")
         .AppendFormatLine(" WHERE F.Id = '{0}'", idFuncion)
         .AppendFormatLine("   AND F.Enabled = 'True'")
         .AppendFormatLine("   AND (F.IdPadre IS NULL OR FP.Enabled = 'True')")
      End With
      Return GetDataTable(stb.ToString()).Rows.Count > 0
   End Function

End Class