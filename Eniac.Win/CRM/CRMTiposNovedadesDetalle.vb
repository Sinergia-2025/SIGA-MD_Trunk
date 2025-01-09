Public Class CRMTiposNovedadesDetalle

   Private _publicos As Publicos

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Eniac.Entidades.CRMTipoNovedad)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

   Public ReadOnly Property TipoNovedad() As Entidades.CRMTipoNovedad
      Get
         Return DirectCast(_entidad, Entidades.CRMTipoNovedad)
      End Get
   End Property

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
      Sub()
         _publicos = New Publicos()

         CargaComboDinamicos(cmbDinamicos)
         ugDinamicos.DataSource = TipoNovedad.Dinamicos
         _publicos.CargaComboDesdeEnum(cmbPrimerOrdenGrilla, GetType(Entidades.CRMNovedad.ColInformeDeNovedades), , True)
         _publicos.CargaComboDesdeEnum(cmbSegundoOrdenGrilla, GetType(Entidades.CRMNovedad.ColInformeDeNovedades), , True)
         _publicos.CargaComboDesdeEnum(cmbSolapaPorDefecto, GetType(Entidades.CRMTipoNovedad.SolapaPorDef), , , hideBrowsable:=Not Reglas.Publicos.ExtrasSinergia)

         _publicos.CargaComboDesdeEnum(cmbVisualizaSucursal, GetType(Entidades.CRMTipoNovedad.ColVisualizaSucursalNovedades), , True)

         BindearControles(_entidad, _liSources)

         If StateForm = Win.StateForm.Insertar Then
            txtCantidadCopias.Text = "1"
         End If

         If String.IsNullOrWhiteSpace(TipoNovedad.SegundoOrdenGrilla) Then
            chbUsaSegundoOrden.Checked = False
            cmbSegundoOrdenGrilla.Enabled = False
            chbSegundoOrdenDesc.Enabled = False
         Else
            chbUsaSegundoOrden.Checked = True
            cmbSegundoOrdenGrilla.Enabled = True
            chbSegundoOrdenDesc.Enabled = True
         End If
      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CRMTiposNovedades()
   End Function
   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()

      If Not HayError And StateForm = Eniac.Win.StateForm.Insertar Then
         Close()
      End If
   End Sub
   Protected Overrides Function ValidarDetalle() As String
      Dim vacio = String.Empty

      If chbUsaSegundoOrden.Checked Then
         If String.IsNullOrWhiteSpace(TipoNovedad.SegundoOrdenGrilla) Then
            cmbSegundoOrdenGrilla.Focus()
            Return "ATENCION: No ingreso un Segundo Orden aunque activó ese Filtro. "
         End If
      End If
      If chbUsaSegundoOrden.Checked Then
         If TipoNovedad.SegundoOrdenGrilla = TipoNovedad.PrimerOrdenGrilla Then
            cmbSegundoOrdenGrilla.Focus()
            Return "ATENCION: El Segundo Orden debe ser distinto del Primer Orden. "
         End If
      End If

      Return vacio
   End Function
#End Region

#Region "Eventos"
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
      Sub()
         If Not IsNumeric(txtOrden.Text) Then
            txtOrden.Text = "1"
         End If
         If cmbDinamicos.SelectedItem IsNot Nothing Then
            For Each dinActual In TipoNovedad.Dinamicos
               If dinActual.IdNombreDinamico = cmbDinamicos.SelectedItem.ToString() Then
                  Throw New Exception("El dinámico seleccionado ya se encuentra en la colección.")
               End If
            Next

            Dim dinNuevo = New Entidades.CRMTipoNovedadDinamico()
            dinNuevo.IdNombreDinamico = cmbDinamicos.SelectedItem.ToString()
            dinNuevo.Orden = Integer.Parse(txtOrden.Text)
            dinNuevo.EsRequerido = chbRequerido.Checked

            TipoNovedad.Dinamicos.Add(dinNuevo)
            ugDinamicos.Rows.Refresh(RefreshRow.ReloadData)
            cmbDinamicos.SelectedIndex = -1
            txtOrden.Text = (dinNuevo.Orden + 1).ToString()
            cmbDinamicos.Focus()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(
      Sub()
         Dim row = ugDinamicos.FilaSeleccionada(Of Entidades.CRMTipoNovedadDinamico)()
         If row IsNot Nothing Then
            If ShowPregunta("¿Desea eliminar el registro seleccionado?") = Windows.Forms.DialogResult.Yes Then
               TipoNovedad.Dinamicos.Remove(row)
               ugDinamicos.Rows.Refresh(RefreshRow.ReloadData)
               cmbDinamicos.Focus()
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugDinamicos_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugDinamicos.DoubleClickRow
      TryCatched(
      Sub()
         Dim row = ugDinamicos.FilaSeleccionada(Of Entidades.CRMTipoNovedadDinamico)()
         If row IsNot Nothing Then
            cmbDinamicos.SelectedItem = row.IdNombreDinamico
            txtOrden.Text = row.Orden.ToString()
            chbRequerido.Checked = row.EsRequerido
            TipoNovedad.Dinamicos.Remove(row)
            ugDinamicos.Rows.Refresh(RefreshRow.ReloadData)
            cmbDinamicos.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chbUsaSegundoOrden_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsaSegundoOrden.CheckedChanged
      TryCatched(
      Sub()
         cmbSegundoOrdenGrilla.Enabled = chbUsaSegundoOrden.Checked
         chbSegundoOrdenDesc.Enabled = chbUsaSegundoOrden.Checked
         If Not chbUsaSegundoOrden.Checked Then
            cmbSegundoOrdenGrilla.SelectedIndex = -1
         End If
      End Sub)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargaComboDinamicos(cmb As Eniac.Controles.ComboBox)
      cmb.DataSource = ArmaListaParaComboDinamicos()
      cmb.SelectedIndex = -1
   End Sub
   Protected Overridable Function ArmaListaParaComboDinamicos() As List(Of String)
      Dim lista = New List(Of String) From {
         Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES.ToString(),
         Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS.ToString(),
         Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES.ToString(),
         Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO.ToString(),
         Entidades.CRMTipoNovedad.TipoDinamico.PRODUCTOS.ToString(),
         Entidades.CRMTipoNovedad.TipoDinamico.OBSERVACION.ToString()
      }
      If New Reglas.Funciones().ExisteFuncion("CRMNovedadesABMSERVICE") Then
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.SERVICE.ToString())
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.SERVICELUGARCOMPRA.ToString())
      End If
      If Reglas.Publicos.ExtrasSinergia Then
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES.ToString())
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS.ToString())
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.PROYECTOS.ToString())
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION.ToString())
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.MOTIVOS.ToString())
         lista.Add(Entidades.CRMTipoNovedad.TipoDinamico.APLICACIONTERCERO.ToString())
      End If
      Return lista
   End Function
#End Region
End Class