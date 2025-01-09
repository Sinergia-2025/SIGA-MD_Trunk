Partial Public Class Publicos

   Public Sub CargaComboLetraComprobanteVenta(combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "LetraFiscal"
         .ValueMember = "LetraFiscal"
         .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboLetraComprobanteCompra(combo As Eniac.Controles.ComboBox)
      With combo
         Dim aTipoFactura As ArrayList = New ArrayList
         aTipoFactura.Insert(0, "A")
         aTipoFactura.Insert(1, "B")
         aTipoFactura.Insert(2, "C")
         aTipoFactura.Insert(3, "D")
         aTipoFactura.Insert(4, "E")
         aTipoFactura.Insert(5, "I")
         aTipoFactura.Insert(6, "M")
         aTipoFactura.Insert(7, "R")
         aTipoFactura.Insert(8, "X")
         combo.DataSource = aTipoFactura
      End With
   End Sub

   Public Sub CargaComboCentroCostos(combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreCentroCosto"
         .ValueMember = "IdCentroCosto"
         .DataSource = New Reglas.ContabilidadCentrosCostos().GetTodos()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboFormatosEtiquetas(combo As Eniac.Controles.ComboBox, tipo As Entidades.FormatoEtiqueta.Tipos?, activo As Boolean?)
      With combo
         .DisplayMember = Entidades.FormatoEtiqueta.Columnas.NombreFormatoEtiqueta.ToString()
         .ValueMember = Entidades.FormatoEtiqueta.Columnas.IdFormatoEtiqueta.ToString()
         .DataSource = New Reglas.FormatosEtiquetas().GetTodas(tipo, activo)
         .SelectedIndex = -1
      End With
   End Sub

#Region "Propiedades Shared ReadOnly"
   <Obsolete("Usar Reglas")>
   Public Shared ReadOnly Property FactElectEsSincronica() As Boolean
      Get
         Return Reglas.Publicos.FactElectEsSincronica
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property MailServidor() As String
      Get
         Return Reglas.Publicos.MailServidor ' New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.MAILSERVIDOR)
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property MailDireccion() As String
      Get
         Return Reglas.Publicos.MailDireccion ' New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.MAILDIRECCION)
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property TamañoMaximoImagenes() As Integer
      Get
         Return Reglas.Publicos.TamañoMaximoImagenes
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property MailUsuario() As String
      Get
         Return Reglas.Publicos.MailUsuario
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property MailPassword() As String
      Get
         Return Reglas.Publicos.MailPassword
      End Get
   End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property MailPuertoSalida() As Integer
      Get
         Return Reglas.Publicos.MailPuertoSalida ' Int32.Parse(New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.MAILPUERTOSALIDA))
      End Get
   End Property

   ''''<Obsolete("Usar el de Reglas")>
   ''''Public Shared ReadOnly Property MailRequiereSSL() As Boolean
   ''''   Get
   ''''      Return Reglas.Publicos.MailRequiereSSL
   ''''   End Get
   ''''End Property

   ''''Public Shared ReadOnly Property MailRequiereAutenticacion() As Boolean
   ''''   Get
   ''''      Return Boolean.Parse(New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.MAILREQUIEREAUTENTICACION.ToString()))
   ''''   End Get
   ''''End Property

   <Obsolete("Usar el de Reglas")>
   Public Shared ReadOnly Property RetieneGanancias() As Boolean
      Get
         Return Reglas.Publicos.RetieneGanancias
      End Get
   End Property

   Public Shared ReadOnly Property ReemplazarComprobanteTipoComprobanteOrigen() As String
      Get
         Return Reglas.Publicos.ReemplazarComprobanteTipoComprobanteOrigen
      End Get
   End Property

   Public Shared ReadOnly Property ReemplazarComprobanteTipoComprobanteDestino() As String
      Get
         Return Reglas.Publicos.ReemplazarComprobanteTipoComprobanteDestino
      End Get
   End Property

   ''Public Shared ReadOnly Property ComprasDecimalesRedondeoEnCantidad() As Integer
   ''   Get
   ''      Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESREDONDEOENCANTIDAD.ToString(), "2"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ComprasDecimalesMostrarEnCantidad() As Integer
   ''   Get
   ''      Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESMOSTRARENCANTIDAD.ToString(), "2"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ComprasDecimalesRedondeoEnPrecio() As Integer
   ''   Get
   ''      Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESREDONDEOENPRECIO.ToString(), "4"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ComprasDecimalesEnPrecio() As Integer
   ''   Get
   ''      Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESENPRECIO.ToString(), "2"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ComprasToleranciaIvaManual() As Decimal
   ''   Get
   ''      Return Decimal.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASTOLERANCIAIVAMANUAL.ToString(), "0.05"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ComprasDecimalesEnTotalXProducto() As Integer
   ''   Get
   ''      Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESENTOTALXPRODUCTO.ToString(), "2"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ComprasDecimalesEnTotalGeneral() As Integer
   ''   Get
   ''      Return Integer.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.COMPRASDECIMALESENTOTALGENERAL.ToString(), "2"))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ActualizaPrecioCostoPorTipoCambio() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.ACTUALIZAPRECIOCOSTOPORTIPOCAMBIO.ToString(), Boolean.FalseString))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property ActualizarPreciosMostrarCodigoProductoProveedor() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.ACTUALIZARPRECIOSMOSTRARCODIGOPRODUCTOPROVEEDOR.ToString(), Boolean.FalseString))
   ''   End Get
   ''End Property

   ''Public Shared ReadOnly Property FTPCarpetaSecundaria() As Boolean
   ''   Get
   ''      Return Boolean.Parse(New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.FTPCARPETASECUNDARIA.ToString(), Boolean.FalseString))
   ''   End Get
   ''End Property

   Public Shared ReadOnly Property UbicacionArchivoPDA() As String
      Get
         Return New Reglas.Parametros().GetValorPD(Entidades.Parametro.Parametros.UBICACIONARCHIVOSPDA.ToString(), Boolean.FalseString)
      End Get
   End Property

#End Region

#Region "Metodos Publicos"
   Public Shared Function ObtenerFechaHoraAfip() As DateTime
      Return Reglas.Publicos.ObtenerFechaHoraAfip()
   End Function
#End Region

   Private Shared _unidadTamano As String() = {"B", "KB", "MB", "GB"}
   Public Structure TamanioArchivoFormateado
      Public Property Tamanio As Decimal
      Public Property Unidad As String
      Public Sub New(tamanio As Decimal, unidad As String)
         Me.Tamanio = tamanio
         Me.Unidad = unidad
      End Sub
      Public Overrides Function ToString() As String
         Return String.Format("{0:N2} {1}", Tamanio, Unidad)
      End Function
   End Structure
   Public Shared Function GetTamanioArchivoFormateado(tamano As Decimal) As TamanioArchivoFormateado
      Return GetTamanioArchivoFormateado(tamano, 0)
   End Function
   Private Shared Function GetTamanioArchivoFormateado(tamano As Decimal, unidadIndex As Integer) As TamanioArchivoFormateado
      If tamano < 1024 Or unidadIndex > _unidadTamano.Length - 1 Then
         Return New TamanioArchivoFormateado(tamano, _unidadTamano(Math.Min(unidadIndex, _unidadTamano.Length - 1)))
      Else
         unidadIndex += 1
         tamano = tamano / 1024
         Return GetTamanioArchivoFormateado(tamano, unidadIndex)
      End If
   End Function

   Public Shared Function HayInternet() As Boolean
      Dim Url As System.Uri = New System.Uri("http://www.google.com")
      Dim peticion As System.Net.WebRequest
      Dim respuesta As System.Net.WebResponse

      Try
         'Creamos la peticion
         peticion = System.Net.WebRequest.Create(Url)
         'POnemos un tiempo limite
         peticion.Timeout = 5000

         'ejecutamos la peticion
         respuesta = peticion.GetResponse()
         respuesta.Close()
         peticion = Nothing

         Return True

      Catch ex As Exception
         'si ocurre un error, devolvemos error
         peticion = Nothing
         Return False

      End Try

   End Function

End Class
