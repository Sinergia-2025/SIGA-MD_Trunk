Public Class InfClientesRuta

#Region "Campos"

   Private _publicos As Publicos
   Private _idUsuario As String = actual.Nombre
   Private _modalidadPantalla As Entidades.ModalidadPantalla = Entidades.ModalidadPantalla.Consultar
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(_idUsuario).Rows.Count = 0 Then
               _idUsuario = ""
            End If

            '# Carga combo días de la semana
            _publicos.CargaComboDesdeEnum(cmbDiaSemana, GetType(Entidades.Publicos.Dias))
            cmbDiaSemana.SelectedIndex = -1

            _publicos.CargaComboEmpleados(cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, _idUsuario)
            cmbVendedor.SelectedIndex = -1
            _publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR, _idUsuario)
            cmbCobrador.SelectedIndex = -1
            _publicos.CargaComboRutas(cmbRutas, activa:=True, seleccionMultiple:=False, seleccionTodos:=False, cargarListaPrecios:=False)
            cmbRutas.SelectedIndex = -1

            _publicos.CargaComboLocalidades(cmbLocalidad)
            cmbLocalidad.SelectedIndex = -1

            cmbLocalidad.Enabled = chkLocalidad.Checked
            cmbRutas.Enabled = chbRuta.Checked
            cmbCobrador.Enabled = chbCobrador.Checked
            cmbVendedor.Enabled = chbVendedor.Checked

            FormatearGrilla()

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: Activo el filtro de Cliente pero NO selecciono")
               bscCodigoCliente.Select()
               Exit Sub
            End If

            If chbDia.Checked AndAlso cmbDiaSemana.SelectedIndex = -1 Then
               ShowMessage("ATENCION: Activó el filtro de Día pero NO selecciono ninguno.")
               cmbDiaSemana.Select()
               Exit Sub
            End If

            If chkLocalidad.Checked AndAlso cmbLocalidad.SelectedIndex = -1 Then
               ShowMessage("ATENCION: Activó el filtro de Localidad pero NO selecciono ninguna.")
               cmbLocalidad.Select()
               Exit Sub
            End If

            chkExpandAll.Enabled = True
            chkExpandAll.Checked = False

            CargaGrillaDetalle()

            FormatearGrilla()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Select()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
               Exit Sub
            End If
         End Sub)

   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla(),
                 onFinallyAction:=Sub(owner) tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar)
   End Sub

   Private Sub tsbImprimirPreDiseñado_Click(sender As Object, e As EventArgs)
      TryCatched(
         Sub()
            If ugDetalle.Rows.Count() = 0 Then Exit Sub

            Dim filtros = CargarFiltrosImpresion()
            Dim dt = DirectCast(ugDetalle.DataSource, DataTable)
            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)()

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Filtros", Filtros))

            Dim frmImprime = New VisorReportes("Eniac.Win.ConsultarRecibosAClientes.rdlc", "DataSetCtaCteClientes_DetalleRecibosAClientes", dt, parm, True, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Me.Text
            frmImprime.WindowState = FormWindowState.Maximized
            If chbCliente.Checked Then
               If bscCodigoCliente.Selecciono Then
                  If Not String.IsNullOrWhiteSpace(bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                     frmImprime.Destinatarios = bscCodigoCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
                  End If
               ElseIf bscCliente.Selecciono Then
                  If Not String.IsNullOrWhiteSpace(bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()) Then
                     frmImprime.Destinatarios = bscCliente.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()
                  End If
               End If
            End If
            frmImprime.Show()
         End Sub)
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Text, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"

   Private Sub chkLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chkLocalidad.CheckedChanged
      TryCatched(Sub() chkLocalidad.FiltroCheckedChanged(cmbLocalidad))
   End Sub

   Private Sub chbDia_CheckedChanged(sender As Object, e As EventArgs) Handles chbDia.CheckedChanged
      TryCatched(Sub() chbDia.FiltroCheckedChanged(cmbDiaSemana))
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      TryCatched(Sub() chbVendedor.FiltroCheckedChanged(cmbVendedor))
   End Sub

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged
      TryCatched(Sub() chbCobrador.FiltroCheckedChanged(cmbCobrador))
   End Sub

   Private Sub chbRuta_CheckedChanged(sender As Object, e As EventArgs) Handles chbRuta.CheckedChanged
      TryCatched(Sub() chbRuta.FiltroCheckedChanged(cmbRutas))
   End Sub

#End Region

#Region "Eventos Buscadores"

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If e.FilaDevuelta IsNot Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
            End If
         End Sub)
   End Sub

#End Region

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False

      btnConsultar.Select()

   End Sub

   Private Sub RefrescarDatosGrilla()

      chbCliente.Checked = False
      chbVendedor.Checked = False
      cmbVendedor.SelectedIndex = -1
      chbCobrador.Checked = False
      cmbCobrador.SelectedIndex = -1
      chbRuta.Checked = False
      cmbRutas.SelectedIndex = -1
      chbDia.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      chkLocalidad.Checked = False
      cmbLocalidad.SelectedIndex = -1
      ugDetalle.ClearFilas()

      btnConsultar.Select()

   End Sub

   Private Sub CargaGrillaDetalle()


      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idVendedor = cmbVendedor.ValorSeleccionado(chbVendedor, 0I)
      Dim idCobrador = cmbCobrador.ValorSeleccionado(chbCobrador, 0I)
      Dim idRuta = cmbRutas.ValorSeleccionado(chbRuta, 0I)
      '  Dim diaSemana = cmbDiaSemana.ValorSeleccionado(Of Integer?)(chbDia, Nothing)
      Dim diaSemana As Entidades.Publicos.Dias? = Nothing
      If Me.chbDia.Checked Then
         diaSemana = Me.cmbDiaSemana.ValorSeleccionado(Of Entidades.Publicos.Dias)()
      End If

      Dim idLocalidad = cmbLocalidad.ValorSeleccionado(chkLocalidad, 0I)

      Dim rMovilRutas = New Reglas.MovilRutas()
      Dim dtDetalle = rMovilRutas.GetClientesRutas(idRuta, idCliente, idCobrador, idVendedor, diaSemana, idLocalidad)

      Dim _dtDetalle = CrearDT()
      For Each dr As DataRow In dtDetalle.Rows
         Dim drCl = _dtDetalle.NewRow()
         drCl("NombreRuta") = dr("NombreRuta").ToString()
         drCl("Cobrador") = dr("Cobrador").ToString()
         drCl("Vendedor") = dr("Vendedor").ToString()
         drCl("Orden") = dr("Orden").ToString()
         drCl("CodigoCliente") = Long.Parse(dr("CodigoCliente").ToString())
         drCl("NombreCliente") = dr("NombreCliente").ToString()
         drCl("Dia") = DiaDeLaSemana(Integer.Parse(dr("dia").ToString()))
         drCl("Localidad") = dr("NombreLocalidad").ToString()
         drCl(Entidades.Cliente.Columnas.Telefono.ToString()) = dr(Entidades.Cliente.Columnas.Telefono.ToString())
         drCl(Entidades.Cliente.Columnas.Direccion.ToString()) = dr(Entidades.Cliente.Columnas.Direccion.ToString())

         _dtDetalle.Rows.Add(drCl)
      Next

      ugDetalle.DataSource = _dtDetalle

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("NombreRuta", GetType(String))
         .Columns.Add("Cobrador", GetType(String))
         .Columns.Add("Vendedor", GetType(String))
         .Columns.Add("Orden", GetType(String))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("Dia", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("Telefono", GetType(String))
         .Columns.Add("Localidad", GetType(String))
      End With
      Return dtTemp
   End Function
   Private Function DiaDeLaSemana(Dia As Integer) As String
      Dim Letra = String.Empty
      Select Case Dia
         Case 7
            Letra = "Otr"
         Case 0
            Letra = "Dom"
         Case 1
            Letra = "Lun"
         Case 2
            Letra = "Mar"
         Case 3
            Letra = "Mie"
         Case 4
            Letra = "Jue"
         Case 5
            Letra = "Vie"
         Case 6
            Letra = "Sab"
      End Select
      Return Letra
   End Function

   Public Sub FormatearGrilla()
      ugDetalle.DisplayLayout.UseFixedHeaders = True
      ugDetalle.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Dim pos As Integer = 0
      With Me.ugDetalle.DisplayLayout.Bands(0)

         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         .Columns("NombreRuta").FormatearColumna("Nombre de Ruta", pos, 140)
         .Columns("Vendedor").FormatearColumna("Vendedor", pos, 170)
         .Columns("Cobrador").FormatearColumna("Cobrador", pos, 170)
         .Columns("Orden").FormatearColumna("Orden", pos, 50, HAlign.Right)
         .Columns("CodigoCliente").FormatearColumna("Codigo", pos, 60, HAlign.Right)
         .Columns("NombreCliente").FormatearColumna("Nombre de Cliente", pos, 260)
         .Columns("Dia").FormatearColumna("Dia", pos, 50, HAlign.Left)
         .Columns("Telefono").FormatearColumna("Teléfono", pos, 80, HAlign.Right)
         .Columns("Direccion").FormatearColumna("Dirección", pos, 150, HAlign.Left)
         .Columns("Localidad").FormatearColumna("Localidad", pos, 150, HAlign.Left)
      End With

      ugDetalle.AgregarFiltroEnLinea({"NombreRuta", "Cobrador", "Vendedor", "NombreCliente"})

      PreferenciasLeer(ugDetalle, tsbPreferencias)
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         If chbRuta.Checked Then
            .AppendFormat("Ruta: {0} - ", cmbRutas.Text)
         End If
         If chbCliente.Checked Then
            .AppendFormat("Cliente: {0} - {1} - ", bscCodigoCliente.Text, bscCliente.Text)
         End If
         If chbVendedor.Checked Then
            .AppendFormat("Vendedor: {0} - ", cmbVendedor.Text)
         End If
         If chbCobrador.Checked Then
            .AppendFormat("Cobrador: {0} - ", cmbCobrador.Text)
         End If
         If chbDia.Checked Then
            .AppendFormat("Día: {0} - ", cmbDiaSemana.Text)
         End If
         If chkLocalidad.Checked Then
            .AppendFormat("Localidad: {0} - ", cmbLocalidad.Text)
         End If
      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

End Class