<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SueldosConceptosMasivo
   Inherits BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SueldosConceptosMasivo))
      Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand1 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("Personal", -1)
      Dim UltraGridColumn7 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdLegajo")
      Dim UltraGridColumn8 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombrePersonal")
      Dim UltraGridColumn9 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("TipoDocPersonal")
      Dim UltraGridColumn10 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NroDocPersonal")
      Dim UltraGridColumn11 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Domicilio")
      Dim UltraGridColumn12 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Check", 0)
      Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim UltraGridBand2 As Infragistics.Win.UltraWinGrid.UltraGridBand = New Infragistics.Win.UltraWinGrid.UltraGridBand("ConceptosPersonal", -1)
      Dim UltraGridColumn13 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idLegajo", -1, Nothing, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, True)
      Dim UltraGridColumn14 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idConcepto")
      Dim UltraGridColumn15 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreConcepto")
      Dim UltraGridColumn16 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idTipoConcepto")
      Dim UltraGridColumn17 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoConcepto")
      Dim UltraGridColumn18 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("idQuePide")
      Dim UltraGridColumn19 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreQuePide")
      Dim UltraGridColumn20 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Valor")
      Dim UltraGridColumn21 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("Periodos")
      Dim UltraGridColumn22 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("IdTipoRecibo")
      Dim UltraGridColumn1 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsContempladoAguinaldo")
      Dim UltraGridColumn23 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("EsAguinaldo")
      Dim UltraGridColumn24 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("NombreTipoRecibo")
      Dim UltraGridColumn25 As Infragistics.Win.UltraWinGrid.UltraGridColumn = New Infragistics.Win.UltraWinGrid.UltraGridColumn("CodigoConcepto")
      Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
      Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
      Me.tstBarra = New System.Windows.Forms.ToolStrip()
      Me.tsbRefrescar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbGrabar = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbEliminarConceptosMasivo = New System.Windows.Forms.ToolStripButton()
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me.tsbSalir = New System.Windows.Forms.ToolStripButton()
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
      Me.tssRegistros = New System.Windows.Forms.ToolStripStatusLabel()
      Me.btnAsignarConcepto = New Eniac.Controles.Button()
      Me.txtValorConcepto = New Eniac.Controles.TextBox()
      Me.btnBorrarConceptoSueldo = New Eniac.Controles.Button()
      Me.lblCodigoConcepto = New Eniac.Controles.Label()
      Me.lblNombreConcepto = New Eniac.Controles.Label()
      Me.bscCodigoConcepto = New Eniac.Controles.Buscador()
      Me.bscNombreConcepto = New Eniac.Controles.Buscador()
      Me.lblTipoConcepto = New Eniac.Controles.Label()
      Me.Label10 = New Eniac.Controles.Label()
      Me.Label12 = New Eniac.Controles.Label()
      Me.lblModalidad = New Eniac.Controles.Label()
      Me.grpConceptos = New System.Windows.Forms.GroupBox()
      Me.btnLimpiar = New Eniac.Controles.Button()
      Me.cmbTipoRecibo = New Eniac.Controles.ComboBox()
      Me.lblTipoRecibo = New Eniac.Controles.Label()
      Me.txtPeriodosLiquidar = New Eniac.Controles.TextBox()
      Me.Label4 = New Eniac.Controles.Label()
      Me.Label14 = New Eniac.Controles.Label()
      Me.grpModalidad = New System.Windows.Forms.GroupBox()
      Me.RadioModoAguinaldo = New System.Windows.Forms.RadioButton()
      Me.RadioModoNormal = New System.Windows.Forms.RadioButton()
      Me.lblNormal_o_Aguianaldo = New Eniac.Controles.Label()
      Me.lblValorConcepto = New Eniac.Controles.Label()
      Me.spcAsinacionDeConceptos = New System.Windows.Forms.SplitContainer()
      Me.cmbLugarActividad = New Eniac.Controles.ComboBox()
      Me.chbLugarActividad = New Eniac.Controles.CheckBox()
      Me.cmbEstadoCivil = New Eniac.Controles.ComboBox()
      Me.chbEstadoCivil = New Eniac.Controles.CheckBox()
      Me.ugvPersonal = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.PersonalBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataSetSueldos = New Eniac.Win.DataSetSueldos()
      Me.chbPersonalSeleccionarTodos = New Eniac.Controles.CheckBox()
      Me.dgvConceptosSueldo = New Infragistics.Win.UltraWinGrid.UltraGrid()
      Me.ConceptosPersonalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.GrillaPagosRecibosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.GeneraCuotasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.PersonalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.DataSetSueldosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.tstBarra.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.grpConceptos.SuspendLayout()
      Me.grpModalidad.SuspendLayout()
      CType(Me.spcAsinacionDeConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spcAsinacionDeConceptos.Panel1.SuspendLayout()
      Me.spcAsinacionDeConceptos.Panel2.SuspendLayout()
      Me.spcAsinacionDeConceptos.SuspendLayout()
      CType(Me.ugvPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PersonalBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvConceptosSueldo, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ConceptosPersonalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.GrillaPagosRecibosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.GeneraCuotasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PersonalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataSetSueldosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'imgIconos
      '
      Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
      Me.imgIconos.Images.SetKeyName(0, "document_find.ico")
      Me.imgIconos.Images.SetKeyName(1, "folder.ico")
      Me.imgIconos.Images.SetKeyName(2, "row_add.ico")
      Me.imgIconos.Images.SetKeyName(3, "refresh.ico")
      '
      'tstBarra
      '
      Me.tstBarra.AllowItemReorder = True
      Me.tstBarra.ImageScalingSize = New System.Drawing.Size(22, 22)
      Me.tstBarra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbRefrescar, Me.ToolStripSeparator2, Me.tsbGrabar, Me.ToolStripSeparator1, Me.tsbEliminarConceptosMasivo, Me.ToolStripSeparator3, Me.tsbSalir})
      Me.tstBarra.Location = New System.Drawing.Point(0, 0)
      Me.tstBarra.Name = "tstBarra"
      Me.tstBarra.Size = New System.Drawing.Size(1073, 29)
      Me.tstBarra.TabIndex = 9
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
      'tsbGrabar
      '
      Me.tsbGrabar.Image = CType(resources.GetObject("tsbGrabar.Image"), System.Drawing.Image)
      Me.tsbGrabar.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbGrabar.Name = "tsbGrabar"
      Me.tsbGrabar.Size = New System.Drawing.Size(68, 26)
      Me.tsbGrabar.Text = "&Grabar"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 29)
      '
      'tsbEliminarConceptosMasivo
      '
      Me.tsbEliminarConceptosMasivo.Image = CType(resources.GetObject("tsbEliminarConceptosMasivo.Image"), System.Drawing.Image)
      Me.tsbEliminarConceptosMasivo.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.tsbEliminarConceptosMasivo.Name = "tsbEliminarConceptosMasivo"
      Me.tsbEliminarConceptosMasivo.Size = New System.Drawing.Size(210, 26)
      Me.tsbEliminarConceptosMasivo.Text = "&Eliminar Conceptos Masivamente"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 29)
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
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssRegistros})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 450)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(1073, 22)
      Me.StatusStrip1.TabIndex = 8
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'tssRegistros
      '
      Me.tssRegistros.Name = "tssRegistros"
      Me.tssRegistros.Size = New System.Drawing.Size(1058, 17)
      Me.tssRegistros.Spring = True
      Me.tssRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnAsignarConcepto
      '
      Me.btnAsignarConcepto.Image = CType(resources.GetObject("btnAsignarConcepto.Image"), System.Drawing.Image)
      Me.btnAsignarConcepto.Location = New System.Drawing.Point(555, 27)
      Me.btnAsignarConcepto.Name = "btnAsignarConcepto"
      Me.btnAsignarConcepto.Size = New System.Drawing.Size(37, 37)
      Me.btnAsignarConcepto.TabIndex = 10
      Me.btnAsignarConcepto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnAsignarConcepto.UseVisualStyleBackColor = True
      '
      'txtValorConcepto
      '
      Me.txtValorConcepto.BindearPropiedadControl = ""
      Me.txtValorConcepto.BindearPropiedadEntidad = ""
      Me.txtValorConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.txtValorConcepto.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtValorConcepto.Formato = "#,##0.00"
      Me.txtValorConcepto.IsDecimal = True
      Me.txtValorConcepto.IsNumber = True
      Me.txtValorConcepto.IsPK = False
      Me.txtValorConcepto.IsRequired = True
      Me.txtValorConcepto.Key = ""
      Me.txtValorConcepto.LabelAsoc = Nothing
      Me.txtValorConcepto.Location = New System.Drawing.Point(490, 43)
      Me.txtValorConcepto.MaxLength = 25
      Me.txtValorConcepto.Name = "txtValorConcepto"
      Me.txtValorConcepto.Size = New System.Drawing.Size(61, 20)
      Me.txtValorConcepto.TabIndex = 4
      Me.txtValorConcepto.Text = "0.00"
      Me.txtValorConcepto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'btnBorrarConceptoSueldo
      '
      Me.btnBorrarConceptoSueldo.Image = CType(resources.GetObject("btnBorrarConceptoSueldo.Image"), System.Drawing.Image)
      Me.btnBorrarConceptoSueldo.Location = New System.Drawing.Point(555, 67)
      Me.btnBorrarConceptoSueldo.Name = "btnBorrarConceptoSueldo"
      Me.btnBorrarConceptoSueldo.Size = New System.Drawing.Size(37, 37)
      Me.btnBorrarConceptoSueldo.TabIndex = 11
      Me.btnBorrarConceptoSueldo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnBorrarConceptoSueldo.UseVisualStyleBackColor = True
      '
      'lblCodigoConcepto
      '
      Me.lblCodigoConcepto.AutoSize = True
      Me.lblCodigoConcepto.Location = New System.Drawing.Point(121, 25)
      Me.lblCodigoConcepto.Name = "lblCodigoConcepto"
      Me.lblCodigoConcepto.Size = New System.Drawing.Size(53, 13)
      Me.lblCodigoConcepto.TabIndex = 0
      Me.lblCodigoConcepto.Text = "Concepto"
      '
      'lblNombreConcepto
      '
      Me.lblNombreConcepto.AutoSize = True
      Me.lblNombreConcepto.Location = New System.Drawing.Point(235, 23)
      Me.lblNombreConcepto.Name = "lblNombreConcepto"
      Me.lblNombreConcepto.Size = New System.Drawing.Size(44, 13)
      Me.lblNombreConcepto.TabIndex = 2
      Me.lblNombreConcepto.Text = "Nombre"
      '
      'bscCodigoConcepto
      '
      Me.bscCodigoConcepto.AyudaAncho = 608
      Me.bscCodigoConcepto.BindearPropiedadControl = Nothing
      Me.bscCodigoConcepto.BindearPropiedadEntidad = Nothing
      Me.bscCodigoConcepto.ColumnasAlineacion = Nothing
      Me.bscCodigoConcepto.ColumnasAncho = Nothing
      Me.bscCodigoConcepto.ColumnasFormato = Nothing
      Me.bscCodigoConcepto.ColumnasOcultas = Nothing
      Me.bscCodigoConcepto.ColumnasTitulos = Nothing
      Me.bscCodigoConcepto.Datos = Nothing
      Me.bscCodigoConcepto.FilaDevuelta = Nothing
      Me.bscCodigoConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscCodigoConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscCodigoConcepto.IsDecimal = False
      Me.bscCodigoConcepto.IsNumber = True
      Me.bscCodigoConcepto.IsPK = False
      Me.bscCodigoConcepto.IsRequired = False
      Me.bscCodigoConcepto.Key = ""
      Me.bscCodigoConcepto.LabelAsoc = Me.lblCodigoConcepto
      Me.bscCodigoConcepto.Location = New System.Drawing.Point(124, 40)
      Me.bscCodigoConcepto.MaxLengh = "32767"
      Me.bscCodigoConcepto.Name = "bscCodigoConcepto"
      Me.bscCodigoConcepto.Permitido = True
      Me.bscCodigoConcepto.Selecciono = False
      Me.bscCodigoConcepto.Size = New System.Drawing.Size(107, 23)
      Me.bscCodigoConcepto.TabIndex = 2
      Me.bscCodigoConcepto.Titulo = Nothing
      '
      'bscNombreConcepto
      '
      Me.bscNombreConcepto.AutoSize = True
      Me.bscNombreConcepto.AyudaAncho = 608
      Me.bscNombreConcepto.BindearPropiedadControl = Nothing
      Me.bscNombreConcepto.BindearPropiedadEntidad = Nothing
      Me.bscNombreConcepto.ColumnasAlineacion = Nothing
      Me.bscNombreConcepto.ColumnasAncho = Nothing
      Me.bscNombreConcepto.ColumnasFormato = Nothing
      Me.bscNombreConcepto.ColumnasOcultas = Nothing
      Me.bscNombreConcepto.ColumnasTitulos = Nothing
      Me.bscNombreConcepto.Datos = Nothing
      Me.bscNombreConcepto.FilaDevuelta = Nothing
      Me.bscNombreConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.bscNombreConcepto.ForeColorFocus = System.Drawing.Color.Red
      Me.bscNombreConcepto.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.bscNombreConcepto.IsDecimal = False
      Me.bscNombreConcepto.IsNumber = False
      Me.bscNombreConcepto.IsPK = False
      Me.bscNombreConcepto.IsRequired = False
      Me.bscNombreConcepto.Key = ""
      Me.bscNombreConcepto.LabelAsoc = Me.lblNombreConcepto
      Me.bscNombreConcepto.Location = New System.Drawing.Point(238, 40)
      Me.bscNombreConcepto.Margin = New System.Windows.Forms.Padding(4)
      Me.bscNombreConcepto.MaxLengh = "32767"
      Me.bscNombreConcepto.Name = "bscNombreConcepto"
      Me.bscNombreConcepto.Permitido = True
      Me.bscNombreConcepto.Selecciono = False
      Me.bscNombreConcepto.Size = New System.Drawing.Size(245, 23)
      Me.bscNombreConcepto.TabIndex = 3
      Me.bscNombreConcepto.Titulo = Nothing
      '
      'lblTipoConcepto
      '
      Me.lblTipoConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblTipoConcepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblTipoConcepto.Location = New System.Drawing.Point(181, 84)
      Me.lblTipoConcepto.Name = "lblTipoConcepto"
      Me.lblTipoConcepto.Size = New System.Drawing.Size(108, 19)
      Me.lblTipoConcepto.TabIndex = 7
      Me.lblTipoConcepto.Text = "-"
      Me.lblTipoConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(178, 67)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(92, 13)
      Me.Label10.TabIndex = 9
      Me.Label10.Text = "Tipo de Concepto"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.Location = New System.Drawing.Point(429, 65)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(56, 13)
      Me.Label12.TabIndex = 13
      Me.Label12.Text = "Modalidad"
      '
      'lblModalidad
      '
      Me.lblModalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblModalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblModalidad.Location = New System.Drawing.Point(432, 84)
      Me.lblModalidad.Name = "lblModalidad"
      Me.lblModalidad.Size = New System.Drawing.Size(117, 19)
      Me.lblModalidad.TabIndex = 9
      Me.lblModalidad.Text = "-"
      Me.lblModalidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'grpConceptos
      '
      Me.grpConceptos.Controls.Add(Me.btnLimpiar)
      Me.grpConceptos.Controls.Add(Me.cmbTipoRecibo)
      Me.grpConceptos.Controls.Add(Me.lblTipoRecibo)
      Me.grpConceptos.Controls.Add(Me.txtPeriodosLiquidar)
      Me.grpConceptos.Controls.Add(Me.Label4)
      Me.grpConceptos.Controls.Add(Me.btnBorrarConceptoSueldo)
      Me.grpConceptos.Controls.Add(Me.Label14)
      Me.grpConceptos.Controls.Add(Me.grpModalidad)
      Me.grpConceptos.Controls.Add(Me.bscCodigoConcepto)
      Me.grpConceptos.Controls.Add(Me.lblNormal_o_Aguianaldo)
      Me.grpConceptos.Controls.Add(Me.lblCodigoConcepto)
      Me.grpConceptos.Controls.Add(Me.lblValorConcepto)
      Me.grpConceptos.Controls.Add(Me.bscNombreConcepto)
      Me.grpConceptos.Controls.Add(Me.lblModalidad)
      Me.grpConceptos.Controls.Add(Me.lblNombreConcepto)
      Me.grpConceptos.Controls.Add(Me.Label12)
      Me.grpConceptos.Controls.Add(Me.btnAsignarConcepto)
      Me.grpConceptos.Controls.Add(Me.txtValorConcepto)
      Me.grpConceptos.Controls.Add(Me.Label10)
      Me.grpConceptos.Controls.Add(Me.lblTipoConcepto)
      Me.grpConceptos.Location = New System.Drawing.Point(5, 7)
      Me.grpConceptos.Name = "grpConceptos"
      Me.grpConceptos.Size = New System.Drawing.Size(602, 114)
      Me.grpConceptos.TabIndex = 0
      Me.grpConceptos.TabStop = False
      Me.grpConceptos.Text = "Seleccion de conceptos"
      '
      'btnLimpiar
      '
      Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Image)
      Me.btnLimpiar.Location = New System.Drawing.Point(87, 24)
      Me.btnLimpiar.Name = "btnLimpiar"
      Me.btnLimpiar.Size = New System.Drawing.Size(37, 37)
      Me.btnLimpiar.TabIndex = 19
      Me.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.btnLimpiar.UseVisualStyleBackColor = True
      '
      'cmbTipoRecibo
      '
      Me.cmbTipoRecibo.BindearPropiedadControl = "SelectedValue"
      Me.cmbTipoRecibo.BindearPropiedadEntidad = "IdTipoConcepto"
      Me.cmbTipoRecibo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoRecibo.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbTipoRecibo.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbTipoRecibo.FormattingEnabled = True
      Me.cmbTipoRecibo.IsPK = False
      Me.cmbTipoRecibo.IsRequired = True
      Me.cmbTipoRecibo.Key = Nothing
      Me.cmbTipoRecibo.LabelAsoc = Me.lblTipoRecibo
      Me.cmbTipoRecibo.Location = New System.Drawing.Point(6, 82)
      Me.cmbTipoRecibo.Name = "cmbTipoRecibo"
      Me.cmbTipoRecibo.Size = New System.Drawing.Size(118, 21)
      Me.cmbTipoRecibo.TabIndex = 5
      '
      'lblTipoRecibo
      '
      Me.lblTipoRecibo.AutoSize = True
      Me.lblTipoRecibo.Location = New System.Drawing.Point(3, 68)
      Me.lblTipoRecibo.Name = "lblTipoRecibo"
      Me.lblTipoRecibo.Size = New System.Drawing.Size(80, 13)
      Me.lblTipoRecibo.TabIndex = 17
      Me.lblTipoRecibo.Text = "Tipo de Recibo"
      '
      'txtPeriodosLiquidar
      '
      Me.txtPeriodosLiquidar.BindearPropiedadControl = ""
      Me.txtPeriodosLiquidar.BindearPropiedadEntidad = ""
      Me.txtPeriodosLiquidar.Enabled = False
      Me.txtPeriodosLiquidar.ForeColorFocus = System.Drawing.Color.Red
      Me.txtPeriodosLiquidar.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.txtPeriodosLiquidar.Formato = ""
      Me.txtPeriodosLiquidar.IsDecimal = False
      Me.txtPeriodosLiquidar.IsNumber = True
      Me.txtPeriodosLiquidar.IsPK = False
      Me.txtPeriodosLiquidar.IsRequired = False
      Me.txtPeriodosLiquidar.Key = ""
      Me.txtPeriodosLiquidar.LabelAsoc = Nothing
      Me.txtPeriodosLiquidar.Location = New System.Drawing.Point(130, 84)
      Me.txtPeriodosLiquidar.MaxLength = 2
      Me.txtPeriodosLiquidar.Name = "txtPeriodosLiquidar"
      Me.txtPeriodosLiquidar.Size = New System.Drawing.Size(45, 20)
      Me.txtPeriodosLiquidar.TabIndex = 6
      Me.txtPeriodosLiquidar.Text = "0"
      Me.txtPeriodosLiquidar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(122, 68)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 15
      Me.Label4.Text = "Períodos"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.Location = New System.Drawing.Point(292, 68)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(100, 13)
      Me.Label14.TabIndex = 11
      Me.Label14.Text = "Tipo de Liquidacion"
      '
      'grpModalidad
      '
      Me.grpModalidad.Controls.Add(Me.RadioModoAguinaldo)
      Me.grpModalidad.Controls.Add(Me.RadioModoNormal)
      Me.grpModalidad.Location = New System.Drawing.Point(6, 14)
      Me.grpModalidad.Name = "grpModalidad"
      Me.grpModalidad.Size = New System.Drawing.Size(80, 52)
      Me.grpModalidad.TabIndex = 0
      Me.grpModalidad.TabStop = False
      '
      'RadioModoAguinaldo
      '
      Me.RadioModoAguinaldo.AutoSize = True
      Me.RadioModoAguinaldo.Location = New System.Drawing.Point(6, 29)
      Me.RadioModoAguinaldo.Name = "RadioModoAguinaldo"
      Me.RadioModoAguinaldo.Size = New System.Drawing.Size(72, 17)
      Me.RadioModoAguinaldo.TabIndex = 1
      Me.RadioModoAguinaldo.Text = "Aguinaldo"
      Me.RadioModoAguinaldo.UseVisualStyleBackColor = True
      '
      'RadioModoNormal
      '
      Me.RadioModoNormal.AutoSize = True
      Me.RadioModoNormal.Checked = True
      Me.RadioModoNormal.Location = New System.Drawing.Point(7, 10)
      Me.RadioModoNormal.Name = "RadioModoNormal"
      Me.RadioModoNormal.Size = New System.Drawing.Size(58, 17)
      Me.RadioModoNormal.TabIndex = 0
      Me.RadioModoNormal.TabStop = True
      Me.RadioModoNormal.Text = "Normal"
      Me.RadioModoNormal.UseVisualStyleBackColor = True
      '
      'lblNormal_o_Aguianaldo
      '
      Me.lblNormal_o_Aguianaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblNormal_o_Aguianaldo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.lblNormal_o_Aguianaldo.Location = New System.Drawing.Point(295, 84)
      Me.lblNormal_o_Aguianaldo.Name = "lblNormal_o_Aguianaldo"
      Me.lblNormal_o_Aguianaldo.Size = New System.Drawing.Size(131, 19)
      Me.lblNormal_o_Aguianaldo.TabIndex = 8
      Me.lblNormal_o_Aguianaldo.Text = "-"
      Me.lblNormal_o_Aguianaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblValorConcepto
      '
      Me.lblValorConcepto.AutoSize = True
      Me.lblValorConcepto.Location = New System.Drawing.Point(487, 28)
      Me.lblValorConcepto.Name = "lblValorConcepto"
      Me.lblValorConcepto.Size = New System.Drawing.Size(31, 13)
      Me.lblValorConcepto.TabIndex = 4
      Me.lblValorConcepto.Text = "Valor"
      '
      'spcAsinacionDeConceptos
      '
      Me.spcAsinacionDeConceptos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.spcAsinacionDeConceptos.Location = New System.Drawing.Point(0, 29)
      Me.spcAsinacionDeConceptos.Name = "spcAsinacionDeConceptos"
      '
      'spcAsinacionDeConceptos.Panel1
      '
      Me.spcAsinacionDeConceptos.Panel1.Controls.Add(Me.cmbLugarActividad)
      Me.spcAsinacionDeConceptos.Panel1.Controls.Add(Me.chbLugarActividad)
      Me.spcAsinacionDeConceptos.Panel1.Controls.Add(Me.cmbEstadoCivil)
      Me.spcAsinacionDeConceptos.Panel1.Controls.Add(Me.chbEstadoCivil)
      Me.spcAsinacionDeConceptos.Panel1.Controls.Add(Me.ugvPersonal)
      Me.spcAsinacionDeConceptos.Panel1.Controls.Add(Me.chbPersonalSeleccionarTodos)
      '
      'spcAsinacionDeConceptos.Panel2
      '
      Me.spcAsinacionDeConceptos.Panel2.Controls.Add(Me.dgvConceptosSueldo)
      Me.spcAsinacionDeConceptos.Panel2.Controls.Add(Me.grpConceptos)
      Me.spcAsinacionDeConceptos.Size = New System.Drawing.Size(1073, 421)
      Me.spcAsinacionDeConceptos.SplitterDistance = 459
      Me.spcAsinacionDeConceptos.TabIndex = 0
      '
      'cmbLugarActividad
      '
      Me.cmbLugarActividad.BindearPropiedadControl = Nothing
      Me.cmbLugarActividad.BindearPropiedadEntidad = Nothing
      Me.cmbLugarActividad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbLugarActividad.Enabled = False
      Me.cmbLugarActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbLugarActividad.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbLugarActividad.FormattingEnabled = True
      Me.cmbLugarActividad.IsPK = False
      Me.cmbLugarActividad.IsRequired = False
      Me.cmbLugarActividad.Key = Nothing
      Me.cmbLugarActividad.LabelAsoc = Nothing
      Me.cmbLugarActividad.Location = New System.Drawing.Point(353, 7)
      Me.cmbLugarActividad.Name = "cmbLugarActividad"
      Me.cmbLugarActividad.Size = New System.Drawing.Size(103, 21)
      Me.cmbLugarActividad.TabIndex = 7
      '
      'chbLugarActividad
      '
      Me.chbLugarActividad.AutoSize = True
      Me.chbLugarActividad.BindearPropiedadControl = Nothing
      Me.chbLugarActividad.BindearPropiedadEntidad = Nothing
      Me.chbLugarActividad.ForeColorFocus = System.Drawing.Color.Red
      Me.chbLugarActividad.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbLugarActividad.IsPK = False
      Me.chbLugarActividad.IsRequired = False
      Me.chbLugarActividad.Key = Nothing
      Me.chbLugarActividad.LabelAsoc = Nothing
      Me.chbLugarActividad.Location = New System.Drawing.Point(258, 13)
      Me.chbLugarActividad.Name = "chbLugarActividad"
      Me.chbLugarActividad.Size = New System.Drawing.Size(100, 17)
      Me.chbLugarActividad.TabIndex = 8
      Me.chbLugarActividad.Text = "Lugar Actividad"
      Me.chbLugarActividad.UseVisualStyleBackColor = True
      '
      'cmbEstadoCivil
      '
      Me.cmbEstadoCivil.BindearPropiedadControl = Nothing
      Me.cmbEstadoCivil.BindearPropiedadEntidad = Nothing
      Me.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbEstadoCivil.Enabled = False
      Me.cmbEstadoCivil.ForeColorFocus = System.Drawing.Color.Red
      Me.cmbEstadoCivil.ForeColorLostFocus = System.Drawing.SystemColors.WindowText
      Me.cmbEstadoCivil.FormattingEnabled = True
      Me.cmbEstadoCivil.IsPK = False
      Me.cmbEstadoCivil.IsRequired = False
      Me.cmbEstadoCivil.Key = Nothing
      Me.cmbEstadoCivil.LabelAsoc = Nothing
      Me.cmbEstadoCivil.Location = New System.Drawing.Point(146, 7)
      Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
      Me.cmbEstadoCivil.Size = New System.Drawing.Size(108, 21)
      Me.cmbEstadoCivil.TabIndex = 5
      '
      'chbEstadoCivil
      '
      Me.chbEstadoCivil.AutoSize = True
      Me.chbEstadoCivil.BindearPropiedadControl = Nothing
      Me.chbEstadoCivil.BindearPropiedadEntidad = Nothing
      Me.chbEstadoCivil.ForeColorFocus = System.Drawing.Color.Red
      Me.chbEstadoCivil.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbEstadoCivil.IsPK = False
      Me.chbEstadoCivil.IsRequired = False
      Me.chbEstadoCivil.Key = Nothing
      Me.chbEstadoCivil.LabelAsoc = Nothing
      Me.chbEstadoCivil.Location = New System.Drawing.Point(69, 13)
      Me.chbEstadoCivil.Name = "chbEstadoCivil"
      Me.chbEstadoCivil.Size = New System.Drawing.Size(81, 17)
      Me.chbEstadoCivil.TabIndex = 6
      Me.chbEstadoCivil.Text = "Estado Civil"
      Me.chbEstadoCivil.UseVisualStyleBackColor = True
      '
      'ugvPersonal
      '
      Me.ugvPersonal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ugvPersonal.DataSource = Me.PersonalBindingSource1
      Appearance1.BackColor = System.Drawing.SystemColors.Window
      Appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.ugvPersonal.DisplayLayout.Appearance = Appearance1
      UltraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn7.Header.VisiblePosition = 1
      UltraGridColumn7.RowLayoutColumnInfo.OriginX = 2
      UltraGridColumn7.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn7.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(47, 0)
      UltraGridColumn7.RowLayoutColumnInfo.SpanX = 2
      UltraGridColumn7.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn8.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn8.Header.VisiblePosition = 2
      UltraGridColumn8.RowLayoutColumnInfo.OriginX = 4
      UltraGridColumn8.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn8.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(141, 0)
      UltraGridColumn8.RowLayoutColumnInfo.SpanX = 3
      UltraGridColumn8.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn9.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn9.Header.VisiblePosition = 3
      UltraGridColumn9.RowLayoutColumnInfo.OriginX = 7
      UltraGridColumn9.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn9.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(57, 0)
      UltraGridColumn9.RowLayoutColumnInfo.SpanX = 2
      UltraGridColumn9.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn10.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn10.Header.VisiblePosition = 4
      UltraGridColumn10.RowLayoutColumnInfo.OriginX = 9
      UltraGridColumn10.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn10.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(93, 0)
      UltraGridColumn10.RowLayoutColumnInfo.SpanX = 2
      UltraGridColumn10.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn11.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn11.Header.VisiblePosition = 5
      UltraGridColumn11.RowLayoutColumnInfo.OriginX = 11
      UltraGridColumn11.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn11.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(101, 0)
      UltraGridColumn11.RowLayoutColumnInfo.SpanX = 3
      UltraGridColumn11.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn12.DataType = GetType(Boolean)
      UltraGridColumn12.Header.Caption = ""
      UltraGridColumn12.Header.VisiblePosition = 0
      UltraGridColumn12.RowLayoutColumnInfo.OriginX = 0
      UltraGridColumn12.RowLayoutColumnInfo.OriginY = 0
      UltraGridColumn12.RowLayoutColumnInfo.PreferredCellSize = New System.Drawing.Size(42, 0)
      UltraGridColumn12.RowLayoutColumnInfo.SpanX = 2
      UltraGridColumn12.RowLayoutColumnInfo.SpanY = 2
      UltraGridColumn12.Width = 43
      UltraGridBand1.Columns.AddRange(New Object() {UltraGridColumn7, UltraGridColumn8, UltraGridColumn9, UltraGridColumn10, UltraGridColumn11, UltraGridColumn12})
      UltraGridBand1.RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.GroupLayout
      UltraGridBand1.SummaryFooterCaption = "Suma"
      Me.ugvPersonal.DisplayLayout.BandsSerializer.Add(UltraGridBand1)
      Me.ugvPersonal.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance2.BorderColor = System.Drawing.SystemColors.Window
      Me.ugvPersonal.DisplayLayout.GroupByBox.Appearance = Appearance2
      Appearance3.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugvPersonal.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance3
      Me.ugvPersonal.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.ugvPersonal.DisplayLayout.GroupByBox.Hidden = True
      Me.ugvPersonal.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna aquí para agrupar."
      Appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance4.BackColor2 = System.Drawing.SystemColors.Control
      Appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance4.ForeColor = System.Drawing.SystemColors.GrayText
      Me.ugvPersonal.DisplayLayout.GroupByBox.PromptAppearance = Appearance4
      Me.ugvPersonal.DisplayLayout.MaxColScrollRegions = 1
      Me.ugvPersonal.DisplayLayout.MaxRowScrollRegions = 1
      Appearance5.BackColor = System.Drawing.SystemColors.Window
      Appearance5.ForeColor = System.Drawing.SystemColors.ControlText
      Me.ugvPersonal.DisplayLayout.Override.ActiveCellAppearance = Appearance5
      Appearance6.BackColor = System.Drawing.SystemColors.Highlight
      Appearance6.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.ugvPersonal.DisplayLayout.Override.ActiveRowAppearance = Appearance6
      Me.ugvPersonal.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.ugvPersonal.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance7.BackColor = System.Drawing.SystemColors.Window
      Me.ugvPersonal.DisplayLayout.Override.CardAreaAppearance = Appearance7
      Appearance8.BorderColor = System.Drawing.Color.Silver
      Appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.ugvPersonal.DisplayLayout.Override.CellAppearance = Appearance8
      Me.ugvPersonal.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.ugvPersonal.DisplayLayout.Override.CellPadding = 0
      Appearance9.BackColor = System.Drawing.SystemColors.Control
      Appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance9.BorderColor = System.Drawing.SystemColors.Window
      Me.ugvPersonal.DisplayLayout.Override.GroupByRowAppearance = Appearance9
      Appearance10.TextHAlignAsString = "Left"
      Me.ugvPersonal.DisplayLayout.Override.HeaderAppearance = Appearance10
      Me.ugvPersonal.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.ugvPersonal.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance11.BackColor = System.Drawing.SystemColors.Window
      Appearance11.BorderColor = System.Drawing.Color.Silver
      Me.ugvPersonal.DisplayLayout.Override.RowAppearance = Appearance11
      Me.ugvPersonal.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance12.BackColor = System.Drawing.SystemColors.ControlLight
      Me.ugvPersonal.DisplayLayout.Override.TemplateAddRowAppearance = Appearance12
      Me.ugvPersonal.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.ugvPersonal.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.ugvPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ugvPersonal.Location = New System.Drawing.Point(3, 34)
      Me.ugvPersonal.Name = "ugvPersonal"
      Me.ugvPersonal.Size = New System.Drawing.Size(453, 384)
      Me.ugvPersonal.TabIndex = 0
      Me.ugvPersonal.Text = "Personal"
      '
      'PersonalBindingSource1
      '
      Me.PersonalBindingSource1.DataMember = "Personal"
      Me.PersonalBindingSource1.DataSource = Me.DataSetSueldos
      '
      'DataSetSueldos
      '
      Me.DataSetSueldos.DataSetName = "DataSetSueldos"
      Me.DataSetSueldos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'chbPersonalSeleccionarTodos
      '
      Me.chbPersonalSeleccionarTodos.AutoSize = True
      Me.chbPersonalSeleccionarTodos.BindearPropiedadControl = Nothing
      Me.chbPersonalSeleccionarTodos.BindearPropiedadEntidad = Nothing
      Me.chbPersonalSeleccionarTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.chbPersonalSeleccionarTodos.ForeColorFocus = System.Drawing.Color.Red
      Me.chbPersonalSeleccionarTodos.ForeColorLostFocus = System.Drawing.SystemColors.ControlText
      Me.chbPersonalSeleccionarTodos.IsPK = False
      Me.chbPersonalSeleccionarTodos.IsRequired = False
      Me.chbPersonalSeleccionarTodos.Key = Nothing
      Me.chbPersonalSeleccionarTodos.LabelAsoc = Nothing
      Me.chbPersonalSeleccionarTodos.Location = New System.Drawing.Point(6, 12)
      Me.chbPersonalSeleccionarTodos.Name = "chbPersonalSeleccionarTodos"
      Me.chbPersonalSeleccionarTodos.Size = New System.Drawing.Size(55, 17)
      Me.chbPersonalSeleccionarTodos.TabIndex = 9
      Me.chbPersonalSeleccionarTodos.Text = "Check"
      Me.chbPersonalSeleccionarTodos.UseVisualStyleBackColor = True
      '
      'dgvConceptosSueldo
      '
      Me.dgvConceptosSueldo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Appearance13.BackColor = System.Drawing.SystemColors.Window
      Appearance13.BorderColor = System.Drawing.SystemColors.InactiveCaption
      Me.dgvConceptosSueldo.DisplayLayout.Appearance = Appearance13
      UltraGridColumn13.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn13.Header.VisiblePosition = 0
      UltraGridColumn14.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn14.Header.VisiblePosition = 1
      UltraGridColumn14.Hidden = True
      UltraGridColumn15.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn15.Header.VisiblePosition = 2
      UltraGridColumn15.Width = 182
      UltraGridColumn16.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn16.Header.VisiblePosition = 3
      UltraGridColumn16.Hidden = True
      UltraGridColumn17.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn17.Header.VisiblePosition = 4
      UltraGridColumn17.Width = 108
      UltraGridColumn18.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn18.Header.VisiblePosition = 5
      UltraGridColumn18.Hidden = True
      UltraGridColumn19.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn19.Header.VisiblePosition = 6
      UltraGridColumn19.Width = 87
      UltraGridColumn20.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
      UltraGridColumn20.Header.VisiblePosition = 7
      UltraGridColumn20.MaskInput = "{double:9.2}"
      UltraGridColumn20.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
      UltraGridColumn20.Width = 66
      UltraGridColumn21.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn21.Header.VisiblePosition = 8
      UltraGridColumn21.Hidden = True
      UltraGridColumn21.Width = 61
      UltraGridColumn22.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn22.Header.VisiblePosition = 9
      UltraGridColumn22.Hidden = True
      UltraGridColumn1.Header.VisiblePosition = 10
      UltraGridColumn1.Width = 80
      UltraGridColumn23.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn23.Header.VisiblePosition = 11
      UltraGridColumn23.Width = 80
      UltraGridColumn24.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
      UltraGridColumn24.Header.VisiblePosition = 12
      UltraGridColumn25.Header.VisiblePosition = 13
      UltraGridColumn25.Hidden = True
      UltraGridBand2.Columns.AddRange(New Object() {UltraGridColumn13, UltraGridColumn14, UltraGridColumn15, UltraGridColumn16, UltraGridColumn17, UltraGridColumn18, UltraGridColumn19, UltraGridColumn20, UltraGridColumn21, UltraGridColumn22, UltraGridColumn1, UltraGridColumn23, UltraGridColumn24, UltraGridColumn25})
      UltraGridBand2.SummaryFooterCaption = "Suma"
      Me.dgvConceptosSueldo.DisplayLayout.BandsSerializer.Add(UltraGridBand2)
      Me.dgvConceptosSueldo.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder
      Appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
      Appearance14.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvConceptosSueldo.DisplayLayout.GroupByBox.Appearance = Appearance14
      Appearance15.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvConceptosSueldo.DisplayLayout.GroupByBox.BandLabelAppearance = Appearance15
      Me.dgvConceptosSueldo.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
      Me.dgvConceptosSueldo.DisplayLayout.GroupByBox.Hidden = True
      Me.dgvConceptosSueldo.DisplayLayout.GroupByBox.Prompt = "Arrastre una columna aquí para agrupar."
      Appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight
      Appearance16.BackColor2 = System.Drawing.SystemColors.Control
      Appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance16.ForeColor = System.Drawing.SystemColors.GrayText
      Me.dgvConceptosSueldo.DisplayLayout.GroupByBox.PromptAppearance = Appearance16
      Me.dgvConceptosSueldo.DisplayLayout.MaxColScrollRegions = 1
      Me.dgvConceptosSueldo.DisplayLayout.MaxRowScrollRegions = 1
      Appearance17.BackColor = System.Drawing.SystemColors.Window
      Appearance17.ForeColor = System.Drawing.SystemColors.ControlText
      Me.dgvConceptosSueldo.DisplayLayout.Override.ActiveCellAppearance = Appearance17
      Appearance18.BackColor = System.Drawing.SystemColors.Highlight
      Appearance18.ForeColor = System.Drawing.SystemColors.HighlightText
      Me.dgvConceptosSueldo.DisplayLayout.Override.ActiveRowAppearance = Appearance18
      Me.dgvConceptosSueldo.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted
      Me.dgvConceptosSueldo.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted
      Appearance19.BackColor = System.Drawing.SystemColors.Window
      Me.dgvConceptosSueldo.DisplayLayout.Override.CardAreaAppearance = Appearance19
      Appearance20.BorderColor = System.Drawing.Color.Silver
      Appearance20.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter
      Me.dgvConceptosSueldo.DisplayLayout.Override.CellAppearance = Appearance20
      Me.dgvConceptosSueldo.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText
      Me.dgvConceptosSueldo.DisplayLayout.Override.CellPadding = 0
      Appearance21.BackColor = System.Drawing.SystemColors.Control
      Appearance21.BackColor2 = System.Drawing.SystemColors.ControlDark
      Appearance21.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element
      Appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal
      Appearance21.BorderColor = System.Drawing.SystemColors.Window
      Me.dgvConceptosSueldo.DisplayLayout.Override.GroupByRowAppearance = Appearance21
      Appearance22.TextHAlignAsString = "Left"
      Me.dgvConceptosSueldo.DisplayLayout.Override.HeaderAppearance = Appearance22
      Me.dgvConceptosSueldo.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
      Me.dgvConceptosSueldo.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand
      Appearance23.BackColor = System.Drawing.SystemColors.Window
      Appearance23.BorderColor = System.Drawing.Color.Silver
      Me.dgvConceptosSueldo.DisplayLayout.Override.RowAppearance = Appearance23
      Me.dgvConceptosSueldo.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.[False]
      Appearance24.BackColor = System.Drawing.SystemColors.ControlLight
      Me.dgvConceptosSueldo.DisplayLayout.Override.TemplateAddRowAppearance = Appearance24
      Me.dgvConceptosSueldo.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
      Me.dgvConceptosSueldo.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
      Me.dgvConceptosSueldo.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
      Me.dgvConceptosSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dgvConceptosSueldo.Location = New System.Drawing.Point(5, 124)
      Me.dgvConceptosSueldo.Name = "dgvConceptosSueldo"
      Me.dgvConceptosSueldo.Size = New System.Drawing.Size(602, 294)
      Me.dgvConceptosSueldo.TabIndex = 2
      Me.dgvConceptosSueldo.Text = "Conceptos de Sueldo"
      '
      'ConceptosPersonalBindingSource
      '
      Me.ConceptosPersonalBindingSource.DataMember = "ConceptosPersonal"
      Me.ConceptosPersonalBindingSource.DataSource = Me.DataSetSueldos
      '
      'GrillaPagosRecibosBindingSource
      '
      Me.GrillaPagosRecibosBindingSource.DataMember = "ConceptosPersonal"
      Me.GrillaPagosRecibosBindingSource.DataSource = Me.DataSetSueldos
      '
      'GeneraCuotasBindingSource
      '
      Me.GeneraCuotasBindingSource.DataMember = "ConceptosPersonal"
      Me.GeneraCuotasBindingSource.DataSource = Me.DataSetSueldos
      '
      'PersonalBindingSource
      '
      Me.PersonalBindingSource.DataMember = "Personal"
      Me.PersonalBindingSource.DataSource = Me.DataSetSueldos
      '
      'DataSetSueldosBindingSource
      '
      Me.DataSetSueldosBindingSource.DataSource = Me.DataSetSueldos
      Me.DataSetSueldosBindingSource.Position = 0
      '
      'SueldosConceptosMasivo
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1073, 472)
      Me.Controls.Add(Me.spcAsinacionDeConceptos)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.tstBarra)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Name = "SueldosConceptosMasivo"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Asignacion de Conceptos Masivo"
      Me.tstBarra.ResumeLayout(False)
      Me.tstBarra.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.grpConceptos.ResumeLayout(False)
      Me.grpConceptos.PerformLayout()
      Me.grpModalidad.ResumeLayout(False)
      Me.grpModalidad.PerformLayout()
      Me.spcAsinacionDeConceptos.Panel1.ResumeLayout(False)
      Me.spcAsinacionDeConceptos.Panel1.PerformLayout()
      Me.spcAsinacionDeConceptos.Panel2.ResumeLayout(False)
      CType(Me.spcAsinacionDeConceptos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spcAsinacionDeConceptos.ResumeLayout(False)
      CType(Me.ugvPersonal, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PersonalBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataSetSueldos, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvConceptosSueldo, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ConceptosPersonalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.GrillaPagosRecibosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.GeneraCuotasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PersonalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataSetSueldosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents imgIconos As System.Windows.Forms.ImageList
   Public WithEvents tstBarra As System.Windows.Forms.ToolStrip
   Public WithEvents tsbSalir As System.Windows.Forms.ToolStripButton
   Public WithEvents tsbRefrescar As System.Windows.Forms.ToolStripButton
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents tssRegistros As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents GeneraCuotasBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataSetSueldos As Eniac.Win.DataSetSueldos
   Friend WithEvents GrillaPagosRecibosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents tsbGrabar As System.Windows.Forms.ToolStripButton
   Private WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents btnAsignarConcepto As Eniac.Controles.Button
   Friend WithEvents txtValorConcepto As Eniac.Controles.TextBox
   Friend WithEvents btnBorrarConceptoSueldo As Eniac.Controles.Button
   Friend WithEvents TipoDocSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NroDocSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreSocioDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents PeriodoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobanteDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobanteDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents FechaDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents Periodo2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IdTipoComprobante2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NumeroComprobante2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents NombreCategoriaSocioDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SaldoDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ImporteTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ObservacionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents lblCodigoConcepto As Eniac.Controles.Label
   Friend WithEvents lblNombreConcepto As Eniac.Controles.Label
   Friend WithEvents bscCodigoConcepto As Eniac.Controles.Buscador
   Friend WithEvents bscNombreConcepto As Eniac.Controles.Buscador
   Friend WithEvents lblTipoConcepto As Eniac.Controles.Label
   Friend WithEvents Label10 As Eniac.Controles.Label
   Friend WithEvents Label12 As Eniac.Controles.Label
   Friend WithEvents lblModalidad As Eniac.Controles.Label
   Friend WithEvents grpConceptos As System.Windows.Forms.GroupBox
   Friend WithEvents lblValorConcepto As Eniac.Controles.Label
   Friend WithEvents Label14 As Eniac.Controles.Label
   Friend WithEvents lblNormal_o_Aguianaldo As Eniac.Controles.Label
   Friend WithEvents grpModalidad As System.Windows.Forms.GroupBox
   Friend WithEvents RadioModoAguinaldo As System.Windows.Forms.RadioButton
   Friend WithEvents RadioModoNormal As System.Windows.Forms.RadioButton
   Friend WithEvents txtPeriodosLiquidar As Eniac.Controles.TextBox
   Friend WithEvents Label4 As Eniac.Controles.Label
   Friend WithEvents spcAsinacionDeConceptos As System.Windows.Forms.SplitContainer
   Friend WithEvents ugvPersonal As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbTipoRecibo As Eniac.Controles.ComboBox
   Friend WithEvents lblTipoRecibo As Eniac.Controles.Label
   Friend WithEvents dgvConceptosSueldo As Infragistics.Win.UltraWinGrid.UltraGrid
   Friend WithEvents cmbEstadoCivil As Eniac.Controles.ComboBox
   Friend WithEvents chbEstadoCivil As Eniac.Controles.CheckBox
   Friend WithEvents PersonalBindingSource1 As System.Windows.Forms.BindingSource
   Friend WithEvents PersonalBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents DataSetSueldosBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ConceptosPersonalBindingSource As System.Windows.Forms.BindingSource
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents cmbLugarActividad As Eniac.Controles.ComboBox
   Friend WithEvents chbLugarActividad As Eniac.Controles.CheckBox
   Friend WithEvents tsbEliminarConceptosMasivo As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents chbPersonalSeleccionarTodos As Eniac.Controles.CheckBox
   Friend WithEvents btnLimpiar As Eniac.Controles.Button
End Class
