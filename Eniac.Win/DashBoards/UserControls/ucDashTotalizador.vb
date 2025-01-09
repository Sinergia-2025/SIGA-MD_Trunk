Public Class ucDashTotalizador

#Region "Campos"
   Private _DashBoardID As Integer
   ''' <summary>
   ''' Multiplicador de Timer en milisegundos.- --
   ''' </summary>
   Private ReadOnly DashBoardTMR As Integer = Reglas.Publicos.DashBoard.DashBoardMultipTimer

#End Region

#Region "Overrides"
   Public Sub New()
      InitializeComponent()
      '-- Inicializa Totalizador.- --
      Inicializar()
   End Sub
#End Region

#Region "Eventos"
   ''' <summary>
   ''' Evento Click de la Imagen del Totalizador.- --
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub pbxDashTotalizador_Click(sender As Object, e As EventArgs) Handles pbxDashTotalizador.Click

   End Sub
   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub tmrDashBoard_Tick(sender As Object, e As EventArgs) Handles tmrDashBoard.Tick
      Try
         Select Case oDashBoard.TipoRefresh
            Case Entidades.Publicos.TipoRefreshDashBoard.DATOS
               '----------------------------------------------------------------------------
               CargaPackDatos()
               '----------------------------------------------------------------------------
            Case Entidades.Publicos.TipoRefreshDashBoard.FULL
               '----------------------------------------------------------------------------
               RefreshFullDashBoard()
               '----------------------------------------------------------------------------
         End Select
      Catch ex As Exception
         MessageBox.Show(ex.Message, oDashBoard.Nombre, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub ckbDashBoard_CheckedChanged(sender As Object, e As EventArgs) Handles ckbDashBoard.CheckedChanged
      '-- Activa-Desactiva Timer.- --------------------
      '-- Para el caso de que se este editando.- ------
      If Not oEditando Then
         tmrDashBoard.Enabled = ckbDashBoard.Checked
      End If
      '------------------------------------------------
   End Sub

#End Region

#Region "Metodos"
   Private Sub RefreshFullDashBoard()
      '-- Define Variables.- ------------------------------------------------------
      Dim rDashBoard = New Reglas.DashBoardsPaneles
      '-- Recupera todos los DashBoard Activos.- ----------------------------------
      oDashBoard = rDashBoard.GetUno(_DashBoardID)
      '-- Refresh Set de Datos.- --------------------------------------------------
      GetValoresDashBoard()
      '----------------------------------------------------------------------------
   End Sub

   ''' <summary>
   ''' Inicializa los Objetos del DashBoard.- --
   ''' </summary>
   Private Sub Inicializar()
      '-- Inicializa los Label.- --
      lblTituloPrincipal.Text = "Titulo DashBoard"
      lblTituloComentario.Text = "Comentario DashBoard"
      lblDatosPrincipales.Text = "Dato-Valor"
      '-- Marca Tipo de Totalizador.- --
      oTipoDash = 1
      '-- Instancia Nueva Entidad.- ------
      oDashBoard = New Entidades.DashBoardPaneles
   End Sub
   ''' <summary>
   ''' Recibe los Valores Principales del DashBord.- --
   ''' </summary>
   Public Overrides Sub GetValoresDashBoard()
      '-- Carga el Numero de DashBoard.- --
      _DashBoardID = oDashBoard.IdDashBoard
      '-- Carga Valores de Etiquetas.- --
      lblTituloPrincipal.Text = oDashBoard.Titulo
      lblTituloComentario.Text = oDashBoard.Comentario
      '-- Auto Refresh.- --------------------------------
      With ckbDashBoard
         .Visible = oDashBoard.AutoRefresh
         .Checked = oDashBoard.AutoRefresh
      End With
      If oDashBoard.AutoRefresh Then
         tmrDashBoard.Interval = (oDashBoard.TimerRefresh * DashBoardTMR)
         '-- Para el caso de que se este editando.- ------
         If Not oEditando Then
            tmrDashBoard.Enabled = oDashBoard.AutoRefresh
         End If
         '------------------------------------------------
      End If
      '-- Inicializa el Picture Box.- --
      Dim rDashBoard = New Reglas.DashBoardsPaneles
      If oDashBoard.ImagenDashBoard IsNot Nothing Then
         pbxDashTotalizador.Image = rDashBoard.Bytes2Image(oDashBoard.ImagenDashBoard)
      End If
      '----------------------------------------------------
      CargaPackDatos()
      '----------------------------------------------------
   End Sub
   ''' <summary>
   ''' Carga los Datos del totalizador
   ''' </summary>
   Private Sub CargaPackDatos()
      Try
         '-- Datos Principales.- --
         Dim oResultado = CargaSetDatos(oDashBoard.SentenciaSQL)
         '--------------------------------------------------
         If oDashBoard.ValorObjetivo > 0 And oDashBoard.ValorMinimo > 0 Then
            Select Case oResultado
               Case > oDashBoard.ValorObjetivo
                  lblDatosPrincipales.ForeColor = Color.SpringGreen
               Case < oDashBoard.ValorMinimo
                  lblDatosPrincipales.ForeColor = Color.Red
               Case Else
                  lblDatosPrincipales.ForeColor = Color.Yellow
            End Select
         Else
            lblDatosPrincipales.ForeColor = Color.White
         End If
         '-------------------------------------------------------------
         lblDatosPrincipales.Text = String.Format("{0:N2}", oResultado)
         '-------------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(String.Format("Error en la Carga de Datos.{0}{1}",
                                       Environment.NewLine,
                                       ex.Message), oDashBoard.Nombre, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   ''' <summary>
   ''' Recupera los Datos de la Sentencia SQL.- --
   ''' </summary>
   ''' <param name="oSentenciaSQL"></param>
   ''' <returns></returns>
   Private Function CargaSetDatos(oSentenciaSQL As String) As Decimal
      Dim oString As Decimal = 0
      Dim rSetDatos = New Reglas.DashBoardsPaneles()
      '-- Recupera Valor de Totalizador
      Dim dt = rSetDatos.GetValoresDashBoard(oSentenciaSQL)
      For Each dr As DataRow In dt.Rows
         oString = CDec(dr(0))
      Next
      '-- Informa Valor Totalizador.- --
      Return oString
   End Function

#End Region

End Class
