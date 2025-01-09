'--REQ-31725.- -Informe de Ventas Pirelli-

Public Class InformaVentasPirelli

#Region "Properties"

#End Region

#Region "Eventos"
   Public Sub New()
      InitializeComponent()
      '-- Limpia campos de inicio.- --
      LMP_CamposFiltrados()
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         '-- Inicializa Campos de Filtrado.- --
         LMP_CamposFiltrados()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
      Dim VentasPirelli = New Reglas.VentasPirelli()
      If Not String.IsNullOrEmpty(Reglas.Publicos.InformeVentas.VentasPirelli.VentasPirelliURLBase) Then
         Try
            '-- Proceso de Informe de Ventas.- --
            With VentasPirelli
               '-- Asigno Valores de Rango de Fechas.- --
               .rFechaDesde = dtpDesde.Value
               .rFechaHasta = dtpHasta.Value
               .InformaVentasPirelli()
            End With
            '-- Proceso el Pedido.- --
            If VentasPirelli.EstadoProceso Then
               '-- Informo Exito del Proceso.- --
               ShowMessage("Proceso de Informe de Ventas Pirelli Exitoso !!!" + Chr(13) + VentasPirelli.MensajProceso.ToString())
            Else
               '-- Informo Exito del Proceso.- --
               ShowMessage(VentasPirelli.MensajErrores.ToString())
            End If
         Catch ex As Exception
            ShowError(ex)
         End Try

      End If
   End Sub

#End Region

#Region "Métodos"
   '-- Limpia o Inicializa los campos de Filtrado.- --
   Public Sub LMP_CamposFiltrados()
      Dim FechaTemp As Date

      If Date.Today.Day <= 15 Then
         FechaTemp = Date.Today.PrimerDiaMes().AddMonths(-1)
      Else
         FechaTemp = Date.Today.PrimerDiaMes()
      End If
      '-- Asigna Fecha Desde.- --
      dtpDesde.Value = FechaTemp
      '-- Asigna Fecha Hasta.- --
      dtpHasta.Value = Date.Today
   End Sub

#End Region
End Class