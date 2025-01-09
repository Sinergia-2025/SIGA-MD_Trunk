Public Class TarjetasCuponesDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _permisoPlanillaDeCaja As Boolean = False
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.TarjetaCupon)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicos = New Publicos()

         '-- Carga Combo de Tarjetas de Credito.- --------
         _publicos.CargaComboTarjetas(cmbTarTarjeta)
         _publicos.CargaComboSituacion(cmbSituacionTarjetaCupones)
         '------------------------------------------------

         BindearControles(_entidad, _liSources)

         '-- Verifica si tienen permiso a Caja.- -------------------------
         Dim oUsuario = New Reglas.Usuarios()
         _permisoPlanillaDeCaja = oUsuario.TienePermisos("PlanillaDeCaja")
         '-- Deshabilita la solapa de Ingreso Caja.- -------
         tbc_TarjetasCupones.TabPages.Remove(tbpIngresoCaja)
         '--------------------------------------------------

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            txtEstadoActual.Text = "ALTA"
            '-- Verifica permiso a caja.- ---------------------
            If _permisoPlanillaDeCaja Then
               'TabControl1.TabPages.Add(tbpIngresoCaja)
               'btnIngresoPorCaja.Enabled = True
               'cmbCaja.Enabled = True
            End If
            '-- Posiciona el Cursor.- --
            bscCodigoCliente.Select()
            '---------------------------
            dtpFechaEmision.Value = Date.Today
            cmbSituacionTarjetaCupones.SelectedValue = New Reglas.SituacionCupones().GetPorDefecto().IdSituacionCupon
            '---------------------------------
         Else
            '-- Carga Banco existente.- -----
            bscTarBanco.Text = New Reglas.Bancos().GetUno(DirectCast(_entidad, Entidades.TarjetaCupon).IdBanco).NombreBanco
            bscTarBanco.PresionarBoton()
            '-- Carga Cliente existente.- -----
            bscCodigoCliente.Text = New Reglas.Clientes().GetUno(DirectCast(_entidad, Entidades.TarjetaCupon).IdCliente).CodigoCliente.ToString()
            bscCodigoCliente.PresionarBoton()
            '-- Posiciona el Cursor.- --------
            cmbSituacionTarjetaCupones.Focus()
            HabilitaDeshabilita(Me.StateForm = Eniac.Win.StateForm.Insertar)
            '---------------------------------
         End If
      Catch ex As Exception

      End Try
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TarjetasCupones()
   End Function
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            If Not HayError Then Close()
            bscCodigoCliente.Select()
         End Sub)
   End Sub

   Private Sub HabilitaDeshabilita(sEstado As Boolean)
      bscCodigoCliente.Enabled = sEstado
      bscCliente.Enabled = sEstado

      cmbTarTarjeta.Enabled = sEstado
      bscTarBanco.Enabled = sEstado

      txtNumeroLote.ReadOnly = Not sEstado
      txtNroCupon.ReadOnly = Not sEstado

      dtpFechaEmision.Enabled = sEstado

      txtTarMonto.ReadOnly = Not sEstado
      txtCuota.ReadOnly = Not sEstado
   End Sub

   Private Sub bscTarBanco_BuscadorClick() Handles bscTarBanco.BuscadorClick
      Try
         Me._publicos.PreparaGrillaBancos(Me.bscTarBanco)
         Dim oBanco As Eniac.Reglas.Bancos = New Eniac.Reglas.Bancos()
         Me.bscTarBanco.Datos = oBanco.GetFiltradoPorNombre(Me.bscTarBanco.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscTarBanco_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscTarBanco.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTarjetasBancos(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region

#Region "Metodos"
   Protected Overrides Sub Aceptar()
      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         With DirectCast(_entidad, Entidades.TarjetaCupon)
            .IdSucursal = actual.Sucursal.IdSucursal
            .IdTarjetaCupon = New Reglas.TarjetasCupones().GetCodigoMaximo
            .IdUsuarioActualizacion = actual.Nombre
            .FechaActualizacion = Date.Now
            If Not String.IsNullOrWhiteSpace(Me.bscCodigoCliente.Text) Then
               .IdCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
            Else
               .IdCliente = 0
            End If
            If Not String.IsNullOrWhiteSpace(Me.bscTarBanco.Text) Then
               .IdBanco = Integer.Parse(bscTarBanco.Tag.ToString())
            Else
               .IdBanco = 0
            End If
         End With
      End If
      MyBase.Aceptar()

   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      '-- Valida Cliente.- ------
      If Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
         bscCodigoCliente.Select()
         Return "No selecciono un Cliente."
      End If
      '-- Tarjeta.- ------------
      If cmbTarTarjeta.SelectedIndex = -1 Then
         cmbTarTarjeta.Focus()
         Return "ATENCIÓN: No seleccionó un Tipo de Tarjeta"
      End If
      '-- Valida Banco.- ------
      If Not bscTarBanco.Selecciono Then
         bscTarBanco.Select()
         Return "No selecciono un Banco."
      End If


      If txtTarMonto.ValorNumericoPorDefecto(0D) <= 0 Then
         txtTarMonto.Select()
         Return "El Importe del Cupón es inválido."
      End If
      If txtCuota.ValorNumericoPorDefecto(0D) <= 0 Then
         txtCuota.Select()
         Return "El Valor de la Cuota es inválido."
      End If
      Return vacio

   End Function
   Private Sub CargarDatosTarjetasBancos(dr As DataGridViewRow)
      Me.bscTarBanco.Text = dr.Cells("NombreBanco").Value.ToString()
      bscTarBanco.Tag = dr.Cells("IdBanco").Value.ToString()
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
   End Sub

#End Region
End Class