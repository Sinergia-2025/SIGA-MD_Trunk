Public Class EmpleadosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Dim tsi As ToolStripButton = New ToolStripButton("Geo", Nothing, AddressOf PresionarGeo)
      Me.tstBarra.Items.Insert(Me.tstBarra.Items.Count - 1, tsi)

   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New EmpleadosDetalle(DirectCast(Me.GetEntidad(), Entidades.Empleado))
      End If
      Return New EmpleadosDetalle(New Entidades.Empleado)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Empleados()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Empleados.rdlc", "SistemaDataSet_Empleados", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = "Empleados"
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim empleado As Entidades.Empleado = New Entidades.Empleado
      With Me.dgvDatos.ActiveCell.Row
         empleado = New Reglas.Empleados().GetUno(Integer.Parse(.Cells("IdEmpleado").Value.ToString()))
      End With
      Return empleado
   End Function

   Protected Overrides Sub FormatearGrilla()


      Grilla.AgregarFiltroEnLinea(dgvDatos, {("IdEmpleado").ToString(), "NombreEmpleado", "NroDocEmpleado", "NombreDeFantasia", "Direccion",
                                  "Observacion", "TelefonoEmpleado", "CelularEmpleado", "CorreoAdministrativo", "NombreTarjeta"})


      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns("IdEmpleado").FormatearColumna("Id", pos, 70, HAlign.Right)
         .Columns("NombreEmpleado").FormatearColumna("Nombre", pos, 170)
         .Columns("TipoDocEmpleado").FormatearColumna("Tipo", pos, 40)
         .Columns("NroDocEmpleado").FormatearColumna("Número", pos, 70, HAlign.Right)
         .Columns("Direccion").FormatearColumna("Dirección", pos, 150)
         .Columns("IdLocalidad").Hidden = True
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 100)
         .Columns("TelefonoEmpleado").FormatearColumna("Teléfono", pos, 100)
         .Columns("CelularEmpleado").FormatearColumna("Celular", pos, 100)
         .Columns("EsVendedor").FormatearColumna("Vendedor", pos, 60)
         .Columns("EsComprador").FormatearColumna("Comprador", pos, 60)
         .Columns("EsCobrador").FormatearColumna("Cobrador", pos, 60)
         .Columns("IdUsuario").FormatearColumna("Usuario", pos, 70)
         .Columns("IdUsuarioMovil").FormatearColumna("Usuario Movil", pos, 70)
         .Columns("NivelAutorizacion").FormatearColumna("Nivel de Autorización", pos, 85, HAlign.Right)
         .Columns("ComisionPorVenta").FormatearColumna("Comisión", pos, 60, HAlign.Right)
         .Columns("GeoLocalizacionLat").Hidden = True
         .Columns("GeoLocalizacionLng").Hidden = True
         .Columns("Clave").FormatearColumna("Clave", pos, 70).EditorComponent = UltraTextEditor1

         .Columns(Eniac.Entidades.Empleado.Columnas.DebitoDirecto.ToString()).FormatearColumna("Débito Directo", pos, 70)
         .Columns(Eniac.Entidades.Empleado.Columnas.IdBanco.ToString()).FormatearColumna("Id Banco", pos, 70, HAlign.Right, True)
         .Columns("NombreBanco").FormatearColumna("Banco", pos, 200)


         .Columns(Eniac.Entidades.Empleado.Columnas.IdDispositivo.ToString()).FormatearColumna("ID Dispositivo", pos, 180)
         .Columns(Eniac.Entidades.EmpleadoSucursal.Columnas.IdCaja.ToString()).FormatearColumna("Id Caja", pos, 70, HAlign.Right)
         .Columns(Eniac.Entidades.CajaNombre.Columnas.NombreCaja.ToString()).FormatearColumna("Caja", pos, 120)
         .Columns(Eniac.Entidades.EmpleadoSucursal.Columnas.Observacion.ToString()).FormatearColumna("Observación", pos, 200)

         '-.PE-31509.-
         .Columns(Eniac.Entidades.Empleado.Columnas.DebitoTarjeta.ToString()).FormatearColumna("Débito Tarjeta", pos, 70)
         .Columns(Eniac.Entidades.Empleado.Columnas.IdTarjeta.ToString()).FormatearColumna("Id Tarjeta", pos, 70, HAlign.Right, True)
         .Columns("NombreTarjeta").FormatearColumna("Tarjeta", pos, 200)

         .Columns("IdCategoriaEmpleado").Hidden = True
         .Columns("CodigoCategoria").FormatearColumna("Cod.Categoria", pos, 100)
         .Columns("DescripcionCategoria").FormatearColumna("Descripcion", pos, 200)
         .Columns("ValorHoraProd").FormatearColumna("Valor Hora", pos, 70, HAlign.Right)

         .Columns("CobraPremioCobranza").FormatearColumna("Cobra Premio", pos, 60)

      End With

   End Sub

#End Region

#Region "Metodos"

   Public Sub PresionarGeo(ByVal o As Object, ByVal e As EventArgs)
      Try
         Dim geo As EmpleadosGeoLocalizacion = New EmpleadosGeoLocalizacion()
         geo.Empleados = DirectCast(Me.dgvDatos.DataSource, DataTable)
         geo.ShowDialog()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            Dim colorColumnKey As String = Entidades.Empleado.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class