Public Class BaseCambioContrasena

   Private _sale As Boolean = True

   Private Function Valida() As Boolean
      If Me.txtUsuario.Text.Trim().Length = 0 Then
         MessageBox.Show("Debe ingresar un usuario.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtUsuario.Focus()
         Return False
      End If
      If Me.txtPwdActual.Text.Trim().Length = 0 Then
         MessageBox.Show("Debe ingresar la contraseña actual.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdActual.Focus()
         Return False
      End If
      If Me.txtPwdNueva.Text.Trim().Length = 0 Then
         MessageBox.Show("Debe ingresar una nueva contraseña.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdNueva.Focus()
         Return False
      End If
      If Me.txtPwdNueva2.Text.Trim().Length = 0 Then
         MessageBox.Show("Debe ingresar nuevamente la contraseña.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdNueva2.Focus()
         Return False
      End If

      If Publicos.PoliticasSeguridadClaves Then
         'compara las contraseñas con Case Sensitive, si difiere de 0 son distintas
         If String.Compare(Me.txtPwdNueva.Text.Trim(), Me.txtPwdNueva2.Text.Trim(), False) <> 0 Then
            MessageBox.Show("La nueva contraseña difiere de la repetición.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPwdNueva.Focus()
            Return False
         End If

      Else
         If Me.txtPwdNueva.Text.Trim().ToUpper() <> Me.txtPwdNueva2.Text.Trim().ToUpper() Then
            MessageBox.Show("La nueva contraseña difiere de la repetición.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtPwdNueva.Focus()
            Return False
         End If
      End If


      Dim oUsuario As Reglas.Usuarios = New Reglas.Usuarios()
      If Not oUsuario.EsValido(Me.txtUsuario.Text.Trim(), Me.txtPwdActual.Text.Trim(), Publicos.PoliticasSeguridadClaves) Then
         MessageBox.Show("El usuario o contraseña no son validos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtUsuario.Focus()
         Return False
      End If

      If Publicos.PoliticasSeguridadClaves Then
         If Not Me.VerificarPWD() Then
            Return False
         End If
      End If


      Return True
   End Function

   Private Function SonIgualesLasContraseñas(pwd1 As String, pwd2 As String) As Boolean

      Dim cantidad As Integer = 0
      Dim i As Integer = 0

      For Each ch As Char In pwd1
         If ch = pwd2.Chars(i) Then
            cantidad += 1
         End If
         i += 1
      Next

      If cantidad = pwd1.Length Then
         Return True
      Else
         Return False
      End If

      Return True
   End Function

   Private Sub btnCambiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
      Try
         If Valida() Then
            Dim oUsu As Reglas.Usuarios = New Reglas.Usuarios()
            oUsu.ActualizaPassword(Me.txtUsuario.Text.Trim(), Me.txtPwdNueva.Text.Trim())
            MessageBox.Show("La clave se actualizó satisfactoriamente!!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me._sale = False
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
      Me._sale = False
      Me.Close()
   End Sub

   Private Sub BaseCambioContrasena_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      e.Cancel = Me._sale
   End Sub


   Private Function VerificarPWD() As Boolean
      'Valida que la password nueva tenga al menos 1 numero y 1 letra
      Dim numeros As Integer = 0
      Dim letras As Integer = 0
      Dim mayusculas As Integer = 0
      Dim cantidad As Integer = 0
      For Each ch As Char In Me.txtPwdNueva.Text.ToString()
         If Char.IsNumber(ch) Then
            numeros += 1
         End If
         If Char.IsLetter(ch) Then
            letras += 1
         End If
         If Char.IsUpper(ch) Then
            mayusculas += 1
         End If
         cantidad += 1
      Next
      If (numeros < 1) Then
         MessageBox.Show("La contraseña nueva debe contener al menos 1 número.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdNueva.Focus()
         Return False
      End If

      If (letras < 1) Then
         MessageBox.Show("La contraseña nueva debe contener al menos 1 letra.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdNueva.Focus()
         Return False
      End If

      If (mayusculas < 1) Then
         MessageBox.Show("La contraseña nueva debe contener al menos 1 mayuscula.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdNueva.Focus()
         Return False
      End If

      If (cantidad < 8) Then
         MessageBox.Show("La contraseña nueva debe contener al menos 8 caracteres.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtPwdNueva.Focus()
         Return False
      End If

      'Controla si la contraseña nueva ya fue utilizada
      Dim oUsuarioClave As Reglas.UsuariosClaves = New Reglas.UsuariosClaves()
      Dim dt As DataTable
      dt = oUsuarioClave.GetUsuariosClaves(Me.txtUsuario.Text)
      For Each dr As DataRow In dt.Rows
         If dr("Clave").ToString() = Me.txtPwdNueva.Text() Then
            MessageBox.Show("La contraseña que quiere utilizar como nueva ya fue utilizada con anterioridad.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
         End If
      Next

      Return True
      'valida que no tenga todas estas palabras

      '                                       System.Collections.ArrayList ar = new System.Collections.ArrayList();
      '                                       ar.Add("CARGILL");        ar.Add("LUNES");                           ar.Add("MARTES");
      '                                       ar.Add("MIERCOLES"); ar.Add("JUEVES");                         ar.Add("VIERNES");
      '                                       ar.Add("SABADO");       ar.Add("DOMINGO");   ar.Add("ENERO");
      '                                       ar.Add("FEBRERO");      ar.Add("MARZO");                         ar.Add("ABRIL");
      '                                       ar.Add("MAYO");                           ar.Add("JUNIO");                           ar.Add("JULIO");
      '                                       ar.Add("AGOSTO");                       ar.Add("SETIEMBRE");  ar.Add("SEPTIEMBRE");
      '                                       ar.Add("OCTUBRE");     ar.Add("NOVIEMBRE");               ar.Add("DICIEMBRE");
      '                                       ar.Add("MONDAY");                     ar.Add("TUESDAY");      ar.Add("WEDNESDAY");
      '                                       ar.Add("THURSDAY");   ar.Add("FRIDAY");                          ar.Add("SATURDAY");
      '                                       ar.Add("SUNDAY");                       ar.Add("JANUARY");     ar.Add("FEBRUARY");
      '                                       ar.Add("MARCH");                         ar.Add("APRIL");                             ar.Add("MAY");
      '                                       ar.Add("JUNE");                              ar.Add("JULY");                               ar.Add("AUGUST");
      '                                       ar.Add("SEPTEMBER"); ar.Add("OCTOBER");     ar.Add("NOVEMBER");
      '                                       ar.Add("DECEMBER");


      '                                       foreach (string a in ar)
      '                                       {
      'If (pwd.IndexOf(a) > -1) Then
      '                                                       {
      '                                                                      throw new Exception("La contraseña no puede contener palabras reservadas como días de semana, meses, etc.");
      '                                                       }
      '                                       }
      '                       }

   End Function

   Private Sub txtPwdNueva_Leave(sender As Object, e As EventArgs) Handles txtPwdNueva.Leave
      Try
         'Realiza la verificación de que no se pueda ingresar cualquier tipo de pwd.
         If Publicos.PoliticasSeguridadClaves Then
            Me.VerificarPWD()
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class