Public Class VentasImpuestos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("VentasImpuestos", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.VentaImpuesto)))
      'EjecutaConTransaccion(Sub()
      '                         _Insertar(DirectCast(entidad, Entidades.VentaImpuesto))
      '                         da.Command.ExecuteNonQuery()
      '                      End Sub)
   End Sub

   Public Sub _Insertar(vi As Entidades.VentaImpuesto)

      Dim rImpuestos = New Impuestos(da)
      If Not rImpuestos._Existe(vi.IdTipoImpuesto.ToString(), vi.Alicuota) Then
         rImpuestos._Insertar(New Entidades.Impuesto(vi.IdTipoImpuesto.ToString(), vi.Alicuota))
      End If
      Dim sql = New SqlServer.VentasImpuestos(da)
      sql.VentasImpuestos_I(vi.IdSucursal, vi.TipoComprobante.IdTipoComprobante, vi.Letra,
                            vi.CentroEmisor, vi.NumeroComprobante, vi.TipoImpuesto.IdTipoImpuesto,
                            vi.Alicuota, vi.Bruto, vi.Neto, vi.Importe, vi.Total, vi.IdProvincia,
                            vi.IdRegimenPercepcion)

   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.VentaImpuesto)))
      'da.Command.ExecuteNonQuery()
   End Sub
   Public Overloads Sub _Borrar(vi As Entidades.VentaImpuesto)
      Dim sql = New SqlServer.VentasImpuestos(da)
      sql.VentasImpuestos_D(vi.IdSucursal, vi.TipoComprobante.IdTipoComprobante, vi.Letra,
                                  vi.CentroEmisor, vi.NumeroComprobante, vi.TipoImpuesto.IdTipoImpuesto,
                                  vi.Alicuota)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(o As Entidades.VentaImpuesto, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)("IdSucursal")
         .TipoComprobante = New TiposComprobantes(da).GetUno(dr.Field(Of String)("IdTipoComprobante"))
         .Letra = dr.Field(Of String)("Letra")
         .CentroEmisor = dr.Field(Of Integer)("CentroEmisor").ToShort()
         .NumeroComprobante = dr.Field(Of Long)("NumeroComprobante")
         .TipoImpuesto = New TiposImpuestos(da).GetUno(dr.Field(Of String)(Entidades.VentaImpuesto.Columnas.IdTipoImpuesto.ToString()).StringToEnum(Entidades.TipoImpuesto.Tipos.IVA))
         .Alicuota = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Alicuota.ToString())
         .Bruto = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Bruto.ToString())
         .Neto = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Neto.ToString())
         .Importe = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Importe.ToString())
         .Total = dr.Field(Of Decimal)(Entidades.VentaImpuesto.Columnas.Total.ToString())
         .IdProvincia = dr.Field(Of String)(Entidades.VentaImpuesto.Columnas.IdProvincia.ToString()).IfNull()
         .IdRegimenPercepcion = dr.Field(Of Integer?)(Entidades.VentaImpuesto.Columnas.IdRegimenPercepcion.ToString()).IfNull()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Friend Sub EjecutaSP(ent As Entidades.VentaImpuesto, tipo As TipoSP)
      Dim sql = New SqlServer.VentasImpuestos(da)

      Select Case tipo
            'Case TipoSP._I

            '   sql.VentasProductos_I(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, _
            '                ent.NumeroComprobante, ent.Producto.IdProducto, ent.Producto.NombreProducto, ent.Cantidad, ent.Precio, ent.Costo, ent.DescRecGeneral, _
            '                ent.DescRecGeneralProducto, ent.DescuentoRecargo, ent.DescuentoRecargoProducto, _
            '                ent.DescuentoRecargoPorc1, ent.DescuentoRecargoPorc2, ent.PrecioLista, ent.PrecioNeto, ent.Utilidad, _
            '                ent.ImporteTotal, ent.ImporteTotalNeto, ent.Kilos, ent.TipoImpuesto.IdTipoImpuesto, _
            '                ent.AlicuotaImpuesto, ent.ImporteImpuesto)

            'Case TipoSP._U

            '   sql.VentasProductos_U(ent.IdSucursal, ent.TipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante, _
            '                   ent.Orden, ent.Producto, ent.Cantidad, ent.Precio, ent.Costo, ent.DescRecGeneral, _
            '                   ent.DescRecGeneralProducto, ent.DescuentoRecargo, ent.DescuentoRecargoProducto, _
            '                   ent.DescuentoRecargoPorc, ent.PrecioLista, ent.PrecioNeto, ent.Utilidad, ent.ImporteTotal, _
            '                   ent.ImporteTotalNeto)
         Case TipoSP._D

            sql.VentasImpuestos_D(ent.IdSucursal, ent.TipoComprobante.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroComprobante,
                                  ent.IdTipoImpuesto, ent.Alicuota)
      End Select

   End Sub

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.VentaImpuesto)
      Return GetTodos(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idTipoImpuesto:=Nothing)
   End Function
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                            idTipoImpuesto As Entidades.TipoImpuesto.Tipos?) As List(Of Entidades.VentaImpuesto)
      Return CargaLista(New SqlServer.VentasImpuestos(da).VentasImpuestos_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idTipoImpuesto),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaImpuesto())
   End Function
   Public Function GetTodos(comprobantes As IEnumerable(Of Entidades.IPKComprobante), idTipoImpuesto As Entidades.TipoImpuesto.Tipos?) As List(Of Entidades.VentaImpuesto)
      Return CargaLista(New SqlServer.VentasImpuestos(da).VentasImpuestos_GA(comprobantes, idTipoImpuesto),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaImpuesto())
   End Function
   Public Function GetTodos() As List(Of Entidades.VentaImpuesto)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaImpuesto())
   End Function

   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idTipoImpuesto As Entidades.TipoImpuesto.Tipos, alicuota As Decimal) As Entidades.VentaImpuesto
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idTipoImpuesto, alicuota, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          idTipoImpuesto As Entidades.TipoImpuesto.Tipos, alicuota As Decimal, accion As AccionesSiNoExisteRegistro) As Entidades.VentaImpuesto
      Return CargaEntidad(New SqlServer.VentasImpuestos(da).VentasImpuestos_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idTipoImpuesto, alicuota),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaImpuesto(),
                          accion, Function() String.Format("No existe el registro de VentaImpuesto"))
   End Function

   Public Function GetResumenDeVenta(empresas As Entidades.Empresa(),
                                     fechaDesde As Date?, fechaHasta As Date?,
                                     periodoDesde As Date?, periodoHasta As Date?,
                                     grabaLibro As Entidades.Publicos.SiNoTodos, esComercial As Entidades.Publicos.SiNoTodos,
                                     informaLibroIVA As Entidades.Publicos.SiNoTodos, separarNetos As Boolean) As DataSet
      Return EjecutaConConexion(
         Function()
            Dim ds = New DataSet()
            Dim sql = New SqlServer.VentasImpuestos(da)

            ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra.ToString(),
                          sql.GetResumenDeVenta(empresas, fechaDesde, fechaHasta, periodoDesde, periodoHasta, grabaLibro, esComercial, informaLibroIVA, Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra, separarNetos))

            ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal.ToString(),
                          sql.GetResumenDeVenta(empresas, fechaDesde, fechaHasta, periodoDesde, periodoHasta, grabaLibro, esComercial, informaLibroIVA, Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal, separarNetos))

            ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente.ToString(),
                          sql.GetResumenDeVenta(empresas, fechaDesde, fechaHasta, periodoDesde, periodoHasta, grabaLibro, esComercial, informaLibroIVA, Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente, separarNetos))

            ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto.ToString(),
                          sql.GetResumenDeVenta(empresas, fechaDesde, fechaHasta, periodoDesde, periodoHasta, grabaLibro, esComercial, informaLibroIVA, Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto, separarNetos))

            ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto.ToString(),
                          sql.GetResumenDeVenta(empresas, fechaDesde, fechaHasta, periodoDesde, periodoHasta, grabaLibro, esComercial, informaLibroIVA, Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto, separarNetos))

            ds.Tables.Add(Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal.ToString(),
                          sql.GetResumenDeVenta(empresas, fechaDesde, fechaHasta, periodoDesde, periodoHasta, grabaLibro, esComercial, informaLibroIVA, Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal, separarNetos))

            Return ds
         End Function)
   End Function

#End Region

End Class