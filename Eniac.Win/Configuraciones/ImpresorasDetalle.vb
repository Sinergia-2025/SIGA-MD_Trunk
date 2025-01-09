Public Class ImpresorasDetalle

#Region "Campos"

   Private ReadOnly Property Impresora As Entidades.Impresora
      Get
         Return DirectCast(_entidad, Entidades.Impresora)
      End Get
   End Property
   Private ReadOnly Property Comprobantes As IEnumerable(Of TipoComprobanteSelect)
      Get
         Return If(TypeOf (ugComprobantes.DataSource) Is IEnumerable(Of TipoComprobanteSelect), DirectCast(ugComprobantes.DataSource, IEnumerable(Of TipoComprobanteSelect)), {})
      End Get
   End Property

   Private _estaCargando As Boolean = True
   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.Impresora)
      Me.New()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         tbcImpresora.SelectedTab = tbpDireccion
         tbcImpresora.SelectedTab = tbpFiscal
         tbcImpresora.SelectedTab = tbpGeneral

         CargarComprobantesHabilitados()
         CargarCombos()

         _publicos.CargaComboLocalidades(cmbLocalidadCentroEmisor)

         _liSources.Add("LocalidadCentroEmisor", Impresora.LocalidadCentroEmisor)

         BindearControles(_entidad, _liSources)

         _estaCargando = False

         If StateForm = Win.StateForm.Actualizar Then
            CargarCampos()

            txtCentroEmisor.Enabled = False
            If (cmbTipoImpresora.Text = "FISCAL") Then
               If Not New Reglas.Impresoras().CentroEmisorEnUso(Impresora.CentroEmisor) Then
                  txtCentroEmisor.Enabled = True
               End If
            End If

         End If

         If (cmbTipoImpresora.Text = "FISCAL") Then
            If Not tbcImpresora.TabPages.Contains(tbpFiscal) Then
               tbcImpresora.TabPages.Add(tbpFiscal)
            End If
         Else
            If tbcImpresora.TabPages.Contains(tbpFiscal) Then
               tbcImpresora.TabPages.Remove(tbpFiscal)
            End If
         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Impresoras()
   End Function

   Protected Overrides Sub Aceptar()
      ugComprobantes.UpdateData()

      If ValidarDatos() Then

         Dim valores(Me.clbPCs.Items.Count - 1) As String
         Dim i As Integer = 0
         For Each pc In clbPCs.Items.OfType(Of String)
            valores(i) = pc
            i += 1
         Next
         Impresora.PCs = valores

         Dim cmp = String.Join(",", Comprobantes.Where(Function(x) x.Selec).ToList().ConvertAll(Function(x) x.IdTipoComprobante))
         Impresora.ComprobantesHabilitados = cmp

         Impresora.IdSucursal = actual.Sucursal.Id

         MyBase.Aceptar()

         If Not HayError Then Close()

      End If

   End Sub

   Private Function ValidarDatos() As Boolean

      If Short.Parse(txtCentroEmisor.Text) = 0 Then
         ShowMessage("Debe indicar el Emisor de la Impresora.")
         Return False
      End If

      If Not Comprobantes.Any(Function(tc) tc.Selec) Then
         ShowMessage("Debe cargar al menos un comprobante.")
         Return False
      End If

      If tbcImpresora.TabPages.Contains(tbpFiscal) Then
         If cboMetodo.ValorSeleccionado(Of Entidades.Impresora.MetodosFiscal)() <> Entidades.Impresora.MetodosFiscal.BATCH Then

            'HASAR: SMH/P-330F, SMH/P-441F, SMH/P-715F, SMH/P-715Fv1, SMH/P-250F2g
            'EPSON: TM-U950F, TM-U220AF, TM-U2000AF, TM-U2002AF+, LX-300F+., TM-900AF"

            If (cboMarca.Text = "HASAR" And (txtModelo.Text <> "SMH/P-330F" And txtModelo.Text <> "SMH/P-441F" And txtModelo.Text <> "SMH/P-715F" And txtModelo.Text <> "SMH/P-715Fv1" And txtModelo.Text <> "SMH/P-250F2g")) Or
               (cboMarca.Text = "EPSON" And (txtModelo.Text <> "TM-U220AF" And txtModelo.Text <> "TM-U220AFII" And txtModelo.Text <> "TM-U2000AF" And txtModelo.Text <> "TM-U2000AF+" And txtModelo.Text <> "TM-U2002AF+" And txtModelo.Text <> "TM-U950F" And txtModelo.Text <> "LX-300F+" And txtModelo.Text <> "TM-900AF")) Then

               ShowMessage(String.Format("ATENCION: En la Marca elegida los unicos Modelos habilitados son: {0}{0}{1}", Environment.NewLine,
                                         If(cboMarca.Text = "HASAR",
                                            "SMH/P-330F, SMH/P-441F, SMH/P-715F, SMH/P-715Fv1 o SMH/P-250F2g ",
                                            "TM-U220AF, TM-U220AFII, TM-U2000AF, TM-U2000AF+, TM-U2002AF,  TM-U950F o LX-300F+., TM-900AF")))
               Return False
            End If

         End If
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub cmbTipoImpresora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoImpresora.SelectedIndexChanged
      If _estaCargando Then Exit Sub
      Dim blnSolicita = (cmbTipoImpresora.Text = "FISCAL")

      txtPuerto.IsRequired = blnSolicita
      txtVelocidad.IsRequired = blnSolicita
      txtTipoFormulario.IsRequired = blnSolicita
      txtCantidadCopias.IsRequired = blnSolicita
      txtTamanioLetra.IsRequired = blnSolicita
      cboMarca.IsRequired = blnSolicita
      txtModelo.IsRequired = blnSolicita
      txtOrigenPapel.IsRequired = blnSolicita
      cboMetodo.IsRequired = blnSolicita

      If blnSolicita Then
         If Not tbcImpresora.TabPages.Contains(tbpFiscal) Then
            tbcImpresora.TabPages.Add(tbpFiscal)
         End If
      Else
         If tbcImpresora.TabPages.Contains(tbpFiscal) Then
            tbcImpresora.TabPages.Remove(tbpFiscal)
         End If
      End If
   End Sub

   Private Sub txtTipoFormulario_Leave(sender As Object, e As EventArgs) Handles txtTipoFormulario.Leave
      TryCatched(Sub() txtTipoFormulario.Text = txtTipoFormulario.Text.ToUpper())
   End Sub
   Private Sub txtOrigenPapel_Leave(sender As Object, e As EventArgs) Handles txtOrigenPapel.Leave
      TryCatched(Sub() txtOrigenPapel.Text = txtOrigenPapel.Text.ToUpper())
   End Sub

   Private Sub btnAgregarPC_Click(sender As Object, e As EventArgs) Handles btnAgregarPC.Click
      TryCatched(
      Sub()
         If txtPCs.Text.Trim().Length > 0 Then
            If ExisteLaPC(txtPCs.Text.Trim()) Then
               ShowMessage("Ya existe la PC para esta impresora.")
            Else
               clbPCs.Items.Add(txtPCs.Text.Trim())
               txtPCs.Text = ""
            End If
         End If
         txtPCs.Focus()
      End Sub)
   End Sub

   Private Sub btnEliminarPC_Click(sender As Object, e As EventArgs) Handles btnEliminarPC.Click
      TryCatched(
      Sub()
         If clbPCs.SelectedIndex <> -1 Then
            clbPCs.Items.RemoveAt(clbPCs.SelectedIndex)
         End If
         txtPCs.Focus()
      End Sub)
   End Sub

   Private Sub AgregarPCActualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarPCActualToolStripMenuItem.Click
      TryCatched(
      Sub()
         txtPCs.Text = Environment.MachineName
         btnAgregarPC_Click(sender, e)
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarCampos()
      'cargo los comprobantes
      For Each c In Impresora.ComprobantesHabilitados.Split(","c)
         Comprobantes.Where(Function(tp) tp.IdTipoComprobante = c).All(Function(tp)
                                                                          tp.Selec = True
                                                                          Return True
                                                                       End Function)
      Next

      'cargo las PCs
      For Each val As String In Impresora.PCs
         Me.clbPCs.Items.Add(val)
      Next

      If (Me.cmbTipoImpresora.Text = "FISCAL") Then
         If Not tbcImpresora.TabPages.Contains(tbpFiscal) Then
            tbcImpresora.TabPages.Add(tbpFiscal)
         End If
      Else
         If tbcImpresora.TabPages.Contains(tbpFiscal) Then
            tbcImpresora.TabPages.Remove(tbpFiscal)
         End If
      End If

   End Sub

   Private Sub CargarComprobantesHabilitados()
      Dim tipos = New Reglas.TiposComprobantes().GetTodos()
      ugComprobantes.DataSource = tipos.ConvertAll(Function(tc) New TipoComprobanteSelect(tc)).ToArray()
      ugComprobantes.AgregarFiltroEnLinea({"IdTipoComprobante", "Descripcion"})
   End Sub

   Private Sub CargarCombos()

      'Tipos de Impresoras
      Dim dt = New DataTable()
      dt.Columns.Add(New DataColumn("Tipo", GetType(String)))
      Dim dr As DataRow

      dr = dt.NewRow()
      dr("Tipo") = "NORMAL"
      dt.Rows.Add(dr)

      dr = dt.NewRow()
      dr("Tipo") = "FISCAL"
      dt.Rows.Add(dr)

      cmbTipoImpresora.DataSource = dt
      cmbTipoImpresora.DisplayMember = "Tipo"
      cmbTipoImpresora.ValueMember = "Tipo"

      'Marcas

      'Dim aMarca As ArrayList = New ArrayList
      'aMarca.Insert(0, "EPSON")
      'aMarca.Insert(1, "HASAR")
      'Me.cboMarca.DataSource = aMarca

      'Dim dt As DataTable = New DataTable()
      dt = New DataTable()
      dt.Columns.Add(New DataColumn("Marca", GetType(String)))
      'Dim dr As DataRow

      dr = dt.NewRow()
      dr("Marca") = "EPSON"
      dt.Rows.Add(dr)

      dr = dt.NewRow()
      dr("Marca") = "HASAR"
      dt.Rows.Add(dr)

      cboMarca.DataSource = dt
      cboMarca.DisplayMember = "Marca"
      cboMarca.ValueMember = "Marca"

      'Metodos
      _publicos.CargaComboDesdeEnum(cboMetodo, GetType(Entidades.Impresora.MetodosFiscal))

   End Sub

   Private Function ExisteLaPC(pc As String) As Boolean
      For Each pc In clbPCs.Items.OfType(Of String)
         If pc.Trim() = pc.Trim() Then
            Return True
         End If
      Next
      Return False
   End Function

#End Region


#Region "Clases Privadas"
   Private Class TipoComprobanteSelect
      Public Property Selec As Boolean
      Public ReadOnly Property IdTipoComprobante As String
         Get
            Return If(TipoComprobante IsNot Nothing, TipoComprobante.IdTipoComprobante, String.Empty)
         End Get
      End Property
      Public ReadOnly Property Descripcion As String
         Get
            Return If(TipoComprobante IsNot Nothing, TipoComprobante.Descripcion, String.Empty)
         End Get
      End Property
      Public ReadOnly Property EsFiscal As Boolean
         Get
            Return If(TipoComprobante IsNot Nothing, TipoComprobante.EsFiscal, False)
         End Get
      End Property
      Public ReadOnly Property Tipo As String
         Get
            Return If(TipoComprobante IsNot Nothing, TipoComprobante.Tipo, String.Empty)
         End Get
      End Property
      Public ReadOnly Property Grupo As String
         Get
            Return If(TipoComprobante IsNot Nothing, TipoComprobante.Grupo, String.Empty)
         End Get
      End Property
      Public Property TipoComprobante As Entidades.TipoComprobante

      Public Sub New(tipoComprobante As Entidades.TipoComprobante)
         Me.TipoComprobante = tipoComprobante
      End Sub

   End Class
#End Region

End Class