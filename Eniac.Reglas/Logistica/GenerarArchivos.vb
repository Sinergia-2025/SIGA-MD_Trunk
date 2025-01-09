Imports actual = Eniac.Entidades.Usuario.Actual
Public Class GenerarArchivos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "GenerarArchivos"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

   Public Function GetRutasArchivo(IdVendedor As Integer, ByVal ruta As Integer) As DataTable
      Return New SqlServer.GenerarArchivos(Me.da).GetRutasArchivo(IdVendedor, ruta)
   End Function

   Public Function GetRutasSeleccionadas(IdVendedor As Integer, ByVal ruta As Integer) As DataTable
      Return New SqlServer.GenerarArchivos(Me.da).getRutasSeleccionadas(IdVendedor, ruta)
   End Function

   Public Function GetArticulosArchivo(ByVal sucursal As Integer, IdVendedor As Integer,
                                       exportaConIVA As Boolean, ByVal idListaPrecios As Integer) As DataTable
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      If idListaPrecios = -1 Then
         idListaPrecios = Eniac.Reglas.Publicos.ListaPreciosPredeterminada
      End If
      Return New SqlServer.GenerarArchivos(Me.da).GetArticulosArchivo(sucursal, IdVendedor, blnPreciosConIVA, exportaConIVA, idListaPrecios, Reglas.Publicos.Logistica.IncluirEsCambiableEsBonificable)
   End Function

   Public Function GetRubrosArchivo(ByVal sucursal As Integer, IdVendedor As Integer) As DataTable
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Return New SqlServer.GenerarArchivos(Me.da).GetRubrosArchivo(sucursal, IdVendedor, blnPreciosConIVA)
   End Function

   Public Function GetClientesArchivo(IdVendedor As Integer, idRuta As Integer) As DataTable
      Return New SqlServer.GenerarArchivos(Me.da).GetClientesArchivos(IdVendedor, idRuta)
   End Function

   Public Function GetRutasPreventista(IdVendedor As Integer) As DataTable
      Return New SqlServer.MovilRutas(da).MovilRutas_GA(IdVendedor)
   End Function

   Public Function GetHistoricosArchivo(IdVendedor As Integer) As DataTable

      Dim dtPrincipal As DataTable = New SqlServer.GenerarArchivos(Me.da).GetHistoricosArchivos(IdVendedor)
      Dim dtAux As DataTable

      For Each filaPpal As DataRow In dtPrincipal.Rows

         'para cada fila busco las ultimas 4 cantidades de ventas.
         dtAux = New SqlServer.GenerarArchivos(Me.da).getAuxHistoricos(IdVendedor, filaPpal)

         'paso cantidades a la tabla principal.
         For i As Integer = 1 To dtAux.Rows.Count
            filaPpal("cant" & i.ToString) = dtAux.Rows(i - 1)("cantidad")
         Next

      Next

      Return dtPrincipal ' New SqlServer.GenerarArchivos(Me.da).GetHistoricosArchivos(preventista)

   End Function

   Public Function GetConfiguracionesArchivo(idRuta As Integer) As DataTable
      Dim dt As DataTable = New DataTable()
      dt.Columns.Add("IdParametro", GetType(String))
      dt.Columns.Add("ValorParametro", GetType(String))

      Try
         da.OpenConection()

         dt.Rows.Add("1", Publicos.ParametrosSiMovil.CorreoMovil1(da).ToString().ToLower())
         dt.Rows.Add("2", Publicos.ParametrosSiMovil.CorreoMovil2(da).ToString().ToLower())
         dt.Rows.Add("3", Publicos.ParametrosSiMovil.CorreoMovil3(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.buscar_cliente.ToString(), Publicos.ParametrosSiMovil.BusquedaClientes(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.orden_producto.ToString(), Publicos.ParametrosSiMovil.OrdenarProductos(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.fecha_exportacion.ToString(), Publicos.ParametrosSiMovil.UsarFechaExportacion(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.ocultar_envio_mail.ToString(), Publicos.ParametrosSiMovil.OcultarCompartirVentasPorMail(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.solicita_cierre.ToString(), Publicos.ParametrosSiMovil.SolicitaCierrePedidos(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.plazo_entrega_dv.ToString(), 1)           'No hay plazo de entrega en live
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.porc_max_decuento.ToString(), 99999999)   'En live no tenemos tope de descuento
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.porc_max_recargo.ToString(), 99999999)    'En live no tenemos tope de recargo
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.envia_mail_cliente.ToString(), Publicos.ParametrosSiMovil.EnviaMailCliente(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.envia_mail_empresa.ToString(), Publicos.ParametrosSiMovil.EnviaMailEmpresa(da).ToString().ToLower())
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.ocultar_resumen_promedio.ToString(), Publicos.ParametrosSiMovil.OcultarResumenPromedio(da).ToString().ToLower())

         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.plazo_entrega_pedido.ToString(), Boolean.FalseString.ToLower())   'No hay plazo de entrega en live
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.plazo_entrega_linea.ToString(), Boolean.FalseString.ToLower())    'No hay plazo de entrega en live

         Dim ruta As Entidades.MovilRuta = New MovilRutas(da).GetUno(idRuta)
         dt.Rows.Add(Entidades.GenerarArchivo.PreferenciasKeys.puede_modificar_precios.ToString(), ruta.PuedeModificarPrecio.ToString().ToLower())

      Finally
         da.CloseConection()
      End Try

      Return dt
   End Function

   Public Function GetListasDePreciosArchivo(idListaPreciosCol As Integer(), exportaConIVA As Boolean) As DataTable
      Dim blnPreciosConIVA As Boolean = Publicos.PreciosConIVA
      Return New SqlServer.GenerarArchivos(da).GetListasDePreciosArchivo(idListaPreciosCol, actual.Sucursal.Id, exportaConIVA, blnPreciosConIVA)
   End Function

End Class
