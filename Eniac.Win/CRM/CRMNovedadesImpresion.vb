Imports System.IO
Imports Eniac.Entidades

Public Class CRMNovedadesImpresion

#Region "Campos"
   Private _oNovedad As Entidades.CRMNovedad
   Private Estado As EstadoImpresion = New EstadoImpresion()
#End Region

#Region "Constructores"

   Public Sub New(ByVal CRMNovedad As Entidades.CRMNovedad)
      Me._oNovedad = CRMNovedad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

#End Region

#Region "Metodos"

   Public Sub ResolverImpresion(n As Entidades.CRMNovedad,
                                reporteNombre As String,
                                nombreDataSet As String,
                                datosDS As SistemaDataSet.CRMNovedadesSeguimientoDataTable,
                                nombreDataSet2 As String,
                                datosDS2 As CRMDataSet.CRMNovedadesProductosDataTable,
                                Parametros As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter),
                                embebido As Boolean,
                                exportar As Boolean, nombreArchivoExportar As String)

      '# Orden de jerarquía en la impresión
      '# 1. Impresión del Estado
      '# 2. Impresión del Tablero
      '# 3. Impresión por defecto
      Dim cantidadCopias As Integer = 1
      If Not String.IsNullOrEmpty(n.EstadoNovedad.Reporte) Then
         reporteNombre = String.Format("{0}{1}", If(Not n.EstadoNovedad.Embebido, "Reportes\", Nothing), n.EstadoNovedad.Reporte)
         embebido = If(n.EstadoNovedad.Embebido, True, False)
         cantidadCopias = n.EstadoNovedad.CantidadCopias
      ElseIf Not String.IsNullOrEmpty(n.TipoNovedad.Reporte) Then
         reporteNombre = String.Format("{0}{1}", If(Not n.TipoNovedad.Embebido, "Reportes\", Nothing), n.TipoNovedad.Reporte)
         embebido = If(n.TipoNovedad.Embebido, True, False)
         cantidadCopias = n.TipoNovedad.CantidadCopias
      End If

      If Not exportar Then
         Dim frmImprime As VisorReportes
         frmImprime = New VisorReportes(reporteNombre, nombreDataSet, datosDS, nombreDataSet2, datosDS2, Parametros, embebido, cantidadCopias)
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.rvReporte.LocalReport.DisplayName = nombreArchivoExportar
         frmImprime.ShowDialog()

      Else
         Dim ePDF = New ExportarPDF()
         ePDF.Run(reporteNombre, nombreDataSet, datosDS, nombreDataSet2, datosDS2, Parametros, embebido, nombreArchivoExportar)
      End If

   End Sub

   'Public Function Imprimir() As EstadoImpresion
   '   Estado.OK = True
   '   Estado.MensajeError = ""
   '   Return Estado
   'End Function

   Public Function ExportarNovedad() As String
      Return ExportarNovedad(nombreArchivo:=Path.Combine(Path.GetTempPath, String.Format("{0}_{1}_{2:0000}-{3:00000000}.pdf",
                                                                                         _oNovedad.IdTipoNovedad, _oNovedad.Letra, _oNovedad.CentroEmisor, _oNovedad.IdNovedad)))
   End Function
   Public Function ExportarNovedad(nombreArchivo As String) As String
      ImprimirNovedad(exportar:=True, nombreArchivo)
      Return nombreArchivo
   End Function
   Public Sub ImprimirNovedad()
      ImprimirNovedad(exportar:=False, nombreArchivo:=String.Empty)
   End Sub
   Public Sub ImprimirNovedad(exportar As Boolean, nombreArchivo As String)

      Dim dtNS As SistemaDataSet.CRMNovedadesSeguimientoDataTable = New SistemaDataSet.CRMNovedadesSeguimientoDataTable()
      Dim drNS As SistemaDataSet.CRMNovedadesSeguimientoRow
      Dim dtPS As CRMDataSet.CRMNovedadesProductosDataTable = New CRMDataSet.CRMNovedadesProductosDataTable()
      Dim drPS As CRMDataSet.CRMNovedadesProductosRow
      Dim Linea As Integer = 0


      For Each nov As Entidades.CRMNovedadSeguimiento In Me._oNovedad.Seguimientos
         drNS = dtNS.NewCRMNovedadesSeguimientoRow()

         drNS.IdTipoNovedad = nov.IdTipoNovedad
         drNS.IdNovedad = nov.IdNovedad
         drNS.IdSeguimiento = nov.IdSeguimiento
         drNS.FechaSeguimiento = nov.FechaSeguimiento
         drNS.Comentario = nov.Comentario
         drNS.EsComentario = nov.EsComentario
         drNS.UsuarioSeguimiento = nov.UsuarioSeguimiento.Id
         drNS.Interlocutor = nov.Interlocutor
         drNS.IdTipoComentarioNovedad = If(nov.IdTipoComentarioNovedad.HasValue, nov.IdTipoComentarioNovedad.Value, Nothing)
         dtNS.AddCRMNovedadesSeguimientoRow(drNS)

      Next

      For Each nov As Entidades.CRMNovedadProducto In Me._oNovedad.ProductosNovedad
         drPS = dtPS.NewCRMNovedadesProductosRow()

         drPS.IdNovedad = nov.IdNovedad
         drPS.LetraNovedad = nov.LetraNovedad
         drPS.CentroEmisor = nov.CentroEmisor
         drPS.IdSucursalNovedad = If(nov.IdSucursalNovedad.HasValue, nov.IdSucursalNovedad.Value, Nothing)
         drPS.IdProducto = nov.IdProducto
         drPS.NombreProducto = nov.NombreProducto
         drPS.OrdenProducto = nov.OrdenProducto
         drPS.CantidadProducto = nov.CantidadProducto
         drPS.PrecioProducto = nov.PrecioProducto
         drPS.ImporteNovedad = nov.ImporteNovedad
         drPS.IdListaPrecios = nov.IdListaPrecios
         drPS.StockConsumidoProducto = nov.StockConsumidoProducto
         drPS.nroSerie = nov.nroSerie
         dtPS.AddCRMNovedadesProductosRow(drPS)

      Next


      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

      Dim Cliente As Entidades.Cliente = Nothing
      Dim ClienteNombre As String = ""
      Dim ClienteMail As String = ""
      Dim ClienteTelefono As String = "0"
      Dim ClienteCategoria As String = ""
      Dim ClienteDireccion As String = ""
      Dim ClienteLocalidad As String = ""
      Dim ClienteCodigo As Long = 0
      If Not String.IsNullOrWhiteSpace(_oNovedad.IdCliente.ToString()) Then
         Cliente = New Reglas.Clientes().GetUno(_oNovedad.IdCliente)
         ClienteCodigo = Cliente.CodigoCliente
         ClienteNombre = Cliente.NombreCliente
         ClienteMail = Cliente.CorreoElectronico + " " + Cliente.CorreoAdministrativo
         ClienteTelefono = Cliente.Telefono + " " + Cliente.Celular
         ClienteCategoria = New Reglas.Categorias().GetUno(Cliente.IdCategoria).NombreCategoria
         ClienteDireccion = Cliente.Direccion
         ClienteLocalidad = Cliente.NombreLocalidad
      End If

      Dim Prospecto As Entidades.Cliente = Nothing
      Dim ProspectoNombre As String = ""
      Dim ProspectoMail As String = ""
      Dim ProspectoTelefono As String = "0"
      Dim ProspectoCategoria As String = ""
      If Not String.IsNullOrWhiteSpace(_oNovedad.IdProspecto.ToString()) Then
         Prospecto = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Prospecto).GetUno(_oNovedad.IdProspecto)
         ProspectoNombre = Prospecto.NombreCliente
         ProspectoMail = Prospecto.CorreoElectronico + " " + Prospecto.CorreoAdministrativo
         ProspectoTelefono = Prospecto.Telefono
         ProspectoCategoria = New Reglas.Categorias().GetUno(Prospecto.IdCategoria).NombreCategoria
      End If

      Dim Proveedor As Entidades.Proveedor = Nothing
      Dim ProveedorNombre As String = ""
      If Not String.IsNullOrWhiteSpace(_oNovedad.IdProveedor.ToString()) Then
         Proveedor = New Reglas.Proveedores().GetUno(_oNovedad.IdProveedor)
         ProveedorNombre = Proveedor.NombreProveedor
      End If

      '-.PE-31999.-
      Dim ProveedorGarante As Entidades.Proveedor = Nothing
      Dim ProveedorGaranteNombre As String = ""
      If Not String.IsNullOrWhiteSpace(_oNovedad.IdProveedorGarantia.ToString()) Then
         ProveedorGarante = New Reglas.Proveedores().GetUno(CLng(_oNovedad.IdProveedorGarantia))
         ProveedorGaranteNombre = ProveedorGarante.NombreProveedor
      End If

      Dim Prod As Entidades.Producto = Nothing
      If _oNovedad.IdProducto IsNot Nothing Then
         Prod = New Reglas.Productos().GetUno(_oNovedad.IdProducto)
      End If


      Dim Venta As Entidades.Venta = Nothing
      If _oNovedad.IdTipoComprobanteService IsNot Nothing Then
         Venta = New Reglas.Ventas().GetUna(_oNovedad.IdSucursalService, _oNovedad.IdTipoComprobanteService, _oNovedad.LetraService,
                                            _oNovedad.CentroEmisorService, _oNovedad.NumeroComprobanteService)
      End If

      'Dim Funcion As String = ""
      'If Not String.IsNullOrWhiteSpace(_oNovedad.IdFuncion.ToString()) Then
      '   Funcion = New Reglas.Funciones().GetAll()
      'End If

      Dim CategoriaNovedad As String = New Reglas.CRMCategoriasNovedades().GetUno(_oNovedad.IdCategoriaNovedad).NombreCategoriaNovedad
      Dim MedioNovedad As String = New Reglas.CRMMediosComunicacionesNovedades().GetUno(_oNovedad.IdMedioComunicacionNovedad).NombreMedioComunicacionNovedad
      Dim EstadoNovedad As String = New Reglas.CRMEstadosNovedades().GetUno(_oNovedad.IdEstadoNovedad).NombreEstadoNovedad
      Dim PrioridadNovedad As String = New Reglas.CRMPrioridadesNovedades().GetUno(_oNovedad.IdPrioridadNovedad).NombrePrioridadNovedad
      Dim MetodoResolución As String = New Reglas.CRMMetodosResolucionesNovedades().GetUno(_oNovedad.IdMetodoResolucionNovedad).NombreMetodoResolucionNovedad
      If _oNovedad.IdProducto IsNot Nothing Then
         Dim Producto As String = New Reglas.Productos().GetUno(_oNovedad.IdProducto).NombreProducto
      End If

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroVersionAplicacion", String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)))

      '# Logo
      Dim LogoImagen = actual.Logo
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))

      '-- REQ-34527.- ------------------------------------------------------------------------------------------------------------
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
      '---------------------------------------------------------------------------------------------------------------------------

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresaOriginal", actual.Sucursal.Direccion & " - " & actual.Sucursal.Localidad.NombreLocalidad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("eMail", actual.Sucursal.Correo.ToString()))

      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdTipoNovedad", Me._oNovedad.IdTipoNovedad)) 
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoNovedad", _oNovedad.TipoNovedad.NombreTipoNovedad))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdNovedad", Me._oNovedad.IdNovedad.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaNovedad", Me._oNovedad.FechaNovedad.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Descripcion", Me._oNovedad.Descripcion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdPrioridadNovedad", PrioridadNovedad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdCategoriaNovedad", CategoriaNovedad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdEstadoNovedad", EstadoNovedad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaEstadoNovedad", Me._oNovedad.FechaEstadoNovedad.ToString()))
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdUsuarioEstadoNovedad", Me._oNovedad.IdUsuarioEstadoNovedad)) 
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaAlta", Me._oNovedad.FechaAlta.ToString()))

      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdUsuarioAlta", Me._oNovedad.IdUsuarioAlta)) 
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("UsuarioAlta", _oNovedad.UsuarioAlta.Nombre))

      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdUsuarioAsignado", Me._oNovedad.IdUsuarioAsignado))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("UsuarioAsignado", _oNovedad.UsuarioAsignado.Nombre))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Avance", Me._oNovedad.Avance.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdMedioComunicacionNovedad", MedioNovedad))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdCliente", Me._oNovedad.IdCliente.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreCliente", ClienteNombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoCliente", ClienteMail))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoCliente", ClienteTelefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionCliente", String.Format("{0} - {1}", Cliente.Direccion, Cliente.NombreLocalidad)))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CategoriaCliente", ClienteCategoria))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdProspecto", Me._oNovedad.IdProspecto.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProspecto", ProspectoNombre))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoProspecto", ProspectoMail))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoProspecto", ProspectoTelefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CategoriaProspecto", ProspectoCategoria))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdFuncion", Me._oNovedad.IdFuncion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdSistema", Me._oNovedad.IdSistema))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaProximoContacto", Me._oNovedad.FechaProximoContacto.ToString()))
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("BanderaColor", Me._oNovedad.BanderaColor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Interlocutor", Me._oNovedad.Interlocutor))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdMetodoResolucionNovedad", MetodoResolución))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdProveedor", Me._oNovedad.IdProveedor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdProveedor", Me._oNovedad.IdProveedor.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("EstadoNovedad", _oNovedad.EstadoNovedad.NombreEstadoNovedad))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Finalizado", _oNovedad.EstadoNovedad.Finalizado.ToString()))

      'SERVICE
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoSucursal", actual.Sucursal.Telefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("RedesSociales", actual.Sucursal.RedesSociales))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("MailEmpresa", actual.Sucursal.Correo))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", ClienteCodigo.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", ClienteDireccion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", ClienteLocalidad))
      If Prod IsNot Nothing Then
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CodigoProducto", Prod.IdProducto))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProducto", _oNovedad.NombreProducto))
      End If

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreMarca", _oNovedad.NombreMarcaProducto)) ' Prod.NombreMarca))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreModelo", _oNovedad.NombreModeloProducto)) ' Prod.NombreModelo))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cantidad", _oNovedad.CantidadProducto.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroDeSerie", _oNovedad.NroDeSerie))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("UbicacionService", _oNovedad.UbicacionService))

      If Me._oNovedad.IdTipoComprobanteService IsNot Nothing Then
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", Venta.TipoComprobanteDescripcion & " '" & Venta.LetraComprobante & "' " & Venta.CentroEmisor.ToString("0000") & "-" & Venta.NumeroComprobante.ToString("00000000") & " - " & Venta.Fecha.ToString("dd/MM/yyyy")))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ComprobanteAdjunto", "ADJUNTA " & Venta.TipoComprobanteDescripcion))
         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Estados", Venta.))
      Else
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", "SIN FACTURA RELACIONADA"))
      End If
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Costo", Me._oNovedad.CostoReparacion.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Defecto", Me._oNovedad.Descripcion))

      '# Producto Prestado
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdProductoPrestado", _oNovedad.IdProductoPrestado))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProductoPrestado", _oNovedad.NombreProductoPrestado))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroSerieProductoPrestado", _oNovedad.NroSerieProductoPrestado))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CantidadProductoPrestado", _oNovedad.CantidadProductoPrestado.ToString()))

      '-.PE-31999.-
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", actual.Sucursal.Direccion))
      'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", actual.Sucursal.Telefono))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Letra", _oNovedad.Letra))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LocalidadEmpresa", actual.Sucursal.Localidad.NombreLocalidad.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroServicioTecnico", _oNovedad.IdNovedad.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProveedorGarantia", ProveedorGaranteNombre.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Modelo", _oNovedad.NombreModeloProducto.ToString()))

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Sena", _oNovedad.AnticipoNovedad.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Total", _oNovedad.CostoReparacion.ToString()))

      If Not String.IsNullOrEmpty(Me._oNovedad.ServiceLugarCompraTipoComprobante) Then
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ServiceComprobante", "N° de " & _oNovedad.ServiceLugarCompraTipoComprobante & _oNovedad.ServiceLugarCompraNumeroComprobante))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("AdjuntaServiceComprobante", "ADJUNTA " & _oNovedad.ServiceLugarCompraTipoComprobante))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("ServiceLugarCompra", _oNovedad.ServiceLugarCompraFecha & " " & _oNovedad.ServiceLugarCompra))
      End If


      '# Reporte por defecto



      Dim nombreArchivoExportar As String = String.Format("{0}_{1}_{2}_{3}", _oNovedad.IdTipoNovedad,
                                                       _oNovedad.CentroEmisor,
                                                       _oNovedad.IdNovedad,
                                                       Cliente.NombreCliente)

      Dim reporteNombre As String = "Eniac.Win.CRMNovedades.rdlc"
      Dim reporteEmbebido As Boolean = True
      ResolverImpresion(_oNovedad, reporteNombre, "SistemasDataSet_CRMNovedadesSeguimiento", dtNS, "CRMDataSet_CRMNovedadesProductos", dtPS, parm, reporteEmbebido, exportar, nombreArchivoExportar)

   End Sub

#End Region

#Region "Propiedades"
   Private _cantidadCopias As Integer
   Public Property CantidadCopias() As Integer
      Get
         If _cantidadCopias = 0 Then
            Return 1
         Else
            Return _cantidadCopias
         End If
      End Get
      Set(ByVal value As Integer)
         _cantidadCopias = value
      End Set
   End Property
#End Region

End Class
