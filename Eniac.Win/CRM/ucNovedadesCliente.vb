Public Class ucNovedadesCliente

#Region "Busqueda"
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick

      Dim codigoCliente As Long = -1
      Try
         Me.Cursor = Cursors.WaitCursor
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
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
   Private Sub bscCodigoCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
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
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub bscCliente_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         Me.Cursor = Cursors.WaitCursor
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub CargarDatosCliente(ByVal dr As DataGridViewRow)

      Me.bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString().Trim()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()

      Me.txtCategoria.Text = dr.Cells("NombreCategoria").Value.ToString()

      Me.txtCategoria.SetColor(dr)

      Me.txtTelefonos.Text = Strings.Trim(dr.Cells("Telefono").Value.ToString() & " " & dr.Cells("Celular").Value.ToString())
      Me.txtCorreo.Text = dr.Cells("CorreoElectronico").Value.ToString()
      If Me.chbRevisionAdministrativa.Visible Then
         If Me.StateForm = Win.StateForm.Insertar Then
            Me.chbRevisionAdministrativa.Checked = Boolean.Parse(dr.Cells("RequiereRevisionAdministrativa").Value.ToString())
         End If
      End If

      If Novedad IsNot Nothing AndAlso Novedad.ClienteValorizacionEstrellas.HasValue Then
         txtValorizacionEstrellas.Text = Novedad.ClienteValorizacionEstrellas.Value.ToString()
      Else
         txtValorizacionEstrellas.Text = dr.Cells("ValorizacionEstrellas").Value.ToString()
      End If
      txtValorizacionEstrellas.Visible = Reglas.Publicos.RecalculaValoracionesEstrellas

      Dim semaforo = New Reglas.SemaforoVentasUtilidades().ColorSemaforo(txtValorizacionEstrellas.ValorNumericoPorDefecto(0D), Entidades.SemaforoVentaUtilidad.TiposSemaforos.ESTRELLAS)
      If semaforo IsNot Nothing Then
         txtValorizacionEstrellas.BackColor = Color.FromArgb(semaforo.ColorSemaforo)
         txtValorizacionEstrellas.ForeColor = Color.FromArgb(semaforo.ColorLetra)
         If semaforo.Negrita Then
            txtValorizacionEstrellas.Font = New Font(txtValorizacionEstrellas.Font, FontStyle.Bold)
         Else
            txtValorizacionEstrellas.Font = New Font(txtValorizacionEstrellas.Font, FontStyle.Regular)
         End If
      Else
         txtValorizacionEstrellas.BackColor = Nothing
         txtValorizacionEstrellas.ForeColor = Nothing
         txtValorizacionEstrellas.Font = New Font(txtValorizacionEstrellas.Font, FontStyle.Regular)
      End If

      txtTipoCliente.Text = dr.Cells("NombreTipoCliente").Value.ToString()
      txtEstado.Text = dr.Cells("NombreEstadoCliente").Value.ToString()

      OnSelectedChanged(Nothing)

   End Sub

   'Public Property RevisionAdministrativa() As Boolean
   '   Get
   '      Return Me.chbRevisionAdministrativa.Checked
   '   End Get
   '   Set(ByVal value As Boolean)
   '      Me.chbRevisionAdministrativa.Checked = value
   '   End Set
   'End Property

   Private _visualizaRevisionAdministrativa As Boolean
   Public Property VisualizaRevisionAdministrativa() As Boolean
      Get
         Return _visualizaRevisionAdministrativa
      End Get
      Set(ByVal value As Boolean)
         _visualizaRevisionAdministrativa = value
      End Set
   End Property


#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
         '-- Seguridad --
         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         'Seguridad de la Edición de Clientes (enlace a través de la etiqueta "Más info...")
         Me.llbCliente.Visible = oUsuario.TienePermisos("Clientes-PuedeUsarMasInfo")
         Me.chbRevisionAdministrativa.Visible = Me.VisualizaRevisionAdministrativa
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Public Property IdCliente() As Long
      Get
         Dim result As Long = 0
         If bscCodigoCliente.Tag IsNot Nothing AndAlso IsNumeric(bscCodigoCliente.Tag) Then
            result = Convert.ToInt64(bscCodigoCliente.Tag)
         End If
         Return result
      End Get
      Set(ByVal value As Long)
         Try
            If value > 0 Then
               bscCodigoCliente.Text = New Reglas.Clientes().GetUno(value).CodigoCliente.ToString()
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
            MessageBox.Show(String.Format("No se pudo recuperar el Cliente: {0}", ex.Message), FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End Try
      End Set
   End Property

   Public Property RevisionAdministrativa() As Boolean
      Get
         Return chbRevisionAdministrativa.Checked
      End Get
      Set(ByVal value As Boolean)
         If chbRevisionAdministrativa.Visible Then
            chbRevisionAdministrativa.Checked = value
         End If
      End Set
   End Property

   Public Property Novedad As Entidades.CRMNovedad

   Private Function MostrarMasInfo() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         Me.bscCodigoCliente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoCliente.Permitido
         Me.bscCodigoCliente.PresionarBoton()
         bscCodigoCliente.Permitido = prevPermitido
      End If
      Return result

   End Function

   Private Sub llbCliente_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked
      Try

         MostrarMasInfo()

         'Dim PantCliente As ClientesDetalle

         'If Me.bscCodigoCliente.Selecciono Or Me.bscCliente.Selecciono Then
         '   Dim Clie As Eniac.Entidades.Cliente = New Eniac.Entidades.Cliente
         '   Dim blnIncluirFoto As Boolean = True
         '   Clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), blnIncluirFoto)
         '   Clie.Usuario = actual.Nombre
         '   PantCliente = New ClientesDetalle(Clie)
         '   PantCliente.CierraAutomaticamente = True
         '   PantCliente.StateForm = Eniac.Win.StateForm.Actualizar
         '   'Else
         '   '   PantCliente = New ClientesDetalle(New Entidades.Cliente())
         '   '   PantCliente.CierraAutomaticamente = True
         '   '   PantCliente.StateForm = Eniac.Win.StateForm.Insertar

         '   If PantCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
         '      Me.bscCodigoCliente.Text = PantCliente.txtCodigoCliente.Text
         '      Me.bscCodigoCliente.PresionarBoton()
         '   End If
         'End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

End Class
