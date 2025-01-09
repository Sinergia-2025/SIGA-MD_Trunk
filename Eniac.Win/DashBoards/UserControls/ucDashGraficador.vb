Imports System.IO
Imports Aspose.Words.Drawing.Charts

Public Class ucDashGraficador

#Region "Campos"
   '-- Variables de Graficados.- ------
   Public oNombreSerie As Integer = 0
   Private oSentenciaSQL As String = ""
   '-----------------------------------
   Private _DashBoardID As Integer
   ''' <summary>
   ''' Multiplicador de Timer en milisegundos.- --
   ''' </summary>
   Private ReadOnly DashBoardTMR As Integer = Reglas.Publicos.DashBoard.DashBoardMultipTimer
   ''' <summary>
   ''' Valor Maximo para las grillas.- --
   ''' </summary>
   Private ReadOnly DashBoardMMG As Integer = Reglas.Publicos.DashBoard.DashBoardMMGrids
#End Region

#Region "Overrides"
   Public Sub New()
      InitializeComponent()
      '-- Inicializa Graficador.- --
      Inicializar()
   End Sub
#End Region

#Region "Eventos"
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
   ''' <summary>
   ''' Hace un Refresh Full del DashBoard.- --
   ''' </summary>
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
      lblComentarioPrincipal.Text = "Comentario DashBoard"
      '-- Marca Tipo de Totalizador.- --
      oTipoDash = 2
      '-- Inicializar Dash Board.- --
      With gfcPrincipal
         .ChartAreas(oNombreSerie).AxisX.Title = ""
         .ChartAreas(oNombreSerie).AxisY.Title = ""
         '-- Barras de Objetivo-Minimo.- --
         With .ChartAreas("ChartArea").Axes(1)
            With .MajorGrid
               .Interval = 0
               .IntervalOffset = 0
               .Enabled = False
            End With
            With .MinorGrid
               .Interval = 0
               .IntervalOffset = 0
               .Enabled = False
            End With
         End With
         '-- Limpia las Series.- --
         .Series.Clear()
      End With
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
      lblComentarioPrincipal.Text = oDashBoard.Comentario
      '-- Auto Refresh.- --------------------------------
      With ckbDashBoard
         .Visible = oDashBoard.AutoRefresh
         .Checked = oDashBoard.AutoRefresh
      End With
      If oDashBoard.AutoRefresh Then
         '-- Establece el Intervalo de Ejecucion.- --
         tmrDashBoard.Interval = (oDashBoard.TimerRefresh * DashBoardTMR)
         '-- Para el caso de que se este editando.- ------
         If Not oEditando Then
            tmrDashBoard.Enabled = oDashBoard.AutoRefresh
         End If
      End If
      '-- Inicializa el Picture Box.- --
      Dim rDashBoard = New Reglas.DashBoardsPaneles
      If oDashBoard.ImagenDashBoard IsNot Nothing Then
         pbxDashGraficador.Image = rDashBoard.Bytes2Image(oDashBoard.ImagenDashBoard)
      End If
      '------------------------------------------------------------------------
      CargaPackDatos()
      '------------------------------------------------------------------------
   End Sub
   ''' <summary>
   ''' Carga el Pack de Datos y los objetos.- --
   ''' </summary>
   Private Sub CargaPackDatos()
      Try
         '-- Datos Principales.- --
         Dim oResultado = CargaSetDatos(oDashBoard.SentenciaSQL)
         Dim CantSeries = (oResultado.Columns.Count() - 1)
         '------------------------------------------------------------------------
         LimpiarDatosSeries(CantSeries - 1, oResultado)
         '------------------------------------------------------------------------
         '-- Especifica Propiedades del Grafico.- --
         With gfcPrincipal
            '-- Visualiza titulos en Grafica.- -----------------
            If oDashBoard.AxisTitleX IsNot Nothing Then
               .ChartAreas(oNombreSerie).AxisX.Title = oDashBoard.AxisTitleX
               .ChartAreas(oNombreSerie).AxisY.Title = oDashBoard.AxisTitleY
            End If
            '-- Tipo de Estilo 3D.- --
            .ChartAreas(0).Area3DStyle.Enable3D = oDashBoard.Area3DStyle IsNot Nothing AndAlso CBool(oDashBoard.Area3DStyle)
            '------------------------------------------------------------------------
            For Each dr As DataRow In oResultado.Rows
               For Ind = 1 To CantSeries
                  '-- Visualiza Puntos en Grafica.- -----------------
                  .Series(Ind - 1).IsValueShownAsLabel = CBool(oDashBoard.ShowValueLabel)
                  '-- Si ShowValueLabel es True - Define color de fondo de las burbujas.- --
                  If oDashBoard.ShowValueLabel Then
                     .Series(Ind - 1).LabelBackColor = Color.White
                  End If
                  '-------------------------------------------------------------------------
                  '-- Tipo de Grafico.- --
                  .Series(Ind - 1).ChartType = CType(oDashBoard.ModeloDashBoard.IdModeloDB, DataVisualization.Charting.SeriesChartType)
                  .Series(Ind - 1).AxisLabel = "."
                  '-- Carga Valores del Grafico.-
                  Select Case oDashBoard.ModeloDashBoard.IdModeloDB
                     Case 17, 18
                        .Series(Ind - 1).Points.AddXY(dr(0), dr(Ind).ToString)
                        .Series(Ind - 1).LegendText = ""
                     Case Else
                        .Series(Ind - 1).Points.AddXY(dr(0).ToString, dr(Ind).ToString)
                  End Select
                  .Series(Ind - 1).IsVisibleInLegend = oDashBoard.VisualizaLeyenda
               Next
            Next
            '-- Carga de Valores de Objetivo-Minimo.- -------------------------------
            If oDashBoard.ValorObjetivo > 0 And oDashBoard.ValorMinimo > 0 Then
               With gfcPrincipal.ChartAreas("ChartArea").Axes(1)
                  With .MajorGrid
                     .Interval = oDashBoard.ValorObjetivo * DashBoardMMG
                     .IntervalOffset = oDashBoard.ValorObjetivo
                     .Enabled = True
                  End With
                  With .MinorGrid
                     .Interval = oDashBoard.ValorMinimo * DashBoardMMG
                     .IntervalOffset = oDashBoard.ValorMinimo
                     .Enabled = True
                  End With
               End With
            Else
               With gfcPrincipal.ChartAreas("ChartArea").Axes(1)
                  With .MajorGrid
                     .Enabled = False
                  End With
                  With .MinorGrid
                     .Enabled = False
                  End With
               End With
            End If
            '------------------------------------------------------------------------
         End With
      Catch ex As Exception
         MessageBox.Show(String.Format("Error en la Carga de Datos.{0}{1}",
                                       Environment.NewLine,
                                       ex.Message), oDashBoard.Nombre, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   ''' <summary>
   ''' Crea las Cantidad de Series necesarias.-
   ''' </summary>
   ''' <param name="oSeries">Cantidad de Series</param>
   ''' <param name="oDt">Nombre/Titulo de Serie</param>
   Private Sub LimpiarDatosSeries(oSeries As Integer, oDt As DataTable)

      Try
         With gfcPrincipal
            '-- Limpia las Series.- --
            .Series.Clear()
            '-- Limpia por Cada Serie los Datos.- ----
            For Serie = 0 To oSeries
               '-- Define Variable de Series.- --------------------
               Dim sSeries = New DataVisualization.Charting.Series
               '---------------------------------------------------
               With sSeries
                  .Points.Clear()
                  '-- Visibiliza la Leyenda.- --
                  .IsVisibleInLegend = True
                  '-- Carga Leyenda del Grafico.-
                  .LegendText = String.Format("{0}", oDt.Columns(Serie + 1).ColumnName.ToString())
                  '-- Asocia la Cabecera de Chart.- --
                  .ChartArea = "ChartArea"
               End With
               '-- Agrega la nueva Serie.- 
               .Series.Add(sSeries)
               '--------------------------
            Next
         End With
      Catch ex As Exception
         MessageBox.Show(String.Format("Error en la Limpieza de Datos.{0}{1}",
                                       Environment.NewLine,
                                       ex.Message), oDashBoard.Nombre, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   ''' <summary>
   ''' Recupera los Datos de la Sentencia SQL.- --
   ''' </summary>
   ''' <param name="oSentenciaSQL"></param>
   ''' <returns></returns>
   Private Function CargaSetDatos(oSentenciaSQL As String) As DataTable
      Dim rSetDatos = New Reglas.DashBoardsPaneles()
      '-- Recupera Valor de Totalizador
      Return rSetDatos.GetValoresDashBoard(oSentenciaSQL)
   End Function

   Private Sub gfcPrincipal_KeyUp(sender As Object, e As KeyEventArgs) Handles gfcPrincipal.KeyUp
      Select Case e.KeyCode
         Case Keys.C '-- Cambia el Color de la Serie Principal. --
            cdgDashBoard.Color = Me.BackColor
            Dim oSerie = 0
            With gfcPrincipal
               If .Series.Count > 1 Then
                  oSerie = Integer.Parse(InputBox(String.Format("Introduzca Nro Serie {0}Entre valores 1 a {1}",
                                                                 Environment.NewLine,
                                                                 gfcPrincipal.Series.Count), "Cambio Color de Serie")) - 1
               End If
               If cdgDashBoard.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  .Series(oSerie).Color = cdgDashBoard.Color
               End If
            End With
         Case Keys.D '-- Muestra el Detalle. --

      End Select
   End Sub

#End Region

End Class
