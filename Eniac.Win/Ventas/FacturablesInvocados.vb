Public Class FacturablesInvocados

#Region "Campos"

   Private _idSucursal As Integer
   Private _idTipoComprobante As String
   Private _letra As String
   Private _centroEmisor As Integer
   Private _numeroComprobante As Long
   Private _titInvocados As Dictionary(Of String, String)
   Private _titInvocadores As Dictionary(Of String, String)

#End Region

#Region "Constructores"

   <Obsolete("Pasar la sucursal del registro.")>
   Public Sub New(idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Me.New(actual.Sucursal.Id, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Sub

   Public Sub New(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      InitializeComponent()

      _idSucursal = idSucursal
      _idTipoComprobante = idTipoComprobante
      _letra = letra
      _centroEmisor = centroEmisor
      _numeroComprobante = numeroComprobante

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)
      TryCatched(Sub()
                    _titInvocados = GetColumnasVisiblesGrilla(ugDetalle)
                    _titInvocadores = GetColumnasVisiblesGrilla(ugDetalleInvocadores)
                    ugDetalle.AgregarTotalesSuma({"ImporteNeto", "Kilos"})
                    ugDetalleInvocadores.AgregarTotalesSuma({"ImporteNeto", "Kilos"})

                    CargaGrillaDetalle()
                 End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.Escape Then
         Close()
         Return True
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

#Region "Eventos"

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaGrillaDetalle()
      Dim rInvocados = New Reglas.VentasInvocados()
      Dim dtTuple = rInvocados.GetInvocadosInvocadores(_idSucursal, _idTipoComprobante, _letra, _centroEmisor, _numeroComprobante)

      If dtTuple.Item1.Rows.Count > 0 Then
         Dim drVenta = dtTuple.Item1.Rows(0)
         txtTipoComprobante.Text = drVenta.Field(Of String)("DescripcionTipoComprobante")
         txtLetra.Text = _letra
         txtCentroEmisor.Text = _centroEmisor.ToString(txtCentroEmisor.Formato)
         txtNumeroComprobante.Text = _numeroComprobante.ToString(txtNumeroComprobante.Formato)

         txtFechaEmisión.Text = drVenta.Field(Of Date)(Entidades.Venta.Columnas.Fecha.ToString()).ToString("dd/MM/yyyy")
         txtCodigoCliente.Text = drVenta.Field(Of Long)(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString()
         txtNombreCliente.Text = drVenta.Field(Of String)(Entidades.Cliente.Columnas.NombreCliente.ToString())
      End If

      ugDetalle.DataSource = dtTuple.Item2
      ugDetalleInvocadores.DataSource = dtTuple.Item3

      AjustarColumnasGrilla(ugDetalle, _titInvocados)
      AjustarColumnasGrilla(ugDetalleInvocadores, _titInvocadores)

      tssRegistros.Text = String.Format("Invocados: {0} Registros / Invocadores: {1} Registros", ugDetalle.Count(), ugDetalleInvocadores.Count())
   End Sub

#End Region

End Class