Public Class ImpresionTurnos

   Public Sub New()
      Parametros = New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
   End Sub

   Public Sub ImprimeTurno(turno As Entidades.TurnoCalendario)
      ArmarReporteTurnos(turno)

      Using frmImprime = New VisorReportes(ReporteNombre,
                                           ReporteDataSource, Nothing,
                                           ReporteDataSource2, Nothing,
                                           ReporteDataSource3, Nothing,
                                           ReporteDataSource4, Nothing,
                                           Parametros, ReporteEmbebido, CantidadCopias)
         frmImprime.Text = "Turnos"
         frmImprime.rvReporte.DocumentMapCollapsed = True
         frmImprime.Size = New Size(780, 600)
         frmImprime.StartPosition = FormStartPosition.CenterScreen
         frmImprime.ShowDialog()
      End Using
   End Sub

   Private Sub ArmarReporteTurnos(turnos As Entidades.TurnoCalendario)

      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreFantasia))
      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("FechaTurno", turnos.FechaDesde.ToString()))
      '-- Trae los Datos del Cliente.- ---------------------------------------------------------------------------------
      Dim rCliente = New Reglas.Clientes()
      Dim eCliente = rCliente.GetUno(turnos.IdCliente)
      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cliente", eCliente.NombreCliente))
      If Not String.IsNullOrEmpty(eCliente.Telefono) Then
         Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", eCliente.Telefono))
      Else
         Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", "-"))
      End If
      '-----------------------------------------------------------------------------------------------------------------
      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Patente", turnos.IdPatenteVehiculo))
      '-- Trae los Datos del Producto.- --------------------------------------------------------------------------------
      Dim rProducto = New Reglas.Productos()
      Dim eProducto = rProducto.GetUno(turnos.IdProducto, accion:=Reglas.Base.AccionesSiNoExisteRegistro.Vacio)
      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Servicio", eProducto.NombreProducto))
      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Importe", turnos.Precio.ToString()))
      '-----------------------------------------------------------------------------------------------------------------
      Parametros.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", turnos.Observaciones))
      '-----------------------------------------------------------------------------------------------------------------

      ReporteDataSource = String.Empty
      ReporteDataSource2 = String.Empty
      ReporteDataSource3 = String.Empty
      ReporteDataSource4 = String.Empty

      ReporteNombre = "Eniac.Win.ImpresionTurnos.rdlc"
      ReporteEmbebido = True

      Dim custName = String.Format("Reportes\{0}_ImpresionTurnos.rdlc", Reglas.Publicos.CodigoClienteSinergia)
      If IO.File.Exists(custName) Then
         ReporteEmbebido = False
         ReporteNombre = custName
      End If

      CantidadCopias = 1

   End Sub

   Private Property _ConfigImprimir As ConfiguracionImprimir
   Public Property ConfigImprimir As ConfiguracionImprimir
      Get
         If _ConfigImprimir Is Nothing Then
            _ConfigImprimir = New ConfiguracionImprimir(0, 0)
         End If
         Return _ConfigImprimir
      End Get
      Set(value As ConfiguracionImprimir)
         _ConfigImprimir = value
      End Set
   End Property
   Private _cantidadCopias As Integer
   Public Property CantidadCopias() As Integer
      Get
         If _cantidadCopias = 0 Then
            Return 1
         Else
            Return _cantidadCopias
         End If
      End Get
      Set(ByVal value As Integer)
         _cantidadCopias = value
      End Set
   End Property

   Public Property ReporteNombre() As String
   Public Property ReporteEmbebido As Boolean
   Public Property Titulo() As String
   Public Property Parametros() As List(Of Microsoft.Reporting.WinForms.ReportParameter)
   Public Property ReporteDataSource() As String
   Public Property ReporteDataSource2() As String
   Public Property ReporteDataSource3() As String
   Public Property ReporteDataSource4() As String

End Class