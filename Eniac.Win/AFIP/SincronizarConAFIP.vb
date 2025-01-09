Imports System.ComponentModel

Public Class SincronizarConAFIP

#Region "Campos"
   Public wsPadron As Reglas.AFIPPN4
   Private _SinInternet As Boolean = False
   Private _IdContribuyente As Long = 0
   Private _Inicio As Boolean = False
   Protected Property ModoClienteProspecto As Entidades.Cliente.ModoClienteProspecto
   Public TipoClienteProveedor As Entidades.Publicos.TipoContribuyente = Entidades.Publicos.TipoContribuyente.CLIENTE
   Private _direcciones As DataTable

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         '-- Inicializa Variables.- 
         LimpiarCamposDatos()
         '-------------------------
         wsPadron = New Reglas.AFIPPN4
         '-- Testing Conexion a Internet-AFIP.- 
         TestGeneralesAFIP()
         '-- Posiciona.- --
         txtNroCuit.Focus()
         _Inicio = True
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"
   Private Sub Refrescar()
      '-- Datos.- --------------------
      txtTipoPersona.Text = String.Empty
      txtEstadoClave.Text = String.Empty
      txtTipoDocumento.Text = String.Empty
      txtNroDocumento.Text = String.Empty
      txtRazonSocial.Text = String.Empty
      txtNombre.Text = String.Empty
      txtApellido.Text = String.Empty
      txtCategoriaFiscal.Text = String.Empty
      '-------------------------------
      ugDomicilios.ClearFilas()
      ugDomicilios.Refresh()
      ugActividades.ClearFilas()
      ugActividades.Refresh()
      ugImpuestos.ClearFilas()
      ugImpuestos.Refresh()
      '-------------------------------
      btnNuevo.Enabled = False
      btnEditar.Enabled = False
   End Sub
   Private Sub LimpiarCamposDatos()
      '-- Datos Conexion.- ----------
      tssServidor.Text = "Servidor: "
      tssFecha.Text = "Fecha: "
      '-- CUIT.- --------------------
      txtNroCuit.Text = String.Empty
      Refrescar()
   End Sub

   Private Sub CargaDatosPersona(persona As Reglas.WSPN4.personaReturn)
      '-- Carga Datos.- --
      If persona IsNot Nothing Then
         With persona.datosGenerales
            txtTipoPersona.Text = .tipoPersona
            txtEstadoClave.Text = .estadoClave
            txtRazonSocial.Text = .razonSocial
            txtNombre.Text = .nombre
            txtApellido.Text = .apellido
            txtTipoDocumento.Text = .tipoClave
            txtNroDocumento.Text = .idPersona.ToString()
            '-- Domicilio.- 
            Dim eDomic As New List(Of Eniac.Reglas.WSPN4.domicilio)
            eDomic.Add(.domicilioFiscal)
            ugDomicilios.DataSource = eDomic
            FormatearGrillasDomicilios()
            '----------------------------------------
            txtTipoDocumento.Text = .tipoClave
            txtNroDocumento.Text = .idPersona.ToString()
         End With
      End If
      '-- Consumidor Final.- -------------------------------------------
      txtCategoriaFiscal.Text = "Consumidor Final"
      txtCategoriaFiscal.Tag = 1
      '-----------------------------------------------------------------
      If persona.datosRegimenGeneral IsNot Nothing Then
         With persona.datosRegimenGeneral
            '-- Actividad.- 
            ugActividades.DataSource = .actividad
            FormatearGrillasActividades()
            '-- Impuestos.- 
            Dim eImpu As New List(Of Eniac.Reglas.WSPN4.impuesto)
            eImpu = .impuesto.ToList()
            ugImpuestos.DataSource = eImpu
            FormatearGrillasImpuestos()
            '-- Obtiene Categoria Fiscal.- --
            ObtieneCategoriaFiscal(.impuesto)
         End With
      End If
      If persona.datosMonotributo IsNot Nothing Then
         With persona.datosMonotributo
            '-- Actividad.- 
            Dim eActiv As New List(Of Eniac.Reglas.WSPN4.actividad)
            eActiv.Add(.actividadMonotributista)
            ugActividades.DataSource = eActiv
            FormatearGrillasActividades()
            '-- Impuestos.- 
            Dim eImpu As New List(Of Eniac.Reglas.WSPN4.impuesto)
            eImpu = .impuesto.ToList()
            ugImpuestos.DataSource = eImpu
            FormatearGrillasImpuestos()
            '-- Obtiene Categoria Fiscal.- --
            ObtieneCategoriaFiscal(.impuesto)
         End With
      End If
   End Sub
   Private Sub ObtieneCategoriaFiscal(impuestos As Reglas.WSPN4.impuesto())
      '-- Consumidor Final.- -------------------------------------------
      txtCategoriaFiscal.Text = "Consumidor Final"
      txtCategoriaFiscal.Tag = 1
      '-- MonoTributista.- ---------------------------------------------
      If impuestos.Where(Function(x) x.idImpuesto = 20).Count > 0 Then
         If actual.Sucursal.Empresa.IdCategoriaFiscal = 2 Then
            txtCategoriaFiscal.Text = "Monotributista A"
            txtCategoriaFiscal.Tag = 9
         Else
            txtCategoriaFiscal.Text = "Monotributista"
            txtCategoriaFiscal.Tag = 6
         End If
      End If
      '-- Responsable Inscripto.- --------------------------------------
      If impuestos.Where(Function(x) x.idImpuesto = 30).Count > 0 Then
         txtCategoriaFiscal.Text = "Responsable Inscripto"
         txtCategoriaFiscal.Tag = 2
      End If
      '-- Exento.- -----------------------------------------------------
      If impuestos.Where(Function(x) x.idImpuesto = 32).Count > 0 Then
         txtCategoriaFiscal.Text = "Exento"
         txtCategoriaFiscal.Tag = 4
      End If

   End Sub
   Private Sub FormatearGrillasDomicilios()
      '-- Telefonos.- ---
      If ugDomicilios.DisplayLayout.Bands(0).Columns.Count = 0 Then
         Exit Sub
      End If

      Dim pos As Integer = 0
      With ugDomicilios.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         .Columns("tipoDomicilio").FormatearColumna("Tipo Domicilio", pos, 100, HAlign.Left)
         .Columns("direccion").FormatearColumna("Dirección", pos, 211, HAlign.Left)
         .Columns("codPostal").FormatearColumna("Cod. Postal", pos, 70, HAlign.Center)
         .Columns("localidad").FormatearColumna("Localidad", pos, 115, HAlign.Left)
         .Columns("descripcionProvincia").FormatearColumna("Provincia", pos, 115, HAlign.Left)
      End With
   End Sub
   Private Sub FormatearGrillasActividades()
      '-- Telefonos.- ---
      If ugActividades.DisplayLayout.Bands(0).Columns.Count = 0 Then
         Exit Sub
      End If
      Dim pos As Integer = 0
      With ugActividades.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         .Columns("idActividad").FormatearColumna("Codigo", pos, 66, HAlign.Right)
         .Columns("descripcionActividad").FormatearColumna("Descripción", pos, 320, HAlign.Left)
         .Columns("nomenclador").FormatearColumna("Nomenclador", pos, 100, HAlign.Center)
         .Columns("periodo").FormatearColumna("Período", pos, 80, HAlign.Center)
      End With
   End Sub
   Private Sub FormatearGrillasImpuestos()
      '-- Impuestos.- ---
      If ugImpuestos.DisplayLayout.Bands(0).Columns.Count = 0 Then
         Exit Sub
      End If
      Dim pos As Integer = 0
      With ugImpuestos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         .Columns("idImpuesto").FormatearColumna("Codigo", pos, 64, HAlign.Right)
         .Columns("descripcionImpuesto").FormatearColumna("Descripción", pos, 340, HAlign.Left)
         .Columns("periodo").FormatearColumna("Período", pos, 70, HAlign.Center)
      End With
   End Sub

   Private Sub CargaContribuyenteSiga(cuit As String)
      Dim cstContribuyente As DataTable = Nothing
      Select Case TipoClienteProveedor
         Case Entidades.Publicos.TipoContribuyente.CLIENTE
            '-- Carga Listado Contribuyentes.- ------------------------------------------------------------------
            cstContribuyente = New Reglas.Clientes().GetFiltradoPorCUIT(cuit, False)
            If cstContribuyente IsNot Nothing AndAlso cstContribuyente.Rows.Count > 0 Then
               MessageBox.Show(String.Format("Nro. CUIT ya Ingresado en Cliente {0}.", cstContribuyente(0).Field(Of String)("NombreCliente")), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               With cmbContribuyentes
                  .DisplayMember = "NombreCliente"
                  .ValueMember = "IdCliente"
                  .DataSource = cstContribuyente
               End With
               cmbContribuyentes.SelectedIndex = 0
            End If
            btnNuevo.Enabled = (cstContribuyente IsNot Nothing)
            btnEditar.Enabled = (cstContribuyente IsNot Nothing AndAlso cstContribuyente.Rows.Count >= 1)
            '-- Visualiza Contribuyentes.- ----------------------------------------------------------------------
            lblContribuyentes.Visible = (cstContribuyente IsNot Nothing AndAlso cstContribuyente.Rows.Count > 1)
            cmbContribuyentes.Visible = (cstContribuyente IsNot Nothing AndAlso cstContribuyente.Rows.Count > 1)
            '----------------------------------------------------------------------------------------------------
         Case Entidades.Publicos.TipoContribuyente.PROVEEDOR
            '-- Carga Listado Contribuyentes.- ------------------------------------------------------------------
            cstContribuyente = New Reglas.Proveedores().GetFiltradoPorCUIT(cuit)
            If cstContribuyente IsNot Nothing AndAlso cstContribuyente.Rows.Count > 0 Then
               MessageBox.Show(String.Format("Nro. CUIT ya Ingresado en Proveedor {0}. Solo se puede Editar.", cstContribuyente(0).Field(Of String)("NombreProveedor")), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               With cmbContribuyentes
                  .DisplayMember = "NombreProveedor"
                  .ValueMember = "IdProveedor"
                  .DataSource = cstContribuyente
               End With
               cmbContribuyentes.SelectedIndex = 0
            End If
            btnNuevo.Enabled = (cstContribuyente.Rows.Count = 0)
            btnEditar.Enabled = (cstContribuyente IsNot Nothing AndAlso cstContribuyente.Rows.Count >= 1)
      End Select
   End Sub
   Private Sub TestGeneralesAFIP()

      Me.pcbInternet.Image = My.Resources.server_cancel_48
      Me.pcbAFIP.Image = My.Resources.server_cancel_48

      If Publicos.HayInternet() Then
         pcbInternet.Image = My.Resources.server_ok_48
         Dim wsState = wsPadron.VerificaEstadoAFIP()
         With wsState
            If .appserver = "OK" Or .authserver = "OK" Or .dbserver = "OK" Then
               pcbAFIP.Image = My.Resources.server_ok_48
               pcbInternet.Image = My.Resources.server_ok_48
               pcbAFIP.Image = My.Resources.server_ok_48
            End If
         End With
         _SinInternet = False
      Else
         _SinInternet = True
      End If

   End Sub
   Private Function GetEntidad() As Eniac.Entidades.Entidad
      Return CargaDatosCliente()
   End Function

   Private Function CargaDatosCliente() As Entidades.Cliente
      Dim Contribuyente = New Entidades.Cliente
      Dim blnIncluirFoto As Boolean = True
      Dim blnIncluirAdjuntos As Entidades.ModoCargaAdjunto = Entidades.ModoCargaAdjunto.SinDatos
      '-- Recupera un Cliente.- -- 
      Contribuyente = New Reglas.Clientes(ModoClienteProspecto).GetUno(_IdContribuyente, blnIncluirFoto, blnIncluirAdjuntos)
      Contribuyente.Usuario = actual.Nombre
      '-- Carga Datos anexos.- --
      With Contribuyente
         .IdAplicacion = ""
         Select Case txtTipoPersona.Text
            Case "JURIDICA"
               .NombreCliente = txtRazonSocial.Text
            Case Else
               .NombreCliente = txtApellido.Text & " " & txtNombre.Text
         End Select
         '-- Domicilio.- --
         .Direccion = String.Empty
         Select Case ugDomicilios.Rows.Count
            Case = 1
               For Each domic In ugDomicilios.Rows
                  .Direccion = domic.Cells("direccion").Value.ToString()
                  .Localidad = New Reglas.Localidades().GetUna(Integer.Parse(domic.Cells("codPostal").Value.ToString()))
               Next
            Case > 1
               Dim ordDom = 1
               For Each domic In ugDomicilios.Rows
                  If ordDom = 1 Then
                     .Direccion = domic.Cells("direccion").Value.ToString()
                     .Localidad = New Reglas.Localidades().GetUna(Integer.Parse(domic.Cells("codPostal").Value.ToString()))
                  End If
                  ordDom += 1
               Next
         End Select
         If txtTipoPersona.Text = "JURIDICA" Then
            '-- Sexo.- --
            .Sexo = Entidades.Cliente.SexoOpciones.NoAplica
         Else
            '-- Sexo.- --
            .Sexo = Entidades.Cliente.SexoOpciones.Indefinido
         End If
         '-- CUIT.- - 
         .NombreDeFantasia = txtRazonSocial.Text
         .Cuit = txtNroCuit.Text
         If txtEstadoClave.Text = "ACTIVO" Then
            .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(txtCategoriaFiscal.Tag.ToString()))
         Else
            .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(1)
            MessageBox.Show("Cliente Inactivo en AFIP. Se carga como Consumidor Final.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End With
      Return Contribuyente
   End Function
   Private Function CargaDatosProveedor() As Entidades.Proveedor
      Dim Contribuyente = New Entidades.Proveedor
      '-- Recupera un Cliente.- -- 
      Contribuyente = New Reglas.Proveedores().GetUno(_IdContribuyente)
      Contribuyente.Usuario = actual.Nombre
      '-- Carga Datos anexos.- --
      With Contribuyente
         Select Case txtTipoPersona.Text
            Case "JURIDICA"
               .NombreProveedor = txtRazonSocial.Text
            Case Else
               .NombreProveedor = txtApellido.Text & " " & txtNombre.Text
         End Select
         '-- Domicilio.- --
         .DireccionProveedor = String.Empty
         Select Case ugDomicilios.Rows.Count
            Case = 1
               For Each domic In ugDomicilios.Rows
                  .DireccionProveedor = domic.Cells("direccion").Value.ToString()
                  Dim Localida = New Reglas.Localidades().GetUna(Integer.Parse(domic.Cells("codPostal").Value.ToString()))
                  .IdLocalidadProveedor = Localida.IdLocalidad
               Next
            Case > 1
               Dim ordDom = 1
               For Each domic In ugDomicilios.Rows
                  If ordDom = 1 Then
                     .DireccionProveedor = domic.Cells("direccion").Value.ToString()
                     Dim Localida = New Reglas.Localidades().GetUna(Integer.Parse(domic.Cells("codPostal").Value.ToString()))
                     .IdLocalidadProveedor = Localida.IdLocalidad
                  End If
                  ordDom += 1
               Next
         End Select
         '-- CUIT.- - 
         .NombreDeFantasia = txtRazonSocial.Text
         .CuitProveedor = txtNroCuit.Text
         If txtEstadoClave.Text = "ACTIVO" Then
            .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(Short.Parse(txtCategoriaFiscal.Tag.ToString()))
         Else
            .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(1)
            MessageBox.Show("Proveedor Inactivo en AFIP. Se carga como Consumidor Final.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End With
      Return Contribuyente
   End Function
   Private Sub creaEstructuraDirecciones()
      If Me._direcciones Is Nothing Then
         Me._direcciones = New DataTable()
         Me._direcciones.Columns.Add("IdDireccion", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("IdCliente", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("Direccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("IdTipoDireccion", System.Type.GetType("System.Int32"))
         Me._direcciones.Columns.Add("NombreAbrevTipoDireccion", System.Type.GetType("System.String"))
         Me._direcciones.Columns.Add("DireccionAdicional", System.Type.GetType("System.String"))
      End If
      _direcciones.Rows.Clear()
   End Sub

#End Region

#Region "Eventos"
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Refrescar()
         '-- Testea Conexion.- --
         TestGeneralesAFIP()
         '-----------------------
         If Me._SinInternet Then
            MessageBox.Show("Sin Internet, Por favor revise la conexión y luego presione el boton de Testear Servidores AFIP para continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         Else
            If txtNroCuit.Text.Trim().Length = 11 Then
               Dim resp = wsPadron.GetDatosContribuyento(Long.Parse(txtNroCuit.Text))
               '-- Asigna Datos de Proceso-Servidor.- --
               With resp.metadata
                  tssServidor.Text = .servidor
                  tssFecha.Text = .fechaHora.ToString()
               End With
               If resp.datosGenerales IsNot Nothing Then
                  CargaDatosPersona(resp)
                  CargaContribuyenteSiga(resp.datosGenerales.idPersona.ToString())
               Else
                  MessageBox.Show(String.Format("La Clave Ingresada {3}( {0} - {1} {2} ) {3} No es un CUIT Válido ",
                                                resp.errorConstancia.idPersona,
                                                resp.errorConstancia.apellido,
                                                resp.errorConstancia.nombre, Environment.NewLine), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  '-- REQ-43952.- ------------------------------------------------------------------------------------------------------------------------------------
                  'Select Case TipoClienteProveedor
                  '   Case Entidades.Publicos.TipoContribuyente.CLIENTE
                  '      Dim Contribuyente = New Entidades.Cliente
                  '      ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
                  '      With Contribuyente
                  '         .Usuario = actual.Nombre
                  '         .IdAplicacion = ""
                  '         .NombreCliente = resp.errorConstancia.apellido & " " & resp.errorConstancia.nombre
                  '         .Sexo = Entidades.Cliente.SexoOpciones.Indefinido
                  '         .Direccion = String.Empty
                  '         .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(1)
                  '      End With
                  '      Using frm As New ClientesDetalle(Contribuyente, ModoClienteProspecto)
                  '         '-- Establece Estado.- --
                  '         frm.StateForm = StateForm.Insertar
                  '         frm.ShowDialog()
                  '      End Using
                  '   Case Entidades.Publicos.TipoContribuyente.PROVEEDOR
                  '      Dim Contribuyente = New Entidades.Proveedor
                  '      With Contribuyente
                  '         .Usuario = actual.Nombre
                  '         .NombreProveedor = resp.errorConstancia.apellido & " " & resp.errorConstancia.nombre
                  '         .CuitProveedor = resp.errorConstancia.idPersona.ToString
                  '         .DireccionProveedor = String.Empty
                  '         .CategoriaFiscal = New Reglas.CategoriasFiscales().GetUno(1)
                  '      End With
                  '      Using frm As New ProveedoresDetalle(Contribuyente)
                  '         '-- Establece Estado.- --
                  '         frm.StateForm = StateForm.Insertar
                  '         frm.ShowDialog()
                  '      End Using
                  'End Select
                  '---------------------------------------------------------------------------------------------------------------------------------------------------
                  Refrescar()
               End If
            Else
               MessageBox.Show("El Nro. de CUIT es inválido", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Refrescar()
               txtNroCuit.Select()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(Replace(ex.Message, "Id", "CUIT"), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Refrescar()
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub btnTesteaServidorAfip_Click(sender As Object, e As EventArgs) Handles btnTesteaServidorAfip.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.TestGeneralesAFIP()
         Me.Cursor = Cursors.Default

         If _SinInternet Then
            MessageBox.Show("Sin Internet, Por favor revise la conexión y luego presione el boton de Testear Servidores AFIP para continuar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
      Select Case TipoClienteProveedor
         Case Entidades.Publicos.TipoContribuyente.CLIENTE
            ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
            Using frm As New ClientesDetalle(DirectCast(Me.GetEntidad(), Entidades.Cliente), ModoClienteProspecto)
               '-- Domicililios.- --
               frm.tbcCliente.SelectedTab = frm.tbpDatos
               Select Case ugDomicilios.Rows.Count
                  Case = 1
                     frm.bscCodigoLocalidad.Text = ugDomicilios.Rows(0).Cells("codPostal").Value.ToString()
                  Case > 1
                     frm.tbcCliente.SelectedTab = frm.tbpDirecciones
                     creaEstructuraDirecciones()
                     Dim tipoDir = New Reglas.TiposDirecciones().GetUna(2)
                     _direcciones.Rows.Clear()
                     Dim ordDom = 1
                     For Each domic In ugDomicilios.Rows
                        If ordDom >= 2 Then
                           Dim dr As DataRow = Me._direcciones.NewRow()
                           dr("IdDireccion") = 0
                           dr("IdCliente") = _IdContribuyente
                           dr("Direccion") = domic.Cells("direccion").Value.ToString()
                           dr("IdLocalidad") = domic.Cells("codPostal").Value.ToString()
                           dr("NombreLocalidad") = If(domic.Cells("localidad").Value Is Nothing, String.Empty, domic.Cells("localidad").Value.ToString())
                           dr("NombreProvincia") = domic.Cells("descripcionProvincia").Value.ToString()
                           dr("IdTipoDireccion") = tipoDir.IdTipoDireccion
                           dr("NombreAbrevTipoDireccion") = tipoDir.NombreAbrevTipoDireccion
                           dr("DireccionAdicional") = ""
                           _direcciones.Rows.Add(dr)
                        End If
                        ordDom += 1
                     Next
                     frm._domicilios = _direcciones
               End Select
               '--------------------
               frm.StateForm = StateForm.Actualizar
               frm.ShowDialog()
            End Using
         Case Entidades.Publicos.TipoContribuyente.PROVEEDOR
            Dim Contribuyente = CargaDatosProveedor()
            Using frm As New ProveedoresDetalle(Contribuyente)
               '-- Domicililios.- --
               Select Case ugDomicilios.Rows.Count
                  Case = 1
                     frm.bscCodigoLocalidad.Text = ugDomicilios.Rows(0).Cells("codPostal").Value.ToString()
               End Select
               '-- Establece Estado.- --
               frm.StateForm = StateForm.Actualizar
               frm.ShowDialog()
            End Using

      End Select
      Me.Close()
   End Sub

   Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
      Select Case TipoClienteProveedor
         Case Entidades.Publicos.TipoContribuyente.CLIENTE
            ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente
            Dim Contribuyente = CargaDatosCliente()
            Using frm As New ClientesDetalle(Contribuyente, ModoClienteProspecto)
               frm._publicos = New Publicos()
               '-- Domicililios.- --
               frm.tbcCliente.SelectedTab = frm.tbpDatos
               Select Case ugDomicilios.Rows.Count
                  Case = 1
                     frm.bscCodigoLocalidad.Text = ugDomicilios.Rows(0).Cells("codPostal").Value.ToString()
                  Case > 1
                     creaEstructuraDirecciones()
                     _direcciones.Rows.Clear()
                     Dim ordDom = 1
                     For Each domic In ugDomicilios.Rows
                        Select Case ordDom
                           Case 1
                              frm.tbcCliente.SelectedTab = frm.tbpDatos
                              frm.bscCodigoLocalidad.Text = ugDomicilios.Rows(0).Cells("codPostal").Value.ToString()
                           Case >= 2
                              frm.tbcCliente.SelectedTab = frm.tbpDirecciones
                              Dim dr As DataRow = Me._direcciones.NewRow()
                              dr("IdDireccion") = 0
                              dr("IdCliente") = _IdContribuyente
                              dr("Direccion") = domic.Cells("direccion").Value.ToString()
                              dr("IdLocalidad") = domic.Cells("codPostal").Value.ToString()
                              dr("NombreLocalidad") = If(domic.Cells("localidad").Value Is Nothing, String.Empty, domic.Cells("localidad").Value.ToString())
                              dr("NombreProvincia") = domic.Cells("descripcionProvincia").Value.ToString()
                              dr("IdTipoDireccion") = 1
                              dr("NombreAbrevTipoDireccion") = "F"
                              _direcciones.Rows.Add(dr)
                        End Select
                        ordDom += 1
                     Next
                     frm._domicilios = _direcciones
               End Select
               '-- Establece Estado.- --
               frm.StateForm = StateForm.Insertar
               frm.ShowDialog()
            End Using
         Case Entidades.Publicos.TipoContribuyente.PROVEEDOR
            Dim Contribuyente = CargaDatosProveedor()
            Using frm As New ProveedoresDetalle(Contribuyente)
               '-- Domicililios.- --
               Select Case ugDomicilios.Rows.Count
                  Case = 1
                     frm.bscCodigoLocalidad.Text = ugDomicilios.Rows(0).Cells("codPostal").Value.ToString()
                  Case > 1
                     creaEstructuraDirecciones()
                     _direcciones.Rows.Clear()
                     Dim ordDom = 1
                     For Each domic In ugDomicilios.Rows
                        Select Case ordDom
                           Case 1
                              frm.tbcProveedor.SelectedTab = frm.tbpDatos
                              frm.bscCodigoLocalidad.Text = ugDomicilios.Rows(0).Cells("codPostal").Value.ToString()
                        End Select
                        ordDom += 1
                     Next
               End Select
               '-- Establece Estado.- --
               frm.StateForm = StateForm.Insertar
               frm.ShowDialog()
            End Using
      End Select
      Me.Close()
   End Sub
   Private Sub cmbContribuyentes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbContribuyentes.SelectedIndexChanged
      _IdContribuyente = Long.Parse(cmbContribuyentes.SelectedValue.ToString())
   End Sub

   Private Sub txtNroCuit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNroCuit.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnConsultar.PerformClick()
      End If
   End Sub

   Private Sub lblAutorización_Click(sender As Object, e As EventArgs) Handles lblAutorización.Click
      ugImpuestos.ClearFilas()
      ugImpuestos.Refresh()
   End Sub

#End Region
End Class