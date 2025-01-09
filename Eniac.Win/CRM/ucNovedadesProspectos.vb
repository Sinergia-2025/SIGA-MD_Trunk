Public Class ucNovedadesProspectos
#Region "Busqueda"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProspectos2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            Dim rClte = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Prospecto)
            bscCodigoCliente.Datos = rClte.GetFiltradoPorCodigo(codigoCliente, True, True)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProspectos2(bscCliente)
            Dim rClte = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Prospecto)
            bscCliente.Datos = rClte.GetFiltradoPorNombre(bscCliente.Text.Trim(), True)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta))
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCliente.Text = dr.Cells("NombreProspecto").Value.ToString()
         bscCodigoCliente.Text = dr.Cells("CodigoProspecto").Value.ToString().Trim()
         bscCodigoCliente.Tag = dr.Cells("IdProspecto").Value.ToString()

         txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()
         txtTelefonos.Text = (dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString()).Trim()
         txtCorreo.Text = dr.Cells("CorreoElectronico").Value.ToString()
         txtTipoCliente.Text = dr.Cells("NombreTipoCliente").Value.ToString()

         OnSelectedChanged(Nothing)
      End If
   End Sub
#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            '-- Seguridad --
            Dim rUsuario = New Reglas.Usuarios()
            'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
            llbCliente.Visible = rUsuario.TienePermisos("Clientes-PuedeUsarMasInfo")
         End Sub)
   End Sub

   Public Property IdProspectos() As Long
      Get
         Dim result As Long = 0
         If bscCodigoCliente.Tag IsNot Nothing AndAlso IsNumeric(bscCodigoCliente.Tag) Then
            result = Convert.ToInt64(bscCodigoCliente.Tag)
         End If
         Return result
      End Get
      Set(value As Long)
         Try
            If value > 0 Then
               bscCodigoCliente.Text = New Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Prospecto).GetUno(value).CodigoCliente.ToString()
               bscCodigoCliente.PresionarBoton()
            Else
               bscCodigoCliente.Text = String.Empty
               bscCliente.Text = String.Empty
            End If
            OnSelectedChanged(Nothing)
         Catch ex As Exception
            bscCodigoCliente.Text = String.Empty
            bscCliente.Text = String.Empty
            OnSelectedChanged(Nothing)
            FindForm().ShowMessage(String.Format("No se pudo recuperar el Prospecto: {0}", ex.Message))
         End Try
      End Set
   End Property

   Private Sub llbCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Dim PantCliente As ClientesDetalle = Nothing
      TryCatched(
         Sub()
            Dim clie = New Entidades.Cliente()

            If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
               Dim blnIncluirFoto As Boolean = True
               clie = New Eniac.Reglas.Clientes(Entidades.Cliente.ModoClienteProspecto.Prospecto).GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), blnIncluirFoto)
               clie.Usuario = actual.Nombre
               PantCliente = New ClientesDetalle(clie, Entidades.Cliente.ModoClienteProspecto.Prospecto)
               PantCliente.CierraAutomaticamente = True
               PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
            Else
               'PantCliente = New ClientesDetalle(New Entidades.Cliente())
               PantCliente = New ClientesDetalle(clie, Entidades.Cliente.ModoClienteProspecto.Prospecto)
               PantCliente.CierraAutomaticamente = True
               PantCliente.StateForm = Eniac.Win.StateForm.Insertar
            End If

            If PantCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Me.bscCodigoCliente.Text = PantCliente.txtCodigoCliente.Text
               'Me.bscCodigoCliente.Permitido = True
               Me.bscCodigoCliente.PresionarBoton()
               'Me.bscCodigoCliente.Permitido = False
            End If
         End Sub,
         onFinallyAction:=
         Sub()
            If PantCliente IsNot Nothing Then PantCliente.Dispose()
         End Sub)
   End Sub

End Class