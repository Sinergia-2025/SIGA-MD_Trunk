#Region "Option"
Option Strict On
Option Explicit On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region
Public Class CRMTiposComentariosNovedades
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMTipoComentarioNovedadJSon)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMTipoComentarioNovedad.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CRMTipoComentarioNovedad)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CRMTipoComentarioNovedad)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CRMTipoComentarioNovedad)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMTiposComentariosNovedades = New SqlServer.CRMTiposComentariosNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMTiposComentariosNovedades(Me.da).CRMTiposComentariosNovedades_GA()
   End Function

   Public Overloads Function GetAll(tipoNovedad As Entidades.CRMTipoNovedad) As System.Data.DataTable
      If tipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(tipoNovedad.IdTipoNovedad, False)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.CRMTiposComentariosNovedades(Me.da).CRMTiposComentariosNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMTipoComentarioNovedad, tipo As TipoSP)
      Dim sqlC As SqlServer.CRMTiposComentariosNovedades = New SqlServer.CRMTiposComentariosNovedades(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CRMTiposComentariosNovedades_I(en.IdTipoComentarioNovedad, en.NombreTipoComentarioNovedad,
                                                en.Posicion, en.IdTipoNovedad,
                                                en.PorDefecto, en.Color,
                                                en.VisibleParaCliente, en.VisibleParaRepresentante)
         Case TipoSP._U
            sqlC.CRMTiposComentariosNovedades_U(en.IdTipoComentarioNovedad, en.NombreTipoComentarioNovedad,
                                                en.Posicion, en.IdTipoNovedad,
                                                en.PorDefecto, en.Color,
                                                en.VisibleParaCliente, en.VisibleParaRepresentante)
         Case TipoSP._D
            sqlC.CRMTiposComentariosNovedades_D(en.IdTipoComentarioNovedad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CRMTipoComentarioNovedad, dr As DataRow)
      With o
         .IdTipoComentarioNovedad = dr.Field(Of Integer)(Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString())
         .NombreTipoComentarioNovedad = dr.Field(Of String)(Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString())
         .Posicion = dr.Field(Of Integer)(Entidades.CRMTipoComentarioNovedad.Columnas.Posicion.ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.CRMTipoComentarioNovedad.Columnas.PorDefecto.ToString())
         .Color = dr.Field(Of Integer?)(Entidades.CRMTipoComentarioNovedad.Columnas.Color.ToString())
         .VisibleParaCliente = dr.Field(Of Boolean)(Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaCliente.ToString())
         .VisibleParaRepresentante = dr.Field(Of Boolean)(Entidades.CRMTipoComentarioNovedad.Columnas.VisibleParaRepresentante.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CRMTipoComentarioNovedad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.CRMTipoComentarioNovedad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.CRMTipoComentarioNovedad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idTipoComentarioNovedad As Integer) As Entidades.CRMTipoComentarioNovedad
      Return GetUno(idTipoComentarioNovedad, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoComentarioNovedad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CRMTipoComentarioNovedad
      Return CargaEntidad(New SqlServer.CRMTiposComentariosNovedades(Me.da).CRMTiposComentariosNovedades_G1(idTipoComentarioNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoComentarioNovedad(),
                          accion, Function() String.Format("No existe Tipo de Comentario con Id: {0}", idTipoComentarioNovedad))
   End Function

   Public Function GetPorDefecto(idTipoNovedad As String) As Entidades.CRMTipoComentarioNovedad
      Return GetPorDefecto(idTipoNovedad, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetPorDefecto(idTipoNovedad As String, accion As AccionesSiNoExisteRegistro) As Entidades.CRMTipoComentarioNovedad
      Return CargaEntidad(New SqlServer.CRMTiposComentariosNovedades(Me.da).CRMTiposComentariosNovedades_G_Default(idTipoNovedad),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoComentarioNovedad(),
                          accion, Function() String.Format("No existe Tipo de Comentario Por Defecto con Tipo Novedad: {0}", idTipoNovedad))
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMTipoComentarioNovedad)
      Return CargaLista(Me.GetAll(idTipoNovedad, ordenarPosicion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMTipoComentarioNovedad), dr),
                        Function() New Entidades.CRMTipoComentarioNovedad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMTiposComentariosNovedades(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return New SqlServer.CRMTiposComentariosNovedades(Me.da).GetPosicionMaxima(idTipoNovedad)
   End Function

#End Region
End Class