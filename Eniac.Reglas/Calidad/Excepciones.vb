Option Explicit On
Option Strict On
Public Class Excepciones
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.Excepcion.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Excepcion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.Excepcion), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.Excepcion), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.Excepcion), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Excepcion), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Excepcion), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Excepcion), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.Excepciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Excepciones(da).GetCodigoMaximo() + 1
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sExcepciones As SqlServer.Excepciones = New SqlServer.Excepciones(da)
      Return sExcepciones.Excepciones_GA()
   End Function


#End Region

#Region "Métodos Públicos"

   Public Function GetUno(IdExcepcion As Integer) As Entidades.Excepcion
      Dim sExcepciones As SqlServer.Excepciones = New SqlServer.Excepciones(da)
      Return CargaEntidad(sExcepciones.Excepciones_G1(IdExcepcion),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Excepcion(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe la Excepción {0}", IdExcepcion))
   End Function

   Public Function GetTodos() As List(Of Entidades.Excepcion)
      Dim dt As DataTable = Me.GetAll()
      Dim eExcepcion As Entidades.Excepcion
      Dim lista As List(Of Entidades.Excepcion) = New List(Of Entidades.Excepcion)
      For Each dr As DataRow In dt.Rows
         eExcepcion = New Entidades.Excepcion()
         Me.CargarUno(eExcepcion, dr)
         lista.Add(eExcepcion)
      Next
      Return lista
   End Function

   Public Function GetExcepciones(IdListaControlTipo As Integer, IdExcepcionTipo As Integer) As System.Data.DataTable
      Dim sExcepciones As SqlServer.Excepciones = New SqlServer.Excepciones(da)
      Return sExcepciones.Excepciones_GExcepciones(IdListaControlTipo, IdExcepcionTipo)
   End Function

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.Excepcion, tipo As TipoSP)
      Dim sExcepciones As SqlServer.Excepciones = New SqlServer.Excepciones(da)
      Select Case tipo
         Case TipoSP._I
            sExcepciones.Excepciones_I(en.IdExcepcion, en.IdListaControlTipo,
                                       en.IdExcepcionTipo, en.Motivo,
                                       en.FechaExcepcion, en.IdUsuario, en.AccionesCorrectivas, en.Item,
                                       en.IdUsuario1, en.IdUsuario2, en.IdUsuario3, en.FechaUsuario1,
                                       en.FechaUsuario2, en.FechaUsuario3, en.Dpto)
         Case TipoSP._U
            sExcepciones.Excepciones_U(en.IdExcepcion, en.IdListaControlTipo,
                                       en.IdExcepcionTipo, en.Motivo,
                                       en.FechaExcepcion, en.IdUsuario, en.AccionesCorrectivas, en.Item,
                                       en.IdUsuario1, en.IdUsuario2, en.IdUsuario3, en.FechaUsuario1,
                                       en.FechaUsuario2, en.FechaUsuario3, en.Dpto)
         Case TipoSP._D
            sExcepciones.Excepciones_D(en.IdExcepcion)
      End Select
   End Sub

   Private Sub CargarUno(eExcepcion As Entidades.Excepcion, dr As DataRow)
      With eExcepcion
         .IdExcepcion = dr.Field(Of Integer)(Entidades.Excepcion.Columnas.IdExcepcion.ToString())
         .IdListaControlTipo = dr.Field(Of Integer)(Entidades.Excepcion.Columnas.IdListaControlTipo.ToString())
         .IdExcepcionTipo = dr.Field(Of Integer)(Entidades.Excepcion.Columnas.IdExcepcionTipo.ToString())
         .Motivo = dr.Field(Of String)(Entidades.Excepcion.Columnas.Motivo.ToString())
         .FechaExcepcion = dr.Field(Of Date)(Entidades.Excepcion.Columnas.FechaExcepcion.ToString())
         .IdUsuario = dr.Field(Of String)(Entidades.Excepcion.Columnas.IdUsuario.ToString())
         .AccionesCorrectivas = dr.Field(Of String)(Entidades.Excepcion.Columnas.AccionesCorrectivas.ToString())
         .Item = dr.Field(Of String)(Entidades.Excepcion.Columnas.Item.ToString())
         .IdUsuario1 = dr.Field(Of String)(Entidades.Excepcion.Columnas.IdUsuario1.ToString())
         .IdUsuario2 = dr.Field(Of String)(Entidades.Excepcion.Columnas.IdUsuario2.ToString())
         .IdUsuario3 = dr.Field(Of String)(Entidades.Excepcion.Columnas.IdUsuario3.ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Excepcion.Columnas.FechaUsuario1.ToString()).ToString()) Then
            .FechaUsuario1 = dr.Field(Of Date)(Entidades.Excepcion.Columnas.FechaUsuario1.ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Excepcion.Columnas.FechaUsuario2.ToString()).ToString()) Then
            .FechaUsuario2 = dr.Field(Of Date)(Entidades.Excepcion.Columnas.FechaUsuario2.ToString())
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Excepcion.Columnas.FechaUsuario3.ToString()).ToString()) Then
            .FechaUsuario3 = dr.Field(Of Date)(Entidades.Excepcion.Columnas.FechaUsuario3.ToString())
         End If
         .Dpto = dr.Field(Of String)(Entidades.Excepcion.Columnas.Dpto.ToString())
      End With
   End Sub

#End Region

End Class
