Public Class TurismoTiposViajes
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.TurismoTipoViaje.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TurismoTipoViaje), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TurismoTipoViaje), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TurismoTipoViaje), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.TurismoTiposViajes(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.TurismoTiposViajes(da).TurismoTiposViajes_GA()
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.TurismoTiposViajes(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TurismoTipoViaje, tipo As TipoSP)
      Dim sqlC = New SqlServer.TurismoTiposViajes(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TurismoTiposViajes_I(en.IdTipoViaje, en.DescripcionTipoViaje, en.CantidadDiasUltimaCuota, en.IdInteres)
         Case TipoSP._U
            sqlC.TurismoTiposViajes_U(en.IdTipoViaje, en.DescripcionTipoViaje, en.CantidadDiasUltimaCuota, en.IdInteres)
         Case TipoSP._D
            sqlC.TurismoTiposViajes_D(en.IdTipoViaje)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TurismoTipoViaje, dr As DataRow)
      With o
         .IdTipoViaje = dr.Field(Of Integer)(Entidades.TurismoTipoViaje.Columnas.IdTipoViaje.ToString())
         .DescripcionTipoViaje = dr.Field(Of String)(Entidades.TurismoTipoViaje.Columnas.DescripcionTipoViaje.ToString())
         .CantidadDiasUltimaCuota = dr.Field(Of Integer)(Entidades.TurismoTipoViaje.Columnas.CantidadDiasUltimaCuota.ToString())
         .IdInteres = dr.Field(Of Integer?)(Entidades.TurismoTipoViaje.Columnas.IdInteres.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTurismoTipoViaje As Integer) As Entidades.TurismoTipoViaje
      Return GetUno(idTurismoTipoViaje, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTurismoTipoViaje As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TurismoTipoViaje
      Return CargaEntidad(New SqlServer.TurismoTiposViajes(da).TurismoTiposViajes_G1(idTurismoTipoViaje),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TurismoTipoViaje(),
                          accion, String.Format("No existe Tipo de Viaje con ID {0}", idTurismoTipoViaje))
   End Function
   Public Function GetTodos() As List(Of Entidades.TurismoTipoViaje)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TurismoTipoViaje())
   End Function

#End Region

End Class