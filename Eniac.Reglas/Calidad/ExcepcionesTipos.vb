Option Explicit On
Option Strict On
Public Class ExcepcionesTipos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ExcepcionTipo.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ExcepcionTipo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ExcepcionTipo), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ExcepcionTipo), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ExcepcionTipo), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ExcepcionTipo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ExcepcionTipo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ExcepcionTipo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ExcepcionesTipos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ExcepcionesTipos(da).GetCodigoMaximo() + 1
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sExcepcionesTipos As SqlServer.ExcepcionesTipos = New SqlServer.ExcepcionesTipos(da)
      Return sExcepcionesTipos.ExcepcionesTipos_GA()
   End Function


#End Region

#Region "Métodos Públicos"

   Public Function GetUno(IdExcepcionTipo As Integer) As Entidades.ExcepcionTipo
      Dim sExcepcionesTipos As SqlServer.ExcepcionesTipos = New SqlServer.ExcepcionesTipos(da)
      Return CargaEntidad(sExcepcionesTipos.ExcepcionesTipos_G1(IdExcepcionTipo),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ExcepcionTipo(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Excepción {0}", IdExcepcionTipo))
   End Function

   Public Function GetTodos() As List(Of Entidades.ExcepcionTipo)
      Dim dt As DataTable = Me.GetAll()
      Dim eExcepcionTipo As Entidades.ExcepcionTipo
      Dim lista As List(Of Entidades.ExcepcionTipo) = New List(Of Entidades.ExcepcionTipo)
      For Each dr As DataRow In dt.Rows
         eExcepcionTipo = New Entidades.ExcepcionTipo()
         Me.CargarUno(eExcepcionTipo, dr)
         lista.Add(eExcepcionTipo)
      Next
      Return lista
   End Function


#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ExcepcionTipo, tipo As TipoSP)
      Dim sExcepcionesTipos As SqlServer.ExcepcionesTipos = New SqlServer.ExcepcionesTipos(da)
      Select Case tipo
         Case TipoSP._I
            sExcepcionesTipos.ExcepcionesTipos_I(en.IdExcepcionTipo,
                                                               en.NombreExcepcionTipo)
         Case TipoSP._U
            sExcepcionesTipos.ExcepcionesTipos_U(en.IdExcepcionTipo,
                                                               en.NombreExcepcionTipo)
         Case TipoSP._D
            sExcepcionesTipos.ExcepcionesTipos_D(en.IdExcepcionTipo)
      End Select
   End Sub

   Private Sub CargarUno(eExcepcionTipo As Entidades.ExcepcionTipo, dr As DataRow)
      With eExcepcionTipo
         .IdExcepcionTipo = dr.Field(Of Integer)(Entidades.ExcepcionTipo.Columnas.IdExcepcionTipo.ToString())
         .NombreExcepcionTipo = dr.Field(Of String)(Entidades.ExcepcionTipo.Columnas.NombreExcepcionTipo.ToString())
      End With
   End Sub

#End Region

End Class
