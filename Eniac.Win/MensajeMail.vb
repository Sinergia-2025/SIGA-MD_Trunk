Public Class MensajeMail
   Private _ArchivoAAdjuntar As String
   Private _textoSinAdjuntoInicial As String

   Public Property ArchivoAAdjuntar As String
      Get
         Return _ArchivoAAdjuntar
      End Get
      Set
         _ArchivoAAdjuntar = Value
         MostrarNombreAdjunto(Value)
      End Set
   End Property

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F9 Then
         btnEnviar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         Close()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      TryCatched(Sub() chbCopiaASiMismo.Checked = Reglas.Publicos.MailCopiaASiMismo)
      TryCatched(Sub() _textoSinAdjuntoInicial = lblAdjuntos.Text)
   End Sub

   Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
      TryCatched(
      Sub()
         If txtAsunto.Text.Trim.Length = 0 Then
            ShowMessage("ATENCION: debe indicar un Asunto de Correo!!")
            Exit Sub
         End If

         If txtCuerpo.Text.Trim.Length = 0 Then
            ShowMessage("ATENCION: debe indicar un Cuerpo de Correo!!")
            Exit Sub
         End If

         tslTexto.Text = "Armando mail..."
         Application.DoEvents()

         Dim destinatarios = txtDestinatarios.Text.Split(";"c).Where(Function(x) txtDestinatarios.Text.Trim.Length > 5 And txtDestinatarios.Text.Contains("@")).ToList()
         Dim destinatariosCC = txtDestinatariosCC.Text.Split(";"c).Where(Function(x) txtDestinatarios.Text.Trim.Length > 5 And txtDestinatarios.Text.Contains("@")).ToList()
         Dim destinatariosCCO = txtDestinatariosCCO.Text.Split(";"c).Where(Function(x) txtDestinatarios.Text.Trim.Length > 5 And txtDestinatarios.Text.Contains("@")).ToList()

         If destinatarios.Count + destinatariosCC.Count + destinatariosCCO.Count = 0 Then
            ShowMessage("ATENCION: debe indicar una Direccion de Correo válida!!")
            Exit Sub
         End If

         If chbCopiaASiMismo.Checked Then
            Dim strCorreoSaliente As String

            If actual.MailConfig.UtilizaComoPredeterminado Then
               strCorreoSaliente = actual.MailConfig.Direccion
            Else
               strCorreoSaliente = Reglas.Publicos.MailDireccion
            End If

            destinatariosCC.Add(strCorreoSaliente)
         End If

         Dim mail = New MailSSS()
         mail.CrearMail(destinatarios.ToArray(), txtAsunto.Text, txtCuerpo.Text, destinatariosCC.ToArray(), destinatariosCCO.ToArray())

         If Not String.IsNullOrEmpty(ArchivoAAdjuntar) Then
            mail.AgregarAdjunto(ArchivoAAdjuntar)
         End If
         tslTexto.Text = "Enviando mail..."
         Application.DoEvents()
         mail.EnviarMail()

         tslTexto.Text = "Mail enviado."
         Close()
      End Sub,
      onErrorAction:=Sub(owner, ex) ShowError(ex, recursivo:=True))
   End Sub
   Private Sub MostrarNombreAdjunto(value As String)
      lblAdjuntos.BackColor = Nothing
      lblAdjuntos.ForeColor = Nothing
      If String.IsNullOrWhiteSpace(value) Then
         lblAdjuntos.Text = _textoSinAdjuntoInicial
      Else
         If IO.File.Exists(value) Then
            lblAdjuntos.Text = value
            btnVerAdjunto.Visible = True
         Else
            lblAdjuntos.Text = String.Format("(NO EXISTE) {0}", value)
            lblAdjuntos.BackColor = Color.Red
            lblAdjuntos.ForeColor = Color.White
         End If
      End If
   End Sub

   Private Sub btnAgenda_Click(sender As Object, e As EventArgs) Handles btnAgenda.Click
      TryCatched(Sub() AbrirAgenda())
   End Sub
   Public Sub AbrirAgenda()
      Using frm = New MensajeMailAgenda()
         If frm.ShowDialog(Me, txtDestinatarios.Text, txtDestinatariosCC.Text, txtDestinatariosCCO.Text) = DialogResult.OK Then
            txtDestinatarios.Text = frm.Destinatarios
            txtDestinatariosCC.Text = frm.DestinatariosCC
            txtDestinatariosCCO.Text = frm.DestinatariosCCO

            grpDestinatariosCC.Expanded = Not String.IsNullOrWhiteSpace(txtDestinatariosCC.Text)
            grpDestinatariosCCO.Expanded = Not String.IsNullOrWhiteSpace(txtDestinatariosCCO.Text)
         End If
      End Using
   End Sub

   Private Sub btnVerAdjunto_Click(sender As Object, e As EventArgs) Handles btnVerAdjunto.Click
      TryCatched(Sub() If IO.File.Exists(ArchivoAAdjuntar) Then Process.Start(ArchivoAAdjuntar))
   End Sub
End Class