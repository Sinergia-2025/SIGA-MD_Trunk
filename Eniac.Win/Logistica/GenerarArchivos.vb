#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class GenerarArchivos

#Region "Campos"
   Private _publicos As Publicos
   Private _interno As Boolean
   Private CarpetaCreada As String = String.Empty
   Private _valoresListaPrecios As Dictionary(Of Integer, Entidades.ListaDePrecios)

   Private ReadOnly Property FormatoExportacion() As Entidades.GenerarArchivo.FormatosExportacion
      Get
         If cmbFormatoArchivo.SelectedValue Is Nothing Then DefaultValueParaFormatoExportacion()
         Return DirectCast(cmbFormatoArchivo.SelectedValue, Entidades.GenerarArchivo.FormatosExportacion)
      End Get
   End Property
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _valoresListaPrecios = New Dictionary(Of Integer, Eniac.Entidades.ListaDePrecios)()
         For Each lista As Eniac.Entidades.ListaDePrecios In New Eniac.Reglas.ListasDePrecios().GetTodos(Nothing, Eniac.Entidades.ListaDePrecios.Columnas.NombreListaPrecios)
            _valoresListaPrecios.Add(clbListaDePrecios.Items.Count, lista)
            clbListaDePrecios.Items.Add(lista.NombreListaPrecios)
         Next

         Me._publicos.CargaComboEmpleados(Me.cmbVendedor, Eniac.Entidades.Publicos.TiposEmpleados.VENDEDOR)
         Me.cmbVendedor.SelectedIndex = 0

         _publicos.CargaComboDesdeEnum(cmbFormatoArchivo, GetType(Entidades.GenerarArchivo.FormatosExportacion))
         DefaultValueParaFormatoExportacion()

         Me.txtdestino.Text = Reglas.Publicos.Logistica.RutaArchivosPalm

         chbConIVA.Enabled = False
         'chbConIVA.Checked = Publicos.ExportarPreciosConIVA
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      Try
         If keyData = Keys.F4 Then
            btnGenerar.PerformClick()
            Return True
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"
   Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
      Me.Close()
   End Sub

   Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
      Try
         If ValidarFiltros() Then
            GenerarArchivos()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmdExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExaminar.Click
      Try
         Using dialogo As New System.Windows.Forms.FolderBrowserDialog()
            dialogo.RootFolder = System.Environment.SpecialFolder.Desktop
            dialogo.SelectedPath = txtdestino.Text
            If dialogo.ShowDialog() = Windows.Forms.DialogResult.OK Then
               Me.txtdestino.Text = dialogo.SelectedPath
            End If
         End Using
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbVendedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVendedor.SelectedIndexChanged
      Try
         Dim oRuta As Reglas.GenerarArchivos = New Reglas.GenerarArchivos
         Dim tablaRutas As DataTable

         Dim IdVendedor As Integer = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado

         tablaRutas = oRuta.GetRutasPreventista(IdVendedor)

         cmbRutas.DataSource = tablaRutas
         cmbRutas.DisplayMember = "NombreRuta"
         cmbRutas.ValueMember = "IdRuta"
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub clbArchivos_SelectedValueChanged(sender As Object, e As EventArgs) Handles clbArchivos.SelectedValueChanged
      Try
         'chbConIVA.Enabled = clbArchivos.CheckedItems.Contains("PRODUCTOS") Or
         '                    clbArchivos.CheckedItems.Contains("LISTAS DE PRECIOS")
         _interno = True
         chbTodosArchivos.Checked = clbArchivos.Items.Count = clbArchivos.CheckedItems.Count
         _interno = False
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbRutas_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbRutas.SelectedValueChanged
      Try
         If cmbRutas.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbRutas.SelectedValue) Then
            Dim ruta As Entidades.MovilRuta = New Reglas.MovilRutas().GetUno(Integer.Parse(cmbRutas.SelectedValue.ToString()))
            If ruta.ListasDePrecio.Count = 0 Then
               clbListaDePrecios.Enabled = True
               For i As Integer = 0 To clbListaDePrecios.Items.Count - 1
                  clbListaDePrecios.SetItemChecked(i, False)
               Next
            Else
               clbListaDePrecios.Enabled = False
               For i As Integer = 0 To clbListaDePrecios.Items.Count - 1
                  Dim lista As Eniac.Entidades.ListaDePrecios = _valoresListaPrecios(i)
                  Dim existe As Boolean = ruta.ExisteListaDePrecios(lista.IdListaPrecios)
                  clbListaDePrecios.SetItemChecked(i, existe)
               Next
            End If

            _interno = True
            chbTodasListas.Checked = clbListaDePrecios.Items.Count = clbListaDePrecios.CheckedItems.Count
            chbTodasListas.Enabled = clbListaDePrecios.Enabled
            _interno = False

            chbConIVA.Checked = ruta.PrecioConImpuestos

         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTodosArchivos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodosArchivos.CheckedChanged
      Try
         If Not _interno Then
            For i As Integer = 0 To clbArchivos.Items.Count - 1
               clbArchivos.SetItemChecked(i, chbTodosArchivos.Checked)
            Next
         End If
         'chbConIVA.Enabled = clbArchivos.CheckedItems.Contains("PRODUCTOS") Or
         '                    clbArchivos.CheckedItems.Contains("LISTAS DE PRECIOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTodasListas_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodasListas.CheckedChanged
      Try
         If Not _interno AndAlso clbListaDePrecios.Enabled Then
            For i As Integer = 0 To clbListaDePrecios.Items.Count - 1
               clbListaDePrecios.SetItemChecked(i, chbTodasListas.Checked)
            Next
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub clbListaDePrecios_SelectedValueChanged(sender As Object, e As EventArgs) Handles clbListaDePrecios.SelectedValueChanged
      Try
         _interno = True
         chbTodasListas.Checked = clbListaDePrecios.Items.Count = clbListaDePrecios.CheckedItems.Count
         _interno = False
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos Privados"

   Private Function ValidarFiltros() As Boolean

      If Me.cmbVendedor.SelectedIndex = -1 Then
         'preventista = 0
         ShowMessage("Debe seleccionar un preventista.")
         Me.cmbVendedor.Focus()
         Return False
      End If

      If Me.cmbRutas.SelectedIndex = -1 Then
         'preventista = 0
         ShowMessage("Debe seleccionar una ruta.")
         Me.cmbVendedor.Focus()
         Return False
      End If

      If Me.clbArchivos.CheckedItems.Count = 0 Then
         ShowMessage("Debe seleccionar al menos un archivo para generar")
         Me.clbArchivos.Focus()
         Return False
      End If

      If Me.txtdestino.Text = String.Empty Then
         ShowMessage("Debe seleccionar un destino correcto para el/los archivos/s")
         Me.cmdExaminar.Focus()
         Return False
      End If

      Return True
   End Function

   Private Sub GenerarArchivos()

      Dim oGenerar As Reglas.GenerarArchivos = New Reglas.GenerarArchivos()
      Dim mensajeResultado As StringBuilder = New StringBuilder()

      CarpetaCreada = txtdestino.Text

      If Not IO.Directory.Exists(CarpetaCreada) Then
         IO.Directory.CreateDirectory(CarpetaCreada)
      End If

      Dim IdVendedor As Integer = DirectCast(Me.cmbVendedor.SelectedItem, Eniac.Entidades.Empleado).IdEmpleado
      Dim idRuta As Integer = CInt(Me.cmbRutas.SelectedValue)

      For i As Integer = 0 To Me.clbArchivos.CheckedItems.Count - 1
         Select Case Me.clbArchivos.CheckedItems(i).ToString

            Case "RUTAS"
               Using tablaRutas As DataTable = oGenerar.GetRutasArchivo(IdVendedor, idRuta)
                  Using rutasSelec As DataTable = oGenerar.GetRutasSeleccionadas(IdVendedor, idRuta)
                     If rutasSelec.Rows.Count = 0 Then
                        mensajeResultado.AppendLine("Archivo de Rutas con 0 registros --> VERIFICAR!")
                     Else
                        mensajeResultado.AppendLine("Archivo de Rutas con " & tablaRutas.Rows.Count.ToString & " registro/s --> OK")

                        GenerarArchivoRutas(tablaRutas, "RUTAS", txtdestino.Text, rutasSelec)
                     End If
                  End Using
               End Using

            Case "CLIENTES"
               Using tablaClientes As DataTable = oGenerar.GetClientesArchivo(IdVendedor, idRuta)
                  If tablaClientes.Rows.Count = 0 Then
                     mensajeResultado.AppendLine("Archivo de Clientes con 0 registros --> VERIFICAR! (Vendedor sin Clientes asociados)")
                  Else
                     mensajeResultado.AppendLine("Archivo de Clientes con " & tablaClientes.Rows.Count.ToString & " registro/s --> OK")
                     grabarArchivo(tablaClientes, "CLIENTES", CarpetaCreada, False, idRuta)
                  End If
               End Using

            Case "PRODUCTOS"
               Dim idLista As Integer = -1
               If clbListaDePrecios.CheckedIndices.Count = 0 Then
                  mensajeResultado.AppendLine("No seleccionó ninguna lista de precios --> VERIFICAR!")
               Else
                  If clbListaDePrecios.CheckedIndices.Count = 1 Then
                     idLista = _valoresListaPrecios(clbListaDePrecios.CheckedIndices(0)).IdListaPrecios
                  End If
                  Using tablaArticulos As DataTable = oGenerar.GetArticulosArchivo(actual.Sucursal.IdSucursal, IdVendedor, chbConIVA.Checked, idLista) ' DirectCast(Me.cmbListaDePrecios.SelectedItem, Eniac.Entidades.ListaDePrecios).IdListaPrecios)
                     If tablaArticulos.Rows.Count = 0 Then
                        mensajeResultado.AppendLine("Archivo de Productos con 0 registros --> VERIFICAR!")
                     Else
                        mensajeResultado.AppendLine("Archivo de Productos con " & tablaArticulos.Rows.Count.ToString & " registro/s --> OK")
                        grabarArchivo(tablaArticulos, "PRODUCTOS", CarpetaCreada, False, idRuta)
                     End If
                  End Using
               End If

            Case "LISTAS DE PRECIOS"
               If clbListaDePrecios.CheckedItems.Count > 0 Then
                  Dim listas As List(Of Integer) = New List(Of Integer)()
                  For j As Integer = 0 To clbListaDePrecios.Items.Count - 1
                     If clbListaDePrecios.GetItemChecked(j) Then
                        listas.Add(_valoresListaPrecios(j).IdListaPrecios)
                     End If
                  Next
                  Using tablaListasDePrecios As DataTable = oGenerar.GetListasDePreciosArchivo(listas.ToArray(), chbConIVA.Checked)
                     If tablaListasDePrecios.Rows.Count = 0 Then
                        mensajeResultado.AppendLine("Archivo de Listas de Precios con 0 registros --> VERIFICAR!")
                     Else
                        mensajeResultado.AppendLine("Archivo de Listas de Precios con " & tablaListasDePrecios.Rows.Count.ToString & " registro/s --> OK")
                        grabarArchivo(tablaListasDePrecios, "LISTAS DE PRECIOS", CarpetaCreada, False, idRuta)
                     End If
                  End Using
               Else
                  mensajeResultado.AppendLine("No seleccionó ninguna lista de precios --> VERIFICAR!")
               End If

            Case "RUBROS"
               Using tablaRubros As DataTable = oGenerar.GetRubrosArchivo(actual.Sucursal.IdSucursal, IdVendedor)
                  If tablaRubros.Rows.Count = 0 Then
                     mensajeResultado.AppendLine("Archivo de Rubros con 0 registros --> VERIFICAR!")
                  Else
                     mensajeResultado.AppendLine("Archivo de Rubros con " & tablaRubros.Rows.Count.ToString & " registro/s --> OK")
                     grabarArchivo(tablaRubros, "RUBROS", CarpetaCreada, False, idRuta)
                  End If
               End Using

            Case "HISTÓRICOS"
               Using tablaHistoricos As DataTable = oGenerar.GetHistoricosArchivo(IdVendedor)
                  If tablaHistoricos.Rows.Count = 0 Then
                     mensajeResultado.AppendLine("Archivo de Históricos con 0 registros --> VERIFICAR!")
                  Else
                     mensajeResultado.AppendLine("Archivo de Históricos con " & tablaHistoricos.Rows.Count.ToString & " registro/s --> OK")
                     grabarArchivo(tablaHistoricos, "HISTORICOS", CarpetaCreada, False, idRuta)
                  End If
               End Using

            Case "CONFIGURACIONES"

               Using tablaConfiguraciones As DataTable = oGenerar.GetConfiguracionesArchivo(idRuta)
                  If tablaConfiguraciones.Rows.Count = 0 Then
                     mensajeResultado.AppendLine("Archivo de Configuraciones con 0 registros --> VERIFICAR!")
                  Else
                     mensajeResultado.AppendLine("Archivo de Configuraciones con " & tablaConfiguraciones.Rows.Count.ToString & " registro/s --> OK")
                     grabarArchivo(tablaConfiguraciones, "CONFIGURACIONES", CarpetaCreada, True, idRuta)
                  End If
               End Using

         End Select

      Next

      ShowMessage(mensajeResultado.ToString())

   End Sub

   Private Sub grabarArchivo(tablaDatos As DataTable,
                             tipo As String,
                             rutaArchivo As String,
                             agregaRuta As Boolean,
                             idRuta As Integer)
      Dim delimitador As String = ";"
      Dim linea As String = String.Empty
      Dim nombreArchivo As String = rutaArchivo & "\" & tipo.Replace(" ", "").ToLower() & ".csv"
      If System.IO.File.Exists(nombreArchivo) Then ' existe el archivo
         If MessageBox.Show("Desea sobreescribir el Archivo " & nombreArchivo & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then ' lo piso
            Exit Sub
         End If
      End If

      'GAR: 16/09/2016 - Cambie de ASCII a UTF8 por las Ñ y acentos.
      Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(nombreArchivo, False, System.Text.Encoding.UTF8)

         If FormatoExportacion = Entidades.GenerarArchivo.FormatosExportacion.Sync2 Then
            Dim tag As String = String.Empty
            If tipo = "CLIENTES" Then
               tag = Entidades.GenerarArchivo.TagsSync2.TAG_CLIENTES
            ElseIf tipo = "PRODUCTOS" Then
               tag = Entidades.GenerarArchivo.TagsSync2.TAG_PRODUCTOS
            ElseIf tipo = "RUBROS" Then
               tag = Entidades.GenerarArchivo.TagsSync2.TAG_RUBROS
            ElseIf tipo = "HISTORICOS" Then
               tag = Entidades.GenerarArchivo.TagsSync2.TAG_HISTORICOS
            ElseIf tipo = "CONFIGURACIONES" Then
               tag = Entidades.GenerarArchivo.TagsSync2.TAG_CONFIGURACIONES
            ElseIf tipo = "LISTAS DE PRECIOS" Then
               tag = Entidades.GenerarArchivo.TagsSync2.TAG_LISTASPRECIOS
            End If
            If Not String.IsNullOrWhiteSpace(tag) Then
               sw.WriteLine(tag) 'agego la linea con el tag
            End If
         End If

         If agregaRuta Then
            sw.WriteLine(idRuta) 'agego la linea con la ruta
         End If

         For Each dr As DataRow In tablaDatos.Rows

            For col As Integer = 0 To tablaDatos.Columns.Count - 1
               linea += dr(col).ToString & delimitador
            Next

            sw.WriteLine(linea.Substring(0, linea.Length - 1))

            linea = String.Empty
         Next
         sw.Close()
      End Using
   End Sub

   Private Sub GenerarArchivoRutas(tablaDatos As DataTable,
                                   tipo As String,
                                   rutaArchivo As String,
                                   rutasSelec As DataTable)

      Dim delimitador As String = ";"
      Dim linea As String = String.Empty
      Dim nombreArchivo As String = String.Empty '= rutaArchivo & "\" & tipo.ToLower & ".csv"


      For i As Integer = 0 To rutasSelec.Rows.Count - 1 ' para cada ruta seleccionada

         For Each fila As DataRow In tablaDatos.Select("idRuta = " & rutasSelec.Rows(i)(0).ToString) ' para c/ ruta armo el archivo
            If Not System.IO.Directory.Exists(rutaArchivo & "\" & tipo.ToLower & "\" & fila("nombreEmpleado").ToString.ToLower) Then ' armo el directorio
               System.IO.Directory.CreateDirectory(rutaArchivo & "\" & tipo.ToLower & "\" & fila("nombreEmpleado").ToString.ToLower)
            End If

            nombreArchivo = rutaArchivo & "\" & tipo.ToLower & "\" & fila("nombreEmpleado").ToString.ToLower & "\" & tipo.ToLower & ".csv"

            CarpetaCreada = rutaArchivo & "\" & tipo.ToLower & "\" & fila("nombreEmpleado").ToString.ToLower

            If System.IO.File.Exists(nombreArchivo) Then ' existe el archivo
               If MessageBox.Show("Desea sobreescribir el Archivo " & nombreArchivo & "?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then ' lo piso
                  Exit For
               Else
                  Exit Sub
               End If
            Else ' no existe... le doy gas
               Exit For
            End If
         Next

         Using sw As System.IO.StreamWriter = New System.IO.StreamWriter(nombreArchivo, False, System.Text.Encoding.UTF8)

            If FormatoExportacion = Entidades.GenerarArchivo.FormatosExportacion.Sync2 Then
               sw.WriteLine(Entidades.GenerarArchivo.TagsSync2.TAG_RUTAS) 'agego la linea con la ruta
            End If

            sw.WriteLine(rutasSelec.Rows(i)(0).ToString) 'agego la linea con la ruta

            For Each fila2 As DataRow In tablaDatos.Select("idRuta = " & rutasSelec.Rows(i)(0).ToString) ' para ruta armo el archivo
               'linea = fila2("orden").ToString & delimitador & fila2("nrodocCliente").ToString & delimitador & fila2("dia").ToString
               linea = fila2("orden").ToString & delimitador & fila2("CodigoCliente").ToString & delimitador & fila2("dia").ToString
               sw.WriteLine(linea)
               linea = String.Empty
            Next
            sw.Close()
         End Using

      Next

   End Sub

   Private Sub DefaultValueParaFormatoExportacion()
      cmbFormatoArchivo.SelectedValue = Reglas.Publicos.Logistica.LogisticaFormatoExportacionDefaultEnum
   End Sub

#End Region

End Class