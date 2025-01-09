Imports System.ComponentModel

Public Class AdministradorPedidosTiendasWeb
#Region "Propiedades"
   Private _publicos As Publicos
#End Region

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)

      AgregarFiltroEnLinea(Me.ugDetalle, {"NroDocCliente", "NombreClienteTiendaWeb", "MensajeError", "ObservacionesTiendaWeb", "DireccionEnvio"})
   End Sub
   Public Sub New()

      ' This call is required by the designer.
      InitializeComponent()
      _publicos = New Publicos

      '# Carga Combos
      Me._publicos.CargaComboDesdeEnum(Me.cmbEstados, GetType(Estados))
      Me.cmbEstados.SelectedValue = Estados.ERROR
      Me._publicos.CargaComboDesdeEnum(Me.cmbFechaFiltro, GetType(TiposFechas))
      Me.cmbFechaFiltro.SelectedValue = TiposFechas.FechaPedido
      Me._publicos.CargaComboDesdeEnum(Me.cmbTiendaWeb, GetType(Entidades.TiendasWeb))
      Me.cmbTiendaWeb.SelectedValue = Entidades.TiendasWeb.TIENDANUBE

      Me.ResetearFechas()

   End Sub


#Region "Métodos"

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      With filtro

         Dim tipoFechaFiltro As String = String.Empty
         If Me.cmbFechaFiltro.SelectedValue.ToString() = TiposFechas.FechaPedido.ToString() Then
            tipoFechaFiltro = "Fecha Pedido"
         ElseIf Me.cmbFechaFiltro.SelectedValue.ToString() = TiposFechas.FechaEstado.ToString() Then
            tipoFechaFiltro = "Fecha Estado"
         Else
            tipoFechaFiltro = "Fecha Descarga"
         End If

         filtro.AppendFormat("Tienda: {0}", Me.cmbTiendaWeb.Text)
         filtro.AppendFormat(" - Estado: {0}", Me.cmbEstados.Text)
         filtro.AppendFormat(" - Fecha Desde: {0}", Me.dtpDesde.Value.ToString())
         filtro.AppendFormat(" Hasta: {0} ({1})", Me.dtpHasta.Value.ToString(), tipoFechaFiltro)

         If Me.chbPedido.Checked AndAlso Not String.IsNullOrEmpty(Me.txtIdPedido.Text) AndAlso Me.txtIdPedido.Text <> "0" Then
            filtro.AppendFormat("Nro. Pedido: {0}", Me.txtIdPedido.Text)
         End If
      End With
      Return filtro.ToString()
   End Function

   '# Recibo la row correspondiente al pedido por parámetro
   Private Sub ImportarPedido(dt As DataTable)
      Dim importacion = New Reglas.ServiciosRest.TiendasWeb.ImportacionPedidosTiendasWeb()

      '-- Proceso Marca la Tienda.- -------------------------------
      Dim oComboOpcion = cmbTiendaWeb.ValorSeleccionado(Of Entidades.TiendasWeb)()
      '------------------------------------------------------------
      importacion._Importar(dt, oComboOpcion)
      '-------------------------------------------------------------------
      ShowMessage("Proceso de Importación realizado correctamente !!!")
      '-------------------------------------------------------------------
      CargarGrillaDetalle()
   End Sub

   Private Sub ActualizarEstadoPedido(id As String, sistemaDestino As String, nuevoEstado As String)
      Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb
      '-------------------------------------------------------------------
      rPTW._ActualizarEstadoPedidoTiendaWeb(id, sistemaDestino, nuevoEstado, quitarMensajeError:=False)
      '-------------------------------------------------------------------
      ShowMessage("Se actualizó el Estado del Pedido correctamente !!!")

      '# Cargo nuevamente la pantalla
      CargarGrillaDetalle()
   End Sub

   Private Function ValidarDetalle() As Boolean

      If Me.chbPedido.Checked AndAlso String.IsNullOrWhiteSpace(Me.txtIdPedido.Text) AndAlso Me.txtIdPedido.Text <> "0" Then
         ShowMessage("ATENCIÓN: Activó el filtro por Pedido pero no ingresó uno.")
         Me.txtIdPedido.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub CargarGrillaDetalle()
      Dim ds As DataSet = New DataSet()
      Dim dtCabecera, dtDetalle As DataTable
      Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb
      Dim rPPTW As Reglas.PedidosProductosTiendasWeb = New Reglas.PedidosProductosTiendasWeb
      Dim e As String() = If(Me.cmbEstados.SelectedValue.ToString() <> Estados.TODOS.ToString(), {Me.cmbEstados.SelectedValue.ToString()}, Nothing)

      '# Filtros
      Dim nroPedido As Long? = If(Me.chbPedido.Checked, Convert.ToInt64(Me.txtIdPedido.Text), Nothing)
      Dim desde As DateTime = Me.dtpDesde.Value
      Dim hasta As DateTime = Me.dtpHasta.Value
      Dim tipoFechaFiltro As String = Me.cmbFechaFiltro.SelectedValue.ToString()

      dtCabecera = rPTW.GetPedidosAImportar(Me.cmbTiendaWeb.SelectedValue.ToString(), e, nroPedido, desde, hasta, tipoFechaFiltro)
      dtDetalle = rPPTW.GetPedidosProductosAImportar(Me.cmbTiendaWeb.SelectedValue.ToString(), e, nroPedido, desde, hasta, tipoFechaFiltro)

      '# JSON
      dtCabecera.Columns.Add("VerJSON", GetType(String))
      dtCabecera.Columns.Add("CopiarJSON", GetType(String))

      '# Check para selección multiple de Pedidos. Por defecto todos sin seleccionar
      dtCabecera.Columns.Add("Check", GetType(Boolean))
      For Each dr As DataRow In dtCabecera.Rows
         dr("Check") = False
      Next

      dtCabecera.TableName = "Cabecera"
      dtDetalle.TableName = "Detalle"
      ds.Tables.Add(dtCabecera)
      ds.Tables.Add(dtDetalle)

      '# Armo la relación entre la cabecera y el detalle
      Dim relacion As DataRelation = New DataRelation("Detalle",
                                                      {ds.Tables("Cabecera").Columns("Id"), ds.Tables("Cabecera").Columns("SistemaDestino")},
                                                      {ds.Tables("Detalle").Columns("Id"), ds.Tables("Detalle").Columns("SistemaDestino")},
                                                      True)
      ds.Relations.Add(relacion)

      '# Cargo la grilla
      Me.ugDetalle.DataSource = ds
      Me.FormatearBand1()

      If dtCabecera.Rows.Count = 0 Then ShowMessage("NO hay registros que cumplan con la seleccion !!!")

   End Sub

   Private Sub FormatearBand1()
      Me.ugDetalle.DisplayLayout.Bands(1).Columns("Id").Hidden = True
      Me.ugDetalle.DisplayLayout.Bands(1).Columns("SistemaDestino").Hidden = True
      Me.ugDetalle.DisplayLayout.Bands(1).Columns("Cantidad").CellAppearance.TextHAlign = HAlign.Right
      Me.ugDetalle.DisplayLayout.Bands(1).Columns("Precio").CellAppearance.TextHAlign = HAlign.Right
   End Sub

   Private Sub Refrescar()
      Me.ugDetalle.ClearFilas()
      Me.chbPedido.Checked = False
      Me.chkExpandAll.Checked = False

      Me.cmbEstados.SelectedValue = Estados.ERROR
      Me.cmbFechaFiltro.SelectedValue = TiposFechas.FechaPedido
      Me.cmbTiendaWeb.SelectedValue = Entidades.TiendasWeb.TIENDANUBE

      Me.ResetearFechas()


   End Sub

   Private Sub ResetearFechas()
      Me.dtpDesde.Value = DateTime.Today
      Me.dtpHasta.Value = DateTime.Today.UltimoSegundoDelDia()
   End Sub

#End Region

#Region "Eventos"

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".xls", Me.Text, UltraGridExcelExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.Exportar(Me.Name & ".pdf", Me.Text, UltraGridDocumentExporter1, Me.CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      Me.ugDetalle.Rows.ExpandAll(chkExpandAll.Checked)
   End Sub

   Private Sub tsbCambiarEstado_Click(sender As Object, e As EventArgs) Handles tsbCambiarEstado.Click
      Try

         Dim p As New Entidades.PedidoTiendaWeb With {.Id = ugDetalle.FilaSeleccionada(Of DataRow)().Field(Of String)("Id"),
                                                      .SistemaDestino = ugDetalle.FilaSeleccionada(Of DataRow)().Field(Of String)("SistemaDestino"),
                                                      .Numero = ugDetalle.FilaSeleccionada(Of DataRow)().Field(Of Long)("Numero"),
                                                      .IdEstadoPedidoTiendaWeb = ugDetalle.FilaSeleccionada(Of DataRow)().Field(Of String)("IdEstadoPedidoTiendaWeb")}
         Using frm As New CambiarEstadoPedidoTiendaWeb(p)
            frm.ShowDialog()
            If frm.DialogResult <> Windows.Forms.DialogResult.OK Then Exit Sub
            Me.ActualizarEstadoPedido(p.Id, p.SistemaDestino, frm.NuevoEstado)
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Refrescar()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbPedido_CheckedChanged(sender As Object, e As EventArgs) Handles chbPedido.CheckedChanged
      Try
         Me.txtIdPedido.Enabled = Me.chbPedido.Checked
         If Not Me.chbPedido.Checked Then
            Me.txtIdPedido.Clear()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         '# Validar Filtros
         If Me.ValidarDetalle() Then
            Me.CargarGrillaDetalle()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalle.AfterRowActivate
      Try
         Dim row As DataRow = Me.ugDetalle.FilaSeleccionada(Of DataRow)()
         Me.tsbCambiarEstado.Enabled = False

         '# Valido que siempre se toque el pedido y no su detalle para querer Importarlo.
         If row IsNot Nothing AndAlso row.GetParentRow("Detalle") Is Nothing Then
            Me.tsbCambiarEstado.Enabled = (row(Entidades.PedidoTiendaWeb.Columnas.IdEstadoPedidoTiendaWeb.ToString()).ToString() = Estados.ERROR.ToString())
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      Try
         Dim row As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)()
         If row IsNot Nothing AndAlso row.GetParentRow("Detalle") Is Nothing Then
            Select Case e.Cell.Column.Key
               Case "CopiarJSON"
                  If Not String.IsNullOrWhiteSpace(row("JSON").ToString()) Then
                     Clipboard.SetText(row("JSON").ToString())
                     ShowMessage("JSON Copiado en portapapeles!")
                  End If
               Case "VerJSON"
                  If Not String.IsNullOrWhiteSpace(row("JSON").ToString()) Then
                     Using frm As VisorTexto = New VisorTexto()
                        frm.ShowDialog(Me, String.Format("JSON del Pedido {0} {1}", row("Numero").ToString(), row("SistemaDestino").ToString()),
                                       String.Format("{0}", row("JSON").ToString()))
                     End Using
                  End If
               Case Else
                  Exit Sub
            End Select
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugDetalle, True)
         pre.ShowDialog()
         Me.PreferenciasLeer(Me.ugDetalle, tsbPreferencias)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      Try
         '# Preparo la tabla con los pedidos a Importar
         Me.ugDetalle.UpdateData()
         Dim checkedRows As DataRow() = DirectCast(Me.ugDetalle.DataSource, DataSet).Tables("Cabecera").Select("Check = 'True'")
         If checkedRows Is Nothing OrElse checkedRows.Count = 0 Then
            ShowMessage("ATENCIÓN: Debe seleccionar al menos un pedido a Importar.")
            Exit Sub
         End If

         For Each dr As DataRow In checkedRows
            Dim estado As String = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdEstadoPedidoTiendaWeb.ToString())
            Dim nroPedido As Long = dr.Field(Of Long)(Entidades.PedidoTiendaWeb.Columnas.Numero.ToString())
            '# Valido que los pedidos seleccionados se encuentren en estado ERROR (No se puede Importar ningún pedido en cualquier otro estado)
            If estado <> Estados.ERROR.ToString() Then
               ShowMessage(String.Format("ATENCIÓN: El pedido {0} se encuentra en estado {1}. Sólo se pueden importar pedidos manualmente que se encuentren en estado de ERROR.",
                                         nroPedido, estado))
               Exit Sub
            End If
         Next

         '# Luego de la validación, agrego las rows de los pedidos a importar al dt
         Dim dtPedidosAImportar As DataTable = checkedRows.CopyToDataTable()
         Me.ImportarPedido(dtPedidosAImportar)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Enums"
   Private Enum Estados
      <Description("TODOS")> TODOS
      <Description("ERROR")> [ERROR]
      <Description("CANCELADO")> CANCELADO
      <Description("PROCESADO")> PROCESADO
      <Description("INGRESADO")> INGRESADO
      <Description("PENDIENTE")> PENDIENTE
   End Enum

   Private Enum TiposFechas
      <Description("Fecha Pedido")> FechaPedido
      <Description("Fecha Descarga")> FechaDescarga
      <Description("Fecha Estado")> FechaEstado
   End Enum

#End Region

End Class