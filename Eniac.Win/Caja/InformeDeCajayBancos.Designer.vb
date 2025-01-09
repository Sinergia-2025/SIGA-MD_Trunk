<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InformeDeCajayBancos
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InformeDeCajayBancos))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Band 0", -1)
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdSucursal", -1, Nothing, 754469032, 0, 0)
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn2 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdCaja")
      Dim UltraGridColumn3 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCaja", -1, Nothing, 754469032, 1, 0)
      Dim UltraGridColumn6 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("FechaMovimiento")
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NumeroMovimiento", -1, Nothing, 754469032, 5, 0)
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuentaCaja", -1, Nothing, 754469032, 4, 0)
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdGrupoCuenta")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoMovimiento")
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdUsuario", -1, Nothing, 754469036, 1, 0)
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsModificable", -1, Nothing, 754469032, 7, 0)
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Observacion", -1, Nothing, 754469032, 6, 0)
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdPlanCuenta")
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdAsiento")
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn26 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TM")
      Dim UltraGridColumn27 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("I_Ef_$", -1, Nothing, 754469034, 0, 0)
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn28 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("E_Ef_$", -1, Nothing, 754469037, 0, 0)
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn29 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("I_Ch_$", -1, Nothing, 754469034, 1, 0)
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn30 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("E_Ch_$", -1, Nothing, 754469037, 1, 0)
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn31 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("I_Ba_$", -1, Nothing, 754469035, 1, 0)
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn32 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("E_Ba_$", -1, Nothing, 754469035, 2, 0)
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn33 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("I_Ta_$", -1, Nothing, 754469034, 2, 0)
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn34 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("E_Ta_$", -1, Nothing, 754469037, 2, 0)
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn35 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Efectivo$")
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn36 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Cheques3ros")
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn38 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Tarjetas")
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn39 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Dolares")
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn40 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Retenciones")
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn41 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("INGRESOS", -1, Nothing, 754469033, 0, 0)
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn42 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EGRESOS", -1, Nothing, 754469033, 1, 0)
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("BancoCC")
      Dim UltraGridColumn4 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Hora", -1, Nothing, 754469032, 3, 0)
      Dim UltraGridColumn5 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("I_Dol_u$s", -1, Nothing, 754469034, 3, 0)
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("E_Dol_u$s", -1, Nothing, 754469037, 3, 0)
      Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("I_Ret_$", -1, Nothing, 754469034, 4, 0)
      Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("E_Ret_$", -1, Nothing, 754469037, 4, 0)
      Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo_Ef_$", -1, Nothing, 754469038, 0, 0)
      Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo_Ch_$", -1, Nothing, 754469038, 1, 0)
      Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo_Ba_$", -1, Nothing, 754469035, 3, 0)
      Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo_Ta_$", -1, Nothing, 754469038, 2, 0)
      Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo_Dol_u$s", -1, Nothing, 754469038, 3, 0)
      Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn37 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Saldo_Ret_$", -1, Nothing, 754469038, 4, 0)
      Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn43 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Fec", -1, Nothing, 754469032, 2, 0)
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreCuenta", -1, Nothing, 754469035, 0, 0)
      Dim UltraGridColumn45 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoTotalCaja", -1, Nothing, 754469038, 5, 0)
      Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn46 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("SaldoGeneral", -1, Nothing, 754469036, 0, 0)
      Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridColumn47 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("GeneraContabilidad")
      Dim UltraGridColumn44 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Imp", 0)
      Dim UltraGridGroup1 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(" ", 754469032)
      Dim UltraGridGroup2 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Movimientos Generales", 754469033)
      Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup3 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Caja", 754469034)
      Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup4 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("Banco", 754469035)
      Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup5 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup(754469036)
      Dim UltraGridGroup6 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("NewGroup5", 754469037)
      Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridGroup7 As Infragistics.Win.UltraWinGrid.UltraGridGroup = New Infragistics.Win.UltraWinGrid.UltraGridGroup("NewGroup6", 754469038)
      Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
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
      Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.grbFiltros = New System.Windows.Forms.GroupBox()
      Me.chbSaldoIniciales = New Eniac.Controles.CheckBox()
      Me.lblCajas = New Eniac.Controles.Label()
      Me.cmbCajas = New Eniac.Win.ComboBoxCajas()
      Me.cmbSucursal = New Eniac.Win.ComboBoxSucursales()
      Me.lblSucursal = New Eniac.Controles.Label()
      Me.chbGrupo = New Eniac.Controles.CheckBox()
      Me.cmbGrupos = New Eniac.Controles.ComboBox()
      Me.lblEsModificable = New Eniac.Controles.Label()
      Me.cmbEsModificable = New Eniac.Controles.ComboBox()
      Me.chbCuentaDeCaja = New Eniac.Controles.CheckBox()
      Me.rdbFechaMovimiento = New Eniac.Controles.RadioButton()
      Me.rdbFechaPlanilla = New Eniac.Controles.RadioButton()
      Me.lblFechaDe = New Eniac.Controles.Label()
      Me.bscCuentaCaja = New Eniac.Controles.Buscador()
      Me.bscNombreCuentaCaja = New Eniac.Controles.Buscador()
      Me.btnConsultar = New Eniac.Controles.Button()
      Me.chkMesCompleto = New Eniac.Controles.CheckBox()
      Me.dtpHasta = New Eniac.Controles.DateTimePicker()
      Me.lblHasta = New Eniac.Controles.Label()
      Me.dtpDesde = New Eniac.Controles.DateTimePicker()
      Me.lblDesde = New Eniac.Controles.Label()
      Me.chkExpandAll = New System.Windows.Forms.CheckBox()
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbImprimir = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsddExportar = New System.Windows.Forms.ToolStripDropDownButton()
      Me.tsmiAExcel = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsmiAPDF = New System.Windows.Forms.ToolStripMenuItem()
      Me.tsbPreferencias = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.stsStado = New System.Windows.Forms.StatusStrip()
      Me.tssInfo = New System.Windows.Forms.ToolStripStatusLabel()
      Me.tspBarra = New System.Windows.Forms.ToolStripProgressBar()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.ugDetalle = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.UltraDataSource1 = New Infragistics.Win.UltraWinDataSource.UltraDataSource(Me.components)
      Me.UltraGridPrintDocument1 = New Infragistics.Win.UltraWinGrid.UltraGridPrintDocument(Me.components)
      Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter(Me.components)
      Me.UltraGridDocumentExporter1 = New Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter(Me.components)
      Me.UltraPrintPreviewDialog1 = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
      Me.sfdExportar = New System.Windows.Forms.SaveFileDialog()
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grbFiltros.SuspendLayout()
        Me.tstBarra.SuspendLayout()
        Me.stsStado.SuspendLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbFiltros
        '
        Me.grbFiltros.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbFiltros.Controls.Add(Me.chbSaldoIniciales)
        Me.grbFiltros.Controls.Add(Me.lblCajas)
        Me.grbFiltros.Controls.Add(Me.cmbCajas)
        Me.grbFiltros.Controls.Add(Me.cmbSucursal)
        Me.grbFiltros.Controls.Add(Me.lblSucursal)
        Me.grbFiltros.Controls.Add(Me.chbGrupo)
        Me.grbFiltros.Controls.Add(Me.cmbGrupos)
        Me.grbFiltros.Controls.Add(Me.lblEsModificable)
        Me.grbFiltros.Controls.Add(Me.cmbEsModificable)
        Me.grbFiltros.Controls.Add(Me.chbCuentaDeCaja)
        Me.grbFiltros.Controls.Add(Me.rdbFechaMovimiento)
        Me.grbFiltros.Controls.Add(Me.rdbFechaPlanilla)
        Me.grbFiltros.Controls.Add(Me.lblFechaDe)
        Me.grbFiltros.Controls.Add(Me.bscCuentaCaja)
        Me.grbFiltros.Controls.Add(Me.bscNombreCuentaCaja)
        Me.grbFiltros.Controls.Add(Me.btnConsultar)
        Me.grbFiltros.Controls.Add(Me.chkMesCompleto)
        Me.grbFiltros.Controls.Add(Me.dtpHasta)
        Me.grbFiltros.Controls.Add(Me.dtpDesde)
        Me.grbFiltros.Controls.Add(Me.lblHasta)
        Me.grbFiltros.Controls.Add(Me.lblDesde)
        Me.grbFiltros.Controls.Add(Me.chkExpandAll)
        Me.grbFiltros.Location = New System.Drawing.Point(12, 38)
        Me.grbFiltros.Name = "grbFiltros"
        Me.grbFiltros.Size = New System.Drawing.Size(1040, 93)
        Me.grbFiltros.TabIndex = 0
        Me.grbFiltros.TabStop = False
        Me.grbFiltros.Text = "Filtros"
        '
        'chbSaldoIniciales
        '
        Me.chbSaldoIniciales.AutoSize = True
        Me.chbSaldoIniciales.BindearPropiedadControl = Nothing
        Me.chbSaldoIniciales.BindearPropiedadEntidad = Nothing
        Me.chbSaldoIniciales.ForeColorFocus = System.Drawing.Color.Red
        Me.chbSaldoIniciales.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbSaldoIniciales.IsPK = False
        Me.chbSaldoIniciales.IsRequired = False
        Me.chbSaldoIniciales.Key = Nothing
        Me.chbSaldoIniciales.LabelAsoc = Nothing
        Me.chbSaldoIniciales.Location = New System.Drawing.Point(721, 66)
        Me.chbSaldoIniciales.Name = "chbSaldoIniciales"
        Me.chbSaldoIniciales.Size = New System.Drawing.Size(118, 17)
        Me.chbSaldoIniciales.TabIndex = 9
        Me.chbSaldoIniciales.Text = "Ver Saldos Iniciales"
        Me.chbSaldoIniciales.UseVisualStyleBackColor = True
        '
        'lblCajas
        '
        Me.lblCajas.AutoSize = True
        Me.lblCajas.LabelAsoc = Nothing
        Me.lblCajas.Location = New System.Drawing.Point(594, 39)
        Me.lblCajas.Name = "lblCajas"
        Me.lblCajas.Size = New System.Drawing.Size(28, 13)
        Me.lblCajas.TabIndex = 74
        Me.lblCajas.Text = "Caja"
        '
        'cmbCajas
        '
        Me.cmbCajas.BindearPropiedadControl = Nothing
        Me.cmbCajas.BindearPropiedadEntidad = Nothing
        Me.cmbCajas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCajas.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbCajas.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbCajas.FormattingEnabled = True
        Me.cmbCajas.IsPK = False
        Me.cmbCajas.IsRequired = False
        Me.cmbCajas.Key = Nothing
        Me.cmbCajas.LabelAsoc = Me.lblCajas
        Me.cmbCajas.Location = New System.Drawing.Point(625, 35)
        Me.cmbCajas.Name = "cmbCajas"
        Me.cmbCajas.Size = New System.Drawing.Size(121, 21)
        Me.cmbCajas.SucursalesSeleccionadas = Nothing
        Me.cmbCajas.TabIndex = 73
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
        Me.cmbSucursal.Location = New System.Drawing.Point(146, 9)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(130, 21)
        Me.cmbSucursal.TabIndex = 26
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.LabelAsoc = Nothing
        Me.lblSucursal.Location = New System.Drawing.Point(92, 12)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(48, 13)
        Me.lblSucursal.TabIndex = 25
        Me.lblSucursal.Text = "Sucursal"
        '
        'chbGrupo
        '
        Me.chbGrupo.AutoSize = True
        Me.chbGrupo.BindearPropiedadControl = Nothing
        Me.chbGrupo.BindearPropiedadEntidad = Nothing
        Me.chbGrupo.ForeColorFocus = System.Drawing.Color.Red
        Me.chbGrupo.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbGrupo.IsPK = False
        Me.chbGrupo.IsRequired = False
        Me.chbGrupo.Key = Nothing
        Me.chbGrupo.LabelAsoc = Nothing
        Me.chbGrupo.Location = New System.Drawing.Point(393, 65)
        Me.chbGrupo.Name = "chbGrupo"
        Me.chbGrupo.Size = New System.Drawing.Size(55, 17)
        Me.chbGrupo.TabIndex = 19
        Me.chbGrupo.Text = "Grupo"
        Me.chbGrupo.UseVisualStyleBackColor = True
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BindearPropiedadControl = ""
        Me.cmbGrupos.BindearPropiedadEntidad = ""
        Me.cmbGrupos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupos.Enabled = False
        Me.cmbGrupos.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbGrupos.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbGrupos.FormattingEnabled = True
        Me.cmbGrupos.IsPK = False
        Me.cmbGrupos.IsRequired = False
        Me.cmbGrupos.Key = Nothing
        Me.cmbGrupos.LabelAsoc = Nothing
        Me.cmbGrupos.Location = New System.Drawing.Point(449, 63)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(96, 21)
        Me.cmbGrupos.TabIndex = 7
        '
        'lblEsModificable
        '
        Me.lblEsModificable.AutoSize = True
        Me.lblEsModificable.LabelAsoc = Nothing
        Me.lblEsModificable.Location = New System.Drawing.Point(570, 67)
        Me.lblEsModificable.Name = "lblEsModificable"
        Me.lblEsModificable.Size = New System.Drawing.Size(51, 13)
        Me.lblEsModificable.TabIndex = 20
        Me.lblEsModificable.Text = "Es Modif."
        '
        'cmbEsModificable
        '
        Me.cmbEsModificable.BindearPropiedadControl = Nothing
        Me.cmbEsModificable.BindearPropiedadEntidad = Nothing
        Me.cmbEsModificable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEsModificable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEsModificable.ForeColorFocus = System.Drawing.Color.Red
        Me.cmbEsModificable.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.cmbEsModificable.FormattingEnabled = True
        Me.cmbEsModificable.IsPK = False
        Me.cmbEsModificable.IsRequired = False
        Me.cmbEsModificable.Key = Nothing
        Me.cmbEsModificable.LabelAsoc = Me.lblEsModificable
        Me.cmbEsModificable.Location = New System.Drawing.Point(625, 63)
        Me.cmbEsModificable.Name = "cmbEsModificable"
        Me.cmbEsModificable.Size = New System.Drawing.Size(75, 21)
        Me.cmbEsModificable.TabIndex = 8
        '
        'chbCuentaDeCaja
        '
        Me.chbCuentaDeCaja.AutoSize = True
        Me.chbCuentaDeCaja.BindearPropiedadControl = Nothing
        Me.chbCuentaDeCaja.BindearPropiedadEntidad = Nothing
        Me.chbCuentaDeCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.chbCuentaDeCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.chbCuentaDeCaja.IsPK = False
        Me.chbCuentaDeCaja.IsRequired = False
        Me.chbCuentaDeCaja.Key = Nothing
        Me.chbCuentaDeCaja.LabelAsoc = Nothing
        Me.chbCuentaDeCaja.Location = New System.Drawing.Point(5, 66)
        Me.chbCuentaDeCaja.Name = "chbCuentaDeCaja"
        Me.chbCuentaDeCaja.Size = New System.Drawing.Size(60, 17)
        Me.chbCuentaDeCaja.TabIndex = 18
        Me.chbCuentaDeCaja.Text = "Cuenta"
        Me.chbCuentaDeCaja.UseVisualStyleBackColor = True
        '
        'rdbFechaMovimiento
        '
        Me.rdbFechaMovimiento.AutoSize = True
        Me.rdbFechaMovimiento.BindearPropiedadControl = Nothing
        Me.rdbFechaMovimiento.BindearPropiedadEntidad = Nothing
        Me.rdbFechaMovimiento.Checked = True
        Me.rdbFechaMovimiento.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFechaMovimiento.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFechaMovimiento.IsPK = False
        Me.rdbFechaMovimiento.IsRequired = False
        Me.rdbFechaMovimiento.Key = Nothing
        Me.rdbFechaMovimiento.LabelAsoc = Nothing
        Me.rdbFechaMovimiento.Location = New System.Drawing.Point(449, 37)
        Me.rdbFechaMovimiento.Name = "rdbFechaMovimiento"
        Me.rdbFechaMovimiento.Size = New System.Drawing.Size(79, 17)
        Me.rdbFechaMovimiento.TabIndex = 2
        Me.rdbFechaMovimiento.TabStop = True
        Me.rdbFechaMovimiento.Text = "Movimiento"
        Me.rdbFechaMovimiento.UseVisualStyleBackColor = True
        Me.rdbFechaMovimiento.Visible = False
        '
        'rdbFechaPlanilla
        '
        Me.rdbFechaPlanilla.AutoSize = True
        Me.rdbFechaPlanilla.BindearPropiedadControl = Nothing
        Me.rdbFechaPlanilla.BindearPropiedadEntidad = Nothing
        Me.rdbFechaPlanilla.ForeColorFocus = System.Drawing.Color.Red
        Me.rdbFechaPlanilla.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.rdbFechaPlanilla.IsPK = False
        Me.rdbFechaPlanilla.IsRequired = False
        Me.rdbFechaPlanilla.Key = Nothing
        Me.rdbFechaPlanilla.LabelAsoc = Nothing
        Me.rdbFechaPlanilla.Location = New System.Drawing.Point(532, 37)
        Me.rdbFechaPlanilla.Name = "rdbFechaPlanilla"
        Me.rdbFechaPlanilla.Size = New System.Drawing.Size(58, 17)
        Me.rdbFechaPlanilla.TabIndex = 15
        Me.rdbFechaPlanilla.Text = "Planilla"
        Me.rdbFechaPlanilla.UseVisualStyleBackColor = True
        Me.rdbFechaPlanilla.Visible = False
        '
        'lblFechaDe
        '
        Me.lblFechaDe.AutoSize = True
        Me.lblFechaDe.LabelAsoc = Nothing
        Me.lblFechaDe.Location = New System.Drawing.Point(391, 39)
        Me.lblFechaDe.Name = "lblFechaDe"
        Me.lblFechaDe.Size = New System.Drawing.Size(52, 13)
        Me.lblFechaDe.TabIndex = 14
        Me.lblFechaDe.Text = "Fecha de"
        Me.lblFechaDe.Visible = False
        '
        'bscCuentaCaja
        '
        Me.bscCuentaCaja.AyudaAncho = 608
        Me.bscCuentaCaja.BindearPropiedadControl = Nothing
        Me.bscCuentaCaja.BindearPropiedadEntidad = Nothing
        Me.bscCuentaCaja.ColumnasAlineacion = Nothing
        Me.bscCuentaCaja.ColumnasAncho = Nothing
        Me.bscCuentaCaja.ColumnasFormato = Nothing
        Me.bscCuentaCaja.ColumnasOcultas = Nothing
        Me.bscCuentaCaja.ColumnasTitulos = Nothing
        Me.bscCuentaCaja.Datos = Nothing
        Me.bscCuentaCaja.Enabled = False
        Me.bscCuentaCaja.FilaDevuelta = Nothing
        Me.bscCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscCuentaCaja.IsDecimal = False
        Me.bscCuentaCaja.IsNumber = False
        Me.bscCuentaCaja.IsPK = False
        Me.bscCuentaCaja.IsRequired = False
        Me.bscCuentaCaja.Key = ""
        Me.bscCuentaCaja.LabelAsoc = Nothing
        Me.bscCuentaCaja.Location = New System.Drawing.Point(68, 63)
        Me.bscCuentaCaja.MaxLengh = "32767"
        Me.bscCuentaCaja.Name = "bscCuentaCaja"
        Me.bscCuentaCaja.Permitido = True
        Me.bscCuentaCaja.Selecciono = False
        Me.bscCuentaCaja.Size = New System.Drawing.Size(90, 23)
        Me.bscCuentaCaja.TabIndex = 5
        Me.bscCuentaCaja.Titulo = Nothing
        '
        'bscNombreCuentaCaja
        '
        Me.bscNombreCuentaCaja.AutoSize = True
        Me.bscNombreCuentaCaja.AyudaAncho = 608
        Me.bscNombreCuentaCaja.BindearPropiedadControl = Nothing
        Me.bscNombreCuentaCaja.BindearPropiedadEntidad = Nothing
        Me.bscNombreCuentaCaja.ColumnasAlineacion = Nothing
        Me.bscNombreCuentaCaja.ColumnasAncho = Nothing
        Me.bscNombreCuentaCaja.ColumnasFormato = Nothing
        Me.bscNombreCuentaCaja.ColumnasOcultas = Nothing
        Me.bscNombreCuentaCaja.ColumnasTitulos = Nothing
        Me.bscNombreCuentaCaja.Datos = Nothing
        Me.bscNombreCuentaCaja.Enabled = False
        Me.bscNombreCuentaCaja.FilaDevuelta = Nothing
        Me.bscNombreCuentaCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bscNombreCuentaCaja.ForeColorFocus = System.Drawing.Color.Red
        Me.bscNombreCuentaCaja.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
        Me.bscNombreCuentaCaja.IsDecimal = False
        Me.bscNombreCuentaCaja.IsNumber = False
        Me.bscNombreCuentaCaja.IsPK = False
        Me.bscNombreCuentaCaja.IsRequired = False
        Me.bscNombreCuentaCaja.Key = ""
        Me.bscNombreCuentaCaja.LabelAsoc = Nothing
        Me.bscNombreCuentaCaja.Location = New System.Drawing.Point(162, 63)
        Me.bscNombreCuentaCaja.Margin = New System.Windows.Forms.Padding(4)
        Me.bscNombreCuentaCaja.MaxLengh = "32767"
        Me.bscNombreCuentaCaja.Name = "bscNombreCuentaCaja"
        Me.bscNombreCuentaCaja.Permitido = True
        Me.bscNombreCuentaCaja.Selecciono = False
        Me.bscNombreCuentaCaja.Size = New System.Drawing.Size(202, 23)
        Me.bscNombreCuentaCaja.TabIndex = 6
        Me.bscNombreCuentaCaja.Titulo = Nothing
        '
        'btnConsultar
        '
        Me.btnConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsultar.Image = Global.Eniac.Win.My.Resources.Resources.view
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.btnConsultar.Location = New System.Drawing.Point(912, 19)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(100, 45)
        Me.btnConsultar.TabIndex = 10
        Me.btnConsultar.Text = "&Consultar"
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
        Me.chkMesCompleto.Location = New System.Drawing.Point(5, 37)
        Me.chkMesCompleto.Name = "chkMesCompleto"
        Me.chkMesCompleto.Size = New System.Drawing.Size(93, 17)
        Me.chkMesCompleto.TabIndex = 11
        Me.chkMesCompleto.Text = "Mes Completo"
        Me.chkMesCompleto.UseVisualStyleBackColor = True
        '
        'dtpHasta
        '
        Me.dtpHasta.BindearPropiedadControl = Nothing
        Me.dtpHasta.BindearPropiedadEntidad = Nothing
        Me.dtpHasta.CustomFormat = "dd/MM/yyyy"
        Me.dtpHasta.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpHasta.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHasta.IsPK = False
        Me.dtpHasta.IsRequired = False
        Me.dtpHasta.Key = ""
        Me.dtpHasta.LabelAsoc = Me.lblHasta
        Me.dtpHasta.Location = New System.Drawing.Point(285, 35)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(95, 20)
        Me.dtpHasta.TabIndex = 1
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.LabelAsoc = Nothing
        Me.lblHasta.Location = New System.Drawing.Point(244, 39)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(35, 13)
        Me.lblHasta.TabIndex = 13
        Me.lblHasta.Text = "Hasta"
        '
        'dtpDesde
        '
        Me.dtpDesde.BindearPropiedadControl = Nothing
        Me.dtpDesde.BindearPropiedadEntidad = Nothing
        Me.dtpDesde.CustomFormat = "dd/MM/yyyy"
        Me.dtpDesde.ForeColorFocus = System.Drawing.Color.Red
        Me.dtpDesde.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDesde.IsPK = False
        Me.dtpDesde.IsRequired = False
        Me.dtpDesde.Key = ""
        Me.dtpDesde.LabelAsoc = Me.lblDesde
        Me.dtpDesde.Location = New System.Drawing.Point(146, 35)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(95, 20)
        Me.dtpDesde.TabIndex = 0
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.LabelAsoc = Nothing
        Me.lblDesde.Location = New System.Drawing.Point(102, 39)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(38, 13)
        Me.lblDesde.TabIndex = 12
        Me.lblDesde.Text = "Desde"
        '
        'chkExpandAll
        '
        Me.chkExpandAll.Enabled = False
        Me.chkExpandAll.Location = New System.Drawing.Point(912, 66)
        Me.chkExpandAll.Name = "chkExpandAll"
        Me.chkExpandAll.Size = New System.Drawing.Size(113, 19)
        Me.chkExpandAll.TabIndex = 11
        Me.chkExpandAll.Text = "Expandir Grupos"
        '
        'tstBarra
        '
        Me.tstBarra.AllowItemReorder = True
        Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator1, Me.tsbImprimir, Me.ToolStripSeparator2, Me.tsddExportar, Me.tsbPreferencias, Me.toolStripSeparator3, Me.tsbSalir})
        Me.tstBarra.Location = New System.Drawing.Point(0, 0)
        Me.tstBarra.Name = "tstBarra"
        Me.tstBarra.Size = New System.Drawing.Size(1059, 29)
        Me.tstBarra.TabIndex = 3
        '
        'tsbRefrescar
        '
        Me.tsbRefrescar.Image = Global.Eniac.Win.My.Resources.Resources.refresh_32
        Me.tsbRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefrescar.Name = "tsbRefrescar"
        Me.tsbRefrescar.Size = New System.Drawing.Size(104, 26)
        Me.tsbRefrescar.Text = "&Refrescar (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
        '
        'tsbImprimir
        '
        Me.tsbImprimir.Image = Global.Eniac.Win.My.Resources.Resources.printer_32
        Me.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImprimir.Name = "tsbImprimir"
        Me.tsbImprimir.Size = New System.Drawing.Size(79, 26)
        Me.tsbImprimir.Text = "&Imprimir"
        Me.tsbImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 29)
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
        Me.tsmiAExcel.Image = Global.Eniac.Win.My.Resources.Resources.excel
        Me.tsmiAExcel.Name = "tsmiAExcel"
        Me.tsmiAExcel.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAExcel.Text = "a Excel"
        '
        'tsmiAPDF
        '
        Me.tsmiAPDF.Image = Global.Eniac.Win.My.Resources.Resources.Adobe_PDF_256
        Me.tsmiAPDF.Name = "tsmiAPDF"
        Me.tsmiAPDF.Size = New System.Drawing.Size(110, 22)
        Me.tsmiAPDF.Text = "a PDF"
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
        Me.tsbSalir.Image = Global.Eniac.Win.My.Resources.Resources.close_b_32
        Me.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSalir.Name = "tsbSalir"
        Me.tsbSalir.Size = New System.Drawing.Size(65, 26)
        Me.tsbSalir.Text = "&Cerrar"
        Me.tsbSalir.ToolTipText = "Cerrar el formulario"
        '
        'stsStado
        '
        Me.stsStado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssInfo, Me.tspBarra, Me.tssRegistros})
        Me.stsStado.Location = New System.Drawing.Point(0, 548)
        Me.stsStado.Name = "stsStado"
        Me.stsStado.Size = New System.Drawing.Size(1059, 22)
        Me.stsStado.TabIndex = 2
        Me.stsStado.Text = "statusStrip1"
        '
        'tssInfo
        '
        Me.tssInfo.Name = "tssInfo"
        Me.tssInfo.Size = New System.Drawing.Size(980, 17)
        Me.tssInfo.Spring = True
        '
        'tspBarra
        '
        Me.tspBarra.Name = "tspBarra"
        Me.tspBarra.Size = New System.Drawing.Size(100, 16)
        Me.tspBarra.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.tspBarra.Visible = False
        '
        'tssRegistros
        '
        Me.tssRegistros.Name = "tssRegistros"
        Me.tssRegistros.Size = New System.Drawing.Size(64, 17)
        Me.tssRegistros.Text = "0 Registros"
        '
        'ugDetalle
        '
        Appearance1.BackColor = System.Drawing.SystemColors.Window
        Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
        Me.ugDetalle.DisplayLayout.Appearance = Appearance1
        Appearance2.TextHAlignAsString = "Right"
        UltraGridColumn24.CellAppearance = Appearance2
        UltraGridColumn24.Header.Caption = "Suc."
        UltraGridColumn24.Width = 36
        UltraGridColumn2.Header.VisiblePosition = 6
        UltraGridColumn2.Hidden = True
        UltraGridColumn3.Header.Caption = "Caja"
        UltraGridColumn3.Width = 110
        Appearance3.TextHAlignAsString = "Center"
        UltraGridColumn6.CellAppearance = Appearance3
        UltraGridColumn6.Format = ""
        UltraGridColumn6.Header.Caption = "Movimiento"
        UltraGridColumn6.Header.VisiblePosition = 9
        UltraGridColumn6.Hidden = True
        UltraGridColumn6.Width = 70
        Appearance4.TextHAlignAsString = "Right"
        UltraGridColumn7.CellAppearance = Appearance4
        UltraGridColumn7.Header.Caption = "Nro. Mov."
        UltraGridColumn7.Width = 38
        UltraGridColumn8.Header.Caption = "Nombre de Cuenta"
        UltraGridColumn8.Width = 162
        UltraGridColumn9.Header.Caption = "Grupo"
        UltraGridColumn9.Header.VisiblePosition = 10
        UltraGridColumn9.Hidden = True
        UltraGridColumn9.Width = 100
        Appearance5.TextHAlignAsString = "Center"
        UltraGridColumn10.CellAppearance = Appearance5
        UltraGridColumn10.Header.Caption = "T"
        UltraGridColumn10.Header.VisiblePosition = 13
        UltraGridColumn10.Hidden = True
        UltraGridColumn10.Width = 17
        UltraGridColumn16.Header.Caption = "Usuario"
        UltraGridColumn16.Width = 75
        Appearance6.TextHAlignAsString = "Center"
        UltraGridColumn17.CellAppearance = Appearance6
        UltraGridColumn17.Header.Caption = "Mod."
        UltraGridColumn17.Width = 35
        UltraGridColumn18.Width = 262
        Appearance7.TextHAlignAsString = "Right"
        UltraGridColumn22.CellAppearance = Appearance7
        UltraGridColumn22.Header.Caption = "P."
        UltraGridColumn22.Header.VisiblePosition = 35
        UltraGridColumn22.Hidden = True
        UltraGridColumn22.Width = 25
        Appearance8.TextHAlignAsString = "Right"
        UltraGridColumn23.CellAppearance = Appearance8
        UltraGridColumn23.Header.Caption = "Asiento"
        UltraGridColumn23.Header.VisiblePosition = 40
        UltraGridColumn23.Hidden = True
        UltraGridColumn23.Width = 54
        UltraGridColumn26.Header.VisiblePosition = 18
        UltraGridColumn26.Hidden = True
        UltraGridColumn26.Width = 47
        Appearance9.TextHAlignAsString = "Right"
        UltraGridColumn27.CellAppearance = Appearance9
        UltraGridColumn27.Format = "N2"
        UltraGridColumn27.Header.Caption = "I_Efectivo_$"
        UltraGridColumn27.Width = 90
        Appearance10.TextHAlignAsString = "Right"
        UltraGridColumn28.CellAppearance = Appearance10
        UltraGridColumn28.Format = "N2"
        UltraGridColumn28.Header.Caption = "E_Efectivo_$"
        UltraGridColumn28.Width = 90
        Appearance11.TextHAlignAsString = "Right"
        UltraGridColumn29.CellAppearance = Appearance11
        UltraGridColumn29.Format = "N2"
        UltraGridColumn29.Header.Caption = "I_Cheque_$"
        UltraGridColumn29.Width = 90
        Appearance12.TextHAlignAsString = "Right"
        UltraGridColumn30.CellAppearance = Appearance12
        UltraGridColumn30.Format = "N2"
        UltraGridColumn30.Header.Caption = "E_Cheque_$"
        UltraGridColumn30.Width = 90
        Appearance13.TextHAlignAsString = "Right"
        UltraGridColumn31.CellAppearance = Appearance13
        UltraGridColumn31.Format = "N2"
        UltraGridColumn31.Header.Caption = "Banco I"
        UltraGridColumn31.Width = 90
        Appearance14.TextHAlignAsString = "Right"
        UltraGridColumn32.CellAppearance = Appearance14
        UltraGridColumn32.Format = "N2"
        UltraGridColumn32.Header.Caption = "Banco E"
        UltraGridColumn32.Width = 90
        Appearance15.TextHAlignAsString = "Right"
        UltraGridColumn33.CellAppearance = Appearance15
        UltraGridColumn33.Format = "N2"
        UltraGridColumn33.Header.Caption = "I_Tarjeta_$"
        UltraGridColumn33.Width = 90
        Appearance16.TextHAlignAsString = "Right"
        UltraGridColumn34.CellAppearance = Appearance16
        UltraGridColumn34.Format = "N2"
        UltraGridColumn34.Header.Caption = "E_Tarjeta_$"
        UltraGridColumn34.Width = 90
        Appearance17.TextHAlignAsString = "Right"
        UltraGridColumn35.CellAppearance = Appearance17
        UltraGridColumn35.Format = "N2"
        UltraGridColumn35.Header.VisiblePosition = 21
        UltraGridColumn35.Hidden = True
        Appearance18.TextHAlignAsString = "Right"
        UltraGridColumn36.CellAppearance = Appearance18
        UltraGridColumn36.Format = "N2"
        UltraGridColumn36.Header.VisiblePosition = 22
        UltraGridColumn36.Hidden = True
        Appearance19.TextHAlignAsString = "Right"
        UltraGridColumn38.CellAppearance = Appearance19
        UltraGridColumn38.Format = "N2"
        UltraGridColumn38.Header.VisiblePosition = 23
        UltraGridColumn38.Hidden = True
        Appearance20.TextHAlignAsString = "Right"
        UltraGridColumn39.CellAppearance = Appearance20
        UltraGridColumn39.Format = "N2"
        UltraGridColumn39.Header.VisiblePosition = 26
        UltraGridColumn39.Hidden = True
        Appearance21.TextHAlignAsString = "Right"
        UltraGridColumn40.CellAppearance = Appearance21
        UltraGridColumn40.Format = "N2"
        UltraGridColumn40.Header.VisiblePosition = 30
        UltraGridColumn40.Hidden = True
        Appearance22.TextHAlignAsString = "Right"
        UltraGridColumn41.CellAppearance = Appearance22
        UltraGridColumn41.Format = "N2"
        UltraGridColumn41.Header.Caption = "Ingresos"
        UltraGridColumn41.Width = 90
        Appearance23.TextHAlignAsString = "Right"
        UltraGridColumn42.CellAppearance = Appearance23
        UltraGridColumn42.Format = "N2"
        UltraGridColumn42.Header.Caption = "Egresos"
        UltraGridColumn42.Width = 90
        UltraGridColumn1.Header.VisiblePosition = 45
        UltraGridColumn1.Hidden = True
        UltraGridColumn4.Width = 47
        Appearance24.TextHAlignAsString = "Right"
        UltraGridColumn5.CellAppearance = Appearance24
        UltraGridColumn5.Format = "N2"
        UltraGridColumn5.Header.Caption = "I_Dolares_u$s"
        UltraGridColumn5.Width = 90
        Appearance25.TextHAlignAsString = "Right"
        UltraGridColumn11.CellAppearance = Appearance25
        UltraGridColumn11.Format = "N2"
        UltraGridColumn11.Header.Caption = "E_Dolares_u$s"
        UltraGridColumn11.Width = 90
        Appearance26.TextHAlignAsString = "Right"
        UltraGridColumn12.CellAppearance = Appearance26
        UltraGridColumn12.Format = "N2"
        UltraGridColumn12.Header.Caption = "I_Retenciones_$"
        UltraGridColumn12.Width = 90
        Appearance27.TextHAlignAsString = "Right"
        UltraGridColumn13.CellAppearance = Appearance27
        UltraGridColumn13.Format = "N2"
        UltraGridColumn13.Header.Caption = "E_Retenciones_$"
        UltraGridColumn13.Width = 90
        Appearance28.TextHAlignAsString = "Right"
        UltraGridColumn14.CellAppearance = Appearance28
        UltraGridColumn14.Format = "N2"
        UltraGridColumn14.Header.Caption = "Saldo_Efectivo_$"
        UltraGridColumn14.Width = 90
        Appearance29.TextHAlignAsString = "Right"
        UltraGridColumn15.CellAppearance = Appearance29
        UltraGridColumn15.Format = "N2"
        UltraGridColumn15.Header.Caption = "Saldo_Cheque_$"
        UltraGridColumn15.Width = 90
        Appearance30.TextHAlignAsString = "Right"
        UltraGridColumn20.CellAppearance = Appearance30
        UltraGridColumn20.Format = "N2"
        UltraGridColumn20.Header.Caption = "Saldo Banco"
        UltraGridColumn20.Width = 90
        Appearance31.TextHAlignAsString = "Right"
        UltraGridColumn21.CellAppearance = Appearance31
        UltraGridColumn21.Format = "N2"
        UltraGridColumn21.Header.Caption = "Saldo_Tarjeta_$"
        UltraGridColumn21.Width = 90
        Appearance32.TextHAlignAsString = "Right"
        UltraGridColumn25.CellAppearance = Appearance32
        UltraGridColumn25.Format = "N2"
        UltraGridColumn25.Header.Caption = "Saldo_Dolares_u$s"
        UltraGridColumn25.Width = 90
        Appearance33.TextHAlignAsString = "Right"
        UltraGridColumn37.CellAppearance = Appearance33
        UltraGridColumn37.Format = "N2"
        UltraGridColumn37.Header.Caption = "Saldo_Retenciones_$"
        UltraGridColumn37.Width = 90
        UltraGridColumn43.Header.Caption = "Fecha"
        UltraGridColumn43.Width = 74
        UltraGridColumn19.Header.Caption = "Cuenta Bancaria"
        UltraGridColumn19.Width = 160
        Appearance34.TextHAlignAsString = "Right"
        UltraGridColumn45.CellAppearance = Appearance34
        UltraGridColumn45.Format = "N2"
        UltraGridColumn45.Header.Caption = "Saldo Total Caja"
        UltraGridColumn45.Width = 95
        Appearance35.TextHAlignAsString = "Right"
        UltraGridColumn46.CellAppearance = Appearance35
        UltraGridColumn46.Format = "N2"
        UltraGridColumn46.Header.Caption = "Saldo General"
        UltraGridColumn46.Width = 96
        UltraGridColumn47.Header.Caption = "Genera Contabilidad"
        UltraGridColumn47.Header.VisiblePosition = 46
        UltraGridColumn44.Header.VisiblePosition = 5
        UltraGridColumn44.Hidden = True
        UltraGridColumn44.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        UltraGridColumn44.Width = 30
        UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn24, UltraGridColumn2, UltraGridColumn3, UltraGridColumn6, UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn22, UltraGridColumn23, UltraGridColumn26, UltraGridColumn27, UltraGridColumn28, UltraGridColumn29, UltraGridColumn30, UltraGridColumn31, UltraGridColumn32, UltraGridColumn33, UltraGridColumn34, UltraGridColumn35, UltraGridColumn36, UltraGridColumn38, UltraGridColumn39, UltraGridColumn40, UltraGridColumn41, UltraGridColumn42, UltraGridColumn1, UltraGridColumn4, UltraGridColumn5, UltraGridColumn11, UltraGridColumn12, UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn20, UltraGridColumn21, UltraGridColumn25, UltraGridColumn37, UltraGridColumn43, UltraGridColumn19, UltraGridColumn45, UltraGridColumn46, UltraGridColumn47, UltraGridColumn44})
        UltraGridGroup1.Key = " "
        Appearance36.TextHAlignAsString = "Center"
        UltraGridGroup2.Header.Appearance = Appearance36
        UltraGridGroup2.Key = "Movimientos Generales"
        Appearance37.TextHAlignAsString = "Center"
        UltraGridGroup3.Header.Appearance = Appearance37
        UltraGridGroup3.Header.Caption = "Caja Ingresos"
        UltraGridGroup3.Key = "Caja"
        Appearance38.TextHAlignAsString = "Center"
        UltraGridGroup4.Header.Appearance = Appearance38
        UltraGridGroup4.Header.VisiblePosition = 5
        UltraGridGroup4.Key = "Banco"
        UltraGridGroup5.Header.VisiblePosition = 6
        Appearance39.TextHAlignAsString = "Center"
        UltraGridGroup6.Header.Appearance = Appearance39
        UltraGridGroup6.Header.Caption = "Caja Egresos"
        UltraGridGroup6.Header.VisiblePosition = 3
        UltraGridGroup6.Key = "NewGroup5"
        Appearance40.TextHAlignAsString = "Center"
        UltraGridGroup7.Header.Appearance = Appearance40
        UltraGridGroup7.Header.Caption = "Caja Saldos"
        UltraGridGroup7.Header.VisiblePosition = 4
        UltraGridGroup7.Key = "NewGroup6"
        UltraGridBand1.Groups.AddRange(New Infragistics.Win.UltraWinGrid.UltraGridGroup() {UltraGridGroup1, UltraGridGroup2, UltraGridGroup3, UltraGridGroup4, UltraGridGroup5, UltraGridGroup6, UltraGridGroup7})
        Appearance41.TextHAlignAsString = "Center"
        UltraGridBand1.Header.Appearance = Appearance41
        Me.ugDetalle.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
        Me.ugDetalle.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.[False]
        Appearance42.BackColor = System.Drawing.SystemColors.ActiveBorder
        Appearance42.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance42.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
        Appearance42.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.GroupByBox.Appearance = Appearance42
        Appearance43.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance43
        Me.ugDetalle.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
        Me.ugDetalle.DisplayLayout.GroupByBox.Prompt = "Arrastre un título de columna aquí para agrupar."
        Appearance44.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance44.BackColor2 = System.Drawing.SystemColors.Control
        Appearance44.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance44.ForeColor = System.Drawing.SystemColors.GrayText
        Me.ugDetalle.DisplayLayout.GroupByBox.PromptAppearance = Appearance44
        Me.ugDetalle.DisplayLayout.MaxColScrollRegions = 1
        Me.ugDetalle.DisplayLayout.MaxRowScrollRegions = 1
        Appearance45.BackColor = System.Drawing.SystemColors.Window
        Appearance45.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ugDetalle.DisplayLayout.Override.ActiveCellAppearance = Appearance45
        Appearance46.BackColor = System.Drawing.SystemColors.Highlight
        Appearance46.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.ugDetalle.DisplayLayout.Override.ActiveRowAppearance = Appearance46
        Me.ugDetalle.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No
        Me.ugDetalle.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.[False]
        Me.ugDetalle.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
        Me.ugDetalle.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
        Appearance47.BackColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.CardAreaAppearance = Appearance47
        Appearance48.BorderColor = System.Drawing.Color.Silver
        Appearance48.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
        Me.ugDetalle.DisplayLayout.Override.CellAppearance = Appearance48
        Me.ugDetalle.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
        Me.ugDetalle.DisplayLayout.Override.CellPadding = 0
        Appearance49.BackColor = System.Drawing.SystemColors.Control
        Appearance49.BackColor2 = System.Drawing.SystemColors.ControlDark
        Appearance49.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance49.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
        Appearance49.BorderColor = System.Drawing.SystemColors.Window
        Me.ugDetalle.DisplayLayout.Override.GroupByRowAppearance = Appearance49
        Appearance50.TextHAlignAsString = "Left"
        Me.ugDetalle.DisplayLayout.Override.HeaderAppearance = Appearance50
        Me.ugDetalle.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        Me.ugDetalle.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
        Appearance51.BackColor = System.Drawing.SystemColors.Window
        Appearance51.BorderColor = System.Drawing.Color.Silver
        Me.ugDetalle.DisplayLayout.Override.RowAppearance = Appearance51
        Me.ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.None
        Me.ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
        Appearance52.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ugDetalle.DisplayLayout.Override.TemplateAddRowAppearance = Appearance52
        Me.ugDetalle.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
        Me.ugDetalle.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        Me.ugDetalle.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.ugDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ugDetalle.Location = New System.Drawing.Point(3, 3)
        Me.ugDetalle.Name = "ugDetalle"
        Me.ugDetalle.Size = New System.Drawing.Size(1034, 402)
        Me.ugDetalle.TabIndex = 1
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
        Appearance53.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Appearance53.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
        Appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump
        Me.UltraGridPrintDocument1.Header.Appearance = Appearance53
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
        'UltraPrintPreviewDialog1
        '
        Me.UltraPrintPreviewDialog1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.UltraPrintPreviewDialog1.Name = "UltraPrintPreviewDialog1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ugDetalle, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 137)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1040, 408)
        Me.TableLayoutPanel1.TabIndex = 77
        '
        'InformeDeCajayBancos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 570)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.stsStado)
        Me.Controls.Add(Me.tstBarra)
        Me.Controls.Add(Me.grbFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "InformeDeCajayBancos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informe de Caja y Bancos"
        Me.grbFiltros.ResumeLayout(False)
        Me.grbFiltros.PerformLayout()
        Me.tstBarra.ResumeLayout(False)
        Me.tstBarra.PerformLayout()
        Me.stsStado.ResumeLayout(False)
        Me.stsStado.PerformLayout()
        CType(Me.ugDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grbFiltros As System.Windows.Forms.GroupBox
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Private WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Friend WithEvents chkMesCompleto As Eniac.Controles.CheckBox
   Friend WithEvents dtpHasta As Eniac.Controles.DateTimePicker
   Friend WithEvents lblHasta As Eniac.Controles.Label
   Friend WithEvents dtpDesde As Eniac.Controles.DateTimePicker
   Friend WithEvents lblDesde As Eniac.Controles.Label
   Friend WithEvents btnConsultar As Eniac.Controles.Button
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Protected Friend WithEvents stsStado As System.Windows.Forms.StatusStrip
   Protected Friend WithEvents tssInfo As System.Windows.Forms.ToolStripStatusLabel
   Protected Friend WithEvents tspBarra As System.Windows.Forms.ToolStripProgressBar
   Protected WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents bscCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents bscNombreCuentaCaja As Eniac.Controles.Buscador
   Friend WithEvents rdbFechaMovimiento As Eniac.Controles.RadioButton
   Friend WithEvents rdbFechaPlanilla As Eniac.Controles.RadioButton
   Friend WithEvents lblFechaDe As Eniac.Controles.Label
   Friend WithEvents chbCuentaDeCaja As Eniac.Controles.CheckBox
   Friend WithEvents ugDetalle As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents UltraDataSource1 As Infragistics.Win.UltraWinDataSource.UltraDataSource
   Friend WithEvents UltraGridPrintDocument1 As Infragistics.Win.UltraWinGrid.UltraGridPrintDocument
   Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
   Friend WithEvents UltraGridDocumentExporter1 As Infragistics.Win.UltraWinGrid.DocumentExport.UltraGridDocumentExporter
   Friend WithEvents UltraPrintPreviewDialog1 As Infragistics.Win.Printing.UltraPrintPreviewDialog
   Friend WithEvents sfdExportar As System.Windows.Forms.SaveFileDialog
   Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsbImprimir As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents tsddExportar As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents tsmiAExcel As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents tsmiAPDF As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents chkExpandAll As System.Windows.Forms.CheckBox
   Friend WithEvents cmbEsModificable As Eniac.Controles.ComboBox
   Friend WithEvents lblEsModificable As Eniac.Controles.Label
   Friend WithEvents chbGrupo As Eniac.Controles.CheckBox
   Friend WithEvents cmbGrupos As Eniac.Controles.ComboBox
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents cmbSucursal As Eniac.Win.ComboBoxSucursales
   Friend WithEvents lblSucursal As Eniac.Controles.Label
   Friend WithEvents lblCajas As Eniac.Controles.Label
   Friend WithEvents cmbCajas As Eniac.Win.ComboBoxCajas
   Public WithEvents tsbPreferencias As System.Windows.Forms.ToolStripButton
   Friend WithEvents chbSaldoIniciales As Eniac.Controles.CheckBox
End Class
