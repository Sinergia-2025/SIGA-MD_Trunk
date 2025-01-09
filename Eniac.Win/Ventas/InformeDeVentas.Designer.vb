<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeDeVentas
    Inherits Eniac.Win.BaseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim UltraDataColumn1 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Fecha")
      Dim UltraDataColumn2 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdTipoComprobante")
      Dim UltraDataColumn3 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoComprobante")
      Dim UltraDataColumn4 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Letra")
      Dim UltraDataColumn5 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("CentroEmisor")
      Dim UltraDataColumn6 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NumeroComprobante")
      Dim UltraDataColumn7 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("TipoDocCliente")
      Dim UltraDataColumn8 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NroDocCliente")
      Dim UltraDataColumn9 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCliente")
      Dim UltraDataColumn10 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreCategoriaFiscal")
      Dim UltraDataColumn11 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("FormaDePago")
      Dim UltraDataColumn12 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("IdProducto")
      Dim UltraDataColumn13 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreProducto")
      Dim UltraDataColumn14 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreMarca")
      Dim UltraDataColumn15 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreRubro")
      Dim UltraDataColumn16 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("NombreSubRubro")
      Dim UltraDataColumn17 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Cantidad")
      Dim UltraDataColumn18 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioLista")
      Dim UltraDataColumn19 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Precio")
      Dim UltraDataColumn20 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc")
      Dim UltraDataColumn21 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorc2")
      Dim UltraDataColumn22 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("DescuentoRecargoPorcGral")
      Dim UltraDataColumn23 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("PrecioNeto")
      Dim UltraDataColumn24 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("AlicuotaImpuesto")
      Dim UltraDataColumn25 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteImpuesto")
      Dim UltraDataColumn26 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("ImporteTotalNeto")
      Dim UltraDataColumn27 As Infragistics.Win.UltraWinDataSource.UltraDataColumn = New Infragistics.Win.UltraWinDataSource.UltraDataColumn("Usuario")
        Dim Appearance60 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
        Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha")
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_FECHA")
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fecha_HORA")
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoComprobante")
        Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoComprobante")
        Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Letra")
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CentroEmisor")
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroComprobante")
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCliente")
        Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoCliente")
        Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCliente")
        Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoriaFiscal")
        Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FormaDePago")
        Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Subtotal")
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestos")
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTotal")
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Usuario")
        Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion")
        Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreVendedor")
        Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreZonaGeografica")
        Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Direccion")
        Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreLocalidad")
        Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProvincia")
        Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaActualizacion")
        Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreProveedor")
        Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImportePesos")
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn78 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteDolares")
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTickets")
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTarjetas")
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteCheques")
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCuentaBancaria")
        Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("ImporteTransfBancaria")
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreBanco")
        Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IVA")
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Percepciones")
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCategoria")
        Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CAE")
        Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CAEVencimiento")
        Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("MetodoGrabacion")
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdFuncion")
        Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroReparto")
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TotalImpuestoInterno")
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal")
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdMoneda")
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreMoneda")
        Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Simbolo")
        Dim UltraGridColumn48 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CotizacionDolar")
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn49 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdClienteVinculado")
        Dim UltraGridColumn50 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoClienteVinculado")
        Dim UltraGridColumn51 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreClienteVinculado")
        Dim UltraGridColumn52 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombresCentrosCosto")
        Dim UltraGridColumn53 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaEnvioCorreo")
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn54 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroVersionAplicacion")
        Dim UltraGridColumn55 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDeFantasia")
        Dim UltraGridColumn56 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPaciente")
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn57 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePaciente")
        Dim UltraGridColumn58 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdDoctor")
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn59 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreDoctor")
        Dim UltraGridColumn60 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaCirugia")
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn61 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NetoNoGravado")
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn62 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NetoGravado")
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn63 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdConceptoCM05")
        Dim UltraGridColumn64 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("DescripcionConceptoCM05")
        Dim UltraGridColumn65 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoConceptoCM05")
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn75 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTransportista")
        Dim UltraGridColumn76 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTransportista")
        Dim UltraGridColumn77 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaBancaria")
        Dim UltraGridColumn66 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("btnVer", 0)
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn67 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("btnVerEstandar", 1)
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn68 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("btnImprimir", 2)
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn69 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadLotes", 3)
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn70 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadInvocadosInvocadores", 4)
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn71 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja", 5)
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn72 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroPlanilla", 6)
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn73 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento", 7)
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim UltraGridColumn74 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CantidadContactos", 8)
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance54 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance55 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance56 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance57 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance58 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance59 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeDeVentas))
        Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
        Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
        Me.ugDetalle = New Eniac.Win.UltraGridSiga()
        Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
        Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
        Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
        Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
        Me.tstBarra = New System.Windows.Forms.ToolStrip()
        Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimirPrediseñado = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbImprimirFicha = New System.Windows.Forms.ToolStripButton()
        Me.tsbImpFichaCliente = New System.Windows.Forms.ToolStripButton()
        Me.tssFichas = New System.Windows.Forms.ToolStripSeparator()
        Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
        Me.stsStado = New System.Windows.Forms.StatusStrip()
        Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
        Me.chbTransportista = New Eniac.Controles.CheckBox()
        Me.cmbTransportista = New Eniac.Controles.ComboBox()
        Me.cmbOrigenCategoria = New Eniac.Controles.ComboBox()
        Me.cmbOrigenVendedor = New Eniac.Controles.ComboBox()
        Me.cmbCorreoEnviado = New Eniac.Controles.ComboBox()
        Me.lblCorreoEnviado = New Eniac.Controles.Label()
        Me.chbCentroCosto = New Eniac.Controles.CheckBox()
        Me.cmbCentroCosto = New Eniac.Controles.ComboBox()
        Me.cmbEmisor = New Eniac.Controles.ComboBox()
        Me.chbEmisor = New Eniac.Controles.CheckBox()
        Me.cboLetra = New Eniac.Controles.ComboBox()
        Me.chbLetra = New Eniac.Controles.CheckBox()
        Me.txtNumeroCompDesde = New Eniac.Controles.TextBox()
        Me.chbNumero = New Eniac.Controles.CheckBox()
        Me.chbCliente = New Eniac.Controles.CheckBox()
        Me.txtNumeroCompHasta = New Eniac.Controles.TextBox()
        Me.txtNroRepartoHasta = New Eniac.Controles.TextBox()
        Me.lblNroRepartoHasta = New Eniac.Controles.Label()
        Me.txtNroRepartoDesde = New Eniac.Controles.TextBox()
        Me.chbNroReparto = New Eniac.Controles.CheckBox()
        Me.chbProvincia = New Eniac.Controles.CheckBox()
        Me.chbLocalidad = New Eniac.Controles.CheckBox()
        Me.cmbProvincia = New Eniac.Controles.ComboBox()
        Me.bscCodigoLocalidad = New Eniac.Controles.Buscador()
        Me.bscNombreLocalidad = New Eniac.Controles.Buscador()
        Me.cmbZonaGeografica = New Eniac.Controles.ComboBox()
        Me.chbZonaGeografica = New Eniac.Controles.CheckBox()
        Me.chbCategoria = New Eniac.Controles.CheckBox()
        Me.cmbCategoria = New Eniac.Controles.ComboBox()
        Me.cmbEsComercial = New Eniac.Controles.ComboBox()
        Me.lblEsComercial = New Eniac.Controles.Label()
        Me.cmbMercDespachada = New Eniac.Controles.ComboBox()
        Me.lblMercDespachada = New Eniac.Controles.Label()
        Me.chbUsuario = New Eniac.Controles.CheckBox()
        Me.cmbUsuario = New Eniac.Controles.ComboBox()
        Me.chbFormaPago = New Eniac.Controles.CheckBox()
        Me.cmbFormaPago = New Eniac.Controles.ComboBox()
        Me.chbVendedor = New Eniac.Controles.CheckBox()
        Me.cmbVendedor = New Eniac.Controles.ComboBox()
        Me.cmbAfectaCaja = New Eniac.Controles.ComboBox()
        Me.lblAfectaCaja = New Eniac.Controles.Label()
        Me.cmbGrabanLibro = New Eniac.Controles.ComboBox()
        Me.lblGrabanLibro = New Eniac.Controles.Label()
        Me.bscCodigoCliente = New Eniac.Controles.Buscador2()
        Me.bscCliente = New Eniac.Controles.Buscador2()
        Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
        Me.lblSucursal = New Eniac.Controles.Label()
        Me.cmbTiposComprobantes = New Eniac.Win.ComboBoxTiposComprobantes()
        Me.chbTipoComprobante = New Eniac.Controles.Label()
        Me.btnConsultar = New Eniac.Win.ButtonConsultar()
        Me.chkMesCompleto = New Eniac.Controles.CheckBox()
        Me.dtpHasta = New Eniac.Controles.DateTimePicker()
        Me.lblHasta = New Eniac.Controles.Label()
        Me.dtpDesde = New Eniac.Controles.DateTimePicker()
        Me.lblDesde = New Eniac.Controles.Label()
        Me.FiltersManager1 = New Eniac.Win.FilterManager.FilterManager(Me.components)
        Me.grpFiltros = New Eniac.Controles.GroupBox()
        Me.Label2 = New Eniac.Controles.Label()
        Me.pnlHistoriaClinica = New System.Windows.Forms.Panel()
        Me.chbFechaCirugia = New Eniac.Controles.CheckBox()
        Me.bscCodigoPaciente = New Eniac.Controles.Buscador2()
        Me.dtpFechaCirugia = New Eniac.Controles.DateTimePicker()
        Me.chbPaciente = New Eniac.Controles.CheckBox()
        Me.bscCodigoDoctor = New Eniac.Controles.Buscador2()
        Me.bscPaciente = New Eniac.Controles.Buscador2()
        Me.bscDoctor = New Eniac.Controles.Buscador2()
        Me.chbDoctor = New Eniac.Controles.CheckBox()
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.chkExpandAll = New System.Windows.Forms.CheckBox()
        Me.UltraSplitter1 = New Infragistics.Win.Misc.UltraSplitter()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        Me.grpFiltros.SuspendLayout()
        Me.pnlHistoriaClinica.SuspendLayout()
        Me.pnlAcciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'UltraDataSource1
        '
        Me.UltraDataSource1.Band.Columns.AddRange(New Object() {UltraDataColumn1, UltraDataColumn2, UltraDataColumn3, UltraDataColumn4, UltraDataColumn5, UltraDataColumn6, UltraDataColumn7, UltraDataColumn8, UltraDataColumn9, UltraDataColumn10, UltraDataColumn11, UltraDataColumn12, UltraDataColumn13, UltraDataColumn14, UltraDataColumn15, UltraDataColumn16, UltraDataColumn17, UltraDataColumn18, UltraDataColumn19, UltraDataColumn20, UltraDataColumn21, UltraDataColumn22, UltraDataColumn23, UltraDataColumn24, UltraDataColumn25, UltraDataColumn26, UltraDataColumn27})
        '
        'UltraGridPrintDocument1
        '
        Me.UltraGridPrintDocument1.DocumentName = "Informe"
        Me.UltraGridPrintDocument1.Footer.TextCenter = ""
        Me.UltraGridPrintDocument1.Grid = Me.ugDetalle
        Appearance60.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance60.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance60
        Me.UltraGridPrintDocument1.Header.BorderSides = System.Windows.Forms.Border3DSide.Bottom
        Me.UltraGridPrintDocument1.Header.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Header.TextCenter = ""
        Me.UltraGridPrintDocument1.Page.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.Page.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.Page.Margins.Left = 2
        Me.UltraGridPrintDocument1.Page.Margins.Right = 2
        Me.UltraGridPrintDocument1.Page.Margins.Top = 2
        Me.UltraGridPrintDocument1.PageBody.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.UltraGridPrintDocument1.PageBody.Margins.Bottom = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Left = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Right = 2
        Me.UltraGridPrintDocument1.PageBody.Margins.Top = 2
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Center"
        UltraGridColumn1.CellAppearance = Appearance2
        UltraGridColumn1.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn1.Header.VisiblePosition = 6
        UltraGridColumn1.Hidden = True
        UltraGridColumn1.Width = 100
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn2.CellAppearance = Appearance3
        UltraGridColumn2.Header.Caption = "Fecha"
        UltraGridColumn2.Header.VisiblePosition = 4
        UltraGridColumn2.Width = 80
        Appearance4.TextHAlignAsString = "Center"
        UltraGridColumn3.CellAppearance = Appearance4
        UltraGridColumn3.Header.Caption = "Hora"
        UltraGridColumn3.Header.VisiblePosition = 5
        UltraGridColumn3.Width = 80
        UltraGridColumn4.Header.VisiblePosition = 7
        UltraGridColumn4.Hidden = True
        UltraGridColumn5.Header.Caption = "Comprobante"
        UltraGridColumn5.Header.VisiblePosition = 8
        UltraGridColumn5.Width = 90
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance5
        UltraGridColumn6.Header.Caption = "L."
        UltraGridColumn6.Header.VisiblePosition = 9
        UltraGridColumn6.Width = 20
        Appearance6.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance6
        UltraGridColumn7.Header.Caption = "Emis."
        UltraGridColumn7.Header.VisiblePosition = 10
        UltraGridColumn7.Width = 40
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn8.CellAppearance = Appearance7
        UltraGridColumn8.Header.Caption = "Número"
        UltraGridColumn8.Header.VisiblePosition = 11
        UltraGridColumn8.Width = 70
        UltraGridColumn9.Header.VisiblePosition = 12
        UltraGridColumn9.Hidden = True
        UltraGridColumn10.Header.VisiblePosition = 13
        UltraGridColumn10.Hidden = True
        UltraGridColumn11.Header.Caption = "Nombre Cliente"
        UltraGridColumn11.Header.VisiblePosition = 14
        UltraGridColumn11.Width = 166
        UltraGridColumn12.Header.Caption = "Categ. Fiscal"
        UltraGridColumn12.Header.VisiblePosition = 30
        UltraGridColumn12.Width = 76
        UltraGridColumn13.Header.Caption = "F. de Pago"
        UltraGridColumn13.Header.VisiblePosition = 16
        UltraGridColumn13.Width = 75
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance8
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "Neto"
        UltraGridColumn14.Header.VisiblePosition = 20
        UltraGridColumn14.Width = 80
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance9
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Impuestos"
        UltraGridColumn15.Header.VisiblePosition = 26
        UltraGridColumn15.Hidden = True
        UltraGridColumn15.Width = 70
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn16.CellAppearance = Appearance10
        UltraGridColumn16.Format = "N2"
        UltraGridColumn16.Header.Caption = "Total"
        UltraGridColumn16.Header.VisiblePosition = 27
        UltraGridColumn16.Width = 80
        UltraGridColumn17.Header.VisiblePosition = 34
        UltraGridColumn17.Width = 80
        UltraGridColumn18.Header.VisiblePosition = 33
        UltraGridColumn18.Width = 200
        UltraGridColumn19.Header.Caption = "Vendedor"
        UltraGridColumn19.Header.VisiblePosition = 39
        UltraGridColumn19.Width = 150
        UltraGridColumn20.Header.Caption = "Zona Geografica"
        UltraGridColumn20.Header.VisiblePosition = 38
        UltraGridColumn20.Width = 150
        UltraGridColumn21.Header.VisiblePosition = 35
        UltraGridColumn21.Width = 181
        UltraGridColumn22.Header.Caption = "Localidad"
        UltraGridColumn22.Header.VisiblePosition = 36
        UltraGridColumn22.Width = 130
        UltraGridColumn23.Header.Caption = "Provincia"
        UltraGridColumn23.Header.VisiblePosition = 37
        UltraGridColumn23.Width = 110
        UltraGridColumn24.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn24.Header.Caption = "Fecha Actualización"
        UltraGridColumn24.Header.VisiblePosition = 41
        UltraGridColumn24.Width = 114
        UltraGridColumn25.Header.Caption = "Proveedor CyO"
        UltraGridColumn25.Header.VisiblePosition = 42
        UltraGridColumn25.Width = 150
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn26.CellAppearance = Appearance11
        UltraGridColumn26.Format = "N2"
        UltraGridColumn26.Header.Caption = "Imp. Pesos"
        UltraGridColumn26.Header.VisiblePosition = 43
        UltraGridColumn26.Width = 80
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn78.CellAppearance = Appearance12
        UltraGridColumn78.Format = "N2"
        UltraGridColumn78.Header.Caption = "Imp. Dolares"
        UltraGridColumn78.Header.VisiblePosition = 44
        UltraGridColumn78.Width = 80
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance13
        UltraGridColumn27.Format = "N2"
        UltraGridColumn27.Header.Caption = "Imp. Tickets"
        UltraGridColumn27.Header.VisiblePosition = 45
        UltraGridColumn27.Width = 80
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance14
        UltraGridColumn28.Format = "N2"
        UltraGridColumn28.Header.Caption = "Imp. Tarjetas"
        UltraGridColumn28.Header.VisiblePosition = 46
        UltraGridColumn28.Width = 80
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance15
        UltraGridColumn29.Format = "N2"
        UltraGridColumn29.Header.Caption = "Imp. Cheques"
        UltraGridColumn29.Header.VisiblePosition = 47
        UltraGridColumn29.Width = 80
        UltraGridColumn30.Header.VisiblePosition = 48
        UltraGridColumn30.Hidden = True
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance16
        UltraGridColumn31.Format = "N2"
        UltraGridColumn31.Header.Caption = "Imp. Tr. Banc."
        UltraGridColumn31.Header.VisiblePosition = 49
        UltraGridColumn31.Width = 80
        UltraGridColumn32.Header.Caption = "Banco"
        UltraGridColumn32.Header.VisiblePosition = 50
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance17
        UltraGridColumn33.Format = "N2"
        UltraGridColumn33.Header.VisiblePosition = 23
        UltraGridColumn33.Width = 80
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance18
        UltraGridColumn34.Format = "N2"
        UltraGridColumn34.Header.VisiblePosition = 25
        UltraGridColumn34.Hidden = True
        UltraGridColumn34.Width = 80
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance19
        UltraGridColumn35.Header.Caption = "P."
        UltraGridColumn35.Header.VisiblePosition = 56
        UltraGridColumn35.Width = 25
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance20
        UltraGridColumn36.Header.Caption = "Asiento"
        UltraGridColumn36.Header.VisiblePosition = 61
        UltraGridColumn36.Width = 54
        UltraGridColumn37.Header.Caption = "Categoria"
        UltraGridColumn37.Header.VisiblePosition = 40
        UltraGridColumn37.Width = 90
        UltraGridColumn38.Header.VisiblePosition = 31
        UltraGridColumn39.Header.Caption = "Vencimiento CAE"
        UltraGridColumn39.Header.VisiblePosition = 32
        UltraGridColumn39.Width = 103
        Appearance21.TextHAlignAsString = "Center"
        UltraGridColumn40.CellAppearance = Appearance21
        UltraGridColumn40.Header.Caption = "Met."
        UltraGridColumn40.Header.VisiblePosition = 66
        UltraGridColumn40.Width = 40
        UltraGridColumn41.Header.Caption = "Pantalla"
        UltraGridColumn41.Header.VisiblePosition = 71
        UltraGridColumn41.Width = 200
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn42.CellAppearance = Appearance22
        UltraGridColumn42.Header.Caption = "Reparto"
        UltraGridColumn42.Header.VisiblePosition = 53
        UltraGridColumn42.Width = 80
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn43.CellAppearance = Appearance23
        UltraGridColumn43.Header.Caption = "Imp. Int."
        UltraGridColumn43.Header.VisiblePosition = 24
        UltraGridColumn43.Width = 70
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn44.CellAppearance = Appearance24
        UltraGridColumn44.Header.Caption = "S."
        UltraGridColumn44.Header.VisiblePosition = 3
        UltraGridColumn44.Width = 24
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance25
        UltraGridColumn45.Header.Caption = "Id Moneda"
        UltraGridColumn45.Header.VisiblePosition = 52
        UltraGridColumn45.Hidden = True
        UltraGridColumn46.Header.Caption = "Moneda"
        UltraGridColumn46.Header.VisiblePosition = 28
        UltraGridColumn46.Width = 80
        UltraGridColumn47.Header.VisiblePosition = 60
        UltraGridColumn47.Hidden = True
        Appearance26.TextHAlignAsString = "Right"
        UltraGridColumn48.CellAppearance = Appearance26
        UltraGridColumn48.Format = "N2"
        UltraGridColumn48.Header.Caption = "Cotización Dolar"
        UltraGridColumn48.Header.VisiblePosition = 29
        UltraGridColumn48.Width = 70
        UltraGridColumn49.Header.VisiblePosition = 54
        UltraGridColumn49.Hidden = True
        UltraGridColumn50.Header.VisiblePosition = 59
        UltraGridColumn50.Hidden = True
        UltraGridColumn51.Header.Caption = "Cliente Vinculado"
        UltraGridColumn51.Header.VisiblePosition = 55
        UltraGridColumn51.Width = 166
        UltraGridColumn52.Header.Caption = "Centros de Costo"
        UltraGridColumn52.Header.VisiblePosition = 57
        UltraGridColumn52.Width = 150
        Appearance27.TextHAlignAsString = "Center"
        UltraGridColumn53.CellAppearance = Appearance27
        UltraGridColumn53.Format = "dd/MM/yyyy HH:mm"
        UltraGridColumn53.Header.Caption = "Fecha Envio de Correo"
        UltraGridColumn53.Header.VisiblePosition = 58
        UltraGridColumn54.Header.Caption = "Versión Aplicación"
        UltraGridColumn54.Header.VisiblePosition = 72
        UltraGridColumn54.Width = 174
        UltraGridColumn55.Header.Caption = "Nombre de Fantasía"
        UltraGridColumn55.Header.VisiblePosition = 15
        UltraGridColumn55.Hidden = True
        UltraGridColumn55.Width = 166
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn56.CellAppearance = Appearance28
        UltraGridColumn56.Header.VisiblePosition = 73
        UltraGridColumn56.Hidden = True
        UltraGridColumn57.Header.Caption = "Paciente"
        UltraGridColumn57.Header.VisiblePosition = 74
        UltraGridColumn57.Width = 196
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn58.CellAppearance = Appearance29
        UltraGridColumn58.Header.VisiblePosition = 75
        UltraGridColumn58.Hidden = True
        UltraGridColumn59.Header.Caption = "Doctor"
        UltraGridColumn59.Header.VisiblePosition = 76
        UltraGridColumn59.Width = 192
        Appearance30.TextHAlignAsString = "Center"
        UltraGridColumn60.CellAppearance = Appearance30
        UltraGridColumn60.Header.Caption = "Fecha de Cirugía"
        UltraGridColumn60.Header.VisiblePosition = 77
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn61.CellAppearance = Appearance31
        UltraGridColumn61.Format = "N2"
        UltraGridColumn61.Header.Caption = "Neto No Gravado"
        UltraGridColumn61.Header.VisiblePosition = 21
        UltraGridColumn61.Hidden = True
        UltraGridColumn61.Width = 80
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn62.CellAppearance = Appearance32
        UltraGridColumn62.Format = "N2"
        UltraGridColumn62.Header.Caption = "Neto Gravado"
        UltraGridColumn62.Header.VisiblePosition = 22
        UltraGridColumn62.Hidden = True
        UltraGridColumn62.Width = 80
        UltraGridColumn63.Header.VisiblePosition = 64
        UltraGridColumn63.Hidden = True
        UltraGridColumn64.Header.Caption = "Concepto CM05"
        UltraGridColumn64.Header.VisiblePosition = 67
        UltraGridColumn64.Width = 150
        Appearance33.TextHAlignAsString = "Center"
        UltraGridColumn65.CellAppearance = Appearance33
        UltraGridColumn65.Header.Caption = "Tipo CM05"
        UltraGridColumn65.Header.VisiblePosition = 69
        UltraGridColumn65.Width = 70
        UltraGridColumn75.Header.VisiblePosition = 68
        UltraGridColumn75.Hidden = True
        UltraGridColumn76.Header.Caption = "Transportista"
        UltraGridColumn76.Header.VisiblePosition = 70
        UltraGridColumn76.Hidden = True
        UltraGridColumn76.Width = 120
        UltraGridColumn77.Header.Caption = "Cuenta Bancaria"
        UltraGridColumn77.Header.VisiblePosition = 51
        UltraGridColumn66.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance34.TextHAlignAsString = "Center"
        UltraGridColumn66.CellAppearance = Appearance34
        Appearance35.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance35.BackColor2 = System.Drawing.Color.LightGray
        Appearance35.BorderColor3DBase = System.Drawing.Color.Silver
        UltraGridColumn66.CellButtonAppearance = Appearance35
        UltraGridColumn66.Header.Caption = "Ver"
        UltraGridColumn66.Header.VisiblePosition = 0
        UltraGridColumn66.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn66.Width = 30
        UltraGridColumn67.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance36.TextHAlignAsString = "Center"
        UltraGridColumn67.CellAppearance = Appearance36
        Appearance37.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance37.BackColor2 = System.Drawing.Color.LightGray
        Appearance37.BorderColor3DBase = System.Drawing.Color.Silver
        UltraGridColumn67.CellButtonAppearance = Appearance37
        UltraGridColumn67.Header.Caption = "V.E."
        UltraGridColumn67.Header.VisiblePosition = 2
        UltraGridColumn67.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn67.Width = 32
        UltraGridColumn68.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance38.TextHAlignAsString = "Center"
        UltraGridColumn68.CellAppearance = Appearance38
        Appearance39.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance39.BackColor2 = System.Drawing.Color.LightGray
        Appearance39.BorderColor3DBase = System.Drawing.Color.Silver
        UltraGridColumn68.CellButtonAppearance = Appearance39
        UltraGridColumn68.Header.Caption = "Imp"
        UltraGridColumn68.Header.VisiblePosition = 1
        UltraGridColumn68.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn68.Width = 29
        UltraGridColumn69.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance40.TextHAlignAsString = "Center"
        UltraGridColumn69.CellAppearance = Appearance40
        Appearance41.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance41.BackColor2 = System.Drawing.Color.LightGray
        Appearance41.BorderColor3DBase = System.Drawing.Color.Silver
        UltraGridColumn69.CellButtonAppearance = Appearance41
        UltraGridColumn69.Header.Caption = "Lotes"
        UltraGridColumn69.Header.VisiblePosition = 18
        UltraGridColumn69.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn69.Width = 29
        UltraGridColumn70.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance42.TextHAlignAsString = "Center"
        UltraGridColumn70.CellAppearance = Appearance42
        Appearance43.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance43.BackColor2 = System.Drawing.Color.LightGray
        Appearance43.BorderColor3DBase = System.Drawing.Color.Silver
        UltraGridColumn70.CellButtonAppearance = Appearance43
        UltraGridColumn70.Header.Caption = "Invoc"
        UltraGridColumn70.Header.VisiblePosition = 17
        UltraGridColumn70.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn70.Width = 40
        Appearance44.TextHAlignAsString = "Left"
        UltraGridColumn71.CellAppearance = Appearance44
        UltraGridColumn71.Header.Caption = "Caja"
        UltraGridColumn71.Header.VisiblePosition = 62
        UltraGridColumn71.Width = 90
        Appearance45.TextHAlignAsString = "Right"
        UltraGridColumn72.CellAppearance = Appearance45
        UltraGridColumn72.Header.Caption = "Planilla"
        UltraGridColumn72.Header.VisiblePosition = 63
        UltraGridColumn72.Width = 50
        Appearance46.TextHAlignAsString = "Right"
        UltraGridColumn73.CellAppearance = Appearance46
        UltraGridColumn73.Header.Caption = "Movim."
        UltraGridColumn73.Header.VisiblePosition = 65
        UltraGridColumn73.Width = 60
        UltraGridColumn74.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        Appearance47.TextHAlignAsString = "Center"
        UltraGridColumn74.CellAppearance = Appearance47
        Appearance48.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance48.BackColor2 = System.Drawing.Color.LightGray
        Appearance48.BorderColor3DBase = System.Drawing.Color.Silver
        UltraGridColumn74.CellButtonAppearance = Appearance48
        UltraGridColumn74.Header.Caption = "Con."
        UltraGridColumn74.Header.VisiblePosition = 19
        UltraGridColumn74.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn74.Width = 29
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn1, UltraGridColumn2, UltraGridColumn3, UltraGridColumn4, UltraGridColumn5, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25, UltraGridColumn26, UltraGridColumn78, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn37, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn43, UltraGridColumn44, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn48, UltraGridColumn49, UltraGridColumn50, UltraGridColumn51, UltraGridColumn52, UltraGridColumn53, UltraGridColumn54, UltraGridColumn55, UltraGridColumn56, UltraGridColumn57, UltraGridColumn58, UltraGridColumn59, UltraGridColumn60, UltraGridColumn61, UltraGridColumn62, UltraGridColumn63, UltraGridColumn64, UltraGridColumn65, UltraGridColumn75, UltraGridColumn76, UltraGridColumn77, UltraGridColumn66, UltraGridColumn67, UltraGridColumn68, UltraGridColumn69, UltraGridColumn70, UltraGridColumn71, UltraGridColumn72, UltraGridColumn73, UltraGridColumn74})
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance49.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance49
        Appearance50.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance50
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance51.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance51.BackColor2 = System.Drawing.SystemColors.Control
        Appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance51.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance51
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance52.BackColor = System.Drawing.SystemColors.Window
        Appearance52.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance52
        Appearance53.BackColor = System.Drawing.SystemColors.Highlight
        Appearance53.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance53
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance54.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance54
        Appearance55.BorderColor = System.Drawing.Color.Silver
        Appearance55.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance55
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance56.BackColor = System.Drawing.SystemColors.Control
        Appearance56.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance56.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance56.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance56
        Appearance57.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance57
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance58.BackColor = System.Drawing.SystemColors.Window
        Appearance58.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance58
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed
        Appearance59.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance59
        Me.ugDetalle.DisplayLayout.Override.WrapHeaderText = Infragistics.Win.DefaultableBoolean.[True]
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(0, 245)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1058, 295)
        Me.ugDetalle.TabIndex = 3
        Me.ugDetalle.ToolStripLabelRegistros = Me.tssRegistros
        Me.ugDetalle.ToolStripMenuExpandir = Nothing
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbImprimirPrediseñado, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator4, Me.tsbImprimirFicha, Me.tsbImpFichaCliente, Me.tssFichas, Me.tsddExportar, Me.ToolStripSeparator5, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1058, 29)
        Me.tstBarra.TabIndex = 5
        Me.tstBarra.Text = "toolStrip1"
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = CType(resources.GetObject("tsbRefrescar.Image"), System.Drawing.Image)
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimirPrediseñado
        '
        Me.tsbImprimirPrediseñado.Image = CType(resources.GetObject("tsbImprimirPrediseñado.Image"), System.Drawing.Image)
        Me.tsbImprimirPrediseñado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirPrediseñado.Name = "tsbImprimirPrediseñado"
        Me.tsbImprimirPrediseñado.Size = New System.Drawing.Size(147, 26)
        Me.tsbImprimirPrediseñado.Text = "&Imprimir Prediseñado"
        Me.tsbImprimirPrediseñado.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = CType(resources.GetObject("tsbImprimir.Image"), System.Drawing.Image)
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimirFicha
        '
        Me.tsbImprimirFicha.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimirFicha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimirFicha.Name = "tsbImprimirFicha"
        Me.tsbImprimirFicha.Size = New System.Drawing.Size(110, 26)
        Me.tsbImprimirFicha.Text = "&Imprimir Ficha"
        Me.tsbImprimirFicha.Visible = False
        '
        'tsbImpFichaCliente
        '
        Me.tsbImpFichaCliente.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImpFichaCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImpFichaCliente.Name = "tsbImpFichaCliente"
        Me.tsbImpFichaCliente.Size = New System.Drawing.Size(150, 26)
        Me.tsbImpFichaCliente.Text = "Imprimir Fic&ha Cliente"
        Me.tsbImpFichaCliente.Visible = False
        '
        'tssFichas
        '
        Me.tssFichas.Name = "tssFichas"
        Me.tssFichas.Size = New System.Drawing.Size(6, 29)
        Me.tssFichas.Visible = False
        '
        'tsddExportar
        '
        Me.tsddExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsddExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiAExcel, Me.tsmiAPDF})
        Me.tsddExportar.Image = CType(resources.GetObject("tsddExportar.Image"), System.Drawing.Image)
        Me.tsddExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsddExportar.Name = "tsddExportar"
        Me.tsddExportar.Size = New System.Drawing.Size(64, 26)
        Me.tsddExportar.Text = "Exportar"
        '
        'tsmiAExcel
        '
        Me.tsmiAExcel.Image = CType(resources.GetObject("tsmiAExcel.Image"), System.Drawing.Image)
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = CType(resources.GetObject("tsmiAPDF.Image"), System.Drawing.Image)
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 29)
        '
        'tsbPreferencias
        '
        Me.tsbPreferencias.Image = CType(resources.GetObject("tsbPreferencias.Image"), System.Drawing.Image)
        Me.tsbPreferencias.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPreferencias.Name = "tsbPreferencias"
        Me.tsbPreferencias.Size = New System.Drawing.Size(97, 26)
        Me.tsbPreferencias.Text = "&Preferencias"
        Me.tsbPreferencias.ToolTipText = "Selector de Columnas"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 29)
        '
        'tsbSalir
        '
        Me.tsbSalir.Image = CType(resources.GetObject("tsbSalir.Image"), System.Drawing.Image)
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 540)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1058, 22)
        Me.stsStado.TabIndex = 4
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(979, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'chbTransportista
        '
        Me.chbTransportista.AutoSize = True
        Me.chbTransportista.BindearPropiedadControl = Nothing
        Me.chbTransportista.BindearPropiedadEntidad = Nothing
        Me.chbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.chbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbTransportista.IsPK = False
        Me.chbTransportista.IsRequired = False
        Me.chbTransportista.Key = Nothing
        Me.chbTransportista.LabelAsoc = Nothing
        Me.chbTransportista.Location = New System.Drawing.Point(375, 137)
        Me.chbTransportista.Name = "chbTransportista"
        Me.chbTransportista.Size = New System.Drawing.Size(87, 17)
        Me.chbTransportista.TabIndex = 51
        Me.chbTransportista.Text = "Transportista"
        Me.chbTransportista.UseVisualStyleBackColor = True
        '
        'cmbTransportista
        '
        Me.cmbTransportista.BindearPropiedadControl = "SelectedValue"
        Me.cmbTransportista.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbTransportista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTransportista.Enabled = False
        Me.cmbTransportista.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTransportista.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTransportista.FormattingEnabled = True
        Me.cmbTransportista.IsPK = False
        Me.cmbTransportista.IsRequired = True
        Me.cmbTransportista.Key = Nothing
        Me.cmbTransportista.LabelAsoc = Me.chbTransportista
        Me.cmbTransportista.Location = New System.Drawing.Point(468, 135)
        Me.cmbTransportista.Name = "cmbTransportista"
        Me.cmbTransportista.Size = New System.Drawing.Size(130, 21)
        Me.cmbTransportista.TabIndex = 52
        '
        'cmbOrigenCategoria
        '
        Me.cmbOrigenCategoria.BindearPropiedadControl = Nothing
        Me.cmbOrigenCategoria.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenCategoria.FormattingEnabled = True
        Me.cmbOrigenCategoria.IsPK = False
        Me.cmbOrigenCategoria.IsRequired = False
        Me.cmbOrigenCategoria.Key = Nothing
        Me.cmbOrigenCategoria.LabelAsoc = Nothing
        Me.cmbOrigenCategoria.Location = New System.Drawing.Point(614, 110)
        Me.cmbOrigenCategoria.Name = "cmbOrigenCategoria"
        Me.cmbOrigenCategoria.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenCategoria.TabIndex = 46
        '
        'cmbOrigenVendedor
        '
        Me.cmbOrigenVendedor.BindearPropiedadControl = Nothing
        Me.cmbOrigenVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbOrigenVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOrigenVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrigenVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbOrigenVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbOrigenVendedor.FormattingEnabled = True
        Me.cmbOrigenVendedor.IsPK = False
        Me.cmbOrigenVendedor.IsRequired = False
        Me.cmbOrigenVendedor.Key = Nothing
        Me.cmbOrigenVendedor.LabelAsoc = Nothing
        Me.cmbOrigenVendedor.Location = New System.Drawing.Point(672, 35)
        Me.cmbOrigenVendedor.Name = "cmbOrigenVendedor"
        Me.cmbOrigenVendedor.Size = New System.Drawing.Size(83, 21)
        Me.cmbOrigenVendedor.TabIndex = 19
        '
        'cmbCorreoEnviado
        '
        Me.cmbCorreoEnviado.BindearPropiedadControl = ""
        Me.cmbCorreoEnviado.BindearPropiedadEntidad = ""
        Me.cmbCorreoEnviado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCorreoEnviado.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCorreoEnviado.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCorreoEnviado.FormattingEnabled = True
        Me.cmbCorreoEnviado.IsPK = False
        Me.cmbCorreoEnviado.IsRequired = True
        Me.cmbCorreoEnviado.Key = Nothing
        Me.cmbCorreoEnviado.LabelAsoc = Me.lblCorreoEnviado
        Me.cmbCorreoEnviado.Location = New System.Drawing.Point(669, 135)
        Me.cmbCorreoEnviado.Name = "cmbCorreoEnviado"
        Me.cmbCorreoEnviado.Size = New System.Drawing.Size(73, 21)
        Me.cmbCorreoEnviado.TabIndex = 54
        '
        'lblCorreoEnviado
        '
        Me.lblCorreoEnviado.AutoSize = True
        Me.lblCorreoEnviado.LabelAsoc = Nothing
        Me.lblCorreoEnviado.Location = New System.Drawing.Point(617, 139)
        Me.lblCorreoEnviado.Name = "lblCorreoEnviado"
        Me.lblCorreoEnviado.Size = New System.Drawing.Size(46, 13)
        Me.lblCorreoEnviado.TabIndex = 53
        Me.lblCorreoEnviado.Text = "Enviado"
        '
        'chbCentroCosto
        '
        Me.chbCentroCosto.AutoSize = True
        Me.chbCentroCosto.BindearPropiedadControl = Nothing
        Me.chbCentroCosto.BindearPropiedadEntidad = Nothing
        Me.chbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCentroCosto.IsPK = False
        Me.chbCentroCosto.IsRequired = False
        Me.chbCentroCosto.Key = Nothing
        Me.chbCentroCosto.LabelAsoc = Nothing
        Me.chbCentroCosto.Location = New System.Drawing.Point(13, 137)
        Me.chbCentroCosto.Name = "chbCentroCosto"
        Me.chbCentroCosto.Size = New System.Drawing.Size(107, 17)
        Me.chbCentroCosto.TabIndex = 49
        Me.chbCentroCosto.Text = "Centro de Costos"
        Me.chbCentroCosto.UseVisualStyleBackColor = True
        '
        'cmbCentroCosto
        '
        Me.cmbCentroCosto.BindearPropiedadControl = "SelectedValue"
        Me.cmbCentroCosto.BindearPropiedadEntidad = "IdPlanCuenta"
        Me.cmbCentroCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCentroCosto.Enabled = False
        Me.cmbCentroCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCentroCosto.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCentroCosto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCentroCosto.FormattingEnabled = True
        Me.cmbCentroCosto.IsPK = False
        Me.cmbCentroCosto.IsRequired = True
        Me.cmbCentroCosto.Key = Nothing
        Me.cmbCentroCosto.LabelAsoc = Nothing
        Me.cmbCentroCosto.Location = New System.Drawing.Point(129, 135)
        Me.cmbCentroCosto.Name = "cmbCentroCosto"
        Me.cmbCentroCosto.Size = New System.Drawing.Size(180, 21)
        Me.cmbCentroCosto.TabIndex = 50
        '
        'cmbEmisor
        '
        Me.cmbEmisor.BindearPropiedadControl = Nothing
        Me.cmbEmisor.BindearPropiedadEntidad = Nothing
        Me.cmbEmisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmisor.Enabled = False
        Me.cmbEmisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEmisor.FormattingEnabled = True
        Me.cmbEmisor.IsPK = False
        Me.cmbEmisor.IsRequired = False
        Me.cmbEmisor.Key = Nothing
        Me.cmbEmisor.LabelAsoc = Me.chbEmisor
        Me.cmbEmisor.Location = New System.Drawing.Point(816, 10)
        Me.cmbEmisor.Name = "cmbEmisor"
        Me.cmbEmisor.Size = New System.Drawing.Size(40, 21)
        Me.cmbEmisor.TabIndex = 7
        '
        'chbEmisor
        '
        Me.chbEmisor.AutoSize = True
        Me.chbEmisor.BindearPropiedadControl = Nothing
        Me.chbEmisor.BindearPropiedadEntidad = Nothing
        Me.chbEmisor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbEmisor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbEmisor.IsPK = False
        Me.chbEmisor.IsRequired = False
        Me.chbEmisor.Key = Nothing
        Me.chbEmisor.LabelAsoc = Nothing
        Me.chbEmisor.Location = New System.Drawing.Point(760, 12)
        Me.chbEmisor.Name = "chbEmisor"
        Me.chbEmisor.Size = New System.Drawing.Size(57, 17)
        Me.chbEmisor.TabIndex = 6
        Me.chbEmisor.Text = "Emisor"
        Me.chbEmisor.UseVisualStyleBackColor = True
        '
        'cboLetra
        '
        Me.cboLetra.BindearPropiedadControl = Nothing
        Me.cboLetra.BindearPropiedadEntidad = Nothing
        Me.cboLetra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLetra.Enabled = False
        Me.cboLetra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.cboLetra.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cboLetra.FormattingEnabled = True
        Me.cboLetra.IsPK = False
        Me.cboLetra.IsRequired = False
        Me.cboLetra.Key = Nothing
        Me.cboLetra.LabelAsoc = Me.chbLetra
        Me.cboLetra.Location = New System.Drawing.Point(717, 10)
        Me.cboLetra.Name = "cboLetra"
        Me.cboLetra.Size = New System.Drawing.Size(38, 21)
        Me.cboLetra.TabIndex = 5
        '
        'chbLetra
        '
        Me.chbLetra.AutoSize = True
        Me.chbLetra.BindearPropiedadControl = Nothing
        Me.chbLetra.BindearPropiedadEntidad = Nothing
        Me.chbLetra.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLetra.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLetra.IsPK = False
        Me.chbLetra.IsRequired = False
        Me.chbLetra.Key = Nothing
        Me.chbLetra.LabelAsoc = Nothing
        Me.chbLetra.Location = New System.Drawing.Point(669, 12)
        Me.chbLetra.Name = "chbLetra"
        Me.chbLetra.Size = New System.Drawing.Size(50, 17)
        Me.chbLetra.TabIndex = 4
        Me.chbLetra.Text = "Letra"
        Me.chbLetra.UseVisualStyleBackColor = True
        '
        'txtNumeroCompDesde
        '
        Me.txtNumeroCompDesde.BindearPropiedadControl = Nothing
        Me.txtNumeroCompDesde.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCompDesde.Enabled = False
        Me.txtNumeroCompDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCompDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCompDesde.Formato = "##0"
        Me.txtNumeroCompDesde.IsDecimal = False
        Me.txtNumeroCompDesde.IsNumber = True
        Me.txtNumeroCompDesde.IsPK = False
        Me.txtNumeroCompDesde.IsRequired = False
        Me.txtNumeroCompDesde.Key = ""
        Me.txtNumeroCompDesde.LabelAsoc = Me.chbNumero
        Me.txtNumeroCompDesde.Location = New System.Drawing.Point(922, 10)
        Me.txtNumeroCompDesde.MaxLength = 8
        Me.txtNumeroCompDesde.Name = "txtNumeroCompDesde"
        Me.txtNumeroCompDesde.Size = New System.Drawing.Size(55, 20)
        Me.txtNumeroCompDesde.TabIndex = 9
        Me.txtNumeroCompDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNumero
        '
        Me.chbNumero.AutoSize = True
        Me.chbNumero.BindearPropiedadControl = Nothing
        Me.chbNumero.BindearPropiedadEntidad = Nothing
        Me.chbNumero.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNumero.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNumero.IsPK = False
        Me.chbNumero.IsRequired = False
        Me.chbNumero.Key = Nothing
        Me.chbNumero.LabelAsoc = Nothing
        Me.chbNumero.Location = New System.Drawing.Point(858, 12)
        Me.chbNumero.Name = "chbNumero"
        Me.chbNumero.Size = New System.Drawing.Size(63, 17)
        Me.chbNumero.TabIndex = 8
        Me.chbNumero.Text = "Numero"
        Me.chbNumero.UseVisualStyleBackColor = True
        '
        'chbCliente
        '
        Me.chbCliente.AutoSize = True
        Me.chbCliente.BindearPropiedadControl = Nothing
        Me.chbCliente.BindearPropiedadEntidad = Nothing
        Me.chbCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCliente.IsPK = False
        Me.chbCliente.IsRequired = False
        Me.chbCliente.Key = Nothing
        Me.chbCliente.LabelAsoc = Nothing
        Me.chbCliente.Location = New System.Drawing.Point(13, 62)
        Me.chbCliente.Name = "chbCliente"
        Me.chbCliente.Size = New System.Drawing.Size(58, 17)
        Me.chbCliente.TabIndex = 24
        Me.chbCliente.Text = "Cliente"
        Me.chbCliente.UseVisualStyleBackColor = True
        '
        'txtNumeroCompHasta
        '
        Me.txtNumeroCompHasta.BindearPropiedadControl = Nothing
        Me.txtNumeroCompHasta.BindearPropiedadEntidad = Nothing
        Me.txtNumeroCompHasta.Enabled = False
        Me.txtNumeroCompHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNumeroCompHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNumeroCompHasta.Formato = "##0"
        Me.txtNumeroCompHasta.IsDecimal = False
        Me.txtNumeroCompHasta.IsNumber = True
        Me.txtNumeroCompHasta.IsPK = False
        Me.txtNumeroCompHasta.IsRequired = False
        Me.txtNumeroCompHasta.Key = ""
        Me.txtNumeroCompHasta.LabelAsoc = Nothing
        Me.txtNumeroCompHasta.Location = New System.Drawing.Point(997, 10)
        Me.txtNumeroCompHasta.MaxLength = 8
        Me.txtNumeroCompHasta.Name = "txtNumeroCompHasta"
        Me.txtNumeroCompHasta.Size = New System.Drawing.Size(55, 20)
        Me.txtNumeroCompHasta.TabIndex = 11
        Me.txtNumeroCompHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNroRepartoHasta
        '
        Me.txtNroRepartoHasta.BindearPropiedadControl = Nothing
        Me.txtNroRepartoHasta.BindearPropiedadEntidad = Nothing
        Me.txtNroRepartoHasta.Enabled = False
        Me.txtNroRepartoHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRepartoHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRepartoHasta.Formato = "##0"
        Me.txtNroRepartoHasta.IsDecimal = False
        Me.txtNroRepartoHasta.IsNumber = True
        Me.txtNroRepartoHasta.IsPK = False
        Me.txtNroRepartoHasta.IsRequired = False
        Me.txtNroRepartoHasta.Key = ""
        Me.txtNroRepartoHasta.LabelAsoc = Me.lblNroRepartoHasta
        Me.txtNroRepartoHasta.Location = New System.Drawing.Point(997, 35)
        Me.txtNroRepartoHasta.MaxLength = 8
        Me.txtNroRepartoHasta.Name = "txtNroRepartoHasta"
        Me.txtNroRepartoHasta.Size = New System.Drawing.Size(55, 20)
        Me.txtNroRepartoHasta.TabIndex = 23
        Me.txtNroRepartoHasta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNroRepartoHasta
        '
        Me.lblNroRepartoHasta.AutoSize = True
        Me.lblNroRepartoHasta.LabelAsoc = Nothing
        Me.lblNroRepartoHasta.Location = New System.Drawing.Point(980, 39)
        Me.lblNroRepartoHasta.Name = "lblNroRepartoHasta"
        Me.lblNroRepartoHasta.Size = New System.Drawing.Size(13, 13)
        Me.lblNroRepartoHasta.TabIndex = 22
        Me.lblNroRepartoHasta.Text = "a"
        '
        'txtNroRepartoDesde
        '
        Me.txtNroRepartoDesde.BindearPropiedadControl = Nothing
        Me.txtNroRepartoDesde.BindearPropiedadEntidad = Nothing
        Me.txtNroRepartoDesde.Enabled = False
        Me.txtNroRepartoDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.txtNroRepartoDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.txtNroRepartoDesde.Formato = "##0"
        Me.txtNroRepartoDesde.IsDecimal = False
        Me.txtNroRepartoDesde.IsNumber = True
        Me.txtNroRepartoDesde.IsPK = False
        Me.txtNroRepartoDesde.IsRequired = False
        Me.txtNroRepartoDesde.Key = ""
        Me.txtNroRepartoDesde.LabelAsoc = Me.chbNroReparto
        Me.txtNroRepartoDesde.Location = New System.Drawing.Point(922, 35)
        Me.txtNroRepartoDesde.MaxLength = 8
        Me.txtNroRepartoDesde.Name = "txtNroRepartoDesde"
        Me.txtNroRepartoDesde.Size = New System.Drawing.Size(55, 20)
        Me.txtNroRepartoDesde.TabIndex = 21
        Me.txtNroRepartoDesde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chbNroReparto
        '
        Me.chbNroReparto.AutoSize = True
        Me.chbNroReparto.BindearPropiedadControl = Nothing
        Me.chbNroReparto.BindearPropiedadEntidad = Nothing
        Me.chbNroReparto.ForeColorFocus = System.Drawing.Color.Red
        Me.chbNroReparto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbNroReparto.IsPK = False
        Me.chbNroReparto.IsRequired = False
        Me.chbNroReparto.Key = Nothing
        Me.chbNroReparto.LabelAsoc = Nothing
        Me.chbNroReparto.Location = New System.Drawing.Point(832, 37)
        Me.chbNroReparto.Name = "chbNroReparto"
        Me.chbNroReparto.Size = New System.Drawing.Size(84, 17)
        Me.chbNroReparto.TabIndex = 20
        Me.chbNroReparto.Text = "Nro Reparto"
        Me.chbNroReparto.UseVisualStyleBackColor = True
        '
        'chbProvincia
        '
        Me.chbProvincia.AutoSize = True
        Me.chbProvincia.BindearPropiedadControl = Nothing
        Me.chbProvincia.BindearPropiedadEntidad = Nothing
        Me.chbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbProvincia.IsPK = False
        Me.chbProvincia.IsRequired = False
        Me.chbProvincia.Key = Nothing
        Me.chbProvincia.LabelAsoc = Nothing
        Me.chbProvincia.Location = New System.Drawing.Point(705, 87)
        Me.chbProvincia.Name = "chbProvincia"
        Me.chbProvincia.Size = New System.Drawing.Size(70, 17)
        Me.chbProvincia.TabIndex = 38
        Me.chbProvincia.Text = "Provincia"
        Me.chbProvincia.UseVisualStyleBackColor = True
        '
        'chbLocalidad
        '
        Me.chbLocalidad.AutoSize = True
        Me.chbLocalidad.BindearPropiedadControl = Nothing
        Me.chbLocalidad.BindearPropiedadEntidad = Nothing
        Me.chbLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.chbLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbLocalidad.IsPK = False
        Me.chbLocalidad.IsRequired = False
        Me.chbLocalidad.Key = Nothing
        Me.chbLocalidad.LabelAsoc = Nothing
        Me.chbLocalidad.Location = New System.Drawing.Point(375, 87)
        Me.chbLocalidad.Name = "chbLocalidad"
        Me.chbLocalidad.Size = New System.Drawing.Size(72, 17)
        Me.chbLocalidad.TabIndex = 35
        Me.chbLocalidad.Text = "Localidad"
        Me.chbLocalidad.UseVisualStyleBackColor = True
        '
        'cmbProvincia
        '
        Me.cmbProvincia.BindearPropiedadControl = "SelectedValue"
        Me.cmbProvincia.BindearPropiedadEntidad = "IdProvincia"
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Enabled = False
        Me.cmbProvincia.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbProvincia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.IsPK = False
        Me.cmbProvincia.IsRequired = True
        Me.cmbProvincia.Key = Nothing
        Me.cmbProvincia.LabelAsoc = Me.chbProvincia
        Me.cmbProvincia.Location = New System.Drawing.Point(809, 85)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(119, 21)
        Me.cmbProvincia.TabIndex = 39
        '
        'bscCodigoLocalidad
        '
        Me.bscCodigoLocalidad.AyudaAncho = 608
        Me.bscCodigoLocalidad.BindearPropiedadControl = "Text"
        Me.bscCodigoLocalidad.BindearPropiedadEntidad = "IdLocalidad"
        Me.bscCodigoLocalidad.ColumnasAlineacion = Nothing
        Me.bscCodigoLocalidad.ColumnasAncho = Nothing
        Me.bscCodigoLocalidad.ColumnasFormato = Nothing
        Me.bscCodigoLocalidad.ColumnasOcultas = Nothing
        Me.bscCodigoLocalidad.ColumnasTitulos = Nothing
        Me.bscCodigoLocalidad.Datos = Nothing
        Me.bscCodigoLocalidad.FilaDevuelta = Nothing
        Me.bscCodigoLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoLocalidad.IsDecimal = False
        Me.bscCodigoLocalidad.IsNumber = False
        Me.bscCodigoLocalidad.IsPK = False
        Me.bscCodigoLocalidad.IsRequired = False
        Me.bscCodigoLocalidad.Key = ""
        Me.bscCodigoLocalidad.LabelAsoc = Me.chbLocalidad
        Me.bscCodigoLocalidad.Location = New System.Drawing.Point(468, 85)
        Me.bscCodigoLocalidad.MaxLengh = "32767"
        Me.bscCodigoLocalidad.Name = "bscCodigoLocalidad"
        Me.bscCodigoLocalidad.Permitido = False
        Me.bscCodigoLocalidad.Selecciono = False
        Me.bscCodigoLocalidad.Size = New System.Drawing.Size(85, 20)
        Me.bscCodigoLocalidad.TabIndex = 36
        Me.bscCodigoLocalidad.Titulo = Nothing
        '
        'bscNombreLocalidad
        '
        Me.bscNombreLocalidad.AyudaAncho = 608
        Me.bscNombreLocalidad.BindearPropiedadControl = Nothing
        Me.bscNombreLocalidad.BindearPropiedadEntidad = Nothing
        Me.bscNombreLocalidad.ColumnasAlineacion = Nothing
        Me.bscNombreLocalidad.ColumnasAncho = Nothing
        Me.bscNombreLocalidad.ColumnasFormato = Nothing
        Me.bscNombreLocalidad.ColumnasOcultas = Nothing
        Me.bscNombreLocalidad.ColumnasTitulos = Nothing
        Me.bscNombreLocalidad.Datos = Nothing
        Me.bscNombreLocalidad.FilaDevuelta = Nothing
        Me.bscNombreLocalidad.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreLocalidad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreLocalidad.IsDecimal = False
        Me.bscNombreLocalidad.IsNumber = False
        Me.bscNombreLocalidad.IsPK = False
        Me.bscNombreLocalidad.IsRequired = False
        Me.bscNombreLocalidad.Key = ""
        Me.bscNombreLocalidad.LabelAsoc = Me.chbLocalidad
        Me.bscNombreLocalidad.Location = New System.Drawing.Point(555, 85)
        Me.bscNombreLocalidad.MaxLengh = "32767"
        Me.bscNombreLocalidad.Name = "bscNombreLocalidad"
        Me.bscNombreLocalidad.Permitido = False
        Me.bscNombreLocalidad.Selecciono = False
        Me.bscNombreLocalidad.Size = New System.Drawing.Size(142, 20)
        Me.bscNombreLocalidad.TabIndex = 37
        Me.bscNombreLocalidad.Titulo = Nothing
        '
        'cmbZonaGeografica
        '
        Me.cmbZonaGeografica.BindearPropiedadControl = Nothing
        Me.cmbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.cmbZonaGeografica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaGeografica.Enabled = False
        Me.cmbZonaGeografica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbZonaGeografica.FormattingEnabled = True
        Me.cmbZonaGeografica.IsPK = False
        Me.cmbZonaGeografica.IsRequired = False
        Me.cmbZonaGeografica.Key = Nothing
        Me.cmbZonaGeografica.LabelAsoc = Me.chbZonaGeografica
        Me.cmbZonaGeografica.Location = New System.Drawing.Point(536, 60)
        Me.cmbZonaGeografica.Name = "cmbZonaGeografica"
        Me.cmbZonaGeografica.Size = New System.Drawing.Size(130, 21)
        Me.cmbZonaGeografica.TabIndex = 28
        '
        'chbZonaGeografica
        '
        Me.chbZonaGeografica.AutoSize = True
        Me.chbZonaGeografica.BindearPropiedadControl = Nothing
        Me.chbZonaGeografica.BindearPropiedadEntidad = Nothing
        Me.chbZonaGeografica.ForeColorFocus = System.Drawing.Color.Red
        Me.chbZonaGeografica.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbZonaGeografica.IsPK = False
        Me.chbZonaGeografica.IsRequired = False
        Me.chbZonaGeografica.Key = Nothing
        Me.chbZonaGeografica.LabelAsoc = Nothing
        Me.chbZonaGeografica.Location = New System.Drawing.Point(429, 62)
        Me.chbZonaGeografica.Name = "chbZonaGeografica"
        Me.chbZonaGeografica.Size = New System.Drawing.Size(106, 17)
        Me.chbZonaGeografica.TabIndex = 27
        Me.chbZonaGeografica.Text = "Zona Geográfica"
        Me.chbZonaGeografica.UseVisualStyleBackColor = True
        '
        'chbCategoria
        '
        Me.chbCategoria.AutoSize = True
        Me.chbCategoria.BindearPropiedadControl = Nothing
        Me.chbCategoria.BindearPropiedadEntidad = Nothing
        Me.chbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCategoria.IsPK = False
        Me.chbCategoria.IsRequired = False
        Me.chbCategoria.Key = Nothing
        Me.chbCategoria.LabelAsoc = Nothing
        Me.chbCategoria.Location = New System.Drawing.Point(375, 112)
        Me.chbCategoria.Name = "chbCategoria"
        Me.chbCategoria.Size = New System.Drawing.Size(71, 17)
        Me.chbCategoria.TabIndex = 44
        Me.chbCategoria.Text = "Categoria"
        Me.chbCategoria.UseVisualStyleBackColor = True
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BindearPropiedadControl = "SelectedValue"
        Me.cmbCategoria.BindearPropiedadEntidad = "Categoria.IdCategoria"
        Me.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoria.Enabled = False
        Me.cmbCategoria.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCategoria.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.IsPK = False
        Me.cmbCategoria.IsRequired = True
        Me.cmbCategoria.Key = Nothing
        Me.cmbCategoria.LabelAsoc = Me.chbCategoria
        Me.cmbCategoria.Location = New System.Drawing.Point(468, 110)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(130, 21)
        Me.cmbCategoria.TabIndex = 45
        '
        'cmbEsComercial
        '
        Me.cmbEsComercial.BindearPropiedadControl = Nothing
        Me.cmbEsComercial.BindearPropiedadEntidad = Nothing
        Me.cmbEsComercial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsComercial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsComercial.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsComercial.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsComercial.FormattingEnabled = True
        Me.cmbEsComercial.IsPK = False
        Me.cmbEsComercial.IsRequired = False
        Me.cmbEsComercial.Key = Nothing
        Me.cmbEsComercial.LabelAsoc = Me.lblEsComercial
        Me.cmbEsComercial.Location = New System.Drawing.Point(92, 110)
        Me.cmbEsComercial.Name = "cmbEsComercial"
        Me.cmbEsComercial.Size = New System.Drawing.Size(83, 21)
        Me.cmbEsComercial.TabIndex = 41
        '
        'lblEsComercial
        '
        Me.lblEsComercial.AutoSize = True
        Me.lblEsComercial.LabelAsoc = Nothing
        Me.lblEsComercial.Location = New System.Drawing.Point(19, 114)
        Me.lblEsComercial.Name = "lblEsComercial"
        Me.lblEsComercial.Size = New System.Drawing.Size(53, 13)
        Me.lblEsComercial.TabIndex = 40
        Me.lblEsComercial.Text = "Comercial"
        '
        'cmbMercDespachada
        '
        Me.cmbMercDespachada.BindearPropiedadControl = Nothing
        Me.cmbMercDespachada.BindearPropiedadEntidad = Nothing
        Me.cmbMercDespachada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMercDespachada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMercDespachada.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbMercDespachada.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbMercDespachada.FormattingEnabled = True
        Me.cmbMercDespachada.IsPK = False
        Me.cmbMercDespachada.IsRequired = False
        Me.cmbMercDespachada.Key = Nothing
        Me.cmbMercDespachada.LabelAsoc = Me.lblMercDespachada
        Me.cmbMercDespachada.Location = New System.Drawing.Point(284, 110)
        Me.cmbMercDespachada.Name = "cmbMercDespachada"
        Me.cmbMercDespachada.Size = New System.Drawing.Size(83, 21)
        Me.cmbMercDespachada.TabIndex = 43
        '
        'lblMercDespachada
        '
        Me.lblMercDespachada.AutoSize = True
        Me.lblMercDespachada.LabelAsoc = Nothing
        Me.lblMercDespachada.Location = New System.Drawing.Point(183, 114)
        Me.lblMercDespachada.Name = "lblMercDespachada"
        Me.lblMercDespachada.Size = New System.Drawing.Size(98, 13)
        Me.lblMercDespachada.TabIndex = 42
        Me.lblMercDespachada.Text = "Merc. Despachada"
        '
        'chbUsuario
        '
        Me.chbUsuario.AutoSize = True
        Me.chbUsuario.BindearPropiedadControl = Nothing
        Me.chbUsuario.BindearPropiedadEntidad = Nothing
        Me.chbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.chbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbUsuario.IsPK = False
        Me.chbUsuario.IsRequired = False
        Me.chbUsuario.Key = Nothing
        Me.chbUsuario.LabelAsoc = Nothing
        Me.chbUsuario.Location = New System.Drawing.Point(706, 112)
        Me.chbUsuario.Name = "chbUsuario"
        Me.chbUsuario.Size = New System.Drawing.Size(62, 17)
        Me.chbUsuario.TabIndex = 47
        Me.chbUsuario.Text = "Usuario"
        Me.chbUsuario.UseVisualStyleBackColor = True
        '
        'cmbUsuario
        '
        Me.cmbUsuario.BindearPropiedadControl = Nothing
        Me.cmbUsuario.BindearPropiedadEntidad = Nothing
        Me.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsuario.Enabled = False
        Me.cmbUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUsuario.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbUsuario.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbUsuario.FormattingEnabled = True
        Me.cmbUsuario.IsPK = False
        Me.cmbUsuario.IsRequired = False
        Me.cmbUsuario.Key = Nothing
        Me.cmbUsuario.LabelAsoc = Me.chbUsuario
        Me.cmbUsuario.Location = New System.Drawing.Point(809, 110)
        Me.cmbUsuario.Name = "cmbUsuario"
        Me.cmbUsuario.Size = New System.Drawing.Size(119, 21)
        Me.cmbUsuario.TabIndex = 48
        '
        'chbFormaPago
        '
        Me.chbFormaPago.AutoSize = True
        Me.chbFormaPago.BindearPropiedadControl = Nothing
        Me.chbFormaPago.BindearPropiedadEntidad = Nothing
        Me.chbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFormaPago.IsPK = False
        Me.chbFormaPago.IsRequired = False
        Me.chbFormaPago.Key = Nothing
        Me.chbFormaPago.LabelAsoc = Nothing
        Me.chbFormaPago.Location = New System.Drawing.Point(705, 62)
        Me.chbFormaPago.Name = "chbFormaPago"
        Me.chbFormaPago.Size = New System.Drawing.Size(98, 17)
        Me.chbFormaPago.TabIndex = 29
        Me.chbFormaPago.Text = "Forma de Pago"
        Me.chbFormaPago.UseVisualStyleBackColor = True
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.BindearPropiedadControl = Nothing
        Me.cmbFormaPago.BindearPropiedadEntidad = Nothing
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Enabled = False
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbFormaPago.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.IsPK = False
        Me.cmbFormaPago.IsRequired = False
        Me.cmbFormaPago.Key = Nothing
        Me.cmbFormaPago.LabelAsoc = Me.chbFormaPago
        Me.cmbFormaPago.Location = New System.Drawing.Point(809, 60)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(119, 21)
        Me.cmbFormaPago.TabIndex = 30
        '
        'chbVendedor
        '
        Me.chbVendedor.AutoSize = True
        Me.chbVendedor.BindearPropiedadControl = Nothing
        Me.chbVendedor.BindearPropiedadEntidad = Nothing
        Me.chbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbVendedor.IsPK = False
        Me.chbVendedor.IsRequired = False
        Me.chbVendedor.Key = Nothing
        Me.chbVendedor.LabelAsoc = Nothing
        Me.chbVendedor.Location = New System.Drawing.Point(429, 37)
        Me.chbVendedor.Name = "chbVendedor"
        Me.chbVendedor.Size = New System.Drawing.Size(72, 17)
        Me.chbVendedor.TabIndex = 17
        Me.chbVendedor.Text = "Vendedor"
        Me.chbVendedor.UseVisualStyleBackColor = True
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BindearPropiedadControl = Nothing
        Me.cmbVendedor.BindearPropiedadEntidad = Nothing
        Me.cmbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedor.Enabled = False
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbVendedor.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.IsPK = False
        Me.cmbVendedor.IsRequired = False
        Me.cmbVendedor.Key = Nothing
        Me.cmbVendedor.LabelAsoc = Me.chbVendedor
        Me.cmbVendedor.Location = New System.Drawing.Point(536, 35)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(130, 21)
        Me.cmbVendedor.TabIndex = 18
        '
        'cmbAfectaCaja
        '
        Me.cmbAfectaCaja.BindearPropiedadControl = Nothing
        Me.cmbAfectaCaja.BindearPropiedadEntidad = Nothing
        Me.cmbAfectaCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbAfectaCaja.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbAfectaCaja.FormattingEnabled = True
        Me.cmbAfectaCaja.IsPK = False
        Me.cmbAfectaCaja.IsRequired = False
        Me.cmbAfectaCaja.Key = Nothing
        Me.cmbAfectaCaja.LabelAsoc = Me.lblAfectaCaja
        Me.cmbAfectaCaja.Location = New System.Drawing.Point(284, 85)
        Me.cmbAfectaCaja.Name = "cmbAfectaCaja"
        Me.cmbAfectaCaja.Size = New System.Drawing.Size(83, 21)
        Me.cmbAfectaCaja.TabIndex = 34
        '
        'lblAfectaCaja
        '
        Me.lblAfectaCaja.AutoSize = True
        Me.lblAfectaCaja.LabelAsoc = Nothing
        Me.lblAfectaCaja.Location = New System.Drawing.Point(219, 89)
        Me.lblAfectaCaja.Name = "lblAfectaCaja"
        Me.lblAfectaCaja.Size = New System.Drawing.Size(62, 13)
        Me.lblAfectaCaja.TabIndex = 33
        Me.lblAfectaCaja.Text = "Afecta Caja"
        '
        'cmbGrabanLibro
        '
        Me.cmbGrabanLibro.BindearPropiedadControl = Nothing
        Me.cmbGrabanLibro.BindearPropiedadEntidad = Nothing
        Me.cmbGrabanLibro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrabanLibro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrabanLibro.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrabanLibro.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrabanLibro.FormattingEnabled = True
        Me.cmbGrabanLibro.IsPK = False
        Me.cmbGrabanLibro.IsRequired = False
        Me.cmbGrabanLibro.Key = Nothing
        Me.cmbGrabanLibro.LabelAsoc = Me.lblGrabanLibro
        Me.cmbGrabanLibro.Location = New System.Drawing.Point(92, 85)
        Me.cmbGrabanLibro.Name = "cmbGrabanLibro"
        Me.cmbGrabanLibro.Size = New System.Drawing.Size(83, 21)
        Me.cmbGrabanLibro.TabIndex = 32
        '
        'lblGrabanLibro
        '
        Me.lblGrabanLibro.AutoSize = True
        Me.lblGrabanLibro.LabelAsoc = Nothing
        Me.lblGrabanLibro.Location = New System.Drawing.Point(19, 89)
        Me.lblGrabanLibro.Name = "lblGrabanLibro"
        Me.lblGrabanLibro.Size = New System.Drawing.Size(68, 13)
        Me.lblGrabanLibro.TabIndex = 31
        Me.lblGrabanLibro.Text = "Graban Libro"
        '
        'bscCodigoCliente
        '
        Me.bscCodigoCliente.ActivarFiltroEnGrilla = True
        Me.bscCodigoCliente.BindearPropiedadControl = Nothing
        Me.bscCodigoCliente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoCliente.ConfigBuscador = Nothing
        Me.bscCodigoCliente.Datos = Nothing
        Me.bscCodigoCliente.FilaDevuelta = Nothing
        Me.bscCodigoCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoCliente.IsDecimal = False
        Me.bscCodigoCliente.IsNumber = False
        Me.bscCodigoCliente.IsPK = False
        Me.bscCodigoCliente.IsRequired = False
        Me.bscCodigoCliente.Key = ""
        Me.bscCodigoCliente.LabelAsoc = Nothing
        Me.bscCodigoCliente.Location = New System.Drawing.Point(71, 59)
        Me.bscCodigoCliente.MaxLengh = "32767"
        Me.bscCodigoCliente.Name = "bscCodigoCliente"
        Me.bscCodigoCliente.Permitido = False
        Me.bscCodigoCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoCliente.Selecciono = False
        Me.bscCodigoCliente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoCliente.TabIndex = 25
        '
        'bscCliente
        '
        Me.bscCliente.ActivarFiltroEnGrilla = True
        Me.bscCliente.AutoSize = True
        Me.bscCliente.BindearPropiedadControl = Nothing
        Me.bscCliente.BindearPropiedadEntidad = Nothing
        Me.bscCliente.ConfigBuscador = Nothing
        Me.bscCliente.Datos = Nothing
        Me.bscCliente.FilaDevuelta = Nothing
        Me.bscCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscCliente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCliente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCliente.IsDecimal = False
        Me.bscCliente.IsNumber = False
        Me.bscCliente.IsPK = False
        Me.bscCliente.IsRequired = False
        Me.bscCliente.Key = ""
        Me.bscCliente.LabelAsoc = Nothing
        Me.bscCliente.Location = New System.Drawing.Point(165, 59)
        Me.bscCliente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscCliente.MaxLengh = "32767"
        Me.bscCliente.Name = "bscCliente"
        Me.bscCliente.Permitido = False
        Me.bscCliente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCliente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCliente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCliente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCliente.Selecciono = False
        Me.bscCliente.Size = New System.Drawing.Size(259, 23)
        Me.bscCliente.TabIndex = 26
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BindearPropiedadControl = Nothing
        Me.cmbSucursal.BindearPropiedadEntidad = Nothing
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbSucursal.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbSucursal.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.IsPK = False
        Me.cmbSucursal.IsRequired = False
        Me.cmbSucursal.ItemHeight = 13
        Me.cmbSucursal.Key = Nothing
        Me.cmbSucursal.LabelAsoc = Me.lblSucursal
        Me.cmbSucursal.Location = New System.Drawing.Point(137, 10)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 1
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(83, 14)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 0
        Me.lblSucursal.Text = "Sucursal"
        '
        'cmbTiposComprobantes
        '
        Me.cmbTiposComprobantes.BindearPropiedadControl = Nothing
        Me.cmbTiposComprobantes.BindearPropiedadEntidad = Nothing
        Me.cmbTiposComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTiposComprobantes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cmbTiposComprobantes.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbTiposComprobantes.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbTiposComprobantes.FormattingEnabled = True
        Me.cmbTiposComprobantes.IsPK = False
        Me.cmbTiposComprobantes.IsRequired = False
        Me.cmbTiposComprobantes.ItemHeight = 13
        Me.cmbTiposComprobantes.Key = Nothing
        Me.cmbTiposComprobantes.LabelAsoc = Me.chbTipoComprobante
        Me.cmbTiposComprobantes.Location = New System.Drawing.Point(536, 10)
        Me.cmbTiposComprobantes.Name = "cmbTiposComprobantes"
        Me.cmbTiposComprobantes.Size = New System.Drawing.Size(130, 21)
        Me.cmbTiposComprobantes.TabIndex = 3
        '
        'chbTipoComprobante
        '
        Me.chbTipoComprobante.AutoSize = True
        Me.chbTipoComprobante.LabelAsoc = Nothing
        Me.chbTipoComprobante.Location = New System.Drawing.Point(445, 14)
        Me.chbTipoComprobante.Name = "chbTipoComprobante"
        Me.chbTipoComprobante.Size = New System.Drawing.Size(76, 13)
        Me.chbTipoComprobante.TabIndex = 2
        Me.chbTipoComprobante.Text = "Tipo Comprob."
        '
        'btnConsultar
        '
        Me.btnConsultar.AnchoredControl = Me.ugDetalle
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view_24
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.Location = New System.Drawing.Point(942, 248)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(110, 30)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "&Consultar (F3)"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'chkMesCompleto
        '
        Me.chkMesCompleto.AutoSize = True
        Me.chkMesCompleto.BindearPropiedadControl = Nothing
        Me.chkMesCompleto.BindearPropiedadEntidad = Nothing
        Me.chkMesCompleto.ForeColorFocus = System.Drawing.Color.Red
        Me.chkMesCompleto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chkMesCompleto.IsPK = False
        Me.chkMesCompleto.IsRequired = False
        Me.chkMesCompleto.Key = Nothing
        Me.chkMesCompleto.LabelAsoc = Nothing
        Me.chkMesCompleto.Location = New System.Drawing.Point(13, 37)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 12
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(300, 35)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(125, 20)
        Me.dtpHasta.TabIndex = 16
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Me.chkMesCompleto
        Me.lblHasta.Location = New System.Drawing.Point(261, 39)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 15
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy HH:mm"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(137, 35)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(125, 20)
        Me.dtpDesde.TabIndex = 14
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Me.chkMesCompleto
        Me.lblDesde.Location = New System.Drawing.Point(102, 39)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 13
        Me.lblDesde.Text = "Desde"
        '
        'FiltersManager1
        '
        Me.FiltersManager1.BotonRefrescar = Me.tsbRefrescar
        Me.FiltersManager1.PanelFiltro = Me.grpFiltros
        '
        'grpFiltros
        '
        Me.grpFiltros.Controls.Add(Me.Label2)
        Me.grpFiltros.Controls.Add(Me.chbTransportista)
        Me.grpFiltros.Controls.Add(Me.pnlHistoriaClinica)
        Me.grpFiltros.Controls.Add(Me.txtNroRepartoHasta)
        Me.grpFiltros.Controls.Add(Me.txtNumeroCompDesde)
        Me.grpFiltros.Controls.Add(Me.chbCategoria)
        Me.grpFiltros.Controls.Add(Me.bscCodigoCliente)
        Me.grpFiltros.Controls.Add(Me.cmbEsComercial)
        Me.grpFiltros.Controls.Add(Me.lblCorreoEnviado)
        Me.grpFiltros.Controls.Add(Me.cmbOrigenVendedor)
        Me.grpFiltros.Controls.Add(Me.cmbVendedor)
        Me.grpFiltros.Controls.Add(Me.cmbCentroCosto)
        Me.grpFiltros.Controls.Add(Me.lblSucursal)
        Me.grpFiltros.Controls.Add(Me.cmbFormaPago)
        Me.grpFiltros.Controls.Add(Me.chbProvincia)
        Me.grpFiltros.Controls.Add(Me.lblAfectaCaja)
        Me.grpFiltros.Controls.Add(Me.dtpDesde)
        Me.grpFiltros.Controls.Add(Me.chbEmisor)
        Me.grpFiltros.Controls.Add(Me.lblNroRepartoHasta)
        Me.grpFiltros.Controls.Add(Me.cmbProvincia)
        Me.grpFiltros.Controls.Add(Me.cmbMercDespachada)
        Me.grpFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grpFiltros.Controls.Add(Me.cmbTiposComprobantes)
        Me.grpFiltros.Controls.Add(Me.lblDesde)
        Me.grpFiltros.Controls.Add(Me.chbNroReparto)
        Me.grpFiltros.Controls.Add(Me.cmbSucursal)
        Me.grpFiltros.Controls.Add(Me.chbUsuario)
        Me.grpFiltros.Controls.Add(Me.lblMercDespachada)
        Me.grpFiltros.Controls.Add(Me.chbCliente)
        Me.grpFiltros.Controls.Add(Me.cmbTransportista)
        Me.grpFiltros.Controls.Add(Me.lblHasta)
        Me.grpFiltros.Controls.Add(Me.chbZonaGeografica)
        Me.grpFiltros.Controls.Add(Me.chbTipoComprobante)
        Me.grpFiltros.Controls.Add(Me.chbLocalidad)
        Me.grpFiltros.Controls.Add(Me.cmbUsuario)
        Me.grpFiltros.Controls.Add(Me.lblGrabanLibro)
        Me.grpFiltros.Controls.Add(Me.lblEsComercial)
        Me.grpFiltros.Controls.Add(Me.cmbAfectaCaja)
        Me.grpFiltros.Controls.Add(Me.cmbGrabanLibro)
        Me.grpFiltros.Controls.Add(Me.chbFormaPago)
        Me.grpFiltros.Controls.Add(Me.dtpHasta)
        Me.grpFiltros.Controls.Add(Me.chbCentroCosto)
        Me.grpFiltros.Controls.Add(Me.bscCodigoLocalidad)
        Me.grpFiltros.Controls.Add(Me.bscCliente)
        Me.grpFiltros.Controls.Add(Me.chbNumero)
        Me.grpFiltros.Controls.Add(Me.cmbCategoria)
        Me.grpFiltros.Controls.Add(Me.txtNroRepartoDesde)
        Me.grpFiltros.Controls.Add(Me.bscNombreLocalidad)
        Me.grpFiltros.Controls.Add(Me.chbVendedor)
        Me.grpFiltros.Controls.Add(Me.cmbEmisor)
        Me.grpFiltros.Controls.Add(Me.chbLetra)
        Me.grpFiltros.Controls.Add(Me.cmbCorreoEnviado)
        Me.grpFiltros.Controls.Add(Me.txtNumeroCompHasta)
        Me.grpFiltros.Controls.Add(Me.cmbOrigenCategoria)
        Me.grpFiltros.Controls.Add(Me.cboLetra)
        Me.grpFiltros.Controls.Add(Me.cmbZonaGeografica)
        Me.grpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpFiltros.Location = New System.Drawing.Point(0, 29)
        Me.grpFiltros.Name = "grpFiltros"
        Me.grpFiltros.Size = New System.Drawing.Size(1058, 183)
        Me.grpFiltros.TabIndex = 0
        Me.grpFiltros.TabStop = False
        Me.grpFiltros.Text = "Filtros"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.LabelAsoc = Nothing
        Me.Label2.Location = New System.Drawing.Point(980, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "a"
        '
        'pnlHistoriaClinica
        '
        Me.pnlHistoriaClinica.Controls.Add(Me.chbFechaCirugia)
        Me.pnlHistoriaClinica.Controls.Add(Me.bscCodigoPaciente)
        Me.pnlHistoriaClinica.Controls.Add(Me.dtpFechaCirugia)
        Me.pnlHistoriaClinica.Controls.Add(Me.chbPaciente)
        Me.pnlHistoriaClinica.Controls.Add(Me.bscCodigoDoctor)
        Me.pnlHistoriaClinica.Controls.Add(Me.bscPaciente)
        Me.pnlHistoriaClinica.Controls.Add(Me.bscDoctor)
        Me.pnlHistoriaClinica.Controls.Add(Me.chbDoctor)
        Me.pnlHistoriaClinica.Location = New System.Drawing.Point(10, 159)
        Me.pnlHistoriaClinica.Name = "pnlHistoriaClinica"
        Me.pnlHistoriaClinica.Size = New System.Drawing.Size(1034, 22)
        Me.pnlHistoriaClinica.TabIndex = 55
        Me.pnlHistoriaClinica.Visible = False
        '
        'chbFechaCirugia
        '
        Me.chbFechaCirugia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chbFechaCirugia.AutoSize = True
        Me.chbFechaCirugia.BindearPropiedadControl = Nothing
        Me.chbFechaCirugia.BindearPropiedadEntidad = Nothing
        Me.chbFechaCirugia.ForeColorFocus = System.Drawing.Color.Red
        Me.chbFechaCirugia.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbFechaCirugia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.chbFechaCirugia.IsPK = False
        Me.chbFechaCirugia.IsRequired = False
        Me.chbFechaCirugia.Key = Nothing
        Me.chbFechaCirugia.LabelAsoc = Nothing
        Me.chbFechaCirugia.Location = New System.Drawing.Point(780, 4)
        Me.chbFechaCirugia.Name = "chbFechaCirugia"
        Me.chbFechaCirugia.Size = New System.Drawing.Size(108, 17)
        Me.chbFechaCirugia.TabIndex = 6
        Me.chbFechaCirugia.Text = "Fecha de Cirugía"
        Me.chbFechaCirugia.UseVisualStyleBackColor = True
        '
        'bscCodigoPaciente
        '
        Me.bscCodigoPaciente.ActivarFiltroEnGrilla = True
        Me.bscCodigoPaciente.BindearPropiedadControl = Nothing
        Me.bscCodigoPaciente.BindearPropiedadEntidad = Nothing
        Me.bscCodigoPaciente.ConfigBuscador = Nothing
        Me.bscCodigoPaciente.Datos = Nothing
        Me.bscCodigoPaciente.FilaDevuelta = Nothing
        Me.bscCodigoPaciente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoPaciente.IsDecimal = False
        Me.bscCodigoPaciente.IsNumber = False
        Me.bscCodigoPaciente.IsPK = False
        Me.bscCodigoPaciente.IsRequired = False
        Me.bscCodigoPaciente.Key = ""
        Me.bscCodigoPaciente.LabelAsoc = Nothing
        Me.bscCodigoPaciente.Location = New System.Drawing.Point(75, 1)
        Me.bscCodigoPaciente.MaxLengh = "32767"
        Me.bscCodigoPaciente.Name = "bscCodigoPaciente"
        Me.bscCodigoPaciente.Permitido = False
        Me.bscCodigoPaciente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoPaciente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoPaciente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoPaciente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoPaciente.Selecciono = False
        Me.bscCodigoPaciente.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoPaciente.TabIndex = 1
        '
        'dtpFechaCirugia
        '
        Me.dtpFechaCirugia.BindearPropiedadControl = Nothing
        Me.dtpFechaCirugia.BindearPropiedadEntidad = Nothing
        Me.dtpFechaCirugia.CustomFormat = "dd/MM/yyyy"
        Me.dtpFechaCirugia.Enabled = False
        Me.dtpFechaCirugia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFechaCirugia.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpFechaCirugia.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpFechaCirugia.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFechaCirugia.IsPK = False
        Me.dtpFechaCirugia.IsRequired = False
        Me.dtpFechaCirugia.Key = ""
        Me.dtpFechaCirugia.LabelAsoc = Nothing
        Me.dtpFechaCirugia.Location = New System.Drawing.Point(894, 2)
        Me.dtpFechaCirugia.Name = "dtpFechaCirugia"
        Me.dtpFechaCirugia.Size = New System.Drawing.Size(97, 20)
        Me.dtpFechaCirugia.TabIndex = 7
        '
        'chbPaciente
        '
        Me.chbPaciente.AutoSize = True
        Me.chbPaciente.BindearPropiedadControl = Nothing
        Me.chbPaciente.BindearPropiedadEntidad = Nothing
        Me.chbPaciente.ForeColorFocus = System.Drawing.Color.Red
        Me.chbPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbPaciente.IsPK = False
        Me.chbPaciente.IsRequired = False
        Me.chbPaciente.Key = Nothing
        Me.chbPaciente.LabelAsoc = Nothing
        Me.chbPaciente.Location = New System.Drawing.Point(3, 4)
        Me.chbPaciente.Name = "chbPaciente"
        Me.chbPaciente.Size = New System.Drawing.Size(68, 17)
        Me.chbPaciente.TabIndex = 0
        Me.chbPaciente.Text = "Paciente"
        Me.chbPaciente.UseVisualStyleBackColor = True
        '
        'bscCodigoDoctor
        '
        Me.bscCodigoDoctor.ActivarFiltroEnGrilla = True
        Me.bscCodigoDoctor.BindearPropiedadControl = Nothing
        Me.bscCodigoDoctor.BindearPropiedadEntidad = Nothing
        Me.bscCodigoDoctor.ConfigBuscador = Nothing
        Me.bscCodigoDoctor.Datos = Nothing
        Me.bscCodigoDoctor.FilaDevuelta = Nothing
        Me.bscCodigoDoctor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCodigoDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCodigoDoctor.IsDecimal = False
        Me.bscCodigoDoctor.IsNumber = False
        Me.bscCodigoDoctor.IsPK = False
        Me.bscCodigoDoctor.IsRequired = False
        Me.bscCodigoDoctor.Key = ""
        Me.bscCodigoDoctor.LabelAsoc = Nothing
        Me.bscCodigoDoctor.Location = New System.Drawing.Point(465, 1)
        Me.bscCodigoDoctor.MaxLengh = "32767"
        Me.bscCodigoDoctor.Name = "bscCodigoDoctor"
        Me.bscCodigoDoctor.Permitido = False
        Me.bscCodigoDoctor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscCodigoDoctor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscCodigoDoctor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscCodigoDoctor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscCodigoDoctor.Selecciono = False
        Me.bscCodigoDoctor.Size = New System.Drawing.Size(90, 23)
        Me.bscCodigoDoctor.TabIndex = 4
        '
        'bscPaciente
        '
        Me.bscPaciente.ActivarFiltroEnGrilla = True
        Me.bscPaciente.AutoSize = True
        Me.bscPaciente.BindearPropiedadControl = Nothing
        Me.bscPaciente.BindearPropiedadEntidad = Nothing
        Me.bscPaciente.ConfigBuscador = Nothing
        Me.bscPaciente.Datos = Nothing
        Me.bscPaciente.FilaDevuelta = Nothing
        Me.bscPaciente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscPaciente.ForeColorFocus = System.Drawing.Color.Red
        Me.bscPaciente.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscPaciente.IsDecimal = False
        Me.bscPaciente.IsNumber = False
        Me.bscPaciente.IsPK = False
        Me.bscPaciente.IsRequired = False
        Me.bscPaciente.Key = ""
        Me.bscPaciente.LabelAsoc = Nothing
        Me.bscPaciente.Location = New System.Drawing.Point(172, 1)
        Me.bscPaciente.Margin = New System.Windows.Forms.Padding(4)
        Me.bscPaciente.MaxLengh = "32767"
        Me.bscPaciente.Name = "bscPaciente"
        Me.bscPaciente.Permitido = False
        Me.bscPaciente.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscPaciente.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscPaciente.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscPaciente.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscPaciente.Selecciono = False
        Me.bscPaciente.Size = New System.Drawing.Size(211, 23)
        Me.bscPaciente.TabIndex = 2
        '
        'bscDoctor
        '
        Me.bscDoctor.ActivarFiltroEnGrilla = True
        Me.bscDoctor.AutoSize = True
        Me.bscDoctor.BindearPropiedadControl = Nothing
        Me.bscDoctor.BindearPropiedadEntidad = Nothing
        Me.bscDoctor.ConfigBuscador = Nothing
        Me.bscDoctor.Datos = Nothing
        Me.bscDoctor.FilaDevuelta = Nothing
        Me.bscDoctor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscDoctor.ForeColorFocus = System.Drawing.Color.Red
        Me.bscDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscDoctor.IsDecimal = False
        Me.bscDoctor.IsNumber = False
        Me.bscDoctor.IsPK = False
        Me.bscDoctor.IsRequired = False
        Me.bscDoctor.Key = ""
        Me.bscDoctor.LabelAsoc = Nothing
        Me.bscDoctor.Location = New System.Drawing.Point(562, 1)
        Me.bscDoctor.Margin = New System.Windows.Forms.Padding(4)
        Me.bscDoctor.MaxLengh = "32767"
        Me.bscDoctor.Name = "bscDoctor"
        Me.bscDoctor.Permitido = False
        Me.bscDoctor.PermitidoNoBackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.bscDoctor.PermitidoNoForeColor = System.Drawing.Color.Black
        Me.bscDoctor.PermitidoSiBackColor = System.Drawing.Color.White
        Me.bscDoctor.PermitidoSiForeColor = System.Drawing.Color.Black
        Me.bscDoctor.Selecciono = False
        Me.bscDoctor.Size = New System.Drawing.Size(211, 23)
        Me.bscDoctor.TabIndex = 5
        '
        'chbDoctor
        '
        Me.chbDoctor.AutoSize = True
        Me.chbDoctor.BindearPropiedadControl = Nothing
        Me.chbDoctor.BindearPropiedadEntidad = Nothing
        Me.chbDoctor.ForeColorFocus = System.Drawing.Color.Red
        Me.chbDoctor.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbDoctor.IsPK = False
        Me.chbDoctor.IsRequired = False
        Me.chbDoctor.Key = Nothing
        Me.chbDoctor.LabelAsoc = Nothing
        Me.chbDoctor.Location = New System.Drawing.Point(401, 4)
        Me.chbDoctor.Name = "chbDoctor"
        Me.chbDoctor.Size = New System.Drawing.Size(58, 17)
        Me.chbDoctor.TabIndex = 3
        Me.chbDoctor.Text = "Doctor"
        Me.chbDoctor.UseVisualStyleBackColor = True
        '
        'pnlAcciones
        '
        Me.pnlAcciones.AutoSize = True
        Me.pnlAcciones.Controls.Add(Me.chkExpandAll)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAcciones.Location = New System.Drawing.Point(0, 227)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(1058, 18)
        Me.pnlAcciones.TabIndex = 1
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(951, 0)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(104, 15)
        Me.chkExpandAll.TabIndex = 0
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'UltraSplitter1
        '
        Me.UltraSplitter1.BackColor = System.Drawing.SystemColors.Control
        Me.UltraSplitter1.ButtonExtent = 350
        Me.UltraSplitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.UltraSplitter1.Location = New System.Drawing.Point(0, 212)
        Me.UltraSplitter1.MinSize = 80
        Me.UltraSplitter1.Name = "UltraSplitter1"
        Me.UltraSplitter1.RestoreExtent = 223
        Me.UltraSplitter1.Size = New System.Drawing.Size(1058, 15)
        Me.UltraSplitter1.TabIndex = 6
        '
        'InformeDeVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1058, 562)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.ugDetalle)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.UltraSplitter1)
        Me.Controls.Add(Me.grpFiltros)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.stsStado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InformeDeVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Ventas"
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        Me.grpFiltros.ResumeLayout(False)
        Me.grpFiltros.PerformLayout()
        Me.pnlHistoriaClinica.ResumeLayout(False)
        Me.pnlHistoriaClinica.PerformLayout()
        Me.pnlAcciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chbTipoComprobante As Eniac.Controles.Label
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
    Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
    Friend WithEvents lblHasta As Eniac.Controles.Label
    Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
    Friend WithEvents lblDesde As Eniac.Controles.Label
    Friend WithEvents chbCliente As Eniac.Controles.CheckBox
   Friend WithEvents btnConsultar As ButtonConsultar
   Friend WithEvents cmbTiposComprobantes As ComboBoxTiposComprobantes
    Friend WithEvents bscCodigoCliente As Eniac.Controles.Buscador2
   Friend WithEvents bscCliente As Eniac.Controles.Buscador2
   Friend WithEvents cmbGrabanLibro As Eniac.Controles.ComboBox
   Friend WithEvents lblGrabanLibro As Eniac.Controles.Label
   Friend WithEvents cmbAfectaCaja As Eniac.Controles.ComboBox
   Friend WithEvents lblAfectaCaja As Eniac.Controles.Label
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents chbVendedor As Eniac.Controles.CheckBox
   Friend WithEvents cmbVendedor As Eniac.Controles.ComboBox
   Friend WithEvents chbFormaPago As Eniac.Controles.CheckBox
   Friend WithEvents cmbFormaPago As Eniac.Controles.ComboBox
   Friend WithEvents chbUsuario As Eniac.Controles.CheckBox
   Friend WithEvents cmbUsuario As Eniac.Controles.ComboBox
   Friend WithEvents cmbMercDespachada As Eniac.Controles.ComboBox
   Friend WithEvents lblMercDespachada As Eniac.Controles.Label
   Friend WithEvents cmbEsComercial As Eniac.Controles.ComboBox
   Friend WithEvents lblEsComercial As Eniac.Controles.Label
   Friend WithEvents chbCategoria As Eniac.Controles.CheckBox
   Friend WithEvents cmbCategoria As Eniac.Controles.ComboBox
   Friend WithEvents ugDetalle As UltraGridSiga
   Friend WithEvents chbZonaGeografica As Eniac.Controles.CheckBox
   Friend WithEvents cmbZonaGeografica As Eniac.Controles.ComboBox
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbProvincia As Eniac.Controles.CheckBox
   Friend WithEvents chbLocalidad As Eniac.Controles.CheckBox
   Public WithEvents cmbProvincia As Eniac.Controles.ComboBox
   Friend WithEvents bscCodigoLocalidad As Eniac.Controles.Buscador
   Friend WithEvents bscNombreLocalidad As Eniac.Controles.Buscador
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbNumero As Eniac.Controles.CheckBox
   Friend WithEvents txtNumeroCompDesde As Eniac.Controles.TextBox
   Friend WithEvents chbLetra As Eniac.Controles.CheckBox
   Friend WithEvents chbEmisor As Eniac.Controles.CheckBox
   Friend WithEvents cmbEmisor As Eniac.Controles.ComboBox
   Friend WithEvents cboLetra As Eniac.Controles.ComboBox
   Friend WithEvents tsbImprimirPrediseñado As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents txtNroRepartoHasta As Eniac.Controles.TextBox
   Friend WithEvents lblNroRepartoHasta As Eniac.Controles.Label
   Friend WithEvents txtNroRepartoDesde As Eniac.Controles.TextBox
   Friend WithEvents chbNroReparto As Eniac.Controles.CheckBox
   Friend WithEvents cmbSucursal As ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents txtNumeroCompHasta As Eniac.Controles.TextBox
   Friend WithEvents chbCentroCosto As Eniac.Controles.CheckBox
    Friend WithEvents cmbCentroCosto As Eniac.Controles.ComboBox
    Friend WithEvents cmbCorreoEnviado As Eniac.Controles.ComboBox
    Friend WithEvents lblCorreoEnviado As Eniac.Controles.Label
    Friend WithEvents cmbOrigenVendedor As Controles.ComboBox
    Friend WithEvents cmbOrigenCategoria As Controles.ComboBox
   Friend WithEvents chbTransportista As Controles.CheckBox
   Friend WithEvents cmbTransportista As Controles.ComboBox
   Friend WithEvents tsbImpFichaCliente As ToolStripButton
   Friend WithEvents tsbImprimirFicha As ToolStripButton
   Friend WithEvents tssFichas As ToolStripSeparator
   Friend WithEvents FiltersManager1 As FilterManager.FilterManager
   Friend WithEvents grpFiltros As Controles.GroupBox
   Friend WithEvents pnlAcciones As Panel
   Friend WithEvents chkExpandAll As CheckBox
   Friend WithEvents UltraSplitter1 As Misc.UltraSplitter
   Friend WithEvents Label2 As Controles.Label
   Friend WithEvents pnlHistoriaClinica As Panel
   Friend WithEvents chbFechaCirugia As Controles.CheckBox
   Friend WithEvents bscCodigoPaciente As Controles.Buscador2
   Friend WithEvents dtpFechaCirugia As Controles.DateTimePicker
   Friend WithEvents chbPaciente As Controles.CheckBox
   Friend WithEvents bscCodigoDoctor As Controles.Buscador2
   Friend WithEvents bscPaciente As Controles.Buscador2
   Friend WithEvents bscDoctor As Controles.Buscador2
   Friend WithEvents chbDoctor As Controles.CheckBox
End Class
