Public Class ContabilidadEstadosAsientos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ContabilidadEstadoAsiento.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ContabilidadEstadoAsiento), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ContabilidadEstadoAsiento), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.ContabilidadEstadoAsiento), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ContabilidadEstadosAsientos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ContabilidadEstadosAsientos(da).ContabilidadEstadosAsientos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ContabilidadEstadoAsiento, tipo As TipoSP)
      Dim sqlC = New SqlServer.ContabilidadEstadosAsientos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.ContabilidadEstadosAsientos_I(en.IdEstadoAsiento, en.NombreEstadoAsiento, en.PorDefectoManual, en.PorDefectoAutomatico)
         Case TipoSP._U
            sqlC.ContabilidadEstadosAsientos_U(en.IdEstadoAsiento, en.NombreEstadoAsiento, en.PorDefectoManual, en.PorDefectoAutomatico)
         Case TipoSP._D
            sqlC.ContabilidadEstadosAsientos_D(en.IdEstadoAsiento)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ContabilidadEstadoAsiento, dr As DataRow)
      With o
         .IdEstadoAsiento = dr.Field(Of Integer)(Entidades.ContabilidadEstadoAsiento.Columnas.IdEstadoAsiento.ToString())
         .NombreEstadoAsiento = dr.Field(Of String)(Entidades.ContabilidadEstadoAsiento.Columnas.NombreEstadoAsiento.ToString())
         .PorDefectoManual = dr.Field(Of Boolean)(Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoManual.ToString())
         .PorDefectoAutomatico = dr.Field(Of Boolean)(Entidades.ContabilidadEstadoAsiento.Columnas.PorDefectoAutomatico.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUnoPorDefectoAutomatico() As Entidades.ContabilidadEstadoAsiento
      Return CargaEntidad(New SqlServer.ContabilidadEstadosAsientos(da).ContabilidadEstadosAsientos_G1_PorDefectoAutomatico(),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ContabilidadEstadoAsiento(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe Estado de Asiendo definida Por Defecto Automático"))
   End Function
   Public Function GetUnoPorDefectoManual() As Entidades.ContabilidadEstadoAsiento
      Return CargaEntidad(New SqlServer.ContabilidadEstadosAsientos(da).ContabilidadEstadosAsientos_G1_PorDefectoManual(),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ContabilidadEstadoAsiento(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe Estado de Asiendo definida Por Defecto Manual"))
   End Function

   Public Function GetUno(idEstadoAsiento As Integer) As Entidades.ContabilidadEstadoAsiento
      Return GetUno(idEstadoAsiento, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoAsiento As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ContabilidadEstadoAsiento
      Return CargaEntidad(Get1(idEstadoAsiento), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ContabilidadEstadoAsiento(),
                          accion, Function() String.Format("No existe Estado de Asiendo con código {0}", idEstadoAsiento))
   End Function
   Public Function GetTodos() As List(Of Entidades.ContabilidadEstadoAsiento)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ContabilidadEstadoAsiento())
   End Function

   Public Function Get1(idEstadoAsiento As Integer) As DataTable
      Return New SqlServer.ContabilidadEstadosAsientos(da).ContabilidadEstadosAsientos_G1(idEstadoAsiento)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ContabilidadEstadosAsientos(da).GetCodigoMaximo()
   End Function

#End Region

End Class