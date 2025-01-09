Imports Eniac.Entidades.Cliente
Imports Microsoft.Reporting.WinForms
Public Class ProveedoresABM

   Friend WithEvents tsbCstAfip As ToolStripButton
   Friend WithEvents tsbSepAfip As ToolStripSeparator

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()

      '-- Nuevo Boton de Consulta AFIP.- 
      tsbSepAfip = New ToolStripSeparator()
      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbBorrar) + 1, tsbSepAfip)

      tsbCstAfip = New ToolStripButton()
      With tsbCstAfip
         .Image = My.Resources.Afip
         .ImageTransparentColor = Color.Magenta
         .Name = "tsbCstAfip"
         .Size = New Size(65, 26)
         .Text = "AFIP"
         .ToolTipText = "Sincronizar Contribuyentes con Afip."
      End With
      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbSepAfip) + 1, tsbCstAfip)

   End Sub
   Private Sub tsbCstAfip_Click(sender As Object, e As EventArgs) Handles tsbCstAfip.Click
      TryCatched(Sub() CallSincronizarcionAFIP())
   End Sub
#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ProveedoresDetalle(DirectCast(GetEntidad(), Entidades.Proveedor))
      End If
      Return New ProveedoresDetalle(New Entidades.Proveedor())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Proveedores()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
         Sub()
            Dim parm = New List(Of ReportParameter)
            parm.Add(New ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

            Using frmImprime = New VisorReportes("Eniac.Win.Proveedores.rdlc", "SistemaDataSet_Proveedores", dtDatos, parm, True, 1)
               frmImprime.Text = "Proveedores"
               frmImprime.ShowDialog()
            End Using
         End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()

      Dim provee = New Entidades.Proveedor()
      Dim blnIncluirFoto = True

      With dgvDatos.ActiveCell.Row
         provee = New Reglas.Proveedores().GetUno(Long.Parse(.Cells("IdProveedor").Value.ToString()), blnIncluirFoto)
         provee.Usuario = actual.Nombre
      End With

      Return provee
   End Function

   Protected Overrides Sub FormatearGrilla()
      dgvDatos.AgregarFiltroEnLinea({"CodigoProveedor", "NombreProveedor", "NombreDeFantasia", "DireccionProveedor",
                                     "Observacion", "TelefonoProveedor", "CorreoElectronico", "NombreTransportista"})

      Dim col = 0I
      With dgvDatos.DisplayLayout.Bands(0)
         .Columns("IdProveedor").Hidden = True

         .Columns("CodigoProveedor").FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns("CodigoProveedorLetras").Hidden = True
         .Columns("NombreProveedor").FormatearColumna("Nombre", col, 200)
         .Columns("NombreDeFantasia").FormatearColumna("Nombre de Fantasia", col, 200)
         .Columns("DireccionProveedor").FormatearColumna("Dirección", col, 120)
         .Columns("IdLocalidadProveedor").Hidden = True
         .Columns("NombreLocalidad").FormatearColumna("Localidad", col, 120)
         .Columns("IdCategoriaFiscal").Hidden = True
         .Columns("NombreCategoriaFiscal").FormatearColumna("Categoría Fiscal", col, 120)
         .Columns("IdCategoria").Hidden = True
         .Columns("NombreCategoria").FormatearColumna("Categoría", col, 120)
         .Columns("IdRubroCompra").Hidden = True
         .Columns("NombreRubro").FormatearColumna("Rubro", col, 120)
         .Columns("CuitProveedor").FormatearColumna(My.Resources.RTextos.Cuit, col, 90)
         .Columns("TipoDocProveedor").FormatearColumna("Tipo", col, 50)
         .Columns("NroDocProveedor").FormatearColumna("Nro. Doc.", col, 80, HAlign.Right)
         .Columns("CBUProveedor").FormatearColumna("CBU", col, 155)
         .Columns("CBUAliasProveedor").FormatearColumna("CBU Alias", col, 130)
         .Columns("CBUCuit").FormatearColumna("CBU Cuit", col, 90)

         .Columns("IngresosBrutos").FormatearColumna("Ing. Brutos", col, 120)
         .Columns("TelefonoProveedor").FormatearColumna("Teléfono", col, 170)
         .Columns("FaxProveedor").FormatearColumna("Fax", col, 170)
         .Columns("CorreoElectronico").FormatearColumna("Correo Electronico", col, 150)
         .Columns("CorreoAdministrativo").FormatearColumna("Correo Administrativo", col, 150)
         .Columns("LetraFiscal").Hidden = True
         .Columns("IdCategoriaFiscal").Hidden = True
         .Columns("IdCuentaCaja").Hidden = True
         .Columns("IdCuentaBanco").Hidden = True
         .Columns("NombreCuentaCaja").FormatearColumna("Cuenta de Caja", col, 240)
         .Columns("NombreCuentaBanco").FormatearColumna("Cuenta de Banco", col, 240)
         .Columns("NivelAutorizacion").FormatearColumna("Nivel de Autorización", col, 85, HAlign.Right)
         .Columns("Activo").FormatearColumna("Activo", col, 50)
         .Columns("EsProveedorGenerico").FormatearColumna("Proveedor Eventual", col, 80)

         .Columns("EsPasibleRetencionIIBB").Hidden = True 'Colocar Bien
         .Columns("EsPasibleRetencion").FormatearColumna("Ret. Gan", col, 70)
         .Columns("EsPasibleRetencion").Hidden = Not Reglas.Publicos.RetieneGanancias
         .Columns("IdRegimenIVA").Hidden = True 'Colocar Bien
         .Columns("EsPasibleRetencionIVA").FormatearColumna("Ret. IVA", col, 70)
         .Columns("EsPasibleRetencionIVA").Hidden = Not Reglas.Publicos.RetieneGanancias

         .Columns("IdConceptoCM05").OcultoPosicion(True, col)
         .Columns("DescripcionConceptoCM05").FormatearColumna("Concepto CM05", col, 150)
         .Columns("TipoConceptoCM05").FormatearColumna("Tipo Concepto", col, 100, HAlign.Center)

         .Columns("IdRegimen").Hidden = True
         .Columns("IdRegimenGan").Hidden = True 'Colocar Bien
         .Columns("IdRegimenIIBB").Hidden = True 'Colocar Bien

         .Columns("IdTipoComprobante").FormatearColumna("Comprob. Compra", col, 70)
         .Columns("DescuentoRecargoPorc").FormatearColumna("Desc/Rec. %", col, 70, HAlign.Right, , "N2")

         .Columns("PorCtaOrden").FormatearColumna("Por Cta. Orden", col, 60, HAlign.Center)

         .Columns("IdFormasPago").Hidden = True
         .Columns("DescripcionFormasPago").FormatearColumna("Forma Pago", col, 80)


         .Columns("FechaHigSeg").FormatearColumna("Fecha HyS", col, 80)
         .Columns("FechaRes559").FormatearColumna("Fecha Res559", col, 80)
         .Columns("FechaIndiceInc").FormatearColumna("Fecha Indice", col, 80)
         .Columns("FechaIndemnidad").FormatearColumna("Fecha Indemnidad", col, 80)

         .Columns(Entidades.Proveedor.Columnas.IdCuentaContable.ToString()).FormatearColumna("Cuenta", col, 90)
         .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).FormatearColumna("Nombre Cuenta", col, 280)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.Proveedor.Columnas.IdCuentaContable.ToString()).Hidden = True
            .Columns(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).Hidden = True
         End If

         .Columns("Observacion").FormatearColumna("Observacion", col, 300)

         .Columns("Foto").Hidden = True
         .Columns("NroCuenta").Hidden = True

         .Columns("IdTransportista").Hidden = True
         .Columns("NombreTransportista").FormatearColumna("Transportista", col, 120)

         .Columns(Entidades.Proveedor.Columnas.IdClienteVinculado.ToString()).OcultoPosicion(hidden:=True, col)
         .Columns("CodigoClienteVinculado").FormatearColumna("Código Cliente", col, 60, HAlign.Right)
         .Columns("NombreClienteVinculado").FormatearColumna("Cliente Vinculado", col, 200)

      End With
   End Sub

#End Region

   Private Sub CallSincronizarcionAFIP()
      Using frm As New SincronizarConAFIP
         '-- Define Tipo de Consulta.- --
         frm.TipoClienteProveedor = Entidades.Publicos.TipoContribuyente.PROVEEDOR
         frm.ShowDialog(Me)
      End Using
      MyBase.RefreshGrid()
   End Sub

End Class