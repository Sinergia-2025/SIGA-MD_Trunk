Imports Eniac.Reglas.ServiciosRest.Sincronizacion
Public Class Proveedores
   Inherits BaseSync(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte, Entidades.JSonEntidades.Archivos.ProveedorJSon)
   Implements IRestServices
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.ProveedorJSonTransporte, Entidades.JSonEntidades.Archivos.ProveedorJSon)

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Proveedores"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.Proveedor), TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.Proveedor), TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaSP(DirectCast(entidad, Entidades.Proveedor), TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Proveedores(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA()
   End Function

   Public Sub Inserta(entidad As Entidades.Proveedor)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(entidad As Entidades.Proveedor)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Proveedor, tipo As TipoSP)

      'Dim en As Entidades.Proveedor = DirectCast(entidad, Entidades.Proveedor)
      Dim blnConexionAbierta = da.Connection.State = ConnectionState.Open

      Try
         If Not blnConexionAbierta Then
            da.OpenConection()
            da.BeginTransaction()
         End If

         Dim idCuenta As Long? = Nothing
         If en.CuentaContable IsNot Nothing Then idCuenta = en.CuentaContable.IdCuenta

         Dim sql = New SqlServer.Proveedores(da)
         Select Case tipo

            Case TipoSP._I

               If String.IsNullOrWhiteSpace(en.CodigoProveedorLetras) Then
                  en.CodigoProveedorLetras = en.CodigoProveedor.ToString()
               End If

               en.IdProveedor = sql.GetCodigoMaximo(Entidades.Proveedor.Columnas.IdProveedor.ToString()) + 1
               If en.CodigoProveedor < 0 Then
                  en.CodigoProveedor = en.IdProveedor
               End If

               sql.Proveedores_I(en.IdProveedor, en.CodigoProveedor, en.CodigoProveedorLetras, en.TipoDocProveedor, en.NroDocProveedor, en.NombreProveedor, en.DireccionProveedor,
                                 en.IdLocalidadProveedor, en.CuitProveedor, en.TelefonoProveedor, en.FaxProveedor,
                                 en.CategoriaFiscal.IdCategoriaFiscal, en.IngresosBrutos, en.CorreoElectronico, en.Observacion,
                                 en.Categoria.IdCategoria, en.RubroCompra.IdRubro, en.CuentaDeCaja.IdCuentaCaja, en.Activo,
                                 en.EsPasibleRetencion, en.Regimen.IdRegimen, en.IdTipoComprobante, en.DescuentoRecargoPorc, en.IdFormasPago, en.PorCtaOrden,
                                 en.FechaHigSeg, en.FechaRes559, en.FechaIndiceInc, en.EsPasibleRetencionIVA, en.RegimenIVA.IdRegimen, en.EsPasibleRetencionIIBB, en.RegimenIIBB.IdRegimen, en.RegimenGan.IdRegimen, idCuenta,
                                 en.NombreDeFantasia, en.CuentaBanco.IdCuentaBanco, en.NivelAutorizacion, en.FechaIndemnidad, en.EsProveedorGenerico, en.CBUProveedor, en.CBUAliasProveedor, en.CBUCuit,
                                 en.CorreoAdministrativo, en.NroCuenta, en.IdConceptoCM05, en.IdTransportista, en.IdClienteVinculado, en.RegimenIIBBComplem.IdRegimen)

               sql.GrabarFoto(en.Foto, en.IdProveedor, en.NombreProveedor)

            Case TipoSP._U
               sql.Proveedores_U(en.IdProveedor, en.CodigoProveedor, en.CodigoProveedorLetras, en.TipoDocProveedor, en.NroDocProveedor, en.NombreProveedor, en.DireccionProveedor,
                                 en.IdLocalidadProveedor, en.CuitProveedor, en.TelefonoProveedor, en.FaxProveedor,
                                 en.CategoriaFiscal.IdCategoriaFiscal, en.IngresosBrutos, en.CorreoElectronico, en.Observacion,
                                 en.Categoria.IdCategoria, en.RubroCompra.IdRubro, en.CuentaDeCaja.IdCuentaCaja, en.Activo,
                                 en.EsPasibleRetencion, en.Regimen.IdRegimen, en.IdTipoComprobante, en.DescuentoRecargoPorc, en.IdFormasPago, en.PorCtaOrden,
                                 en.FechaHigSeg, en.FechaRes559, en.FechaIndiceInc, en.EsPasibleRetencionIVA, en.RegimenIVA.IdRegimen, en.EsPasibleRetencionIIBB, en.RegimenIIBB.IdRegimen, en.RegimenGan.IdRegimen, idCuenta,
                                 en.NombreDeFantasia, en.CuentaBanco.IdCuentaBanco, en.NivelAutorizacion, en.FechaIndemnidad, en.EsProveedorGenerico, en.CBUProveedor, en.CBUAliasProveedor, en.CBUCuit,
                                 en.CorreoAdministrativo, en.NroCuenta, en.IdConceptoCM05, en.IdTransportista, en.IdClienteVinculado, en.RegimenIIBBComplem.IdRegimen)

               sql.GrabarFoto(en.Foto, en.IdProveedor, en.NombreProveedor)

            Case TipoSP._D
               sql.Proveedores_D(en.IdProveedor)
         End Select

         If Not blnConexionAbierta Then
            da.CommitTransaction()
         End If

      Catch
         If Not blnConexionAbierta Then
            da.RollbakTransaction()
         End If
         Throw
      Finally
         If Not blnConexionAbierta Then
            da.CloseConection()
         End If
      End Try
   End Sub

   Private Sub CargarUno(o As Entidades.Proveedor, dr As DataRow)
      With o
         .IdProveedor = Long.Parse(dr("IdProveedor").ToString())
         .CodigoProveedor = Long.Parse(dr("CodigoProveedor").ToString())
         .CodigoProveedorLetras = dr.Field(Of String)(Entidades.Proveedor.Columnas.CodigoProveedorLetras.ToString())
         .NombreProveedor = dr("NombreProveedor").ToString()
         .NombreDeFantasia = dr(Entidades.Proveedor.Columnas.NombreDeFantasia.ToString()).ToString()
         .DireccionProveedor = dr("DireccionProveedor").ToString()
         .IdLocalidadProveedor = Integer.Parse(dr("IdLocalidadProveedor").ToString())
         .NombreLocalidad = New Reglas.Localidades(da).GetUna(Integer.Parse(dr("IdLocalidadProveedor").ToString())).NombreLocalidad
         .CategoriaFiscal = New Reglas.CategoriasFiscales(da)._GetUno(Short.Parse(dr("IdCategoriaFiscal").ToString()))
         .CuitProveedor = dr("CuitProveedor").ToString()

         If Not String.IsNullOrEmpty(dr("TipoDocProveedor").ToString()) Then
            .TipoDocProveedor = dr("TipoDocProveedor").ToString()
            .NroDocProveedor = Long.Parse(dr("NroDocProveedor").ToString())
         End If

         .IngresosBrutos = dr("IngresosBrutos").ToString()
         .TelefonoProveedor = dr("TelefonoProveedor").ToString()
         .FaxProveedor = dr("FaxProveedor").ToString()
         .CorreoElectronico = dr("CorreoElectronico").ToString()
         .Observacion = dr("Observacion").ToString()
         .Categoria = New Reglas.CategoriasProveedores(da).GetUno(Integer.Parse(dr("IdCategoria").ToString()))
         .RubroCompra = New Reglas.RubrosCompras(da).GetUno(Integer.Parse(dr("IdRubroCompra").ToString()))
         .CuentaDeCaja = New Reglas.CuentasDeCajas(da).GetUna(Integer.Parse(dr("IdCuentaCaja").ToString()))
         .Activo = Boolean.Parse(dr("Activo").ToString())
         If Not String.IsNullOrEmpty(dr("EsPasibleRetencion").ToString()) Then
            .EsPasibleRetencion = Boolean.Parse(dr("EsPasibleRetencion").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimen").ToString()) Then
            .Regimen = New Reglas.Regimenes(da)._GetUno(Int32.Parse(dr("IdRegimen").ToString()))
         End If

         If Not String.IsNullOrEmpty(dr("IdRegimenGan").ToString()) Then
            .RegimenGan = New Reglas.Regimenes(da)._GetUno(Int32.Parse(dr("IdRegimenGan").ToString()))
         End If

         If Not String.IsNullOrEmpty(dr("EsPasibleRetencionIVA").ToString()) Then
            .EsPasibleRetencionIVA = Boolean.Parse(dr("EsPasibleRetencionIVA").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimenIVA").ToString()) Then
            .RegimenIVA = New Reglas.Regimenes(da)._GetUno(Int32.Parse(dr("IdRegimenIVA").ToString()))
         End If

         If Not String.IsNullOrEmpty(dr("EsPasibleRetencionIIBB").ToString()) Then
            .EsPasibleRetencionIIBB = Boolean.Parse(dr("EsPasibleRetencionIIBB").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimenIIBB").ToString()) Then
            .RegimenIIBB = New Reglas.Regimenes(da)._GetUno(Int32.Parse(dr("IdRegimenIIBB").ToString()))
         End If
         If Not String.IsNullOrEmpty(dr("IdRegimenIIBBComplem").ToString()) Then
            .RegimenIIBBComplem = New Reglas.Regimenes(da)._GetUno(Int32.Parse(dr("IdRegimenIIBBComplem").ToString()))
         End If

         .CorreoElectronico = dr("CorreoElectronico").ToString()
         If Not String.IsNullOrEmpty(dr("IdTipoComprobante").ToString()) Then
            .IdTipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr("IdTipoComprobante").ToString()).IdTipoComprobante
         End If

         If Not String.IsNullOrEmpty(dr("DescuentoRecargoPorc").ToString()) Then
            .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("IdFormasPago").ToString()) Then
            .IdFormasPago = Integer.Parse(dr("IdFormasPago").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("PorCtaOrden").ToString()) Then
            .PorCtaOrden = Boolean.Parse(dr("PorCtaOrden").ToString())
         End If

         If Not String.IsNullOrEmpty(dr("Foto").ToString()) Then
            Dim content() As Byte = CType(dr("Foto"), Byte())
            Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream(content)
            .Foto = New System.Drawing.Bitmap(stream)
         End If

         If IsDBNull(dr(Entidades.Proveedor.Columnas.FechaHigSeg.ToString())) Then
            .FechaHigSeg = Nothing
         Else
            .FechaHigSeg = Convert.ToDateTime(dr(Entidades.Proveedor.Columnas.FechaHigSeg.ToString()))
         End If
         If IsDBNull(dr(Entidades.Proveedor.Columnas.FechaRes559.ToString())) Then
            .FechaRes559 = Nothing
         Else
            .FechaRes559 = Convert.ToDateTime(dr(Entidades.Proveedor.Columnas.FechaRes559.ToString()))
         End If
         If IsDBNull(dr(Entidades.Proveedor.Columnas.FechaIndiceInc.ToString())) Then
            .FechaIndiceInc = Nothing
         Else
            .FechaIndiceInc = Convert.ToDateTime(dr(Entidades.Proveedor.Columnas.FechaIndiceInc.ToString()))
         End If

         If Not IsDBNull(dr(Entidades.Proveedor.Columnas.IdCuentaContable.ToString())) Then
            .CuentaContable = New ContabilidadCuentas(da)._GetUna(CLng(dr(Entidades.Proveedor.Columnas.IdCuentaContable.ToString())))
         End If

         .CuentaBanco = New Reglas.CuentasBancos(da).GetUna(Integer.Parse(dr(Entidades.Proveedor.Columnas.IdCuentaBanco.ToString()).ToString()))

         .NivelAutorizacion = Short.Parse(dr(Entidades.Proveedor.Columnas.NivelAutorizacion.ToString()).ToString())

         If IsDBNull(dr(Entidades.Proveedor.Columnas.FechaIndemnidad.ToString())) Then
            .FechaIndemnidad = Nothing
         Else
            .FechaIndemnidad = Convert.ToDateTime(dr(Entidades.Proveedor.Columnas.FechaIndemnidad.ToString()))
         End If

         .EsProveedorGenerico = Boolean.Parse(dr(Entidades.Proveedor.Columnas.EsProveedorGenerico.ToString()).ToString())

         .CBUProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CBUProveedor.ToString())
         .CBUAliasProveedor = dr.Field(Of String)(Entidades.Proveedor.Columnas.CBUAliasProveedor.ToString())
         .CBUCuit = dr.Field(Of String)(Entidades.Proveedor.Columnas.CBUCuit.ToString())
         .CorreoAdministrativo = dr.Field(Of String)(Entidades.Proveedor.Columnas.CorreoAdministrativo.ToString())
         .NroCuenta = dr.Field(Of String)(Entidades.Proveedor.Columnas.NroCuenta.ToString())
         .IdConceptoCM05 = dr.Field(Of Integer?)(Entidades.Proveedor.Columnas.IdConceptoCM05.ToString())
         If Not String.IsNullOrEmpty(dr("IdTransportista").ToString()) Then
            .IdTransportista = Integer.Parse(dr("IdTransportista").ToString())
         End If
         .IdClienteVinculado = dr.Field(Of Long?)(Entidades.Proveedor.Columnas.IdClienteVinculado.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Function GetCodigoMaximo(campo As String) As Long
      Return New SqlServer.Proveedores(da).GetCodigoMaximo(campo)
   End Function

   Public Function GetFiltradoPorCodigo(CodigoProveedor As Long,
                                        Optional BusquedaParcial As Boolean = True) As DataTable
      Dim sql = New SqlServer.Proveedores(da)
      Dim dt = sql.Proveedores_G1_Codigo(CodigoProveedor, incluirFoto:=False, codigoExacto:=True, activo:=True)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = sql.Proveedores_G1_Codigo(CodigoProveedor, incluirFoto:=False, codigoExacto:=False, activo:=True)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorCodigoLetras(CodigoLetrasProveedor As String,
                                        Optional BusquedaParcial As Boolean = True) As DataTable
      Dim sql = New SqlServer.Proveedores(da)
      Dim dt = sql.Proveedores_G1_CodigoLetras(CodigoLetrasProveedor, incluirFoto:=False)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = sql.Proveedores_G1_CodigoLetras(CodigoLetrasProveedor, incluirFoto:=False)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorCodigoTodos(CodigoProveedor As Long, Optional BusquedaParcial As Boolean = True) As DataTable

      Dim sql = New SqlServer.Proveedores(da)
      Dim dt = sql.Proveedores_G1_Codigo(CodigoProveedor, incluirFoto:=False, codigoExacto:=True, activo:=Nothing)
      If dt.Rows.Count = 0 And BusquedaParcial Then
         dt = sql.Proveedores_G1_Codigo(CodigoProveedor, incluirFoto:=False, codigoExacto:=False, activo:=Nothing)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(nombreProveedor As String) As DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA_Nombre(nombreProveedor, nombreExacto:=False, nombreProveedorYFantasia:=True, activo:=True)
   End Function

   Public Function GetFiltradoPorDireccion(direccionProveedor As String) As DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA_Direccion(direccionProveedor, True)
   End Function

   Public Function GetFiltradoPorCtaOrden() As DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA_CtaOrden(True)
   End Function

   Public Function GetFiltradoPorCUIT(cuit As String) As DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA_Cuit(cuit, True)
   End Function

   Public Function GetUno(idProveedor As Long, Optional incluirFoto As Boolean = False) As Entidades.Proveedor
      Try
         da.OpenConection()
         Return _GetUno(idProveedor, incluirFoto)
      Finally
         da.CloseConection()
      End Try
   End Function

   Public Function _GetUno(idProveedor As Long, Optional incluirFoto As Boolean = False) As Entidades.Proveedor
      Dim dt = New SqlServer.Proveedores(da).Proveedores_G1(idProveedor, incluirFoto)
      Dim oProv = New Entidades.Proveedor()
      If dt.Rows.Count > 0 Then
         CargarUno(oProv, dt.Rows(0))
      End If
      Return oProv
   End Function

   <Obsolete("Usar _GetUno")>
   Public Function Proveedores_G1Todos(IdProveedor As Long, Optional incluirFoto As Boolean = False) As Entidades.Proveedor
      Return _GetUno(IdProveedor, incluirFoto)
   End Function

   Public Function GetTodos() As List(Of Entidades.Proveedor)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Proveedor
      Dim oLis As List(Of Entidades.Proveedor) = New List(Of Entidades.Proveedor)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Proveedor()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function ExisteProveedorPorCodigoNombre(codigoProveedor As Long, nombreProveedor As String) As Boolean
      Return New SqlServer.Proveedores(da).ExisteProveedor(codigoProveedor, nombreProveedor)
   End Function

   Public Sub ImportarProveedores(idSucursal As Integer,
                                  dt As DataTable,
                                  usuario As String,
                                  barraProg As System.Windows.Forms.ProgressBar)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim oCategorias As Eniac.Reglas.CategoriasProveedores = New Eniac.Reglas.CategoriasProveedores(da)
         Dim dtCategorias As DataTable = New DataTable
         Dim Categoria As Entidades.CategoriaProveedor = New Entidades.CategoriaProveedor

         Dim oCategoriasFiscales As Eniac.Reglas.CategoriasFiscales = New Eniac.Reglas.CategoriasFiscales(da)
         Dim dtCategoriasFiscales As DataTable = New DataTable
         Dim CategoriaFiscal As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal

         Dim oRubrosCompras As Eniac.Reglas.RubrosCompras = New Eniac.Reglas.RubrosCompras(da)
         Dim dtRubrosCompras As DataTable = New DataTable
         Dim RubrosCompras As Entidades.RubroCompra = New Entidades.RubroCompra

         Dim oCuentasDeCajas As Eniac.Reglas.CuentasDeCajas = New Eniac.Reglas.CuentasDeCajas(da)
         Dim dtCuentasDeCajas As DataTable = New DataTable
         Dim CuentasDeCajas As Entidades.CuentaDeCaja = New Entidades.CuentaDeCaja

         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores(da)
         Dim ExisteProveedor As Boolean
         Dim Proveedor As Entidades.Proveedor = New Entidades.Proveedor

         Dim AnchoNombreProveedor As Integer = New Reglas.Publicos().GetAnchoCampo("Proveedores", "NombreProveedor")
         Dim AnchoTelefono As Integer = New Reglas.Publicos().GetAnchoCampo("Proveedores", "TelefonoProveedor")


         Dim i As Integer = 0

         barraProg.Maximum = dt.Rows.Count
         barraProg.Minimum = 0
         barraProg.Value = 0

         For Each dr As DataRow In dt.Rows

            i += 1
            barraProg.Value = i

            'If i = 150 Then
            '   Stop
            'End If

            If Boolean.Parse(dr("Importa").ToString()) Then

               ExisteProveedor = oProveedores.ExisteProveedorPorCodigoNombre(Long.Parse(dr("CodigoProveedor").ToString()), "")

               If ExisteProveedor Then

                  Proveedor = oProveedores.GetUnoPorCodigo(Long.Parse(dr("CodigoProveedor").ToString()), False)
               Else
                  Proveedor.IdProveedor = 0
                  Proveedor.CodigoProveedor = Long.Parse(dr("CodigoProveedor").ToString.Trim())
               End If

               dtCategorias = oCategorias.GetPorNombreExacto(dr("NombreCategoria").ToString())


               Proveedor.Categoria.IdCategoria = Integer.Parse(dtCategorias.Rows(0)("IdCategoria").ToString())


               dtCategoriasFiscales = oCategoriasFiscales.GetPorNombreExacto(dr("NombreCategoriaFiscal").ToString())
               Proveedor.CategoriaFiscal.IdCategoriaFiscal = Short.Parse(dtCategoriasFiscales.Rows(0)("IdCategoriaFiscal").ToString())

               If Not String.IsNullOrEmpty(dr("TipoDocProveedor").ToString.Trim()) And Not String.IsNullOrEmpty(dr("NroDocProveedor").ToString.Trim()) Then
                  Proveedor.TipoDocProveedor = dr("TipoDocProveedor").ToString.Trim()
                  Proveedor.NroDocProveedor = Long.Parse(dr("NroDocProveedor").ToString.Trim())
               Else
                  Proveedor.TipoDocProveedor = ""
                  Proveedor.NroDocProveedor = 0
               End If

               If Strings.Trim(dr("NombreProveedor").ToString.Trim()).Length > AnchoNombreProveedor Then
                  Proveedor.NombreProveedor = Strings.Trim(dr("NombreProveedor").ToString.Trim()).Remove(AnchoNombreProveedor)
               Else
                  Proveedor.NombreProveedor = Strings.Trim(dr("NombreProveedor").ToString.Trim())
               End If
               Proveedor.DireccionProveedor = dr("Direccion").ToString()

               Proveedor.IdLocalidadProveedor = Integer.Parse(dr("IdLocalidadProveedor").ToString())

               If Strings.Trim(dr("Telefono").ToString.Trim()).Length > AnchoTelefono Then
                  Proveedor.TelefonoProveedor = Strings.Trim(dr("Telefono").ToString().Trim()).Remove(AnchoTelefono)
               Else
                  Proveedor.TelefonoProveedor = Strings.Trim(dr("Telefono").ToString().Trim())
               End If

               Proveedor.IngresosBrutos = dr("IngresosBrutos").ToString()

               dtRubrosCompras = oRubrosCompras.GetPorNombreExacto(dr("NombreRubro").ToString())
               Proveedor.RubroCompra.IdRubro = Integer.Parse(dtRubrosCompras.Rows(0)("IdRubro").ToString())

               dtCuentasDeCajas = oCuentasDeCajas.GetPorNombreExacto(dr("NombreCuentaCaja").ToString())
               Proveedor.CuentaDeCaja.IdCuentaCaja = Integer.Parse(dtCuentasDeCajas.Rows(0)("IdCuentaCaja").ToString())

               Proveedor.CuentaBanco = DirectCast(dr("CuentaBanco_Entidad"), Entidades.CuentaBanco)

               Proveedor.CorreoElectronico = dr("CorreoElectronico").ToString()

               Proveedor.Usuario = usuario

               If Not String.IsNullOrEmpty(Strings.Trim(dr("CUIT").ToString.Trim())) Then
                  Proveedor.CuitProveedor = Strings.Trim(dr("CUIT").ToString.Trim()).Replace("-", "")
               Else
                  Proveedor.CuitProveedor = String.Empty
               End If

               If Not ExisteProveedor Then

                  Proveedor.IdSucursal = idSucursal
                  Proveedor.Activo = True
                  Proveedor.Observacion = ""
                  Proveedor.DescuentoRecargoPorc = 0
                  Proveedor.IdTipoComprobante = ""
                  Proveedor.IdFormasPago = 0
                  Proveedor.EsPasibleRetencion = False

                  oProveedores.Inserta(Proveedor)
               Else
                  oProveedores.Actualiza(Proveedor)
               End If

            End If
         Next

         da.CommitTransaction()

      Catch
         barraProg.Value = 0
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub


   Public Function GetUnoPorCodigo(codigoProveedor As Long, Optional incluirFoto As Boolean = False) As Entidades.Proveedor
      Dim dt As DataTable = New SqlServer.Proveedores(da).Proveedores_G1_Codigo(codigoProveedor, activo:=True, incluirFoto:=incluirFoto, codigoExacto:=True)
      Dim oProv As Entidades.Proveedor = New Entidades.Proveedor()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(oProv, dt.Rows(0))
      End If
      Return oProv
   End Function

   Public Function GetUnoPorCodigoLetras(codigoProveedorLetras As String, incluirFoto As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.Proveedor
      Return CargaEntidad(New SqlServer.Proveedores(da).Proveedores_G1_CodigoLetras(codigoProveedorLetras, incluirFoto:=incluirFoto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Proveedor(),
                          accion, Function() String.Format("No se encontró proveedor con el Código Letra {0}", codigoProveedorLetras))
   End Function

   Public Function GetUnoPorCodigoLetrasExacto(codigoProveedorLetras As String, incluirFoto As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.Proveedor
      Return CargaEntidad(New SqlServer.Proveedores(da).Proveedores_G1_CodigoLetrasExacto(codigoProveedorLetras, incluirFoto:=incluirFoto),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Proveedor(),
                          accion, Function() String.Format("No se encontró proveedor con el Código Letra {0}", codigoProveedorLetras))
   End Function
   Public Function GetUnoPorNombre(nombreProveedor As String) As Entidades.Proveedor
      Return GetUnoPorNombre(nombreProveedor:=nombreProveedor, nombreExacto:=False)
   End Function

   Public Function GetUnoPorNombre(nombreProveedor As String, nombreExacto As Boolean) As Entidades.Proveedor
      Dim dt As DataTable = New SqlServer.Proveedores(da).Proveedores_GA_Nombre(nombreProveedor, nombreExacto:=nombreExacto, nombreProveedorYFantasia:=True, activo:=True)
      Dim oProv As Entidades.Proveedor = New Entidades.Proveedor()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(oProv, dt.Rows(0))
      End If
      Return oProv
   End Function
   Public Function GetAll_Ids() As DataTable
      Return New SqlServer.Proveedores(da).Proveedores_GA_Ids()
   End Function

   Public Sub ActualizarTelefonoMails(idProveedor As Long, Telefonos As String, Mails As String)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim pro As SqlServer.Proveedores = New SqlServer.Proveedores(Me.da)

         pro.ActualizarTelefonosMails(idProveedor, Telefonos, Mails)

         da.CommitTransaction()

      Catch ex As Exception
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

#End Region

End Class