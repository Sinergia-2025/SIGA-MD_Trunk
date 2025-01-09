Imports actual = Eniac.Entidades.Usuario.Actual
Public Class Principal

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         If Me._ok Then
            'Le asigna al formulario de tareas el mdi 
            'Dim oTareas As Tareas = New Tareas()
            'oTareas.MdiParent = Me
            ''Muestra el formulario de tareas
            'oTareas.Show()

            Me.ControlesVarios()

         Else
            Application.Exit()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub ControlesVarios()

      'Chequeo y Genero (si no existe) el Periodo Fiscal
      Dim oPF As Reglas.PeriodosFiscales = New Reglas.PeriodosFiscales()
      Dim dt As DataTable = oPF.Get1(actual.Sucursal.IdEmpresa, Integer.Parse(Date.Now.ToString("yyyyMM")))
      If dt.Rows.Count = 0 Then
         oPF.CrearUnoEnBlanco(Integer.Parse(Date.Now.ToString("yyyyMM")))
      End If

      Dim verifResult As String = New Reglas.Ayudante.VerificarTablasEspejo().VerificaTablasEspejo()
      If Not String.IsNullOrWhiteSpace(verifResult) Then
         MessageBox.Show(verifResult, "ERROR DE MODELO DE DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error)

#If Not Debug Then
            Application.Exit()
#End If

      End If

   End Sub

#End Region

End Class