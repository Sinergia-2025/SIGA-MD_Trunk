Public Class DashBoardTipos
   Inherits Comunes

   Private _stb As StringBuilder

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
      Me._stb = New StringBuilder()
   End Sub

   ''' <summary>
   ''' Select Standart de Consulta.- ---
   ''' </summary>
   ''' <param name="stb"></param>
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT DBT.* ")
      End With
   End Sub
   ''' <summary>
   ''' From Standart de Sentencia.- --
   ''' </summary>
   ''' <param name="stb"></param>
   Private Sub FromTexto(stb As StringBuilder)
      With stb
         .AppendFormat("  FROM {0} AS DBT ", Entidades.DashBoardTipo.NombreTabla)
      End With
   End Sub
   ''' <summary>
   ''' Procedimiento de Consulta Todos.- --
   ''' </summary>
   ''' <returns></returns>
   Public Function DashBoards_GA() As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         '-----------------------
         SelectTexto(myQuery)
         FromTexto(myQuery)
         '----------------------
         .AppendLine("  WHERE Estados = 1 ")
         .AppendFormat("  ORDER BY DBT.{0}", Entidades.DashBoardTipo.Columnas.IdDashTipos.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   ''' <summary>
   ''' Proceso de Recuperacion de un solo DashBoard.- 
   ''' </summary>
   ''' <param name="oIdDash">ID de DashBoard Seleccionado.-</param>
   ''' <returns></returns>
   Public Function DashBoard_G1(oIdDash As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         FromTexto(myQuery)
         .AppendFormat("  WHERE {0} = {1}", Entidades.DashBoardTipo.Columnas.IdDashTipos.ToString, oIdDash)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
