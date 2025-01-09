Public Class ImportarClientesExcel
   Implements IConParametros

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As OleDb.OleDbConnection
   Private RangoExcel As String
   Private ColumnaCodigoCliente As Integer = 0
   Private ColumnaNombreCliente As Integer = 1
   Private ColumnaDireccion As Integer = 2
   Private ColumnaIdLocalidad As Integer = 3
   Private ColumnaTelefono As Integer = 4
   Private ColumnaCelular As Integer = 5
   Private ColumnaCorreoElectronico As Integer = 6
   Private ColumnaNombreCategoria As Integer = 7
   Private ColumnaNombreCategoriaFiscal As Integer = 8
   Private ColumnaNombreVendedor As Integer = 9
   Private ColumnaNombreListaPrecios As Integer = 10
   Private ColumnaNombreZonaGeografica As Integer = 11
   Private ColumnaCUIT As Integer = 12
   Private ColumnaTipoDocCliente As Integer = 13
   Private ColumnaNroDocCliente As Integer = 14
   Private ColumnaObservacion As Integer = 15
   Private ColumnaFechaAlta As Integer = 16
   Private ColumnaNombreDeFantasia As Integer = 17
   Private ColumnaTwitter As Integer = 18
   Private ColumnaSexo As Integer = 19
   Private ColumnaTipoCliente As Integer = 20
   Private ClientesConError As Integer
   Private _estaCargando As Boolean = True

   Private _modo As Entidades.Cliente.ModoClienteProspecto = Entidades.Cliente.ModoClienteProspecto.Cliente

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()

            If _modo = Entidades.Cliente.ModoClienteProspecto.Prospecto Then
               Text = Text.Replace("Clientes", "Prospectos")
            End If

            _publicos = New Publicos()

            '_publicos.CargaComboMarcas(Me.cmbMarca)

            _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad, {Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS})

            cboAccion.Items.Insert(0, "Todas")
            cboAccion.Items.Insert(1, "Altas")
            cboAccion.Items.Insert(2, "Modificar")

            cboEstado.Items.Insert(0, "Todos")
            cboEstado.Items.Insert(1, "Validos")
            cboEstado.Items.Insert(2, "Invalidos")

            cmbDescripcionCorte.Items.Insert(0, "No Cortar")
            cmbDescripcionCorte.Items.Insert(1, "Cortar")
            cmbDescripcionCorte.Items.Insert(2, "Avisar y Cortar")

            dgvDetalle.Columns("NombreCliente").HeaderText = String.Format("Nombre {0}", _modo.ToString())

            chbCrearCRM.Visible = _modo = Entidades.Cliente.ModoClienteProspecto.Prospecto
            cmbTipoNovedad.Visible = _modo = Entidades.Cliente.ModoClienteProspecto.Prospecto

            CargarValoresIniciales()

            _estaCargando = False

         End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         btnMostrar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            CargarValoresIniciales()
            tssRegistros.Text = dgvDetalle.Rows.Count.ToString() & " Registros"
         End Sub)
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
         Sub()
            If dgvDetalle.RowCount = 0 Then Exit Sub

            If ClientesConError > 0 AndAlso
               ShowPregunta(String.Format("ATENCION: Existen {0} {1}s que NO se Importarán. ¿ Confirma el proceso ?", ClientesConError, _modo.ToString())) <> DialogResult.Yes Then
               Exit Sub
            End If

            ImportarDatos()

            ShowMessage(String.Format("Se importaron {0} {1}s EXITOSAMENTE !!!", dgvDetalle.RowCount - ClientesConError, _modo.ToString()))

            prbImportando.Value = 0
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
         Sub()
            Using frmAbrirArchivo = New OpenFileDialog()

               frmAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
               frmAbrirArchivo.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*"
               frmAbrirArchivo.FilterIndex = 1
               frmAbrirArchivo.RestoreDirectory = True

               If frmAbrirArchivo.ShowDialog() = DialogResult.OK Then
                  Dim ArchivoStream As IO.Stream = Nothing
                  Try
                     ArchivoStream = frmAbrirArchivo.OpenFile()
                     If (ArchivoStream IsNot Nothing) Then
                        txtArchivoOrigen.Text = frmAbrirArchivo.FileName
                        'Si bien aca lo pude abrir, solo es para obtener el path.
                        txtRangoCeldas.Focus()
                     End If
                  Catch ex As Exception
                     Throw New Exception(String.Format("ATENCION: No se puede leer el archivo. Error: {0}", ex.Message))
                  Finally
                     If (ArchivoStream IsNot Nothing) Then
                        ArchivoStream.Close()
                     End If
                  End Try
               End If
            End Using
         End Sub)
   End Sub

   Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
      TryCatched(
         Sub()
            If Not _estaCargando Then
               tsbImportar.Enabled = (cboEstado.Text <> "Invalidos")
            End If
         End Sub)
   End Sub

   Private Sub chbCrearCRM_CheckedChanged(sender As Object, e As EventArgs) Handles chbCrearCRM.CheckedChanged
      TryCatched(Sub() chbCrearCRM.FiltroCheckedChanged(cmbTipoNovedad))
   End Sub

   Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
      TryCatched(
         Sub()
            If txtArchivoOrigen.Text.Trim() = "" Then
               Exit Sub
            End If

            If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
               MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
               Exit Sub
            End If

            RangoExcel = "[" & txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
            If RangoExcel = "" Or RangoExcel = "An : Un" Then
               MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
               txtRangoCeldas.Focus()
               Exit Sub
            End If

            Mostrar()

         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      txtArchivoOrigen.Text = ""

      txtRangoCeldas.Text = "An : Un"

      cboAccion.SelectedIndex = 0
      cboEstado.SelectedIndex = 0
      cmbDescripcionCorte.SelectedIndex = 0

      If TypeOf (dgvDetalle.DataSource) Is DataTable Then
         DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'If Not Me._dt Is Nothing Then
      '   Me._dt.Rows.Clear()
      'End If

      prbImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         '.Columns.Add("LineaExcel", GetType(Long))
         .Columns.Add("Accion", GetType(String))
         .Columns.Add("CodigoCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("IdLocalidad", GetType(Integer))
         .Columns.Add("Telefono", GetType(String))
         .Columns.Add("Celular", GetType(String))
         .Columns.Add("CorreoElectronico", GetType(String))
         '.Columns.Add("PaginaWeb", GetType(String))
         .Columns.Add("NombreCategoria", GetType(String))
         .Columns.Add("NombreCategoriaFiscal", GetType(String))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("NombreListaPrecios", GetType(String))
         .Columns.Add("NombreZonaGeografica", GetType(String))
         .Columns.Add("CUIT", GetType(String))
         .Columns.Add("TipoDocCliente", GetType(String))
         .Columns.Add("NroDocCliente", GetType(Long))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("FechaAlta", GetType(Date))
         .Columns.Add("NombreDeFantasia", GetType(String))
         .Columns.Add("Twitter", GetType(String))
         .Columns.Add("Sexo", GetType(String))
         .Columns.Add("TipoCliente", GetType(String))
         .Columns.Add("Mensaje", GetType(String))
      End With

      Return dtTemp

   End Function

   Sub AbrirExcel(ArchivoXLS As String)

      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If

      ConexionExcel = New System.Data.OleDb.OleDbConnection(m_sConn1)
      ConexionExcel.Open()

   End Sub

   Private Sub Mostrar()
      Try
         Dim rPublicos = New Reglas.Publicos()
         Dim rClientes = New Reglas.Clientes(_modo)
         Dim rLocalidad = New Reglas.Localidades()

         Dim tabla = String.Format("{0}s", _modo.ToString())
         Dim AnchoNombreCliente = rPublicos.GetAnchoCampo(tabla, String.Format("Nombre{0}", _modo.ToString()))
         Dim AnchoCorreoElectronico = rPublicos.GetAnchoCampo(tabla, "CorreoElectronico")

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ClientesConError = 0

         'Leo el archivo y lo subo a la grilla. 

         Dim dt = CrearDT()

         Dim ds = New DataSet()
         Dim DA = New OleDb.OleDbDataAdapter

         AbrirExcel(txtArchivoOrigen.Text)

         DA = New OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         DA.Fill(ds)

         For Each dr As DataRow In ds.Tables(0).Rows

            Application.DoEvents()

            Dim accion = "A"
            Dim importar = True
            Dim mensaje = String.Empty
            Dim drCl = dt.NewRow()

            If dr(ColumnaCodigoCliente).ToString.Trim() = "" Then
               importar = False
               mensaje = "Hay Campo(s) sin completar"
            ElseIf Not IsNumeric(dr(ColumnaCodigoCliente).ToString()) Then
               importar = False
               mensaje = String.Format("Codigo de {0} No es Numerico.", _modo)
            Else
               drCl("CodigoCliente") = Long.Parse(dr(ColumnaCodigoCliente).ToString())
               accion = If(rClientes.ExisteCodigo(Long.Parse(drCl("CodigoCliente").ToString())), "M", "A")
            End If

            drCl("NombreCliente") = dr(ColumnaNombreCliente).ToString.Trim.Replace("'", "´")
            drCl("Direccion") = dr(ColumnaDireccion).ToString.Trim.Replace("'", "´")

            Dim IdLocalidad As Integer = 0
            If Not Integer.TryParse(dr(ColumnaIdLocalidad).ToString(), IdLocalidad) Then
               importar = False
               mensaje = "Codigo de Localidad No es Numerico."
            Else
               drCl("IdLocalidad") = IdLocalidad
               If Not rLocalidad.Existe(Integer.Parse(drCl("IdLocalidad").ToString())) Then
                  importar = False
                  If mensaje.Length > 0 Then mensaje += " - "
                  mensaje += "No existe el Codigo de Localidad " & drCl("IdLocalidad").ToString()
               End If

            End If

            drCl("Telefono") = dr(ColumnaTelefono).ToString.Trim.Replace("'", "´")
            drCl("Celular") = dr(ColumnaCelular).ToString.Trim.Replace("'", "´")

            drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("/", " ")
            If dr(ColumnaCorreoElectronico).ToString.Trim.Length > AnchoCorreoElectronico Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  importar = False
                  If mensaje.Length > 0 Then mensaje += " - "
                  mensaje += "Digitos del Correo Electrónico es Mayor a " & AnchoCorreoElectronico.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("'", "´").Remove(AnchoCorreoElectronico)
                     If mensaje.Length > 0 Then mensaje += " - "
                     mensaje += "Digitos del  Correo Electrónico es Mayor a " & AnchoCorreoElectronico.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("'", "´").Remove(AnchoCorreoElectronico)
                  End If
               End If
            End If

            drCl("NombreCategoria") = dr(ColumnaNombreCategoria).ToString.Trim.Replace("'", "´")
            Dim oCategorias As DataTable = New Reglas.Categorias().GetPorNombreExacto(drCl("NombreCategoria").ToString())
            If oCategorias.Rows.Count = 0 Then
               importar = False
               If mensaje.Length > 0 Then mensaje += " - "
               mensaje += "NO Existe la Categoria"
            End If


            '------------------------------------------------------------------------------------------------------------------------
            drCl("NombreCategoriaFiscal") = dr(ColumnaNombreCategoriaFiscal).ToString.Trim.Replace("'", "´")
            Dim catFisc As DataTable = New Reglas.CategoriasFiscales().GetPorNombreExacto(drCl("NombreCategoriaFiscal").ToString())


            drCl("CUIT") = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
            '-- Valido Existencia de CUIT.- --
            If dr(ColumnaCUIT).ToString.Trim() <> "" Then

               Dim res = Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.Instancia.Validar(dr(ColumnaCUIT).ToString.Trim())
               If res.Error Then
                  mensaje += res.MensajeError
                  importar = False
               Else
                  drCl("CUIT") = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
               End If

               'If dr(ColumnaCUIT).ToString.Length = 11 Then
               '   If Not Publicos.EsCuitValido(dr(ColumnaCUIT).ToString.Trim()) Then
               '      Mensaje += "El número de CUIT es inválido."
               '      Importar = False
               '   Else
               '      drCl("CUIT") = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
               '   End If
               'Else
               '   Mensaje += "El número de CUIT es inválido."
               '   Importar = False
               'End If
            Else
               If catFisc.Rows.Count > 0 AndAlso catFisc(0).Field(Of Boolean)("SolicitaCUIT") Then
                  mensaje += "La Categoría Fiscal requiere CUIT."
                  importar = False
               End If
            End If

            If catFisc.Rows.Count = 0 Then
               importar = False
               If mensaje.Length > 0 Then mensaje += " - "
               mensaje += "NO Existe La Categoria Fiscal"
            End If

            '-----------------------------------------------------------------------------------------------------------------------------

            drCl("NombreVendedor") = dr(ColumnaNombreVendedor).ToString.Trim.Replace("'", "´")
            Dim oEmpleados As DataTable = New Reglas.Empleados().GetPorNombreExacto(drCl("NombreVendedor").ToString())
            If oEmpleados.Rows.Count = 0 Then
               importar = False
               If mensaje.Length > 0 Then mensaje += " - "
               mensaje += "NO Existe el Vendedor"
            End If

            drCl("NombreListaPrecios") = dr(ColumnaNombreListaPrecios).ToString.Trim.Replace("'", "´")
            Dim oListaPrecios As DataTable = New Reglas.ListasDePrecios().GetPorNombreExacto(drCl("NombreListaPrecios").ToString())
            If oListaPrecios.Rows.Count = 0 Then
               importar = False
               If mensaje.Length > 0 Then mensaje += " - "
               mensaje += "NO Existe La Lista de Precios"
            End If

            drCl("NombreZonaGeografica") = dr(ColumnaNombreZonaGeografica).ToString.Trim.Replace("'", "´")
            Dim oZonaGeograf As DataTable = New Reglas.ZonasGeograficas().GetPorNombreExacto(drCl("NombreZonaGeografica").ToString())
            If oZonaGeograf.Rows.Count = 0 Then
               importar = False
               If mensaje.Length > 0 Then mensaje += " - "
               mensaje += "NO Existe La Zona Geografica"
            End If

            If Not String.IsNullOrEmpty(dr(ColumnaTipoDocCliente).ToString()) Then
               drCl("TipoDocCliente") = dr(ColumnaTipoDocCliente).ToString.Trim.Replace("'", "´")
               If String.IsNullOrEmpty(dr(ColumnaNroDocCliente).ToString()) Then
                  importar = False
                  mensaje = "Falta el Numero de Documento."
               End If
            End If

            If Not String.IsNullOrEmpty(dr(ColumnaNroDocCliente).ToString()) Then
               Dim lngNroDocumento As Long = 0
               If Not Long.TryParse(dr(ColumnaNroDocCliente).ToString(), lngNroDocumento) Then
                  importar = False
                  mensaje = "Numero de Documento No es Numerico."
               Else
                  drCl("NroDocCliente") = lngNroDocumento

                  If String.IsNullOrEmpty(dr(ColumnaTipoDocCliente).ToString()) Then
                     importar = False
                     mensaje = "Falta el Tipo de Documento."
                  End If
               End If
            End If

            drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´")

            If Not IsDBNull(dr(ColumnaFechaAlta)) AndAlso IsDate(dr(ColumnaFechaAlta)) Then
               drCl("FechaAlta") = Date.Parse(dr(ColumnaFechaAlta).ToString())
            Else
               drCl("FechaAlta") = Date.Today()
            End If

            drCl("NombreDeFantasia") = dr(ColumnaNombreDeFantasia).ToString

            drCl("Twitter") = dr(ColumnaTwitter).ToString

            drCl("Sexo") = dr(ColumnaSexo).ToString.Trim.Replace("'", "´")
            If drCl("Sexo").ToString() <> Entidades.Cliente.SexoOpciones.Femenino.ToString() And drCl("Sexo").ToString() <> Entidades.Cliente.SexoOpciones.Masculino.ToString() And
               drCl("Sexo").ToString() <> Entidades.Cliente.SexoOpciones.Indefinido.ToString() And drCl("Sexo").ToString() <> Entidades.Cliente.SexoOpciones.NoAplica.ToString() Then
               drCl("Sexo") = Entidades.Cliente.SexoOpciones.NoAplica.ToString()
            End If

            '-.PE-32498.-

            drCl("TipoCliente") = dr(ColumnaTipoCliente).ToString.Trim.Replace("'", "´")
            Dim rTiposCliente As DataTable = New Reglas.TiposClientes().GetAllPorNombre(drCl("TipoCliente").ToString(), nombreExacto:=True)
            If rTiposCliente.Rows.Count = 0 Then
               importar = False
               If mensaje.Length > 0 Then mensaje += " - "
               mensaje += String.Format("NO Existe El Tipo de {0}", _modo.ToString())
            End If

            drCl("Importa") = importar

            If Not importar Then
               ClientesConError += 1
               drCl("Mensaje") = mensaje
               accion = "X"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And importar) Or (Me.cboEstado.Text = "Invalidos" And Not importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And accion = "A") Or (Me.cboAccion.Text = "Modificar" And accion = "M")) Then
               dt.Rows.Add(drCl)
            End If

         Next

         ConexionExcel.Close()

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ClientesConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos = DirectCast(dgvDetalle.DataSource, DataTable)
      Dim reg = New Reglas.Clientes(_modo)
      reg.ImportarClientes(actual.Sucursal.Id, dtDatos,
                           cmbTipoNovedad.ItemSeleccionado(Of Entidades.CRMTipoNovedad),
                           actual.Nombre, prbImportando)

   End Sub

   Public Sub SetParametros(parametros As String) Implements IConParametros.SetParametros
      TryCatched(Sub() _modo = If(parametros = "PROSP", Entidades.Cliente.ModoClienteProspecto.Prospecto, Entidades.Cliente.ModoClienteProspecto.Cliente))
   End Sub
   Public Function GetParametrosDisponibles() As String Implements IConParametros.GetParametrosDisponibles
      Dim stb = New StringBuilder()
      stb.AppendFormatLine("Modalidad de la pantalla.")
      stb.AppendFormatLine("Valores posibles: PROSP o blanco")
      stb.AppendFormatLine("Si PROSP usa modo Prospecto. Si blanco usa modo Cliente")
      stb.AppendFormatLine("Por defecto: blanco")
      stb.AppendFormatLine("El valor se carga directamente.")
      Return stb.ToString()
   End Function

#End Region

End Class