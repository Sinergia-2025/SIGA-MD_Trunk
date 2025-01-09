Option Strict Off
Public Class NotificacionesMutual


   Private _dato As Entidades.ClienteDeuda

   Public Sub New(ByVal dato As Entidades.ClienteDeuda)
      InitializeComponent()

      Me._dato = dato
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me.CargarDatosIniciales()
         Me.VerificarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatosIniciales()
      Dim car As Reglas.Cartas = New Reglas.Cartas()
      Me.cmbTipoCarta.DataSource = car.GetxTipo("MUTUAL", "Codigo")
      Me.cmbTipoCarta.DisplayMember = "NombreCarta"
      Me.cmbTipoCarta.ValueMember = "IdCarta"

      ''Dim AcuerdosCuotas As Reglas.Acuerdos = New Reglas.Acuerdos()
      ''Dim AcuerdoActivo As Long = AcuerdosCuotas.GetPromesaActiva(Me._dato.Cuenta, Me._dato.IdTipoImpuesto, Me._dato.IdMunicipio)
      ''Me.cmbCuotas.DataSource = New Reglas.AcuerdosDetalles().GetCuotas(AcuerdoActivo, Me._dato.Cuenta, Me._dato.IdTipoImpuesto, Me._dato.IdMunicipio)
      ''Me.cmbCuotas.DisplayMember = Entidades.AcuerdoDetalle.Columnas.NumeroCuota.ToString()
      ''Me.cmbCuotas.ValueMember = Entidades.AcuerdoDetalle.Columnas.NumeroCuota.ToString()

      Me.txtTitular.Text = Me._dato.Cliente.NombreCliente
      Me.txtPatente.Text = Me._dato.empresa.ToString()

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub tsbEmitirCarta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEmitirCarta.Click
      Try
         Me.EmitirCarta()
         Me.VerificarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbReimprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReimprimir.Click
      Try
         Me.ReimprimirCarta()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbCancelarCarta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelarCarta.Click
      Try
         Me.CancelarCarta()
         Me.VerificarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EmitirCarta()
      Dim dt As DSReportes.CartasDataTable = New DSReportes.CartasDataTable()
      Dim drC As DSReportes.CartasRow

      Dim primero As Boolean = True
      Dim colDatos As List(Of Long) = New List(Of Long)

      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder("")

      Dim idCarta As Integer = Int32.Parse(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.IdCarta.ToString()).ToString())

      'grabar todas las cartas en las tablas
      Dim diasAlerta As Integer = Int32.Parse(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.DiasDefault.ToString()).ToString())
      Dim proximaCarta As Integer = 0
      If Not String.IsNullOrEmpty(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.ProximaCarta.ToString()).ToString()) Then
         proximaCarta = Int32.Parse(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.ProximaCarta.ToString()).ToString())
      End If
      Dim diasLlamadasPrevias As Integer = 5

      'pido la fecha de la liquidacion y la fecha del alerta
      Dim fech As CartasFechas = New CartasFechas(idCarta, diasAlerta, proximaCarta)

      fech.dtpFechaLiquidacion.Value = DateTime.Now
      fech.dtpFechaAlertaLlamado.Value = DateTime.Now.AddDays(diasAlerta)
      If fech.ShowDialog() <> Windows.Forms.DialogResult.Yes Then
         Exit Sub
      End If

      Dim fechaAlerta As DateTime = fech.dtpFechaLiquidacion.Value.AddDays(diasAlerta)

      drC = dt.NewCartasRow()

      stb.Length = 0
      stb.AppendLine(Me._dato.Cliente.NombreCliente)
      stb.AppendLine(Me._dato.Cliente.Direccion)
      stb.AppendLine(Me._dato.Cliente.Localidad.NombreLocalidad)
      'If Me._dato.Localidad2.IdLocalidad.ToString().Length > 4 Then
      '   stb.AppendLine(Me._dato.Localidad2.IdLocalidad.ToString().Substring(0, 4))
      'Else
      '   stb.AppendLine(Me._dato.Localidad2.IdLocalidad.ToString())
      'End If
      drC.Destinatario = stb.ToString()

      stb.Length = 0

      'tendria que hacer una busqueda de los prestamos
      stb.AppendLine(Me._dato.nro_prestamo)
      '  stb.AppendLine(Me._dato.MarcaVehiculo)
      drC.Referencia = stb.ToString()

      drC.Texto = DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.Texto.ToString()).ToString().Replace("[Préstamo]", Me._dato.nro_prestamo)

      If idCarta = 1 Or idCarta = 4 Then
         'drC.Resaltado = Me._dato.PatenteVehiculo
      Else
         ' If idCarta = 2 Then
         'drC.Resaltado = "$ " + Me._dato.TotalAdeudado.ToString("#,##0.00") + " (ESTIMADO AL " + fech.dtpFechaLiquidacion.Value.ToString("dd/MM/yyyy") + ")"

         '   Else
         drC.Resaltado = String.Empty
         ' End If
      End If

      drC.Texto2 = DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.Texto2.ToString()).ToString()

      drC.Firma = DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.Firma.ToString()).ToString()

      drC.Fecha = DateTime.Now.ToString("dd \de MMMMMMM \de yyyy")

      '  drC.Localidad = "Expediente de " + Me._dato.Localidad.NombreLocalidad
      drC.Localidad = ""

      dt.AddCartasRow(drC)

      'cargo esta coleccion para mandar a grabar
      colDatos.Add(Me._dato.Cliente.IdCliente)

      If dt.Rows.Count > 0 Then

         If Not fech.chbEnlazaProxCarta.Checked Then
            proximaCarta = 0
         End If

         Dim reg As Reglas.Cartas = New Reglas.Cartas()
         reg.EnvioCartasMutual(colDatos, _
                         idCarta, _
                         Eniac.Entidades.Usuario.Actual.Nombre, _
                         proximaCarta, _
                         fech.dtpFechaLiquidacion.Value, _
                         fechaAlerta, _
                         fech.dtpFechaAlertaLlamado.Value)

         Me.ReCargarDatos()

         'mandar al preview
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Cartas.rdlc", "DSReportes_Cartas", dt, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.cmbTipoCarta.Text
         frmImprime.ShowDialog()
      End If
   End Sub

   Private Sub ReimprimirCarta()
      Dim dt As DSReportes.CartasDataTable = New DSReportes.CartasDataTable()
      Dim drC As DSReportes.CartasRow

      Dim primero As Boolean = True
      Dim colDatos As List(Of Long) = New List(Of Long)

      Dim stb As System.Text.StringBuilder = New System.Text.StringBuilder("")

      Dim idCarta As Integer = Int32.Parse(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.IdCarta.ToString()).ToString())

      drC = dt.NewCartasRow()

      stb.Length = 0
      stb.AppendLine(Me._dato.Cliente.NombreCliente)
      stb.AppendLine(Me._dato.Cliente.Direccion)
      stb.AppendLine(Me._dato.Cliente.Localidad.NombreLocalidad)
      'If Me._dato.Localidad2.IdLocalidad.ToString().Length > 4 Then
      '   stb.AppendLine(Me._dato.Localidad2.IdLocalidad.ToString().Substring(0, 4))
      'Else
      '   stb.AppendLine(Me._dato.Localidad2.IdLocalidad.ToString())
      'End If
      drC.Destinatario = stb.ToString()

      stb.Length = 0

      'tendria que hacer una busqueda de los prestamos
      stb.AppendLine(Me._dato.nro_prestamo)
      '  stb.AppendLine(Me._dato.MarcaVehiculo)
      drC.Referencia = stb.ToString()

      drC.Texto = DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.Texto.ToString()).ToString().Replace("[Préstamo]", Me._dato.nro_prestamo)

      If idCarta = 1 Or idCarta = 4 Then
         'drC.Resaltado = Me._dato.PatenteVehiculo
      Else
         ' If idCarta = 2 Then
         'drC.Resaltado = "$ " + Me._dato.TotalAdeudado.ToString("#,##0.00") + " (ESTIMADO AL " + fech.dtpFechaLiquidacion.Value.ToString("dd/MM/yyyy") + ")"

         '   Else
         drC.Resaltado = String.Empty
         ' End If
      End If

      drC.Texto2 = DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.Texto2.ToString()).ToString()

      drC.Firma = DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.Firma.ToString()).ToString()

      drC.Fecha = DateTime.Now.ToString("dd \de MMMMMMM \de yyyy")

      '  drC.Localidad = "Expediente de " + Me._dato.Localidad.NombreLocalidad
      drC.Localidad = ""

      dt.AddCartasRow(drC)

      'cargo esta coleccion para mandar a grabar
      colDatos.Add(Me._dato.Cliente.IdCliente)

      If dt.Rows.Count > 0 Then

         'cargar la gestion

         Dim SqlCRM As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Dim CRM As Entidades.CRMNovedad = New Entidades.CRMNovedad
         Dim id As Long
         'Dim rGestiones As Reglas.Gestiones = New Reglas.Gestiones
         'Dim Gestion As Entidades.Gestion = New Entidades.Gestion
         id = SqlCRM.GetCodigoMaximo("GESTIONES", "X", 1) + 1

         With CRM
            .TipoNovedad = New Reglas.CRMTiposNovedades().GetUno("GESTIONES")
            .Letra = .TipoNovedad.LetrasHabilitadas
            .IdNovedad = id
            .IdCliente = Me._dato.Cliente.IdCliente
            .FechaNovedad = DateTime.Now
            .FechaEstadoNovedad = DateTime.Now
            .Usuario = Eniac.Entidades.Usuario.Actual.Nombre
            .Descripcion = "REIMPRIMIR " & Me.cmbTipoCarta.Text.ToUpper()
            .CategoriaNovedad = New Reglas.CRMCategoriasNovedades().GetUno(1)
            .EstadoNovedad = New Reglas.CRMEstadosNovedades().GetUno(100)
            .PrioridadNovedad = New Reglas.CRMPrioridadesNovedades().GetUno(100)
            .MedioComunicacionNovedad = New Reglas.CRMMediosComunicacionesNovedades().GetUno(1)
            .UsuarioAsignado = New Reglas.Usuarios().GetUno(Eniac.Entidades.Usuario.Actual.Nombre)

         End With

         SqlCRM.Insertar(CRM)


         'mandar al preview
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Cartas.rdlc", "DSReportes_Cartas", dt, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Me.cmbTipoCarta.Text
         frmImprime.ShowDialog()
      End If
   End Sub

   Private Sub CancelarCarta()
      'grabar todas las cartas en las tablas
      Dim idCarta As Integer = Int32.Parse(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.IdCarta.ToString()).ToString())
      Dim idCartaProxima As Integer
      If Not String.IsNullOrEmpty(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.ProximaCarta.ToString()).ToString()) Then
         idCartaProxima = Int32.Parse(DirectCast(Me.cmbTipoCarta.SelectedItem, DataRowView).Row(Entidades.Carta.Columnas.ProximaCarta.ToString()).ToString())
      End If

      Dim reg As Reglas.Cartas = New Reglas.Cartas()
      reg.CancelarCarta(Me._dato.Cliente.IdCliente, idCarta, Eniac.Entidades.Usuario.Actual.Nombre, idCartaProxima)
      MessageBox.Show("La carta ha sido cancelada.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Me.ReCargarDatos()
   End Sub

   Private Sub cmbTipoCarta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoCarta.SelectedIndexChanged
      Try
         Me.VerificarDatos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub VerificarDatos()
      'habilito todos los botones
      Me.tsbEmitirCarta.Enabled = True
      Me.tsbReimprimir.Enabled = True
      Me.tsbCancelarCarta.Enabled = True

      If IsNumeric(Me.cmbTipoCarta.SelectedValue.ToString()) Then
         Select Case Integer.Parse(Me.cmbTipoCarta.SelectedValue.ToString())
            Case 80 'Carta 1
               If Me._dato.FechaCarta1 = Nothing Then
                  Me.tsbReimprimir.Enabled = False
                  Me.tsbCancelarCarta.Enabled = False
               Else
                  Me.tsbEmitirCarta.Enabled = False
               End If
               'Case "51" 'Carta 2
               '   If Me._dato.Deudas(0).FechaCarta2 = Nothing Then
               '      If Me._dato.Deudas(0).FechaCarta1 <> Nothing Then
               '         Me.tsbReimprimir.Enabled = False
               '         Me.tsbCancelarCarta.Enabled = False
               '      Else
               '         Me.tsbEmitirCarta.Enabled = False
               '         Me.tsbReimprimir.Enabled = False
               '         Me.tsbCancelarCarta.Enabled = False
               '      End If
               '   Else
               'Me.tsbEmitirCarta.Enabled = False
               'End If
            Case "82" 'Carta Liq. Parcial
               If Me._dato.FechaLiquidacion = Nothing Then
                  Me.tsbReimprimir.Enabled = False
                  Me.tsbCancelarCarta.Enabled = False
               Else
                  Me.tsbEmitirCarta.Enabled = False
               End If

            Case Else
               Me.tsbEmitirCarta.Enabled = False
         End Select

      End If

   End Sub

   Private Sub ReCargarDatos()
      'Me._dato.Deudas = New Reglas.InmobiliarioDeuda().GetDeUnDato(Me._dato.Partida, Me._dato.IdTipoImpuesto, Me._dato.IdMunicipio)
      'Me._dato.Gestiones = New Reglas.GestionesInmobiliario().GetDeUnDato(Me._dato.Partida, Me._dato.IdTipoImpuesto, Me._dato.IdMunicipio)
      'Me._dato.Alertas = New Reglas.AlertasInmobiliario().GetDeUnaCuenta(Me._dato.Partida, Me._dato.IdTipoImpuesto, Me._dato.IdMunicipio)
   End Sub

End Class