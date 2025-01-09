Option Strict On
Option Explicit On
Public Class SincronizacionSubida

   Private _publicos As Publicos

   Private _clientes As List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)
   Private _productos As List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte)
   Private _productosSucursales As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte)
   Private _productosSucursalesPrecios As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte)

   Private _localidades As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)
   Private _rubros As List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)
   Private _subRubros As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)
   Private _subSubRubros As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)

   Private _marcas As List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte)

   Private _rubrosCompras As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte)

   Private _proveedores As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte)

   Private _clientesPaginas As List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte())
   Private _productosPaginas As List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte())
   Private _productosSucursalesPaginas As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte())
   Private _productosSucursalesPreciosPaginas As List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte())

   Private _localidadesPaginas As List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte())
   Private _rubrosPaginas As List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte())
   Private _subRubrosPaginas As List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte())
   Private _subSubRubrosPaginas As List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte())

   Private _marcasPaginas As List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte())

   Private _rubrosComprasPaginas As List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte())

   Private _proveedoresPaginas As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte())

   Private _fechaClientes As DateTime?
   Private _fechaProductos As DateTime?
   Private _fechaProductosSucursales As DateTime?
   Private _fechaProductosSucursalesPrecios As DateTime?
   Private _fechaLocalidades As DateTime?
   Private _fechaRubros As DateTime?
   Private _fechaSubRubros As DateTime?
   Private _fechaSubSubRubros As DateTime?


   Public Sub New()
      InitializeComponent()
      _clientes = New List(Of Entidades.JSonEntidades.Archivos.ClienteJSonTransporte)()
      _productos = New List(Of Entidades.JSonEntidades.Archivos.ProductoJSonTransporte)()
      _productosSucursales = New List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSonTransporte)()
      _productosSucursalesPrecios = New List(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSonTransporte)()
      _localidades = New List(Of Entidades.JSonEntidades.Archivos.LocalidadJSonTransporte)()
      _rubros = New List(Of Entidades.JSonEntidades.Archivos.RubroJSonTransporte)()
      _subRubros = New List(Of Entidades.JSonEntidades.Archivos.SubRubroJSonTransporte)()
      _subSubRubros = New List(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSonTransporte)()
      _marcas = New List(Of Entidades.JSonEntidades.Archivos.MarcaJSonTransporte)()
      _rubrosCompras = New List(Of Entidades.JSonEntidades.Archivos.RubroCompraJSonTransporte)()
      _proveedores = New List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte)()

   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbProductosPublicarEnWeb, GetType(Entidades.Publicos.SiNoTodos))
         cmbProductosPublicarEnWeb.SelectedValue = Reglas.Publicos.WebArchivos.Productos.PublicarEnWeb
         chbProductosIncluirImagenes.Checked = Reglas.Publicos.WebArchivos.Productos.IncluirImagenes

         RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub
#End Region

#Region "Eventos"
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarDatosGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbExportar_Click(sender As Object, e As EventArgs) Handles tsbExportar.Click
      Try
         Cursor = Cursors.WaitCursor
         tsbRefrescar.Enabled = False
         tsbExportar.Enabled = False
         tsbContinuar.Enabled = False
         chbClientes.Enabled = False
         chbProductos.Enabled = False
         chbLocalidades.Enabled = False
         chbRubros.Enabled = False
         chbMarcas.Enabled = False
         chbRubrosCompras.Enabled = False
         chbProveedores.Enabled = False
         btnConsultar.Enabled = False

         Dim _inicioExportarDatos As DateTime = Now

         'Dim fechaActualizacion As DateTime? = Nothing
         'If Not chbReenviarTodo.Checked Then
         '   fechaActualizacion = dtpFechaActualizacionDesde.Value
         'End If

         ExportarDatos(False)

         Dim tiempo As TimeSpan = Now.Subtract(_inicioExportarDatos)

         Dim mensajeExitoso As String = String.Format("Envio de información realizado exitosamente. Tiempo transcurrido: {0:00}:{1:00}:{2:00}", tiempo.Hours, tiempo.Minutes, tiempo.Seconds)
         ShowMessage(mensajeExitoso)
         tssInfo.Text = mensajeExitoso

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default

         tsbRefrescar.Enabled = True
         tsbExportar.Enabled = True
         tsbContinuar.Enabled = True
         chbClientes.Enabled = True
         chbProductos.Enabled = True
         chbLocalidades.Enabled = True
         chbRubros.Enabled = True
         chbMarcas.Enabled = True
         chbRubrosCompras.Enabled = True
         chbProveedores.Enabled = True
         HabilitaBotonConsultar()
      End Try
   End Sub

   Private Sub tsbContinuar_Click(sender As Object, e As EventArgs) Handles tsbContinuar.Click
      Try
         Cursor = Cursors.WaitCursor
         tsbRefrescar.Enabled = False
         tsbExportar.Enabled = False
         tsbContinuar.Enabled = False
         chbClientes.Enabled = False
         chbProductos.Enabled = False
         chbLocalidades.Enabled = False
         chbRubros.Enabled = False
         chbMarcas.Enabled = False
         chbRubrosCompras.Enabled = False
         chbProveedores.Enabled = False
         btnConsultar.Enabled = False

         Dim _inicioExportarDatos As DateTime = Now

         'Dim fechaActualizacion As DateTime? = Nothing
         'If Not chbReenviarTodo.Checked Then
         '   fechaActualizacion = dtpFechaActualizacionDesde.Value
         'End If

         ExportarDatos(True)

         Dim tiempo As TimeSpan = Now.Subtract(_inicioExportarDatos)

         Dim mensajeExitoso As String = String.Format("Envio de información realizado exitosamente. Tiempo transcurrido: {0:00}:{1:00}:{2:00}", tiempo.Hours, tiempo.Minutes, tiempo.Seconds)
         ShowMessage(mensajeExitoso)
         tssInfo.Text = mensajeExitoso

      Catch ex As Exception
         ShowError(ex)
      Finally
         Cursor = Cursors.Default

         tsbRefrescar.Enabled = True
         tsbExportar.Enabled = True
         tsbContinuar.Enabled = True
         chbClientes.Enabled = True
         chbProductos.Enabled = True
         chbLocalidades.Enabled = True
         chbRubros.Enabled = True
         chbMarcas.Enabled = True
         chbRubrosCompras.Enabled = True
         chbProveedores.Enabled = True
         HabilitaBotonConsultar()
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
#End Region
#Region "Eventos Filtros"
   Private Sub chbClientes_CheckedChanged(sender As Object, e As EventArgs) Handles chbClientes.CheckedChanged
      HabilitaBotonConsultar()
      'MostrarFechas()
      lblCantidadClientes.Visible = chbClientes.Checked
   End Sub

   Private Sub chbProductos_CheckedChanged(sender As Object, e As EventArgs) Handles chbProductos.CheckedChanged
      HabilitaBotonConsultar()
      'MostrarFechas()
      lblCantidadProductos.Visible = chbProductos.Checked
      lblCantidadProductosSucursales.Visible = chbProductos.Checked
      lblCantidadProductosSucursalesPrecios.Visible = chbProductos.Checked
   End Sub

   Private Sub chbLocalidades_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidades.CheckedChanged
      HabilitaBotonConsultar()
      'MostrarFechas()
      lblCantidadLocalidades.Visible = chbLocalidades.Checked
   End Sub

   Private Sub chbRubros_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubros.CheckedChanged, chbMarcas.CheckedChanged
      HabilitaBotonConsultar()
      'MostrarFechas()
      lblCantidadRubros.Visible = chbRubros.Checked
      lblCantidadSubRubros.Visible = chbRubros.Checked
      lblCantidadSubSubRubros.Visible = chbRubros.Checked
   End Sub

   Private Sub chbMarcas_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarcas.CheckedChanged
      HabilitaBotonConsultar()
      'MostrarFechas()
      lblCantidadMarcas.Visible = chbMarcas.Checked
   End Sub

#End Region

   Private Sub CantidadesACero()
      MuestraCantidadRegistros(lblCantidadClientes, 0, lblClienteTotalPaginas, 0)
      MuestraCantidadRegistros(lblCantidadProductos, 0, lblProductosTotalPaginas, 0)
      MuestraCantidadRegistros(lblCantidadProductosSucursales, 0, lblProductosSucursalesTotalPaginas, 0)
      MuestraCantidadRegistros(lblCantidadProductosSucursalesPrecios, 0, lblProductosSucursalesPreciosTotalPaginas, 0)

      MuestraCantidadRegistros(lblCantidadLocalidades, 0, lblLocalidadesTotalPaginas, 0)
      MuestraCantidadRegistros(lblCantidadRubros, 0, lblRubrosTotalPaginas, 0)
      MuestraCantidadRegistros(lblCantidadSubRubros, 0, lblSubRubrosTotalPaginas, 0)
      MuestraCantidadRegistros(lblCantidadSubSubRubros, 0, lblSubSubRubrosTotalPaginas, 0)

      MuestraCantidadRegistros(lblCantidadMarcas, 0, lblMarcasTotalPaginas, 0)

      MuestraPaginaActual(lblClientePaginaActual, 0)
      MuestraPaginaActual(lblProductosPaginaActual, 0)
      MuestraPaginaActual(lblProductosSucursalesPaginaActual, 0)
      MuestraPaginaActual(lblProductosSucursalesPreciosPaginaActual, 0)
      MuestraPaginaActual(lblLocalidadesPaginaActual, 0)
      MuestraPaginaActual(lblRubrosPaginaActual, 0)
      MuestraPaginaActual(lblSubRubrosPaginaActual, 0)
      MuestraPaginaActual(lblSubSubRubrosPaginaActual, 0)
      MuestraPaginaActual(lblMarcasPaginaActual, 0)
      MuestraPaginaActual(lblRubrosComprasPaginaActual, 0)
      MuestraPaginaActual(lblProveedoresPaginaActual, 0)
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         'Dim rClientes As Reglas.Clientes = New Reglas.Clientes()
         'Dim rProductos As Reglas.Productos = New Reglas.Productos()
         'Dim rProductosSucursales As Reglas.ProductosSucursales = New Reglas.ProductosSucursales()
         'Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         'Dim datetime As DateTime? = Nothing
         'System.IO.File.WriteAllText("c:\temp\_json\export\clientes_nuevo.json", serializer.Serialize(rClientes.GetClientesJSonTransporte(datetime, Entidades.Cliente.ModoClienteProspecto.Cliente)))
         'System.IO.File.WriteAllText("c:\temp\_json\export\productos_nuevo.json", serializer.Serialize(rProductos.GetProductosJSonTransporte(datetime)))
         'System.IO.File.WriteAllText("c:\temp\_json\export\productossucursales_nuevo.json", serializer.Serialize(rProductosSucursales.GetProductosSucursalesJSonTransporte(datetime)))
         'System.IO.File.WriteAllText("c:\temp\_json\export\productossucursalesprecios_nuevo.json", serializer.Serialize(rProductosSucursales.GetProductosSucursalesPreciosJSonTransporte(datetime)))


         Cursor = Cursors.WaitCursor
         Me.btnConsultar.Enabled = False
         Me.chbClientes.Enabled = False
         Me.chbProductos.Enabled = False
         Me.chbLocalidades.Enabled = False
         Me.chbRubros.Enabled = False
         Me.chbMarcas.Enabled = False
         Me.chbRubrosCompras.Enabled = False
         Me.chbProveedores.Enabled = False

         Me.tssRegistros.Text = ""

         Me.CantidadesACero()

         'Dim fechaActualizacion As DateTime? = Nothing
         'If Not chbReenviarTodo.Checked Then
         '   fechaActualizacion = dtpFechaActualizacionDesde.Value
         'End If

         Me.ObtieneClientes()
         Me.ObtieneProductos()
         Me.ObtieneLocalidades()
         Me.ObtieneRubros()
         Me.ObtenerMarcas()
         Me.ObtenerRubrosCompras()
         Me.ObtenerProveedores()

         Dim registros As Long = _clientes.Count + _productos.Count + _productosSucursales.Count + _productosSucursalesPrecios.Count + _
                                 _localidades.Count + _rubros.Count + _subRubros.Count + _subSubRubros.Count + _marcas.Count + _rubrosCompras.Count + _proveedores.Count
         Me.tssRegistros.Text = String.Format("{0} Registros", registros)

         Me.tsbExportar.Enabled = registros <> 0
         'dtpFechaActualizacionDesde.Enabled = False
         'chbReenviarTodo.Enabled = False

         Me.tssInfo.Text = String.Format("Listo para sincronizar {0} registros.", registros)
      Catch ex As Exception
         Me.tssRegistros.Text = String.Format("0 Registros")
         _clientes.Clear()
         _productos.Clear()
         _productosSucursales.Clear()
         _productosSucursalesPrecios.Clear()
         _localidades.Clear()
         _rubros.Clear()
         _subRubros.Clear()
         _subSubRubros.Clear()
         _marcas.Clear()
         _rubrosCompras.Clear()
         _proveedores.Clear()
         tssInfo.Text = String.Format("Error obteniedo información: {0}. Reintente.", ex.Message)
         ShowError(ex)
      Finally
         Cursor = Cursors.Default
         HabilitaBotonConsultar()
         chbClientes.Enabled = True
         chbProductos.Enabled = True
         chbLocalidades.Enabled = True
         chbRubros.Enabled = True
         chbMarcas.Enabled = True
         chbRubrosCompras.Enabled = True
         chbProveedores.Enabled = True
      End Try
   End Sub
#End Region

#Region "Metodos"
   Public Sub RefrescarDatosGrilla()

      _clientes.Clear()
      _productos.Clear()
      _productosSucursales.Clear()
      _productosSucursalesPrecios.Clear()
      _localidades.Clear()
      _rubros.Clear()
      _subRubros.Clear()
      _subSubRubros.Clear()
      _marcas.Clear()
      _rubrosCompras.Clear()
      _proveedores.Clear()


      Me.chbClientes.Checked = Reglas.Publicos.ClientesSubirALaWeb
      Me.chbClientes.Enabled = Me.chbClientes.Checked

      Me.chbProductos.Checked = Reglas.Publicos.ProductosSubirALaWeb
      Me.chbProductos.Enabled = Me.chbProductos.Checked

      Me.chbRubros.Checked = Reglas.Publicos.RubrosSubirALaWeb
      Me.chbRubros.Enabled = Me.chbRubros.Checked

      Me.chbMarcas.Checked = Reglas.Publicos.MarcasSubirALaWeb
      Me.chbMarcas.Enabled = Me.chbMarcas.Checked

      Me.chbLocalidades.Checked = Reglas.Publicos.LocalidadesSubirALaWeb
      Me.chbLocalidades.Enabled = Me.chbLocalidades.Checked

      Me.chbProveedores.Checked = Reglas.Publicos.ProveedoresSubirALaWeb
      Me.chbProveedores.Enabled = Me.chbProveedores.Checked

      Me.chbRubrosCompras.Checked = Reglas.Publicos.RubrosComprasSubirALaWeb
      Me.chbRubrosCompras.Enabled = Me.chbRubrosCompras.Checked

      CantidadesACero()

      _fechaClientes = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.ClienteJSon)("Clientes", Reglas.Publicos.WebArchivos.Clientes.UrlGETMaxFecha) 'http://localhost:14209/api/cliente/max
      _fechaProductos = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.ProductoJSon)("Productos", Reglas.Publicos.WebArchivos.Productos.UrlGETMaxFecha)
      _fechaProductosSucursales = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.ProductoSucursalJSon)("Stock", Reglas.Publicos.WebArchivos.ProductosSucursales.UrlGETMaxFecha)
      _fechaProductosSucursalesPrecios = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.ProductoSucursalPrecioJSon)("Precios", Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlGETMaxFecha)
      _fechaLocalidades = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.LocalidadJSon)("Localidades", Reglas.Publicos.WebArchivos.Localidades.UrlGETMaxFecha)
      _fechaRubros = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.RubroJSon)("Rubros", Reglas.Publicos.WebArchivos.Rubros.UrlGETMaxFecha)
      _fechaSubRubros = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.SubRubroJSon)("SubRubros", Reglas.Publicos.WebArchivos.SubRubros.UrlGETMaxFecha)
      _fechaSubSubRubros = ObtenerFechaMaxima(Of Entidades.JSonEntidades.Archivos.SubSubRubroJSon)("SubSubRubros", Reglas.Publicos.WebArchivos.SubSubRubros.UrlGETMaxFecha)


      'lblFechaClientes.Tag = fechaClientes
      'lblFechaProductos.Tag = fechaProductos
      'lblFechaProductosSucursales.Tag = fechaProductosSucursales
      'lblFechaProductosSucursalesPrecios.Tag = fechaProductosSucursalesPrecios
      'lblFechaLocalidades.Tag = fechaLocalidades
      'lblFechaRubros.Tag = fechaRubros
      'lblFechaSubRubros.Tag = fechaSubRubros
      'lblFechaSubSubRubros.Tag = fechaSubSubRubros

      MostrarFechas()

      tsbExportar.Enabled = False
      tssInfo.Text = ""
      tssRegistros.Text = String.Format("0 Registros")
      HabilitaBotonConsultar()

   End Sub

   Private Sub MostrarFechas()
      MostrarFechas(_fechaClientes, dtpClientes, chbTodosClientes)
      MostrarFechas(_fechaProductos, dtpProductos, chbTodosProductos)
      MostrarFechas(_fechaProductosSucursales, dtpProductosSucursales, chbTodosProductosSucursales)
      MostrarFechas(_fechaProductosSucursalesPrecios, dtpProductosSucursalesPrecios, chbTodosProductosSucursalesPrecios)

      MostrarFechas(_fechaLocalidades, dtpLocalidades, chbTodosLocalidades)
      MostrarFechas(_fechaRubros, dtpRubros, chbTodosRubros)
      MostrarFechas(_fechaSubRubros, dtpSubRubros, chbTodosSubRubros)
      MostrarFechas(_fechaSubSubRubros, dtpSubSubRubros, chbTodosSubSubRubros)
   End Sub

   Private Sub MostrarFechas(fecha As DateTime?, dtp As DateTimePicker, chb As CheckBox)
      chb.Checked = Not fecha.HasValue
      If fecha.HasValue Then
         dtp.Value = fecha.Value
      Else
         dtp.Value = New Date(1900, 1, 1, 0, 0, 0)
      End If
   End Sub

   Private Sub MostrarInfo(texto As String)
      tssInfo.Text = texto
      Application.DoEvents()
   End Sub

   Private Sub ObtieneClientes()
      MostrarInfo("Obteniendo Clientes para sincronizar...")

      If chbClientes.Checked Then
         _clientes = New Reglas.Clientes().GetClientesJSonTransporte(FechaActualizacion(chbTodosClientes, dtpClientes), Entidades.Cliente.ModoClienteProspecto.Cliente)
         _clientesPaginas = PaginarDatos(_clientes, Reglas.Publicos.WebArchivos.Clientes.TamanoPaginaPost)
      ElseIf _clientes IsNot Nothing Then
         _clientes.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadClientes, _clientes.Count, lblClienteTotalPaginas, ContarRegistros(_clientesPaginas))
   End Sub

   Private Sub ObtieneLocalidades()
      MostrarInfo("Obteniendo Localidades para sincronizar...")
      If chbLocalidades.Checked Then
         _localidades = New Reglas.Localidades().GetLocalidadesJSonTransporte(FechaActualizacion(chbTodosLocalidades, dtpLocalidades))
         _localidadesPaginas = PaginarDatos(_localidades, Reglas.Publicos.WebArchivos.Localidades.TamanoPaginaPost)
      ElseIf _localidades IsNot Nothing Then
         _localidades.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadLocalidades, _localidades.Count, lblLocalidadesTotalPaginas, ContarRegistros(_localidadesPaginas))
   End Sub

   Private Function ContarRegistros(Of T)(lista As List(Of T)) As Integer
      If lista Is Nothing Then Return 0
      Return lista.Count
   End Function

   Private Sub ObtieneProductos()
      MostrarInfo("Obteniendo Productos para sincronizar...")
      Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros()
      publicarEn.SincronizacionSucursal = DirectCast(cmbProductosPublicarEnWeb.SelectedValue, Entidades.Publicos.SiNoTodos)
      If chbProductos.Checked Then
         _productos = New Reglas.Productos().GetProductosJSonTransporte(FechaActualizacion(chbTodosProductos, dtpProductos), publicarEn)
         _productosPaginas = PaginarDatos(_productos, Reglas.Publicos.WebArchivos.Productos.TamanoPaginaPost)
      Else
         _productos.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadProductos, _productos.Count, lblProductosTotalPaginas, ContarRegistros(_productosPaginas))

      MostrarInfo("Obteniendo Stocks para sincronizar...")
      If chbProductos.Checked Then
         _productosSucursales = New Reglas.ProductosSucursales().GetProductosSucursalesJSonTransporte(FechaActualizacion(chbTodosProductosSucursales, dtpProductosSucursales), publicarEn)
         _productosSucursalesPaginas = PaginarDatos(_productosSucursales, Reglas.Publicos.WebArchivos.ProductosSucursales.TamanoPaginaPost)
      Else
         _productosSucursales.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadProductosSucursales, _productosSucursales.Count, lblProductosSucursalesTotalPaginas, ContarRegistros(_productosSucursalesPaginas))

      MostrarInfo("Obteniendo Precios para sincronizar...")
      If chbProductos.Checked Then
         _productosSucursalesPrecios = New Reglas.ProductosSucursalesPrecios().GetProductosSucursalesPreciosJSonTransporte(FechaActualizacion(chbTodosProductosSucursalesPrecios, dtpProductosSucursalesPrecios),
                                                                                                                           publicarEn, Entidades.Publicos.SiNoTodos.SI)
         _productosSucursalesPreciosPaginas = PaginarDatos(_productosSucursalesPrecios, Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.TamanoPaginaPost)
      Else
         _productosSucursalesPrecios.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadProductosSucursalesPrecios, _productosSucursalesPrecios.Count, lblProductosSucursalesPreciosTotalPaginas, ContarRegistros(_productosSucursalesPreciosPaginas))
   End Sub

   Private Sub ObtieneRubros()
      MostrarInfo("Obteniendo Rubros para sincronizar...")
      If chbRubros.Checked Then
         _rubros = New Reglas.Rubros().GetRubrosJSonTransporte(FechaActualizacion(chbTodosRubros, dtpRubros))
         _rubrosPaginas = PaginarDatos(_rubros, Reglas.Publicos.WebArchivos.Rubros.TamanoPaginaPost)
      Else
         _rubros.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadRubros, _rubros.Count, lblRubrosTotalPaginas, ContarRegistros(_rubrosPaginas))

      MostrarInfo("Obteniendo SubRubros para sincronizar...")
      If chbRubros.Checked Then
         _subRubros = New Reglas.SubRubros().GetSubRubrosJSonTransporte(FechaActualizacion(chbTodosSubRubros, dtpSubRubros))
         _subRubrosPaginas = PaginarDatos(_subRubros, Reglas.Publicos.WebArchivos.SubRubros.TamanoPaginaPost)
      Else
         _subRubros.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadSubRubros, _subRubros.Count, lblSubRubrosTotalPaginas, ContarRegistros(_subRubrosPaginas))

      MostrarInfo("Obteniendo SubSubRubros para sincronizar...")
      If chbRubros.Checked Then
         _subSubRubros = New Reglas.SubSubRubros().GetSubSubSubRubrosJsonTransporte(FechaActualizacion(chbTodosSubSubRubros, dtpSubSubRubros))
         _subSubRubrosPaginas = PaginarDatos(_subSubRubros, Reglas.Publicos.WebArchivos.SubSubRubros.TamanoPaginaPost)
      Else
         _subSubRubros.Clear()
      End If
      MuestraCantidadRegistros(lblCantidadSubSubRubros, _subSubRubros.Count, lblSubSubRubrosTotalPaginas, ContarRegistros(_subSubRubrosPaginas))
   End Sub

   Private Sub ObtenerMarcas()
      MostrarInfo("Obteniendo Marcas para sincronizar...")
      If chbMarcas.Checked Then
         _marcas = New Reglas.Marcas().GetMarcasJSonTransporte()
         _marcasPaginas = PaginarDatos(_marcas, Reglas.Publicos.WebArchivos.SubSubRubros.TamanoPaginaPost)
      Else
         _marcas.Clear()
      End If

      'Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
      'System.IO.File.WriteAllText("c:\temp\_json\export\marcas_nuevo.json", serializer.Serialize(_marcasPaginas))

      MuestraCantidadRegistros(lblCantidadMarcas, _marcas.Count, lblMarcasTotalPaginas, ContarRegistros(_marcasPaginas))
   End Sub

   Private Sub ObtenerRubrosCompras()
      MostrarInfo("Obteniendo Rubros Compras para sincronizar...")
      If chbRubrosCompras.Checked Then
         _rubrosCompras = New Reglas.RubrosCompras().GetRubrosComprasJSonTransporte()
         _rubrosComprasPaginas = PaginarDatos(_rubrosCompras, Reglas.Publicos.WebArchivos.RubrosCompras.TamanoPaginaPost)
      Else
         _rubrosCompras.Clear()
      End If

      'Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
      'System.IO.File.WriteAllText("c:\temp\_json\export\marcas_nuevo.json", serializer.Serialize(_marcasPaginas))

      MuestraCantidadRegistros(lblCantidadRubrosCompras, _rubrosCompras.Count, lblRubrosComprasTotalPaginas, ContarRegistros(_rubrosComprasPaginas))
   End Sub
   Private Sub ObtenerProveedores()
      MostrarInfo("Obteniendo Proveedores para sincronizar...")
      If chbProveedores.Checked Then
         _proveedores = New Reglas.Proveedores().GetProveedoresJSonTransporte()
         _proveedoresPaginas = PaginarDatos(_proveedores, Reglas.Publicos.WebArchivos.RubrosCompras.TamanoPaginaPost)
      Else
         _proveedores.Clear()
      End If

      'Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
      'System.IO.File.WriteAllText("c:\temp\_json\export\marcas_nuevo.json", serializer.Serialize(_marcasPaginas))

      MuestraCantidadRegistros(lblCantidadProveedores, _proveedores.Count, lblProveedoresTotalPaginas, ContarRegistros(_proveedoresPaginas))
   End Sub


   Private Sub HabilitaBotonConsultar()
      btnConsultar.Enabled = chbClientes.Checked Or chbProductos.Checked Or chbLocalidades.Checked Or chbRubros.Checked Or chbMarcas.Checked Or chbRubrosCompras.Checked Or chbProveedores.Checked
   End Sub

   Private Sub MuestraCantidadRegistros(control As Control, cantidad As Long, totalPaginas As Control, cantidadPaginas As Long)
      control.Text = String.Format(control.Tag.ToString(), cantidad)
      If totalPaginas IsNot Nothing Then totalPaginas.Text = cantidadPaginas.ToString()
      Application.DoEvents()
   End Sub
   Private Sub MuestraPaginaActual(control As Control, cantidad As Long)
      control.Text = cantidad.ToString()
      Application.DoEvents()
   End Sub
#End Region

   Private Function ObtenerFechaMaxima(Of T)(key As String, urlGetMaxFecha As String) As DateTime?
      Dim servicioRest As Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T) = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)()
      Dim result As DateTime? = Nothing
      If Not String.IsNullOrWhiteSpace(urlGetMaxFecha) Then
         tssInfo.Text = String.Format("Obteniendo última fecha de {0}.", key)
         Application.DoEvents()
         Try
            result = servicioRest.GetMaxFecha(urlGetMaxFecha, headers:=Nothing)
         Catch ex As Exception
            result = Nothing
         End Try
      End If
      Return result
   End Function

   Private Function FechaActualizacion(chb As CheckBox, dtp As DateTimePicker) As DateTime?
      If Not chb.Checked Then
         Return dtp.Value
      Else
         Return Nothing
      End If
   End Function

   Private Function GetArchivoLocal(key As String) As String
      If String.IsNullOrWhiteSpace(Reglas.Publicos.WebArchivos.CarpetaExportacion) Then
         Return String.Empty
      Else
         Return IO.Path.Combine(Reglas.Publicos.WebArchivos.CarpetaExportacion, String.Concat(key, "_{0:00000}.json"))
      End If
   End Function

   Private Sub ExportarDatos(continuar As Boolean)

      If Not continuar Then
         lblClientePaginaActual.Text = "0"
         lblProductosPaginaActual.Text = "0"
         lblProductosSucursalesPaginaActual.Text = "0"
         lblProductosSucursalesPreciosPaginaActual.Text = "0"
         lblLocalidadesPaginaActual.Text = "0"
         lblRubrosPaginaActual.Text = "0"
         lblSubRubrosPaginaActual.Text = "0"
         lblSubSubRubrosPaginaActual.Text = "0"
         lblMarcasPaginaActual.Text = "0"
         lblRubrosComprasPaginaActual.Text = "0"
         lblProveedoresPaginaActual.Text = "0"
         If Not String.IsNullOrWhiteSpace(Reglas.Publicos.WebArchivos.CarpetaExportacion) Then
            If Not IO.Directory.Exists(Reglas.Publicos.WebArchivos.CarpetaExportacion) Then
               IO.Directory.CreateDirectory(Reglas.Publicos.WebArchivos.CarpetaExportacion)
            Else
               For Each archivo As String In IO.Directory.EnumerateFiles(Reglas.Publicos.WebArchivos.CarpetaExportacion)
                  IO.File.Delete(archivo)
               Next
            End If
         End If

      End If

      Dim tamanoPagina As Integer = 0
      Dim urlDelete As String = String.Empty
      Dim urlPost As String = String.Empty
      Dim archivoLocal As String = String.Empty
      If chbClientes.Checked And _clientes.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.Clientes.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.Clientes.UrlDELETE 'http://localhost:14209/api/cliente/
         urlPost = Reglas.Publicos.WebArchivos.Clientes.UrlPOST 'http://localhost:14209/api/cliente/
         archivoLocal = GetArchivoLocal("Clientes")
         EnviarDatos("Clientes", _clientesPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosClientes, dtpClientes), lblClientePaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If
      If chbProductos.Checked And _productos.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.Productos.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.Productos.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.Productos.UrlPOST
         archivoLocal = GetArchivoLocal("Productos")
         EnviarDatos("Productos", _productosPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosProductos, dtpProductos), lblProductosPaginaActual)
         '"c:\temp\_json\export\productos_{0:000}.json"
         If chbProductosIncluirImagenes.Checked Then
            Dim rProductos As Reglas.Productos = New Reglas.Productos()
            rProductos.ExportarImagenes(_productos.ConvertAll(Function(x) x.IdProducto))

            Dim servidorFTP As String = Reglas.Publicos.FTPServidor
            Dim usuarioFTP As String = Reglas.Publicos.FTPUsuario
            Dim claveFTP As String = Reglas.Publicos.FTPPassword
            Dim nuevoArchivo As String = Reglas.Publicos.FTPNombreArchivo
            Dim conexionPasivaFTP As Boolean = Reglas.Publicos.FTPConexionPasiva
            Dim carpetaRemotaFTP As String = Reglas.Publicos.FTPCarpetaRemota

            Dim ftp As Reglas.IFtp
            ftp = New Reglas.SimpleFtp(servidorFTP, usuarioFTP, claveFTP)
            ftp.UsePassive = conexionPasivaFTP
            AddHandler ftp.FileUploadBeginning, Sub(sender As Object, e As Reglas.FileUploadEventArgs)
                                                   MostrarInfo(String.Format("Subiendo archivo {0}.......", e.FileName))
                                                End Sub
            AddHandler ftp.FileUploadFinished, Sub(sender As Object, e As Reglas.FileUploadEventArgs)
                                                  MostrarInfo(String.Format("Archivo {0} subido exitosamente.", e.FileName))
                                               End Sub
            ftp.UploadDirectory(IO.Path.Combine(Entidades.Publicos.CarpetaEniac, "ImagenesWeb"), carpetaRemotaFTP, True, True)
         End If
      End If
      If chbProductos.Checked And _productosSucursales.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.ProductosSucursales.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.ProductosSucursales.UrlPOST
         archivoLocal = GetArchivoLocal("Stock")
         EnviarDatos("Stock", _productosSucursalesPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosProductosSucursales, dtpProductosSucursales), lblProductosSucursalesPaginaActual)
         '"c:\temp\_json\export\productossucursales_{0:000}.json"
      End If
      If chbProductos.Checked And _productosSucursalesPrecios.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.ProductosSucursalesPrecios.UrlPOST
         archivoLocal = GetArchivoLocal("Precios")
         EnviarDatos("Precios", _productosSucursalesPreciosPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosProductosSucursalesPrecios, dtpProductosSucursalesPrecios), lblProductosSucursalesPreciosPaginaActual)
         '"c:\temp\_json\export\productossucursalesprecios_{0:000}.json"
      End If



      If chbLocalidades.Checked And _localidades.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.Localidades.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.Localidades.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.Localidades.UrlPOST
         archivoLocal = GetArchivoLocal("Localidades")
         EnviarDatos("Localidades", _localidadesPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosLocalidades, dtpLocalidades), lblLocalidadesPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If
      If chbRubros.Checked And _rubros.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.Rubros.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.Rubros.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.Rubros.UrlPOST
         archivoLocal = GetArchivoLocal("Rubros")
         EnviarDatos("Rubros", _rubrosPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosRubros, dtpRubros), lblRubrosPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If
      If chbRubros.Checked And _subRubros.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.SubRubros.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.SubRubros.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.SubRubros.UrlPOST
         archivoLocal = GetArchivoLocal("SubRubros")
         EnviarDatos("SubRubros", _subRubrosPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosSubRubros, dtpSubRubros), lblSubRubrosPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If
      If chbRubros.Checked And _subSubRubros.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.SubSubRubros.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.SubSubRubros.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.SubSubRubros.UrlPOST
         archivoLocal = GetArchivoLocal("SubSubRubros")
         EnviarDatos("SubSubRubros", _subSubRubrosPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosSubSubRubros, dtpSubSubRubros), lblSubSubRubrosPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If

      If chbMarcas.Checked And _marcas.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.Marcas.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.Marcas.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.Marcas.UrlPOST
         archivoLocal = GetArchivoLocal("Marcas")
         EnviarDatos("Marcas", _marcasPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosMarcas, dtpMarcas), lblMarcasPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If

      If chbRubrosCompras.Checked And _rubrosCompras.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.RubrosCompras.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.RubrosCompras.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.RubrosCompras.UrlPOST
         archivoLocal = GetArchivoLocal("RubrosCompras")
         EnviarDatos("RubrosCompras", _rubrosComprasPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosRubrosCompras, dtpRubrosCompras), lblRubrosComprasPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If

      If chbProveedores.Checked And _proveedores.Count > 0 Then
         tamanoPagina = Reglas.Publicos.WebArchivos.Proveedores.TamanoPaginaPost
         If Not continuar Then urlDelete = Reglas.Publicos.WebArchivos.Proveedores.UrlDELETE
         urlPost = Reglas.Publicos.WebArchivos.Proveedores.UrlPOST
         archivoLocal = GetArchivoLocal("Proveedores")
         EnviarDatos("Proveedores", _proveedoresPaginas, tamanoPagina, urlDelete, urlPost, archivoLocal, FechaActualizacion(chbTodosProveedores, dtpProveedores), lblProveedoresPaginaActual)
         '"c:\temp\_json\export\clientes_{0:000}.json"
      End If

   End Sub

   Private Sub EnviarDatos(Of T)(key As String, paginas As List(Of T()), registrosPorPagina As Integer, urlDelete As String, urlPost As String, archivoLocal As String,
                                 fechaActualizacionDesde As DateTime?, lblPaginaActual As Label)
      'Dim paginas As List(Of T()) = PaginarDatos(datos, registrosPorPagina)

      'Si está configurado un nombre de archivo local, exporto los json a discos.
      If Not String.IsNullOrWhiteSpace(archivoLocal) Then
         Dim numeroPagina As Integer = 0
         Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
         For Each pagina As T() In paginas
            numeroPagina += 1
            IO.File.WriteAllText(String.Format(archivoLocal, numeroPagina), serializer.Serialize(pagina))
         Next
      End If         'If Not String.IsNullOrWhiteSpace(archivoLocal) Then

      If Not String.IsNullOrWhiteSpace(urlDelete) Or Not String.IsNullOrWhiteSpace(urlPost) Then
         Dim servicioRest As Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T) = New Reglas.ServiciosRest.Archivos.BaseArchivosWeb(Of T)()

         'Si está configurada la Url de DELETE, la ejecuto.
         If Not String.IsNullOrWhiteSpace(urlDelete) Then
            If Not fechaActualizacionDesde.HasValue Then
               servicioRest.Delete(urlDelete)
            End If
         End If      'If Not String.IsNullOrWhiteSpace(urlDelete) Then

         'Si está configurada la Url de POST, la ejecuto
         If Not String.IsNullOrWhiteSpace(urlPost) Then
            Dim totalPaginas As Integer = paginas.Count
            Dim paginaInicial As Integer = Integer.Parse(lblPaginaActual.Text)
            For paginaActual As Integer = paginaInicial To totalPaginas - 1
               MostrarAvanceEnviarDatos(key, paginaActual + 1, totalPaginas)
               servicioRest.Post(paginas(paginaActual), urlPost)
               MuestraPaginaActual(lblPaginaActual, (paginaActual + 1))
            Next
         End If      'If Not String.IsNullOrWhiteSpace(urlDelete) Then
      End If         'If Not String.IsNullOrWhiteSpace(urlDelete) Or Not String.IsNullOrWhiteSpace(urlPost) Then

      'IO.File.WriteAllText(String.Format("c:\temp\_json\export\clientes_{000}.json", numeroPagina), serializer.Serialize(pagina))

   End Sub

   Private Sub MostrarAvanceEnviarDatos(key As String, paginaActual As Integer, totalPaginas As Integer)
      tssInfo.Text = String.Format("Cargando {0} - página {1}/{2}", key, paginaActual, totalPaginas)
      Application.DoEvents()
   End Sub

   Private Function PaginarDatos(Of T)(datos As List(Of T), registrosPorPagina As Integer) As List(Of T())
      Dim result As List(Of T()) = New List(Of T())
      Dim posicion As Integer = 0
      While posicion < datos.Count
         Dim pagina(Math.Min(datos.Count - posicion, registrosPorPagina) - 1) As T
         datos.CopyTo(posicion, pagina, 0, Math.Min(datos.Count - posicion, registrosPorPagina))
         result.Add(pagina)
         posicion += registrosPorPagina
      End While
      Return result
   End Function

   'Private Sub chbReenviarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles chbReenviarTodo.CheckedChanged, chbTodosSubSubRubros.CheckedChanged, chbTodosSubRubros.CheckedChanged, chbTodosRubros.CheckedChanged, chbTodosLocalidades.CheckedChanged
   '   dtpFechaActualizacionDesde.Enabled = Not chbReenviarTodo.Checked
   'End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodosClientes.CheckedChanged, chbTodosProductos.CheckedChanged, chbTodosProductosSucursales.CheckedChanged, chbTodosProductosSucursalesPrecios.CheckedChanged, chbTodosLocalidades.CheckedChanged, chbTodosRubros.CheckedChanged, chbTodosSubRubros.CheckedChanged, chbTodosSubSubRubros.CheckedChanged, chbTodosLocalidades.CheckedChanged, chbTodosMarcas.CheckedChanged, chbTodosProveedores.CheckedChanged, chbTodosRubrosCompras.CheckedChanged
      dtpClientes.Enabled = Not chbTodosClientes.Checked
      dtpProductos.Enabled = Not chbTodosProductos.Checked
      dtpProductosSucursales.Enabled = Not chbTodosProductosSucursales.Checked
      dtpProductosSucursalesPrecios.Enabled = Not chbTodosProductosSucursalesPrecios.Checked
      dtpLocalidades.Enabled = Not chbTodosLocalidades.Checked
      dtpRubros.Enabled = Not chbTodosRubros.Checked
      dtpSubRubros.Enabled = Not chbTodosSubRubros.Checked
      dtpSubSubRubros.Enabled = Not chbTodosSubSubRubros.Checked
   End Sub

   Private Sub chbTodos_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      chbTodosClientes.Checked = chbTodos.Checked
      chbTodosProductos.Checked = chbTodos.Checked
      chbTodosProductosSucursales.Checked = chbTodos.Checked
      chbTodosProductosSucursalesPrecios.Checked = chbTodos.Checked
      chbTodosLocalidades.Checked = chbTodos.Checked
      chbTodosRubros.Checked = chbTodos.Checked
      chbTodosSubRubros.Checked = chbTodos.Checked
      chbTodosSubSubRubros.Checked = chbTodos.Checked
   End Sub
End Class