Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Public Class IngresoDatosReparto
   Private _publicos As Publicos
   Private _Transportista As Entidades.Transportista
   Private _NroReparto As Integer
   Private _FechaEnvio As Date

#Region "Propiedades"

   Public ReadOnly Property Transportista() As Entidades.Transportista
      Get
         Return Me._Transportista
      End Get
   End Property

   Public ReadOnly Property NroReparto() As Integer
      Get
         Return Me._NroReparto
      End Get
   End Property

   Public ReadOnly Property FechaEnvio() As Date
      Get
         Return Me._FechaEnvio
      End Get
   End Property

#End Region


   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()
         Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
         Me._NroReparto = oVentas.GetUltNumeroReparto() + 1
         Me.txtNumero.Text = Me._NroReparto.ToString()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub


   Private Sub bscTransportista_BuscadorClick() Handles bscTransportista.BuscadorClick
      Try
         Me._publicos.PreparaGrillaTransportistas(Me.bscTransportista)
         Dim oTransportistas As Reglas.Transportistas = New Reglas.Transportistas
         Me.bscTransportista.Datos = oTransportistas.GetFiltradoPorNombre(Me.bscTransportista.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub bscTransportista_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscTransportista.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosTransportista(e.FilaDevuelta)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub CargarDatosTransportista(ByVal dr As DataGridViewRow)
      Me.bscTransportista.Text = dr.Cells("NombreTransportista").Value.ToString()
      Dim Transp As Reglas.Transportistas = New Reglas.Transportistas()
      Me._Transportista = Transp.GetUno(Long.Parse(dr.Cells("IdTransportista").Value.ToString()))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub


   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Me._FechaEnvio = dtpDesde.Value
         DialogResult = Windows.Forms.DialogResult.OK
         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub
End Class