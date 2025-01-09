Public Class ContactosABM

#Region "Campos"

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      'Dim tsi As ToolStripButton = New ToolStripButton("Geo", Nothing, AddressOf PresionarGeo)
      '  Me.tstBarra.Items.Insert(Me.tstBarra.Items.Count - 1, tsi)

      'Seguridad del campo Vendedor
      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()


   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContactosDetalle(DirectCast(Me.GetEntidad(), Entidades.Contacto))
      End If
      Return New ContactosDetalle(New Entidades.Contacto)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Contactos()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Contactos.rdlc", "SistemaDataSet_Contactos", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Contactos"
         frmImprime.Show()
         'Dim imp As Imprimir = New Imprimir()
         '        Dim path As String = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\") + 1) + "Contactos.rdlc"
         'Dim path As String = "Eniac.Win.Contactos.rdlc"
         'imp.Run(path, "SistemaDataSet_Contactos", Me.dtDatos)
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      MyBase.GetEntidad()

      Dim clie As Entidades.Contacto = New Entidades.Contacto
      Dim blnIncluirFoto As Boolean = True

      With Me.dgvDatos.ActiveCell.Row
         clie = New Reglas.Contactos().GetUno(Long.Parse(.Cells("IdContacto").Value.ToString()), blnIncluirFoto)
         clie.Usuario = actual.Nombre
      End With

      Return clie

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("IdContacto").FormatearColumna("Codigo", pos, 65, HAlign.Right)
         .Columns("NombreContacto").FormatearColumna("Nombre", pos, 200)
         .Columns("Direccion").FormatearColumna("Dirección", pos, 200)
         .Columns("IdLocalidad").FormatearColumna("C.P.", pos, 45, HAlign.Center)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 70)
         .Columns("NombreProvincia").FormatearColumna("Provincia", pos, 70)
         .Columns("IdTipoContacto").OcultoPosicion(True, pos)
         .Columns("NombreTipoContacto").FormatearColumna("Tipo Contacto", pos, 90)
         .Columns("IdCategoriaFiscal").OcultoPosicion(True, pos)
         .Columns("NombreCategoriaFiscal").FormatearColumna("Categoría Fiscal", pos, 120)

         .Columns("Cuit").FormatearColumna("CUIT", pos, 80)
         .Columns("TipoDocContacto").FormatearColumna("Tipo Doc.", pos, 40)
         .Columns("NroDocContacto").FormatearColumna("Nro. Documento", pos, 80, HAlign.Right)
         .Columns("Telefono").FormatearColumna("Telefono", pos, 200)
         .Columns("Celular").FormatearColumna("Celular", pos, 200)
         .Columns("IdZonaGeografica").OcultoPosicion(True, pos)
         .Columns("NombreZonaGeografica").OcultoPosicion(True, pos)
         .Columns("FechaNacimiento").FormatearColumna("Fecha Nac.", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("CorreoElectronico").FormatearColumna("Correo Electronico", pos, 150)
         .Columns("PaginaWeb").FormatearColumna("Pagina Web", pos, 120)
         .Columns("Observacion").FormatearColumna("Observación", pos, 200)
         .Columns("FechaAlta").FormatearColumna("Alta", pos, 100, HAlign.Center, , "dd/MM/yyyy HH:mm")
         .Columns("Activo").FormatearColumna("Activo", pos, 40, HAlign.Center)
         .Columns("IdUsuario").FormatearColumna("Usuario", pos, 80)
         .Columns("GeoLocalizacionLat").Hidden = True
         .Columns("GeoLocalizacionLng").Hidden = True
      End With

   End Sub

   Protected Overrides Sub Borrar()
      MyBase.Borrar()
   End Sub

#End Region

#Region "Metodos"

   Public Sub PresionarGeo(ByVal o As Object, ByVal e As EventArgs)
      Try
         'Dim geo As ContactosGeoLocalizacion = New ContactosGeoLocalizacion()
         'geo.Contactos = Me.dgvDatos.DataSource
         'geo.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

End Class