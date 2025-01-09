Public Class DashBoardTablero
#Region "Campos"

#End Region

#Region "Overrides"
   ''' <summary>
   ''' Load del Formulario.- --
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub Frm_DashBoard_Load(sender As Object, e As EventArgs) Handles Me.Load
      '-- Activa la Barras de Desplazamiento.- --
      FlowLayoutPanel.AutoScroll = True
      '----------------------------------------------------------------------------
      CargaDashBoardIni()
   End Sub
#End Region

#Region "Eventos"
   ''' <summary>
   ''' Doble Click FlowLayoutPanel.- --
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub FlowLayoutPanel_DoubleClick(sender As Object, e As EventArgs) Handles FlowLayoutPanel.DoubleClick
      '----------------------------------------------------------------------------
      CargaDashBoardIni()
   End Sub
#End Region

#Region "Metodos"
   ''' <summary>
   ''' Metodo de Inicio de Carga de DashBoard.- --
   ''' </summary>
   Public Sub CargaDashBoardIni()
      '-- Activa la Barras de Desplazamiento.- --
      FlowLayoutPanel.Controls.Clear()
      '----------------------------------------------------------------------------
      '-- Define Variables.- ------------------------------------------------------
      Dim rDashBoard = New Reglas.DashBoardsPaneles
      Dim eDashBoard = New Entidades.DashBoardPaneles
      Dim ucDashGT As ucDashBase = Nothing
      '----------------------------------------------------------------------------
      '-- Recupera todos los DashBoard Activos.- --
      Dim dtDashBoard = rDashBoard.GetInicio()
      For Each dash In dtDashBoard
         '-- Dash Totalizador.- --
         ucDashGT = CrearUcDash(dash.TipoDashBoard.NombreObjeto)
         If ucDashGT IsNot Nothing Then
            '-- Carga el DashBoard.- --
            FlowLayoutPanel.Controls.Add(ucDashGT)
            '-- Inicializar Control DashBoard.- --
            With ucDashGT
               '-- Informa la Entidad de Datos.- --
               .oDashBoard = dash
               '-- Proceso de Carga de Datos.- ----
               .GetValoresDashBoard()
            End With
         End If
      Next
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
#End Region

End Class