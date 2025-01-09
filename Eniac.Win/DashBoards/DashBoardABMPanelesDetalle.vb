Option Strict On
Option Explicit On
#Region "Option"
Imports System.IO
#End Region

Public Class DashBoardABMPanelesDetalle

#Region "Campos"
   Private _Publicos As Publicos
   Private _decimalesEnDescRec As Integer
   ''' <summary>
   ''' DashBoard Base.- --
   ''' </summary>
   Public ucDashGT As ucDashBase = Nothing
   Public oEntidad As Entidades.DashBoardPaneles
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.DashBoardPaneles)
      InitializeComponent()
      oEntidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _Publicos = New Publicos()
         _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec
         '-- Formate los Campos de Valore Obj-Min.- -------------
         txtMinimoDashBoard.Formato = "N" + _decimalesEnDescRec.ToString()
         txtObjetivoDashBoard.Formato = "N" + _decimalesEnDescRec.ToString()
         '-- Carga Combos de Tipo y Modelo.- ---------------------
         _Publicos.CargaComboTiposDashBoard(cmbTipoDashBoard)
         _Publicos.CargaComboModelosDashBoard(cmbModeloDashBoard)
         _Publicos.CargaComboRefreshDashBoard(cmbTipoRefreshDashBoard)
         '-- Inicializa Imagen.- ------------------------------------ 
         lblImagenDashBoard.Tag = ""
         lblImagenDashBoard.ForeColor = Color.Black
         '-- Carga Valores de Entidad.- --
         CargaControles(oEntidad)
         '------------------------------------------------------
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
   ''' <summary>
   ''' Procedimiento de Aceptar.- --
   ''' </summary>
   Protected Overrides Sub Aceptar()
      Dim rTipos = New Reglas.DashBordsTipos().GetUno(CInt(cmbTipoDashBoard.SelectedValue))
      Dim rModel = New Reglas.DashBordsModelos().GetUno(CInt(cmbModeloDashBoard.SelectedValue))
      Try
         If ValidaCargaDashBoard() Then
            '-- Volcado de Informacion a la Entidad.- --
            With oEntidad
               .IdDashBoard = Integer.Parse(txtIdDashBoard.Text)
               .Nombre = txtNombreDashBoard.Text
               .Titulo = txtTituloDashBoard.Text
               .Comentario = txtComentarioDashBoard.Text
               .ValorObjetivo = Decimal.Parse(txtObjetivoDashBoard.Text)
               .ValorMinimo = Decimal.Parse(txtMinimoDashBoard.Text)
               .Orden = Integer.Parse(txtOrdenDashBoard.Text)
               '------------------------------------------------------------------
               .VisualizaLeyenda = chbShowLeyendLabel.Checked
               '-- Sentencia SQL.- -----------------------------------------------
               .SentenciaSQL = txtSentenciaSQLDashB.Text
               '-- Carga Combos.- ------------------------------------------------
               .TipoDashBoard = rTipos
               .TipoRefresh = CInt(cmbTipoRefreshDashBoard.SelectedValue)
               .TimerRefresh = Integer.Parse(txtTiempoDashBoard.Text)
               '-- Carga los Check.- ---------------------------------------------
               .AutoRefresh = chbRefrescaDatos.Checked
               .Estado = chbEstadoDash.Checked
               '------------------------------------------------------------------
               If lblImagenDashBoard.Tag IsNot Nothing Then
                  .ImagenDashBoard = CType(lblImagenDashBoard.Tag, Byte())
               Else
                  .ImagenDashBoard = Nothing
               End If
               '------------------------------------------------------------------
               If CInt(cmbTipoDashBoard.SelectedValue.ToString()) = 2 Then
                  .ModeloDashBoard = rModel
                  .Area3DStyle = chbEstiloArea3D.Checked
                  .ShowValueLabel = chbShowValueLabel.Checked
                  .AxisTitleX = If(chbTituloXDash.Checked, txtTituloXDash.Text, Nothing)
                  .AxisTitleY = If(chbTituloYDash.Checked, txtTituloYDash.Text, Nothing)
               End If
            End With
            _entidad = oEntidad
            '-- Convoca Proceso de Carga.- --
            MyBase.Aceptar()
         End If
      Catch ex As Exception
         Throw New Exception("Error en la Operacion DashBoard.")
      End Try
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.DashBoardsPaneles()
   End Function
#End Region

#Region "Metodos"
   Private Function ControlaIntegridadSQL() As Boolean
      Try
         Dim rSetDatos = New Reglas.DashBoardsPaneles()
         '-- Recupera Valor de Totalizador
         Dim dt = rSetDatos.GetValoresDashBoard(txtSentenciaSQLDashB.Text)
         Select Case Integer.Parse(cmbTipoDashBoard.SelectedValue.ToString())
            Case 1
               Select Case dt.Rows.Count
                  Case > 1
                     ShowMessage("La sentencia SQL no cumple con las condiciones para el tipo Totalizador!!!")
                     Return False
                  Case 0
                     ShowMessage("La sentencia SQL no arroja resultado para el tipo Totalizador!!!")
                     Return True
               End Select
            Case 2
               Select Case dt.Rows.Count
                  Case >= 1
                     For Each dr As DataRow In dt.Rows
                        If dr.Table.Columns.Count <= 1 Then
                           ShowMessage("La sentencia SQL no cumple con las condiciones para el tipo Graficador!!!")
                           Return False
                        End If
                     Next
                  Case 0
                     ShowMessage("La sentencia SQL no arroja resultado para el tipo Graficador!!!")
                     Return False
               End Select
         End Select
      Catch ex As Exception
         MessageBox.Show(String.Format("Error en Sentencia SQL.{0}{1}",
                                       Environment.NewLine,
         ex.Message), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Return False
      End Try
      Return True
   End Function
   Private Sub CargaControles(entidad As Entidades.DashBoardPaneles)
      Try
         '--- Carga Combos.- --------------------------------
         If StateForm = Eniac.Win.StateForm.Insertar Then
            '-- Inicializa los Controles.- ----------------------------------------------------------------------
            txtIdDashBoard.Text = (DirectCast(GetReglas(), Reglas.DashBoardsPaneles).GetCodigoMaximo() + 1).ToString()
            cmbTipoDashBoard.SelectedIndex = -1
            txtNombreDashBoard.Text = ""
            txtTituloDashBoard.Text = ""
            txtOrdenDashBoard.Text = (DirectCast(GetReglas(), Reglas.DashBoardsPaneles).GetOrdenMaximo() + 1).ToString()
            chbEstadoDash.Checked = True
            txtComentarioDashBoard.Text = ""
            chbRefrescaDatos.Checked = False
            cmbTipoRefreshDashBoard.SelectedIndex = 0
            txtTiempoDashBoard.Text = "1"
            txtObjetivoDashBoard.Text = "0.00"
            txtMinimoDashBoard.Text = "0.00"
            chbEstiloArea3D.Checked = False
            chbShowValueLabel.Checked = False
            '--------------------------------------
            chbShowLeyendLabel.Checked = False
            '--------------------------------------
            chbTituloXDash.Checked = False
            txtTituloXDash.Text = ""
            chbTituloYDash.Checked = False
            txtTituloYDash.Text = ""
            txtSentenciaSQLDashB.Text = ""
            lblImagenDashBoard.Tag = Nothing
            '-- Limpia los Controles.- --
            pnlVisualizadorDashBoard.Controls.Clear()
            '----------------------------------------------------------------------------------------------------
            cmbTipoDashBoard.SelectedIndex = 0
            cmbTipoDashBoard.Focus()
         Else
            '-- Inicializa los Controles.- ----------------------------------------------------------------------
            With entidad
               txtIdDashBoard.Text = .IdDashBoard.ToString()
               txtNombreDashBoard.Text = .Nombre.ToString()
               txtTituloDashBoard.Text = .Titulo.ToString()
               txtComentarioDashBoard.Text = .Comentario.ToString()
               txtObjetivoDashBoard.Text = .ValorObjetivo.ToString()
               txtMinimoDashBoard.Text = .ValorMinimo.ToString()
               txtOrdenDashBoard.Text = .Orden.ToString()
               txtTiempoDashBoard.Text = .TimerRefresh.ToString()
               txtTiempoDashBoard.Enabled = .AutoRefresh
               '-----------------------------------------------------------
               chbShowLeyendLabel.Checked = CBool(.VisualizaLeyenda)
               '-- Imagen.- -----------------------------------------------
               If .ImagenDashBoard IsNot Nothing Then
                  lblImagenDashBoard.Tag = .ImagenDashBoard
                  lblImagenDashBoard.ForeColor = Color.Green
               Else
                  lblImagenDashBoard.Tag = Nothing
                  lblImagenDashBoard.ForeColor = Color.Black
               End If
               '-- Sentencia SQL.- -----------------------------------------------
               txtSentenciaSQLDashB.Text = .SentenciaSQL.ToString()
               '-- Carga Combos.- ------------------------------------------------
               cmbTipoDashBoard.SelectedValue = .TipoDashBoard.IdDashTipos
               cmbTipoRefreshDashBoard.SelectedValue = .TipoRefresh
               cmbTipoRefreshDashBoard.Enabled = .AutoRefresh
               '-- Carga los Check.- ---------------------------------------------
               chbRefrescaDatos.Checked = .AutoRefresh
               chbEstadoDash.Checked = .Estado
               '--------------------------------------------------------
               If CInt(cmbTipoDashBoard.SelectedValue.ToString()) = 2 Then
                  cmbModeloDashBoard.SelectedValue = .ModeloDashBoard.IdModelo
                  chbEstiloArea3D.Checked = CBool(.Area3DStyle)
                  chbShowValueLabel.Checked = CBool(.ShowValueLabel)
                  txtTituloXDash.Text = .AxisTitleX
                  txtTituloYDash.Text = .AxisTitleY
               Else

                  gpbDashBoardGrafico.Visible = False
               End If
               '-----------------------------------------------------------------
            End With
            '-- Deshabilita el Cambio de Tipo.- --
            cmbTipoDashBoard.Enabled = False
            '--------------------------------------------------------
            CargaDashBoardIni()
            '--------------------------------------------------------
            chbTituloXDash.Checked = Not String.IsNullOrWhiteSpace(txtTituloXDash.Text)
            chbTituloYDash.Checked = Not String.IsNullOrWhiteSpace(txtTituloYDash.Text)
            '--------------------------------------------------------
            txtNombreDashBoard.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   ''' <summary>
   ''' Validacion de Datos del DashBoard.- --
   ''' </summary>
   ''' <returns></returns>
   Private Function ValidaCargaDashBoard() As Boolean
      '-- Controla Validez del intervalo de los timers.- ---
      If Integer.Parse(txtTiempoDashBoard.Text) <= 0 Then
         ShowMessage("El Valor para el intervalo Timer debe ser mayor a Cero!!!")
         txtTiempoDashBoard.Focus()
         Return False
      End If
      '-- Controla Integridad SQL.- --
      If Not ControlaIntegridadSQL() Then
         Return False
      End If
      '-- Salida Exitosa.- --
      Return True
   End Function
   Private Sub CargaDashBoardIni()
      '-- Activa la Barras de Desplazamiento.- --
      pnlVisualizadorDashBoard.Controls.Clear()
      '----------------------------------------------------------------------------
      '-- Define Variables.- ------------------------------------------------------
      Dim rDashBoard = New Reglas.DashBoardsPaneles
      Dim eDashBoard = New Entidades.DashBoardPaneles
      '----------------------------------------------------------------------------
      '-- Recupera el DashBoard Activos.- --
      Dim dtDashBoard = rDashBoard.GetUno(CInt(txtIdDashBoard.Text))
      '-- Crea DashBoard asegun el tipo.- --
      ucDashGT = CrearUcDash(dtDashBoard.TipoDashBoard.NombreObjeto)
      If ucDashGT IsNot Nothing Then
         '-- Asigna Posicion del DashBoard.- ---
         CargaPositionDashBoard()
         '-- Carga el DashBoard.- --
         pnlVisualizadorDashBoard.Controls.Add(ucDashGT)
         '-- Inicializar Control DashBoard.- --
         With ucDashGT
            .oEditando = True
            '-- Informa la Entidad de Datos.- --
            .oDashBoard = dtDashBoard
            '-- Proceso de Carga de Datos.- ----
            .GetValoresDashBoard()
         End With
      End If
   End Sub
   Private Sub RecargaDashBoard()
      '-- Activa la Barras de Desplazamiento.- --
      pnlVisualizadorDashBoard.Controls.Clear()
      '-- Define Variables.- ------------------------------------------------------
      Dim eDashBoard = New Reglas.DashBordsModelos().GetUno(CInt(cmbModeloDashBoard.SelectedValue))
      '----------------------------------------------------------------------------
      '-- Recarga Control DashBoard.- --
      With ucDashGT
         '-- Informa la Entidad de Datos.- --
         With .oDashBoard
            '-- Carga los datos del DashBoard.- --
            .Nombre = txtNombreDashBoard.Text
            .Titulo = txtTituloDashBoard.Text
            .Comentario = txtComentarioDashBoard.Text
            .AutoRefresh = chbRefrescaDatos.Checked
            .TipoRefresh = CInt(cmbTipoDashBoard.SelectedValue)
            .ValorObjetivo = CInt(txtObjetivoDashBoard.Text)
            .ValorMinimo = CInt(txtMinimoDashBoard.Text)
            .Area3DStyle = chbEstiloArea3D.Checked
            .ShowValueLabel = chbShowValueLabel.Checked
            '------------------------------------------------------------------
            .VisualizaLeyenda = chbShowLeyendLabel.Checked
            '------------------------------------------------------------------
            .SentenciaSQL = txtSentenciaSQLDashB.Text
            .TimerRefresh = CInt(txtTiempoDashBoard.Text)
            '------------------------------------------------------------------
            If lblImagenDashBoard.Tag IsNot Nothing Then
               .ImagenDashBoard = CType(lblImagenDashBoard.Tag, Byte())
            End If
            '------------------------------------------------------------------
            .AxisTitleX = If(chbTituloXDash.Checked, txtTituloXDash.Text, "")
            .AxisTitleY = If(chbTituloYDash.Checked, txtTituloYDash.Text, "")
            '------------------------------------------------------------------
            .ModeloDashBoard = eDashBoard
            '------------------------------------------------------------------
         End With
         '-- Carga el DashBoard.- --
         pnlVisualizadorDashBoard.Controls.Add(ucDashGT)
         '-- Proceso de Carga de Datos.- ----
         .GetValoresDashBoard()
         '-----------------------------------
      End With
   End Sub
   Public Sub CargaPositionDashBoard()
      Dim rDashBoardT = New Reglas.DashBordsTipos
      Dim eDashBoardT = rDashBoardT.GetUno(CInt(cmbTipoDashBoard.SelectedValue))
      Dim oLocation As Point = ucDashGT.Location
      '-----------------------------------------------
      oLocation.X = CInt(eDashBoardT.LocationX)
      oLocation.Y = CInt(eDashBoardT.LocationY)
      '-- Establece posicion.- --
      ucDashGT.Location = oLocation
   End Sub
   ''' <summary>
   ''' Crea una Instancia de un Objeto en Base a su Nombre.- --
   ''' </summary>
   ''' <param name="nombreObjecto">Nombre del Objeto</param>
   ''' <returns></returns>
   Private Function CrearUcDash(nombreObjecto As String) As ucDashBase
      Try
         If Not String.IsNullOrWhiteSpace(nombreObjecto) Then
            Dim assemblyName As String = String.Empty
            Dim className As String
            Dim splitController = nombreObjecto.Split(":"c)
            If splitController.Length > 1 Then
               assemblyName = splitController(0)
               className = splitController(1)
            Else
               If splitController(0).Contains(".") Then
                  Dim posicionUltimoPunto = splitController(0).LastIndexOf("."c)
                  assemblyName = splitController(0).Substring(0, posicionUltimoPunto)
               End If
               className = splitController(0)
            End If

            Dim assembly As Reflection.Assembly = Nothing
            If Not String.IsNullOrWhiteSpace(assemblyName) Then
               Try
                  assembly = AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(Function(a) a.GetName().Name = assemblyName)
               Catch ex As Exception
                  assembly = Nothing
               End Try
            End If
            If assembly Is Nothing Then
               assembly = Reflection.Assembly.GetExecutingAssembly()
            End If

            If Not className.Contains(".") Then
               className = String.Concat(assembly.GetName().Name, ".", className)
            End If

            Dim type = assembly.GetType(className)

            Dim obj = Activator.CreateInstance(type)

            If TypeOf (obj) Is ucDashBase Then
               Return DirectCast(obj, ucDashBase)
            End If

         End If
      Catch ex As Exception

      End Try
      Return Nothing
   End Function
   ''' <summary>
   ''' Procedimiento ante el cambio de Tipo DashBoard.-
   ''' Rearma el Panel, carga el nuevo Dash y susu datos.-
   ''' </summary>
   Private Sub CambiaTipoDashBoard()
      Try
         If cmbTipoDashBoard.SelectedIndex > -1 Then
            '-- Activa la Barras de Desplazamiento.- --
            pnlVisualizadorDashBoard.Controls.Clear()
            '-- Define Variables.- ------------------------------------------------------
            Dim rDashT = New Reglas.DashBordsTipos
            '-- Recupera el Tipo de DashBoard Seleccionado.- --
            Dim eDashT As Entidades.DashBoardTipo = rDashT.GetUno(CInt(cmbTipoDashBoard.SelectedValue.ToString()))
            '----------------------------------------------------------------------------
            '-- Crea DashBoard asegun el tipo.- --
            ucDashGT = CrearUcDash(eDashT.NombreObjeto)
            '-----------------------------------------
            If ucDashGT IsNot Nothing Then
               '-- Asigna Posicion del DashBoard.- ---
               CargaPositionDashBoard()
               '-- Verifica el tipo de Dash.- -----------
               gpbDashBoardGrafico.Visible = CInt(cmbTipoDashBoard.SelectedValue.ToString()) = 2
               '-- Carga el DashBoard.- --
               pnlVisualizadorDashBoard.Controls.Add(ucDashGT)
               '-- Inicializar Control DashBoard.- --
               With ucDashGT
                  .oEditando = True
                  '-- Proceso de Carga de Datos.- ----
                  .GetValoresDashBoard()
               End With
            End If
            '----------------------------------------------------------------------------
         End If
         txtNombreDashBoard.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Eventos"
   Private Sub chbRefrescaDatos_CheckedChanged(sender As Object, e As EventArgs) Handles chbRefrescaDatos.CheckedChanged
      txtTiempoDashBoard.Enabled = chbRefrescaDatos.Checked
      cmbTipoRefreshDashBoard.Enabled = chbRefrescaDatos.Checked
   End Sub
   Private Sub chbTituloXDash_CheckedChanged(sender As Object, e As EventArgs) Handles chbTituloXDash.CheckedChanged
      txtTituloXDash.Enabled = chbTituloXDash.Checked
      txtTituloXDash.Focus()
   End Sub
   Private Sub chbTituloYDash_CheckedChanged(sender As Object, e As EventArgs) Handles chbTituloYDash.CheckedChanged
      txtTituloYDash.Enabled = chbTituloYDash.Checked
      txtTituloYDash.Focus()
   End Sub
   Private Sub pnlVisualizadorDashBoard_DoubleClick(sender As Object, e As EventArgs) Handles pnlVisualizadorDashBoard.DoubleClick
      '-- Refresh del Grafico DashBoard.- --
      RefrescaDatosDash()
   End Sub


   ''' <summary>
   ''' Boton de Insercion de Imagen.- ---
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      '-- Setea OpenFileDialog.- --------------------------------------------------
      With DialogoAbrirArchivo
         .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
         .Filter = "Archivos PNG(*.png)|*.png|Archivos graficos (*.jpg)|*.jpg|Archivos GIF(*.gif)|*.gif"
      End With
      '----------------------------------------------------------------------------
      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Dim fileInfo = New IO.FileInfo(DialogoAbrirArchivo.FileName)
            If fileInfo.Exists Then
               '-- Carga Imagen.- ------------------------------------ 
               lblImagenDashBoard.Tag = File.ReadAllBytes(DialogoAbrirArchivo.FileName)
               lblImagenDashBoard.ForeColor = Color.Green
            Else
               ShowMessage(String.Format("No se puede acceder al archivo '{0}'.", DialogoAbrirArchivo.FileName))
            End If
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el Archivo. Error: {0}", Ex.Message))
         End Try
      End If
      '---------------------------------------------------------------------------
   End Sub
   ''' <summary>
   ''' Boton de eliminacion de Imagen.- --
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      '-- Inicializa Imagen.- ------------------------------------ 
      lblImagenDashBoard.Tag = Nothing
      lblImagenDashBoard.ForeColor = Color.Black
      '------------------------------------------------------
   End Sub
   Private Sub cmbTipoDashBoard_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDashBoard.SelectedIndexChanged
      '-- Carga del tipo de DashBoard.- --
      CambiaTipoDashBoard()
   End Sub

   Private Sub btnVisualizar_Click(sender As Object, e As EventArgs) Handles btnVisualizar.Click
      '-- Refresh del Grafico DashBoard.- --
      RefrescaDatosDash()
   End Sub

   ''' <summary>
   ''' Realiza el Refresh de los Datos.- --
   ''' </summary>
   Private Sub RefrescaDatosDash()
      '-- Controla Integridad SQL.- --
      If ControlaIntegridadSQL() Then
         '-- Recarga Datos del DashBoard.- --
         CambiaTipoDashBoard()
         RecargaDashBoard()
         '-----------------------------------
      End If
   End Sub

#End Region

End Class