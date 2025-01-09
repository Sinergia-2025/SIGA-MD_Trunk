Public Class DashBoardModelos
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
         .AppendLine("SELECT DBM.* ")
      End With
   End Sub
   ''' <summary>
   ''' From Standart de Sentencia.- --
   ''' </summary>
   ''' <param name="stb"></param>
   Private Sub FromTexto(stb As StringBuilder)
      With stb
         .AppendFormat("  FROM {0} AS DBM ", Entidades.DashBoardModelo.NombreTabla).AppendLine()
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
         .AppendFormat("  ORDER BY DBM.{0}", Entidades.DashBoardModelo.Columnas.IdModelo.ToString())
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
         .AppendFormat("  WHERE {0} = {1}", Entidades.DashBoardModelo.Columnas.IdModelo.ToString(), oIdDash)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

End Class
