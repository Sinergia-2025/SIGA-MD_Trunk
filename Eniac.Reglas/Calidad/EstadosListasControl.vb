#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class EstadosListasControl
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CalidadEstadosListasControl"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CalidadEstadosListasControl"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.EstadosListasControl = New SqlServer.EstadosListasControl(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_GA()
   End Function

   'Public Overloads Function GetAll() As System.Data.DataTable
   '   Return GetAll(False)
   'End Function
   Public Overloads Function GetAll(ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_GA(ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.EstadoListaControl = DirectCast(entidad, Entidades.EstadoListaControl)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.EstadosListasControl = New SqlServer.EstadosListasControl(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.CalidadEstadosListasControl_I(en.IdEstadoCalidad, en.NombreEstadoCalidad, en.Posicion,
                                           en.Finalizado, en.PorDefecto, en.Color)
            Case TipoSP._U
               sqlC.CalidadEstadosListasControl_U(en.IdEstadoCalidad, en.NombreEstadoCalidad, en.Posicion,
                                           en.Finalizado, en.PorDefecto, en.Color)
            Case TipoSP._D
               sqlC.CalidadEstadosListasControl_D(en.IdEstadoCalidad)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoListaControl, ByVal dr As DataRow)
      With o
         .IdEstadoCalidad = Integer.Parse(dr(Entidades.EstadoListaControl.Columnas.IdEstadoCalidad.ToString()).ToString())
         .NombreEstadoCalidad = dr(Entidades.EstadoListaControl.Columnas.NombreEstadoCalidad.ToString()).ToString()
         .Posicion = Integer.Parse(dr(Entidades.EstadoListaControl.Columnas.Posicion.ToString()).ToString())
         .Finalizado = CBool(dr(Entidades.EstadoListaControl.Columnas.Finalizado.ToString()).ToString())
         .PorDefecto = CBool(dr(Entidades.EstadoListaControl.Columnas.PorDefecto.ToString()).ToString())
         If IsNumeric(dr(Entidades.EstadoListaControl.Columnas.Color.ToString())) Then
            .Color = Integer.Parse(dr(Entidades.EstadoListaControl.Columnas.Color.ToString()).ToString())
         Else
            .Color = Nothing
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idEstadoCalidad As Integer) As Entidades.EstadoListaControl
      Dim dt As DataTable = New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_G1(idEstadoCalidad)
      Dim o As Entidades.EstadoListaControl = New Entidades.EstadoListaControl()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(Optional ordenarPosicion As Boolean = False) As List(Of Entidades.EstadoListaControl)
      Return CargaLista(Me.GetAll(ordenarPosicion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.EstadoListaControl), dr),
                        Function() New Entidades.EstadoListaControl())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.EstadosListasControl(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetEstadoPorDefecto() As Integer
      Return New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_GxDefecto()
   End Function

   Public Function GetEstadoColorPorNombre(nombre As String) As Integer
      Return New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_GxNombre(nombre)
   End Function
   Public Function GetEstadoColorPorId(Id As Integer) As Integer
      Return New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_GxId(Id)
   End Function
   Public Function GetEstadoFinalizado() As DataTable
      Return New SqlServer.EstadosListasControl(Me.da).CalidadEstadosListasControl_GFinalizado()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.EstadosListasControl(Me.da).
                                       GetCodigoMaximo(Entidades.EstadoListaControl.Columnas.Posicion.ToString(),
                                                       "CalidadEstadosListasControl"))
   End Function

#End Region

End Class