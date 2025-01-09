Imports System.Threading

Public Class ImportarWebSiExport

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Me.cmbCartuchos.Items.Add("TODOS")
      Me.cmbCartuchos.Items.Add("Clientes")
      Me.cmbCartuchos.Items.Add("Ventas")

      Me.cmbCartuchos.SelectedIndex = 0

   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnBajar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Me.btnEjecutar.Enabled = False
         Application.DoEvents()
         tssInfo.Text = "Ejecutando cartuchos..."
         Me.rtbBajando.Text = String.Empty
         rtbErrores.Text = String.Empty
         tssInfo.Text = String.Empty
         Me.tbcPantallas.SelectedTab = Me.tbpInfo
         Me.EjecutarCartucho(False)

         Me.tsbImportar.Enabled = True
         'Me.grbPendientes.Enabled = False

      Catch ex As Exception
         MessageBox.Show(Me.Text, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.btnEjecutar.Enabled = True
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      Try
         If MessageBox.Show("Va a proceder a importar los registros obtenidos de la Web al sistema, ¿esta seguro?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> DialogResult.Yes Then
            Return
         End If
         Me.Cursor = Cursors.WaitCursor
         tbpErrores.Text = String.Format("Errores")
         rtbErrores.Text = String.Empty
         If TypeOf (Me.dgvCartuchos.DataSource) Is DataTable Then
            DirectCast(Me.dgvCartuchos.DataSource, DataTable).Clear()
         End If
         Me.tssInfo.Text = "Comenzando a importar registros..."
         Me.tbcPantallas.SelectedTab = Me.tbpCartuchos
         Application.DoEvents()
         'Hacer la logica de importar
         Me.tssInfo.Text = "Comenzando a importar registros..."
         Dim reg As Reglas.ImportarWebSiExport = New Reglas.ImportarWebSiExport()
         Dim res As Reglas.ImportarWebSiExport.Resultado
         res = reg.ImportarDatosCartuchos(Me.GetCartucho(), tpbBarra, tssInfo, tssInfo2)
         dgvCartuchos.DataSource = res.Datos
         rtbErrores.Text = String.Join(Environment.NewLine, res.ListaErrores)
         tbpErrores.Text = String.Format("Errores ({0})", res.ConErrores)

         Me.tssInfo.Text = "Actualizando fechas de procesado en la Web..."
         Me.EjecutarCartucho(True)
         Me.tssInfo.Text = ""

         MessageBox.Show("El proceso ha finalizado!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.cmbCartuchos.SelectedIndex = 0
      Me.grbPendientes.Enabled = True
      Me.tpbBarra.Value = 0
      Me.rtbBajando.Text = String.Empty
      Me.tssInfo.Text = String.Empty

      If TypeOf (Me.dgvCartuchos.DataSource) Is DataTable Then
         DirectCast(Me.dgvCartuchos.DataSource, DataTable).Clear()
      End If

   End Sub

   Private Function GetCartucho() As Reglas.ImportarWebSiExport.Cartuchos
      Select Case Me.cmbCartuchos.SelectedIndex
         Case 0
            Return Reglas.ImportarWebSiExport.Cartuchos.TODOS
         Case 1
            Return Reglas.ImportarWebSiExport.Cartuchos.Clientes
         Case 2
            Return Reglas.ImportarWebSiExport.Cartuchos.Ventas
         Case Else
            Return Reglas.ImportarWebSiExport.Cartuchos.TODOS
      End Select
   End Function

   Private Function GetArgumentos() As String
      Dim arg As String

      Select Case Me.cmbCartuchos.SelectedIndex
         Case 1
            arg = "5 1"
         Case 2
            arg = "5 2"
         Case Else
            arg = ""
      End Select

      arg = arg + " 4" 'le digo que solo ejecute la bajada de datos

      Return arg
   End Function

   Private Async Sub EjecutarCartucho(actualizaFechaProcesado As Boolean)
      Dim dirDefecto As String = System.IO.Directory.GetCurrentDirectory()
      Try
         If Not System.IO.Directory.Exists("SiExport") Then
            Throw New Exception("No existe el directorio SiExport")
         End If
         System.IO.Directory.SetCurrentDirectory(dirDefecto + "\SiExport")
         Dim ejecutable As String = System.IO.Directory.GetCurrentDirectory() + "\SiExport.Consola.exe"

         If Not System.IO.File.Exists(ejecutable) Then
            Throw New Exception("No existe el archivo SiExport.Consola.exe")
         End If
         Dim proceso As Process = New Process()
         proceso.StartInfo.FileName = ejecutable

         If actualizaFechaProcesado Then
            'reviso los parametros para enviarlos a la app
            proceso.StartInfo.Arguments = "6"
         Else
            proceso.StartInfo.Arguments = GetArgumentos()
         End If

         proceso.StartInfo.RedirectStandardOutput = True
         proceso.StartInfo.UseShellExecute = False
         proceso.StartInfo.CreateNoWindow = True 'si es true no muestra la pantalla

         proceso.Start()

         If Not actualizaFechaProcesado Then
            rtbBajando.Text = proceso.StandardOutput.ReadToEnd()
            'rtbBajando.Text = Await Task.Run(Function() proceso.StandardOutput.ReadToEndAsync())
            'Await Task.Run(Sub() proceso.WaitForExit())
         End If
         proceso.WaitForExit()

         While Not proceso.HasExited
            tssInfo.Text += "."
            Thread.Sleep(5000)
         End While

         tssInfo.Text = "Proceso finalizado!"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text)
      Finally
         System.IO.Directory.SetCurrentDirectory(dirDefecto)
      End Try
   End Sub


#End Region

End Class