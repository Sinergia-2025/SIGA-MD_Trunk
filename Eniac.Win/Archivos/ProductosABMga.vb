Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual
'Imports Infragistics.Win.UltraWinDataSource
'Imports Infragistics.Win.UltraWinGrid
'Imports Infragistics.Win

Public Class ProductosABMga

#Region "Campos"
   'Private _ProdWeb As ProductosWeb
   Private _MostrarPrecios As Boolean
   Private _observacionesCompras As Boolean

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

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      'If estado = StateForm.Actualizar Then
      '   Return New ProductosDetalle(DirectCast(Me.GetEntidad(), Entidades.Producto))
      'End If
      'Return New ProductosDetalle(New Entidades.Producto())
      If Me._pantallaDetalle IsNot Nothing Then
         Me._pantallaDetalle.Dispose()
         Me._pantallaDetalle = Nothing
      End If
      Me._pantallaDetalle = New ProductosDetalle()
      If estado = StateForm.Actualizar Then
         Me._pantallaDetalle.SetEntidad(Me.GetEntidad())
      Else
         Me._pantallaDetalle.SetCreaEntidadNueva()
      End If

      Return Me._pantallaDetalle
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Me._reglas = New Reglas.Productos()
      Return Me._reglas
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Productos.rdlc", "SistemaDataSet_Productos", Me.dtDatos, parm, True)

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

      With Me.dgvDatos.SelectedCells(0).OwningRow
         Me._entiProducto = DirectCast(Me.GetReglas(), Reglas.Productos).GetUno(.Cells("IdProducto").Value.ToString().Trim(), blnIncluirFoto, True)
         Me._entiProducto.Usuario = actual.Sucursal.Usuario
      End With

      Return Me._entiProducto

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos

         .Columns("IdProducto").HeaderText = "Código"
         .Columns("IdProducto").Width = 100
         .Columns("IdProducto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("NombreProducto").HeaderText = "Nombre"
         .Columns("NombreProducto").Width = 370
         .Columns("NombreCorto").HeaderText = "Nombre Corto"
         .Columns("NombreCorto").Width = 200
         .Columns("Tamano").HeaderText = "Tamaño"
         .Columns("Tamano").Width = 50
         .Columns("Tamano").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns("Tamano").DefaultCellStyle.Format = "N2"
         .Columns("IdUnidadDeMedida").HeaderText = "U.M."
         .Columns("IdUnidadDeMedida").Width = 40
         .Columns("IdUnidadDeMedida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns("IdMarca").HeaderText = "Marca"
         .Columns("IdMarca").Width = 50
         .Columns("NombreMarca").HeaderText = "Nombre Marca"
         .Columns("NombreMarca").Width = 145

         If Publicos.ProductoTieneModelo Then
            .Columns("IdModelo").Visible = True
            .Columns("IdModelo").HeaderText = "Modelo"
            .Columns("IdModelo").Width = 50
            .Columns("NombreModelo").Visible = True
            .Columns("NombreModelo").HeaderText = "Nombre Modelo"
            .Columns("NombreModelo").Width = 145
         Else
            .Columns("IdModelo").Visible = False
            .Columns("NombreModelo").Visible = False
         End If

         .Columns("IdRubro").HeaderText = "Rubro"
         .Columns("IdRubro").Width = 50
         .Columns("NombreRubro").HeaderText = "Nombre Rubro"
         .Columns("NombreRubro").Width = 145

         If Publicos.ProductoTieneSubRubro Then
            .Columns("IdSubRubro").Visible = True
            .Columns("IdSubRubro").HeaderText = "SubRubro"
            .Columns("IdSubRubro").Width = 50
            .Columns("NombreSubRubro").Visible = True
            .Columns("NombreSubRubro").HeaderText = "Nombre SubRubro"
            .Columns("NombreSubRubro").Width = 145
         Else
            .Columns("IdSubRubro").Visible = False
            .Columns("NombreSubRubro").Visible = False
         End If

         .Columns("MesesGarantia").HeaderText = "Meses Garantia"
         .Columns("MesesGarantia").Width = 60
         .Columns("IdTipoImpuesto").HeaderText = "Tipo Imp"
         .Columns("IdTipoImpuesto").Width = 40
         .Columns("IdTipoImpuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         .Columns("Alicuota").HeaderText = "Alicuota"
         .Columns("Alicuota").Width = 50
         .Columns("Alicuota").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         If Publicos.ProductoUtilizaAlicuota2 Then
            .Columns("Alicuota2").HeaderText = "Alicuota 2"
            .Columns("Alicuota2").Width = 50
            .Columns("Alicuota2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         Else
            .Columns("Alicuota2").Visible = False
         End If


         .Columns("AfectaStock").HeaderText = "Afecta Stock"
         .Columns("AfectaStock").Width = 50

         .Columns(Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString()).HeaderText = "Modifica Descripc."
         .Columns(Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString()).Width = 60
         '.Columns(Entidades.Producto.Columnas.PermiteModificarDescripcion.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


         .Columns("Lote").HeaderText = "Lote"
         .Columns("Lote").Width = 40

         '.Columns("NroSerie").Visible = False
         .Columns("NroSerie").HeaderText = "Nro. Serie"
         .Columns("NroSerie").Width = 40

         .Columns("CodigoDeBarras").Visible = Publicos.ProductoUtilizaCodigoDeBarras
         .Columns("CodigoDeBarras").HeaderText = "Codigo de Barras"
         .Columns("CodigoDeBarras").Width = 100
         .Columns("CodigoDeBarras").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Producto.Columnas.CodigoDeBarrasConPrecio.ToString()).HeaderText = "C.B. Precio"
         .Columns(Entidades.Producto.Columnas.CodigoDeBarrasConPrecio.ToString()).Width = 70
         .Columns(Entidades.Producto.Columnas.CodigoDeBarrasConPrecio.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("EsServicio").HeaderText = "Es Servicio"
         .Columns("EsServicio").Width = 70
         .Columns("EsServicio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("PublicarEnWeb").HeaderText = "Publicar En Web"
         .Columns("PublicarEnWeb").Width = 70
         .Columns("PublicarEnWeb").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("Observacion").HeaderText = "Observación y/o Detalle Técnico"
         .Columns("Observacion").Width = 300

         .Columns("Activo").HeaderText = "Activo"
         .Columns("Activo").Width = 40

         If Publicos.TieneModuloProduccion Then
            .Columns("EsCompuesto").HeaderText = "Compuesto"
            .Columns("EsCompuesto").Width = 70
            .Columns("EsCompuesto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("DescontarStockComponentes").HeaderText = "Desc. stock Componentes"
            .Columns("DescontarStockComponentes").Width = 80
            .Columns("DescontarStockComponentes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         Else
            .Columns("EsCompuesto").Visible = False
            .Columns("DescontarStockComponentes").Visible = False
         End If

         .Columns("EsDeCompras").HeaderText = "De Compras"
         .Columns("EsDeCompras").Width = 70
         .Columns("EsDeCompras").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("EsDeVentas").HeaderText = "De Ventas"
         .Columns("EsDeVentas").Width = 70
         .Columns("EsDeVentas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("IdMoneda").Visible = False

         .Columns("NombreMoneda").HeaderText = "Moneda"
         .Columns("NombreMoneda").Width = 70

         .Columns("AlertaDeCaja").HeaderText = "Alerta de Caja"
         .Columns("AlertaDeCaja").Width = 100
         .Columns("AlertaDeCaja").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         If Publicos.TieneModuloAlquiler Then
            .Columns(Entidades.Producto.Columnas.EsAlquilable.ToString()).HeaderText = "Alquilable"
            .Columns(Entidades.Producto.Columnas.EsAlquilable.ToString()).Width = 60
            .Columns(Entidades.Producto.Columnas.EsAlquilable.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(Entidades.Producto.Columnas.EquipoMarca.ToString()).HeaderText = "Equipo Marca"
            .Columns(Entidades.Producto.Columnas.EquipoMarca.ToString()).Width = 150
            .Columns(Entidades.Producto.Columnas.EquipoModelo.ToString()).HeaderText = "Equipo Modelo"
            .Columns(Entidades.Producto.Columnas.EquipoModelo.ToString()).Width = 150
            .Columns(Entidades.Producto.Columnas.NumeroSerie.ToString()).HeaderText = "Nro. Serie"
            .Columns(Entidades.Producto.Columnas.NumeroSerie.ToString()).Width = 200
            '.Columns(Entidades.Producto.Columnas.CaractSII.ToString()).HeaderText = "Caraterísticas"
            '.Columns(Entidades.Producto.Columnas.CaractSII.ToString()).Width = 200
            .Columns(Entidades.Producto.Columnas.CaractSII.ToString()).Visible = False
            .Columns(Entidades.Producto.Columnas.Anio.ToString()).HeaderText = "Año"
            .Columns(Entidades.Producto.Columnas.Anio.ToString()).Width = 40
            .Columns(Entidades.Producto.Columnas.Anio.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
         Else
            .Columns(Entidades.Producto.Columnas.EsAlquilable.ToString()).Visible = False
            .Columns(Entidades.Producto.Columnas.EquipoMarca.ToString()).Visible = False
            .Columns(Entidades.Producto.Columnas.EquipoModelo.ToString()).Visible = False
            .Columns(Entidades.Producto.Columnas.NumeroSerie.ToString()).Visible = False
            .Columns(Entidades.Producto.Columnas.CaractSII.ToString()).Visible = False
            .Columns(Entidades.Producto.Columnas.Anio.ToString()).Visible = False
         End If

         .Columns(Entidades.Producto.Columnas.PagaIngresosBrutos.ToString()).HeaderText = "Paga IIBB"
         .Columns(Entidades.Producto.Columnas.PagaIngresosBrutos.ToString()).Width = 70

         .Columns(Entidades.Producto.Columnas.Embalaje.ToString()).HeaderText = "Embalaje"
         .Columns(Entidades.Producto.Columnas.Embalaje.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.Embalaje.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Producto.Columnas.Kilos.ToString()).HeaderText = "Kilos"
         .Columns(Entidades.Producto.Columnas.Kilos.ToString()).Width = 70
         .Columns(Entidades.Producto.Columnas.Kilos.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.Kilos.ToString()).DefaultCellStyle.Format = "N3"

         .Columns(Entidades.Producto.Columnas.IdFormula.ToString()).Visible = False

         .Columns(Entidades.Producto.Columnas.IdProductoMercosur.ToString()).HeaderText = "Cod. Prod. Mercosur"
         .Columns(Entidades.Producto.Columnas.IdProductoMercosur.ToString()).Width = 70

         .Columns(Entidades.Producto.Columnas.IdProductoSecretaria.ToString()).HeaderText = "Cod. Prod. Secretaria"
         .Columns(Entidades.Producto.Columnas.IdProductoSecretaria.ToString()).Width = 70

         .Columns(Entidades.Producto.Columnas.PublicarListaDePreciosClientes.ToString()).HeaderText = "L.P.Clientes"
         .Columns(Entidades.Producto.Columnas.PublicarListaDePreciosClientes.ToString()).Width = 70

         .Columns(Entidades.Producto.Columnas.FacturacionCantidadNegativa.ToString()).HeaderText = "Fact.Cant.Neg."
         .Columns(Entidades.Producto.Columnas.FacturacionCantidadNegativa.ToString()).Width = 70

         .Columns(Entidades.Producto.Columnas.Orden.ToString()).HeaderText = "Orden"
         .Columns(Entidades.Producto.Columnas.Orden.ToString()).Width = 70

         .Columns(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).HeaderText = "Código Largo"
         'GAR: 12/10/2017 - PEndiente!!
         '.Columns(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).Header.VisiblePosition = 1
         .Columns(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).Width = 150
         .Columns(Entidades.Producto.Columnas.CodigoLargoProducto.ToString()).Visible = Publicos.ProductoUtilizaCodigoLargo

         .Columns(Entidades.Producto.Columnas.IdProveedor.ToString()).Visible = False

         .Columns(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()).HeaderText = "P. H."
         .Columns(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()).Width = 80
         .Columns(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).HeaderText = "Proveedor Habitual"
         .Columns(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).Width = 150

         .Columns(Entidades.Producto.Columnas.UnidHasta1.ToString()).HeaderText = "Unid. 1"
         .Columns(Entidades.Producto.Columnas.UnidHasta1.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UnidHasta1.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

         .Columns(Entidades.Producto.Columnas.UnidHasta1.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UHPorc1.ToString()).HeaderText = "Desc.% 1"
         .Columns(Entidades.Producto.Columnas.UHPorc1.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UHPorc1.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UHPorc1.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UnidHasta2.ToString()).HeaderText = "Unid. 2"
         .Columns(Entidades.Producto.Columnas.UnidHasta2.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UnidHasta2.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UnidHasta2.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UHPorc2.ToString()).HeaderText = "Desc.% 2 "
         .Columns(Entidades.Producto.Columnas.UHPorc2.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UHPorc2.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UHPorc2.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UnidHasta3.ToString()).HeaderText = "Unid. 3"
         .Columns(Entidades.Producto.Columnas.UnidHasta3.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UnidHasta3.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UnidHasta3.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UHPorc3.ToString()).HeaderText = "Desc.% 3"
         .Columns(Entidades.Producto.Columnas.UHPorc3.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UHPorc3.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UHPorc3.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UnidHasta4.ToString()).HeaderText = "Unid. 4"
         .Columns(Entidades.Producto.Columnas.UnidHasta4.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UnidHasta4.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UnidHasta4.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UHPorc4.ToString()).HeaderText = "Desc.% 4"
         .Columns(Entidades.Producto.Columnas.UHPorc4.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UHPorc4.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UHPorc4.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UnidHasta5.ToString()).HeaderText = "Unid. 5"
         .Columns(Entidades.Producto.Columnas.UnidHasta5.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UnidHasta5.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UnidHasta5.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.UHPorc5.ToString()).HeaderText = "Desc.% 5"
         .Columns(Entidades.Producto.Columnas.UHPorc5.ToString()).Width = 60
         .Columns(Entidades.Producto.Columnas.UHPorc5.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.UHPorc5.ToString()).DefaultCellStyle.Format = "N2"

         .Columns(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).HeaderText = "Cta Compra"
         .Columns(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).Width = 90
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Compras").HeaderText = "Nombre Cuenta Compras"
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Compras").Width = 280

         .Columns(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).HeaderText = "Cta Venta"
         .Columns(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).Width = 90
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Ventas").HeaderText = "Nombre Cuenta Ventas"
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Ventas").Width = 280

         .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).HeaderText = "Cta Compras Sec."
         .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).Width = 90
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").HeaderText = "Nombre Cuenta Compras Secundaria"
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").Width = 280

         .Columns(Entidades.Producto.Columnas.IdCentroCosto.ToString()).Visible = False
         '.Columns(Entidades.Producto.Columnas.IdCentroCosto.ToString()).HeaderText = "C.C."
         '.Columns(Entidades.Producto.Columnas.IdCentroCosto.ToString()).Width = 90
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).HeaderText = "Centro de Costos"
         .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Width = 120

         If Not Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Producto.Columnas.IdCuentaCompras.ToString()).Visible = False
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Compras").Visible = False
            .Columns(Entidades.Producto.Columnas.IdCuentaVentas.ToString()).Visible = False
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "Ventas").Visible = False
            .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).Visible = False
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").Visible = False
            .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Visible = False
         Else
            If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto Then
               .Columns(Entidades.Producto.Columnas.IdCuentaComprasSecundaria.ToString()).Visible = False
               .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString() + "ComprasSecundaria").Visible = False
            End If

            If Not Reglas.ContabilidadPublicos.UtilizaCentroCostos Then
               .Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Visible = False
            End If
         End If

         .Columns(Entidades.Producto.Columnas.ImporteImpuestoInterno.ToString()).HeaderText = "Imp. Interno"
         .Columns(Entidades.Producto.Columnas.ImporteImpuestoInterno.ToString()).Width = 90
         .Columns(Entidades.Producto.Columnas.ImporteImpuestoInterno.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.Producto.Columnas.ImporteImpuestoInterno.ToString()).DefaultCellStyle.Format = "N2"

         .Columns("EsOferta").HeaderText = "Es Oferta"
         .Columns("EsOferta").Width = 60
         .Columns("EsOferta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns(Entidades.Producto.Columnas.IncluirExpensas.ToString()).HeaderText = "Incl. Exp."
         .Columns(Entidades.Producto.Columnas.IncluirExpensas.ToString()).Width = 60

         .Columns(Entidades.Producto.Columnas.IncluirExpensas.ToString()).Visible = Publicos.TieneModuloExpensas

         Dim rUsuario As Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me._MostrarPrecios = rUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Productos", "Productos-MostrarPrecios")
         _observacionesCompras = rUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "Compras", "MovimientosDeCompras")

         .Columns("FechaActualizacion").HeaderText = "Ult. Actualizacion"
         .Columns("FechaActualizacion").Width = 100
         .Columns("FechaActualizacion").Visible = Me._MostrarPrecios
         .Columns("FechaActualizacion").DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"
         .Columns("FechaActualizacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

         .Columns("ObservacionCompras").HeaderText = "Observación de Compras"
         .Columns("ObservacionCompras").Width = 300
         .Columns("ObservacionCompras").Visible = Me._observacionesCompras

         .Columns(Entidades.Producto.Columnas.SolicitaPrecioVentaPorTamano.ToString()).HeaderText = "Solic. Precio x Tamaño"
         .Columns(Entidades.Producto.Columnas.SolicitaPrecioVentaPorTamano.ToString()).Width = 70
         .Columns(Entidades.Producto.Columnas.SolicitaPrecioVentaPorTamano.ToString()).Visible = Publicos.TieneModuloProduccion
      End With

   End Sub

#End Region

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

End Class
