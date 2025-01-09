Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO
Imports System.Globalization

#End Region

Public Class ImportarClientesCalidad

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   Private ColumnaCodigoCliente As Integer = 0
   Private ColumnaNombreCliente As Integer = 1
   Private ColumnaDireccion As Integer = 3
   Private ColumnaIdLocalidad As Integer = 6
   Private ColumnaTelefono As Integer = 7
   Private ColumnaCelular As Integer = 5
   Private ColumnaCorreoElectronico As Integer = 9
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
   Private ColumnaNombreDeFantasia As Integer = 2
   Private ColumnaTwitter As Integer = 18
   Private ClientesConError As Integer

   Private ColumnaModeloCodigo = 0
   Private ColumnaModeloDescripcion = 1
   Private ModelsosConError As Integer

   'Chasis
   Private ColumnaIdProducto As Integer = 0
   Private ColumnaNombreProducto As Integer = 1
   Private ColumnaNumeroChasis As Integer = 2
   Private ColumnaNrodeMotor As Integer = 4
   Private ChasisConError As Integer

   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Me._publicos.CargaComboMarcas(Me.cmbMarca)

      Me.cboAccion.Items.Insert(0, "Todas")
      Me.cboAccion.Items.Insert(1, "Altas")
      Me.cboAccion.Items.Insert(2, "Modificar")

      Me.cboEstado.Items.Insert(0, "Todos")
      Me.cboEstado.Items.Insert(1, "Validos")
      Me.cboEstado.Items.Insert(2, "Invalidos")

      Me.cmbDescripcionCorte.Items.Insert(0, "No Cortar")
      Me.cmbDescripcionCorte.Items.Insert(1, "Cortar")
      Me.cmbDescripcionCorte.Items.Insert(2, "Avisar y Cortar")

      Me.TabControl1.TabPages.Remove(tbpChasisEnUso)

      Me.CargarValoresIniciales()

      Me._estaCargando = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarClientesExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
         Me.tssRegistrosModelos.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Try

         ' Me.tsbImportar.Enabled = False

         Me.Cursor = Cursors.WaitCursor

         Me.Mostrar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click

      Dim ArchivoStream As Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*"
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               Me.txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Me.txtRangoCeldas.Focus()
            End If
         Catch Ex As Exception
            MessageBox.Show("ATENCION: No se puede leer el archivo. Error: " & Ex.Message)
         Finally
            If (ArchivoStream IsNot Nothing) Then
               ArchivoStream.Close()
            End If
         End Try
      End If

   End Sub

   Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click

      Try

         If Me.txtArchivoOrigen.Text.Trim() = "" Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         RangoExcel = "[" & Me.txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
         If RangoExcel = "" Or RangoExcel = "An : Sn" Then
            MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
            Me.txtRangoCeldas.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.Mostrar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try

         If Me.dgvDetalle.Rows.Count = 0 And Me.dgvModelos.Rows.Count = 0 And Me.dgvChasis.Rows.Count = 0 Then Exit Sub

         'If ClientesConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ClientesConError.ToString() & " Clientes que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
         '   Exit Sub
         'End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         If dgvDetalle.Rows.Count > 0 Then
            MessageBox.Show("Se importaron " & (Me.dgvDetalle.RowCount - ClientesConError).ToString() & " Clientes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         If dgvModelos.Rows.Count > 0 Then
            MessageBox.Show("Se importaron " & (Me.dgvModelos.RowCount - ModelsosConError).ToString() & " Modelos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         If dgvChasis.Rows.Count > 0 Then
            MessageBox.Show("Se importaron " & (Me.dgvChasis.RowCount - ChasisConError).ToString() & " Chasis EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         Me.prbImportando.Value = 0
         'Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      Me.txtRangoCeldas.Text = "An : Sn"

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0

      Me.tsbGrabar.Enabled = False
      Me.tsbImportar.Enabled = True

      Me.cboAccion.Text = "Altas"
      Me.cboEstado.Text = "Validos"

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.dgvModelos.DataSource Is Nothing Then
         DirectCast(Me.dgvModelos.DataSource, DataTable).Rows.Clear()
      End If

      'If Not Me._dt Is Nothing Then
      '   Me._dt.Rows.Clear()
      'End If

      Me.prbImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
         '.Columns.Add("LineaExcel", System.Type.GetType("System.Int64"))
         .Columns.Add("Accion", System.Type.GetType("System.String"))
         '.Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoClienteLetras", System.Type.GetType("System.String"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         .Columns.Add("Telefono", System.Type.GetType("System.String"))
         .Columns.Add("Celular", System.Type.GetType("System.String"))
         .Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         '.Columns.Add("PaginaWeb", GetType(String))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("NombreListaPrecios", System.Type.GetType("System.String"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("CUIT", System.Type.GetType("System.String"))
         .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("NroDocCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("FechaAlta", GetType(DateTime))
         .Columns.Add("NombreDeFantasia", System.Type.GetType("System.String"))
         .Columns.Add("Twitter", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Private Function CrearDTModelos() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
         '.Columns.Add("LineaExcel", System.Type.GetType("System.Int64"))
         .Columns.Add("Accion", System.Type.GetType("System.String"))
         '.Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("CodigoProductoModelo", System.Type.GetType("System.String"))
         .Columns.Add("NombreProductoModelo", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Private Function CrearDTChasis() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
         '.Columns.Add("LineaExcel", System.Type.GetType("System.Int64"))
         .Columns.Add("Accion", System.Type.GetType("System.String"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("NumeroChasis", System.Type.GetType("System.String"))
         .Columns.Add("NroDeMotor", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Sub AbrirExcel(ByVal ArchivoXLS As String)

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

      If chbImportarClientes.Checked Then
         Me.MostrarClientes()
      End If
      If ChbImportarModelos.Checked Then
         Me.MostrarModelos()
      End If
      If chbImportarChasis.Checked Then
         Me.MostrarChasis()
      End If
      If chbImportarChasisEnUso.Checked Then
         Me.MostrarChasisEnUso()
      End If

   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable
      Dim dtDatos1 As DataTable
      Dim dtDatos2 As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)
      dtDatos1 = DirectCast(Me.dgvModelos.DataSource, DataTable)
      dtDatos2 = DirectCast(Me.dgvChasis.DataSource, DataTable)

      If chbImportarClientes.Checked Then
         Dim reg As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes()
         reg.ImportarClientesBejerman(actual.Sucursal.Id, dtDatos, actual.Nombre, Me.prbImportando)
      End If

      If ChbImportarModelos.Checked Then
         Dim reg As Eniac.Reglas.ProductosModelos = New Eniac.Reglas.ProductosModelos()
         reg.ImportarModelosBejerman(actual.Sucursal.Id, dtDatos1, actual.Nombre, Me.prbImportando)
      End If

      If chbImportarChasis.Checked Then
         Dim reg As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
         reg.ImportarChasisBejerman(actual.Sucursal.Id, dtDatos2, actual.Nombre, Me.prbImportando, Me.IdFuncion)
      End If

   End Sub

   Private Sub MostrarClientes()
      Try

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim oLocalidad As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades
         Dim Codigo As Long = New Reglas.Clientes().GetCodigoMaximo("IdCliente") + 1

         Dim AnchoNombreCliente As Integer
         AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")
         Dim AnchoCorreoElectronico As Integer
         AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Clientes", "CorreoElectronico")

         tsbGrabar.Enabled = False

         ClientesConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim CLientesExternos As DataTable = New Reglas.Clientes().GetClientesExternos(Publicos.CalidadBaseExternaClientes)

         'Dim ds As DataSet = New DataSet()
         'Dim DA As New System.Data.OleDb.OleDbDataAdapter

         'Me.AbrirExcel(txtArchivoOrigen.Text)

         'DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         'DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String


         For Each dr In CLientesExternos.Rows

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaCodigoCliente).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
               'ElseIf Not IsNumeric(dr(ColumnaCodigoCliente).ToString()) Then
               '   Importar = False
               '   Mensaje = "Codigo de Cliente No es Numerico."
            Else
               drCl("CodigoClienteLetras") = dr(ColumnaCodigoCliente).ToString()
               Accion = IIf(oClientes.ExisteCodigoLetras(drCl("CodigoClienteLetras")), "M", "A")
               If Accion = "M" Then
                  '   drCl("CodigoCliente") = Codigo
                  '   Codigo += 1
                  'Else
                  Importar = False
                  Mensaje = "Cliente ya existe."
               End If

            End If

            drCl("NombreCliente") = dr(ColumnaNombreCliente).ToString.Trim.Replace("'", "´")
            drCl("Direccion") = dr(ColumnaDireccion).ToString.Trim.Replace("'", "´")

            Dim IdLocalidad As Integer = 0
            If Not Integer.TryParse(dr(ColumnaIdLocalidad).ToString(), IdLocalidad) Then
               Importar = False
               Mensaje = "Codigo de Localidad No es Numerico."
            Else
               drCl("IdLocalidad") = IdLocalidad
               If Not oLocalidad.Existe(drCl("IdLocalidad")) Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "No existe el Codigo de Localidad " & drCl("IdLocalidad").ToString()
               End If

            End If

            drCl("Telefono") = dr(ColumnaTelefono).ToString.Trim.Replace("'", "´")
            drCl("Celular") = dr(ColumnaCelular).ToString.Trim.Replace("'", "´")

            drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("/", " ")
            If dr(ColumnaCorreoElectronico).ToString.Trim.Length > AnchoCorreoElectronico Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Correo Electrónico es Mayor a " & AnchoCorreoElectronico.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("'", "´").Remove(AnchoCorreoElectronico)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del  Correo Electrónico es Mayor a " & AnchoCorreoElectronico.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("'", "´").Remove(AnchoCorreoElectronico)
                  End If
               End If
            End If

            drCl("NombreCategoria") = "General"
            Dim oCategorias As DataTable = New Reglas.Categorias().GetPorNombreExacto(drCl("NombreCategoria"))
            If oCategorias.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe la Categoria"
            End If

            drCl("NombreCategoriaFiscal") = "Consumidor Final"
            Dim catFisc As DataTable = New Reglas.CategoriasFiscales().GetPorNombreExacto(drCl("NombreCategoriaFiscal"))
            If catFisc.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Categoria Fiscal"
            End If

            drCl("NombreVendedor") = "Empresa"
            Dim oEmpleados As DataTable = New Reglas.Empleados().GetPorNombreExacto(drCl("NombreVendedor"))
            If oEmpleados.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe el Vendedor"
            End If

            drCl("NombreListaPrecios") = "Lista de Venta 1"
            Dim oListaPrecios As DataTable = New Reglas.ListasDePrecios().GetPorNombreExacto(drCl("NombreListaPrecios"))
            If oListaPrecios.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Lista de Precios"
            End If

            drCl("NombreZonaGeografica") = "General"
            Dim oZonaGeograf As DataTable = New Reglas.ZonasGeograficas().GetPorNombreExacto(drCl("NombreZonaGeografica"))
            If oZonaGeograf.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Zona Geografica"
            End If

            drCl("CUIT") = ""
            'If dr(ColumnaCUIT).ToString.Trim() <> "" Then
            '   If dr(ColumnaCUIT).ToString.Length = 11 Then
            '      If Not Publicos.EsCuitValido(dr(ColumnaCUIT).ToString.Trim()) Then
            '         Mensaje += "El número de CUIT es inválido."
            '         Importar = False
            '      Else
            '         drCl("CUIT") = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
            '      End If
            '   Else
            '      Mensaje += "El número de CUIT es inválido."
            '      Importar = False
            '   End If
            'End If

            'If Not String.IsNullOrEmpty(dr(ColumnaTipoDocCliente).ToString()) Then
            '   drCl("TipoDocCliente") = dr(ColumnaTipoDocCliente).ToString.Trim.Replace("'", "´")
            '   If String.IsNullOrEmpty(dr(ColumnaNroDocCliente).ToString()) Then
            '      Importar = False
            '      Mensaje = "Falta el Numero de Documento."
            '   End If
            'End If

            'If Not String.IsNullOrEmpty(dr(ColumnaNroDocCliente).ToString()) Then
            '   Dim lngNroDocumento As Long = 0
            '   If Not Integer.TryParse(dr(ColumnaNroDocCliente).ToString(), lngNroDocumento) Then
            '      Importar = False
            '      Mensaje = "Numero de Documento No es Numerico."
            '   Else
            '      drCl("NroDocCliente") = lngNroDocumento

            '      If String.IsNullOrEmpty(dr(ColumnaTipoDocCliente).ToString()) Then
            '         Importar = False
            '         Mensaje = "Falta el Tipo de Documento."
            '      End If
            '   End If
            ' End If

            drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´")

            If Not IsDBNull(dr(ColumnaFechaAlta)) AndAlso IsDate(dr(ColumnaFechaAlta)) Then
               drCl("FechaAlta") = Date.Parse(dr(ColumnaFechaAlta).ToString())
            Else
               drCl("FechaAlta") = Date.Today()
            End If

            drCl("NombreDeFantasia") = dr(ColumnaNombreDeFantasia).ToString

            drCl("Twitter") = ""

            drCl("Importa") = Importar

            If Not Importar Then
               ClientesConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "M"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dt.Rows.Add(drCl)
            End If

         Next

         '  ConexionExcel.Close()

         Me.dgvDetalle.DataSource = dt

         If dgvDetalle.Rows.Count = 0 Then
            ShowMessage("ATENCION: No hay Clientes para importar.")
            Me.tsbGrabar.Enabled = False
            Me.tsbImportar.Enabled = True
            Exit Sub
         Else
            ShowMessage("Se importarán " & dgvDetalle.Rows.Count.ToString() & " Clientes.")
            Me.tsbGrabar.Enabled = True
         End If

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
      End Try
   End Sub
   Private Sub MostrarModelos()
      Try

         Dim dt1 As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProductosModelos As Eniac.Reglas.ProductosModelos = New Eniac.Reglas.ProductosModelos
         Dim Codigo As Integer = New Reglas.ProductosModelos().GetCodigoMaximo() + 1

         'Dim AnchoNombreCliente As Integer
         'AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")
         'Dim AnchoCorreoElectronico As Integer
         'AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Clientes", "CorreoElectronico")

         tsbGrabar.Enabled = False

         ModelsosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt1 = Me.CrearDTModelos()

         Dim ModelosBejerman As DataTable = New Reglas.ProductosModelos().GetModelosBejerman(Publicos.CalidadBaseExternaClientes)

         'Dim ds As DataSet = New DataSet()
         'Dim DA As New System.Data.OleDb.OleDbDataAdapter

         'Me.AbrirExcel(txtArchivoOrigen.Text)

         'DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         'DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String


         For Each dr In ModelosBejerman.Rows

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt1.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaModeloCodigo).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
               'ElseIf Not IsNumeric(dr(ColumnaCodigoCliente).ToString()) Then
               '   Importar = False
               '   Mensaje = "Codigo de Cliente No es Numerico."
            Else
               drCl("CodigoProductoModelo") = dr(ColumnaModeloCodigo).ToString()
               Accion = IIf(oProductosModelos.ExisteCodigoModelo(drCl("CodigoProductoModelo")), "M", "A")
               If Accion = "M" Then
                  '   drCl("CodigoCliente") = Codigo
                  '   Codigo += 1
                  'Else
                  Importar = True
                  'Mensaje = "Modelo ya existe."
               End If

            End If

            drCl("NombreProductoModelo") = dr(ColumnaModeloDescripcion).ToString.Trim.Replace("'", "´").Replace("CHASIS", "")

            drCl("Importa") = Importar

            If Not Importar Then
               ClientesConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "M"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos") Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dt1.Rows.Add(drCl)
            End If

         Next

         '  ConexionExcel.Close()

         Me.dgvModelos.DataSource = dt1

         If dgvModelos.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay Modelos para importar.")
            Me.tsbGrabar.Enabled = False
            Me.tsbImportar.Enabled = True
            Exit Sub
         Else
            ShowMessage("Se importarán " & dgvModelos.Rows.Count.ToString() & " Modelos.")
            Me.tsbGrabar.Enabled = True
         End If

         Me.tssRegistrosModelos.Text = Me.dgvModelos.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ClientesConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistrosModelos.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub MostrarChasis()
      Try

         Dim dt1 As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos

         'Dim Codigo As Integer = New Reglas.ProductosModelos().GetCodigoMaximo() + 1

         'Dim AnchoNombreCliente As Integer
         'AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")
         'Dim AnchoCorreoElectronico As Integer
         'AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Clientes", "CorreoElectronico")

         tsbGrabar.Enabled = False

         ModelsosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt1 = Me.CrearDTChasis()

         Dim ChasisBejerman As DataTable = New Reglas.Productos().GetVistaProductosBejerman(Publicos.CalidadBaseExternaClientes, NroChasis:=String.Empty)

         'Dim ds As DataSet = New DataSet()
         'Dim DA As New System.Data.OleDb.OleDbDataAdapter

         'Me.AbrirExcel(txtArchivoOrigen.Text)

         'DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         'DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String


         For Each dr In ChasisBejerman.Rows

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt1.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaNumeroChasis).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
               'ElseIf Not IsNumeric(dr(ColumnaCodigoCliente).ToString()) Then
               '   Importar = False
               '   Mensaje = "Codigo de Cliente No es Numerico."
            Else
               Accion = IIf(oProductos.ExisteNumeroChasis(dr(ColumnaNumeroChasis).ToString().Trim()), "M", "A")
               If Accion = "M" Then
                  '   drCl("CodigoCliente") = Codigo
                  '   Codigo += 1
                  'Else
                  Importar = True

                  ' drCl("IdProducto") = oProductos.GetCodigoMaximo()
                  'Mensaje = "Modelo ya existe."
               End If

            End If

            drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Replace("CHASIS", "")

            drCl("NumeroChasis") = dr(ColumnaNumeroChasis).ToString().Trim()

            drCl("NroDeMotor") = dr(ColumnaNrodeMotor).ToString()

            drCl("Importa") = Importar

            If Not Importar Then
               ClientesConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "M"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos") Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dt1.Rows.Add(drCl)
            End If

         Next

         '  ConexionExcel.Close()

         Me.dgvChasis.DataSource = dt1

         If dgvChasis.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay Chasis para importar.")
            Me.tsbGrabar.Enabled = False
            Me.tsbImportar.Enabled = True
            Exit Sub
         Else
            ShowMessage("Se importarán " & dgvChasis.Rows.Count.ToString() & " Chasis.")
            Me.tsbGrabar.Enabled = True
         End If

         Me.tssRegistrosModelos.Text = Me.dgvModelos.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ClientesConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistrosModelos.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub MostrarChasisEnUso()
      Try

         Dim dt1 As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos

         'Dim Codigo As Integer = New Reglas.ProductosModelos().GetCodigoMaximo() + 1

         'Dim AnchoNombreCliente As Integer
         'AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")
         'Dim AnchoCorreoElectronico As Integer
         'AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Clientes", "CorreoElectronico")

         tsbGrabar.Enabled = False

         ModelsosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt1 = Me.CrearDTChasis()

         Dim ChasisEnUso As DataTable = New Reglas.Productos().GetAll()

         'Dim ds As DataSet = New DataSet()
         'Dim DA As New System.Data.OleDb.OleDbDataAdapter

         'Me.AbrirExcel(txtArchivoOrigen.Text)

         'DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         'DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String


         For Each dr In ChasisEnUso.Rows

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt1.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaNumeroChasis).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
               'ElseIf Not IsNumeric(dr(ColumnaCodigoCliente).ToString()) Then
               '   Importar = False
               '   Mensaje = "Codigo de Cliente No es Numerico."
            Else
               Accion = IIf(oProductos.ExisteNumeroChasis(dr(ColumnaNumeroChasis).ToString().Trim()), "M", "A")
               If Accion = "M" Then
                  '   drCl("CodigoCliente") = Codigo
                  '   Codigo += 1
                  'Else
                  Importar = True

                  ' drCl("IdProducto") = oProductos.GetCodigoMaximo()
                  'Mensaje = "Modelo ya existe."
               End If

            End If

            drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Replace("CHASIS", "")

            drCl("NumeroChasis") = dr(ColumnaNumeroChasis).ToString().Trim()

            drCl("NroDeMotor") = dr(ColumnaNrodeMotor).ToString()

            drCl("Importa") = Importar

            If Not Importar Then
               ClientesConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "M"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos") Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dt1.Rows.Add(drCl)
            End If

         Next

         '  ConexionExcel.Close()

         Me.dgvChasis.DataSource = dt1

         If dgvChasis.Rows.Count = 0 Then
            ShowMessage("ATENCION: NO hay Chasis para importar.")
            Me.tsbGrabar.Enabled = False
            Me.tsbImportar.Enabled = True
            Exit Sub
         Else
            ShowMessage("Se importarán " & dgvChasis.Rows.Count.ToString() & " Chasis.")
            Me.tsbGrabar.Enabled = True
         End If

         Me.tssRegistrosModelos.Text = Me.dgvModelos.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ClientesConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistrosModelos.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
#End Region

End Class