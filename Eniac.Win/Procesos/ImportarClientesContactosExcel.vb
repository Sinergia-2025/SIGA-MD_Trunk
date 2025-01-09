#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinDataSource
Imports System.Data
Imports System.IO
Imports System.Globalization

#End Region
Public Class ImportarClientesContactosExcel

#Region "Campos"

   Private _publicos As Reglas.Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   Private RangoInicial As String = "An : Jn"
   Private ColumnaCodigoCliente As Integer = 0
   Private ColumnaNombreCliente As Integer = 1
   Private ColumnaNombreContacto As Integer = 2
   Private ColumnaTipoContacto As Integer = 3
   Private ColumnaDireccion As Integer = 4
   Private ColumnaIdLocalidad As Integer = 5
   Private ColumnaTelefono As Integer = 6
   Private ColumnaCelular As Integer = 7
   Private ColumnaCorreoElectronico As Integer = 8
   Private ColumnaObservacion As Integer = 9
   Private ContactosConError As Integer
   Private AccionA As Integer = 0
   Private AccionM As Integer = 0
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Reglas.Publicos()

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

#Region "Métodos"

   Public Function RemoveDiacritics(stIn As String) As String

      Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
      Dim sb As New StringBuilder()

      For ich As Integer = 0 To stFormD.Length - 1
         Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
         If uc <> UnicodeCategory.NonSpacingMark Then
            sb.Append(stFormD(ich))
         End If
      Next

      Return (sb.ToString().Normalize(NormalizationForm.FormC))

   End Function

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         .Columns.Add("Accion", GetType(String))
         .Columns.Add("IdCliente", GetType(Int64))
         .Columns.Add("CodigoCliente", GetType(Int64))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("IdContacto", GetType(Integer))
         .Columns.Add("NombreContacto", GetType(String))
         .Columns.Add("IdTipoContacto", GetType(Integer))
         .Columns.Add("NombreTipoContacto", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("IdLocalidad", GetType(Integer))
         .Columns.Add("NombreLocalidad", GetType(String))
         .Columns.Add("Telefono", GetType(String))
         .Columns.Add("Celular", GetType(String))
         .Columns.Add("CorreoElectronico", GetType(String))
         .Columns.Add("Observacion", GetType(String))
         .Columns.Add("Mensaje", GetType(String))
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

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      Me.txtRangoCeldas.Text = RangoInicial

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
      Me.tsbImportar.Enabled = False
   End Sub

   Private Sub Mostrar()

      Try

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim _cache As Reglas.BusquedasCacheadas = New Reglas.BusquedasCacheadas()

         Dim idCliente As Long = 0
         Dim codigoCliente As Long = 0
         Dim nombreCliente As String = String.Empty
         Dim drCliente As DataRow = Nothing

         Dim NombreContacto As String = String.Empty
         Dim IdTipoContacto As Integer = 0
         Dim TipoContacto As String = String.Empty
         Dim drContacto As DataRow = Nothing

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim oTiposContactos As Reglas.TiposContactos = New Reglas.TiposContactos
         Dim oContactos As Reglas.ClientesContactos = New Reglas.ClientesContactos

         Dim oLocalidad As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades

         Dim AnchoNombreCliente As Integer
         AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")
         Dim AnchoCorreoElectronico As Integer
         AnchoCorreoElectronico = oPublicos.GetAnchoCampo("Clientes", "CorreoElectronico")

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ContactosConError = 0
         AccionA = 0
         AccionM = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim ds As DataSet = New DataSet()
         Dim DA As New System.Data.OleDb.OleDbDataAdapter

         Me.AbrirExcel(txtArchivoOrigen.Text)

         DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Accion As String

         For Each dr In ds.Tables(0).Rows

            Dim Mensaje As StringBuilder = New StringBuilder

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True

            '# Código del Cliente
            codigoCliente = Ayudante.ImportarExcel.GetValorLong(dr, ColumnaCodigoCliente)
            nombreCliente = Me.RemoveDiacritics(Ayudante.ImportarExcel.GetValorString(dr, ColumnaNombreCliente))

            If codigoCliente = 0 And String.IsNullOrWhiteSpace(nombreCliente) Then
               Importar = False
               Mensaje.AppendFormat("Cliente inválido - ")
            Else
               drCliente = _cache.BuscaClientePorCodigo(codigoCliente)
               If drCliente Is Nothing Then
                  drCliente = _cache.BuscaCliente(nombreCliente)
               End If
               If drCliente Is Nothing Then
                  drCliente = _cache.BuscaClientePorFantasia(nombreCliente)
               End If
               If drCliente Is Nothing Then
                  Importar = False
                  Mensaje.AppendFormat("Cliente no existe - ")
               Else

                  idCliente = drCliente.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString())
                  drCl(Entidades.Cliente.Columnas.IdCliente.ToString()) = idCliente
                  drCl(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = codigoCliente
                  drCl(Entidades.Cliente.Columnas.NombreCliente.ToString()) = nombreCliente

               End If
            End If


               '# Datos del Contacto

               ' Nombre
               NombreContacto = Ayudante.ImportarExcel.GetValorString(dr, ColumnaNombreContacto)
            If String.IsNullOrEmpty(NombreContacto) Then
               Importar = False
               Mensaje.AppendFormat("Nombre de Contacto vacio - ")
            Else
               ' set nombre del Contacto
               drCl(Entidades.ClienteContacto.Columnas.NombreContacto.ToString()) = NombreContacto

               ' # Si existe cambio la bandera para que se actualice
               Accion = If(oContactos.Existe(NombreContacto, idCliente), "M", "A")
            End If

            ' Tipo
            TipoContacto = Ayudante.ImportarExcel.GetValorString(dr, ColumnaTipoContacto)
            If String.IsNullOrEmpty(TipoContacto) Then
               Importar = False
               Mensaje.AppendFormat("Tipo de Contacto vacio - ")
            Else
               ' Verifico que el tipo de contacto ingresado este registrado en el sistema
               Dim temp As DataTable = oTiposContactos.GetPorNombre(TipoContacto)
               If temp.Rows.Count = 0 Then
                  Importar = False
                  Mensaje.AppendFormat("Tipo de Contacto no existe - ")
               Else
                  ' set tipo de contacto
                  Dim drtemp As DataRow = temp.Rows(0)
                  drCl(Entidades.TipoContacto.Columnas.IdTipoContacto.ToString()) = Integer.Parse(drtemp("IdTipoContacto").ToString())
                  drCl(Entidades.TipoContacto.Columnas.NombreTipoContacto.ToString()) = TipoContacto
               End If
            End If

            ' Dirección
            Dim DireccionContacto As String = Ayudante.ImportarExcel.GetValorString(dr, ColumnaDireccion)
            If String.IsNullOrEmpty(DireccionContacto) Then
               Importar = False
               Mensaje.AppendFormat("Dirección de Contacto vacia - ")
            Else
               ' set dirección
               drCl(Entidades.ClienteContacto.Columnas.Direccion.ToString()) = DireccionContacto
            End If

            ' Localidad
            Dim IdLocalidad As Integer = Ayudante.ImportarExcel.GetValorInteger(dr, ColumnaIdLocalidad)
            If IdLocalidad = 0 Then
               Importar = False
               Mensaje.AppendFormat("CP vacio - ")
            ElseIf Not IsNumeric(IdLocalidad) Then
               ' verifico que se hayan ingresado valores numéricos
               Importar = False
               Mensaje.AppendFormat("CP inválido - ")
            Else
               ' verifico que la localidad esté registrada en el sistema
               If Not oLocalidad.Existe(IdLocalidad) Then
                  Importar = False
                  Mensaje.AppendFormat("CP no existe - ")
               Else
                  ' set localidad
                  Dim temp As DataTable = oLocalidad.GetPorCodigo(IdLocalidad)
                  Dim drtemp As DataRow = temp.Rows(0)
                  drCl(Entidades.ClienteContacto.Columnas.IdLocalidad.ToString()) = IdLocalidad
                  drCl(Entidades.Localidad.Columnas.NombreLocalidad.ToString()) = drtemp.Field(Of String)(Entidades.Localidad.Columnas.NombreLocalidad.ToString())
               End If
            End If

            ' Teléfono
            drCl(Entidades.ClienteContacto.Columnas.Telefono.ToString()) = Ayudante.ImportarExcel.GetValorString(dr, ColumnaTelefono) 'dr.Field(Of String)(ColumnaTelefono).ToString()

            ' Celular
            drCl(Entidades.ClienteContacto.Columnas.Celular.ToString()) = Ayudante.ImportarExcel.GetValorString(dr, ColumnaCelular) 'dr.Field(Of String)(ColumnaCelular).ToString()

            ' Correo electrónico
            drCl(Entidades.ClienteContacto.Columnas.CorreoElectronico.ToString()) = Ayudante.ImportarExcel.GetValorString(dr, ColumnaCorreoElectronico) 'dr.Field(Of String)(ColumnaCorreoElectronico).ToString()

            ' Observacion
            drCl(Entidades.ClienteContacto.Columnas.Observacion.ToString()) = Ayudante.ImportarExcel.GetValorString(dr, ColumnaObservacion) ' dr.Field(Of String)(ColumnaObservacion).ToString()

            'If Not Integer.TryParse(dr(ColumnaIdLocalidad).ToString(), IdLocalidad) Then
            '   Importar = False
            '   Mensaje = "Codigo de Localidad No es Numerico."
            'Else
            '   drCl("IdLocalidad") = IdLocalidad
            '   If Not oLocalidad.Existe(drCl("IdLocalidad")) Then
            '      Importar = False
            '      If Mensaje.Length > 0 Then Mensaje += " - "
            '      Mensaje += "No existe el Codigo de Localidad " & drCl("IdLocalidad").ToString()
            '   End If

            'End If

            'drCl("Telefono") = dr(ColumnaTelefono).ToString.Trim.Replace("'", "´")
            'drCl("Celular") = dr(ColumnaCelular).ToString.Trim.Replace("'", "´")

            'drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("/", " ")
            'If dr(ColumnaCorreoElectronico).ToString.Trim.Length > AnchoCorreoElectronico Then
            '   If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
            '      Importar = False
            '      If Mensaje.Length > 0 Then Mensaje += " - "
            '      Mensaje += "Digitos del Correo Electrónico es Mayor a " & AnchoCorreoElectronico.ToString()
            '   Else
            '      If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
            '         drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("'", "´").Remove(AnchoCorreoElectronico)
            '         If Mensaje.Length > 0 Then Mensaje += " - "
            '         Mensaje += "Digitos del  Correo Electrónico es Mayor a " & AnchoCorreoElectronico.ToString()
            '      End If
            '      If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
            '         drCl("CorreoElectronico") = dr(ColumnaCorreoElectronico).ToString.Trim.Replace("'", "´").Remove(AnchoCorreoElectronico)
            '      End If
            '   End If
            'End If

            'drCl("Observacion") = dr(ColumnaObservacion).ToString.Trim.Replace("'", "´")

            drCl("Importa") = Importar

            If Not Importar Then
               ContactosConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "X"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            ' # Contador de los registros a Actualizar o dar de Alta
            If Accion = "A" Then
               AccionA = AccionA + 1
            Else
               AccionM = AccionM + 1
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
            ContactosConError = 0
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

   Private Sub FormatearGrilla()
      For Each dr As UltraGridRow In Me.ugDetalle.Rows
         If dr.Cells("Accion").Value.Equals("X") Then
            dr.Cells("Importa").Appearance.BackColor = Color.Yellow
            dr.Cells("Importa").ActiveAppearance.BackColor = Color.Yellow
         ElseIf dr.Cells("Accion").Value.Equals("E") Then
            dr.Cells("Importa").Appearance.BackColor = Color.LightCoral
            dr.Cells("Importa").ActiveAppearance.BackColor = Color.LightCoral
         Else
            dr.Cells("Importa").Appearance.BackColor = Color.LimeGreen
            dr.Cells("Importa").ActiveAppearance.BackColor = Color.LimeGreen
         End If
      Next
   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable
      Dim regla As Reglas.ClientesContactos = New Reglas.ClientesContactos

      Try

         dtDatos = DirectCast(Me.ugDetalle.DataSource, DataTable)
         regla.ImportarContactos(actual.Sucursal.Id,
                                    dtDatos,
                                    actual.Nombre,
                                    Me.prbImportando)
      Catch ex As Exception
         Throw
      Finally
         Me.tsbImportar.Enabled = False
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
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

   Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click

      Try

         If Me.txtArchivoOrigen.Text.Trim() = "" Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         RangoExcel = "[" & Me.txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
         If RangoExcel = "" Or RangoExcel = RangoInicial Then
            MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
            Me.txtRangoCeldas.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.Mostrar()

         If ugDetalle.Rows.Count > 0 Then
            Me.tsbImportar.Enabled = True
         End If

         FormatearGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click

      Try

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim mensaje As String = String.Format("Se importaran {0} Contactos y se actualizarán {1} Contactos", AccionA - ContactosConError, AccionM)
         MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         If ContactosConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ContactosConError.ToString() & " Contactos que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         If AccionM > 0 Then
            MessageBox.Show("Se importaron y actualizaron " & (Me.ugDetalle.Rows.Count - ContactosConError).ToString() & " Contactos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show("Se importaron " & (Me.ugDetalle.Rows.Count - ContactosConError).ToString() & " Contactos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         Me.prbImportando.Value = 0
         'Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region
End Class