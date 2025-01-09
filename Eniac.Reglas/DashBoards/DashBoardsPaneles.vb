#Region "Option"
Option Strict On
Option Explicit On
#End Region

Imports System.Drawing
Imports System.IO
Public Class DashBoardsPaneles
   Inherits Base
#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.DashBoardPaneles.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardPaneles), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardPaneles), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardPaneles), TipoSP._D))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.DashBoardPaneles(Me.da).DashBoards_GA()
   End Function
#End Region

#Region "Metodos Privados"
   ''' <summary>
   ''' Ejecuta Sentencias SQL.- --
   ''' </summary>
   ''' <param name="en"></param>
   ''' <param name="tipo"></param>
   Private Sub EjecutaSP(en As Entidades.DashBoardPaneles, tipo As TipoSP)
      Dim sqlC = New SqlServer.DashBoardPaneles(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.DashBords_I(en.IdDashBoard,
                             en.Nombre,
                             en.TipoDashBoard.IdDashTipos,
                             en.Titulo,
                             en.Comentario,
                             en.SentenciaSQL,
                             en.AutoRefresh,
                             en.TipoRefresh,
                             en.TimerRefresh,
                             en.ImagenDashBoard,
                             en.ValorObjetivo,
                             en.ValorMinimo,
                             en.Area3DStyle,
                             If(en.ModeloDashBoard Is Nothing, Nothing, en.ModeloDashBoard.IdModelo),
                             en.ShowValueLabel,
                             en.AxisTitleX,
                             en.AxisTitleY,
                             en.Estado,
                             en.Orden,
                             en.VisualizaLeyenda)
         Case TipoSP._U
            sqlC.DashBords_U(en.IdDashBoard,
                             en.Nombre,
                             en.TipoDashBoard.IdDashTipos,
                             en.Titulo,
                             en.Comentario,
                             en.SentenciaSQL,
                             en.AutoRefresh,
                             en.TipoRefresh,
                             en.TimerRefresh,
                             en.ImagenDashBoard,
                             en.ValorObjetivo,
                             en.ValorMinimo,
                             en.Area3DStyle,
                             If(en.ModeloDashBoard Is Nothing, Nothing, en.ModeloDashBoard.IdModelo),
                             en.ShowValueLabel,
                             en.AxisTitleX,
                             en.AxisTitleY,
                             en.Estado,
                             en.Orden,
                             en.VisualizaLeyenda)
         Case TipoSP._D
            sqlC.DashBords_D(en.IdDashBoard)
      End Select
   End Sub
   ''' <summary>
   ''' Carga los datos de un DashBoard.- --
   ''' </summary>
   ''' <param name="oDashBoard"></param>
   ''' <param name="dr"></param>
   Public Sub CargarUno(oDashBoard As Entidades.DashBoardPaneles, dr As DataRow)
      '----------------------------------------------------
      Dim rDashTipos = New DashBordsTipos
      Dim rDashModel = New DashBordsModelos
      '----------------------------------------------------
      With oDashBoard
         .IdDashBoard = dr.Field(Of Integer)("idDashBoard")
         '-- Tipos de DashBoard.- --
         .TipoDashBoard = rDashTipos.GetUno(dr.Field(Of Integer)("TipoDashBoard"))
         '--------------------------
         .Nombre = dr.Field(Of String)("Nombre")
         .Comentario = dr.Field(Of String)("Comentario")
         .Titulo = dr.Field(Of String)("Titulo")
         '-- Auto Refresh de Timer.- --
         .AutoRefresh = dr.Field(Of Boolean)("AutoRefresh")
         .TipoRefresh = dr.Field(Of Integer)("TipoRefresh")
         .TimerRefresh = dr.Field(Of Integer)("TimerRefresh")
         '---------------------
         .VisualizaLeyenda = dr.Field(Of Boolean)("VisualizaLeyenda")
         '-- Sentencia SQL.- --
         .SentenciaSQL = dr.Field(Of String)("SentenciaSQL")
         '-- Valores Objeto y Minimos.- --
         .ValorObjetivo = dr.Field(Of Decimal)("ValorObjetivo")
         .ValorMinimo = dr.Field(Of Decimal)("ValorMinimo")
         '-- Descarga Imagen de la Base.- ------------------------
         If Not String.IsNullOrWhiteSpace(dr("ImagenDashBoard").ToString()) Then
            .ImagenDashBoard = CType(dr("ImagenDashBoard"), Byte())
         End If
         '-- Orden del DashBoard.- --------------------------------
         .Orden = dr.Field(Of Integer)("Orden")
         '-- Estado del DashBoard.- --------------------------------
         .Estado = dr.Field(Of Boolean)("Estado")
         '-- Verifica si el tipo de DashBord - Graficador.- --
         If .TipoDashBoard.IdDashTipos = 2 Then
            '-- Datos Graficos del DashBoard.- --
            .Area3DStyle = dr.Field(Of Boolean)("Area3DStyle")
            .ShowValueLabel = dr.Field(Of Boolean)("ShowValueLabel")
            .AxisTitleX = dr.Field(Of String)("AxisTitleX")
            .AxisTitleY = dr.Field(Of String)("AxisTitleY")
            '-- Modelo de DashBoard.- --
            If Not String.IsNullOrWhiteSpace(dr("ModeloDashBoard").ToString()) Then
               .ModeloDashBoard = rDashModel.GetUno(dr.Field(Of Integer)("ModeloDashBoard"))
               .Modelo = dr.Field(Of String)("Modelo")
            End If
         End If
         '----------------------------------------------------
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function GetValoresDashBoard(rSentencia As String) As DataTable
      '-- Define Variable SQL.- --
      Dim sql = New SqlServer.DashBoardPaneles(Me.da)
      Try
         Me.da.OpenConection()
         '-- Recupera Valor de la Consulta.- --
         Return sql.GetValoresDashBoard(rSentencia)
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetUno(idDashBoard As Integer) As Entidades.DashBoardPaneles
      Return GetUno(idDashBoard, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDashBoard As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.DashBoardPaneles
      Return CargaEntidad(New SqlServer.DashBoardPaneles(Me.da).DashBoard_G1(idDashBoard),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardPaneles(),
                          accion, Function() String.Format("No existe DashBoard con Id: {0}", idDashBoard))
   End Function
   ''' <summary>
   ''' Procedimiento para Traer Todos los Registros.- --
   ''' </summary>
   ''' <returns></returns>
   Public Function GetTodos() As List(Of Entidades.DashBoardPaneles)
      Return CargaLista(New SqlServer.DashBoardPaneles(Me.da).DashBoards_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardPaneles())
   End Function
   Public Function GetInicio() As List(Of Entidades.DashBoardPaneles)
      Return CargaLista(New SqlServer.DashBoardPaneles(Me.da).DashBoards_GAO(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardPaneles())
   End Function
   ''' <summary>
   ''' Trae Valor Maximo de DashBoard.-
   ''' </summary>
   ''' <returns></returns>
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.DashBoardPaneles(Me.da).GetCodigoMaximo()
   End Function
   ''' <summary>
   ''' Trae Valor Maximo de Orden.-
   ''' </summary>
   ''' <returns></returns>
   Public Function GetOrdenMaximo() As Integer
      Return New SqlServer.DashBoardPaneles(Me.da).GetOrdenMaximo()
   End Function
   ''' <summary>
   ''' Convierte Variables Byte a Imagen.- --
   ''' </summary>
   ''' <param name="bytes">Dato de Llegada</param>
   ''' <returns></returns>
   Public Function Bytes2Image(bytes() As Byte) As Image
      If bytes Is Nothing Then Return Nothing

      Dim ms As New MemoryStream(bytes)
      Dim bm As Bitmap = Nothing

      Try
         bm = New Bitmap(ms)
      Catch ex As Exception
         Debug.WriteLine(ex.Message)
      End Try
      Return bm

   End Function

#End Region

End Class
