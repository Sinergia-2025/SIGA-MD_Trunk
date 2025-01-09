Option Explicit On
Option Strict On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports System.Data
Imports System.IO

#End Region

Public Class EnvioDeCorreo

#Region "Campos"

   Private _publicos As Win.Publicos
   Private _enviado As Boolean = False
   Private _idDato As Long = 0
   Private _IdTipoImpuesto As Integer = 0
   Private _IdMunicipio As Integer = 0

#End Region

#Region "Overrides"

   Public Sub New(ByVal idDato As Long, ByVal Correo As String, ByVal Asunto As String, ByVal Cuerpo As String)

      ' This call is required by the designer.
      InitializeComponent()

      txtCorreo.Text = Correo
      txtAsuntoMail.Text = Asunto
      rtbCuerpoMail.Rtf = Cuerpo

      _idDato = idDato

      Me.tssRegistros.Text = String.Empty

      ' Add any initialization after the InitializeComponent() call.

   End Sub

   Public Sub New(ByVal cuenta As Long, ByVal IdTipoImpuesto As Integer, ByVal IdMunicipio As Integer,
                  ByVal Correo As String, ByVal Asunto As String, ByVal Cuerpo As String)

      ' This call is required by the designer.
      InitializeComponent()

      txtCorreo.Text = Correo
      txtAsuntoMail.Text = Asunto
      rtbCuerpoMail.Rtf = Cuerpo

      _idDato = cuenta
      _IdTipoImpuesto = IdTipoImpuesto
      _IdMunicipio = IdMunicipio

      Me.tssRegistros.Text = String.Empty

      ' Add any initialization after the InitializeComponent() call.

   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try

         Me._publicos = New Win.Publicos()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region

#Region "Eventos"

   Private Sub EnvioMasivoDeCorreos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.tssRegistros.Text = String.Empty

         Me.txtCorreo.Text = ""
         Me.txtAsuntoMail.Text = ""
         Me.rtbCuerpoMail.Text = ""

         Me.txtArchivo1.Text = ""
         Me.txtArchivo2.Text = ""
         Me.txtArchivo3.Text = ""
         Me.txtArchivo4.Text = ""

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnExaminar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar1.Click
      Me.ExaminarArchivo(1)
   End Sub

   Private Sub btnExaminar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar2.Click
      Me.ExaminarArchivo(2)
   End Sub

   Private Sub btnExaminar3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar3.Click
      Me.ExaminarArchivo(3)
   End Sub

   Private Sub btnExaminar4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar4.Click
      Me.ExaminarArchivo(4)
   End Sub

   Private Sub tsbEnviarCorreos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEnviarCorreos.Click

      Try

         Me.Cursor = Cursors.WaitCursor

         If String.IsNullOrEmpty(Me.txtCorreo.Text) Then
            MessageBox.Show("ATENCION: Debe ingresar la Direccion del Correo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAsuntoMail.Focus()
            Exit Sub
         End If

         If String.IsNullOrEmpty(Me.txtAsuntoMail.Text) Then
            MessageBox.Show("ATENCION: Debe ingresar el Asunto del Correo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtAsuntoMail.Focus()
            Exit Sub
         End If

         If String.IsNullOrEmpty(Me.rtbCuerpoMail.Text) Then
            MessageBox.Show("ATENCION: Debe ingresar el Cuerpo del Correo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.rtbCuerpoMail.Focus()
            Exit Sub
         End If

         Dim resp As DialogResult
         If (String.IsNullOrEmpty(Me.txtArchivo1.Text) And String.IsNullOrEmpty(Me.txtArchivo2.Text) And String.IsNullOrEmpty(Me.txtArchivo3.Text) And String.IsNullOrEmpty(Me.txtArchivo4.Text)) Then
            resp = MessageBox.Show("ATENCION: No ha adjuntado ningun archivo. Desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If resp = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         Else
            resp = MessageBox.Show("Esta seguro de haber adjuntado todos los archivos a enviar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If resp = Windows.Forms.DialogResult.No Then
               Exit Sub
            End If
         End If

         resp = MessageBox.Show("Esta seguro de haber liquidado todos los periodos?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information)
         If resp = Windows.Forms.DialogResult.No Then
            Exit Sub
         End If

         Dim CorreoSSS As Eniac.Win.MailSSS
         Dim destina As List(Of String) = New List(Of String)()

         Dim Correos() As String

         'cargo los destinatarios
         destina.Clear()
         Correos = txtCorreo.Text.Split(";"c)

         Me.tspBarra.Maximum = 1
         Me.tspBarra.Value = 0

         Me.tslTexto.Text = "Enviando Mail a: " & txtCorreo.Text
         Application.DoEvents()

         Dim Cont As Integer
         For Cont = 0 To Correos.Length - 1
            destina.Add(Correos(Cont))
         Next

         Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder()
         stb.Append("<!DOCTYPE HTML>")
         stb.Append("<html>")
         stb.Append("<head>")
         stb.Append("</head>")
         stb.Append("<body>")
         For Each st As String In Me.rtbCuerpoMail.Lines
            stb.Append("<br>")
            stb.Append(st)
         Next
         stb.Append("</body>")
         stb.Append("</html>")


         Dim html2 As RTFtoHTML = New RTFtoHTML()

         html2.rtf = Me.rtbCuerpoMail.Rtf '"<b>This is bold</b> <font color=#336699>This is blue</font>" '

         Dim html As String

         html = html2.Convertir(Me.rtbCuerpoMail.Rtf)
         'html = html2.html

         'creo el mail y lo envio
         CorreoSSS = New Eniac.Win.MailSSS()

         '     Dim CC As String() = {CorreoSSS.getFrom}

         'CorreoSSS.CrearMail(destina.ToArray(), Me.txtAsuntoMail.Text, Me.rtbCuerpoMail.Text, CC)
         CorreoSSS.CrearMail(destina.ToArray(), Me.txtAsuntoMail.Text, html, Nothing, Nothing)

         If Not String.IsNullOrEmpty(Me.txtArchivo1.Text) Then
            CorreoSSS.AgregarAdjunto(Me.txtArchivo1.Text)
         End If
         If Not String.IsNullOrEmpty(Me.txtArchivo2.Text) Then
            CorreoSSS.AgregarAdjunto(Me.txtArchivo2.Text)
         End If
         If Not String.IsNullOrEmpty(Me.txtArchivo3.Text) Then
            CorreoSSS.AgregarAdjunto(Me.txtArchivo3.Text)
         End If
         If Not String.IsNullOrEmpty(Me.txtArchivo4.Text) Then
            CorreoSSS.AgregarAdjunto(Me.txtArchivo4.Text)
         End If

         CorreoSSS.EnviarMail()

         Me.tspBarra.Value += 1

         MessageBox.Show("Correos enviados con Exito !!.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.tslTexto.Text = String.Empty

         Me._enviado = True

         Me.tspBarra.Value = 0

         If Me._IdMunicipio <> 0 Then
            Dim colDatos As List(Of String) = New List(Of String)
            Dim reg As Reglas.Cartas = New Reglas.Cartas()

            Dim idCarta As Integer = 72

            Dim Carta As Entidades.Carta = New Reglas.Cartas().GetUno(72)

            Dim diasAlerta As Integer
            If Not String.IsNullOrEmpty(Carta.ProximaCarta.ToString()) Then
               diasAlerta = Integer.Parse(Carta.DiasDefault.ToString())
            Else
               diasAlerta = -1
            End If

            Dim proximaCarta As Integer = 0

            If Not String.IsNullOrEmpty(Carta.ProximaCarta.ToString()) Then
               proximaCarta = Int32.Parse(Carta.ProximaCarta.ToString())
            End If

            'pido la fecha de la liquidacion y la fecha del alerta
            Dim fech As CartasFechas = New CartasFechas(idCarta, diasAlerta, proximaCarta)

            If fech.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
               Exit Sub
            End If

            If Not fech.chbEnlazaProxCarta.Checked Then
               proximaCarta = 0
            End If

            colDatos.Add(Me._idDato.ToString())

            'reg.EnvioCartasCuentasInmobiliario(colDatos, _
            '                       Me._IdTipoImpuesto, _
            '                       Me._IdMunicipio, _
            '   idCarta, _
            '   Eniac.Entidades.Usuario.Actual.Nombre, _
            '   proximaCarta, _
            '   fech.dtpFechaLiquidacion.Value, _
            '   fech.dtpFechaAlertaProxCarta.Value, _
            '   fech.dtpFechaAlertaLlamado.Value, 0, False)

            '   Me.generarAlertasYGestionCuentas()
         Else
            ' Me.generarAlertasYGestion()

            'Mutual
            Dim colDatos As List(Of Long) = New List(Of Long)
            Dim reg As Reglas.Cartas = New Reglas.Cartas()

            Dim idCarta As Integer = 83

            Dim Carta As Entidades.Carta = New Reglas.Cartas().GetUno(83)

            Dim diasAlerta As Integer
            If Not String.IsNullOrEmpty(Carta.ProximaCarta.ToString()) Then
               diasAlerta = Integer.Parse(Carta.DiasDefault.ToString())
            Else
               diasAlerta = -1
            End If

            Dim proximaCarta As Integer = 0

            If Not String.IsNullOrEmpty(Carta.ProximaCarta.ToString()) Then
               proximaCarta = Int32.Parse(Carta.ProximaCarta.ToString())
            End If

            'pido la fecha de la liquidacion y la fecha del alerta
            Dim fech As CartasFechas = New CartasFechas(idCarta, diasAlerta, proximaCarta)

            If fech.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
               Exit Sub
            End If

            If Not fech.chbEnlazaProxCarta.Checked Then
               proximaCarta = 0
            End If

            colDatos.Add(Me._idDato)

            reg.EnvioCartasMutual(colDatos, _
                                  idCarta, _
               Eniac.Entidades.Usuario.Actual.Nombre, _
               proximaCarta, _
               fech.dtpFechaLiquidacion.Value, _
               fech.dtpFechaAlertaProxCarta.Value, _
               fech.dtpFechaAlertaLlamado.Value)

         End If


      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Public Function fueEnviado() As Boolean
      Return Me._enviado
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub generarAlertasYGestion()

      'Dim rAlerta As New Reglas.Alertas
      'Dim rGestion As New Reglas.Gestiones
      'Dim rPromesa As New Reglas.PromesasDePagos

      'Dim idPP As Long = (New Reglas.PromesasDePagos).GetPromesaActiva(Me._idDato)
      'Dim msgCuota As String = ""

      'If idPP > 0 Then
      '   Dim offset As Integer = Integer.Parse(New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.ALERTACORREO.ToString))
      '   Dim oPromesa As Entidades.PromesaDePago = rPromesa.GetUno(idPP)
      '   Dim tipoNotificacion As Integer = CInt(If(oPromesa.TipoPromesa = "O", 11, 10))
      '   Dim dtCuotasPendientes As DataTable = (New Reglas.PromesasDePagosDetalles).GetCuotasPendientes(idPP)

      '   Dim textoGestion As String = "Se ha enviado un correo por la Cuota "
      '   Dim textoAlerta As String = "Corroborar el pago (mail enviado el " + DateTime.Now().ToString("dd/MM/yyyy") + ") de las cuotas "

      '   '===============================================
      '   'Dim en As Entidades.PromesaDePago = oPromesa
      '   Dim vencimiento As New Dictionary(Of Short, Date)
      '   Dim mensaje As New Dictionary(Of Short, String)
      '   Me.LeerVencimientosYPeriodos(oPromesa, vencimiento, mensaje)

      '   Dim catAll As String = ""
      '   Dim msj As String = String.Empty

      '   For Each k As Short In vencimiento.Keys
      '      Dim cuota As Short = k
      '      Dim venc As Date = vencimiento(k)
      '      msj = "Nº" & k.ToString & " Venc. " & venc.ToString("dd/MM/yyyy") & " [" & mensaje(k) & "], "
      '      catAll = catAll & msj
      '      Exit For
      '   Next

      '   textoAlerta = textoAlerta + catAll.Substring(0, catAll.Length - 2) + "."
      '   rAlerta.Crear(CDate(dtCuotasPendientes.Rows(0).Item("FechaCuota").ToString()).AddDays(offset), textoAlerta, False, Me._idDato, False, tipoNotificacion)
      '   msgCuota = msgCuota & CDate(dtCuotasPendientes.Rows(0).Item("FechaCuota").ToString()).AddDays(7).ToString("dd/MM/yyyy")

      '   '===============================================

      '   Dim primerCuotaPendiente As Integer
      '   Dim ImporteReclamado As Decimal = 0

      '   If dtCuotasPendientes.Rows.Count > 0 Then

      '      'Dim primerCuotaPendiente As String = (New Reglas.Pagos).GetPrimerPeriodoPendiente(Me._idDato)
      '      primerCuotaPendiente = Integer.Parse(dtCuotasPendientes.Rows(0).Item("NumeroCuota").ToString())

      '      textoGestion = textoGestion & dtCuotasPendientes.Rows(0).Item("NumeroCuota").ToString() & ", Vencimiento: " & Date.Parse(dtCuotasPendientes.Rows(0).Item("FechaCuota").ToString()).ToString("dd/MM/yyyy") & " (Periodos: "

      '      For Each dr As DataRow In dtCuotasPendientes.Rows
      '         If primerCuotaPendiente <> Integer.Parse(dr("NumeroCuota").ToString()) Then
      '            Exit For
      '         End If
      '         textoGestion = textoGestion & dr("Periodo").ToString() & ", "
      '         ImporteReclamado += Decimal.Parse(dr("Importe").ToString())
      '      Next
      '      textoGestion = textoGestion.Substring(0, textoGestion.Length - 2) & ")" 'Quito la coma
      '   Else
      '      textoGestion = textoGestion & "Ninguna Pendiente"
      '   End If

      '   'textoGestion = textoGestion & primerCuotaPendiente

      '   rGestion.Crear(Me._idDato, DateTime.Now(), Eniac.Entidades.Usuario.Actual.Nombre, textoGestion, _
      '                  DateTime.Now(), tipoNotificacion, 5, ImporteReclamado)

      '   MessageBox.Show("Fueron creadas Alertas para las Fechas: " & msgCuota & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'Else
      '   MessageBox.Show("ATENCION: El Dominio no tiene una promesa de Pago Activa. No se generaran las Alertas por Cuotas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      'End If

   End Sub

   Private Sub generarAlertasYGestionCuentas()

      'Dim rAlerta As New Reglas.AlertasCuentas
      'Dim rGestion As New Reglas.GestionesCuentas
      'Dim rPromesa As New Reglas.Acuerdos

      'Dim idPP As Long = (New Reglas.Acuerdos).GetPromesaActiva(Me._idDato, Me._IdTipoImpuesto, Me._IdMunicipio)
      'Dim msgCuota As String = ""

      'If idPP > 0 Then
      '   Dim offset As Integer = Integer.Parse(New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.ALERTACORREO.ToString))
      '   Dim oPromesa As Entidades.Acuerdo = rPromesa.GetUno(idPP, Me._idDato, Me._IdTipoImpuesto, Me._IdMunicipio)
      '   Dim tipoNotificacion As Integer = CInt(If(oPromesa.TipoPromesa = "O", 11, 10))
      '   Dim dtCuotasPendientes As DataTable = (New Reglas.AcuerdosDetalles).GetCuotasPendientes(idPP, Me._idDato, Me._IdTipoImpuesto, Me._IdMunicipio, 1)

      '   Dim textoGestion As String = "Se ha enviado un correo por la Cuota "
      '   Dim textoAlerta As String = "Corroborar el pago (mail enviado el " + DateTime.Now().ToString("dd/MM/yyyy") + ") de las cuotas "

      '   '===============================================
      '   'Dim en As Entidades.PromesaDePago = oPromesa
      '   Dim vencimiento As New Dictionary(Of Short, Date)
      '   Dim mensaje As New Dictionary(Of Short, String)
      '   Me.LeerVencimientosYPeriodosCuentas(oPromesa, vencimiento, mensaje)

      '   Dim catAll As String = ""
      '   For Each k As Short In vencimiento.Keys
      '      Dim cuota As Short = k
      '      Dim venc As Date = vencimiento(k)
      '      Dim msj As String = "Nº" & k.ToString & " Venc. " & venc.ToString("dd/MM/yyyy") & " [" & mensaje(k) & "], "
      '      catAll = catAll & msj
      '   Next
      '   textoAlerta = textoAlerta + catAll.Substring(0, catAll.Length - 2) + "."
      '   rAlerta.Crear(CDate(dtCuotasPendientes.Rows(0).Item("FechaCuota").ToString()).AddDays(offset), textoAlerta, False, Me._idDato, Me._IdTipoImpuesto, Me._IdMunicipio, False, tipoNotificacion)
      '   msgCuota = msgCuota & CDate(dtCuotasPendientes.Rows(0).Item("FechaCuota").ToString()).AddDays(7).ToString("dd/MM/yyyy")

      '   '===============================================

      '   Dim primerCuotaPendiente As Integer

      '   If dtCuotasPendientes.Rows.Count > 0 Then

      '      'Dim primerCuotaPendiente As String = (New Reglas.Pagos).GetPrimerPeriodoPendiente(Me._idDato)
      '      primerCuotaPendiente = Integer.Parse(dtCuotasPendientes.Rows(0).Item("NumeroCuota").ToString())

      '      textoGestion = textoGestion & dtCuotasPendientes.Rows(0).Item("NumeroCuota").ToString() & ", Vencimiento: " & Date.Parse(dtCuotasPendientes.Rows(0).Item("FechaCuota").ToString()).ToString("dd/MM/yyyy") & " (Periodos: "

      '      For Each dr As DataRow In dtCuotasPendientes.Rows
      '         If primerCuotaPendiente <> Integer.Parse(dr("NumeroCuota").ToString()) Then
      '            Exit For
      '         End If
      '         textoGestion = textoGestion & dr("Periodo").ToString() & ", "
      '      Next
      '      textoGestion = textoGestion.Substring(0, textoGestion.Length - 2) & ")" 'Quito la coma
      '   Else
      '      textoGestion = textoGestion & "Ninguna Pendiente"
      '   End If

      '   'textoGestion = textoGestion & primerCuotaPendiente

      '   rGestion.Crear(Me._idDato, Me._IdTipoImpuesto, Me._IdMunicipio, DateTime.Now(), Eniac.Entidades.Usuario.Actual.Nombre, textoGestion, DateTime.Now(), tipoNotificacion)

      '   MessageBox.Show("Fueron creadas Alertas para las Fechas: " & msgCuota & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'Else
      '   MessageBox.Show("ATENCION: La Cuenta no tiene una promesa de Pago Activa. No se generaran las Alertas por Cuotas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      'End If

   End Sub

   'Private Sub LeerVencimientosYPeriodos(ByVal en As Entidades.PromesaDePago, ByRef vencimiento As Dictionary(Of Short, Date), ByRef mensaje As Dictionary(Of Short, String))
   '   Dim fieldSize As Integer = 150

   '   For Each detalle As Entidades.PromesaDePagoDetalle In en.Detalle

   '      If (detalle.FechaPago = Nothing) Then
   '         If Not (vencimiento.ContainsKey(detalle.NumeroCuota)) Then
   '            mensaje(detalle.NumeroCuota) = detalle.Periodo.ToString
   '            vencimiento(detalle.NumeroCuota) = detalle.FechaCuota
   '         Else
   '            If (Len(mensaje(detalle.NumeroCuota)) + Len(detalle.Periodo.ToString)) <= (fieldSize - 2) Then
   '               mensaje(detalle.NumeroCuota) = mensaje(detalle.NumeroCuota) & "/" & detalle.Periodo.ToString
   '            Else
   '               If Len(mensaje(detalle.NumeroCuota)) <= (fieldSize - 3) Then
   '                  mensaje(detalle.NumeroCuota) = mensaje(detalle.NumeroCuota) & "/#"
   '               Else
   '                  'Si no entra mas el #
   '                  mensaje(detalle.NumeroCuota) = mensaje(detalle.NumeroCuota).Substring(0, fieldSize - 3) & "/."
   '               End If
   '            End If
   '         End If
   '      End If
   '   Next

   'End Sub

   'Private Sub LeerVencimientosYPeriodosCuentas(ByVal en As Entidades.Acuerdo, ByRef vencimiento As Dictionary(Of Short, Date), ByRef mensaje As Dictionary(Of Short, String))
   '   Dim fieldSize As Integer = 150

   '   For Each detalle As Entidades.AcuerdoDetalle In en.Detalle

   '      If (detalle.FechaPago = Nothing) Then
   '         If Not (vencimiento.ContainsKey(detalle.NumeroCuota)) Then
   '            mensaje(detalle.NumeroCuota) = detalle.Periodo.ToString
   '            vencimiento(detalle.NumeroCuota) = detalle.FechaCuota
   '         Else
   '            If (Len(mensaje(detalle.NumeroCuota)) + Len(detalle.Periodo.ToString)) <= (fieldSize - 2) Then
   '               mensaje(detalle.NumeroCuota) = mensaje(detalle.NumeroCuota) & "/" & detalle.Periodo.ToString
   '            Else
   '               If Len(mensaje(detalle.NumeroCuota)) <= (fieldSize - 3) Then
   '                  mensaje(detalle.NumeroCuota) = mensaje(detalle.NumeroCuota) & "/#"
   '               Else
   '                  'Si no entra mas el #
   '                  mensaje(detalle.NumeroCuota) = mensaje(detalle.NumeroCuota).Substring(0, fieldSize - 3) & "/."
   '               End If
   '            End If
   '         End If
   '      End If
   '   Next

   'End Sub

   Private Sub ExaminarArchivo(ByVal NumeroArchivo As Integer)

      Dim par As Eniac.Reglas.Parametros = New Eniac.Reglas.Parametros()
      Dim path As String = par.GetValorPD("CORREODIRECTORIOADJUNTOS", "")

      Dim ArchivoStream As Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Adobe Reader (*.pdf)|*.pdf|Todos los Archivos (*.*)|*.*"
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.InitialDirectory = path
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Select Case NumeroArchivo
                  Case 1
                     Me.txtArchivo1.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo1.Focus()
                  Case 2
                     Me.txtArchivo2.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo2.Focus()
                  Case 3
                     Me.txtArchivo3.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo3.Focus()
                  Case Else
                     Me.txtArchivo4.Text = DialogoAbrirArchivo.FileName
                     Me.txtArchivo4.Focus()
               End Select
            End If
         Catch Ex As Exception
            MessageBox.Show("ATENCION: No se puede leer el Archivo " & NumeroArchivo.ToString() & ". Error: " & Ex.Message)
         Finally
            If (ArchivoStream IsNot Nothing) Then
               ArchivoStream.Close()
            End If
         End Try
      End If

   End Sub

#End Region

End Class