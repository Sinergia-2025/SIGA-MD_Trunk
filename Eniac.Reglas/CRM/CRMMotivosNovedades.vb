Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class CRMMotivosNovedades
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMMotivoNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMotivoNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMMotivoNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMotivoNovedadJSon)

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CRMMotivoNovedad.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMMotivoNovedad)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMMotivoNovedad)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMMotivoNovedad)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.CRMMotivosNovedades(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMMotivosNovedades(da).CRMMotivosNovedades_GA()
   End Function

   Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad) As DataTable
      If TipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(TipoNovedad.IdTipoNovedad, False)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As DataTable
      Return New SqlServer.CRMMotivosNovedades(da).CRMMotivosNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMMotivoNovedad, tipo As TipoSP)
      Dim sqlC As SqlServer.CRMMotivosNovedades = New SqlServer.CRMMotivosNovedades(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CRMMotivosNovedades_I(en.IdMotivoNovedad, en.NombreMotivoNovedad, en.Posicion, en.IdTipoNovedad)
         Case TipoSP._U
            sqlC.CRMMotivosNovedades_U(en.IdMotivoNovedad, en.NombreMotivoNovedad, en.Posicion, en.IdTipoNovedad)
         Case TipoSP._D
            sqlC.CRMMotivosNovedades_D(en.IdMotivoNovedad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMMotivoNovedad, dr As DataRow)
      With o
         .IdMotivoNovedad = dr.Field(Of Integer)(Entidades.CRMMotivoNovedad.Columnas.IdMotivoNovedad.ToString())
         .NombreMotivoNovedad = dr.Field(Of String)(Entidades.CRMMotivoNovedad.Columnas.NombreMotivoNovedad.ToString())
         .Posicion = dr.Field(Of Integer)(Entidades.CRMMotivoNovedad.Columnas.Posicion.ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMMotivoNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CRMMotivoNovedad)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.CRMMotivoNovedad)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.CRMMotivoNovedad)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idMotivoNovedad As Integer) As Entidades.CRMMotivoNovedad
      Return GetUno(idMotivoNovedad, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idMotivoNovedad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CRMMotivoNovedad
      Return CargaEntidad(New SqlServer.CRMMotivosNovedades(da).CRMMotivosNovedades_G1(idMotivoNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMMotivoNovedad(),
                          accion, Function() String.Format("No existe un estado de novedad con id '{0}'", idMotivoNovedad))
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMMotivoNovedad)
      Return CargaLista(Me.GetAll(idTipoNovedad, ordenarPosicion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMMotivoNovedad), dr),
                        Function() New Entidades.CRMMotivoNovedad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMMotivosNovedades(da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMMotivosNovedades(da).
                                       GetCodigoMaximo(Entidades.CRMMotivoNovedad.Columnas.Posicion.ToString(),
                                                       "CRMMotivosNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMMotivoNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function
#End Region
End Class