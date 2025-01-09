Imports System.IO

Public Class FuncionesIconos

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Dim oFun As Reglas.Funciones = New Reglas.Funciones()
      Me.cmbFunciones.DataSource = oFun.GetAll("CadenaSegura")
      Me.FormatearComboFunciones()

   End Sub

#End Region

#Region "Metodos"

   Private Sub FormatearComboFunciones()
      With Me.cmbFunciones
         .DisplayMember = "Id"
         .ValueMember = "Id"
      End With
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnIcono_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIcono.Click
      If Me.ofdIcono.ShowDialog() = Windows.Forms.DialogResult.OK Then
         Me.txtIcono.Text = Me.ofdIcono.FileName
      End If
   End Sub
   Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim fsArchivo As FileStream = New FileStream(Me.txtIcono.Text, FileMode.Open, FileAccess.Read)

         Dim iFileLength As Integer = Convert.ToInt32(fsArchivo.Length)

         Dim myData(Int32.Parse(fsArchivo.Length.ToString())) As Byte

         fsArchivo.Read(myData, 0, iFileLength)

         fsArchivo.Close()

         Dim oFun As Reglas.Funciones = New Reglas.Funciones()

         oFun.GrabarImagen(myData, Me.cmbFunciones.Text)

         MessageBox.Show("El icono fue grabado satisfactoriamente!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

End Class