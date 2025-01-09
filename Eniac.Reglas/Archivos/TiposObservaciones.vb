#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class TiposObservaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoObservacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoObservacion), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoObservacion), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.TipoObservacion), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.TiposObservaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposObservaciones(Me.da).TiposObservaciones_GA(False)
   End Function

   Public Function GetActivas() As System.Data.DataTable
      Return New SqlServer.TiposObservaciones(Me.da).TiposObservaciones_GA(True)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.TipoObservacion, tipo As TipoSP)
      Dim sqlC = New SqlServer.TiposObservaciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TiposObservaciones_I(en.IdObservaciones, en.Descripcion, en.Activa, en.PorDefecto)
         Case TipoSP._U
            sqlC.TiposObservaciones_U(en.IdObservaciones, en.Descripcion, en.Activa, en.PorDefecto)
         Case TipoSP._D
            sqlC.TiposObservaciones_D(en.IdObservaciones)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.TipoObservacion, dr As DataRow)
      With o
         .IdObservaciones = dr.Field(Of Short)(Entidades.TipoObservacion.Columnas.IdObservaciones.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.TipoObservacion.Columnas.Descripcion.ToString())
         .Activa = dr.Field(Of Boolean)(Entidades.TipoObservacion.Columnas.Activa.ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.TipoObservacion.Columnas.PorDefecto.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idObservacion As Short) As Entidades.TipoObservacion
      Return GetUno(idObservacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idObservacion As Short, accion As AccionesSiNoExisteRegistro) As Entidades.TipoObservacion
      Return CargaEntidad(New SqlServer.TiposObservaciones(da).TiposObservaciones_G1(idObservacion),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoObservacion(),
                          accion, Function() String.Format("No existe Tipo de Observacion con Id: {0}", idObservacion))
   End Function
   Public Function GetTodos() As List(Of Entidades.TipoObservacion)
      Return CargaLista(New SqlServer.TiposObservaciones(Me.da).TiposObservaciones_GA(True),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.TipoObservacion())
   End Function
   Public Function GetCodigoMaximo() As Short
      Return New SqlServer.TiposObservaciones(Me.da).GetCodigoMaximo()
   End Function
   Public Function GetFiltradoPorCodigo(codigo As Short) As DataTable
      Return New SqlServer.TiposObservaciones(da).GetFiltradoPorCodigo(codigo)
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String) As DataTable
      Return New SqlServer.TiposObservaciones(da).GetFiltradoPorDescripcion(descripcion)
   End Function
   Public Function GetIdTipoObservacionDefecto() As Short
      Return New SqlServer.TiposObservaciones(Me.da).GetIdTipoObservacionDefecto()
   End Function

#End Region

End Class
