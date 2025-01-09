Public Class ProductosABM

#Region "Campos"
   'Private _ProdWeb As ProductosWeb
   'Private _MostrarPrecios As Boolean
   'Private _observacionesCompras As Boolean

   Private _entiProducto As Entidades.Producto
   Private _pantallaDetalle As ProductosDetalle
   Private _reglas As Reglas.Productos

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      'Dim aWeb As New ToolStripMenuItem("a Web")
      'aWeb.Image = My.Resources.world_up_32
      'aWeb.Name = "TSMaWeb"
      'AddHandler aWeb.Click, AddressOf TSMaWeb_Click

      'tsddExportar.DropDownItems.Add(aWeb)
      'tsddExportar.DropDownItems.Add(aWeb)
      'tsddExportar.DropDownItems.Add(aWeb)

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      'If estado = StateForm.Actualizar Then
      '   Return New ProductosDetalle(DirectCast(Me.GetEntidad(), Entidades.Producto))
      'End If
      'Return New ProductosDetalle(New Entidades.Producto())
      If _pantallaDetalle IsNot Nothing Then
         _pantallaDetalle.Dispose()
         _pantallaDetalle = Nothing
      End If
      _pantallaDetalle = New ProductosDetalle()
      If estado = StateForm.Actualizar Then
         _pantallaDetalle.SetEntidad(DirectCast(Me.GetEntidad(), Entidades.Producto))
      Else
         _pantallaDetalle.SetCreaEntidadNueva()
      End If

      Return Me._pantallaDetalle
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Me._reglas = New Reglas.Productos()
      Return Me._reglas
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.Productos).GetAll(If(Reglas.Publicos.OcultarProductosInactivosABMProductos, Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.TODOS))
      'Return MyBase.GetAll(rg)
   End Function
   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.Productos).Buscar(bus, If(Reglas.Publicos.OcultarProductosInactivosABMProductos, Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.TODOS))
      'Return MyBase.Buscar(rg, bus)
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Productos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      MyBase.GetEntidad()

      Dim blnIncluirFoto As Boolean = True

      With Me.dgvDatos.ActiveCell.Row
         Me._entiProducto = DirectCast(Me.GetReglas(), Reglas.Productos).GetUno(.Cells("IdProducto").Value.ToString().Trim(), blnIncluirFoto, True)
         Me._entiProducto.Usuario = actual.Sucursal.Usuario
      End With

      Return Me._entiProducto

   End Function

   Protected Overrides Sub FormatearGrilla()
      FormatearGrilla(dgvDatos, auditoria:=False)
   End Sub

   Public Overloads Shared Sub FormatearGrilla(dgvDatos As UltraGrid, auditoria As Boolean)
      With dgvDatos.DisplayLayout.Bands(0)

         Dim pos = 0I

         If auditoria Then
            .Columns("Modificado").FormatearColumna(String.Empty, pos, 30)
            .Columns("FechaAuditoria").FormatearColumna("Fecha", pos, 100, HAlign.Center,, "dd/MM/yyyy HH:mm")
            .Columns("OperacionAuditoria").FormatearColumna("Tipo", pos, 40, HAlign.Center)
            .Columns("UsuarioAuditoria").FormatearColumna("Usuario", pos, 70)
         End If

         .Columns("IdProducto").FormatearColumna("Código", pos, 100, HAlign.Right)
         .Columns(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).FormatearColumna("Código Largo", pos, 150, , Not Reglas.Publicos.ProductoUtilizaCodigoLargo)

         .Columns("NombreProducto").FormatearColumna("Nombre", pos, 370)

         .Columns("Tamano").FormatearColumna("Tamaño", pos, 50, HAlign.Right, , "N2")
         .Columns("IdUnidadDeMedida").FormatearColumna("U.M. Stock", pos, 90, HAlign.Center)
         '.Columns("IdUnidadDeMedida2").FormatearColumna("U.M.2", pos, 90, HAlign.Center)
         .Columns("IdUnidadDeMedidaCompra").FormatearColumna("U.M. Compra", pos, 90, HAlign.Center)
         .Columns("FactorConversionCompra").FormatearColumna("Conv. UM Compra", pos, 100, HAlign.Right)
         .Columns("IdUnidadDeMedidaProduccion").FormatearColumna("U.M. Producc.", pos, 90, HAlign.Center)
         .Columns("FactorConversionProduccion").FormatearColumna("Conv. UM Producc.", pos, 100, HAlign.Right)

         .Columns("NombreMarca").FormatearColumna("Nombre Marca", pos, 145)
         .Columns("NombreModelo").FormatearColumna("Nombre Modelo", pos, 145, , Not Publicos.ProductoTieneModelo)

         .Columns("NombreRubro").FormatearColumna("Nombre Rubro", pos, 145)
         .Columns("NombreSubRubro").FormatearColumna("Nombre SubRubro", pos, 145, , Not Reglas.Publicos.ProductoTieneSubRubro)
         .Columns("NombreSubSubRubro").FormatearColumna("Nombre SubSubRubro", pos, 145, , Not Reglas.Publicos.ProductoTieneSubSubRubro)

         .Columns("MesesGarantia").FormatearColumna("Meses Garantia", pos, 60)
         .Columns("IdTipoImpuesto").FormatearColumna("Tipo Imp", pos, 40, HAlign.Center)
         .Columns("Alicuota").FormatearColumna("Alicuota", pos, 50, HAlign.Right)
         .Columns("Alicuota2").FormatearColumna("Alicuota 2", pos, 50, HAlign.Right, Not Reglas.Publicos.ProductoUtilizaAlicuota2)

         .Columns("AfectaStock").FormatearColumna("Afecta Stock", pos, 50)

         .Columns("Foto").OcultoPosicion(hidden:=True, pos)
         .Columns("TieneFoto").FormatearColumna("Tiene Foto", pos, 40)     '-.PE-32789.-

         .Columns(Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString()).FormatearColumna("Modifica Descripc.", pos, 60)
         .Columns("Lote").FormatearColumna("Lote", pos, 40)
         .Columns("NroSerie").FormatearColumna("Nro. Serie", pos, 40)

         .Columns("CodigoDeBarras").FormatearColumna("Codigo de Barras", pos, 100, HAlign.Right, Not Publicos.ProductoUtilizaCodigoDeBarras)
         .Columns(Entidades.Producto.Columnas.CodigoDeBarrasConPrecio.ToString()).FormatearColumna("C.B. Precio", pos, 70, HAlign.Center)

         .Columns("EsServicio").FormatearColumna("Es Servicio", pos, 70, HAlign.Center)

         .Columns("PublicarEnWeb").FormatearColumna("Publicar En Web", pos, 70, HAlign.Center)
         .Columns("PublicarEnTiendaNube").FormatearColumna("Publicar En Tienda Nube", pos, 70, HAlign.Center)
         .Columns("PublicarEnMercadoLibre").FormatearColumna("Publicar En Mercado Libre", pos, 70, HAlign.Center)
         .Columns("PublicarEnArborea").FormatearColumna("Publicar En Arborea", pos, 70, HAlign.Center)
         .Columns("PublicarListaDePreciosClientes").FormatearColumna("L.P.Clientes", pos, 70, HAlign.Center)
         .Columns("PublicarEnGestion").FormatearColumna("Publicar En Gestión", pos, 70, HAlign.Center)
         .Columns("PublicarEnEmpresarial").FormatearColumna("Publicar En Empresarial", pos, 70, HAlign.Center)
         .Columns("PublicarEnBalanza").FormatearColumna("Publicar En Balanza", pos, 70, HAlign.Center)
         .Columns("PublicarEnSincronizacionSucursal").FormatearColumna("Publicar Sincroniza Sucursal", pos, 70, HAlign.Center)

         .Columns("Observacion").FormatearColumna("Observación y/o Detalle Técnico", pos, 300)
         .Columns("Activo").FormatearColumna("Activo", pos, 40, HAlign.Center)
         .Columns("EsCompuesto").FormatearColumna("Compuesto", pos, 70, HAlign.Center, Not Reglas.Publicos.TieneModuloProduccion)
         .Columns("DescontarStockComponentes").FormatearColumna("Desc. stock Componentes", pos, 80, HAlign.Center, Not Reglas.Publicos.TieneModuloProduccion)

         .Columns("EsDeCompras").FormatearColumna("De Compras", pos, 70, HAlign.Center)
         .Columns("EsDeVentas").FormatearColumna("De Ventas", pos, 70, HAlign.Center)

         .Columns("IdMoneda").OcultoPosicion(hidden:=True, pos)

         .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 70)
         .Columns("AlertaDeCaja").FormatearColumna("Alerta de Caja", pos, 100, HAlign.Center)

         .Columns(Entidades.Producto.Columnas.EsAlquilable.ToString()).FormatearColumna("Alquilable", pos, 60, HAlign.Center, Not Reglas.Publicos.TieneModuloAlquiler)
         .Columns(Entidades.Producto.Columnas.EquipoMarca.ToString()).FormatearColumna("Equipo Marca", pos, 150, , Not Reglas.Publicos.TieneModuloAlquiler)
         .Columns(Entidades.Producto.Columnas.EquipoModelo.ToString()).FormatearColumna("Equipo Modelo", pos, 150, , Not Reglas.Publicos.TieneModuloAlquiler)
         .Columns(Entidades.Producto.Columnas.NumeroSerie.ToString()).FormatearColumna("Nro. Serie", pos, 200, , Not Reglas.Publicos.TieneModuloAlquiler)
         .Columns(Entidades.Producto.Columnas.CaractSII.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.Producto.Columnas.Anio.ToString()).FormatearColumna("Año", pos, 40, HAlign.Center, Not Reglas.Publicos.TieneModuloAlquiler)

         .Columns(Entidades.Producto.Columnas.PagaIngresosBrutos.ToString()).FormatearColumna("Paga IIBB", pos, 70, HAlign.Center)
         .Columns(Entidades.Producto.Columnas.EsPerceptibleIVARes53292023.ToString()).FormatearColumna("Perc. IVA 5329/2023", pos, 80, HAlign.Center)

         .Columns(Entidades.Producto.Columnas.Embalaje.ToString()).FormatearColumna("Embalaje", pos, 60, HAlign.Center)
         .Columns(Entidades.Producto.Columnas.Kilos.ToString()).FormatearColumna("Kilos", pos, 70, HAlign.Right,, "N3")
         .Columns("IdFormula").OcultoPosicion(hidden:=True, pos)

         .Columns(Entidades.Producto.Columnas.IdProductoMercosur.ToString()).FormatearColumna("Cod. Prod. Mercosur", pos, 70)
         .Columns(Entidades.Producto.Columnas.IdProductoSecretaria.ToString()).FormatearColumna("Cod. Prod. Secretaria", pos, 70)

         .Columns("ActualizaPreciosSucursalesAsociadas").FormatearColumna("Actualiza Precios en Sucursales Asociadas", pos, 70, HAlign.Center)
         .Columns(Entidades.Producto.Columnas.FacturacionCantidadNegativa.ToString()).FormatearColumna("Cant.Neg. Venta/Compra", pos, 80)

         .Columns(Entidades.Producto.Columnas.Orden.ToString()).FormatearColumna("Orden", pos, 70, HAlign.Right)
         .Columns(Entidades.Producto.Columnas.IdProveedor.ToString()).OcultoPosicion(hidden:=True, pos)

         .Columns(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()).FormatearColumna("P. H.", pos, 80)
         .Columns(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).FormatearColumna("Proveedor Habitual", pos, 150)

         .Columns(Entidades.Producto.Columnas.UnidHasta1.ToString()).FormatearColumna("Unid. 1", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.Producto.Columnas.UHPorc1.ToString()).FormatearColumna("Desc.% 1", pos, 60, HAlign.Right, , "N2")
         .Columns("UHListaPrecios1").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreListaPrecios_1").FormatearColumna("Bonif. Lista Precios 1", pos, 100)

         .Columns(Entidades.Producto.Columnas.UnidHasta2.ToString()).FormatearColumna("Unid. 2", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.Producto.Columnas.UHPorc2.ToString()).FormatearColumna("Desc.% 2", pos, 60, HAlign.Right, , "N2")
         .Columns("UHListaPrecios2").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreListaPrecios_2").FormatearColumna("Bonif. Lista Precios 2", pos, 100)

         .Columns(Entidades.Producto.Columnas.UnidHasta3.ToString()).FormatearColumna("Unid. 3", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.Producto.Columnas.UHPorc3.ToString()).FormatearColumna("Desc.% 3", pos, 60, HAlign.Right, , "N2")
         .Columns("UHListaPrecios3").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreListaPrecios_3").FormatearColumna("Bonif. Lista Precios 3", pos, 100)

         .Columns(Entidades.Producto.Columnas.UnidHasta4.ToString()).FormatearColumna("Unid. 4", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.Producto.Columnas.UHPorc4.ToString()).FormatearColumna("Desc.% 4", pos, 60, HAlign.Right, , "N2")
         .Columns("UHListaPrecios4").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreListaPrecios_4").FormatearColumna("Bonif. Lista Precios 4", pos, 100)

         .Columns(Entidades.Producto.Columnas.UnidHasta5.ToString()).FormatearColumna("Unid. 5", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.Producto.Columnas.UHPorc5.ToString()).FormatearColumna("Desc.% 5", pos, 60, HAlign.Right, , "N2")
         .Columns("UHListaPrecios5").OcultoPosicion(hidden:=True, pos)
         .Columns("NombreListaPrecios_5").FormatearColumna("Bonif. Lista Precios 5", pos, 100)


         .Columns(Entidades.Producto.Columnas.DescRecProducto.ToString()).FormatearColumna("Desc/Rec Producto", pos, 60, HAlign.Right, , "N2")
         .Columns(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).FormatearColumna("Cta Compra", pos, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Compras").FormatearColumna("Nombre Cuenta Compras", pos, 280)

         .Columns(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).FormatearColumna("Cta Venta", pos, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Ventas").FormatearColumna("Nombre Cuenta Ventas", pos, 280)

         .Columns(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).FormatearColumna("Cta Venta", pos, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Ventas").FormatearColumna("Nombre Cuenta Ventas", pos, 280)

         .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).FormatearColumna("Cta Compras Sec.", pos, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").FormatearColumna("Nombre Cuenta Compras Secundaria", pos, 280)

         .Columns(Entidades.Producto.Columnas.IdCentroCosto.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).FormatearColumna("Centro de Costos", pos, 120)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Compras").Hidden = True
            .Columns(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Ventas").Hidden = True
            .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").Hidden = True
            .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = True
         Else
            If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto Then
               .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).Hidden = True
               .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").Hidden = True
            End If

            If Not Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
               .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = True
            End If
         End If

         .Columns(Entidades.Producto.Columnas.ImporteImpuestoInterno.ToString()).FormatearColumna("Imp. Interno", pos, 90, HAlign.Right,, "N2")
         .Columns(Entidades.Producto.Columnas.PorcImpuestoInterno.ToString()).FormatearColumna("% Imp. Int.", pos, 90, HAlign.Right,, "N2")
         .Columns(Entidades.Producto.Columnas.OrigenPorcImpInt.ToString()).FormatearColumna("Origen % Imp. Int.", pos, 90, HAlign.Center)

         .Columns("EsOferta").FormatearColumna("Es Oferta", pos, 60, HAlign.Center)

         .Columns(Entidades.Producto.Columnas.IncluirExpensas.ToString()).FormatearColumna("Incl. Exp.", pos, 60, , Not Reglas.Publicos.TieneModuloExpensas)

         Dim rUsuario = New Reglas.Usuarios()
         Dim _MostrarPrecios = rUsuario.TienePermisos("Productos-MostrarPrecios")
         Dim _observacionesCompras = rUsuario.TienePermisos("MovimientosDeCompras")

         .Columns("FechaActualizacion").FormatearColumna("Ult. Actualizacion", pos, 100, HAlign.Center, Not _MostrarPrecios, "dd/MM/yyyy HH:mm")
         .Columns("ObservacionCompras").FormatearColumna("Observación de Compras", pos, 300, , Not _observacionesCompras)

         .Columns(Entidades.Producto.Columnas.SolicitaPrecioVentaPorTamano.ToString()).FormatearColumna("Solic. Precio x Tamaño", pos, 70, , Not Reglas.Publicos.TieneModuloProduccion)

         .Columns(Entidades.Producto.Columnas.Alto.ToString()).FormatearColumna("Alto", pos, 70, HAlign.Right, , "N3")
         .Columns(Entidades.Producto.Columnas.Ancho.ToString()).FormatearColumna("Ancho", pos, 70, HAlign.Right, , "N3")
         .Columns(Entidades.Producto.Columnas.Largo.ToString()).FormatearColumna("Largo", pos, 70, HAlign.Right, , "N3")

         .Columns("EsComercial").FormatearColumna("Es Comercial", pos, 60, HAlign.Center)

         .Columns(Entidades.Producto.Columnas.EsCambiable.ToString()).FormatearColumna("Es Cambiable", pos, 65, HAlign.Center, Not Reglas.Publicos.ProductoPermiteEsCambiable)
         .Columns(Entidades.Producto.Columnas.EsBonificable.ToString()).FormatearColumna("Es Bonificable", pos, 65, HAlign.Center, Not Reglas.Publicos.ProductoPermiteEsBonificable)

         .Columns(Entidades.Producto.Columnas.Espmm.ToString()).FormatearColumna("Esp mm", pos, 70, HAlign.Right, Not Reglas.Publicos.TieneModuloProduccion, "N3")
         .Columns(Entidades.Producto.Columnas.EspPulgadas.ToString()).FormatearColumna("Esp """, pos, 70, , Not Reglas.Publicos.TieneModuloProduccion)
         .Columns(Entidades.Producto.Columnas.CodigoSAE.ToString()).FormatearColumna("SAE", pos, 70, HAlign.Right, Not Reglas.Publicos.TieneModuloProduccion)
         .Columns(Entidades.Producto.Columnas.IdProduccionProceso.ToString()).FormatearColumna("Código Proceso", pos, 70, HAlign.Right, False)
         .Columns("NombreProduccionProceso").FormatearColumna("Proceso", pos, 100, , Not Reglas.Publicos.TieneModuloProduccion)
         .Columns(Entidades.Producto.Columnas.IdProduccionForma.ToString()).FormatearColumna("Código Forma", pos, 70, HAlign.Right, False)
         .Columns("NombreProduccionForma").FormatearColumna("Forma", pos, 100, , Not Reglas.Publicos.TieneModuloProduccion)

         .Columns(Entidades.Producto.Columnas.IdProductoNumerico.ToString()).FormatearColumna("Cód. Producto Numérico", pos, 100, HAlign.Right)

         .Columns(Entidades.Producto.Columnas.Conversion.ToString()).FormatearColumna("Conversión", pos, 80, HAlign.Right, False, "N2")
         .Columns(Entidades.Producto.Columnas.EnviarSinCargo.ToString()).FormatearColumna("Enviar Sin Cargo", pos, 50, HAlign.Center)
         .Columns(Entidades.Producto.Columnas.CodigoProductoTiendaNube.ToString()).FormatearColumna("Cód. Producto Tienda Nube", pos, 100, HAlign.Right)

         '-- REQ-30521.- -----------------------------------------------------------------
         .Columns(Entidades.Producto.Columnas.CodigoProductoMercadoLibre.ToString()).FormatearColumna("Cód. Producto Mercado Libre", pos, 100, HAlign.Right)
         .Columns(Entidades.Producto.Columnas.idCategoriaMercadoLibre.ToString()).FormatearColumna("Categoria Mercado Libre", pos, 80, HAlign.Right, True)
         '.Columns("CodigoProductoArborea").Hidden = False
         '--------------------------------------------------------------------------------

         '-- REQ-xxxxx.- -----------------------------------------------------------------
         .Columns("CodigoProductoProveedor").FormatearColumna("Código Producto Proveedor", pos, 100, HAlign.Right)
         .Columns("NombreCorto").FormatearColumna("Nombre Corto", pos, 200)
         .Columns("NombreProductoWeb").FormatearColumna("Nombre en Web", pos, 200)
         .Columns("IdMarca").FormatearColumna("Marca", pos, 50)
         .Columns("IdModelo").FormatearColumna("Modelo", pos, 50, , Not Publicos.ProductoTieneModelo)
         .Columns("IdRubro").FormatearColumna("Rubro", pos, 50)
         .Columns("IdSubRubro").FormatearColumna("SubRubro", pos, 50, , Not Reglas.Publicos.ProductoTieneSubRubro)
         .Columns("IdSubSubRubro").FormatearColumna("SubSubRubro", pos, 50, , Not Reglas.Publicos.ProductoTieneSubSubRubro)
         '--------------------------------------------------------------------------------

         .Columns(Entidades.Producto.Columnas.IdVarianteProducto.ToString()).FormatearColumna("Variante Producto", pos, 100, HAlign.Right)
         .Columns(Entidades.Producto.Columnas.TipoBonificacion.ToString()).FormatearColumna("Tipo de Bonificación", pos, 100, HAlign.Left)
         .Columns(Entidades.Producto.Columnas.ComisionPorVenta.ToString()).FormatearColumna("Comision por Venta", pos, 120, HAlign.Right)

         .Columns(Entidades.Producto.Columnas.CalidadFecCertificado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaEgreso.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaEntProg.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaEntregado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaIngreso.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaLiberado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaPreEnt.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadFechaPreEnt.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadNroCarroceria.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadNroCertificado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadNumeroChasis.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadObservaciones.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadStatusEntregado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadStatusLiberado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadUserEntregado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadUserLiberado.ToString()).Hidden = True
         .Columns(Entidades.Producto.Columnas.CalidadUsrCertificado.ToString()).Hidden = True


         dgvDatos.AgregarFiltroEnLinea({"IdProducto", Entidades.Producto.Columnas.CodigoLargoProducto.ToString(), "NombreProducto", "NombreMarca", "NombreModelo",
                                        "NombreRubro", "NombreSubRubro", "NombreSubSubRubro", "CodigoDeBarras", "Observacion",
                                        "ObservacionCompras", "CodigoProductoProveedor"})

         Dim cols = ({"IdProducto", "NombreProducto", "NombreCorto", "NombreProductoWeb", "Observacion",
                      "CodigoDeBarras", "CodigoLargoProducto", "ObservacionCompras", "CodigoProductoProveedor"}).ToList()
         cols.ForEach(Sub(c) .Columns(c).FilterOperandDropDownItems = FilterOperandDropDownItems.ShowNone)
      End With
   End Sub

   '-.PE-31322.- Poner en rojo el id y el nombre de los productos inactivos
   '-.PE-33023.- Resaltar en rojo la fila entera de los productos inactivos
   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      If e.Row.Band.Index = 0 Then
         If CBool(e.Row.Cells("Activo").Value) = False Then
            e.Row.CellAppearance.BackColor = Color.Red
            e.Row.CellAppearance.ForeColor = Color.White
            'e.Row.Cells("NombreProducto").Color(Color.White, Color.Red)
            'e.Row.Cells("IdProducto").Color(Color.White, Color.Red)
         End If
      End If
   End Sub

#End Region

#Region "Marcado"
   'Private Sub TSMaWeb_Click(ByVal sender As System.Object, _
   'ByVal e As System.EventArgs)
   '   Try
   '      If Me.dgvDatos.Rows.Count = 0 Then Exit Sub

   '      Me.Cursor = Cursors.WaitCursor

   '      Me.ExportarDatos()

   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   Finally
   '      Me.Cursor = Cursors.Default
   '   End Try

   'End Sub
   'Private Sub ExportarDatos()

   '   Try
   '      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()

   '      Dim DialogoGuardarArchivo As New SaveFileDialog()

   '      DialogoGuardarArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
   '      DialogoGuardarArchivo.Filter = "Archivos de Texto (*.csv)|*.csv|Todos los Archivos (*.*)|*.*"
   '      DialogoGuardarArchivo.FilterIndex = 1
   '      DialogoGuardarArchivo.RestoreDirectory = True
   '      Dim destino As String = ""

   '      If DialogoGuardarArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
   '         Try
   '            If DialogoGuardarArchivo.FileName <> "" Then

   '               destino = DialogoGuardarArchivo.FileName

   '               'If System.IO.File.Exists(destino.Trim()) Then
   '               '    If MessageBox.Show("El Archivo Seleccionado Existe, Desea Sobreescribirlo?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes Then
   '               '        destino = ""
   '               '    End If
   '               'End If

   '            End If

   '            Me.CrearProductosWeb()

   '            Me._ProdWeb.GrabarArchivo(destino)

   '            MessageBox.Show("Se Exportaron " & dgvDatos.Rows.Count.ToString() & " productos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

   '         Catch Ex As Exception
   '            Throw
   '         End Try
   '      End If
   '   Catch ex As Exception
   '      Throw
   '   End Try
   'End Sub
   'Private Sub CrearProductosWeb()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor

   '      Me.toolStripProgressBar1.Visible = True
   '      Me.toolStripProgressBar1.Minimum = 0
   '      Me.toolStripProgressBar1.Maximum = dgvDatos.Rows.Count
   '      Me.toolStripProgressBar1.Value = 0

   '      Me._ProdWeb = New ProductosWeb()

   '      Dim linea As ProductosWebLinea
   '      Me.dgvDatos.Update()

   '      For Each dr As UltraGridRow In dgvDatos.Rows

   '         Me.toolStripProgressBar1.Value += 1

   '         linea = New ProductosWebLinea()

   '         '01 - CUIT
   '         linea.Cuit = Publicos.CuitEmpresa
   '         '02 - Codigo Producto
   '         linea.IdProducto = dr.Cells("IdProducto").Value.ToString()
   '         '03 - Nombre Producto
   '         linea.NombreProducto = dr.Cells("NombreProducto").Value.ToString()
   '         '05 - Marca
   '         linea.NombreMarca = New Reglas.Marcas().GetUna(dr.Cells("IdMarca").Value.ToString()).NombreMarca
   '         '06 - Rubro
   '         linea.NombreRubro = New Reglas.Rubros().GetUno(dr.Cells("IdRubro").Value.ToString()).NombreRubro
   '         '07 - IVA
   '         linea.Alicuota = Decimal.Parse(dr.Cells("Alicuota").Value.ToString())
   '         '08 - Precio Costo
   '         linea.PrecioCosto = New Reglas.ProductosSucursales()._GetUno(actual.Sucursal.IdSucursal, dr.Cells("IdProducto").Value.ToString().Trim()).PrecioCosto
   '         '09 - Precio Venta
   '         'linea.PrecioVenta = New Reglas.ProductosSucursales()._GetUno(actual.Sucursal.IdSucursal, dr.Cells("IdProducto").Value.ToString().Trim()).PrecioVenta
   '         linea.PrecioVenta = New Reglas.ProductosSucursales().GetPrecioVentaPredeterminado(actual.Sucursal.IdSucursal, dr.Cells("IdProducto").Value.ToString())
   '         '10 - Moneda
   '         linea.Moneda = New Reglas.Monedas().GetUna(dr.Cells("IdMoneda").Value.ToString()).NombreMoneda
   '         '11 - Codigo de Barras
   '         linea.CodigoDeBarras = dr.Cells("CodigoDeBarras").Value.ToString()

   '         Me._ProdWeb.Lineas.Add(linea)

   '      Next

   '   Catch ex As Exception
   '      Throw
   '   Finally
   '      Me.toolStripProgressBar1.Value = 0
   '      Me.toolStripProgressBar1.Visible = False
   '      Me.Cursor = Cursors.WaitCursor
   '   End Try
   'End Sub
#End Region
End Class