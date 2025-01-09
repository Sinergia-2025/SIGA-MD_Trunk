Public Class DashBoardTableros
   Inherits Comunes

   Private _stb As StringBuilder

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
      Me._stb = New StringBuilder()
   End Sub

   ''' <summary>
   ''' Procedimiento de Ingreso de DashBoard Tableros.- --
   ''' </summary>
   Public Sub DashBordsTableros_I(IdDashBoard As Integer,
                                  Descripcion As String,
                                  Estado As Boolean)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.DashBoardTablero.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}", Entidades.DashBoardTablero.Columnas.IdTableros.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardTablero.Columnas.Descripcion.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardTablero.Columnas.Estados.ToString())
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("            {0} ", IdDashBoard)
         .AppendFormatLine("          ,'{0}'", Descripcion)
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(Estado))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   ''' <summary>
   ''' Procedimiento de Modificacion de DashBoard Tableros.- --
   ''' </summary>
   Public Sub DashBordsTableros_U(IdDashBoard As Integer,
                                  Descripcion As String,
                                  Estado As Boolean)

      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("UPDATE {0}        ", Entidades.DashBoardTablero.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.DashBoardTablero.Columnas.Descripcion.ToString(), IdDashBoard).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardTablero.Columnas.Estados.ToString(), Descripcion).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.DashBoardTablero.Columnas.IdTableros.ToString(), Estado).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   ''' <summary>
   ''' Elimina Un dasBoard Incidado.- --
   ''' </summary>
   ''' <param name="idDashBoard">ID de Dash Board.</param>
   Public Sub DashBordsTableros_D(idDashBoard As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM   {0}", Entidades.DashBoardTablero.NombreTabla)
         .AppendFormat("  WHERE {0} = {1}", Entidades.DashBoardTablero.Columnas.IdTableros.ToString(), idDashBoard)
      End With

      Me.Execute(myQuery.ToString())
   End Sub
   ''' <summary>
   ''' Select Standart de Consulta.- ---
   ''' </summary>
   ''' <param name="stb"></param>
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT DTB.* ")
      End With
   End Sub
   ''' <summary>
   ''' From Standart de Sentencia.- --
   ''' </summary>
   ''' <param name="stb"></param>
   Private Sub FromTexto(stb As StringBuilder)
      With stb
         .AppendFormat("  FROM {0} AS DTB ", Entidades.DashBoardTablero.NombreTabla).AppendLine()
      End With
   End Sub
   ''' <summary>
   ''' Procedimiento de Consulta Todos los DashBoard Tableros.- --
   ''' </summary>
   ''' <returns></returns>
   Public Function DashBoards_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         '-----------------------
         SelectTexto(myQuery)
         FromTexto(myQuery)
         '----------------------
         .AppendFormat("  ORDER BY DTB.{0}", Entidades.DashBoardTablero.Columnas.IdTableros.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   ''' <summary>
   ''' Proceso de Recuperacion de un solo DashBoard Tableros.- 
   ''' </summary>
   ''' <param name="oIdDash">ID de DashBoard Seleccionado.-</param>
   ''' <returns></returns>
   Public Function DashBoard_G1(oIdDash As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         FromTexto(myQuery)
         .AppendFormat("  WHERE {0} = {1}", Entidades.DashBoardTablero.Columnas.IdTableros.ToString(), oIdDash)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
