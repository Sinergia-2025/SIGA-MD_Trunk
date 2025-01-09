Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class CRMEstadosNovedades
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMEstadoNovedadJSon)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMEstadosNovedades"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMEstadoNovedad)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMEstadoNovedad)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMEstadoNovedad)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMEstadosNovedades = New SqlServer.CRMEstadosNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMEstadosNovedades(Me.da).CRMEstadosNovedades_GA()
   End Function

   Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad) As System.Data.DataTable
      If TipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(TipoNovedad.IdTipoNovedad, False)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.CRMEstadosNovedades(Me.da).CRMEstadosNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMEstadoNovedad, tipo As TipoSP)
      Dim sqlC As SqlServer.CRMEstadosNovedades = New SqlServer.CRMEstadosNovedades(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CRMEstadosNovedades_I(en.IdEstadoNovedad, en.NombreEstadoNovedad, en.Posicion, en.SolicitaUsuario,
                                       en.Finalizado, en.IdTipoNovedad, en.PorDefecto, en.Color,
                                       en.DiasProximoContacto, en.ActualizaUsuarioResponsable, en.SolicitaProveedorService,
                                       en.Imprime, en.Reporte, en.Embebido, en.AcumulaContador1, en.AcumulaContador2, en.EsFacturable, en.CantidadCopias, en.IdTipoEstadoNovedad,
                                       en.Entregado, en.IdEstadoFacturado, en.AvanceEstadoFacturado, en.ControlaStockConsumido, en.RequiereComentarios)
         Case TipoSP._U
            sqlC.CRMEstadosNovedades_U(en.IdEstadoNovedad, en.NombreEstadoNovedad, en.Posicion, en.SolicitaUsuario,
                                       en.Finalizado, en.IdTipoNovedad, en.PorDefecto, en.Color,
                                       en.DiasProximoContacto, en.ActualizaUsuarioResponsable, en.SolicitaProveedorService,
                                       en.Imprime, en.Reporte, en.Embebido, en.AcumulaContador1, en.AcumulaContador2, en.EsFacturable, en.CantidadCopias, en.IdTipoEstadoNovedad,
                                       en.Entregado, en.IdEstadoFacturado, en.AvanceEstadoFacturado, en.ControlaStockConsumido, en.RequiereComentarios)
         Case TipoSP._D
            sqlC.CRMEstadosNovedades_D(en.IdEstadoNovedad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMEstadoNovedad, dr As DataRow)
      With o
         .IdEstadoNovedad = dr.Field(Of Integer)(Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString())
         .NombreEstadoNovedad = dr.Field(Of String)(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString())
         .Posicion = dr.Field(Of Integer)(Entidades.CRMEstadoNovedad.Columnas.Posicion.ToString())
         .SolicitaUsuario = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.SolicitaUsuario.ToString())
         .Finalizado = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.Finalizado.ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMEstadoNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.PorDefecto.ToString())
         .Color = dr.Field(Of Integer?)(Entidades.CRMEstadoNovedad.Columnas.Color.ToString())
         .DiasProximoContacto = dr.Field(Of Integer?)(Entidades.CRMEstadoNovedad.Columnas.DiasProximoContacto.ToString())
         .ActualizaUsuarioResponsable = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.ActualizaUsuarioResponsable.ToString())
         .SolicitaProveedorService = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.SolicitaProveedorService.ToString())
         .Imprime = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.Imprime.ToString())
         .Reporte = dr.Field(Of String)(Entidades.CRMEstadoNovedad.Columnas.Reporte.ToString())
         .Embebido = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.Embebido.ToString())
         .AcumulaContador1 = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.AcumulaContador1.ToString())
         .AcumulaContador2 = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.AcumulaContador2.ToString())
         .EsFacturable = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.EsFacturable.ToString())
         .CantidadCopias = dr.Field(Of Integer)(Entidades.CRMEstadoNovedad.Columnas.CantidadCopias.ToString())
         .IdTipoEstadoNovedad = dr.Field(Of Integer)(Entidades.CRMEstadoNovedad.Columnas.IdTipoEstadoNovedad.ToString())
         .NombreTipoEstadoNovedad = dr.Field(Of String)("NombreTipoEstadoNovedad")
         .Entregado = dr.Field(Of String)(Entidades.CRMEstadoNovedad.Columnas.Entregado.ToString()).StringToEnum(Entidades.CRMEstadoNovedad.EntregadoValores.NoAfecta)
         .IdEstadoFacturado = dr.Field(Of Integer?)(Entidades.CRMEstadoNovedad.Columnas.IdEstadoFacturado.ToString())
         .NombreEstadoNovedadFacturado = dr.Field(Of String)("EstadoFacturado")
         .AvanceEstadoFacturado = dr.Field(Of Decimal?)(Entidades.CRMEstadoNovedad.Columnas.AvanceEstadoFacturado.ToString())
         .ControlaStockConsumido = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.ControlaStockConsumido.ToString())
         .RequiereComentarios = dr.Field(Of Boolean)(Entidades.CRMEstadoNovedad.Columnas.RequiereComentarios.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CRMEstadoNovedad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.CRMEstadoNovedad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.CRMEstadoNovedad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idEstadoNovedad As Integer) As Entidades.CRMEstadoNovedad
      Return GetUno(idEstadoNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idEstadoNovedad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CRMEstadoNovedad
      Return CargaEntidad(New SqlServer.CRMEstadosNovedades(Me.da).CRMEstadosNovedades_G1(idEstadoNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMEstadoNovedad(),
                          accion, Function() String.Format("No existe un estado de novedad con id '{0}'", idEstadoNovedad))
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMEstadoNovedad)
      Return CargaLista(Me.GetAll(idTipoNovedad, ordenarPosicion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMEstadoNovedad), dr),
                        Function() New Entidades.CRMEstadoNovedad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMEstadosNovedades(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMEstadosNovedades(Me.da).
                                       GetCodigoMaximo(Entidades.CRMEstadoNovedad.Columnas.Posicion.ToString(),
                                                       "CRMEstadosNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMEstadoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function
   Public Function GetPorCodigo(codigo As Integer, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMEstadosNovedades(da).CRMEstadosNovedades_GxCodigo(codigo, idTipoNovedad)
   End Function

   Public Function GetPorNombre(nombre As String, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMEstadosNovedades(da).CRMEstadosNovedades_PorNombre(nombre, nombreExacto:=False, idTipoNovedad)
   End Function
#End Region
End Class