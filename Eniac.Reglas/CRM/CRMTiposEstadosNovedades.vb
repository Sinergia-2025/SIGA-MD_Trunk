Option Explicit On
Option Strict On
Public Class CRMTiposEstadosNovedades
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.CRMTipoEstadoNovedad.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMTipoEstadoNovedad.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoEstadoNovedad), TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoEstadoNovedad), TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoEstadoNovedad), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoEstadoNovedad), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoEstadoNovedad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoEstadoNovedad), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMTiposEstadosNovedades = New SqlServer.CRMTiposEstadosNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMTiposEstadosNovedades(Me.da).CRMTiposEstadosNovedades_GA()
   End Function


   Public Overrides Function GetAll(idTipoNovedad As String) As System.Data.DataTable
      Dim sCRMTiposEstadosNovedades As SqlServer.CRMTiposEstadosNovedades = New SqlServer.CRMTiposEstadosNovedades(da)
      Return sCRMTiposEstadosNovedades.CRMTiposEstadosNovedades_GA(idTipoNovedad)
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idTipoEstadoNovedad As Integer) As Entidades.CRMTipoEstadoNovedad
      Dim sCRMTiposEstadosNovedades As SqlServer.CRMTiposEstadosNovedades = New SqlServer.CRMTiposEstadosNovedades(da)
      Return CargaEntidad(sCRMTiposEstadosNovedades.CRMTiposEstadosNovedades_G1(idTipoEstadoNovedad),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoEstadoNovedad(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el tipo de Estado con número: {0}", idTipoEstadoNovedad))
   End Function

   Public Function GetTodos() As List(Of Entidades.CRMTipoEstadoNovedad)
      Return Me.GetTodos(idTipoNovedad:=Nothing)
   End Function

   '# Get Todos x IdTipoNovedad
   Public Function GetTodos(idTipoNovedad As String) As List(Of Entidades.CRMTipoEstadoNovedad)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad)
      Dim eCRMTipoEstadoNovedad As Entidades.CRMTipoEstadoNovedad
      Dim lista As List(Of Entidades.CRMTipoEstadoNovedad) = New List(Of Entidades.CRMTipoEstadoNovedad)
      For Each dr As DataRow In dt.Rows
         eCRMTipoEstadoNovedad = New Entidades.CRMTipoEstadoNovedad()
         Me.CargarUno(eCRMTipoEstadoNovedad, dr)
         lista.Add(eCRMTipoEstadoNovedad)
      Next
      Return lista
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMTiposEstadosNovedades(da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMTiposEstadosNovedades(Me.da).
                                       GetCodigoMaximo(Entidades.CRMTipoEstadoNovedad.Columnas.Posicion.ToString(),
                                                       "CRMTiposEstadosNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMTipoEstadoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMTipoEstadoNovedad, tipo As TipoSP)
      Dim sCRMTiposEstadosNovedades As SqlServer.CRMTiposEstadosNovedades = New SqlServer.CRMTiposEstadosNovedades(da)
      Select Case tipo
         Case TipoSP._I
            sCRMTiposEstadosNovedades.CRMTiposEstadosNovedades_I(en.IdTipoEstadoNovedad, en.NombreTipoEstadoNovedad, en.Posicion, en.IdTipoNovedad)
         Case TipoSP._U
            sCRMTiposEstadosNovedades.CRMTiposEstadosNovedades_U(en.IdTipoEstadoNovedad, en.NombreTipoEstadoNovedad, en.Posicion, en.IdTipoNovedad)
         Case TipoSP._D
            sCRMTiposEstadosNovedades.CRMTiposEstadosNovedades_D(en.IdTipoEstadoNovedad)
      End Select
   End Sub

   Private Sub CargarUno(eCRMTipoEstadoNovedad As Entidades.CRMTipoEstadoNovedad, dr As DataRow)
      With eCRMTipoEstadoNovedad
         .IdTipoEstadoNovedad = dr.Field(Of Integer)(Entidades.CRMTipoEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString())
         .NombreTipoEstadoNovedad = dr.Field(Of String)(Entidades.CRMTipoEstadoNovedad.Columnas.NombreTipoEstadoNovedad.ToString())
         .Posicion = dr.Field(Of Integer)(Entidades.CRMTipoEstadoNovedad.Columnas.Posicion.ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMTipoEstadoNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
      End With
   End Sub

#End Region

End Class
