Public Class SucursalesDetalle

   Private Const funcionParaLimpiar As String = "Sucursales-LimpiaSucursal"
   Private Const funcionPadreParaLimpiar As String = "Sucursales"

   Private ReadOnly Property Sucursal As Entidades.Sucursal
      Get
         Return DirectCast(_entidad, Entidades.Sucursal)
      End Get
   End Property

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Sucursal)
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

         _publicos.CargaComboLocalidades(cmbLocalidad)
         _publicos.CargaComboLocalidades(cmbLocalidadComercial)

         _publicos.CargaComboSucursales(cmbSucursalAsociadaPrecios)

         _publicos.CargaComboFormasDePago(cmbFormaDePago)

         _publicos.CargaComboEmpresas(cmbEmpresa)

         ' # Cargo y formateo la grilla de Formas de Pago de la sucursal
         CargarGrillaFormasDePago()

         _liSources.Add("Localidad", Sucursal.Localidad)
         _liSources.Add("LocalidadComercial", Sucursal.LocalidadComercial)

         BindearControles(Me._entidad, Me._liSources)

         Sucursal.LogoSucursal = GetLogo(Sucursal)
         Sucursal.Usuario = actual.Nombre

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoNumero()
            cmbLocalidad.SelectedValue = actual.Sucursal.Localidad.IdLocalidad
            cmbLocalidadComercial.SelectedValue = actual.Sucursal.LocalidadComercial.IdLocalidad

            cmbEmpresa.SelectedValue = actual.Sucursal.IdEmpresa

            Me.dtpFechaInicioActiv.Value = Date.Now
         Else
            'chbAsociaSucursal.Checked = cmbSucursales.SelectedIndex >= 0
            chbSucursalAsociadaPrecios.Checked = cmbSucursalAsociadaPrecios.SelectedIndex >= 0
            If Sucursal.ColorSucursal <> 0 Then
               txtColor.BackColor = System.Drawing.Color.FromArgb(Sucursal.ColorSucursal)
            End If

            pcbFoto.Image = Sucursal.LogoSucursal

            If pcbFoto.Image IsNot Nothing Then
               Using ms = New IO.MemoryStream()
                  pcbFoto.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                  MostrarTamano(ms.Length)
               End Using
            Else
               MostrarTamano(0)
            End If

         End If

         cmbEmpresa.Visible = New Reglas.Empresas().Count() > 1
         lblEmpresa.Visible = cmbEmpresa.Visible

         Dim oUsuario = New Reglas.Usuarios()
         Dim tienePermisosParaLimpiar = oUsuario.TienePermisos(funcionParaLimpiar)
         btnLimpiarSucursal.Enabled = tienePermisosParaLimpiar
      End Sub)

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Sucursales
   End Function

   Protected Overrides Sub Aceptar()
      'la imagen no está bindeada
      Sucursal.LogoSucursal = Me.pcbFoto.Image

      '# Cargo las Formas de Pago en la entidad
      If Me.ugFormasDePago.Rows.Count > 0 Then
         CargarFormasDePagoEnEntidad()
      End If

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      'Dim vacio As String = ""

      'If Me.chbAsociaSucursal.Checked And Me.cmbSucursales.SelectedIndex = -1 Then
      '   Me.cmbSucursales.Focus()
      '   Return "ATENCION: Activo la Sucursal Asociada. Debe elegir una."
      'End If

      'If cmbSucursales.SelectedValue IsNot Nothing AndAlso Me.cmbSucursales.SelectedValue.Equals(Integer.Parse(Me.txtIdSucursal.Text)) Then
      '   Me.cmbSucursales.Focus()
      '   Return "ATENCION: No puede elegir la misma sucursal que la activa."
      'End If

      If txtDireccionComercial.Text = "" Then
         txtDireccionComercial.Text = txtDireccion.Text
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"
   Private Sub btnBuscarImagen_Click(sender As Object, e As EventArgs) Handles btnBuscarImagen.Click
      TryCatched(
      Sub()
         If ofdArchivos.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim nombrearchivo = ofdArchivos.FileName
            If Not String.IsNullOrEmpty(nombrearchivo) Then
               Dim fileInfo = New IO.FileInfo(nombrearchivo)
               If fileInfo.Length > Reglas.Publicos.TamañoMaximoImagenes Then
                  ShowMessage(String.Format("El archivo seleccionado tiene un tamaño ({0}) que excede el tamaño máximo permitido ({1}).",
                                               Publicos.GetTamanioArchivoFormateado(fileInfo.Length),
                                               Publicos.GetTamanioArchivoFormateado(Reglas.Publicos.TamañoMaximoImagenes)))
               Else
                  pcbFoto.Image = New Bitmap(nombrearchivo)
                  MostrarTamano(fileInfo.Length)
               End If
            End If
         End If
      End Sub)
   End Sub
   Private Sub MostrarTamano(tamano As Decimal)
      lblTamano.Text = String.Format("{0} {1}", "Tamaño Bytes Image : ", Publicos.GetTamanioArchivoFormateado(tamano))
   End Sub
   Private Sub btnLimpiarImagen_Click(sender As Object, e As EventArgs) Handles btnLimpiarImagen.Click
      TryCatched(Sub() pcbFoto.Image = Nothing)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
      Sub()

         If StateForm = Eniac.Win.StateForm.Insertar And Not HayError Then
            'Me.CargarProximoNumero()
            'Me.cmbLocalidad.SelectedIndex = -1
            'Me.chbAsociaSucursal.Checked = False
            Close()
         End If
         txtIdSucursal.Focus()
      End Sub)
   End Sub

   'Private Sub chbAsociaSucursal_CheckedChanged(sender As Object, e As EventArgs)

   '   If Not Me.chbAsociaSucursal.Checked Then
   '      Me.cmbSucursales.SelectedIndex = -1
   '      Sucursal.IdSucursalAsociada = 0
   '   End If

   '   Me.cmbSucursales.Enabled = Me.chbAsociaSucursal.Checked

   'End Sub

   Private Sub chbSucursalAsociadaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbSucursalAsociadaPrecios.CheckedChanged
      TryCatched(
      Sub()
         If Not chbSucursalAsociadaPrecios.Checked Then
            cmbSucursalAsociadaPrecios.SelectedIndex = -1
            Sucursal.IdSucursalAsociadaPrecios = 0
         End If
         cmbSucursalAsociadaPrecios.Enabled = chbSucursalAsociadaPrecios.Checked
      End Sub)
   End Sub

   Private Sub btnColorSucursal_Click(sender As Object, e As EventArgs) Handles btnColorSucursal.Click
      TryCatched(
      Sub()
         ColorDialog1.Color = txtColor.BackColor
         If ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtColor.Key = ColorDialog1.Color.ToArgb().ToString()
            Sucursal.ColorSucursal = ColorDialog1.Color.ToArgb()
            txtColor.BackColor = ColorDialog1.Color
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarFormasDePagoEnEntidad()
      TryCatched(
      Sub()
         '# Valido que no se haya cambiado el Código de Sucursal luego de haber agregado las Formas de Pago. De ser así, actualizo el IdSucursal.
         Dim lista As List(Of Entidades.VentasFormasPagoSucursales) = DirectCast(Me.ugFormasDePago.DataSource, List(Of Entidades.VentasFormasPagoSucursales))
         For Each ent As Entidades.VentasFormasPagoSucursales In lista
            ent.IdSucursal = If(Integer.Parse(Me.txtIdSucursal.Text) <> ent.IdSucursal, Integer.Parse(Me.txtIdSucursal.Text), ent.IdSucursal)
         Next

         '# Set
         DirectCast(_entidad, Entidades.Sucursal).FormasDePago = lista
      End Sub)
   End Sub

   Private Function GetFormaDePagoSeleccionada() As Entidades.VentasFormasPagoSucursales

      If ugFormasDePago.ActiveRow IsNot Nothing AndAlso
         ugFormasDePago.ActiveRow.ListObject IsNot Nothing AndAlso
         TypeOf (ugFormasDePago.ActiveRow.ListObject) Is Entidades.VentasFormasPagoSucursales Then
         Return DirectCast(ugFormasDePago.ActiveRow.ListObject, Entidades.VentasFormasPagoSucursales)
      End If
      Return Nothing

   End Function

   Private Sub CargarGrillaFormasDePago()

      ' # Al crear una nueva sucursal, la grilla se completa con todas las FP.
      ' # Al modificar una sucursal, la grilla se completa con los valores de BD.
      If StateForm = Win.StateForm.Insertar Then
         Dim rVentasFormasPago As Reglas.VentasFormasPago = New Reglas.VentasFormasPago
         Dim listaFP As List(Of Entidades.VentaFormaPago) = rVentasFormasPago.GetTodasOrdenadas()
         Dim listaFPS As List(Of Entidades.VentasFormasPagoSucursales) = New List(Of Entidades.VentasFormasPagoSucursales)

         For Each fp As Entidades.VentaFormaPago In listaFP
            Dim eVFP As Entidades.VentasFormasPagoSucursales = New Entidades.VentasFormasPagoSucursales

            eVFP.IdSucursal = Integer.Parse(Me.txtIdSucursal.Text)
            eVFP.IdFormasPago = fp.IdFormasPago
            eVFP.DescripcionFormasPago = fp.DescripcionFormasPago
            eVFP.OrdenCompras = fp.OrdenCompras
            eVFP.OrdenVentas = fp.OrdenVentas
            eVFP.OrdenFichas = fp.OrdenFichas

            listaFPS.Add(eVFP)
         Next
         Sucursal.FormasDePago = listaFPS
      End If

      ' # Cargo la grilla
      ugFormasDePago.DataSource = Sucursal.FormasDePago

      ' # Formateo a la grilla
      For Each col As UltraGridColumn In Me.ugFormasDePago.DisplayLayout.Bands(0).Columns
         col.Hidden = True
         ' # Solo Descripción y Código visibles
         If col.Key = Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString() Or
            col.Key = Entidades.VentaFormaPago.Columnas.IdFormasPago.ToString() Or
            col.Key.StartsWith("Orden") Then
            col.Hidden = False
         End If
      Next

      ' # Se agrega filto en linea
      Me.ugFormasDePago.AgregarFiltroEnLinea({"DescripcionFormasPago"})

   End Sub


   Private Sub CargarProximoNumero()
      Dim oSucursales As Reglas.Sucursales = New Reglas.Sucursales()
      Me.txtIdSucursal.Text = (oSucursales.GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Function GetLogo(sucursal As Entidades.Sucursal) As System.Drawing.Image
      Dim oSucursales As Reglas.Sucursales = New Reglas.Sucursales()
      Dim logo As System.Drawing.Image
      Try
         logo = oSucursales.GetUna(sucursal.IdSucursal, True).LogoSucursal
      Catch ex As Exception
         Return Nothing
      End Try
      Return logo
   End Function

#End Region

   Private Sub btnLimpiarSucursal_Click(sender As Object, e As EventArgs) Handles btnLimpiarSucursal.Click
      TryCatched(
      Sub()
         If BaseSeguridad.ControloPermisos(actual.Sucursal.Id, Ayudantes.Common.usuario + New String("x"c, 50), funcionParaLimpiar, funcionPadreParaLimpiar) Then
            If ShowPregunta(String.Format("Está por limpiar toda la información de la sucursal {0} - {1}" + Environment.NewLine + Environment.NewLine +
                                          "¿Desea continuar con el proceso?", txtIdSucursal.Text, txtNombre.Text), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
               If ShowPregunta(String.Format("No es posible deshacer la operación de borrado de sucursal" + Environment.NewLine + Environment.NewLine +
                                             "¿Está seguro de proceder con la limpieza?"), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                  Dim rSucursales As Reglas.Sucursales = New Reglas.Sucursales()
                  rSucursales.EjecutaLimpiezaDeSucursales(Integer.Parse(txtIdSucursal.Text))
                  Close()
               End If
            End If
         Else
            ShowMessage("No posee permisos para Limpiar la Sucursal")
         End If
      End Sub)
   End Sub

   Private Sub btnAgregarFormaDePago_Click(sender As Object, e As EventArgs) Handles btnAgregarFormaDePago.Click
      TryCatched(
      Sub()
         If Me.cmbFormaDePago.SelectedIndex = -1 Then Exit Sub

         Dim idFormaDePago As Integer = Integer.Parse(Me.cmbFormaDePago.SelectedValue.ToString())
         Dim idSucursal As Integer = Integer.Parse(Me.txtIdSucursal.Text)

         ' # Si la forma de pago ya fue agregada a la grilla, salgo del método
         If Sucursal.FormasDePago IsNot Nothing Then
            If Sucursal.FormasDePago.Exists(Function(x) x.IdFormasPago = idFormaDePago) Then
               ShowMessage("Esta forma de pago ya fué agregada.")
               Me.cmbFormaDePago.Focus()
               Exit Sub
            End If
         End If

         ' # Agrego la FP a la grilla
         Dim rVentasFormasPago As Reglas.VentasFormasPago = New Reglas.VentasFormasPago
         Dim eVFP As Entidades.VentaFormaPago = rVentasFormasPago.GetUna(idFormaDePago)
         Sucursal.FormasDePago.Add(New Entidades.VentasFormasPagoSucursales() _
                                                                             With {.IdSucursal = idSucursal,
                                                                                   .IdFormasPago = idFormaDePago,
                                                                                   .DescripcionFormasPago = eVFP.DescripcionFormasPago,
                                                                                   .OrdenCompras = eVFP.OrdenCompras,
                                                                                   .OrdenVentas = eVFP.OrdenVentas,
                                                                                   .OrdenFichas = eVFP.OrdenFichas})
         ' # Blanqueo el combo
         Me.cmbFormaDePago.SelectedIndex = -1
         ugFormasDePago.Rows.Refresh(RefreshRow.ReloadData)
      End Sub)
   End Sub

   Private Sub btnEliminarFormaDePago_Click(sender As Object, e As EventArgs) Handles btnEliminarFormaDePago.Click
      TryCatched(
      Sub()
         If Me.ugFormasDePago.Rows.Count = 0 Then Exit Sub

         Dim formaDePago As Entidades.VentasFormasPagoSucursales = GetFormaDePagoSeleccionada()
         If formaDePago IsNot Nothing Then
            Sucursal.FormasDePago.Remove(formaDePago)
            ugFormasDePago.Rows.Refresh(RefreshRow.ReloadData)
         End If
      End Sub)
   End Sub

   Private Sub btnLimpiarFormaDePago_Click(sender As Object, e As EventArgs) Handles btnLimpiarFormaDePago.Click
      '# Limpio el combo de Forma de Pago
      TryCatched(Sub() cmbFormaDePago.SelectedIndex = -1)
   End Sub
End Class
