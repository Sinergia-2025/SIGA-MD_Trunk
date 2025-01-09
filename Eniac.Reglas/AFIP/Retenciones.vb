Public Class Retenciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.Retencion.NombreTabla, accesoDatos)
   End Sub
#End Region

   Public Enum OrdenadoPor
      FechaCobro
      FechaEmision
      NumeroRetencion
      Proveedor
   End Enum

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Retencion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Retencion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Retencion)))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return GetSQL().Retenciones_GA(actual.Sucursal.Id)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSQL() As SqlServer.Retenciones
      Return New SqlServer.Retenciones(da)
   End Function

   Private Sub CargarUno(o As Entidades.Retencion, dr As DataRow)

      With o
         .IdRetencion = dr.Field(Of Integer)(Entidades.Retencion.Columnas.IdRetencion.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.Retencion.Columnas.IdSucursal.ToString())

         .TipoImpuesto = New TiposImpuestos(da)._GetUno(dr.Field(Of String)(Entidades.Retencion.Columnas.IdTipoImpuesto.ToString()).StringToEnum(Entidades.TipoImpuesto.Tipos.Ninguno))
         .EmisorRetencion = dr.Field(Of Integer)(Entidades.Retencion.Columnas.EmisorRetencion.ToString())
         .NumeroRetencion = dr.Field(Of Long)(Entidades.Retencion.Columnas.NumeroRetencion.ToString())

         .FechaEmision = dr.Field(Of Date)(Entidades.Retencion.Columnas.FechaEmision.ToString())

         .BaseImponible = dr.Field(Of Decimal)(Entidades.Retencion.Columnas.BaseImponible.ToString())
         .Alicuota = dr.Field(Of Decimal)(Entidades.Retencion.Columnas.Alicuota.ToString())
         .ImporteTotal = dr.Field(Of Decimal)(Entidades.Retencion.Columnas.ImporteTotal.ToString())

         .CajaIngreso.IdCaja = dr.Field(Of Integer?)(Entidades.Retencion.Columnas.IdCajaIngreso.ToString()).IfNull()
         .NroPlanillaIngreso = dr.Field(Of Integer?)(Entidades.Retencion.Columnas.NroPlanillaIngreso.ToString()).IfNull()
         .NroMovimientoIngreso = dr.Field(Of Integer?)(Entidades.Retencion.Columnas.NroMovimientoIngreso.ToString()).IfNull()

         Dim idCliente = dr.Field(Of Long?)(Entidades.Retencion.Columnas.IdCliente.ToString())

         If idCliente.HasValue Then
            .Cliente = New Clientes(da)._GetUno(idCliente.Value)
         End If

         .IdEstado = dr.Field(Of String)(Entidades.Retencion.Columnas.IdEstado.ToString()).StringToEnum(Entidades.Retencion.Estados.APLICADO)

         Dim idProvincia = dr.Field(Of String)(Entidades.Retencion.Columnas.IdProvincia.ToString())
         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .Provincia = New Provincias(da).GetUno(idProvincia)
         End If

         Dim idLocalidad = dr.Field(Of Integer?)(Entidades.Retencion.Columnas.IdLocalidad.ToString())
         If idLocalidad.HasValue Then
            .Localidad = New Localidades(da).GetUna(idLocalidad.Value)
         End If
      End With

   End Sub
   Private Sub EjecutaSP(en As Entidades.Retencion, tipo As TipoSP)
      Dim sql = GetSQL()
      Select Case tipo
         Case TipoSP._I
            If ExisteRetencion(en) Then
               Throw New Exception(String.Format("Ya existe una retención del cliente con el Emisor {0} y Número {1}", en.EmisorRetencion, en.NumeroRetencion))
            End If
            If en.IdRetencion = 0 Then
               en.IdRetencion = GetProximoCodigo()
            End If
            sql.Retenciones_I(en.IdRetencion, en.IdSucursal, en.IdTipoImpuesto, en.EmisorRetencion, en.NumeroRetencion,
                              en.FechaEmision,
                              en.BaseImponible, en.Alicuota, en.ImporteTotal,
                              en.CajaIngreso.IdCaja, en.NroPlanillaIngreso, en.NroMovimientoIngreso,
                              en.IdEstado, en.Cliente.IdCliente,
                              en.IdProvincia, en.IdLocalidad)

         Case TipoSP._U
            sql.Retenciones_U(en.IdRetencion, en.IdSucursal, en.IdTipoImpuesto, en.EmisorRetencion, en.NumeroRetencion,
                              en.FechaEmision,
                              en.BaseImponible, en.Alicuota, en.ImporteTotal,
                              en.CajaIngreso.IdCaja, en.NroPlanillaIngreso, en.NroMovimientoIngreso,
                              en.IdEstado, en.Cliente.IdCliente,
                              en.IdProvincia, en.IdLocalidad)

         Case TipoSP._D
            sql.Retenciones_D(en.IdRetencion)

      End Select
   End Sub

#End Region


#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.Retencion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Retencion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Retencion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(entidad As IEnumerable(Of Entidades.Retencion))
      entidad.ForEachSecure(Sub(r) _Borrar(r))
   End Sub

   Public Function ExisteRetencion(en As Entidades.Retencion) As Boolean
      Return GetSQL().Retenciones_GA(en.IdSucursal, en.IdTipoImpuesto, en.EmisorRetencion, en.NumeroRetencion, en.Cliente.IdCliente).Any()
   End Function

   Public Function GetInformeRetenciones(idSucursal As Integer, fechaDesde As Date?, fechaHasta As Date?,
                                         idTipoImpuesto As Entidades.TipoImpuesto.Tipos, idProvincia As String, idCliente As Long) As DataTable
      Return GetSQL().GetInformeRetenciones(idSucursal, fechaDesde, fechaHasta, idTipoImpuesto, idProvincia, idCliente)
   End Function

   Public Function Get1(idRetencion As Integer) As DataTable
      Return GetSQL().Retenciones_G1(idRetencion)
   End Function
   Public Function GetUno(idRetencion As Integer) As Entidades.Retencion
      Return GetUno(idRetencion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idRetencion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Retencion
      Return CargaEntidad(Get1(idRetencion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Retencion(),
                          accion, String.Format("No existe retención con el Id {0}", idRetencion))
   End Function

   Public Function GetPorMovimientoCaja(idSucursal As Integer, nroPlanilla As Integer, nroMovimiento As Integer) As List(Of Entidades.Retencion)
      Return CargaLista(GetSQL().GetPorMovimientoCaja(idSucursal, nroPlanilla, nroMovimiento),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Retencion())
   End Function

   Public Function GetPorCuentaCorriente(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                         idCliente As Long) As List(Of Entidades.Retencion)
      Return CargaLista(GetSQL().GetPorCuentaCorriente(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idCliente),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Retencion())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return GetSQL().GetCodigoMaximo()
   End Function
   Public Function GetProximoCodigo() As Integer
      Return GetCodigoMaximo() + 1
   End Function
#End Region

End Class