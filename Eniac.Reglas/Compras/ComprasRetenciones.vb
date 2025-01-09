Public Class ComprasRetenciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CompraRetencion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CompraRetencion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CompraRetencion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CompraRetencion)))
   End Sub

   <Obsolete("No Implemetado: Usar GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)")>
   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException("No Implemetado: Usar GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As DataTable
      Return GetSql().ComprasRetenciones_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor)
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.ComprasRetenciones
      Return New SqlServer.ComprasRetenciones(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CompraRetencion, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.ComprasRetenciones_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdProveedor, en.IdRetencion)

         Case TipoSP._U
            sql.ComprasRetenciones_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdProveedor, en.IdRetencion)

         Case TipoSP._D
            sql.ComprasRetenciones_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdProveedor, en.IdRetencion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CompraRetencion, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CompraRetencion.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CompraRetencion.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CompraRetencion.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CompraRetencion.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CompraRetencion.Columnas.NumeroComprobante.ToString())
         .IdProveedor = dr.Field(Of Long)(Entidades.CompraRetencion.Columnas.IdProveedor.ToString())
         .Retencion = New Retenciones(da).GetUno(dr.Field(Of Integer)(Entidades.CompraRetencion.Columnas.IdRetencion.ToString()))
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CompraRetencion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CompraRetencion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CompraRetencion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(c As Entidades.Compra)
      _Borrar(New Entidades.CompraRetencion() With {
                     .IdSucursal = c.IdSucursal,
                     .IdTipoComprobante = c.IdTipoComprobante,
                     .Letra = c.Letra,
                     .CentroEmisor = c.CentroEmisor,
                     .NumeroComprobante = c.NumeroComprobante,
                     .IdProveedor = c.Proveedor.IdProveedor
                 })
   End Sub
   Public Sub _Insertar(compra As Entidades.Compra)
      Dim rReten = New Retenciones(da)
      compra.Retenciones.ForEachSecure(
         Sub(en)
            en.Retencion.IdSucursal = compra.IdSucursal
            en.Retencion.EmisorRetencion = compra.CentroEmisor
            en.Retencion.NumeroRetencion = compra.NumeroComprobante
            en.Retencion.FechaEmision = compra.Fecha

            en.Retencion.CajaIngreso.IdCaja = compra.IdCaja
            en.Retencion.NroPlanillaIngreso = compra.NumeroPlanilla
            en.Retencion.NroMovimientoIngreso = compra.NumeroMovimiento

            Try
               'Aplico el coeficiente de valor a los importes de la retención solo al momento de grabar
               en.Retencion.BaseImponible *= compra.TipoComprobante.CoeficienteValores
               en.Retencion.ImporteTotal *= compra.TipoComprobante.CoeficienteValores
               rReten._Insertar(en.Retencion)
            Finally
               'Una vez grabado vuelvo atras los importes
               en.Retencion.BaseImponible *= compra.TipoComprobante.CoeficienteValores
               en.Retencion.ImporteTotal *= compra.TipoComprobante.CoeficienteValores
            End Try


            en.IdSucursal = compra.IdSucursal
            en.IdTipoComprobante = compra.IdTipoComprobante
            en.Letra = compra.Letra
            en.CentroEmisor = compra.CentroEmisor
            en.NumeroComprobante = compra.NumeroComprobante
            en.IdProveedor = compra.Proveedor.IdProveedor
            EjecutaSP(en, TipoSP._I)
         End Sub)
   End Sub

   Public Function Get1(idSucursal As Integer,
                        idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                        idRetencion As Integer) As DataTable
      Return GetSql().ComprasRetenciones_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idRetencion)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                          idRetencion As Integer) As Entidades.CompraRetencion
      Return GetUno(idSucursal,
                    idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor,
                    idRetencion,
                    AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                          idRetencion As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.CompraRetencion
      Return CargaEntidad(Get1(idSucursal,
                               idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor,
                               idRetencion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CompraRetencion(),
                          accion, Function() String.Format("No existe Retención de Compras con {0}/{1} {2} {3:0000}-{4:00000000} Id. Prov: {5} Id Retencion{7}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idRetencion))
   End Function

   Public Function GetTodos(compra As Entidades.Compra) As List(Of Entidades.CompraRetencion)
      Return GetTodos(compra.IdSucursal, compra.IdTipoComprobante, compra.Letra, compra.CentroEmisor, compra.NumeroComprobante, compra.Proveedor.IdProveedor)
   End Function
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long) As List(Of Entidades.CompraRetencion)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CompraRetencion())
   End Function

   Public Function CreaRetenciones(cliente As Entidades.Cliente, tipo As Entidades.TipoImpuesto.Tipos, importe As Decimal,
                                   provincia As Entidades.Provincia) As Entidades.CompraRetencion
      Dim rTipoImpuesto = New TiposImpuestos()
      Dim reten = New Entidades.Retencion With {
         .TipoImpuesto = rTipoImpuesto._GetUno(tipo),
         .BaseImponible = 0,
         .Alicuota = 0,
         .ImporteTotal = importe,
         .IdEstado = Entidades.Retencion.Estados.APLICADO,
         .Cliente = cliente,
         .Provincia = provincia
      }
      'Se completan al momento de grabar con los datos definitivos de la compra
      '.EmisorRetencion = compra.CentroEmisor,
      '.NumeroRetencion = compra.NumeroComprobante,
      '.FechaEmision = compra.Fecha,
      Return New Entidades.CompraRetencion() With {.Retencion = reten}
   End Function

   Public Function CreaRetenciones(cliente As Entidades.Cliente, rIVA As Decimal, dtIIBB As DataTable, rGanac As Decimal) As List(Of Entidades.CompraRetencion)
      Dim result = New List(Of Entidades.CompraRetencion)
      If rIVA <> 0 Then
         result.Add(CreaRetenciones(cliente, Entidades.TipoImpuesto.Tipos.RIVA, rIVA, Nothing))
      End If
      If dtIIBB.Any() Then
         Dim rProv = New Provincias(da)
         For Each ib In dtIIBB.AsEnumerable().Where(Function(dr) dr.Field(Of Decimal)("Importe") <> 0)
            result.Add(CreaRetenciones(cliente, Entidades.TipoImpuesto.Tipos.RIIBB, ib.Field(Of Decimal)("Importe"), rProv.GetUno(ib.Field(Of String)("IdProvincia"))))
         Next
      End If
      If rGanac <> 0 Then
         result.Add(CreaRetenciones(cliente, Entidades.TipoImpuesto.Tipos.RGANA, rGanac, Nothing))
      End If
      Return result
   End Function

#End Region

End Class