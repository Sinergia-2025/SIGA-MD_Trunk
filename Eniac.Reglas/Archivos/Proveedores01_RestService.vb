Imports Eniac.Entidades.JSonEntidades
Partial Class Proveedores
#Region "RestService & Json"
   Public Event AvanceValidarDatosProveedores(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceValidarDatos
   Public Event AvanceImportarDatosProveedores(sender As Object, e As Clientes.AvanceProcesarDatosEventArgs) Implements IRestServices.AvanceImportarDatos

   Protected Overrides Sub OnAvanceImportarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceImportarDatosProveedores(Me, eventArgs)
      MyBase.OnAvanceImportarDatos(eventArgs)
   End Sub
   Protected Overrides Sub OnAvanceValidarDatos(eventArgs As Clientes.AvanceProcesarDatosEventArgs)
      RaiseEvent AvanceValidarDatosProveedores(Me, eventArgs)
      MyBase.OnAvanceValidarDatos(eventArgs)
   End Sub

   Public Overrides Function Convertir(transporte As List(Of Archivos.ProveedorJSonTransporte)) As List(Of Archivos.ProveedorJSon)
      Return transporte.ConvertAll(Function(dato) New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.Archivos.ProveedorJSon)(dato.DatosProveedor))
   End Function

   Public Function GetProveedoresJSon() As List(Of Archivos.ProveedorJSon)
      Dim lst = New List(Of Archivos.ProveedorJSon)()

      Dim dt As DataTable = New SqlServer.Proveedores(da).Proveedores_GA()
      Dim o As Entidades.JSonEntidades.Archivos.ProveedorJSon
      Dim cuitEmpresa As String = Publicos.CuitEmpresa
      For Each dr As DataRow In dt.Rows
         o = New Entidades.JSonEntidades.Archivos.ProveedorJSon()
         CargarUno(o, dr, cuitEmpresa)
         lst.Add(o)
      Next

      Return lst
   End Function

   Private Sub CargarUno(o As Archivos.ProveedorJSon, dr As DataRow, cuitEmpresa As String)
      With o
         .CuitEmpresa = cuitEmpresa

         .IdProveedor = Integer.Parse(dr("IdProveedor").ToString())
         .Activo = Boolean.Parse(dr("Activo").ToString())
         .CodigoProveedor = Long.Parse(dr("CodigoProveedor").ToString())
         .CodigoProveedorLetras = dr.Field(Of String)(Entidades.Proveedor.Columnas.CodigoProveedorLetras.ToString())
         .CorreoElectronico = dr("CorreoElectronico").ToString()
         .CuitProveedor = dr("CuitProveedor").ToString()
         .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         .DireccionProveedor = dr("DireccionProveedor").ToString()
         If Not String.IsNullOrEmpty(dr("EsPasibleRetencion").ToString()) Then
            .EsPasibleRetencion = Boolean.Parse(dr("EsPasibleRetencion").ToString())
         End If
         .EsPasibleRetencionIIBB = Boolean.Parse(dr("EsPasibleRetencionIIBB").ToString())
         .EsPasibleRetencionIVA = Boolean.Parse(dr("EsPasibleRetencionIVA").ToString())
         .FaxProveedor = dr("FaxProveedor").ToString()
         .FechaHigSeg = dr("FechaHigSeg").ToString()
         .FechaIndiceInc = dr("FechaIndiceInc").ToString()
         .FechaRes559 = dr("FechaRes559").ToString()
         .IdCategoria = Int32.Parse(dr("IdCategoria").ToString())
         .IdCategoriaFiscal = Short.Parse(dr("IdCategoriaFiscal").ToString())
         .IdCuentaCaja = Int32.Parse(dr("IdCuentaCaja").ToString())
         If Not String.IsNullOrEmpty(dr("IdCuentaContable").ToString()) Then
            .IdCuentaContable = Long.Parse(dr("IdCuentaContable").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdFormasPago").ToString()) Then
            .IdFormasPago = Int32.Parse(dr("IdFormasPago").ToString())
         End If
         .IdLocalidadProveedor = Int32.Parse(dr("IdLocalidadProveedor").ToString())
         If Not String.IsNullOrEmpty(dr("IdRegimen").ToString()) Then
            .IdRegimen = Int32.Parse(dr("IdRegimen").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimenGan").ToString()) Then
            .IdRegimenGan = Int32.Parse(dr("IdRegimenGan").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimenIIBB").ToString()) Then
            .IdRegimenIIBB = Int32.Parse(dr("IdRegimenIIBB").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimenIVA").ToString()) Then
            .IdRegimenIVA = Int32.Parse(dr("IdRegimenIVA").ToString())
         End If
         .IdRubroCompra = Int32.Parse(dr("IdRubroCompra").ToString())
         .IdTipoComprobante = dr("IdTipoComprobante").ToString()
         .IngresosBrutos = dr("IngresosBrutos").ToString()
         .NombreDeFantasia = dr("NombreDeFantasia").ToString()
         .NombreProveedor = dr("NombreProveedor").ToString()
         If Not String.IsNullOrEmpty(dr("NroDocProveedor").ToString()) Then
            .NroDocProveedor = Long.Parse(dr("NroDocProveedor").ToString())
         End If
         .Observacion = dr("Observacion").ToString()
         .PorCtaOrden = Boolean.Parse(dr("PorCtaOrden").ToString())
         .TelefonoProveedor = dr("TelefonoProveedor").ToString()
         .TipoDocProveedor = dr("TipoDocProveedor").ToString()
         .IdCuentaBanco = Int32.Parse(dr("IdCuentaBanco").ToString())

         .NivelAutorizacion = Short.Parse(dr("NivelAutorizacion").ToString())
         .EsProveedorGenerico = Boolean.Parse(dr("EsProveedorGenerico").ToString())

         .CBUProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CBUProveedor.ToString())
         .CBUAliasProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CBUAliasProveedor.ToString())
         .CBUCuit = dr.Field(Of String)(Entidades.Proveedor.Columnas.CBUCuit.ToString())
         .IdConceptoCM05 = dr.Field(Of Integer?)(Entidades.Proveedor.Columnas.IdConceptoCM05.ToString())

         .IdClienteVinculado = dr.Field(Of Integer?)(Entidades.Proveedor.Columnas.IdClienteVinculado.ToString())
      End With
   End Sub

   Public Sub CargarJSonEnLista(entidadesTransporte As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte),
                                entidadesJson As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSon))

      Dim ser As System.Web.Script.Serialization.JavaScriptSerializer
      Dim entidadJSon As Entidades.JSonEntidades.Archivos.ProveedorJSon

      ser = New System.Web.Script.Serialization.JavaScriptSerializer()
      For Each transporte As Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte In entidadesTransporte
         entidadJSon = ser.Deserialize(Of Entidades.JSonEntidades.Archivos.ProveedorJSon)(transporte.DatosProveedor)
         entidadesJson.Add(entidadJSon)
      Next
   End Sub

   Public Overloads Sub ValidarDatos(dt As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSon))
      ValidarDatos(dt, Nothing)
   End Sub
   Public Overrides Function ValidarDatos(col As List(Of Archivos.ProveedorJSon), syncs As ServiciosRest.Sincronizacion.SyncBaseCollection) As Boolean
      Dim cache As BusquedasCacheadas = New BusquedasCacheadas()
      Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Proveedores")

      Dim stbMensajeError As StringBuilder = New StringBuilder()

      eventArgs.TotalRegistros = col.Count
      For Each en As Entidades.JSonEntidades.Archivos.ProveedorJSon In col
         eventArgs.RegistroActual += 1
         eventArgs.Datos = en
         OnAvanceValidarDatos(eventArgs)
         If True Then
            If Not cache.ExisteLocalidad(en.IdLocalidadProveedor) Then
               en.ConErrores = True
               stbMensajeError.AppendFormat("No existe la Localidad con IdLocalidad = {0}.", en.IdLocalidadProveedor)
            End If
            'Dim IdProvincia As String = drMarca(Entidades.Rubro.Columnas.IdProvincia.ToString()).ToString()
            'If Not String.IsNullOrEmpty(IdProvincia) AndAlso Not cache.ExisteProvincia(IdProvincia) Then
            '   drRubro.SetColumnError("IdProvincia", String.Format("No existe la Provincia con IdProvincia = {0}.", IdProvincia))
            'End If
         End If

         SetEstadoRow(en, stbMensajeError, Function(x) cache.ExisteProveedor(x.IdProveedor))

         OnAvanceValidarDatos(eventArgs)
      Next

      Return CheckAlgunError(col)

   End Function

   Public Sub ImportarDesdeWebSiga(dt As DataTable) Implements IRestServices.ImportarDesdeWebSiga
      Throw New NotImplementedException()
   End Sub

   Public Overrides Function ImportarDatos(transporte As List(Of Archivos.ProveedorJSon)) As Boolean
      ImportarDesdeWebSiga(transporte)
      Return True
   End Function

   Public Sub ImportarDesdeWebSiga(Of T)(dt As List(Of T)) Implements IRestServices.ImportarDesdeWebSiga
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim sClientes As SqlServer.Proveedores = New SqlServer.Proveedores(da)
         Dim eventArgs As Clientes.AvanceProcesarDatosEventArgs = New Clientes.AvanceProcesarDatosEventArgs("Proveedores")
         Dim FechaHigSeg As DateTime?
         Dim FechaRes559 As DateTime?
         Dim FechaIndiceInc As DateTime?
         Dim FechaIndemnidad As DateTime?

         eventArgs.TotalRegistros = dt.Count
         Dim maximoFechaActualizacion As DateTime? = Nothing
         For Each dr1 As T In dt
            Dim dr As Entidades.JSonEntidades.Archivos.ProveedorJSon = CType(Convert.ChangeType(dr1, GetType(Entidades.JSonEntidades.Archivos.ProveedorJSon)), Entidades.JSonEntidades.Archivos.ProveedorJSon)
            eventArgs.RegistroActual += 1
            eventArgs.Datos = dr
            OnAvanceImportarDatos(eventArgs)

            FechaHigSeg = Nothing
            If Not String.IsNullOrEmpty(dr.FechaHigSeg) Then
               DateTime.TryParse(dr.FechaHigSeg, FechaHigSeg.Value)
            End If
            FechaRes559 = Nothing
            If Not String.IsNullOrEmpty(dr.FechaRes559) Then
               DateTime.TryParse(dr.FechaRes559, FechaRes559.Value)
            End If
            FechaIndiceInc = Nothing
            If Not String.IsNullOrEmpty(dr.FechaIndiceInc) Then
               DateTime.TryParse(dr.FechaIndiceInc, FechaIndiceInc.Value)
            End If
            FechaIndemnidad = Nothing
            If Not String.IsNullOrEmpty(dr.FechaIndemnidad) Then
               DateTime.TryParse(dr.FechaIndemnidad, FechaIndemnidad.Value)
            End If


            If dr.___Estado = "A" Then
               sClientes.Proveedores_I(dr.IdProveedor, dr.CodigoProveedor, dr.CodigoProveedorLetras, dr.TipoDocProveedor,
                                       dr.NroDocProveedor, dr.NombreProveedor, dr.DireccionProveedor, dr.IdLocalidadProveedor,
                                       dr.CuitProveedor, dr.TelefonoProveedor, dr.FaxProveedor, dr.IdCategoriaFiscal, dr.IngresosBrutos,
                                       dr.CorreoElectronico, dr.Observacion, dr.IdCategoria, dr.IdRubroCompra, dr.IdCuentaCaja,
                                       dr.Activo, dr.EsPasibleRetencion, dr.IdRegimen, dr.IdTipoComprobante,
                                       dr.DescuentoRecargoPorc, dr.IdFormasPago, dr.PorCtaOrden, FechaHigSeg, FechaRes559,
                                       FechaIndiceInc, dr.EsPasibleRetencionIVA, dr.IdRegimenIVA, dr.EsPasibleRetencionIIBB,
                                       dr.IdRegimenIIBB, dr.IdRegimenGan, dr.IdCuentaContable, dr.NombreDeFantasia, dr.IdCuentaBanco,
                                       dr.NivelAutorizacion, FechaIndemnidad, dr.EsProveedorGenerico, dr.CBUProveedor, dr.CBUAliasProveedor, dr.CBUCuit, dr.CorreoAdministrativo, nroCuenta:=Nothing,
                                       dr.IdConceptoCM05, dr.IdTransportista, dr.IdClienteVinculado, dr.IdRegimenIIBBComplem)
            ElseIf dr.___Estado = "M" Then
               sClientes.Proveedores_U(dr.IdProveedor, dr.CodigoProveedor, dr.CodigoProveedorLetras, dr.TipoDocProveedor,
                                       dr.NroDocProveedor, dr.NombreProveedor, dr.DireccionProveedor, dr.IdLocalidadProveedor,
                                       dr.CuitProveedor, dr.TelefonoProveedor, dr.FaxProveedor, dr.IdCategoriaFiscal, dr.IngresosBrutos,
                                       dr.CorreoElectronico, dr.Observacion, dr.IdCategoria, dr.IdRubroCompra, dr.IdCuentaCaja,
                                       dr.Activo, dr.EsPasibleRetencion, dr.IdRegimen, dr.IdTipoComprobante,
                                       dr.DescuentoRecargoPorc, dr.IdFormasPago, dr.PorCtaOrden, FechaHigSeg, FechaRes559,
                                       FechaIndiceInc, dr.EsPasibleRetencionIVA, dr.IdRegimenIVA, dr.EsPasibleRetencionIIBB,
                                       dr.IdRegimenIIBB, dr.IdRegimenGan, dr.IdCuentaContable, dr.NombreDeFantasia, dr.IdCuentaBanco,
                                       dr.NivelAutorizacion, FechaIndemnidad, dr.EsProveedorGenerico, dr.CBUProveedor, dr.CBUAliasProveedor, dr.CBUCuit, dr.CorreoAdministrativo, nroCuenta:=Nothing,
                                       dr.IdConceptoCM05, dr.IdTransportista, dr.IdClienteVinculado, dr.IdRegimenIIBBComplem)
            End If

            dr.___Estado = "I"

            'Dim fechaActualizacion As String = Clientes.ObtieneValor(dr, Entidades.Rubro.Columnas.FechaActualizacionWeb.ToString(), String.Empty)
            'If IsDate(fechaActualizacion) Then
            '   Dim fecha As DateTime = DateTime.Parse(fechaActualizacion)
            '   If Not maximoFechaActualizacion.HasValue Then
            '      maximoFechaActualizacion = fecha
            '   End If

            '   If fecha > maximoFechaActualizacion Then
            '      maximoFechaActualizacion = fecha
            '   End If
            'End If
            OnAvanceImportarDatos(eventArgs)

         Next
         'If maximoFechaActualizacion.HasValue Then
         '   Publicos.WebArchivos.Rubros.GuardarFechaUltimaDescarga(maximoFechaActualizacion.Value, da)
         'End If
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Public Function GetProveedoresJSonTransporte() As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte)
      Dim datos As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSon) = GetProveedoresJSon()
      Dim result As List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte) = New List(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte)()
      Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()

      For Each jEntidad As Entidades.JSonEntidades.Archivos.ProveedorJSon In datos
         Dim tEntidad As Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte
         tEntidad = New Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte(jEntidad.CuitEmpresa, jEntidad.IdProveedor, Now.ToString(Entidades.JSonEntidades.AyudanteJson.FormatoFechas)) 'jEntidad.FechaActualizacionWeb)
         tEntidad.DatosProveedor = serializer.Serialize(jEntidad)
         result.Add(tEntidad)
      Next

      Return result
   End Function

#End Region

End Class