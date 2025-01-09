Imports Infragistics.Win.UltraWinGrid

Public Class ListasControlProductos

#Region "Campos"

   Private _dtListasControl As DataTable
   Private _dtItemsListasControl As DataTable
   Private _dtItemsListasControlAuditoria As DataTable
   Private _dtListasControlAuditoria As DataTable
   Private _publicos As Publicos
   Private _cargandoPantalla As Boolean
   Private _Producto As Entidades.Producto
   Private _idCliente As Long
   Private _Roles As DataTable
   Private _VistaGerencia As Boolean = False
   Private _PermisosCalidad As Boolean = False
   Private _Permisos5SCalidad As Boolean = False
   Private _Permisos5SCalidadEdicion As Boolean = False
   Private _PermisosProduccion As Boolean = False
   Private _Permisos5SProduccion As Boolean = False
   Private _PermisosCabProducto As Boolean = False
   Private _PermisoCalidadFinal As Boolean = False


   Private _ListaControl As Entidades.ListaControlProducto
   Private _IdProducto As String
   Private _dtLinksProductos As DataTable
   Private _dtLinksListasControl As DataTable
   Private _ListaControlSiguiente As Entidades.ListaControlProducto

   Public ConsultarAutomaticamente As Boolean = False

   Private Const _Ok As String = "Ok"
   Private Const _NoOk As String = "NoOk"
   Private Const _Obs As String = "Obs"
   Private Const _Mat As String = "Mat"
   Private Const _NA As String = "NA"
   Private Const _OkCalidad As String = "OkCalidad"
   Private Const _NoOkCalidad As String = "NoOkCalidad"
   Private Const _ObsCalidad As String = "ObsCalidad"
   Private Const _MatCalidad As String = "MatCalidad"
   Private Const _NACalidad As String = "NACalidad"


#End Region

#Region "Constructores"


   Public Sub New()

      Me.InitializeComponent()

   End Sub


   Public Sub New(idProducto As String, idFuncion As String)

      Me.New()

      Me.IdFuncion = idFuncion
      Dim oprod As Reglas.Productos = New Reglas.Productos()
      Dim prod As Entidades.Producto = oprod.GetUno(idProducto)
      Me._IdProducto = prod.IdProducto

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._cargandoPantalla = True
         _publicos = New Publicos()

         Me._cargandoPantalla = False

         spcDatos.Enabled = True

         _Roles = New Reglas.UsuariosRoles().GetRolesdeUsuarios(actual.Nombre)

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

         _VistaGerencia = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-VG")

         _PermisosProduccion = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-P")

         _Permisos5SProduccion = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-5SP")

         _PermisosCalidad = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-C")

         _Permisos5SCalidad = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-5SC")

         _Permisos5SCalidadEdicion = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-5SCE")

         _PermisosCabProducto = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-CP")

         _PermisoCalidadFinal = oUsuario.TienePermisos(actual.Nombre, actual.Sucursal.Id, "ListasControlProductos-CF")

         If _VistaGerencia Then
            spcDatos.SplitterDistance = 1000
         Else
            spcDatos.SplitterDistance = 300
         End If

         tbcProducto.TabPages("TbpFechas").Enabled = False

         ugLinksProductos.DisplayLayout.Override.ActiveRowAppearance.Reset()
         ugLinksItems.DisplayLayout.Override.ActiveRowAppearance.Reset()

         If ConsultarAutomaticamente Then
           
               Me.bscCodigoProducto2.Text = Me._IdProducto.ToString()
               Me.bscCodigoProducto2.PresionarBoton()
         End If

         Me.tsbFInalizarListas.Visible = _PermisoCalidadFinal
         Me.tssFinalizarListas.Visible = _PermisoCalidadFinal
         '  tsbGrabar.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me._cargandoPantalla = False
      End Try

   End Sub

   Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
      MyBase.OnClosing(e)
      Try
         '  Me.ControlaCambios()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCerrar.Click
      Me.Close()
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.Grabar()
         '  Me.GrabarProducto()
         ' Me.Grabar5S()
      

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.tbcVarios.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.tbcVarios.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugListasControlUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugProductoListasControl.AfterRowFilterChanged
      Me.tssListasControlAsignar.Text = Me.ugProductoListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         RefrescarGrilla()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugListasControl_AfterRowActivate(sender As Object, e As EventArgs) Handles ugListasControl.AfterRowActivate
      Try

         Me.Cargar5S()
         Me.CargaItems()
         Me.CargaAuditoriasListas()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugProductoListasControl_AfterRowActivate(sender As Object, e As EventArgs) Handles ugProductoListasControl.AfterRowActivate
      Try
         Me.CargaAuditoriasItems()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugProductoListasControl_CellChange(sender As Object, e As CellEventArgs) Handles ugProductoListasControl.CellChange
      Try
         If e.Cell.Row.Index < 0 Then Exit Sub
         If e.Cell.Column.Key = _Ok Or e.Cell.Column.Key = _NoOk Or e.Cell.Column.Key = _Obs Or e.Cell.Column.Key = _Mat Or e.Cell.Column.Key = _NA Then
            If Not Boolean.Parse(e.Cell.Value.ToString()) Then
               For Each cell As UltraGridCell In ugProductoListasControl.ActiveRow.Cells
                  If cell.Column.Style = ColumnStyle.CheckBox And (e.Cell.Column.Key = _Ok Or e.Cell.Column.Key = _NoOk Or e.Cell.Column.Key = _Obs Or e.Cell.Column.Key = _Mat Or e.Cell.Column.Key = _NA) _
                       And Not (cell.Column.Key = _OkCalidad Or cell.Column.Key = _NoOkCalidad Or cell.Column.Key = _ObsCalidad Or cell.Column.Key = _MatCalidad Or cell.Column.Key = _NACalidad) _
                       And e.Cell.Column.Key <> cell.Column.Key Then
                     cell.Value = False
                  End If
               Next
            End If
            ugProductoListasControl.PerformAction(UltraGridAction.ExitEditMode)
         End If

         If e.Cell.Column.Key = _OkCalidad Or e.Cell.Column.Key = _NoOkCalidad Or e.Cell.Column.Key = _ObsCalidad Or e.Cell.Column.Key = _MatCalidad Or e.Cell.Column.Key = _NACalidad Then
            If Not Boolean.Parse(e.Cell.Value.ToString()) Then
               For Each cell As UltraGridCell In ugProductoListasControl.ActiveRow.Cells
                  If cell.Column.Style = ColumnStyle.CheckBox And (e.Cell.Column.Key = _OkCalidad Or e.Cell.Column.Key = _NoOkCalidad Or e.Cell.Column.Key = _ObsCalidad Or e.Cell.Column.Key = _MatCalidad Or e.Cell.Column.Key = _NACalidad) _
                   And Not (cell.Column.Key = _Ok Or cell.Column.Key = _NoOk Or cell.Column.Key = _Obs Or cell.Column.Key = _Mat Or cell.Column.Key = _NA) _
                   And e.Cell.Column.Key <> cell.Column.Key Then
                     cell.Value = False
                  End If
               Next
            End If
            ugProductoListasControl.PerformAction(UltraGridAction.ExitEditMode)
         End If

         e.Cell.Row.Cells("Modif").Value = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaIngreso.CheckedChanged
      Try
         Me.dtpIngreso.Enabled = Me.chbFechaIngreso.Checked
         If Not Me.chbFechaIngreso.Checked Then
            Me.dtpIngreso.Value = Date.Now()
            _Producto.CalidadFechaIngreso = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEgreso_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEgreso.CheckedChanged
      Try
         Me.dtpEgreso.Enabled = Me.chbFechaEgreso.Checked
         If Not Me.chbFechaEgreso.Checked Then
            Me.dtpEgreso.Value = Date.Now()
            _Producto.CalidadFechaEgreso = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaPreEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaPreEntrega.CheckedChanged
      Try
         Me.dtpPreentrega.Enabled = Me.chbFechaPreEntrega.Checked
         If Not Me.chbFechaPreEntrega.Checked Then
            Me.dtpPreentrega.Value = Date.Now()
            _Producto.CalidadFechaPreEnt = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEntProgramada_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntProgramada.CheckedChanged
      Try
         Me.dtpEntProgramada.Enabled = Me.chbFechaEntProgramada.Checked
         If Not Me.chbFechaEntProgramada.Checked Then
            Me.dtpEntProgramada.Value = Date.Now()
            _Producto.CalidadFechaEntProg = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaLiberado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaLiberado.CheckedChanged
      Try

         Me.dtpLiberado.Enabled = Me.chbFechaLiberado.Checked
         Me.txtUsuarioLiberado.Enabled = Me.chbFechaLiberado.Checked

         If Not Me.chbFechaLiberado.Checked Then
            Me.dtpLiberado.Value = Date.Now()
            Me.txtUsuarioLiberado.Text = ""
            _Producto.CalidadStatusLiberado = False
            _Producto.CalidadFechaLiberado = Nothing
            _Producto.CalidadUserLiberado = Nothing
         Else

            Dim EstadoFinalizado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlTerminado)
            Dim entro As Boolean = False
            Dim Lista As Entidades.ListaControl = New Entidades.ListaControl()
            Dim TipoLista As Entidades.ListaControlTipo = New Entidades.ListaControlTipo

            For Each dr As UltraGridRow In ugListasControl.Rows
               Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr.Cells("IdListaControl").Value.ToString()))
               TipoLista = New Reglas.ListasControlTipos().GetUno(Lista.IdListaControlTipo)
               If TipoLista.VisiblePanelControl Then
                  If Not Lista.HabilitaFechaLiberadoPDI Then
                     If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> EstadoFinalizado.IdEstadoCalidad Then
                        entro = True
                     End If
                  End If
               End If
            Next

            If entro Then
               ShowMessage("Hay Listas que no estan Terminadas, no podrá ingresar fecha Liberado.")
               Me.chbFechaLiberado.Checked = False
               Exit Sub
            End If

            Me.txtUsuarioLiberado.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEntregado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntregado.CheckedChanged
      'Try
      '   Me.dtpEntregado.Enabled = Me.chbFechaEntregado.Checked
      '   Me.txtUsuarioEntregado.Enabled = Me.chbFechaEntregado.Checked

      '   If Not Me.chbFechaEntregado.Checked Then
      '      Me.dtpEntregado.Value = Date.Today()
      '      Me.txtUsuarioEntregado.Text = ""
      '      _Producto.CalidadStatusEntregado = False
      '      _Producto.CalidadFechaEntregado = Nothing
      '      _Producto.CalidadUserEntregado = Nothing
      '   Else
      '      Me.txtUsuarioEntregado.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id
      '   End If
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Private Sub chbFechaCertificado_CheckedChanged(sender As Object, e As EventArgs)
      'Try
      '   Me.txtNroCertificado.Enabled = Me.chbFechaCertificado.Checked
      '   Me.txtFechaCertificado.Enabled = Me.chbFechaCertificado.Checked
      '   Me.txtUsuarioCertificado.Enabled = Me.chbFechaCertificado.Checked
      '   Me.tsbImprimirCertificado.Enabled = Me.chbFechaCertificado.Checked
      '   If Not Me.chbFechaCertificado.Checked Then
      '      Me.txtFechaCertificado.Text = ""
      '      Me.txtUsuarioCertificado.Text = ""
      '      Me.txtNroCertificado.Text = ""
      '      _Producto.CalidadFecCertificado = Nothing
      '      _Producto.CalidadUsrCertificado = Nothing
      '      _Producto.CalidadNroCertificado = Nothing
      '   Else

      '      Me.txtFechaCertificado.Text = Date.Now().ToString()
      '      Me.txtUsuarioCertificado.Text = actual.Nombre
      '   End If
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Private Sub tsbIniciarLista_Click(sender As Object, e As EventArgs) Handles tsbIniciarLista.Click
      Try

         If tsbIniciarLista.Text = "Reabrir Lista" Then
            If Me.chbFechaEntregado.Checked Then
               MessageBox.Show("No se puede reabrir Listas, ya tiene fecha de Entrega.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
               Exit Sub
            End If
         End If

         Me.CambiaAEstadoEnProceso()

         If tsbIniciarLista.Text = "Reabrir Lista" Then

            Dim Lista As Entidades.ListaControl = New Reglas.ListasControl().GetUno(_ListaControl.IdListaControl)

            Dim Orden As Integer = _ListaControl.Orden

            Dim ListaSig As DataTable = New Reglas.ListasControlProductos().GetListasControlSiguienteOrden(Me.bscCodigoProducto2.Text, Orden)

            If ListaSig.Rows.Count = 0 Then
               Me.chbFechaLiberado.Checked = False
            End If

            If Lista.HabilitaFechaLiberado Then
               Me.chbFechaLiberado.Checked = False
            End If

            If Lista.HabilitaFechaLiberadoPDI Then
               Me.chbFechaLiberadoPDI.Checked = False
            End If

            If Lista.ModificaFechaEgreso Then
               Me.chbFechaEgreso.Checked = False
            End If

            If Lista.ModificaFechaPreEntrega Then
               Me.chbFechaPreEntrega.Checked = False
            End If

            Me.txtObservacionLista.Enabled = True
            tbcVarios.SelectedTab = tbpObservacionLista
            Me.txtObservacionLista.Focus()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbFinalizarLista_Click(sender As Object, e As EventArgs) Handles tsbFinalizarLista.Click
      Try

         If MessageBox.Show("Desea finalizar la Lista?", Me.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.tsbGrabar.Enabled = False

         Dim drLista As DataRow = DirectCast(ugListasControl.ActiveRow.ListObject, DataRowView).Row
         Dim ListaActiva As Entidades.ListaControl = New Reglas.ListasControl().GetUno(drLista.Field(Of Integer?)("IdListaControl").IfNull())
         Dim Finaliza As Boolean = False
         Dim ItemsListaProd As DataTable = New DataTable
         Dim oListaControlProductosItems As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems()

         _ListaControl = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, drLista.Field(Of Integer?)("IdListaControl").IfNull(Publicos.ListaPreciosPredeterminada))

         For Each dr As UltraGridRow In ugProductoListasControl.Rows
            If ListaActiva.ControlaProduccion Then
               Dim selec As String
               selec = If(Boolean.Parse(dr.Cells("NoOk").Value.ToString()), dr.Cells("NoOk").Column.Header.Caption,
                          If(Boolean.Parse(dr.Cells("Obs").Value.ToString()), dr.Cells("Obs").Column.Header.Caption,
                              If(Boolean.Parse(dr.Cells("Mat").Value.ToString()), dr.Cells("Mat").Column.Header.Caption, String.Empty)))
               'Si controla producción y hay alguno no OK o NA da error
               If Not String.IsNullOrWhiteSpace(selec) Then
                  ShowMessage(String.Format("La Lista '{0}' controla Producción y el item '{1}' está en '{2}', no es posible Finalizar la Lista.",
                                            ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value, selec))
                  Me.tsbGrabar.Enabled = True
                  dr.Activate()
                  Exit Sub
               End If

               If Not Boolean.Parse(dr.Cells("Ok").Value.ToString()) And Not Boolean.Parse(dr.Cells("NA").Value.ToString()) Then
                  ShowMessage(String.Format("La Lista '{0}' controla Producción y el item '{1}' no tiene seleccionada ninguna opción válida.",
                                            ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value))
                  Me.tsbGrabar.Enabled = True
                  dr.Activate()
                  Exit Sub
               End If

            End If
            If ListaActiva.ControlaCalidad Then
               Dim selec As String
               selec = If(Boolean.Parse(dr.Cells("NoOkCalidad").Value.ToString()), dr.Cells("NoOkCalidad").Column.Header.Caption,
                             If(Boolean.Parse(dr.Cells("ObsCalidad").Value.ToString()), dr.Cells("ObsCalidad").Column.Header.Caption,
                                 If(Boolean.Parse(dr.Cells("MatCalidad").Value.ToString()), dr.Cells("MatCalidad").Column.Header.Caption, String.Empty)))
               If Not String.IsNullOrWhiteSpace(selec) Then
                  ShowMessage(String.Format("La Lista '{0}' controla Calidad y el item '{1}' está en '{2}', no es posible Finalizar la Lista.",
                                               ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value, selec))
                  Me.tsbGrabar.Enabled = True
                  dr.Activate()
                  Exit Sub
               End If

               If Not Boolean.Parse(dr.Cells("OkCalidad").Value.ToString()) And Not Boolean.Parse(dr.Cells("NACalidad").Value.ToString()) Then
                  ShowMessage(String.Format("La Lista '{0}' controla Calidad y el item '{1}' no tiene seleccionada ninguna opción válida.",
                                            ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value))
                  Me.tsbGrabar.Enabled = True
                  dr.Activate()
                  Exit Sub
               End If

               If ListaActiva.ControlaProduccion Then
                  If Boolean.Parse(dr.Cells("Ok").Value.ToString()) <> Boolean.Parse(dr.Cells("OkCalidad").Value.ToString()) Or
                                      Boolean.Parse(dr.Cells("NA").Value.ToString()) <> Boolean.Parse(dr.Cells("NACalidad").Value.ToString()) Then
                     ShowMessage(String.Format("La Lista '{0}' controla Calidad y el item '{1}' tiene diferencias entre producción y calidad.",
                                               ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value))
                     Me.tsbGrabar.Enabled = True
                     dr.Activate()
                     Exit Sub
                  End If
               End If

            End If
         Next

         Finaliza = True

         'If ListaActiva.ControlaProduccion Then
         '   For Each dr As UltraGridRow In ugProductoListasControl.Rows
         '      If dr.Cells("Ok").Value = True Or dr.Cells("NA").Value = True Then
         '         Finaliza = True
         '      Else
         '         MessageBox.Show("La Lista controla Producción y no estan todos los items OK/NA, no es posible Finalizar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         '         Me.tsbGrabar.Enabled = True
         '         Exit Sub
         '      End If
         '   Next
         'End If


         'If ListaActiva.ControlaCalidad Then
         '   For Each dr As UltraGridRow In ugProductoListasControl.Rows

         '      If (dr.Cells("OkCalidad").Value = True Or dr.Cells("NACalidad").Value = True) Then

         '         If (dr.Cells("Ok").Value = dr.Cells("OkCalidad").Value = True Or dr.Cells("NA").Value = dr.Cells("NACalidad").Value = True) Then
         '            Finaliza = True
         '         Else
         '            MessageBox.Show("La Lista controla Calidad y hay diferencias, no es posible Finalizar la Lista. Item:  " & dr.Cells("NombreListaControlItem").Value.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         '            Me.tsbGrabar.Enabled = True
         '            Exit Sub
         '         End If

         '      Else
         '         MessageBox.Show("La Lista controla Calidad y no estan todos los items OK/NA, no es posible Finalizar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         '         Me.tsbGrabar.Enabled = True
         '         Exit Sub
         '      End If

         '   Next
         'End If


         'If ListaActiva.Controla5SProduccion Then
         '   If _ListaControl.CincoS = "Ok" Then
         '      Finaliza = True
         '   Else
         '      MessageBox.Show("La Lista controla 5S Produccion y no esta OK, no es posible Finalizar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         '      Me.tsbGrabar.Enabled = True
         '      Exit Sub
         '   End If
         'End If


         'If ListaActiva.Controla5SCalidad Then
         '   If _ListaControl.CincoSC = "Ok" Then
         '      Finaliza = True
         '   Else
         '      MessageBox.Show("La Lista controla 5S Calidad y no esta OK, no es posible Finalizar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         '      Me.tsbGrabar.Enabled = True
         '      Exit Sub
         '   End If
         'End If

         If Finaliza Then

            Dim EstadoFinalizado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlTerminado)
            Dim Lista As Entidades.ListaControl = New Reglas.ListasControl().GetUno(_ListaControl.IdListaControl)
            Dim Lista2 As Entidades.ListaControl = New Entidades.ListaControl()
            Dim TipoLista As Entidades.ListaControlTipo = New Entidades.ListaControlTipo
            If Lista.HabilitaFechaLiberado Then
               'If _PermisoCalidadFinal Then
               'Controla que esten todas las listas terminadas
               Dim entro As Boolean = False
               For Each dr As UltraGridRow In ugListasControl.Rows
                  Lista2 = New Reglas.ListasControl().GetUno(Integer.Parse(dr.Cells("IdListaControl").Value.ToString()))
                  TipoLista = New Reglas.ListasControlTipos().GetUno(Lista2.IdListaControlTipo)
                  If TipoLista.VisiblePanelControl Then
                     If Not Lista2.HabilitaFechaLiberadoPDI Then
                        If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> EstadoFinalizado.IdEstadoCalidad And Lista2.IdListaControl <> Lista.IdListaControl Then
                           entro = True
                        End If
                     End If
                  End If
               Next
               If entro Then
                  ShowMessage("Hay Listas que no estan Terminadas, no podrá finalizar la Lista.")
                  Exit Sub
               Else
                  'If _PermisoCalidadFinal Then
                  '   Me.chbFechaLiberado.Checked = True
                  '   Me.dtpLiberado.Value = Date.Now()
                  'Else
                  '   Me.chbFechaLiberado.Enabled = False
                  'End If

               End If
               'Else
               '   ShowMessage("No tiene permiso para finalizar la Lista.")
               '   Exit Sub
               'End If
               Dim Producto As Entidades.Producto = New Entidades.Producto
               Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)
               If Producto.CalidadNroCarroceria = 0 Or Producto.CalidadNumeroChasis = Nothing Then
                  ShowMessage("Falta ingresar Numero de Chásis y/o Numero de Carrocería al Producto, no podrá finalizar la Lista.")
                  Exit Sub
               End If
            End If

            'If Lista.HabilitaFechaLiberadoPDI Then
            '   If Me.chbFechaLiberado.Checked Then
            '      Dim entro As Boolean = False
            '      For Each dr As UltraGridRow In ugListasControl.Rows
            '         Lista2 = New Reglas.ListasControl().GetUno(Integer.Parse(dr.Cells("IdListaControl").Value.ToString()))
            '         If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> EstadoFinalizado.IdEstadoCalidad And Lista2.IdListaControl <> Lista.IdListaControl Then
            '            entro = True
            '         End If
            '      Next
            '      If entro Then
            '         ShowMessage("Hay Listas que no estan Terminadas, no podrá finalizar la Lista.")
            '         Exit Sub
            '      End If
            '      'Me.chbFechaLiberadoPDI.Checked = True
            '      'Me.txtUsuarioLiberadoPDI.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id
            '   Else
            '      ShowMessage("No tiene fecha de Liberado, no podrá finalizar la Lista.")
            '      Exit Sub
            '   End If
            'End If

            TipoLista = New Reglas.ListasControlTipos().GetUno(Lista.IdListaControlTipo)
            If Not TipoLista.VisiblePanelControl Then
               If Me.chbFechaLiberado.Checked And Me.chbFechaLiberadoPDI.Checked Then
                  Dim entro As Boolean = False
                  For Each dr As UltraGridRow In ugListasControl.Rows
                     Lista2 = New Reglas.ListasControl().GetUno(Integer.Parse(dr.Cells("IdListaControl").Value.ToString()))
                     If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> EstadoFinalizado.IdEstadoCalidad And Lista2.IdListaControl <> Lista.IdListaControl Then
                        entro = True
                     End If
                  Next
                  If entro Then
                     ShowMessage("Hay Listas que no estan Terminadas, no podrá finalizar la Lista.")
                     Exit Sub
                  End If
                  If tsbEmitirCertificado.Enabled Then
                     ShowMessage("No se emitió el Certificado de Calidad, no podrá finalizar la Lista.")
                     Exit Sub
                  Else
                     ' Me.tsbEmitirCertificadoEntrega.PerformClick()
                  End If


                  'Me.chbFechaLiberadoPDI.Checked = True
                  'Me.txtUsuarioLiberadoPDI.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id
               Else
                  ShowMessage("No tiene fecha de Liberado/Liberado PDI, no podrá finalizar la Lista.")
                  Exit Sub
               End If
            End If

            drLista("IdEstadoCalidad") = EstadoFinalizado.IdEstadoCalidad
            drLista("NombreEstadoCalidad") = EstadoFinalizado.NombreEstadoCalidad

            _ListaControl.IdEstadoCalidad = EstadoFinalizado.IdEstadoCalidad
            _ListaControl.FecEgreso = Date.Now()
            _ListaControl.FecIngreso = Nothing

            Dim color As Color = SystemColors.Control
            color = EstadoFinalizado.Color.ToArgbColor()
            ugListasControl.ActiveRow.Cells.Item("NombreEstadoCalidad").Appearance.BackColor = color
            ugListasControl.ActiveRow.Cells.Item("NombreEstadoCalidad").ActiveAppearance.BackColor = color

            If Lista.ModificaFechaEgreso Then
               Me.chbFechaEgreso.Checked = True
               Me.dtpEgreso.Value = Date.Now()
            End If

            If Lista.ModificaFechaPreEntrega Then
               Me.chbFechaPreEntrega.Checked = True
               Me.dtpPreentrega.Value = Date.Now()
            End If

            '  Me.spcDatos.Panel1.Enabled = False
            ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

            Me.tsbIniciarLista.Enabled = False
            Me.tsbFinalizarLista.Enabled = False
            Me.tsbGrabar.Enabled = True


            'Busca la lista siguiente para cambiarle el estado si es automatica y es Pendiente
            Dim Orden As Integer = Integer.Parse(drLista("Orden").ToString())

            _ListaControlSiguiente = New Entidades.ListaControlProducto()
            Dim ListaSig As DataTable = New Reglas.ListasControlProductos().GetListasControlSiguienteOrden(Me.bscCodigoProducto2.Text, Orden)
            If ListaSig.Rows.Count <> 0 Then
               Dim ListaSiguiente As Entidades.ListaControl = New Reglas.ListasControl().GetUno(Integer.Parse(ListaSig.Rows(0).Item("IdListaControl").ToString()))
               If ListaSiguiente.InicioAutomatico And Integer.Parse(ListaSig.Rows(0).Item("IdEstadoCalidad").ToString()) = 1 Then
                  _ListaControlSiguiente = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, ListaSiguiente.IdListaControl)
                  _ListaControlSiguiente.IdEstadoCalidad = Reglas.Publicos.EstadoListaControlEnProceso
                  _ListaControlSiguiente.FecEgreso = Nothing
                  _ListaControlSiguiente.FecIngreso = Date.Now()
                  If ListaSiguiente.HabilitaFechaLiberadoPDI Then
                     _ListaControlSiguiente.CincoSFechaC = Date.Now()
                     _ListaControlSiguiente.CincoSC = "Ok"
                     _ListaControlSiguiente.CincoSUsrC = New Reglas.Usuarios().GetUno(actual.Nombre).Id
                  End If
               End If
            End If

         End If

         Me.Grabar()

         ' MessageBox.Show("Información grabada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         '  RecargarGrillas()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      Try
         AgregarLinkProducto()
         CargarLinksProductos(True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If ugLinksProductos.Selected.Rows.Count = 0 And ugLinksProductos.ActiveRow IsNot Nothing Then
            ugLinksProductos.ActiveRow.Selected = True
         End If
         Dim olinksProductos As Reglas.ProductosLinks = New Reglas.ProductosLinks()
         Dim ProdLink As Entidades.ProductoLinks = New Entidades.ProductoLinks()
         Try
            Dim drListaControlRol As List(Of DataRow) = New List(Of DataRow)()
            For Each dgRow As UltraGridRow In ugLinksProductos.Selected.Rows
               If dgRow.ListObject IsNot Nothing AndAlso
                  TypeOf (dgRow.ListObject) Is DataRowView AndAlso
                  DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
                  drListaControlRol.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
               End If
            Next
            For Each drRoles As DataRow In drListaControlRol
               ProdLink = olinksProductos.GetUno(drRoles.Field(Of String)("IdProducto"), drRoles.Field(Of Integer)("ItemLink"))
               olinksProductos.Borrar(ProdLink)
               drRoles.Delete()
            Next
            Me._dtLinksProductos.AcceptChanges()
         Catch
            Me._dtLinksProductos.RejectChanges()
            Throw
         End Try
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnInsertarLinkItem_Click(sender As Object, e As EventArgs) Handles btnInsertarLinkItem.Click
      Try
         AgregarLinkItem()
         CargarLinksItems(True)
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnEliminarLinkItem_Click(sender As Object, e As EventArgs) Handles btnEliminarLinkItem.Click
      Try
         If ugLinksItems.Selected.Rows.Count = 0 And ugLinksItems.ActiveRow IsNot Nothing Then
            ugLinksItems.ActiveRow.Selected = True
         End If
         Dim olinksItems As Reglas.ListasControlItemsLinks = New Reglas.ListasControlItemsLinks()
         Dim ItemLink As Entidades.ListaControlItemLinks = New Entidades.ListaControlItemLinks()
         Try
            Dim drLinkItem As List(Of DataRow) = New List(Of DataRow)()
            For Each dgRow As UltraGridRow In ugLinksItems.Selected.Rows
               If dgRow.ListObject IsNot Nothing AndAlso
                  TypeOf (dgRow.ListObject) Is DataRowView AndAlso
                  DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
                  drLinkItem.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
               End If
            Next
            For Each drLink As DataRow In drLinkItem
               ItemLink = olinksItems.GetUno(Integer.Parse(drLink("IdListaControl").ToString()),
                                             Integer.Parse(drLink("Item").ToString()),
                                             Integer.Parse(drLink("ItemLink").ToString()))

               olinksItems.Borrar(ItemLink)
               drLink.Delete()
            Next
            Me._dtLinksProductos.AcceptChanges()
         Catch
            Me._dtLinksProductos.RejectChanges()
            Throw
         End Try
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub rbtOk_CheckedChanged(sender As Object, e As EventArgs) Handles rbtOk.CheckedChanged
      Try
         If rbtOk.Checked Then
            Me.txtFecha5S.Text = Date.Now().ToString()
            Me.txtUsuario5S.Text = actual.Nombre
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtNoOk_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoOk.CheckedChanged
      Try
         If rbtNoOk.Checked Then
            Me.txtFecha5S.Text = Date.Now().ToString()
            Me.txtUsuario5S.Text = actual.Nombre
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtOkCalidad_CheckedChanged(sender As Object, e As EventArgs) Handles rbtOkCalidad.CheckedChanged
      Try
         If rbtOkCalidad.Checked Then
            Me.txtFecha5SCalidad.Text = Date.Now().ToString()
            Me.txtUsuario5SCalidad.Text = actual.Nombre
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub rbtNoOkCalidad_CheckedChanged(sender As Object, e As EventArgs) Handles rbtNoOkCalidad.CheckedChanged
      Try
         If rbtNoOkCalidad.Checked Then
            Me.txtFecha5SCalidad.Text = Date.Now().ToString()
            Me.txtUsuario5SCalidad.Text = actual.Nombre
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabar5S_Click(sender As Object, e As EventArgs) Handles tsbGrabar5S.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.Grabar5S()
         Me.RecargarGrillas()
         '  Me.CargarListasControl(True)
         Me.tsbGrabar5S.Enabled = False
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub rbtNoOkCalidad_Click(sender As Object, e As EventArgs) Handles rbtOkCalidad.Click, rbtNoOkCalidad.Click, rbtNoOk.Click, rbtOk.Click
      Try
         Me.tsbFinalizarLista.Enabled = False
         Me.tsbGrabar.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabarProducto_Click(sender As Object, e As EventArgs) Handles tsbGrabarProducto.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.GrabarProducto()
         Me.CargaProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimirCertificado_Click(sender As Object, e As EventArgs) Handles tsbImprimirCertificado.Click
      Try

         If Me.ugListasControl.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Dim dt As DataTable

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.bdsListasControl.DataSource, DataTable)

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", Me.txtNroCertificado.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me.txtFechaCertificado.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Usuario", Me.txtUsuarioCertificado.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdProducto", Me.bscCodigoProducto2.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Producto", Me.bscProducto2.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cliente", Me.txtNombreCliente.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cliente", Me.txtNombreCliente.Text))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Direccion,
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Localidad.NombreLocalidad,
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Localidad.IdLocalidad,
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Localidad.IdProvincia)))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoEmpresa", Eniac.Entidades.Usuario.Actual.Sucursal.Correo))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", Eniac.Entidades.Usuario.Actual.Sucursal.Telefono))

         Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
         Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))

         Dim frmImprime As VisorReportes


         frmImprime = New VisorReportes("Eniac.Win.Certificado.rdlc", "dtsCalidad_Certificado", dt, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub

   Private Sub tsbEmitirCertificado_Click(sender As Object, e As EventArgs) Handles tsbEmitirCertificado.Click
      Try
         Dim entro As Boolean = False
         Dim Lista As Entidades.ListaControl = New Entidades.ListaControl()
         Dim TipoLista As Entidades.ListaControlTipo = New Entidades.ListaControlTipo

         For Each dr As UltraGridRow In Me.ugListasControl.Rows
            Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr.Cells("IdListaControl").Value.ToString()))
            TipoLista = New Reglas.ListasControlTipos().GetUno(Lista.IdListaControlTipo)
            ' If Not Lista.HabilitaFechaLiberadoPDI Then
            If TipoLista.VisiblePanelControl Then
               If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> Reglas.Publicos.EstadoListaControlTerminado Then
                  entro = True
                  Exit For
               End If
            End If
            ' End If
         Next
         If entro Then
            MessageBox.Show("No podrá emitir el certificado, no estan todas las Listas de Control terminadas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Else
            Dim NroCertificado As Integer = New Reglas.ListasControlProductos().GetProximoNroCertificado()
            Me.txtNroCertificado.Text = NroCertificado.ToString()
            Me.txtFechaCertificado.Text = Date.Now().ToString()
            Me.txtUsuarioCertificado.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id
            Me.tsbEmitirCertificado.Enabled = False

            Me.GrabarProducto()
            Me.CargaProducto()

            MessageBox.Show("Información grabada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugProductoListasControl_KeyUp(sender As Object, e As KeyEventArgs) Handles ugProductoListasControl.KeyUp
      Try
         If ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True Then
            If e.KeyCode = Keys.Space Then
               If Me.ugProductoListasControl.ActiveCell.Column.Key = _Ok Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NoOk Or Me.ugProductoListasControl.ActiveCell.Column.Key = _Obs Or Me.ugProductoListasControl.ActiveCell.Column.Key = _Mat Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NA Then
                  If Not Boolean.Parse(Me.ugProductoListasControl.ActiveCell.Value.ToString()) Then
                     For Each cell As UltraGridCell In ugProductoListasControl.ActiveRow.Cells
                        If cell.Column.Style = ColumnStyle.CheckBox And (Me.ugProductoListasControl.ActiveCell.Column.Key = _Ok Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NoOk Or Me.ugProductoListasControl.ActiveCell.Column.Key = _Obs Or Me.ugProductoListasControl.ActiveCell.Column.Key = _Mat Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NA) _
                             And Not (cell.Column.Key = _OkCalidad Or cell.Column.Key = _NoOkCalidad Or cell.Column.Key = _ObsCalidad Or cell.Column.Key = _MatCalidad Or cell.Column.Key = _NACalidad) _
                             And Me.ugProductoListasControl.ActiveCell.Column.Key <> cell.Column.Key Then
                           cell.Value = False
                        Else
                           Me.ugProductoListasControl.ActiveCell.Value = True
                        End If
                     Next
                  Else
                     Me.ugProductoListasControl.ActiveCell.Value = False
                  End If
                  ugProductoListasControl.PerformAction(UltraGridAction.ExitEditMode)
               End If

               If Me.ugProductoListasControl.ActiveCell.Column.Key = _OkCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NoOkCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _ObsCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _MatCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NACalidad Then
                  If Not Boolean.Parse(Me.ugProductoListasControl.ActiveCell.Value.ToString()) Then
                     For Each cell As UltraGridCell In ugProductoListasControl.ActiveRow.Cells
                        If cell.Column.Style = ColumnStyle.CheckBox And (Me.ugProductoListasControl.ActiveCell.Column.Key = _OkCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NoOkCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _ObsCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _MatCalidad Or Me.ugProductoListasControl.ActiveCell.Column.Key = _NACalidad) _
                         And Not (cell.Column.Key = _Ok Or cell.Column.Key = _NoOk Or cell.Column.Key = _Obs Or cell.Column.Key = _Mat Or cell.Column.Key = _NA) _
                         And Me.ugProductoListasControl.ActiveCell.Column.Key <> cell.Column.Key Then
                           cell.Value = False
                        Else
                           Me.ugProductoListasControl.ActiveCell.Value = True
                        End If
                     Next
                  Else
                     Me.ugProductoListasControl.ActiveCell.Value = False
                  End If
                  ugProductoListasControl.PerformAction(UltraGridAction.ExitEditMode)
               End If

               Me.ugProductoListasControl.ActiveCell.Row.Cells("Modif").Value = True
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaEntReProgramada_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEntReProgramada.CheckedChanged
      Try
         Me.dtpEntReProgramada.Enabled = Me.chbFechaEntReProgramada.Checked
         If Not Me.chbFechaEntReProgramada.Checked Then
            Me.dtpEntReProgramada.Value = Date.Now()
            _Producto.CalidadFechaEntReProg = Nothing
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbFechaLiberadoPDI_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaLiberadoPDI.CheckedChanged
      Try

         Me.dtpLiberadoPDI.Enabled = Me.chbFechaLiberadoPDI.Checked
         Me.txtUsuarioLiberadoPDI.Enabled = Me.chbFechaLiberadoPDI.Checked

         If Not Me.chbFechaLiberadoPDI.Checked Then
            Me.dtpLiberadoPDI.Value = Date.Now()
            Me.txtUsuarioLiberadoPDI.Text = ""
            _Producto.CalidadStatusLiberadoPDI = False
            _Producto.CalidadFechaLiberadoPDI = Nothing
            _Producto.CalidadUserLiberadoPDI = Nothing
         Else

            Dim EstadoFinalizado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlTerminado)
            Dim entro As Boolean = False
            Dim Lista As Entidades.ListaControl = New Entidades.ListaControl()
            Dim TipoLista As Entidades.ListaControlTipo = New Entidades.ListaControlTipo

            For Each dr As UltraGridRow In ugListasControl.Rows
               Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr.Cells("IdListaControl").Value.ToString()))
               TipoLista = New Reglas.ListasControlTipos().GetUno(Lista.IdListaControlTipo)
               If TipoLista.VisiblePanelControl Then
                  If Not Lista.HabilitaFechaLiberado Then
                     If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> EstadoFinalizado.IdEstadoCalidad Then
                        entro = True
                     End If
                  End If
               End If
            Next
            If entro Then
               ShowMessage("Hay Listas que no estan Terminadas, no podrá ingresar fecha Liberado PDI.")
               Me.chbFechaLiberadoPDI.Checked = False
               Exit Sub
            Else
               Me.txtUsuarioLiberadoPDI.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id
            End If

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEmitirCertificadoEntrega_Click(sender As Object, e As EventArgs) Handles tsbEmitirCertificadoEntrega.Click
      Try

         If _Producto.CalidadFechaLiberado = Nothing Then
            MessageBox.Show("No podrá emitir el certificado de Entregado, el coche no tiene fecha de Liberado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         If _Producto.CalidadFecCertificado = Nothing Then
            MessageBox.Show("No podrá emitir el certificado de Entregado, el coche no tiene Certificado de calidad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If
         If _Producto.CalidadFechaLiberadoPDI = Nothing Then
            MessageBox.Show("No podrá emitir el certificado de Entregado, el coche no tiene Fecha de Liberado PDI.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         Dim EstadoFinalizado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlTerminado)
         Dim entro As Boolean = False

         For Each dr As UltraGridRow In ugListasControl.Rows
            If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) <> EstadoFinalizado.IdEstadoCalidad Then
               entro = True
            End If
         Next
         If entro Then
            ShowMessage("No podrá emitir el certificado de Entregado, hay Listas que no estan Terminadas.")
            Exit Sub
         End If

         Dim Obs As CertificadoEntregaObservacion = New CertificadoEntregaObservacion
         Obs.ShowDialog()

         If Obs.DialogResult = DialogResult.OK Then
            If Obs.NroRemito <> 0 Then
               Dim NroCertificado As Integer = New Reglas.ListasControlProductos().GetProximoNroCertEntregado()
               Me.txtNroCertEntregado.Text = NroCertificado.ToString()
               Me.txtFechaCertEntregado.Text = Date.Now().ToString()
               Me.txtUsuarioCertEntregado.Text = New Reglas.Usuarios().GetUno(actual.Nombre).Id
               Me.txtObservacionCertEntrega.Text = Obs.Observacion
               Me.txtNroRemito.Text = Obs.NroRemito.ToString()

               Me.tsbEmitirCertificadoEntrega.Enabled = False
               _Producto.CalidadStatusEntregado = True
               _Producto.CalidadFechaEntregado = Date.Now
               _Producto.CalidadUserEntregado = New Reglas.Usuarios().GetUno(actual.Nombre).Id
               _Producto.CalidadNroCertEObs = Obs.Observacion
               _Producto.CalidadNroRemito = Obs.NroRemito

               Me.GrabarProducto()
               Me.CargaProducto()

               MessageBox.Show("Información grabada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
               MessageBox.Show("Debe ingresar Nro de Remito del Certificado!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Exit Sub
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimirCertificadoEntrega_Click(sender As Object, e As EventArgs) Handles tsbImprimirCertificadoEntrega.Click
      Try

         If Me.ugListasControl.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = String.Empty

         Dim dt As DataTable
         Dim datos As DataRow()
         Dim dt2 As DataTable = New DataTable

         Me.Cursor = Cursors.WaitCursor

         dt = DirectCast(Me.bdsProductosListasControl.DataSource, DataTable)

         datos = dt.Select(String.Format("{0} = 72", Entidades.ListaControl.Columnas.IdListaControl.ToString()))

         If datos.Count <> 0 Then
            dt2 = datos.CopyToDataTable()
         End If


         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Numero", Me.txtNroCertEntregado.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me.dtpEntregado.Value.ToString()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Usuario", Me.txtUsuarioCertEntregado.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("IdProducto", Me.bscCodigoProducto2.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Producto", Me.bscProducto2.Text))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cliente", Me.txtNombreCliente.Text))
         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cliente", Me.txtNombreCliente.Text))
         Dim Producto As Entidades.Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.ToString())
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CalidadNumeroChasis", Producto.CalidadNumeroChasis))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CalidadNroDeMotor", Producto.CalidadNroDeMotor))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", Producto.CalidadNroCertEObs))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroRemito", Producto.CalidadNroRemito.ToString()))



         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionEmpresa", String.Format("{0}, {1} ({2}), {3}",
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Direccion,
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Localidad.NombreLocalidad,
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Localidad.IdLocalidad,
                                                                                                  Eniac.Entidades.Usuario.Actual.Sucursal.Localidad.IdProvincia)))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoEmpresa", Eniac.Entidades.Usuario.Actual.Sucursal.Correo))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoEmpresa", Eniac.Entidades.Usuario.Actual.Sucursal.Telefono))

         Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()
         Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))

         Dim frmImprime As VisorReportes


         frmImprime = New VisorReportes("Eniac.Win.CertificadoEntreg.rdlc", "dtsCalidad_CertificadoEntrega", dt2, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = Me.Text
         frmImprime.WindowState = FormWindowState.Maximized
         frmImprime.DisplayModeInicial = Microsoft.Reporting.WinForms.DisplayMode.PrintLayout
         frmImprime.rvReporte.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      End Try
   End Sub


#End Region

#Region "Metodos"
   Private Sub AgregarLinkProducto()

      Dim Link As Entidades.ProductoLinks = New Entidades.ProductoLinks()
      Link.IdProducto = Me.bscCodigoProducto2.Text

      Using frm As Link = New Link(Link)
         frm.StateForm = Win.StateForm.Insertar
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ugLinksProductos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      End Using

   End Sub

   Private Sub AgregarLinkItem()

      Dim Link As Entidades.ListaControlItemLinks = New Entidades.ListaControlItemLinks()
      Link.IdListaControl = Integer.Parse(Me.ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString())
      Link.Item = Integer.Parse(Me.ugProductoListasControl.ActiveRow.Cells("Item").Value.ToString())

      Using frm As LinkItemListaControl = New LinkItemListaControl(Link)
         frm.StateForm = Win.StateForm.Insertar
         If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ugLinksProductos.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      End Using

   End Sub

   Private Sub CargarListasControl(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then

         _dtListasControl = New Reglas.ListasControlProductos().GetListasControlxProductoRoles(Me.bscCodigoProducto2.Text, _Roles)
         
         bdsListasControl.DataSource = _dtListasControl

         For Each dr As UltraGridRow In Me.ugListasControl.Rows
            If Not Boolean.Parse(dr.Cells("Hab").Value.ToString()) Then
               dr.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled
            End If
         Next

         Me.FormateaGrillaListasControl()

      End If
   End Sub

   Private Sub CargarItemsListasControl(tablaVacia As Boolean)
      If Me.bscProducto2.Selecciono Or bscCodigoProducto2.Selecciono Then

         _dtItemsListasControl = New Reglas.ListasControlProductosItems().GetListasControlxProductoRoles(Me.bscCodigoProducto2.Text.ToString().Trim(), _Roles)

         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtItemsListasControl

         FormateaGrillaListasControlItems()

      End If
   End Sub

   Private Sub CargarItemsListasControlAuditoria(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtItemsListasControlAuditoria = New Reglas.ListasControlProductosItems().GetListasControlxProducto_Auditoria(Me.bscCodigoProducto2.Text.ToString().Trim())
         bdItemsListasControlAuditoria.DataSource = _dtItemsListasControlAuditoria
         ' Me.FormateaGrillaListasControlItemsAuditoria()
      End If
   End Sub

   Private Sub CargarListasControlAuditoria(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtListasControlAuditoria = New Reglas.ListasControlProductos().GetListasControlxProducto_Auditoria(Me.bscCodigoProducto2.Text.ToString().Trim())
         bdsListasControlAuditoria.DataSource = _dtListasControlAuditoria
         Me.FormateaGrillaListasControlAuditoria()
      End If
   End Sub

   Private Sub ControlaCambios()
      If Me.tsbGrabar.Enabled Then
         If ShowPregunta("¿Desea grabar los cambios?") = Windows.Forms.DialogResult.Yes Then
            Me.Grabar()
         End If
      End If
   End Sub

   Private Sub Grabar()

      Me.GrabarProducto()

      Dim Producto As Entidades.Producto

      Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)

      Dim rListasControlProductos As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems()

      Me._dtItemsListasControl.AcceptChanges()

      If _ListaControl Is Nothing Then
         _ListaControl = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, Integer.Parse(Me.ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()))
      End If

      If tsbIniciarLista.Text = "Reabrir Lista" And txtObservacionLista.Text = "" And spcDatos.Enabled And _ListaControl.IdEstadoCalidad <> Reglas.Publicos.EstadoListaControlTerminado Then
         tbcVarios.SelectedTab = tbpObservacionLista
         MessageBox.Show("Debe ingresar observación al Reabrir una Lista de Control.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Me.txtObservacionLista.Focus()
         Exit Sub
      Else
         _ListaControl.Observacion = Me.txtObservacionLista.Text
      End If

      If rbtOk.Checked Then
         _ListaControl.CincoS = rbtOk.Text.ToString()
      End If

      If rbtNoOk.Checked Then
         _ListaControl.CincoS = rbtNoOk.Text.ToString()
      End If

      If Not String.IsNullOrEmpty(Me.txtFecha5S.Text.ToString()) Then
         _ListaControl.CincoSFecha = DateTime.Parse(Me.txtFecha5S.Text.ToString())
         _ListaControl.CincoSUsr = Me.txtUsuario5S.Text
      End If
      _ListaControl.CincoSComment = Me.txtComentario5S.Text

      If rbtOkCalidad.Checked Then
         _ListaControl.CincoSC = rbtOkCalidad.Text.ToString()
      End If

      If rbtNoOkCalidad.Checked Then
         _ListaControl.CincoSC = rbtNoOkCalidad.Text.ToString()
      End If

      If Not String.IsNullOrEmpty(Me.txtFecha5SCalidad.Text.ToString()) Then
         _ListaControl.CincoSFechaC = DateTime.Parse(Me.txtFecha5SCalidad.Text.ToString())
         _ListaControl.CincoSUsrC = Me.txtUsuario5SCalidad.Text

      End If
      _ListaControl.CincoSCommentC = Me.txtComentario5SCalidad.Text


      rListasControlProductos.Guardar(Producto, Me._dtItemsListasControl, _ListaControl, _ListaControlSiguiente)

      Me.Cursor = Cursors.Default
      ' MessageBox.Show("Información grabada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.spcDatos.Panel1.Enabled = True

      '  Me.Grabar5S()

      MessageBox.Show("Información grabada exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      RecargarGrillas()

      If chbFechaIngreso.Checked Then
         spcDatos.Enabled = True
      End If

   End Sub

   Private Sub GrabarLista()

      Dim Producto As Entidades.Producto
      Dim rListasControlProductos As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems()

      Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text)

      If _ListaControl Is Nothing Then
         _ListaControl = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, Integer.Parse(Me.ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()))
      End If


      rListasControlProductos.GuardarListaControl(Producto, _ListaControl)

   End Sub

   Private Sub Grabar5S()

      Dim rListasControlProductos As Reglas.ListasControlProductos = New Reglas.ListasControlProductos()

      _ListaControl = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, Integer.Parse(Me.ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()))

      If rbtOk.Checked Then
         _ListaControl.CincoS = rbtOk.Text.ToString()
      End If

      If rbtNoOk.Checked Then
         _ListaControl.CincoS = rbtNoOk.Text.ToString()
      End If

      If Not String.IsNullOrEmpty(Me.txtFecha5S.Text.ToString()) Then
         _ListaControl.CincoSFecha = DateTime.Parse(Me.txtFecha5S.Text.ToString())
         _ListaControl.CincoSUsr = Me.txtUsuario5S.Text
      End If
      _ListaControl.CincoSComment = Me.txtComentario5S.Text

      If rbtOkCalidad.Checked Then
         _ListaControl.CincoSC = rbtOkCalidad.Text.ToString()
      End If

      If rbtNoOkCalidad.Checked Then
         _ListaControl.CincoSC = rbtNoOkCalidad.Text.ToString()
      End If

      If Not String.IsNullOrEmpty(Me.txtFecha5SCalidad.Text.ToString()) Then
         _ListaControl.CincoSFechaC = DateTime.Parse(Me.txtFecha5SCalidad.Text.ToString())
         _ListaControl.CincoSUsrC = Me.txtUsuario5SCalidad.Text

      End If
      _ListaControl.CincoSCommentC = Me.txtComentario5SCalidad.Text

      rListasControlProductos.Guardar(_ListaControl)

      Me.Cursor = Cursors.Default

      Me.spcDatos.Panel1.Enabled = True

      Me.tsbGrabar5S.Enabled = False

   End Sub

   Private Sub GrabarProducto()


      If Me.txtFechaCertificado.Text <> "" Then
         _Producto.CalidadFecCertificado = Date.Parse(Me.txtFechaCertificado.Text.ToString())
         _Producto.CalidadUsrCertificado = Me.txtUsuarioCertificado.Text
      End If

      If Me.txtFechaCertEntregado.Text <> "" Then
         _Producto.CalidadFecCertEntregado = Date.Parse(Me.txtFechaCertEntregado.Text.ToString())
         _Producto.CalidadUsrCertEntregado = Me.txtUsuarioCertEntregado.Text
         _Producto.CalidadNroCertEObs = Me.txtObservacionCertEntrega.Text
      End If

      If Me.chbFechaIngreso.Checked Then
         _Producto.CalidadFechaIngreso = Me.dtpIngreso.Value
      End If

      If Me.chbFechaEgreso.Checked Then
         _Producto.CalidadFechaEgreso = Me.dtpEgreso.Value
      End If

      If Me.chbFechaPreEntrega.Checked Then
         _Producto.CalidadFechaPreEnt = Me.dtpPreentrega.Value
      End If

      If Me.chbFechaEntProgramada.Checked Then
         _Producto.CalidadFechaEntProg = Me.dtpEntProgramada.Value
      End If

      If Me.chbFechaEntReProgramada.Checked Then
         _Producto.CalidadFechaEntReProg = Me.dtpEntReProgramada.Value
      End If

      If Me.chbFechaEntregado.Checked Then
         _Producto.CalidadStatusEntregado = True
         _Producto.CalidadFechaEntregado = Me.dtpEntregado.Value
         _Producto.CalidadUserEntregado = Me.txtUsuarioEntregado.Text
      End If

      If Me.chbFechaLiberado.Checked Then
         _Producto.CalidadStatusLiberado = True
         _Producto.CalidadFechaLiberado = Me.dtpLiberado.Value
         _Producto.CalidadUserLiberado = Me.txtUsuarioLiberado.Text
      End If

      If Me.chbFechaLiberadoPDI.Checked Then
         _Producto.CalidadStatusLiberadoPDI = True
         _Producto.CalidadFechaLiberadoPDI = Me.dtpLiberadoPDI.Value
         _Producto.CalidadUserLiberadoPDI = Me.txtUsuarioLiberadoPDI.Text
      End If

      _Producto.CalidadObservaciones = Me.txtObservacion.Text

      If Me.txtNroCertificado.Text <> "" Then
         _Producto.CalidadNroCertificado = Integer.Parse(Me.txtNroCertificado.Text.ToString())
      End If

      If Me.txtNroCertEntregado.Text <> "" Then
         _Producto.CalidadNroCertEntregado = Integer.Parse(Me.txtNroCertEntregado.Text.ToString())
      End If


      Dim rProductos As Reglas.Productos = New Reglas.Productos()
      rProductos.Actualizar(_Producto, IdFuncion)

      Me.Cursor = Cursors.Default

      Me.CargaProducto()

   End Sub

   Private Sub RefrescarGrilla()

      If bscCodigoProducto2.Text <> "" Then
         If Me._dtListasControl IsNot Nothing Then
            If Me._dtListasControl.Rows.Count <> 0 Then
               Me._dtListasControl.Clear()
               Me._dtItemsListasControl.Clear()
               Me._dtItemsListasControlAuditoria.Clear()
               Me._dtLinksProductos.Clear()
               Me._dtLinksListasControl.Clear()
               Me._dtListasControlAuditoria.Clear()
            End If
         End If
      End If

      Me.bscCodigoProducto2.Enabled = True
      Me.bscProducto2.Enabled = True
      Me.bscCodigoProducto2.Text = ""
      Me.bscProducto2.Text = ""
      Me.txtCodigoCliente.Text = ""
      Me.txtNombreCliente.Text = ""
      Me.txtClienteFantasia.Text = ""
      Me.chbFechaEgreso.Checked = False
      Me.chbFechaEntProgramada.Checked = False
      Me.chbFechaEntregado.Checked = False
      Me.chbFechaIngreso.Checked = False
      Me.chbFechaLiberado.Checked = False
      Me.chbFechaLiberadoPDI.Checked = False
      Me.chbFechaPreEntrega.Checked = False
      Me.txtObservacion.Text = ""
      Me.txtNroCertificado.Text = ""
      Me.txtNroCertEntregado.Text = ""
      Me.txtFechaCertificado.Text = ""
      Me.txtFechaCertEntregado.Text = ""
      Me.txtUsuarioCertificado.Text = ""
      Me.txtUsuarioCertEntregado.Text = ""
      Me.tsbIniciarLista.Enabled = False
      Me.tsbFinalizarLista.Enabled = False
      Me.tsbGrabar.Enabled = False
      Me.tsbGrabarProducto.Enabled = False
      Me.tsbGrabar5S.Enabled = False
      Me.tsbImprimirCertificado.Enabled = False
      Me.tsbEmitirCertificado.Enabled = False
      Me.tsbEmitirCertificadoEntrega.Enabled = False
      Me.tsbImprimirCertificadoEntrega.Enabled = False
      Me.tsbFInalizarListas.Enabled = True
      Me.spcDatos.Panel1.Enabled = True
      Me.txtFechaCertEntregado.Text = ""
      Me.txtUsuarioCertEntregado.Text = ""
      Me.txtObservacionCertEntrega.Text = ""
      Me.txtNroRemito.Text = ""

      Me._ListaControl = Nothing
      Me._ListaControlSiguiente = Nothing

      grp5SCalidad.Enabled = False
      grp5S.Enabled = False
      grpCertificado.Enabled = False

      tbcProducto.TabPages("TbpFechas").Enabled = False

      Me.spcDatos.Panel2.Enabled = True

      tbcVarios.SelectedTab = tbpItems
      tbcProducto.SelectedTab = TbpFechas
      Me.txtUbicacion.Text = ""
      '  tbcProducto.TabPages("TbpFechas").Enabled = _PermisosCalidad
      Me.Refrescar5S()
      Me.bscCodigoProducto2.Focus()
      spcDatos.Enabled = True

   End Sub

   Private Sub Refrescar5S()
      Me.rbtOk.Checked = False
      Me.rbtNoOk.Checked = False
      Me.rbtOkCalidad.Checked = False
      Me.rbtNoOkCalidad.Checked = False
      Me.txtFecha5S.Text = ""
      Me.txtFecha5SCalidad.Text = ""
      Me.txtUsuario5S.Text = ""
      Me.txtUsuario5SCalidad.Text = ""
      Me.txtComentario5S.Text = ""
      Me.txtComentario5SCalidad.Text = ""
      Me.txtObservacionLista.Text = ""
   End Sub

   Private Sub FormateaGrillaListasControl()
      FormateaGrillaListasControl(Me.ugListasControl)
   End Sub

   Private Sub FormateaGrillaListasControlItems()
      FormateaGrillaListasControlItems(Me.ugProductoListasControl)
   End Sub

   Private Sub FormateaGrillaProductosLinks()
      FormateaGrillaProductosLinks(Me.ugLinksProductos)
   End Sub

   Private Sub FormateaGrillaProductosListasControl()
      FormateaGrillaProductosLinks(Me.ugLinksProductos)
   End Sub

   Private Sub FormateaGrillaListasControlLinks()
      FormateaGrillaProductosLinks(Me.ugLinksItems)
   End Sub

   Private Sub FormateaGrillaListasControlItemsAuditoria()
      FormateaGrillaListasControlItemsAuditoria(Me.ugdItemsListasControlAuditoria)
   End Sub

   Private Sub FormateaGrillaListasControlAuditoria()
      FormateaGrillaListasControlAuditoria(Me.ugdListasControlAuditoria)
   End Sub

   Private Sub FormateaGrillaProductosLinks(grilla As UltraGrid)
      Dim col As Integer = 0
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Descripcion"), "Descripción", col, 150)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Link"), "Link", col, 300)
         .Columns(Entidades.ProductoLinks.Columnas.Link.ToString()).Style = ColumnStyle.URL

      End With

   End Sub

   Private Sub FormateaGrillaItemsLinks(grilla As UltraGrid)
      Dim col As Integer = 0
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Descripcion"), "Descripción", col, 150)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Link"), "Link", col, 300)
         .Columns(Entidades.ProductoLinks.Columnas.Link.ToString()).Style = ColumnStyle.URL

      End With

   End Sub

   Private Sub FormateaGrillaListasControl(grilla As UltraGrid)
      Dim col As Integer = 0


      ' Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"Nombre"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Hab"), "Hab.", col, 40)
         .Columns("Hab").Style = ColumnStyle.CheckBox
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreEstadoCalidad"), "Estado", col, 84)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70, , True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Lista de Control", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 60, HAlign.Right)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Aplica.ToString()), "Aplica", col, 60)
         '.Columns(Entidades.ListaControlProducto.Columnas.Aplica.ToString()).Style = ColumnStyle.CheckBox

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()), "Ingreso", col, 80, HAlign.Center)
         '  .Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).CellActivation = Activation.AllowEdit
         .Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).Style = ColumnStyle.DropDownCalendar

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()), "Egreso", col, 80, HAlign.Center)
         '  .Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).CellActivation = Activation.AllowEdit
         .Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).Style = ColumnStyle.DropDownCalendar
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Dias"), "Dias Transcurridos", col, 80, HAlign.Right)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("DiasMaximoProceso"), "Dias Maximos", col, 80, HAlign.Right)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Diferencia"), "Diferencia", col, 80, HAlign.Right)

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoS.ToString()), "5S Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSUsr.ToString()), "5S Usuario Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString()), "5S Fecha Producción", col, 80, HAlign.Center)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSC.ToString()), "5S Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString()), "5S Usuario Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString()), "5S Fecha Calidad", col, 80, HAlign.Center)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSCommentC.ToString()), "5S Comentario Calidad", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSComment.ToString()), "5S Comentario Producción", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Observacion.ToString()), "Observación", col, 300)

         '  Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.fecha.ToString()), "Fecha Alta", col, 80, , , , , Activation.AllowEdit)
         '  Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Idusuario.ToString()), "Usuario", col, 80)

      End With



      Dim color As Color = SystemColors.Control
      For Each dr As UltraGridRow In Me.ugListasControl.Rows
         If IsNumeric(dr.Cells("Color").Value) Then
            color = Drawing.Color.FromArgb(Integer.Parse(dr.Cells("Color").Value.ToString()))
            dr.Cells("NombreEstadoCalidad").Appearance.BackColor = color
            dr.Cells("NombreEstadoCalidad").ActiveAppearance.BackColor = color
            dr.Cells("NombreEstadoCalidad").ActiveAppearance.ForeColor = Drawing.Color.Black
         End If
      Next

   End Sub

   Private Sub FormateaGrillaListasControlItems(grilla As UltraGrid)
      Dim col As Integer = 0

      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControlItem"), "Items", col, 400)
         .Columns("Ok").CellActivation = Activation.NoEdit

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Ok"), "Ok", col, 40)
         .Columns("Ok").Style = ColumnStyle.CheckBox
         If _PermisosProduccion Then
            .Columns("Ok").CellActivation = Activation.AllowEdit
         Else
            .Columns("Ok").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NoOk"), "No Ok", col, 40)
         .Columns("NoOk").Style = ColumnStyle.CheckBox
         If _PermisosProduccion Then
            .Columns("NoOk").CellActivation = Activation.AllowEdit
         Else
            .Columns("NoOk").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Obs"), "Obs", col, 40)
         .Columns("Obs").Style = ColumnStyle.CheckBox
         If _PermisosProduccion Then
            .Columns("Obs").CellActivation = Activation.AllowEdit
         Else
            .Columns("Obs").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Mat"), "Mat", col, 40)
         .Columns("Mat").Style = ColumnStyle.CheckBox
         If _PermisosProduccion Then
            .Columns("Mat").CellActivation = Activation.AllowEdit
         Else
            .Columns("Mat").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NA"), "NA", col, 40)
         .Columns("NA").Style = ColumnStyle.CheckBox
         If _PermisosProduccion Then
            .Columns("NA").CellActivation = Activation.AllowEdit
         Else
            .Columns("NA").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Observ"), "Observaciones", col, 150)
         If _PermisosProduccion Then
            .Columns("Observ").CellActivation = Activation.AllowEdit
         Else
            .Columns("Observ").CellActivation = Activation.Disabled
         End If

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("OkCalidad"), "Ok Cal", col, 40)
         .Columns("OkCalidad").Style = ColumnStyle.CheckBox
         .Columns("OkCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         If _PermisosCalidad Then
            .Columns("OkCalidad").CellActivation = Activation.AllowEdit
         Else
            .Columns("OkCalidad").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NoOkCalidad"), "No Ok Cal", col, 40)
         .Columns("NoOkCalidad").Style = ColumnStyle.CheckBox
         .Columns("NoOkCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         If _PermisosCalidad Then
            .Columns("NoOkCalidad").CellActivation = Activation.AllowEdit
         Else
            .Columns("NoOkCalidad").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("ObsCalidad"), "Obs Cal", col, 40)
         .Columns("ObsCalidad").Style = ColumnStyle.CheckBox
         .Columns("ObsCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         If _PermisosCalidad Then
            .Columns("ObsCalidad").CellActivation = Activation.AllowEdit
         Else
            .Columns("ObsCalidad").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("MatCalidad"), "Mat Cal", col, 40)
         .Columns("MatCalidad").Style = ColumnStyle.CheckBox
         .Columns("MatCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         If _PermisosCalidad Then
            .Columns("MatCalidad").CellActivation = Activation.AllowEdit
         Else
            .Columns("MatCalidad").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NACalidad"), "NA Cal", col, 40)
         .Columns("NACalidad").Style = ColumnStyle.CheckBox
         .Columns("NACalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         If _PermisosCalidad Then
            .Columns("NACalidad").CellActivation = Activation.AllowEdit
         Else
            .Columns("NACalidad").CellActivation = Activation.Disabled
         End If
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("ObservCalidad"), "Observaciones Calidad", col, 150)
         .Columns("ObservCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         If _PermisosCalidad Then
            .Columns("ObservCalidad").CellActivation = Activation.AllowEdit
         Else
            .Columns("ObservCalidad").CellActivation = Activation.Disabled
         End If

      End With

      ugProductoListasControl.AgregarFiltroEnLinea({"NombreListaControlItem"}, {})

   End Sub

   Private Sub FormateaGrillaListasControlItemsAuditoria(grilla As UltraGrid)
      Dim col As Integer = 0
      '  Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControlItem"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FechaAuditoria"), "Fecha Mod.", col, 100, , , "dd/MM/yyyy HH:mm")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("UsuarioAuditoria"), "Usuario", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("OperacionAuditoria"), "Operación", col, 80)

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Ok"), "Ok", col, 30)
         .Columns("Ok").Style = ColumnStyle.CheckBox
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NoOk"), "No Ok", col, 30)
         .Columns("NoOk").Style = ColumnStyle.CheckBox
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Obs"), "Obs", col, 30)
         .Columns("Obs").Style = ColumnStyle.CheckBox
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Mat"), "Mat", col, 30)
         .Columns("Mat").Style = ColumnStyle.CheckBox
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NA"), "NA", col, 30)
         .Columns("NA").Style = ColumnStyle.CheckBox
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Observ"), "Observaciones", col, 150)

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("OkCalidad"), "Ok Cal", col, 30)
         .Columns("OkCalidad").Style = ColumnStyle.CheckBox
         .Columns("OkCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NoOkCalidad"), "No Ok Cal", col, 30)
         .Columns("NoOkCalidad").Style = ColumnStyle.CheckBox
         .Columns("NoOkCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("ObsCalidad"), "Obs Cal", col, 30)
         .Columns("ObsCalidad").Style = ColumnStyle.CheckBox
         .Columns("ObsCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("MatCalidad"), "Mat Cal", col, 30)
         .Columns("MatCalidad").Style = ColumnStyle.CheckBox
         .Columns("MatCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NACalidad"), "NA Cal", col, 30)
         .Columns("NACalidad").Style = ColumnStyle.CheckBox
         .Columns("NACalidad").CellAppearance.BackColor = Color.PaleGoldenrod
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("ObservCalidad"), "Observaciones Calidad", col, 150)
         .Columns("ObservCalidad").CellAppearance.BackColor = Color.PaleGoldenrod
      End With
   End Sub

   Private Sub FormateaGrillaListasControlAuditoria(grilla As UltraGrid)
      Dim col As Integer = 0
      '  Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"NombreListaControlItem"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FechaAuditoria"), "Fecha Mod.", col, 100, , , "dd/MM/yyyy HH:mm")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("UsuarioAuditoria"), "Usuario", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("OperacionAuditoria"), "Operación", col, 80)

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreEstadoCalidad"), "Estado", col, 84)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70, , True)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Lista de Control", col, 300)
         '   Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Orden"), "Orden", col, 60, HAlign.Right)
         'Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Aplica.ToString()), "Aplica", col, 60)
         '.Columns(Entidades.ListaControlProducto.Columnas.Aplica.ToString()).Style = ColumnStyle.CheckBox

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()), "Ingreso", col, 80)
         .Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).CellActivation = Activation.AllowEdit
         .Columns(Entidades.ListaControlProducto.Columnas.FecIngreso.ToString()).Style = ColumnStyle.DropDownCalendar

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()), "Egreso", col, 80)
         .Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).CellActivation = Activation.AllowEdit
         .Columns(Entidades.ListaControlProducto.Columnas.FecEgreso.ToString()).Style = ColumnStyle.DropDownCalendar

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoS.ToString()), "5S Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSUsr.ToString()), "5S Usuario Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSFecha.ToString()), "5S Fecha Producción", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSC.ToString()), "5S Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSUsrC.ToString()), "5S Usuario Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSFechaC.ToString()), "5S Fecha Calidad", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSCommentC.ToString()), "5S Comentario Calidad", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.CincoSComment.ToString()), "5S Comentario Producción", col, 300)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns(Entidades.ListaControlProducto.Columnas.Observacion.ToString()), "Observación", col, 300)

      End With
   End Sub

   Private Sub CargaProducto()


      Dim Cliente As DataTable = New Reglas.ProductosClientes().GetClientexProducto(_Producto.IdProducto)
      Dim Cli As Entidades.Cliente

      If Cliente.Rows.Count > 0 Then
         _idCliente = Long.Parse(Cliente.Rows(0).Item("IdCliente").ToString())
         Cli = New Reglas.Clientes().GetUno(_idCliente)
         Me.txtCodigoCliente.Text = Cli.CodigoCliente.ToString()
         Me.txtNombreCliente.Text = Cli.NombreCliente.ToString()
         Me.txtClienteFantasia.Text = Cli.NombreDeFantasia.ToString()
      End If

      If _Producto.CalidadFecCertificado <> Nothing Then
         Me.txtFechaCertificado.Text = _Producto.CalidadFecCertificado.ToString()
         Me.txtUsuarioCertificado.Text = _Producto.CalidadUsrCertificado
         Me.tsbImprimirCertificado.Enabled = _PermisosCalidad
      Else
         Me.tsbEmitirCertificado.Enabled = _PermisosCalidad
      End If

      If _Producto.CalidadFecCertEntregado <> Nothing Then
         Me.txtFechaCertEntregado.Text = _Producto.CalidadFecCertEntregado.ToString()
         Me.txtUsuarioCertEntregado.Text = _Producto.CalidadUsrCertEntregado
         Me.txtObservacionCertEntrega.Text = _Producto.CalidadNroCertEObs
         Me.tsbImprimirCertificadoEntrega.Enabled = _PermisosCalidad
      Else
         Me.tsbEmitirCertificadoEntrega.Enabled = _PermisosCalidad
      End If

      If _Producto.CalidadFechaIngreso <> Nothing Then

         Me.chbFechaIngreso.Checked = True
         Me.chbFechaIngreso.Enabled = True
         Me.dtpIngreso.Enabled = True

         Me.dtpIngreso.Value = _Producto.CalidadFechaIngreso

         'Controlo las listas si bloquean Fecha de Ingreso 
         Dim Lista As Entidades.ListaControl = New Entidades.ListaControl
         For Each dr1 As UltraGridRow In ugListasControl.Rows
            Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr1.Cells("IdListaControl").Value.ToString()))
            If Lista.BloqueaFechaIngreso AndAlso IsDate(dr1.Cells("FecIngreso").Value.ToString()) Then
               Me.chbFechaIngreso.Enabled = False
               Me.dtpIngreso.Enabled = False
               Exit For
            End If
         Next
      End If

      If _Producto.CalidadFechaEgreso <> Nothing Then
         Me.chbFechaEgreso.Checked = True
         Me.dtpEgreso.Enabled = True
         Me.dtpEgreso.Value = _Producto.CalidadFechaEgreso
      End If

      If _Producto.CalidadFechaPreEnt <> Nothing Then
         Me.chbFechaPreEntrega.Checked = True
         Me.dtpPreentrega.Enabled = True
         Me.dtpPreentrega.Value = _Producto.CalidadFechaPreEnt
      End If

      If _Producto.CalidadFechaEntProg <> Nothing Then
         Me.chbFechaEntProgramada.Checked = True
         Me.dtpEntProgramada.Enabled = True
         Me.dtpEntProgramada.Value = _Producto.CalidadFechaEntProg
      End If

      If _Producto.CalidadFechaEntReProg <> Nothing Then
         Me.chbFechaEntReProgramada.Checked = True
         Me.dtpEntReProgramada.Enabled = True
         Me.dtpEntReProgramada.Value = _Producto.CalidadFechaEntReProg
      End If

      Me.chbFechaEntregado.Enabled = False
      Me.dtpEntregado.Enabled = False
      If _Producto.CalidadStatusEntregado <> Nothing Then
         Me.chbFechaEntregado.Checked = True
         ' Me.dtpEntregado.Enabled = True
         Me.dtpEntregado.Value = _Producto.CalidadFechaEntregado
         Me.txtUsuarioEntregado.Text = _Producto.CalidadUserEntregado
      End If

      If _Producto.CalidadStatusLiberado <> Nothing Then
         Me.chbFechaLiberado.Checked = True
         Me.dtpLiberado.Enabled = True
         Me.dtpLiberado.Value = _Producto.CalidadFechaLiberado
         Me.txtUsuarioLiberado.Text = _Producto.CalidadUserLiberado
      End If

      'Me.dtpLiberadoPDI.Enabled = False
      'Me.chbFechaLiberadoPDI.Enabled = False
      If _Producto.CalidadStatusLiberadoPDI <> Nothing Then
         Me.chbFechaLiberadoPDI.Checked = True
         Me.dtpLiberadoPDI.Enabled = True
         Me.dtpLiberadoPDI.Value = _Producto.CalidadFechaLiberadoPDI
         Me.txtUsuarioLiberadoPDI.Text = _Producto.CalidadUserLiberadoPDI
      End If


      If _Producto.CalidadObservaciones <> Nothing Then
         Me.txtObservacion.Text = _Producto.CalidadObservaciones.ToString()
      End If

      If _Producto.CalidadNroCertificado <> Nothing Then
         Me.txtNroCertificado.Text = _Producto.CalidadNroCertificado.ToString()
      End If

      If _Producto.CalidadNroCertEntregado <> Nothing Then
         Me.txtNroCertEntregado.Text = _Producto.CalidadNroCertEntregado.ToString()
      End If

      If _Producto.CalidadNroRemito <> Nothing Then
         Me.txtNroRemito.Text = _Producto.CalidadNroRemito.ToString()
      End If

      Me.txtUbicacion.Text = _Producto.Ubicacion.ToString()

      Dim DesviosProductos As DataTable = New Reglas.ProductosExcepciones().GetExcepcionesxProducto(Me.bscCodigoProducto2.Text)
      Me.ugDesviosProductos.DataSource = DesviosProductos

   End Sub

   Private Sub CargarDatosProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()

      _Producto = New Reglas.Productos().GetUno(Me.bscCodigoProducto2.Text.ToString())

      CargaProducto()

      Me.bscCodigoProducto2.Enabled = False
      Me.bscProducto2.Enabled = False

      Me.tsbFInalizarListas.Enabled = False

      RecargarGrillas()
      grpCertificado.Enabled = _PermisosCabProducto

      Me.chbFechaLiberado.Enabled = _PermisoCalidadFinal
      'Me.dtpLiberado.Enabled = _PermisoCalidadFinal
      'Me.chbFechaLiberadoPDI.Enabled = _PermisoCalidadFinal
      'Me.dtpLiberadoPDI.Enabled = _PermisoCalidadFinal


      tbcProducto.TabPages("TbpFechas").Enabled = _PermisosCabProducto
      Me.tsbGrabar.Enabled = True

      If _Producto.CalidadFechaIngreso = Nothing Then
         MessageBox.Show("El Producto no tiene fecha de Ingreso, no podrá modificar las Listas de Control.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tsbEmitirCertificado.Enabled = False
         Me.tsbEmitirCertificadoEntrega.Enabled = False
         Me.bscCodigoProducto2.Focus()
         spcDatos.Enabled = False
         Me.tsbIniciarLista.Enabled = False
         Me.tsbFinalizarLista.Enabled = False
         If Not _PermisosCabProducto Then
            Me.tsbGrabar.Enabled = False
         End If
      Else
         ''Controlo las listas si bloquean Fecha de Ingreso 
         'Dim Lista As Entidades.ListaControl = New Entidades.ListaControl
         'For Each dr1 As UltraGridRow In ugListasControl.Rows
         '   Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr1.Cells("IdListaControl").Value.ToString()))
         '   If Lista.BloqueaFechaIngreso AndAlso IsDate(dr1.Cells("FecIngreso").Value.ToString()) Then
         '      Me.chbFechaIngreso.Enabled = False
         '      Me.dtpIngreso.Enabled = False
         '      Exit For
         '   End If
         'Next
      End If

      If _dtListasControl.Rows.Count = 0 Then
         MessageBox.Show("El Producto no tiene Listas de Control, debe Asignar las Listas de Control.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Me.tsbEmitirCertificado.Enabled = False
         Me.tsbEmitirCertificadoEntrega.Enabled = False
         Me.bscCodigoProducto2.Focus()
         spcDatos.Enabled = False
         Me.tsbIniciarLista.Enabled = False
         Me.tsbFinalizarLista.Enabled = False
         Me.tsbGrabar.Enabled = False
      End If

      'grp5SCalidad.Enabled = _Permisos5SCalidad
      'grp5S.Enabled = _Permisos5SProduccion


   End Sub

   Public Sub RecargarGrillas()

      _ListaControl = Nothing
      _ListaControlSiguiente = Nothing

      Me.CargarListasControl(True)
      Me.tssListasControlAsignar.Text = ugListasControl.Rows.Count.ToString() & " Registros"

      Me.CargarListasControlAuditoria(True)
      Me.Cargar5S()
      Me.CargarItemsListasControl(True)
      Me.CargarItemsListasControlAuditoria(True)
      Me.CargarLinksProductos(True)

      For Each dr As UltraGridRow In ugListasControl.Rows
         If Integer.Parse(dr.Cells("IdEstadoCalidad").Value.ToString()) = Reglas.Publicos.EstadoListaControlEnProceso Then
            If dr.Activation <> Activation.Disabled Then
               dr.Activated = True
               Exit For
            End If
         End If
      Next

      'Controlo las listas si bloquean Fecha de Ingreso 
      Dim Lista As Entidades.ListaControl = New Entidades.ListaControl
      For Each dr1 As UltraGridRow In ugListasControl.Rows
         Lista = New Reglas.ListasControl().GetUno(Integer.Parse(dr1.Cells("IdListaControl").Value.ToString()))
         If Lista.BloqueaFechaIngreso AndAlso IsDate(dr1.Cells("FecIngreso").Value.ToString()) Then
            Me.chbFechaIngreso.Enabled = False
            Me.dtpIngreso.Enabled = False
            Exit For
         End If
      Next

   End Sub

   Public Sub CargaItems()

      Dim drLista As DataRow = ugListasControl.FilaSeleccionada(Of DataRow)()

       If drLista IsNot Nothing Then

         ugProductoListasControl.DataSource = New DataView(_dtItemsListasControl,
                                           String.Format("{0} = {1}", Entidades.ListaControl.Columnas.IdListaControl.ToString(), drLista(Entidades.ListaControl.Columnas.IdListaControl.ToString())),
                                                         "", DataViewRowState.CurrentRows)

         Me.FormateaGrillaListasControlItems()
         '  Me.tssItemsListasControl.Text = ugProductoListasControl.Rows.Count.ToString() & " Registros"
         If ugProductoListasControl.Rows.Count = 0 Then
            ugdItemsListasControlAuditoria.DataSource = Nothing
         End If

         'Me.ugProductoListasControl.Enabled = Boolean.Parse(drLista("Hab").ToString())
         Me.ugProductoListasControl.DisplayLayout.Override.AllowUpdate = If(Boolean.Parse(drLista.Field(Of String)("Hab")), DefaultableBoolean.True, DefaultableBoolean.False)

         Me.tsbIniciarLista.Text = "Iniciar Lista"

         Dim Estado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(drLista.Field(Of Integer)(Entidades.ListaControlProducto.Columnas.IdEstadoCalidad.ToString()))
         Dim Lista As Entidades.ListaControl = New Reglas.ListasControl().GetUno(drLista.Field(Of Integer)(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()))

         If Estado.PorDefecto Or Estado.Finalizado Then

            '   Me.spcDatos.Panel2.Enabled = False
            ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

            ' Me.tsbGrabar.Enabled = True
            Me.tsbIniciarLista.Enabled = True
            Me.tsbFinalizarLista.Enabled = False

            If Estado.Finalizado Then
               Me.tsbIniciarLista.Text = "Reabrir Lista"
            End If

         ElseIf Estado.IdEstadoCalidad = Reglas.Publicos.EstadoListaControlEnProceso Then

            Me.ControlaPermisosLista(drLista)

            Me.ugProductoListasControl.DisplayLayout.Override.AllowUpdate = If(Boolean.Parse(drLista.Field(Of String)("Hab")), DefaultableBoolean.True, DefaultableBoolean.False)

            '     Me.spcDatos.Panel2.Enabled = True
            'If _PermisosProduccion Then
            '   If Lista.ControlaProduccion Then
            '      ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
            '      If drLista(Entidades.ListaControlProducto.Columnas.CincoS.ToString()) <> "Ok" And Lista.Controla5SProduccion Then
            '         ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            '         MessageBox.Show("La Lista controla 5S Producción y no esta Ok, no podrá modificar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '      Else
            '         ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
            '      End If
            '   Else
            '      ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            '   End If

            'End If

            'If _PermisosCalidad Then
            '   If Lista.ControlaCalidad Then
            '      ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
            '      If drLista(Entidades.ListaControlProducto.Columnas.CincoSC.ToString()) <> "Ok" And Lista.Controla5SCalidad Then
            '         ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            '         MessageBox.Show("La Lista controla 5S Calidad y no esta Ok, no podrá modificar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '      Else
            '         ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
            '      End If
            '   Else
            '      ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            '   End If

            'End If

            '      Me.tsbGrabar.Enabled = True
            Me.tsbIniciarLista.Enabled = False
            Me.tsbFinalizarLista.Enabled = True
         Else
            ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            Me.tsbIniciarLista.Enabled = False
            Me.tsbFinalizarLista.Enabled = True
         End If

         If Not Boolean.Parse(drLista("Hab").ToString()) Then
            Me.tsbIniciarLista.Enabled = False
            Me.tsbFinalizarLista.Enabled = False
         End If

      End If
   End Sub

   Public Sub Cargar5S()

      Dim drLista As DataRow = ugListasControl.FilaSeleccionada(Of DataRow)()

      If drLista IsNot Nothing Then
         Dim Lista As Entidades.ListaControl = New Reglas.ListasControl().GetUno(Integer.Parse(drLista("IdListaControl").ToString()))

         If Lista.Controla5SCalidad And _Permisos5SCalidad Then

            If String.IsNullOrEmpty(drLista("CincoSFechaC").ToString()) Then
               grp5SCalidad.Enabled = True
            Else
               grp5SCalidad.Enabled = _Permisos5SCalidadEdicion
               Me.txtFecha5SCalidad.ReadOnly = Not _Permisos5SCalidadEdicion
               Me.txtUsuario5SCalidad.ReadOnly = Not _Permisos5SCalidadEdicion
            End If
         Else
            grp5SCalidad.Enabled = False
            End If



         If Lista.Controla5SProduccion And _Permisos5SProduccion And String.IsNullOrEmpty(drLista("CincoSFecha").ToString()) Then
               grp5S.Enabled = True
            Else
               grp5S.Enabled = False
            End If

            Me.Refrescar5S()

            Select Case drLista("CincoS").ToString()
               Case "Ok"
                  rbtOk.Checked = True
               Case "No Ok"
                  rbtNoOk.Checked = True
               Case Else
            End Select

            If Not String.IsNullOrEmpty(drLista("CincoSFecha").ToString()) Then
               Me.txtFecha5S.Text = drLista.Field(Of DateTime?)("CincoSFecha").ToStringValue()
            End If

            If Not String.IsNullOrEmpty(drLista("CincoSUsr").ToString()) Then
               Me.txtUsuario5S.Text = drLista("CincoSUsr").ToString()
            End If

            If Not String.IsNullOrEmpty(drLista("CincoSComment").ToString()) Then
               Me.txtComentario5S.Text = drLista("CincoSComment").ToString()
            End If

            Select Case drLista("CincoSC").ToString()
               Case "Ok"
                  rbtOkCalidad.Checked = True
               Case "No Ok"
                  rbtNoOkCalidad.Checked = True
               Case Else
            End Select
            If Not String.IsNullOrEmpty(drLista("CincoSFechaC").ToString()) Then
               Me.txtFecha5SCalidad.Text = drLista("CincoSFechaC").ToString()
            End If
            If Not String.IsNullOrEmpty(drLista("CincoSUsrC").ToString()) Then
               Me.txtUsuario5SCalidad.Text = drLista("CincoSUsrC").ToString()
            End If
            If Not String.IsNullOrEmpty(drLista("CincoSCommentC").ToString()) Then
               Me.txtComentario5SCalidad.Text = drLista("CincoSCommentC").ToString()
            End If
            If Not String.IsNullOrEmpty(drLista("Observacion").ToString()) Then
               Me.txtObservacionLista.Text = drLista("Observacion").ToString()
            End If

         End If
   End Sub

   Public Sub CargaAuditoriasItems()

      Dim drLista2 As DataRow = ugListasControl.FilaSeleccionada(Of DataRow)()

      Dim drLista As DataRow = ugProductoListasControl.FilaSeleccionada(Of DataRow)()

      Me.ugdItemsListasControlAuditoria.Enabled = Boolean.Parse(drLista2("Hab").ToString())

      If drLista IsNot Nothing Then


         ugdItemsListasControlAuditoria.DataSource = New DataView(_dtItemsListasControlAuditoria,
                                                     String.Format("{0} = {1}", Entidades.ListaControlProductoItem.Columnas.IdListaControlItem.ToString(), drLista(Entidades.ListaControlProductoItem.Columnas.IdListaControlItem.ToString())),
                                                                   "", DataViewRowState.CurrentRows)

         '  Me.tssItemsListasControlAuditoria.Text = ugdItemsListasControlAuditoria.Rows.Count.ToString() & " Registros"

         Me.FormateaGrillaListasControlItemsAuditoria()


         If Not Me._cargandoPantalla Then

            _dtLinksListasControl = New Reglas.ListasControlItemsLinks().GetAll(drLista.Field(Of Integer)(Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString()),
                                                                                drLista.Field(Of Integer)(Entidades.ListaControlItemLinks.Columnas.Item.ToString()))

            bdsLinksListasControl.Filter = String.Empty
            bdsLinksListasControl.DataSource = _dtLinksListasControl

            Me.FormateaGrillaListasControlLinks()

         End If


         '  _ListaControl = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, drLista("IdListaControl"))

      End If
   End Sub

   Public Sub CargaAuditoriasListas()

      Dim drLista As DataRow = ugListasControl.FilaSeleccionada(Of DataRow)()

      If drLista IsNot Nothing Then

         Me.ugdListasControlAuditoria.Enabled = Boolean.Parse(drLista("Hab").ToString())

         Me.ugdListasControlAuditoria.DataSource = New DataView(_dtListasControlAuditoria,
                                                     String.Format("{0} = {1}", Entidades.ListaControlProducto.Columnas.IdListaControl.ToString(), drLista(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString())),
                                                                   "", DataViewRowState.CurrentRows)

         '  Me.tssItemsListasControlAuditoria.Text = ugdItemsListasControlAuditoria.Rows.Count.ToString() & " Registros"

         Me.FormateaGrillaListasControlAuditoria()

      End If
   End Sub

   Private Sub CargarLinksProductos(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtLinksProductos = New Reglas.ProductosLinks().GetAll(Me.bscCodigoProducto2.Text.ToString())

         bdsLinksProductos.Filter = String.Empty
         bdsLinksProductos.DataSource = _dtLinksProductos

         Me.FormateaGrillaProductosLinks()
      End If
   End Sub

   Private Sub CargarLinksItems(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtLinksListasControl = New Reglas.ListasControlItemsLinks().GetAll(Integer.Parse(Me.ugListasControl.ActiveRow.Cells("IdListaCOntrol").Value.ToString()),
                                                                          Integer.Parse(Me.ugProductoListasControl.ActiveRow.Cells("Item").Value.ToString()))

         bdsLinksListasControl.Filter = String.Empty
         bdsLinksListasControl.DataSource = _dtLinksListasControl

         Me.FormateaGrillaListasControlLinks()
      End If
   End Sub

   Private Sub CambiaAEstadoEnProceso()

      Dim drLista As DataRow = DirectCast(ugListasControl.ActiveRow.ListObject, DataRowView).Row

      ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False

      _ListaControl = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, drLista.Field(Of Integer)("IdListaControl"))

      Dim TipoLista As Entidades.ListaControlTipo = New Entidades.ListaControlTipo
      Dim Lista As Entidades.ListaControl = New Reglas.ListasControl().GetUno(_ListaControl.IdListaControl)
      TipoLista = New Reglas.ListasControlTipos().GetUno(Lista.IdListaControlTipo)
      If Not TipoLista.VisiblePanelControl Then
         If Not (Me.chbFechaLiberado.Checked And Me.chbFechaLiberadoPDI.Checked) Then
            MessageBox.Show("No puede iniciar la Lista, no tiene fecha Liberado/Liberado PDI", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      End If


      Me.tsbIniciarLista.Enabled = False
      Me.tsbFinalizarLista.Enabled = False
      Me.tsbGrabar.Enabled = True

      If Me.ControlaPermisosLista(drLista) Then

         Dim Estado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlEnProceso)

         drLista("IdEstadoCalidad") = Estado.IdEstadoCalidad
         drLista("NombreEstadoCalidad") = Estado.NombreEstadoCalidad
         Dim color As Color = SystemColors.Control
         color = Estado.Color.ToArgbColor() ' Drawing.Color.FromArgb(Estado.Color)

         Me.ugListasControl.ActiveRow.Cells.Item("NombreEstadoCalidad").Appearance.BackColor = color
         Me.ugListasControl.ActiveRow.Cells.Item("NombreEstadoCalidad").ActiveAppearance.BackColor = color


         _ListaControl.IdEstadoCalidad = Estado.IdEstadoCalidad
         _ListaControl.FecEgreso = Nothing
         _ListaControl.FecIngreso = Date.Now()


         Me.chbFechaIngreso.Enabled = Not Lista.BloqueaFechaIngreso
         Me.dtpIngreso.Enabled = Not Lista.BloqueaFechaIngreso

         'Controlo las listas si bloquean Fecha de Ingreso 
         Dim Lista1 As Entidades.ListaControl = New Entidades.ListaControl
         For Each dr1 As UltraGridRow In ugListasControl.Rows
            Lista1 = New Reglas.ListasControl().GetUno(Integer.Parse(dr1.Cells("IdListaControl").Value.ToString()))
            If Lista1.BloqueaFechaIngreso AndAlso IsDate(dr1.Cells("FecIngreso").Value.ToString()) Then
               Me.chbFechaIngreso.Enabled = False
               Me.dtpIngreso.Enabled = False
               Exit For
            End If
         Next

         '    Me.spcDatos.Panel1.Enabled = False
      End If

   End Sub

   Private Function ControlaPermisosLista(drLista As DataRow) As Boolean

      Dim Lista As Entidades.ListaControl = New Reglas.ListasControl().GetUno(drLista.Field(Of Integer)(Entidades.ListaControlProducto.Columnas.IdListaControl.ToString()))

      ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True

      If Lista.ControlaProduccion Then
         If Lista.Controla5SProduccion And Not rbtOk.Checked And Not rbtNoOk.Checked Then
            ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            MessageBox.Show("La Lista controla 5S Producción y no fue actualizada, no podrá modificar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tsbGrabar.Enabled = False
            Return False
         End If
      Else
         ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
      End If

    
      If Lista.ControlaCalidad Then
         ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.True
         If Lista.Controla5SCalidad And Not rbtOkCalidad.Checked And Not rbtNoOkCalidad.Checked Then
            ugProductoListasControl.DisplayLayout.Override.AllowUpdate = DefaultableBoolean.False
            MessageBox.Show("La Lista controla 5S Calidad y no fue actualizada, no podrá modificar la Lista.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.tsbGrabar.Enabled = False
            Return False
         End If

      End If

      Return True
   End Function

   Private Sub tsbFInalizarListas_Click(sender As Object, e As EventArgs) Handles tsbFInalizarListas.Click
      'Try
      '   Me.Cursor = Cursors.WaitCursor

      '   Dim CantidadListas As Integer = 0
      '   Dim ProductosPanel As DataTable = New DataTable
      '   Dim ProductosListas As DataTable = New DataTable
      '   Dim ProductosListasItems As DataTable = New DataTable
      '   Dim Roles As DataTable = New DataTable
      '   Dim Finaliza As Boolean = True
      '   Dim ListaActiva As Entidades.ListaControl = New Entidades.ListaControl()

      '   'Busco todos los productos que no fueron Liberados y estan en el Panel de Control
      '   ProductosPanel = New Reglas.ListasControlProductos().GetProductosPanelControl()
      '   For Each dr As DataRow In ProductosPanel.Rows
      '      'Busco todas las listas EN PROCESO para finalizar las que esten todo OK
      '      ProductosListas = New Reglas.ListasControlProductos().GetListasControlxProductoEnProceso(dr("Idproducto").ToString())
      '      For Each dr1 As DataRow In ProductosListas.Rows
      '         Finaliza = True
      '         _ListaControl = New Reglas.ListasControlProductos().GetUno(dr("Idproducto").ToString(), Integer.Parse(dr1("IdListaControl").ToString()))

      '         ListaActiva = New Reglas.ListasControl().GetUno(Integer.Parse(dr1("IdListaControl").ToString()))
      '         'Busco los items de las listas para hacer el control para poder finalizar la lista
      '         ProductosListasItems = New Reglas.ListasControlProductosItems().GetListasControlxProductoListaControl(dr("Idproducto").ToString(), Integer.Parse(dr1("IdListaControl").ToString()))
      '         For Each dr2 As DataRow In ProductosListasItems.Rows
      '            If ListaActiva.ControlaProduccion Then
      '               Dim selec As String
      '               selec = If(Boolean.Parse(dr2("NoOk").ToString()), "NoOk",
      '                       If(Boolean.Parse(dr2("Obs").ToString()), "Obs",
      '                       If(Boolean.Parse(dr2("Mat").ToString()), "Mat", String.Empty)))
      '               'Si controla producción y hay alguno no OK o NA da error
      '               If Not String.IsNullOrWhiteSpace(selec) Then
      '                  '      ShowMessage(String.Format("La Lista '{0}' controla Producción y el item '{1}' está en '{2}', no es posible Finalizar la Lista.",
      '                  '                                ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value, selec))
      '                  '      Me.tsbGrabar.Enabled = True
      '                  '      dr.Activate()
      '                  '      Exit Sub
      '                  Finaliza = False

      '               End If

      '               If Not Boolean.Parse(dr2("Ok").ToString()) And Not Boolean.Parse(dr2("NA").ToString()) Then
      '                  '      ShowMessage(String.Format("La Lista '{0}' controla Producción y el item '{1}' no tiene seleccionada ninguna opción válida.",
      '                  '                                ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value))
      '                  '      Me.tsbGrabar.Enabled = True
      '                  '      dr.Activate()
      '                  '      Exit Sub
      '                  Finaliza = False

      '               End If

      '            End If

      '            If ListaActiva.ControlaCalidad Then
      '               Dim selec As String
      '               selec = If(Boolean.Parse(dr2("NoOkCalidad").ToString()), "NoOkCalidad",
      '                       If(Boolean.Parse(dr2("ObsCalidad").ToString()), "ObsCalidad",
      '                       If(Boolean.Parse(dr2("MatCalidad").ToString()), "MatCalidad", String.Empty)))
      '               If Not String.IsNullOrWhiteSpace(selec) Then
      '                  '      ShowMessage(String.Format("La Lista '{0}' controla Calidad y el item '{1}' está en '{2}', no es posible Finalizar la Lista.",
      '                  '                                   ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value, selec))
      '                  '      Me.tsbGrabar.Enabled = True
      '                  '      dr.Activate()
      '                  '      Exit Sub
      '                  Finaliza = False

      '               End If

      '               If Not Boolean.Parse(dr2("OkCalidad").ToString()) And Not Boolean.Parse(dr2("NACalidad").ToString()) Then
      '                  '      ShowMessage(String.Format("La Lista '{0}' controla Calidad y el item '{1}' no tiene seleccionada ninguna opción válida.",
      '                  '                                ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value))
      '                  '      Me.tsbGrabar.Enabled = True
      '                  '      dr.Activate()
      '                  '      Exit Sub
      '                  Finaliza = False
      '               End If

      '               If ListaActiva.ControlaProduccion Then
      '                  If Boolean.Parse(dr2("Ok").ToString()) <> Boolean.Parse(dr2("OkCalidad").ToString()) Or
      '                                      Boolean.Parse(dr2("NA").ToString()) <> Boolean.Parse(dr2("NACalidad").ToString()) Then
      '                     '         ShowMessage(String.Format("La Lista '{0}' controla Calidad y el item '{1}' tiene diferencias entre producción y calidad.",
      '                     '                                   ListaActiva.NombreListaControl, dr.Cells("NombreListaControlItem").Value))
      '                     '         Me.tsbGrabar.Enabled = True
      '                     '         dr.Activate()
      '                     '         Exit Sub
      '                     '      End If
      '                     Finaliza = False
      '                  End If

      '               End If
      '            End If

      '            If Not Finaliza Then
      '               Exit For
      '            End If
      '         Next

      '         ' Finaliza = True

      '         If Finaliza Then

      '            Dim EstadoFinalizado As Entidades.EstadoListaControl = New Reglas.EstadosListasControl().GetUno(Reglas.Publicos.EstadoListaControlTerminado)

      '            If ListaActiva.HabilitaFechaLiberado Or ListaActiva.HabilitaFechaLiberadoPDI Then
      '               Exit For
      '            End If

      '            _ListaControl.IdEstadoCalidad = EstadoFinalizado.IdEstadoCalidad
      '            _ListaControl.FecEgreso = Date.Now()
      '            _ListaControl.FecIngreso = Nothing
      '            _ListaControl.Observacion = "TERMINADO AUTOMATICO"

      '            'If Lista.ModificaFechaEgreso Then
      '            '   Me.chbFechaEgreso.Checked = True
      '            '   Me.dtpEgreso.Value = Date.Now()
      '            'End If

      '            'If Lista.ModificaFechaPreEntrega Then
      '            '   Me.chbFechaPreEntrega.Checked = True
      '            '   Me.dtpPreentrega.Value = Date.Now()
      '            'End If


      '            ''Busca la lista siguiente para cambiarle el estado si es automatica y es Pendiente
      '            'Dim Orden As Integer = Integer.Parse(drLista("Orden").ToString())

      '            '_ListaControlSiguiente = New Entidades.ListaControlProducto()
      '            'Dim ListaSig As DataTable = New Reglas.ListasControlProductos().GetListasControlSiguienteOrden(Me.bscCodigoProducto2.Text, Orden)
      '            'If ListaSig.Rows.Count <> 0 Then
      '            '   Dim ListaSiguiente As Entidades.ListaControl = New Reglas.ListasControl().GetUno(Integer.Parse(ListaSig.Rows(0).Item("IdListaControl").ToString()))
      '            '   If ListaSiguiente.InicioAutomatico And Integer.Parse(ListaSig.Rows(0).Item("IdEstadoCalidad").ToString()) = 1 Then
      '            '      _ListaControlSiguiente = New Reglas.ListasControlProductos().GetUno(Me.bscCodigoProducto2.Text, ListaSiguiente.IdListaControl)
      '            '      _ListaControlSiguiente.IdEstadoCalidad = Reglas.Publicos.EstadoListaControlEnProceso
      '            '      _ListaControlSiguiente.FecEgreso = Nothing
      '            '      _ListaControlSiguiente.FecIngreso = Date.Now()
      '            '      If ListaSiguiente.HabilitaFechaLiberadoPDI Then
      '            '         _ListaControlSiguiente.CincoSFechaC = Date.Now()
      '            '         _ListaControlSiguiente.CincoSC = "Ok"
      '            '         _ListaControlSiguiente.CincoSUsrC = New Reglas.Usuarios().GetUno(actual.Nombre).Id
      '            '      End If
      '            '   End If
      '            'End If

      '            Dim Producto As Entidades.Producto
      '            Dim rListasControlProductos As Reglas.ListasControlProductosItems = New Reglas.ListasControlProductosItems()
      '            Producto = New Reglas.Productos().GetUno(dr("Idproducto").ToString())
      '            rListasControlProductos.GuardarListaControl(Producto, _ListaControl)
      '            CantidadListas += 1

      '         End If

      '      Next

      '   Next

      '   MessageBox.Show("Se actualizaron " & CantidadListas & " Listas exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'Finally
      '   Me.Cursor = Cursors.Default
      'End Try

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim CantidadListas As Integer = 0
         Dim oListasControlProductos As Reglas.ListasControlProductos = New Reglas.ListasControlProductos

         CantidadListas = oListasControlProductos.FinalizarListas()

         MessageBox.Show("Se actualizaron " & CantidadListas & " Listas exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub



#End Region


End Class