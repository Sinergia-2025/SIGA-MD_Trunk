Public Class CalidadOrdenDeControlItems
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CalidadOrdenDeControlItem.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CalidadOrdenDeControlItem)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CalidadOrdenDeControlItem)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CalidadOrdenDeControlItem)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().CalidadOrdenDeControlItems_GA()
   End Function

#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CalidadOrdenDeControlItems
      Return New SqlServer.CalidadOrdenDeControlItems(da)
   End Function
   Private Sub ValidaGrabacion(en As Entidades.CalidadOrdenDeControlItem, tipo As TipoSP)
      If {TipoSP._I, TipoSP._U, TipoSP._M}.Contains(tipo) Then
         If en.IdMRPAQLA = 0 Then
            Throw New Exception(String.Format("El item {0} no tiene AQL definido", en.NombreListaControlItem))
         End If
      End If
   End Sub
   Private Sub EjecutaSP(en As Entidades.CalidadOrdenDeControlItem, tipo As TipoSP)
      Dim sql = GetSql()
      ValidaGrabacion(en, tipo)
      Select Case tipo
         Case TipoSP._I
            sql.CalidadOrdenDeControlItems_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                             en.IdListaControl, en.IdListaControlItem, en.NivelInspeccion, en.ValorAQL,
                                             en.IdMRPAQLA, en.CodigoNivel, en.TamanoMuestreo, en.CantidadAceptacion, en.CantidadRechazo)
         Case TipoSP._U
            sql.CalidadOrdenDeControlItems_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                             en.IdListaControl, en.IdListaControlItem, en.NivelInspeccion, en.ValorAQL,
                                             en.IdMRPAQLA, en.CodigoNivel, en.TamanoMuestreo, en.CantidadAceptacion, en.CantidadRechazo)

         Case TipoSP._D
            sql.CalidadOrdenDeControlItems_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                             en.IdListaControl, en.IdListaControlItem)
      End Select
   End Sub

   Private Function GetCodigoNivel(AQLA As Entidades.MRPAQLA, nivel As Entidades.NivelInspeccionMRP) As String
      Select Case nivel
         Case Entidades.NivelInspeccionMRP.I
            Return AQLA.NivelGeneral1
         Case Entidades.NivelInspeccionMRP.II
            Return AQLA.NivelGeneral2
         Case Entidades.NivelInspeccionMRP.III
            Return AQLA.NivelGeneral3
         Case Entidades.NivelInspeccionMRP.SI
            Return AQLA.NivelEspecialS1
         Case Entidades.NivelInspeccionMRP.S2
            Return AQLA.NivelEspecialS2
         Case Entidades.NivelInspeccionMRP.S3
            Return AQLA.NivelEspecialS3
         Case Entidades.NivelInspeccionMRP.S4
            Return AQLA.NivelEspecialS4
         Case Else
            Throw New Exception(String.Format("No existe nivel de inspección: {0}", nivel.ToString()))
      End Select
   End Function
   Private Sub CargarUno(o As Entidades.CalidadOrdenDeControlItem, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CalidadOrdenDeControlItem.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CalidadOrdenDeControlItem.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CalidadOrdenDeControlItem.Columnas.NumeroComprobante.ToString())
         .IdListaControl = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControl.ToString())
         .NombreListaControl = dr.Field(Of String)("NombreListaControl")
         .IdListaControlItem = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.IdListaControlItem.ToString())
         .NombreListaControlItem = dr.Field(Of String)("NombreListaControlItem")
         .NivelInspeccion = dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.NivelInspeccion.ToString()).StringToEnum(Entidades.NivelInspeccionMRP.I)
         .ValorAQL = dr.Field(Of Decimal)(Entidades.CalidadOrdenDeControlItem.Columnas.ValorAQL.ToString())
         .IdMRPAQLA = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.IdMRPAQLA.ToString())
         .CodigoNivel = dr.Field(Of String)(Entidades.CalidadOrdenDeControlItem.Columnas.CodigoNivel.ToString())
         .TamanoMuestreo = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.TamanoMuestreo.ToString())
         .CantidadAceptacion = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.CantidadAceptacion.ToString())
         .CantidadRechazo = dr.Field(Of Integer)(Entidades.CalidadOrdenDeControlItem.Columnas.CantidadRechazo.ToString())
         .Observacion = dr.Field(Of String)(Entidades.CalidadListaControlItem.Columnas.Observacion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CalidadOrdenDeControlItem)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CalidadOrdenDeControlItem)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CalidadOrdenDeControlItem)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                        numeroComprobante As Long, idListaControl As Integer, idListaControlItem As Integer) As DataTable
      Return GetSql().CalidadOrdenDeControlItems_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                    idListaControl, idListaControlItem)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                          numeroComprobante As Long, idListaControl As Integer, idListaControlItem As Integer) As Entidades.CalidadOrdenDeControlItem
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                    idListaControl, idListaControlItem, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                          numeroComprobante As Long, idListaControl As Integer, idListaControlItem As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CalidadOrdenDeControlItem
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                               idListaControl, idListaControlItem), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadOrdenDeControlItem(),
                          accion, Function() String.Format("No existe Orden de Calidad {0}", numeroComprobante))
   End Function

   Public Function GetTodas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer,
                            numeroComprobante As Long) As List(Of Entidades.CalidadOrdenDeControlItem)

      Return CargaLista(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, 0, 0),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CalidadOrdenDeControlItem())
   End Function

   Public Sub BorraDesdeOrdenDeControl(lEntidad As Entidades.CalidadOrdenDeControl)
      If lEntidad IsNot Nothing Then
         For Each drControl In lEntidad.CalidadOrdenDeControlItems
            _Borrar(drControl)
         Next
      End If
   End Sub

   Public Sub ActualizaDesdeOrdenDeControl(lEntidad As Entidades.CalidadOrdenDeControl)

      If lEntidad IsNot Nothing Then
         For Each drCI In lEntidad.CalidadOrdenDeControlItems
            If drCI.NumeroComprobante > 0 Then
               _Actualizar(drCI)
            Else
               With drCI
                  .IdSucursal = lEntidad.IdSucursal
                  .IdTipoComprobante = lEntidad.IdTipoComprobante
                  .Letra = lEntidad.Letra
                  .CentroEmisor = lEntidad.CentroEmisor
                  .NumeroComprobante = lEntidad.NumeroComprobante
                  _Insertar(drCI)
               End With
            End If
         Next
      End If

   End Sub

   Public Function CargaListaControlItemsDelProducto(lControlItem As List(Of Entidades.CalidadOrdenDeControlItem), idProducto As String) As List(Of Entidades.CalidadOrdenDeControlItem)
      lControlItem.Clear()

      '-- Busca las listas de Control para producto.- -------------------------------------------------------------
      Dim dtControl = New CalidadListasControlProductos().GetItemListaControlPorProducto(idProducto)
      For Each drControl In dtControl.AsEnumerable()
         Dim eCOI = New Entidades.CalidadOrdenDeControlItem()
         With eCOI
            .IdSucursal = 0
            .IdTipoComprobante = String.Empty
            .Letra = String.Empty
            .CentroEmisor = 0
            .NumeroComprobante = 0
            .IdListaControl = drControl.Field(Of Integer)("IdListaControl")
            .NombreListaControl = drControl.Field(Of String)("NombreListaControl")
            .IdListaControlItem = drControl.Field(Of Integer)("IdListaControlItem")
            .NombreListaControlItem = drControl.Field(Of String)("NombreListaControlItem")
            .NivelInspeccion = drControl.Field(Of String)("NivelInspeccion").StringToEnum(Entidades.NivelInspeccionMRP.I)
            .ValorAQL = drControl.Field(Of Decimal)("ValorAQL")
         End With
         '-- Cargo el Item en la lista.- --------------------------------------------------------------------------
         lControlItem.Add(eCOI)
      Next
      Return lControlItem
   End Function

   Public Function CalculaCantidadesListaControlItems(listaItems As List(Of Entidades.CalidadOrdenDeControlItem), cantidad As Decimal) As Entidades.ErrorBuilder
      Dim errBuilder = New Entidades.ErrorBuilder()
      If cantidad = 0 Then
         Return errBuilder
      End If
      Dim AQLA = New MRPAQLA().GetCalidadOrdenCantidad(cantidad, AccionesSiNoExisteRegistro.Nulo)
      If AQLA IsNot Nothing Then
         For Each item In listaItems
            With item
               If AQLA IsNot Nothing Then
                  .IdMRPAQLA = AQLA.IdMRPAQLA
                  .CodigoNivel = GetCodigoNivel(AQLA, .NivelInspeccion)

                  Try
                     Dim AQLB = New MRPAQLB().GetUno(.ValorAQL, .CodigoNivel)
                     If AQLB IsNot Nothing Then
                        .TamanoMuestreo = AQLB.TamanoMuestreo
                        .CantidadAceptacion = AQLB.CantidadAceptacion
                        .CantidadRechazo = AQLB.CantidadRechazo
                     End If
                  Catch ex As Exception
                     errBuilder.AddError(String.Format("{0} - {1} - {2}", .NombreListaControl, .NombreListaControlItem, ex.Message))
                  End Try
               End If
            End With
         Next
      Else
         errBuilder.AddError(String.Format("No existe AQL A para una muestra de: {0}", cantidad))
      End If
      Return errBuilder
   End Function

   Public Function GetOrdenesCalidadItemXEstados(sucursales As Entidades.Sucursal(), estadosOrdenes As Entidades.EstadoOrdenCalidad(), dtpDesde As Date?, dtpHasta As Date?,
                                               listaComprobantes As Entidades.TipoComprobante(), numeroOrdenCalidad As Long, idProducto As String,
                                               idProveedor As Long, idUsuario As String, idListaControl As Integer, idlistaControlItem As Integer) As DataTable
      Dim sql = New SqlServer.CalidadOrdenDeControlItems(da)
      Return sql.GetCalidadOrdenControlItemXEstados(sucursales, estadosOrdenes, dtpDesde, dtpHasta, listaComprobantes, numeroOrdenCalidad, idProducto,
                                                    idProveedor, idUsuario, idListaControl, idlistaControlItem)
   End Function
#End Region
End Class
