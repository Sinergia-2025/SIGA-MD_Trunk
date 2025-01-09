Option Strict On
Option Explicit On
Partial Class Clientes

   Public Function GrabarValoracionEstrellasMasiva(dt As DataTable) As Integer
      Return EjecutaConTransaccion(Function() _GrabarValoracionEstrellasMasiva(dt))
   End Function
   Public Function _GrabarValoracionEstrellasMasiva(dt As DataTable) As Integer
      Dim sql = New SqlServer.Clientes(da, Entidades.Cliente.ModoClienteProspecto.Cliente)
      Dim rAudit = New Reglas.Auditorias(da)
      Dim idUsuario = actual.Nombre
      Dim idClienteNombreColumna = String.Format("Id{0}", ModoClienteProspecto.ToString())
      Dim valoracionClienteNombreColumna = String.Format("Valorizacion{0}", ModoClienteProspecto.ToString())
      Dim clienteNombreTabla = String.Format("{0}s", ModoClienteProspecto.ToString())

      Dim dtModified = dt.GetChanges(DataRowState.Modified)
      If dtModified IsNot Nothing Then
         For Each dr In dtModified.Select()
            Dim idCliente = dr.Field(Of Long)(idClienteNombreColumna)

            sql.Clientes_U_Estrellas(idCliente,
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionFacturacionMensual.ToString()),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCoeficienteFacturacion.ToString()),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionFacturacion.ToString()),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionImporteAdeudado.ToString()),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionCoeficienteDeuda.ToString()),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionDeuda.ToString()),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionProyecto.ToString()),
                                     dr.Field(Of Decimal)(valoracionClienteNombreColumna),
                                     dr.Field(Of Decimal)(Entidades.Cliente.Columnas.ValorizacionEstrellas.ToString()))

            rAudit.Insertar(clienteNombreTabla, Entidades.OperacionesAuditorias.Modificacion, idUsuario,
                            String.Format("{0} = {1}", idClienteNombreColumna, idCliente), conMilisegundos:=False)
         Next
         Return dtModified.Rows.Count
      Else
         Return 0
      End If
   End Function

   Private _puedeVerDetalleValoracionEstrellas As Boolean
   Private _recalculaValoracionesEstrellas As Boolean

   Friend Sub ReCalcularValoraciones(idCliente As Long)
      If Not _recalculaValoracionesEstrellas Then Exit Sub
      EjecutaReCalcularValoracionFacturacion(idCliente)
      EjecutaReCalcularValoracionDeuda(idCliente)
      EjecutaReCalcularValoracionCliente(idCliente)
      EjecutaReCalcularValoracionEstrellas()
   End Sub
   Friend Sub ReCalcularValoracionFacturacion(idCliente As Long)
      If Not _recalculaValoracionesEstrellas Then Exit Sub
      EjecutaReCalcularValoracionFacturacion(idCliente)
      EjecutaReCalcularValoracionCliente(idCliente)
      EjecutaReCalcularValoracionEstrellas()
   End Sub
   Friend Sub ReCalcularValoracionDeuda(idCliente As Long)
      If Not _recalculaValoracionesEstrellas Then Exit Sub
      EjecutaReCalcularValoracionDeuda(idCliente)
      EjecutaReCalcularValoracionCliente(idCliente)
      EjecutaReCalcularValoracionEstrellas()
   End Sub
   Friend Sub ReCalcularValoracionCliente(idCliente As Long)
      If Not _recalculaValoracionesEstrellas Then Exit Sub
      EjecutaReCalcularValoracionCliente(idCliente)
      EjecutaReCalcularValoracionEstrellas()
   End Sub
   Friend Sub ReCalcularValoracionEstrellas()
      If Not _recalculaValoracionesEstrellas Then Exit Sub
      EjecutaReCalcularValoracionEstrellas()
   End Sub



   Private Sub EjecutaReCalcularValoracionFacturacion(idCliente As Long)
      'Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      'sql.ReCalcularValoracionFacturacion(idCliente)
   End Sub
   Private Sub EjecutaReCalcularValoracionDeuda(idCliente As Long)
      'Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      'sql.ReCalcularValoracionDeuda(idCliente)
   End Sub
   Private Sub EjecutaReCalcularValoracionCliente(idCliente As Long)
      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      sql.ReCalcularValoracionCliente(idCliente)
   End Sub
   Private Sub EjecutaReCalcularValoracionEstrellas()
      Dim sql As SqlServer.Clientes = New SqlServer.Clientes(da, ModoClienteProspecto)
      sql.ReCalcularValoracionEstrellas()
   End Sub

End Class