Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO

#End Region

Public Class ImportarClientesLIVEExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   'Private ColumnaTipoDocCliente As Integer = 0
   'Private ColumnaNroDocCliente As Integer = 1
   'Private ColumnaNombreCliente As Integer = 2
   'Private ColumnaDireccion As Integer = 3
   'Private ColumnaIdLocalidad As Integer = 4
   'Private ColumnaTelefono As Integer = 5
   'Private ColumnaCelular As Integer = 6
   'Private ColumnaCorreoElectronico As Integer = 7
   'Private ColumnaNombreCategoria As Integer = 8
   'Private ColumnaNombreCategoriaFiscal As Integer = 9
   'Private ColumnaNombreVendedor As Integer = 10
   'Private ColumnaNombreListaPrecios As Integer = 11
   'Private ColumnaNombreZonaGeografica As Integer = 12
   'Private ColumnaCUIT As Integer = 13
   'Private ColumnaObservacion As Integer = 14

   Private columnaCodigoCliente As Integer = 0
   Private ColumnaNombreCliente As Integer = 1

   Private ColumnaNombreCalle As Integer = 2
   Private ColumnaAlturaCalle As Integer = 3
   Private ColumnaDireccionAdicional As Integer = 4
   Private ColumnaIdLocalidad As Integer = 5

   Private ColumnaNombreCalle2 As Integer = 6
   Private ColumnaAlturaCalle2 As Integer = 7
   Private ColumnaDireccionAdicional2 As Integer = 8
   Private ColumnaIdLocalidad2 As Integer = 9

   Private ColumnaTelefono As Integer = 10
   Private ColumnaCelular As Integer = 11
   Private ColumnaCorreoElectronico As Integer = 12
   Private ColumnaNombreCategoria As Integer = 13
   Private ColumnaNombreCategoriaFiscal As Integer = 14
   Private ColumnaNombreVendedor As Integer = 15
   Private ColumnaNombreListaPrecios As Integer = 16
   Private ColumnaNombreZonaGeografica As Integer = 17
   Private ColumnaCUIT As Integer = 18

   Private ColumnaTipoDocCliente As Integer = 19
   Private ColumnaNroDocCliente As Integer = 20

   Private ColumnaObservacion As Integer = 21

   Private ColumnaCompFact As Integer = 22
   Private ColumnaEstado As Integer = 23
   Private ColumnaFormaPago As Integer = 24
   Private ColumnaTransportista As Integer = 25
   Private ColumnaAlta As Integer = 26
   Private ColumnaTipoCliente As Integer = 27

   Private ClientesConError As Integer
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
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If ClientesConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ClientesConError.ToString() & " Clientes que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.RowCount - ClientesConError).ToString() & " Clientes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0
         'Me.Close()

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

   Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

      If Not Me._estaCargando Then
         Me.tsbImportar.Enabled = (Me.cboEstado.Text <> "Invalidos")
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
         If RangoExcel = "" Or RangoExcel = "An : ABn" Then
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

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      Me.txtRangoCeldas.Text = "An : ABn"

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0


      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
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
         .Columns.Add("CodigoCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCalle", System.Type.GetType("System.String"))
         .Columns.Add("AlturaCalle", System.Type.GetType("System.Int32"))
         .Columns.Add("DireccionAdicional", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreCalle2", System.Type.GetType("System.String"))
         .Columns.Add("AlturaCalle2", System.Type.GetType("System.Int32"))
         .Columns.Add("DireccionAdicional2", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidad2", System.Type.GetType("System.Int32"))
         .Columns.Add("Telefono", System.Type.GetType("System.String"))
         .Columns.Add("Celular", System.Type.GetType("System.String"))
         .Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("NombreListaPrecios", System.Type.GetType("System.String"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("CUIT", System.Type.GetType("System.String"))
         .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("NroDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))
         'vml17/04/15

         .Columns.Add("CompFact", System.Type.GetType("System.String"))
         .Columns.Add("Estado", System.Type.GetType("System.String"))
         .Columns.Add("FormaPago", System.Type.GetType("System.String"))
         .Columns.Add("Transportista", System.Type.GetType("System.String"))
         .Columns.Add("Alta", System.Type.GetType("System.String"))
         .Columns.Add("TipoCliente", System.Type.GetType("System.String"))

         '.Columns.Add("IdCliente", System.Type.GetType("System.Int32"))
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


      Try

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim oLocalidad As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades

         'vml
         Dim oTransportistas As Eniac.Reglas.Transportistas = New Eniac.Reglas.Transportistas
         Dim oTiposComprobantes As Eniac.Reglas.TiposComprobantes = New Eniac.Reglas.TiposComprobantes
         Dim oEstadosClientes As Reglas.EstadosClientes = New Reglas.EstadosClientes
         Dim oEmpleados As Eniac.Reglas.Empleados = New Eniac.Reglas.Empleados
         Dim oFormasDePago As Eniac.Reglas.VentasFormasPago = New Eniac.Reglas.VentasFormasPago

         Dim oTiposClientes As Eniac.Reglas.TiposClientes = New Eniac.Reglas.TiposClientes()

         Dim AnchoNombreCliente As Integer
         AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")
         Dim AnchoCorreoElectronico As Integer
         AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Clientes", "CorreoElectronico")

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ClientesConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim ds As DataSet = New DataSet()
         Dim DA As New System.Data.OleDb.OleDbDataAdapter

         Me.AbrirExcel(txtArchivoOrigen.Text)

         DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String

         For Each dr In ds.Tables(0).Rows

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr(columnaCodigoCliente).ToString.Trim() = "" Or Not IsNumeric(dr(columnaCodigoCliente).ToString()) Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            ElseIf Not IsNumeric(dr(columnaCodigoCliente).ToString()) Then
               Importar = False
               Mensaje = "Codigo de Cliente No es Numerico."
            Else
               drCl("CodigoCliente") = Long.Parse(dr(columnaCodigoCliente).ToString())
               Accion = IIf(oClientes.ExisteCodigo(Long.Parse(drCl("CodigoCliente"))), "M", "A")
            End If

            'drCl("IdCliente") = Integer.Parse("0" & dr(columnaIdCliente).ToString.Trim.Replace("'", "´"))
            'Accion = IIf(oClientes.Existe(Long.Parse(drCl(Entidades.Cliente.Columnas.IdCliente.ToString()))), "M", "A")

            drCl("NombreCliente") = dr(ColumnaNombreCliente).ToString.Trim.Replace("'", "´")

            'drCl("Direccion") = dr(ColumnaDireccion).ToString.Trim.Replace("'", "´")

            drCl("NombreCalle") = dr(ColumnaNombreCalle).ToString.Trim.Replace("'", "´")
            drCl("AlturaCalle") = Integer.Parse("0" & dr(ColumnaAlturaCalle).ToString.Trim.Replace("'", "´"))
            drCl("DireccionAdicional") = dr(ColumnaDireccionAdicional).ToString.Trim.Replace("'", "´")

            drCl("NombreCalle2") = dr(ColumnaNombreCalle2).ToString.Trim.Replace("'", "´")
            drCl("AlturaCalle2") = Integer.Parse("0" & dr(ColumnaAlturaCalle2).ToString.Trim.Replace("'", "´"))
            drCl("DireccionAdicional2") = dr(ColumnaDireccionAdicional2).ToString.Trim.Replace("'", "´")

            If dr(ColumnaCompFact).ToString.Trim() = "" Or dr(ColumnaEstado).ToString.Trim() = "" _
               Or dr(ColumnaAlta).ToString.Trim() = "" Or dr(ColumnaTransportista).ToString.Trim() = "" _
               Or dr(ColumnaFormaPago).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            End If

            drCl("CompFact") = dr(ColumnaCompFact).ToString.Trim.Replace("'", "´")
            If oTiposComprobantes.GetPorCodigo(drCl("CompFact").ToString, Eniac.Entidades.TipoComprobante.Tipos.VENTAS.ToString(), String.Empty).Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el tipo de comprobante " & drCl("CompFact").ToString()
            End If

            drCl("Estado") = dr(ColumnaEstado).ToString.Trim.Replace("'", "´")

            If oEstadosClientes.GetXNombre(dr(ColumnaEstado).ToString.Trim.Replace("'", "´").ToString.ToUpper, Reglas.Base.AccionesSiNoExisteRegistro.Nulo) Is Nothing Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Estado del Cliente."
            End If

            drCl("FormaPago") = dr(ColumnaFormaPago).ToString.Trim.Replace("'", "´")
            If Integer.Parse("0" & drCl("FormaPago")) < 1 OrElse oFormasDePago.GetUna(drCl("FormaPago")).IdFormasPago = Nothing Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe la Forma de Pago."
            End If

            drCl("Transportista") = dr(ColumnaTransportista).ToString.Trim.Replace("'", "´")
            If oTransportistas.GetFiltradoPorNombre(drCl("Transportista")).Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Transportista."
            End If

            drCl("Alta") = dr(ColumnaAlta).ToString.Trim.Replace("'", "´")
            If oEmpleados.GetPorNombreExacto(drCl("Alta")).Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Empleado de ALTA. "
            End If

            drCl("IdLocalidad") = Integer.Parse("0" & dr(ColumnaIdLocalidad).ToString.Trim.Replace("'", "´"))
            If Not oLocalidad.Existe(drCl("IdLocalidad")) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Codigo de Localidad " & drCl("IdLocalidad").ToString()
            End If

            drCl("IdLocalidad2") = Integer.Parse("0" & dr(ColumnaIdLocalidad2).ToString.Trim.Replace("'", "´"))
            If Not oLocalidad.Existe(drCl("IdLocalidad2")) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Codigo de Localidad " & drCl("IdLocalidad2").ToString()
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


            drCl("NombreCategoria") = dr(ColumnaNombreCategoria).ToString.Trim.Replace("'", "´")
            Dim oCategorias As DataTable = New Eniac.Reglas.Categorias().GetPorNombreExacto(drCl("NombreCategoria"))
            If oCategorias.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe la Categoria"
            End If

            drCl("NombreCategoriaFiscal") = dr(ColumnaNombreCategoriaFiscal).ToString.Trim.Replace("'", "´")
            Dim catFisc As DataTable = New Eniac.Reglas.CategoriasFiscales().GetPorNombreExacto(drCl("NombreCategoriaFiscal"))
            If catFisc.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Categoria Fiscal"
            End If

            drCl("NombreVendedor") = dr(ColumnaNombreVendedor).ToString.Trim.Replace("'", "´")
            Dim dtEmpleados As DataTable = New Eniac.Reglas.Empleados().GetPorNombreExacto(drCl("NombreVendedor"))
            If dtEmpleados.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe el Vendedor"
            End If

            drCl("NombreListaPrecios") = dr(ColumnaNombreListaPrecios).ToString.Trim.Replace("'", "´")
            Dim oListaPrecios As DataTable = New Eniac.Reglas.ListasDePrecios().GetPorNombreExacto(drCl("NombreListaPrecios"))
            If oListaPrecios.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Lista de Precios"
            End If

            drCl("NombreZonaGeografica") = dr(ColumnaNombreZonaGeografica).ToString.Trim.Replace("'", "´")
            Dim oZonaGeograf As DataTable = New Eniac.Reglas.ZonasGeograficas().GetPorNombreExacto(drCl("NombreZonaGeografica"))
            If oZonaGeograf.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Zona Geografica"
            End If

            Dim cuit As String = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
            drCl("CUIT") = cuit
            If Not String.IsNullOrWhiteSpace(cuit) Then
               If cuit.Length > 13 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El cuit tiene más de 13 caracteres"
               ElseIf Not Publicos.EsCuitValido(cuit) Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El cuit es inválido"
               End If
            End If

            If Not String.IsNullOrEmpty(dr(ColumnaTipoDocCliente).ToString()) And Not String.IsNullOrEmpty(dr(ColumnaNroDocCliente).ToString()) Then
               drCl("TipoDocCliente") = dr(ColumnaTipoDocCliente).ToString.Trim.Replace("'", "´")
               drCl("NroDocCliente") = Long.Parse(dr(ColumnaNroDocCliente).ToString.Trim.Replace("'", "´"))
            End If

            drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´")

            drCl("TipoCliente") = dr(ColumnaTipoCliente).ToString.Trim.Replace("'", "´")
            If oTiposClientes.GetUnoXNombre(drCl("TipoCliente")).IdTipoCliente = Nothing Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Tipos de Cliente."
            End If

            drCl("Importa") = Importar

            If Not Importar Then
               ClientesConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "X"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And _
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
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

      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      Dim reg As Reglas.Clientes = New Reglas.Clientes()

      reg.ImportarClientesLIVE(actual.Sucursal.Id, dtDatos, actual.Nombre, Me.prbImportando)

   End Sub

#End Region

End Class