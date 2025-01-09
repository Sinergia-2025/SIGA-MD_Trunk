#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ImportarProveedoresExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private RangoExcel As String
   Private ColumnaCodigoProveedor As Integer = 0
   Private ColumnaNombreProveedor As Integer = 1
   Private ColumnaDireccion As Integer = 2
   Private ColumnaLocalidad As Integer = 3
   Private ColumnaNombreCategoriaFiscal As Integer = 4
   Private ColumnaNombreCategoria As Integer = 5
   Private ColumnaRubroCompras As Integer = 6
   Private ColumnaCuentaCaja As Integer = 7
   Private ColumnaCuentaBanco As Integer = 8
   Private ColumnaCUIT As Integer = 9
   Private ColumnaTipoDocProveedor As Integer = 10
   Private ColumnaNroDocProveedor As Integer = 11
   Private ColumnaIngBrutos As Integer = 12
   Private ColumnaTelefono As Integer = 13
   Private ColumnaCorreoElectronico As Integer = 14
   Private ColumnaObservacion As Integer = 15
   Private ProveedoresConError As Integer
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

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

   Private Sub ImportarProveedoresExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         If ProveedoresConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ProveedoresConError.ToString() & " Proveedores que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.RowCount - ProveedoresConError).ToString() & " Proveedores EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0

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

      Dim ArchivoStream As IO.Stream = Nothing
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

      Me.txtRangoCeldas.Text = "An : Pn"

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0


      If TypeOf (Me.dgvDetalle.DataSource) Is DataTable Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Clear()
      End If

      Me.prbImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
         .Columns.Add("Accion", System.Type.GetType("System.String"))
         .Columns.Add("CodigoProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreProveedor", System.Type.GetType("System.String"))
         .Columns.Add("Direccion", System.Type.GetType("System.String"))
         .Columns.Add("IdLocalidadProveedor", System.Type.GetType("System.Int32"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("NombreCuentaCaja", System.Type.GetType("System.String"))
         .Columns.Add("NombreCuentaBanco", GetType(String))
         .Columns.Add("CUIT", System.Type.GetType("System.String"))
         .Columns.Add("TipoDocProveedor", System.Type.GetType("System.String"))
         .Columns.Add("NroDocProveedor", System.Type.GetType("System.Int64"))
         .Columns.Add("IngresosBrutos", System.Type.GetType("System.String"))
         .Columns.Add("Telefono", System.Type.GetType("System.String"))
         .Columns.Add("CorreoElectronico", System.Type.GetType("System.String"))
         .Columns.Add("Observacion", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))

         .Columns.Add("CuentaBanco_Entidad", GetType(Object))
      End With

      Return dtTemp

   End Function

   Function AbrirExcel(archivoXLS As String) As System.Data.OleDb.OleDbConnection

      Dim m_sConn1 As String

      If archivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & archivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & archivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If

      Dim conexionExcel As System.Data.OleDb.OleDbConnection
      conexionExcel = New System.Data.OleDb.OleDbConnection(m_sConn1)
      conexionExcel.Open()
      Return conexionExcel

   End Function

   Private Sub Mostrar()

      Try

         If TypeOf (dgvDetalle.DataSource) Is DataTable Then
            DirectCast(dgvDetalle.DataSource, DataTable).Clear()
            Application.DoEvents()
         End If

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProveedores As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores
         Dim oLocalidad As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades

         Dim AnchoNombreProveedor As Integer
         AnchoNombreProveedor = oPublicos.GetAnchoCampo("Proveedores", "NombreProveedor")
         Dim AnchoCorreoElectronico As Integer
         AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Proveedores", "CorreoElectronico")

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ProveedoresConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim ds As DataSet = New DataSet()
         Dim DA As New System.Data.OleDb.OleDbDataAdapter


         Dim ConexionExcel As System.Data.OleDb.OleDbConnection = Me.AbrirExcel(txtArchivoOrigen.Text)

         Try
            DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, ConexionExcel)
            DA.Fill(ds)
         Finally
            ConexionExcel.Close()
         End Try

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String

         Dim cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

         prbImportando.Value = 0
         prbImportando.Maximum = ds.Tables(0).Rows.Count
         prbImportando.Step = 1

         For Each dr In ds.Tables(0).Rows

            prbImportando.PerformStep()

            Accion = "A"

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaCodigoProveedor).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            Else
               drCl("CodigoProveedor") = Long.Parse(dr(ColumnaCodigoProveedor).ToString())
               Accion = If(oProveedores.ExisteProveedorPorCodigoNombre(Long.Parse(drCl("CodigoProveedor").ToString()), ""), "M", "A")
            End If

            drCl("NombreProveedor") = dr(ColumnaNombreProveedor).ToString.Trim.Replace("'", "´")
            drCl("Direccion") = dr(ColumnaDireccion).ToString.Trim.Replace("'", "´")

            drCl("IdLocalidadProveedor") = Integer.Parse("0" & dr(ColumnaLocalidad).ToString.Trim.Replace("'", "´"))

            If Not oLocalidad.Existe(Integer.Parse(drCl("IdLocalidadProveedor").ToString())) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "No existe el Codigo de Localidad " & drCl("IdLocalidadProveedor").ToString()
            End If

            drCl("NombreCategoriaFiscal") = dr(ColumnaNombreCategoriaFiscal).ToString.Trim.Replace("'", "´")
            Dim catFisc As DataTable = New Reglas.CategoriasFiscales().GetPorNombreExacto(drCl("NombreCategoriaFiscal").ToString())
            If catFisc.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe La Categoria Fiscal"
            End If

            drCl("NombreCategoria") = dr(ColumnaNombreCategoria).ToString.Trim.Replace("'", "´")
            Dim oCategorias As DataTable = New Reglas.CategoriasProveedores().GetPorNombreExacto(drCl("NombreCategoria").ToString())
            If oCategorias.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe la Categoria"
            End If

            drCl("NombreRubro") = dr(ColumnaRubroCompras).ToString.Trim.Replace("'", "´")
            Dim oRubrosCompras As DataTable = New Reglas.RubrosCompras().GetPorNombreExacto(drCl("NombreRubro").ToString())
            If oRubrosCompras.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe el Rubro de Compras"
            End If

            drCl("NombreCuentaCaja") = dr(ColumnaCuentaCaja).ToString.Trim.Replace("'", "´")
            Dim oCuentasCajas As DataTable = New Reglas.CuentasDeCajas().GetPorNombreExacto(drCl("NombreCuentaCaja").ToString())
            If oCuentasCajas.Rows.Count = 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe la Cuenta la Caja"
            End If

            drCl("NombreCuentaBanco") = dr(ColumnaCuentaBanco).ToString.Trim.Replace("'", "´")
            Dim oCuentasBancos As Entidades.CuentaBanco = cache.BuscaCuentaBanco(drCl("NombreCuentaBanco").ToString())
            If oCuentasBancos Is Nothing Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "NO Existe la Cuenta la Banco"
            Else
               drCl("CuentaBanco_Entidad") = oCuentasBancos
            End If

            drCl("CUIT") = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
            If dr(ColumnaCUIT).ToString.Trim() <> "" Then
               If dr(ColumnaCUIT).ToString.Length = 11 Then
                  If Not Publicos.EsCuitValido(dr(ColumnaCUIT).ToString.Trim()) Then
                     Mensaje += "El número de CUIT " & dr(ColumnaCUIT).ToString() & " es inválido."
                     Importar = False
                  Else
                     drCl("CUIT") = dr(ColumnaCUIT).ToString.Trim.Replace("'", "´")
                  End If
               Else
                  Mensaje += "El número de CUIT " & dr(ColumnaCUIT).ToString() & " es inválido."
                  Importar = False
               End If
            End If

            If Not String.IsNullOrEmpty(dr(ColumnaTipoDocProveedor).ToString()) And Not String.IsNullOrEmpty(dr(ColumnaNroDocProveedor).ToString()) Then
               drCl("TipoDocProveedor") = dr(ColumnaTipoDocProveedor).ToString.Trim.Replace("'", "´")
               drCl("NroDocProveedor") = Long.Parse(dr(ColumnaNroDocProveedor).ToString.Trim.Replace("'", "´"))
            End If

            drCl("IngresosBrutos") = dr(ColumnaIngBrutos).ToString.Trim.Replace("'", "´")

            drCl("Telefono") = dr(ColumnaTelefono).ToString.Trim.Replace("'", "´")

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

            drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´")

            drCl("Importa") = Importar

            If Not Importar Then
               ProveedoresConError += 1
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

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ProveedoresConError = 0
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
         prbImportando.Value = 0
      End Try

   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      Dim reg As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()

      reg.ImportarProveedores(actual.Sucursal.Id, dtDatos, actual.Nombre, Me.prbImportando)

   End Sub

#End Region

End Class