Public Class DashBoardPaneles
   Inherits Comunes

   Private _stb As StringBuilder

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
      Me._stb = New StringBuilder()
   End Sub

   ''' <summary>
   ''' Procedimiento de Ingreso de DashBoard.- --
   ''' </summary>
   Public Sub DashBords_I(IdDashBoard As Integer,
                          Nombre As String,
                          TipoDashBoard As Integer,
                          Titulo As String,
                          Comentario As String,
                          SentenciaSQL As String,
                          AutoRefresh As Boolean,
                          TipoRefresh As Integer,
                          TimerRefresh As Integer,
                          ImagenDashBoard As Byte(),
                          ValorObjetivo As Decimal,
                          ValorMinimo As Decimal,
                          Area3DStyle As Boolean?,
                          ModeloDashBoard As Integer?,
                          ShowValueLabel As Boolean?,
                          AxisTitleX As String,
                          AxisTitleY As String,
                          Estado As Boolean,
                          Orden As Integer,
                          VisualizaLeyenda As Boolean)
      Dim myQuery = New StringBuilder()
      Dim oParameter As Common.DbParameter

      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.DashBoardPaneles.NombreTabla).AppendLine()
         .AppendFormatLine("           ({0}", Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.Nombre.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.TipoDashBoard.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.Titulo.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.Comentario.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.SentenciaSQL.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.AutoRefresh.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.TipoRefresh.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.TimerRefresh.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.ImagenDashBoard.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.ValorObjetivo.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.ValorMinimo.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.Area3DStyle.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.ModeloDashBoard.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.ShowValueLabel.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.AxisTitleX.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.AxisTitleY.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.Estado.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.Orden.ToString())
         .AppendFormatLine("           ,{0}", Entidades.DashBoardPaneles.Columnas.VisualizaLeyenda.ToString())
         .AppendFormatLine("  ) VALUES (")
         .AppendFormatLine("            {0} ", IdDashBoard)
         .AppendFormatLine("          ,'{0}'", Nombre)
         .AppendFormatLine("          , {0} ", TipoDashBoard)
         .AppendFormatLine("          ,'{0}'", Titulo)
         .AppendFormatLine("          ,'{0}'", Comentario)
         .AppendFormatLine("          ,@SentSQL")
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(AutoRefresh))
         .AppendFormatLine("          , {0} ", TipoRefresh)
         .AppendFormatLine("          , {0} ", TimerRefresh)
         .AppendFormatLine("          , @ImgDash ")
         .AppendFormatLine("          , {0} ", ValorObjetivo)
         .AppendFormatLine("          , {0} ", ValorMinimo)
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(Area3DStyle))
         If ModeloDashBoard = 0 Then
            .AppendFormat("            ,NULL ").AppendLine()
         Else
            .AppendFormatLine("          , {0} ", ModeloDashBoard)
         End If
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(ShowValueLabel))
         .AppendFormatLine("          ,'{0}'", AxisTitleX)
         .AppendFormatLine("          ,'{0}'", AxisTitleY)
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(Estado))
         .AppendFormatLine("          , {0} ", Orden)
         .AppendFormatLine("          , {0} ", GetStringFromBoolean(VisualizaLeyenda))

         .AppendLine(")")

         Me._da.Command.CommandText = .ToString()
         Me._da.Command.CommandType = CommandType.Text
         Me._da.Command.Transaction = Me._da.Transaction

         '-- Carga Parametro Imagenes.- ------------------
         oParameter = _da.Command.CreateParameter()
         oParameter.ParameterName = "@ImgDash"
         oParameter.DbType = DbType.Binary
         '-- Verifica Imagen.- --
         If ImagenDashBoard IsNot Nothing Then
            oParameter.Size = ImagenDashBoard.Length
            oParameter.Value = ImagenDashBoard
         Else
            oParameter.Value = DBNull.Value
         End If
         _da.Command.Parameters.Add(oParameter)
         '-- Carga Parametro SQL.- ----------------------
         oParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@SentSQL"
         oParameter.DbType = DbType.String
         oParameter.Value = SentenciaSQL
         _da.Command.Parameters.Add(oParameter)
         '-----------------------------------------------

         'Me._da.Command.Parameters.Add(oParameter)


         Me._da.Command.Connection = Me._da.Connection
         Me._da.ExecuteNonQuery(Me._da.Command)

      End With
   End Sub
   ''' <summary>
   ''' Procedimiento de Ingreso de DashBoard.- --
   ''' </summary>
   Public Sub DashBords_U(IdDashBoard As Integer,
                          Nombre As String,
                          TipoDashBoard As Integer,
                          Titulo As String,
                          Comentario As String,
                          SentenciaSQL As String,
                          AutoRefresh As Boolean,
                          TipoRefresh As Integer,
                          TimerRefresh As Integer,
                          ImagenDashBoard As Byte(),
                          ValorObjetivo As Decimal,
                          ValorMinimo As Decimal,
                          Area3DStyle As Boolean?,
                          ModeloDashBoard As Integer?,
                          ShowValueLabel As Boolean?,
                          AxisTitleX As String,
                          AxisTitleY As String,
                          Estado As Boolean,
                          Orden As Integer,
                          VisualizaLeyenda As Boolean)

      Dim myQuery = New StringBuilder()
      Dim oParameter As Data.Common.DbParameter

      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.DashBoardPaneles.NombreTabla).AppendLine()

         .AppendFormat("   SET {0} = '{1}'", Entidades.DashBoardPaneles.Columnas.Nombre.ToString(), Nombre).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", Entidades.DashBoardPaneles.Columnas.Titulo.ToString(), Titulo).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", Entidades.DashBoardPaneles.Columnas.Comentario.ToString(), Comentario).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.VisualizaLeyenda.ToString(), GetStringFromBoolean(VisualizaLeyenda)).AppendLine()
         '-- Carga Sentencia SQL.- ----------------------------------------------------------------------------------
         .AppendFormat("      ,{0} =  @SentSQL ", Entidades.DashBoardPaneles.Columnas.SentenciaSQL.ToString()).AppendLine()
         '-----------------------------------------------------------------------------------------------------------
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.Area3DStyle.ToString(), GetStringFromBoolean(Area3DStyle)).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.ShowValueLabel.ToString(), GetStringFromBoolean(ShowValueLabel)).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.Estado.ToString(), GetStringFromBoolean(Estado)).AppendLine()
         '-- Carga Refresh.- ----------------------------------------------------------------------------------------
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.AutoRefresh.ToString(), GetStringFromBoolean(AutoRefresh)).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.TipoRefresh.ToString(), TipoRefresh).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.TimerRefresh.ToString(), TimerRefresh).AppendLine()
         '-----------------------------------------------------------------------------------------------------------
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.ValorObjetivo.ToString(), ValorObjetivo).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.ValorMinimo.ToString(), ValorMinimo).AppendLine()
         If ModeloDashBoard = 0 Then
            .AppendFormat("      ,{0} =  NULL ", Entidades.DashBoardPaneles.Columnas.ModeloDashBoard.ToString()).AppendLine()
         Else
            .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.ModeloDashBoard.ToString(), ModeloDashBoard).AppendLine()
         End If
         .AppendFormat("      ,{0} = '{1}'", Entidades.DashBoardPaneles.Columnas.AxisTitleX.ToString(), AxisTitleX).AppendLine()
         .AppendFormat("      ,{0} = '{1}'", Entidades.DashBoardPaneles.Columnas.AxisTitleY.ToString(), AxisTitleY).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", Entidades.DashBoardPaneles.Columnas.Orden.ToString(), Orden).AppendLine()
         '-- Carga Imagenes.- ----------------------------------------------------------------------------------------
         .AppendFormat("      ,{0} =  @ImgDash ", Entidades.DashBoardPaneles.Columnas.ImagenDashBoard.ToString()).AppendLine()
         '------------------------------------------------------------------------------------------------------------
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString(), IdDashBoard).AppendLine()

         _da.Command.CommandText = .ToString()
         _da.Command.CommandType = CommandType.Text
         _da.Command.Transaction = _da.Transaction

         '-- Carga Parametro Imagenes.- ------------------
         oParameter = _da.Command.CreateParameter()
         oParameter.ParameterName = "@ImgDash"
         oParameter.DbType = DbType.Binary
         '-- Verifica Imagen.- --
         If ImagenDashBoard IsNot Nothing Then
            oParameter.Size = ImagenDashBoard.Length
            oParameter.Value = ImagenDashBoard
         Else
            oParameter.Value = DBNull.Value
         End If
         _da.Command.Parameters.Add(oParameter)
         '-- Carga Parametro SQL.- ----------------------
         oParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@SentSQL"
         oParameter.DbType = DbType.String
         oParameter.Value = SentenciaSQL
         _da.Command.Parameters.Add(oParameter)
         '-----------------------------------------------

         _da.Command.Connection = Me._da.Connection
         _da.ExecuteNonQuery(Me._da.Command)

      End With

   End Sub
   ''' <summary>
   ''' Elimina Un dasBoard Incidado.- --
   ''' </summary>
   ''' <param name="idDashBoard">ID de Dash Board.</param>
   Public Sub DashBords_D(idDashBoard As Integer)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("DELETE FROM  {0}", Entidades.DashBoardPaneles.NombreTabla).AppendLine()
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString(), idDashBoard)
      End With

      Me.Execute(myQuery.ToString())
   End Sub
   ''' <summary>
   ''' Actualiza el Estado de Un Dashboard.- --
   ''' </summary>
   ''' <param name="idDashBoard">Id de DashBoard.</param>
   ''' <param name="estadoDashBoard">Estado de Dash Board.</param>
   Public Sub DashBords_A(idDashBoard As Integer, estadoDashBoard As Boolean)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendFormat("UPDATE  {0}", Entidades.DashBoardPaneles.NombreTabla).AppendLine()
         .AppendFormat(" SET {0} = {1}", Entidades.DashBoardPaneles.Columnas.Estado.ToString(), idDashBoard)
         .AppendFormat(" WHERE {0} = {1}", Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString(), idDashBoard)
      End With

      Me.Execute(myQuery.ToString())
   End Sub
   ''' <summary>
   ''' Select Standart de Consulta.- ---
   ''' </summary>
   ''' <param name="stb"></param>
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT DBR.*, DBT.Descripcion as Descripcion, DBM.Descripcion as Modelo ")
      End With
   End Sub
   Private Sub FromTexto(stb As StringBuilder)
      With stb
         .AppendFormat("  FROM {0} AS DBR ", Entidades.DashBoardPaneles.NombreTabla).AppendLine()
         .AppendLine("  INNER JOIN DashBoardsTipos AS DBT ON DBR.TIPODASHBOARD = DBT.IDDASHTIPOS ")
         .AppendLine("  LEFT JOIN DashBoardsModelos AS DBM ON DBR.MODELODASHBOARD = DBM.IDMODELO ")
      End With
   End Sub
   ''' <summary>
   ''' Recupera los Valores de las Sentencias SQL.- ---
   ''' </summary>
   ''' <param name="sSentencia"></param>
   ''' <returns></returns>
   Public Function GetValoresDashBoard(sSentencia As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      '-- Asigna Sentencia predefinida.- --
      With stb
         .AppendLine(sSentencia)
      End With
      '------------------------------------
      Return Me.GetDataTable(stb.ToString())
   End Function
   ''' <summary>
   ''' Proceso de Recuperacion de Todos los DashBoard Activos.- --
   ''' </summary>
   ''' <returns></returns>
   Public Function DashBoards_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         '-----------------------
         SelectTexto(myQuery)
         FromTexto(myQuery)
         '----------------------
         .AppendFormat("  ORDER BY DBR.{0}", Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   ''' <summary>
   ''' Proceso de Recuperacion de Todos los DashBoard Activos.- --
   ''' </summary>
   ''' <returns></returns>
   Public Function DashBoards_GAO() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         '-----------------------
         SelectTexto(myQuery)
         FromTexto(myQuery)
         '----------------------
         .AppendLine("  WHERE Estado = 1 ")
         .AppendFormat("  ORDER BY DBR.{0}", Entidades.DashBoardPaneles.Columnas.Orden.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   ''' <summary>
   ''' Proceso de Recuperacion de un solo DashBoard.- 
   ''' </summary>
   ''' <param name="oIdDash">ID de DashBoard Seleccionado.-</param>
   ''' <returns></returns>
   Public Function DashBoard_G1(oIdDash As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         FromTexto(myQuery)
         .AppendFormat("  WHERE {0} = {1}", Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString(), oIdDash)
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   ''' <summary>
   ''' Obtienen el Mayor Valor de numerador DashBoard.- --
   ''' </summary>
   ''' <returns></returns>
   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString(), Entidades.DashBoardPaneles.NombreTabla))
   End Function
   ''' <summary>
   ''' Obtiene para sugerencia el Mayor Orden Existente.- --
   ''' </summary>
   ''' <returns></returns>
   Public Overloads Function GetOrdenMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.DashBoardPaneles.Columnas.Orden.ToString(), Entidades.DashBoardPaneles.NombreTabla))
   End Function

End Class
