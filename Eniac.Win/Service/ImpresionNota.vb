Imports System.IO
Imports System.Timers

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class ImpresionNota

#Region "Campos"

   Private _nota As Eniac.Entidades.RecepcionNota

#End Region

#Region "Constructores"

   Public Sub New(ByVal Nota As Eniac.Entidades.RecepcionNota)

      Me._nota = Nota

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ImprimirNotaRecepcion()

      'Supongo que tiene que existe un registro para enviarlo como parametro al Visor.
      Dim dtFic As Eniac.Win.SistemaDataSet.VentasProductosDataTable = New Eniac.Win.SistemaDataSet.VentasProductosDataTable()
      Dim drF As Eniac.Win.SistemaDataSet.VentasProductosRow
      drF = dtFic.NewVentasProductosRow()
      drF.IdSucursal = Me._nota.IdSucursal

      If Me._nota.Venta.TipoComprobante IsNot Nothing Then
         drF.IdTipoComprobante = Me._nota.Venta.TipoComprobante.IdTipoComprobante
         drF.Letra = Me._nota.Venta.LetraComprobante
         drF.CentroEmisor = Me._nota.Venta.CentroEmisor
         drF.NumeroComprobante = Me._nota.Venta.NumeroComprobante
      Else
         drF.IdTipoComprobante = ""
         drF.Letra = ""
         drF.CentroEmisor = 0
         drF.NumeroComprobante = 0
      End If

      drF.IdProducto = Me._nota.Producto.IdProducto
      drF.NombreProducto = Me._nota.Producto.NombreProducto
      drF.Cantidad = Me._nota.CantidadProductos
      drF.Precio = Me._nota.CostoReparacion
      dtFic.AddVentasProductosRow(drF)


      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NroNota", Me._nota.NroNota.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TelefonoSucursal", actual.Sucursal.Telefono))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("RedesSociales", actual.Sucursal.RedesSociales))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("MailEmpresa", actual.Sucursal.Correo))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Fecha", Me._nota.FechaNota.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreYApellido", Me._nota.Cliente.NombreCliente))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("TipoYNroDocumento", Me._nota.Cliente.CodigoCliente.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Direccion", Me._nota.Cliente.Direccion))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Localidad", Me._nota.Cliente.IdLocalidad.ToString())) 'Poner Nombre
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Telefono", Me._nota.Cliente.Telefono & " " & Me._nota.Cliente.Celular))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Email", Me._nota.Cliente.CorreoElectronico))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("CodigoProducto", Me._nota.Producto.IdProducto))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreProducto", Me._nota.Producto.NombreProducto))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Cantidad", Me._nota.CantidadProductos.ToString()))

      If Me._nota.Venta.TipoComprobante IsNot Nothing Then
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", Me._nota.Venta.Fecha.ToString("dd/MM/yyyy") & " - " & Me._nota.Venta.TipoComprobanteDescripcion & " '" & Me._nota.Venta.LetraComprobante & "' " & Me._nota.Venta.CentroEmisor.ToString("0000") & "-" & Me._nota.Venta.NumeroComprobante.ToString("00000000")))
      Else
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Comprobante", "SIN FACTURA RELACIONADA"))
      End If
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Costo", Me._nota.CostoReparacion.ToString()))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Defecto", Me._nota.DefectoProducto))
      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("Observacion", Me._nota.Observacion))

      Dim frmImprime As VisorReportes

      If Me._nota.Estado.Reporte <> "" Then
         frmImprime = New VisorReportes(Me._nota.Estado.Reporte, "SistemaDataSet_FichasProductos", Nothing, parm, 1) '# 1 = Cantidad Copias
      Else
         If Eniac.Win.Publicos.ServiceImprime1copiaNR Then
            frmImprime = New VisorReportes("Eniac.Win.NotaRecepcion.rdlc", "SistemaDataSet_FichasProductos", Nothing, parm, 1) '# 1 = Cantidad Copias
         Else
            frmImprime = New VisorReportes("Eniac.Win.NotaRecepcion2.rdlc", "SistemaDataSet_FichasProductos", Nothing, parm, 1) '# 1 = Cantidad Copias
         End If
      End If

      frmImprime.Text = "Nota Recepción"
      frmImprime.ShowDialog()

   End Sub


#End Region

#Region "Metodos Privados"

#End Region

End Class
