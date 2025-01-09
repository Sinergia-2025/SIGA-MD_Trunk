Imports Eniac.Entidades
Imports System.Drawing.Printing
Imports Eniac.Entidades.Extensiones.Encoders
Public Class ListaDePreciosParaClientes

#Region "Campos"

   Private _publicos As Publicos
   Private _precios As List(Of Entidades.ProductoSucursal)
   Private _estaCargando As Boolean = True
   Private _fechaVigencia As Date
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Publicos()

         If Not Reglas.Publicos.ProductoTieneSubRubro Then

            Me.chbAgregarPrecioEmbalaje.Visible = False
            Me.lblSubRubro.Visible = False
            Me.cmbSubRubro.Visible = False
            Me.rbSubRubro.Visible = False
            Me.rbRubroSubRubro.Visible = False
            Me.rbMarcaRubroSubRubro.Visible = False
         Else
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = False
            Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreMarca").Hidden = True
         End If

         Me.chbProductosCliente.Checked = Reglas.Publicos.ClienteMostrarProductosAsociados

         Me.cmbEsOferta.SelectedIndex = 0

         Me._publicos.CargaComboListaDePrecios(Me.cmbListaDePrecios)

         Me.chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         Me.lblSSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro
         Me.cmbSSubRubro.Visible = Me.lblSSubRubro.Visible

         '# Posibilidad de ordenar por Cód. Producto Numérico
         Me.rbCodNumerico.Visible = Reglas.Publicos.HabilitaCodigoNumericoProducto

         Me.SetearColumnas()
         '------------
         Me._publicos.CargaComboMonedas(Me.cmbMoneda)

         DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows.InsertAt(DirectCast(Me.cmbMoneda.DataSource, DataTable).NewRow, 0)
         DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows(0)("IdMoneda") = -1
         DirectCast(Me.cmbMoneda.DataSource, DataTable).Rows(0)("NombreMoneda") = "del producto"
         Me.cmbMoneda.SelectedIndex = 0
         '------------------------------

         If Me.cmbPrecio.SelectedIndex = -1 Then
            Me.cmbPrecio.SelectedItem = "de venta"
         End If

         '------------------------------

         '# Cargo los combos de Publicar en...
         CargarCombosWeb()

         cmbSubRubro.ConcatenarNombreRubro = True
         cmbSSubRubro.ConcatenarNombreSubRubro = False
         cmbMarca.Inicializar(False, True, True)
         cmbRubro.Inicializar(False, True, True)
         cmbSSubRubro.Inicializar(False)

         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "NombreMarca", "NombreRubro"})

         Me.PreferenciasLeer(ugDetalle, tsbPreferencias)
         Me.RefrescarDatos()

         Me._estaCargando = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"
   Private Sub ListaDePreciosParaClientes_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.RefrescarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click

      If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

      Try

         Me.Cursor = Cursors.WaitCursor

         Dim dt As DataTable
         Dim filtros As String = String.Empty

         dt = DirectCast(Me.ugDetalle.DataSource, DataTable)

         For Each dr As DataRow In dt.Rows
            If Me.chbConIVA.Checked Then
               dr("PrecioVenta") = dr("PrecioVentaConIVA")
            Else
               dr("PrecioVenta") = dr("PrecioVentaSinIVA")
            End If
         Next

         Dim nombreLogo As String = Publicos.NombreLogo

         Dim parI As Reglas.ParametrosImagenes = New Reglas.ParametrosImagenes()

         If Eniac.Entidades.Usuario.Actual.Logo Is Nothing Then
            MsgBox("ATENCION: NO tiene definido el LOGO de la Empresa, por favor carguelo en Parametros antes de Emitir la Lista.", MsgBoxStyle.Exclamation)
            Exit Sub
         End If

         Dim lista As String = ""
         lista = Me.cmbListaDePrecios.Text

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim DireccionCompleta As String = actual.Sucursal.DireccionComercial & " - " & actual.Sucursal.LocalidadComercial.NombreLocalidad & " - " & actual.Sucursal.LocalidadComercial.NombreProvincia
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionSucursal", DireccionCompleta))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoSucursal", actual.Sucursal.Telefono))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CorreoSucursal", actual.Sucursal.Correo))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DireccionWebEmpresa", Reglas.Publicos.DireccionWebEmpresa))

         Dim LogoImagen As System.Drawing.Image = Eniac.Entidades.Usuario.Actual.Logo

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Logo", LogoImagen.ConvertImageToBase64()))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("LogoMime", LogoImagen.MimeType))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Lista", String.Format("{0} ({1})", lista, Me.cmbPrecio.Text)))

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Orden", Me.GetOrdenImpresion()))

         '-.PE-31542.-
         'parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaVigencia"), _fechaVigencia.ToString("dd/MM/yyyy"))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaVigencia", CType(_fechaVigencia, String)))

         ImprimirInformes(dt, filtros, parm, True)

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub CargarCombosWeb()

      _publicos.CargaComboDesdeEnum(cmbPublicarEnWeb, GetType(Entidades.Publicos.SiNoTodos)).SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      _publicos.CargaComboDesdeEnum(cmbPublicarEnGestion, GetType(Entidades.Publicos.SiNoTodos)).SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      _publicos.CargaComboDesdeEnum(cmbPublicarEnEmpresarial, GetType(Entidades.Publicos.SiNoTodos)).SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      _publicos.CargaComboDesdeEnum(cmbPublicarEnBalanza, GetType(Entidades.Publicos.SiNoTodos)).SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      _publicos.CargaComboDesdeEnum(cmbPublicarEnSincronizarSucursal, GetType(Entidades.Publicos.SiNoTodos)).SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      _publicos.CargaComboDesdeEnum(cmbPublicarEnListaDePreciosParaClientes, GetType(Entidades.Publicos.SiNoTodos)).SelectedValue = Entidades.Publicos.SiNoTodos.SI

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      End If
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

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)

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

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   'Por ahora, porque utiliza un reporte totalmente independiente.
   Private Sub chbAgregarPrecioEmbalaje_CheckedChanged(sender As Object, e As EventArgs) Handles chbAgregarPrecioEmbalaje.CheckedChanged
      Me.gbAgruparPor.Visible = Not Me.chbAgregarPrecioEmbalaje.Checked
      Me.gbOrdenarPor.Visible = Not Me.chbAgregarPrecioEmbalaje.Checked
      If Me._estaCargando Then Exit Sub

      '   Me.SetearColumnas()

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

      Catch ex As Exception
         ShowError(ex)
         Me.tssRegistros.Text = "0 Registros"
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub optAgruparPorMarcaRubro_CheckedChanged(sender As Object, e As EventArgs) Handles optAgruparPorMarcaRubro.CheckedChanged
      Try
         If optAgruparPorMarcaRubro.Checked Then
            optOrdenarPorNombre.Checked = True
         End If

         Me.chb2Columnas.Checked = Me.optAgruparPorMarcaRubro.Checked Or optAgruparPorRubroMarca.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbMoneda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMoneda.SelectedIndexChanged
      Try
         If cmbMoneda.SelectedIndex = 0 Then
            txtTipoCambio.Enabled = False
            txtTipoCambio.Text = "1.00"
         Else
            txtTipoCambio.Enabled = True
            txtTipoCambio.Text = New Reglas.Monedas().GetUna(Entidades.Moneda.Dolar).FactorConversion.ToString("N2")
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      If Me._estaCargando Then Exit Sub

      Me.SetearColumnas()
   End Sub

   Private Sub bscCodigoCliente2_BuscadorClick() Handles bscCodigoCliente2.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente2)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente2.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente2.Text.Trim())
         End If
         Me.bscCodigoCliente2.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscCodigoCliente2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente2_BuscadorClick() Handles bscCliente2.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente2)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente2.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente2.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCliente2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscCodigoCliente2.FilaDevuelta = e.FilaDevuelta '# Igualo la fila devuelta por cualquier campo que se haya buscado
            Me.CargarDatosCliente(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)

      Me.bscCliente2.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente2.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente2.Tag = Long.Parse(dr.Cells("IdCliente").Value.ToString())

      Me.bscCliente2.Enabled = False
      Me.bscCodigoCliente2.Enabled = False
      Me.bscCliente2.Selecciono = True
      Me.bscCodigoCliente2.Selecciono = True

      btnConsultar.Focus()
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente2.Enabled = Me.chbCliente.Checked
      Me.bscCliente2.Enabled = Me.chbCliente.Checked
      If Not Me.chbCliente.Checked Then
         Me.bscCodigoCliente2.Text = String.Empty
         Me.bscCliente2.Text = String.Empty
         bscCodigoCliente2.Tag = Nothing
      Else
         bscCodigoCliente2.Focus()
      End If
   End Sub

   Private Sub optAgruparPorRubroMarca_CheckedChanged(sender As Object, e As EventArgs) Handles optAgruparPorRubroMarca.CheckedChanged
      Try
         If optAgruparPorMarcaRubro.Checked Then
            optOrdenarPorNombre.Checked = True
         End If

         Me.chb2Columnas.Checked = Me.optAgruparPorMarcaRubro.Checked Or optAgruparPorRubroMarca.Checked

         chbCondensado.Visible = optAgruparPorRubroMarca.Checked
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      Try
         If cmbRubro.SelectedIndex > -1 Then

            cmbSubRubro.Inicializar(True, True, True, cmbRubro.GetRubros())
            cmbSSubRubro.Inicializar(True, True, True, cmbSubRubro.GetSubRubros())

            cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
            cmbSubRubro_AfterSelectedIndexChanged(sender, e)

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      Try
         If cmbSubRubro.SelectedIndex > -1 Then

            cmbSSubRubro.Inicializar(True, True, True, cmbSubRubro.GetSubRubros())
            cmbSSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#Region "Eventos Codigo y/o Descripcion"
   Private Sub radCodigoDescripcion_CheckedChanged(sender As Object, e As EventArgs) Handles radCodigoYDescripcion.CheckedChanged, radCodigoODescripcion.CheckedChanged
      Try
         If radCodigoODescripcion.Checked Then
            If Not String.IsNullOrEmpty(txtCodigoProducto.Text) Then
               _textChangedInternal = True
               txtNombreProducto.Text = String.Empty
               _textChangedInternal = False
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private _textChangedInternal As Boolean = False
   Private Sub txtCodigo_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoProducto.TextChanged
      If Not _textChangedInternal Then
         If radCodigoODescripcion.Checked Then
            _textChangedInternal = True
            txtNombreProducto.Text = String.Empty
            _textChangedInternal = False
         End If
      End If
   End Sub

   Private Sub txtProducto_TextChanged(sender As Object, e As EventArgs) Handles txtNombreProducto.TextChanged
      If Not _textChangedInternal Then
         If radCodigoODescripcion.Checked Then
            _textChangedInternal = True
            txtCodigoProducto.Text = String.Empty
            _textChangedInternal = False
         End If
      End If
   End Sub
#End Region

#End Region

#Region "Metodos"

   Private Function GetOrdenImpresion() As String

      If Me.rbCodNumerico.Checked Then Return "CodigoNumerico"
      If Me.optOrdenarPorCodigo.Checked Then Return "Codigo"
      If Me.optOrdenarPorNombre.Checked Then Return "Nombre"

      Return Nothing
   End Function

   Private Function CargarDestinatarios() As String

      Dim destinatarios As StringBuilder = New StringBuilder()

      '# Si seleccionó un cliente
      If Me.chbCliente.Checked AndAlso Me.bscCliente2.Selecciono AndAlso Me.bscCodigoCliente2.Selecciono Then
         Dim correoAdministrativo As String = String.Empty
         Dim correoPrincipal As String = String.Empty

         Dim control As Eniac.Controles.Buscador2 = Me.bscCodigoCliente2 '# Si se seleccionó un cliente, siempre se va a llenar le control del Código (si fue por descripción, igual se iguala al control del código).
         correoAdministrativo = control.FilaDevuelta().Cells("CorreoAdministrativo").Value.ToString()
         '.Field(Of String)(Entidades.Cliente.Columnas.CorreoAdministrativo.ToString())
         correoPrincipal = control.FilaDevuelta().Cells("CorreoElectronico").Value.ToString()

         '# Cargo los correos según el valor del parámetro seleccionado y los devuelvo como "Destinatarios"
         With destinatarios
            Select Case Reglas.Publicos.ConfiguraciónMail
               Case Entidades.Cliente.ConfiguracionMail.Administrativo.ToString()
                  .AppendFormat("{0};", correoAdministrativo)
               Case Entidades.Cliente.ConfiguracionMail.Principal.ToString()
                  .AppendFormat("{0};", correoPrincipal)
               Case Entidades.Cliente.ConfiguracionMail.AdminyPrincipal.ToString(), Entidades.Cliente.ConfiguracionMail.AdminoPrincipal.ToString()
                  .AppendFormat("{0};{1}", correoPrincipal, correoAdministrativo)
            End Select
         End With
      End If
      Return destinatarios.ToString()
   End Function

   Private Sub ImprimirInformes(dt As DataTable,
                                   filtros As String,
                                   parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter),
                                   visualiza As Boolean)
      Try

         Dim reporte As Entidades.InformePersonalizadoResuelto
         Dim strReporte As String = String.Empty
         Dim frmImprime As VisorReportes

         If Me.chbAgregarPrecioEmbalaje.Checked Then
            'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientes_SubRubro.rdlc", "dsPrecios_ListaDePreciosCosto", dt, parm, True)
            reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_SubRubro, "Eniac.Win.ListaDePreciosParaClientes_SubRubro.rdlc")
         Else

            '# Agrupar por MARCA
            If Me.optAgruparPorMarca.Checked Then
               If Me.chbConImagen.Checked Then
                  'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientesImagen_Marca.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                  reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientesImagen_Marca, "Eniac.Win.ListaDePreciosParaClientesImagen_Marca.rdlc")
               Else
                  If Me.chb2Columnas.Checked Then
                     ' por marca/alfabético/2c
                     'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientes_Marca2C.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                     reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorMarca2C, "Eniac.Win.ListaDePreciosParaClientes_Marca2C.rdlc")
                  Else
                     ' por marca/código
                     reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorMarca, "Eniac.Win.ListaDePreciosParaClientes_Marca.rdlc")
                  End If
               End If

               '# Agrupar por RUBRO
            ElseIf Me.optAgruparPorRubro.Checked Then
               If Me.chbConImagen.Checked Then
                  'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientesImagen_Rubro.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                  reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientesImagen_Rubro, "Eniac.Win.ListaDePreciosParaClientesImagen_Rubro.rdlc")
               Else
                  If Me.chb2Columnas.Checked Then
                     'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientes_Rubro2C.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                     reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorRubro2C, "Eniac.Win.ListaDePreciosParaClientes_Rubro2C.rdlc")
                  Else
                     ' por marca rubro
                     reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorMarcaRubro, "Eniac.Win.ListaDePreciosParaClientes_Rubro.rdlc")
                  End If
               End If


               '# Agrupar por SUBRUBRO c/Imagen
            ElseIf Me.rbSubRubro.Checked Then
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientesImagen_SubRubro, "Eniac.Win.ListaDePreciosParaClientesImagen_SubRubro.rdlc")

               '# Agrupar por RUBRO SUBRUBRO c/Imagen 
            ElseIf Me.rbRubroSubRubro.Checked Then
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientesImagen_RubroSubRubro, "Eniac.Win.ListaDePreciosParaClientes_Rubro_SubRubro.rdlc")

               '# Agrupar por MARCA RUBRO SUBRUBRO c/Imagen 
            ElseIf Me.rbMarcaRubroSubRubro.Checked Then
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientesImagen_MarcaRubroSubRubro, "Eniac.Win.ListaDePreciosParaClientes_Marca_Rubro_SubRubro.rdlc")

               '# Agrupar por RUBRO SUBRUBRO SUBSUBRUBROS c/Imagen 
            ElseIf Me.rbRubroSubRubroSubSubRubro.Checked Then
               reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientesImagen_MarcaRubroSubRubro, "Eniac.Win.ListaDePreciosParaClientes_Rubro_SubRubro_SubSubRubro.rdlc")

               '# Agrupar por RUBROMARCA
            ElseIf optAgruparPorRubroMarca.Checked Then
               If Me.chb2Columnas.Checked Then
                  If chbCondensado.Checked Then
                     'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientes_Rubro_Marca2C_Mini.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                     reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorRubroMarca2CMini, "Eniac.Win.ListaDePreciosParaClientes_Rubro_Marca2C_Mini.rdlc")
                  Else
                     'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientes_Rubro_Marca2C.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                     reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorRubroMarca2C, "Eniac.Win.ListaDePreciosParaClientes_Rubro_Marca2C.rdlc")
                  End If
               Else
                  ' por rubro marca
                  reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorRubroMarca, "Eniac.Win.ListaDePreciosParaClientes_Rubro_Marca.rdlc")
               End If

               '# Agrupar por MARCARUBRO
            Else
               If Me.chb2Columnas.Checked Then
                  ' por marcaRubro/código/2c
                  'frmImprime = New VisorReportes("Eniac.Win.ListaDePreciosParaClientes_Marca_Rubro2C.rdlc", "dsPrecios_PreciosImagen", dt, parm, True)
                  reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorMarcaRubro2C, "Eniac.Win.ListaDePreciosParaClientes_Marca_Rubro2C.rdlc")
               Else
                  ' por marcaRubro/código
                  reporte = New Reglas.PersonalizacionDeInformes().ResolverInformePersonalizado(Entidades.PersonalizacionDeInforme.Informes.ListaDePreciosParaClientes_PorMarcaRubro, "Eniac.Win.ListaDePreciosParaClientes_Marca_Rubro.rdlc")
               End If
            End If
         End If

         ' # Campo donde voy a guardar el nombre del DS
         Dim ds As String = If(Me.chbAgregarPrecioEmbalaje.Checked, "dsPrecios_ListaDePreciosCosto", "dsPrecios_PreciosImagen")

         If visualiza Then
            frmImprime = New VisorReportes(reporte.NombreArchivo, ds, dt, parm, reporte.ReporteEmbebido, 1) '# 1 = Cantidad Copias
            frmImprime.Text = Me.Text
            frmImprime.WindowState = FormWindowState.Maximized
            frmImprime.Destinatarios = Me.CargarDestinatarios()

            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.rvReporte.DocumentMapCollapsed = True   'Si no hago esto, muestra una grilla a la izquierda.

            frmImprime.Show()
         Else
            Dim ePDF As Eniac.Win.ExportarPDF = New Eniac.Win.ExportarPDF()
            ePDF.Run(reporte.NombreArchivo, "dsPrecios_PreciosImagen", dt, parm, reporte.ReporteEmbebido, "")
         End If

         'frmImprime.Text = "Listado de Precios para Clientes"
         'frmImprime.WindowState = FormWindowState.Maximized
         'frmImprime.StartPosition = FormStartPosition.CenterScreen
         'frmImprime.rvReporte.DocumentMapCollapsed = True   'Si no hago esto, muestra una grilla a la izquierda.
         'frmImprime.Show()

         Me.Cursor = Cursors.Default
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub RefrescarDatos()

      Me.tsbImprimir.Enabled = False

      Me.cmbListaDePrecios.SelectedIndex = 0

      Me.chbConImagen.Checked = False

      cmbMarca.Refrescar()
      cmbRubro.Refrescar()
      cmbSubRubro.Refrescar()
      cmbSSubRubro.Refrescar()

      Me.cmbPrecio.SelectedItem = "de venta"

      Me.chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      Me.chbProducto.Checked = False

      Me.chbConPrecio.Checked = False
      Me.chbConStock.Checked = False

      chbCliente.Checked = False

      Me.optAgruparPorMarca.Checked = True
      Me.optOrdenarPorCodigo.Checked = True

      Me.chbAgregarPrecioEmbalaje.Checked = False

      Me.cmbMoneda.SelectedIndex = 0
      Me.cmbEsOferta.SelectedIndex = 0

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      Me.tssRegistros.Text = " 0 Registros"

      If Me.cmbListaDePrecios.Items.Count = 1 Then
         Me.btnConsultar.Focus()
      Else
         Me.cmbListaDePrecios.Focus()
      End If

      '# Filtros PublicarEn..
      Me.cmbPublicarEnWeb.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbPublicarEnGestion.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbPublicarEnEmpresarial.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbPublicarEnBalanza.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbPublicarEnSincronizarSucursal.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
      Me.cmbPublicarEnListaDePreciosParaClientes.SelectedValue = Entidades.Publicos.SiNoTodos.SI

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim inicioProceso As DateTime = Now
      Dim IdCliente As Long = 0
      Dim IdListaDePrecios As Integer
      Dim IdProducto As String = ""
      Dim ConPrecio As Boolean
      Dim ConStock As Boolean
      Dim EsOferta As String

      Dim FechaActDesde As Date = Nothing
      Dim FechaActHasta As Date = Nothing

      If Me.chbCliente.Checked Then
         If Me.bscCliente2.Selecciono Or Me.bscCodigoCliente2.Selecciono Then
         Else
            MessageBox.Show("Tildo el filtro del cliente y no selecciono ninguno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      End If

      If Me.chbProducto.Checked Then
         If Me.bscCodigoProducto2.Selecciono Or Me.bscProducto2.Selecciono Then
            IdProducto = Me.bscCodigoProducto2.Text
         Else
            MessageBox.Show("Tildo el filtro del producto y no selecciono ninguno.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      End If

      If Me.chbFechaActualizado.Checked Then
         FechaActDesde = Me.dtpDesde.Value
         FechaActHasta = Me.dtpHasta.Value
      End If

      IdListaDePrecios = Integer.Parse(Me.cmbListaDePrecios.SelectedValue.ToString())

      ConPrecio = Me.chbConPrecio.Checked

      ConStock = Me.chbConStock.Checked

      Dim OrdenarPor As String = IIf(Me.optOrdenarPorCodigo.Checked, "CODIGO", "NOMBRE").ToString()

      Dim AgruparPor As String = ""

      If Me.chbAgregarPrecioEmbalaje.Checked Then
         AgruparPor = "SUBRUBRO"
      Else
         If Me.optAgruparPorMarca.Checked Then
            AgruparPor = "MARCA"
         ElseIf Me.optAgruparPorRubro.Checked Then
            AgruparPor = "RUBRO"
         ElseIf optAgruparPorRubroMarca.Checked Then
            AgruparPor = "RUBROMARCA"
         ElseIf optAgruparPorMarcaRubro.Checked Then
            AgruparPor = "MARCARUBRO"
         ElseIf rbRubroSubRubroSubSubRubro.Checked Then
            AgruparPor = "RUBROSUBRUBROSUBSUBRUBRO"

         End If
         ' AgruparPor = IIf(Me.optAgruparPorMarca.Checked, "MARCA", "RUBRO").ToString()
      End If
      If Me.chbProductosCliente.Checked And Me.chbCliente.Checked Then
         IdCliente = Long.Parse(Me.bscCodigoCliente2.Tag.ToString())
      End If

      EsOferta = Me.cmbEsOferta.Text

      '# Filtros Publicar En..
      Dim publicarEn As New Entidades.Filtros.ProductosPublicarEnFiltros()
      publicarEn.Web = cmbPublicarEnWeb.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Gestion = cmbPublicarEnGestion.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Empresarial = cmbPublicarEnEmpresarial.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.Balanza = cmbPublicarEnBalanza.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.SincronizacionSucursal = cmbPublicarEnSincronizarSucursal.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()
      publicarEn.ListaPrecioCliente = cmbPublicarEnListaDePreciosParaClientes.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos)()

      '# Lógica para liberar el DT de la memoria
      If TypeOf (ugDetalle.DataSource) Is DataTable Then
         Dim dtTemp = DirectCast(ugDetalle.DataSource, DataTable)
         Me.ugDetalle.DataSource = dtTemp.Clone()
         dtTemp.Dispose()
      End If

      Dim dtDetalle As DataTable = New Reglas.Productos().GetPreciosListasParaClientes(AgruparPor,
                                                                        OrdenarPor,
                                                                        {actual.Sucursal},
                                                                        IdListaDePrecios,
                                                                        cmbMarca.GetMarcas(True),
                                                                        cmbRubro.GetRubros(True),
                                                                        cmbSubRubro.GetSubRubros(True),
                                                                        cmbSSubRubro.GetSubSubRubros(True),
                                                                        IdProducto,
                                                                        ConPrecio,
                                                                        ConStock,
                                                                        Integer.Parse(cmbMoneda.SelectedValue.ToString()),
                                                                        Decimal.Parse(txtTipoCambio.Text),
                                                                        EsOferta,
                                                                        txtCodigoProducto.Text,
                                                                        txtNombreProducto.Text,
                                                                        FechaActDesde,
                                                                        FechaActHasta,
                                                                        IdCliente,
                                                                        publicarEn)

      Dim PrecioVentaSinIVA As Decimal
      Dim PrecioVentaConIVA As Decimal
      Dim descuentoGeneralDelCliente As Decimal
      Dim descuentosProductos As Reglas.DescuentoRecargoProducto

      Dim cache As Reglas.BusquedasCacheadas
      Dim calcDescRec As Reglas.CalculosDescuentosRecargos = Nothing
      Dim cliente As Entidades.Cliente = Nothing
      dtDetalle.Columns.Add("EAN128", Type.GetType("System.String"))

      If bscCodigoCliente2.Tag IsNot Nothing Then
         cache = New Reglas.BusquedasCacheadas()
         calcDescRec = New Reglas.CalculosDescuentosRecargos(cache)
         cliente = New Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente2.Tag.ToString()))

         cache.BuscaClientesDescuentosMarcas(cliente.IdCliente, -1)
         cache.BuscaClientesDescuentosRubros(cliente.IdCliente, -1)
         cache.BuscaClientesDescuentosSubRubros(cliente.IdCliente, -1)
         cache.BuscaClientesDescuentosProductos(cliente.IdCliente, "")
         cache.BuscaCategoria(-1)
         cache.BuscaSubRubroEntidad(-1)
         cache.BuscaRubro(-1)
      End If

      For Each dr As DataRow In dtDetalle.Rows

         PrecioVentaSinIVA = Decimal.Parse(dr("PrecioVentaSinIVA").ToString())
         PrecioVentaConIVA = Decimal.Parse(dr("PrecioVentaConIVA").ToString())

         'Si no seleccionó cliente, no aplico descuentos/recargos.
         If cliente IsNot Nothing AndAlso calcDescRec IsNot Nothing Then
            descuentoGeneralDelCliente = calcDescRec.DescuentoRecargo(cliente, grabaLibro:=True, esPreElectronico:=False, formaPago:=Nothing, cantidadLineasVenta:=0)
            descuentosProductos = calcDescRec.DescuentoRecargo(cliente, dr, cantidad:=1, decimalesRedondeoEnPrecio:=2) ' 2 decimales para que coincida con la pantalla de facturacion

            'factorConversion:=1 porque el precio ya fué convertido en dolares en el query
            PrecioVentaSinIVA = calcDescRec.GetPreciosConDescuentos(PrecioVentaSinIVA, descuentoGeneralDelCliente, descuentosProductos.DescuentoRecargo1, descuentosProductos.DescuentoRecargo2, factorConversion:=1)
            PrecioVentaConIVA = calcDescRec.GetPreciosConDescuentos(PrecioVentaConIVA, descuentoGeneralDelCliente, descuentosProductos.DescuentoRecargo1, descuentosProductos.DescuentoRecargo2, factorConversion:=1)
         End If
         If Me.cmbPrecio.Text = "de venta" Then
            dr("PrecioVentaSinIVA") = PrecioVentaSinIVA
            dr("PrecioVentaConIVA") = PrecioVentaConIVA
         Else
            dr("PrecioVentaSinIVA") = If(Integer.Parse(dr("Embalaje").ToString()) > 0, PrecioVentaSinIVA / Integer.Parse(dr("Embalaje").ToString()), 0)
            dr("PrecioVentaConIVA") = If(Integer.Parse(dr("Embalaje").ToString()) > 0, PrecioVentaConIVA / Integer.Parse(dr("Embalaje").ToString()), 0)
         End If
         _fechaVigencia = CDate(dr("FechaVigencia")) '-.PE-31542.-
         dr("EAN128") = dr("IdProducto").ToString().ToCode128()
      Next

      Me.ugDetalle.DisplayLayout.Bands(0).Columns("Foto").Hidden = Not Me.chbConImagen.Checked
      Me.ugDetalle.DisplayLayout.Override.DefaultRowHeight = If(Me.chbConImagen.Checked, 43, 20)


      Me.ugDetalle.DataSource = dtDetalle
      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Me.tsbImprimir.Enabled = True
      Me.ugDetalle.Rows.ExpandAll(True)

      'MessageBox.Show(Now.Subtract(inicioProceso).ToString())

   End Sub

   Private Sub CargarProducto(dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
      Me.btnConsultar_Click(Me.btnConsultar, New EventArgs())
   End Sub

   Private Sub SetearColumnas()

      Me.ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaSinIVA").Hidden = Me.chbConIVA.Checked
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("PrecioVentaConIVA").Hidden = Not Me.chbConIVA.Checked

      'Me.ugDetalle.DisplayLayout.Bands(0).Columns("FechaActualizacion").Hidden = Not Me.chbFechaActualizado.Checked

   End Sub

   Private Sub Imprimir()
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         'Dim Filtros As String = Me.CargarFiltrosImpresion
         Dim Titulo As String

         'Titulo = Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros
         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         '# Se deja sin filtros porque esta lista se va para los clientes.

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function
#End Region

   Private Sub chbFechaActualizado_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaActualizado.CheckedChanged
      Try
         Me.dtpDesde.Enabled = Me.chbFechaActualizado.Checked
         Me.dtpHasta.Enabled = Me.chbFechaActualizado.Checked
         Me.dtpDesde.Value = Date.Today
         Me.dtpHasta.Value = Date.Today.AddHours(23).AddMinutes(59).AddSeconds(59)
         If Me.chbFechaActualizado.Checked Then
            Me.dtpDesde.Focus()
         End If
         Me.SetearColumnas()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Me.PreferenciasCargar(ugDetalle, tsbPreferencias)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      Imprimir()
   End Sub



End Class