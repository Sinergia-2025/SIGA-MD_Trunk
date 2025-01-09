Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO

#End Region

Public Class ImportarArchivosExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
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
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         If ClientesConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ClientesConError.ToString() & " Clientes que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.ugDetalle.Rows.Count - ClientesConError).ToString() & " Clientes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

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
      DialogoAbrirArchivo.Filter = "Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*|Libro de Excel 97-2003 (*.xls)|*.xls"
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
         If RangoExcel = "" Or RangoExcel = "An : Pn" Then
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

      Me.txtRangoCeldas.Text = "A1 : AMn"

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0


      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
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
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidad", System.Type.GetType("System.Int32"))
         .Columns.Add("Localidad", System.Type.GetType("System.String"))
         .Columns.Add("Provincia", System.Type.GetType("System.String"))
         .Columns.Add("Telefono", System.Type.GetType("System.String"))
         .Columns.Add("Celular", System.Type.GetType("System.String"))
         .Columns.Add("TelefonoLaboral", System.Type.GetType("System.String"))
         .Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         .Columns.Add("CUIT", System.Type.GetType("System.String"))
         .Columns.Add("TipoDocCliente", System.Type.GetType("System.String"))
         .Columns.Add("NroDocCliente", System.Type.GetType("System.Int64"))

         .Columns.Add("Fecha_Corte", System.Type.GetType("System.DateTime"))
         .Columns.Add("tipo_cobro", System.Type.GetType("System.String"))
         .Columns.Add("convenio", System.Type.GetType("System.String"))
         .Columns.Add("linea", System.Type.GetType("System.String"))
         .Columns.Add("nro_prestamo", System.Type.GetType("System.Int64"))
         .Columns.Add("fecha_emision", System.Type.GetType("System.DateTime"))
         .Columns.Add("cantidad_cuotas", System.Type.GetType("System.Int32"))
         .Columns.Add("cuotas_pagas", System.Type.GetType("System.Int32"))
         .Columns.Add("cuotas_adeudadas", System.Type.GetType("System.Int32"))
         .Columns.Add("capital_total", System.Type.GetType("System.Decimal"))
         .Columns.Add("deuda_exigible", System.Type.GetType("System.Decimal"))
         .Columns.Add("fecha_ult_cobranza", System.Type.GetType("System.DateTime"))
         .Columns.Add("dias_mora", System.Type.GetType("System.Int32"))
         .Columns.Add("deuda_exigible_con_quita", System.Type.GetType("System.Decimal"))
         .Columns.Add("empresa", System.Type.GetType("System.String"))
         .Columns.Add("vendedor", System.Type.GetType("System.String"))
         .Columns.Add("monto_cuota", System.Type.GetType("System.Decimal"))
         .Columns.Add("Activo", System.Type.GetType("System.Boolean"))
         .Columns.Add("observacion", System.Type.GetType("System.String"))
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

      Try

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
         Dim oClientesDeudas As Eniac.Reglas.ClientesDeudas = New Eniac.Reglas.ClientesDeudas
         Dim oLocalidad As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades

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
         Dim Cliente As Entidades.Cliente

         Me.tssRegistros.Text = "Leyendo archivo excel...."
         System.Windows.Forms.Application.DoEvents()

         Dim i As Integer = 0

         prbImportando.Maximum = ds.Tables(0).Rows.Count
         prbImportando.Minimum = 0
         prbImportando.Value = 0

         For Each dr In ds.Tables(0).Rows

            i += 1
            prbImportando.Value = i

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr("nro_doc").ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            ElseIf Not IsNumeric(dr("nro_doc").ToString.Trim()) Then
               Importar = False
               Mensaje = "Codigo de Cliente No es Numerico."
            Else
               drCl("CodigoCliente") = Long.Parse(dr("nro_doc").ToString.Trim())
               Cliente = New Reglas.Clientes().GetUnoPorCodigo(Long.Parse(dr("nro_doc").ToString.Trim()))
               'controlar si existe cliente
               If Cliente IsNot Nothing Then
                  Accion = IIf(oClientesDeudas.ExisteCodigo(Cliente.IdCliente, Integer.Parse(dr("nro_prestamo").ToString())), "M", "A")
               Else
                  Accion = "A"
               End If

            End If

            drCl("NombreCliente") = dr("nombre_apellido").ToString.Trim.Replace("'", "´")
            drCl("Direccion") = dr("domicilio").ToString.Trim.Replace("'", "´")

            Dim IdLocalidad As Integer = 0

            If Not Integer.TryParse(dr("cod_postal").ToString(), IdLocalidad) Then
               drCl("IdLocalidad") = 2000
            Else
               drCl("IdLocalidad") = IdLocalidad
               If Not oLocalidad.Existe(drCl("IdLocalidad")) Then
                  drCl("IdLocalidad") = 2000

               End If

            End If

            ' drCl("observacion") = dr("cod_postal").ToString() & "-" & dr("localidad").ToString.Trim.Replace("'", "´") & "-" & dr("provincia").ToString.Trim.Replace("'", "´")

            drCl("localidad") = dr("localidad").ToString.Trim.Replace("'", "´")
            drCl("provincia") = dr("provincia").ToString.Trim.Replace("'", "´")
            drCl("Telefono") = dr("tel_principal").ToString.Trim.Replace("'", "´")
            drCl("Celular") = dr("tel_celular").ToString.Trim.Replace("'", "´")
            drCl("TelefonoLaboral") = dr("tel_laboral").ToString.Trim.Replace("'", "´")
            drCl("CorreoElectronico") = dr("correo_electronico").ToString.Trim.Replace("/", " ")
            drCl("CUIT") = dr("cuit_cuil").ToString.Trim.Replace("'", "´")

            drCl("Fecha_Corte") = DateTime.Now

            drCl("tipo_cobro") = dr("tipo_cobro").ToString()
            drCl("convenio") = dr("convenio").ToString.Trim.Replace("'", "´")
            drCl("linea") = dr("linea").ToString.Trim.Replace("'", "´")
            drCl("nro_prestamo") = Integer.Parse(dr("nro_prestamo").ToString.Trim.Replace("'", "´"))

            If Not String.IsNullOrEmpty(dr("fecha_emision").ToString()) Then
               drCl("fecha_emision") = Date.Parse(dr("fecha_emision").ToString.Trim.Replace("'", "´"))
            End If

            If Not String.IsNullOrEmpty(dr("cantidad_cuotas").ToString) Then
               drCl("cantidad_cuotas") = Integer.Parse(dr("cantidad_cuotas").ToString.Trim.Replace("'", "´"))
            Else
               drCl("cantidad_cuotas") = 0
            End If


            If Not String.IsNullOrEmpty(dr("cuotas_pagas").ToString) Then
               drCl("cuotas_pagas") = Integer.Parse(dr("cuotas_pagas").ToString.Trim.Replace("'", "´"))
            Else
               drCl("cuotas_pagas") = 0
            End If


            If Not String.IsNullOrEmpty(dr("cuotas_adeudadas").ToString) Then
               drCl("cuotas_adeudadas") = Integer.Parse(dr("cuotas_adeudadas").ToString.Trim.Replace("'", "´"))
            Else
               drCl("cuotas_adeudadas") = 0
            End If

            If Not String.IsNullOrEmpty(dr("capital_total").ToString) Then
               drCl("capital_total") = Decimal.Parse(dr("capital_total").ToString.Trim.Replace("'", "´"))
            Else
               drCl("capital_total") = 0
            End If

            drCl("deuda_exigible") = Decimal.Parse(dr("deuda_exigible").ToString.Trim.Replace("'", "´"))

            If Not String.IsNullOrEmpty(dr("fecha_ult_cobranza").ToString()) Then
               drCl("fecha_ult_cobranza") = Date.Parse(dr("fecha_ult_cobranza").ToString.Trim.Replace("'", "´"))
            End If

            If Not String.IsNullOrEmpty(dr("dias_mora").ToString()) Then
               drCl("dias_mora") = Integer.Parse(dr("dias_mora").ToString.Trim.Replace("'", "´"))
            Else
               drCl("dias_mora") = 0
            End If

            drCl("deuda_exigible_con_quita") = Decimal.Parse(dr("deuda_exigible_con_quita").ToString.Trim.Replace("'", "´"))

            drCl("empresa") = dr("empresa").ToString.Trim.Replace("'", "´")
            drCl("vendedor") = dr("vendedor").ToString.Trim.Replace("'", "´")


            If Not String.IsNullOrEmpty(dr("monto_cuota").ToString) Then
               drCl("monto_cuota") = Decimal.Parse(dr("monto_cuota").ToString.Trim.Replace("'", "´"))
            Else
               drCl("monto_cuota") = 0
            End If

            drCl("Activo") = True

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

         Me.ugDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ClientesConError = 0
         End If


      Catch ex As Exception
         prbImportando.Value = 0
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

      dtDatos = DirectCast(Me.ugDetalle.DataSource, DataTable)

      Dim reg As Eniac.Reglas.ClientesDeudas = New Eniac.Reglas.ClientesDeudas()

      reg.ImportarClientesDeudas(actual.Sucursal.Id, dtDatos, actual.Nombre, Me.prbImportando)

   End Sub

#End Region

End Class