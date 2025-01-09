Imports System.Web.Script.Serialization
Imports Eniac.Reglas.ServiciosRest.TiendasWeb.SincronizacionTiendaNube

Namespace ServiciosRest.TiendasWeb
   Public Class ImportacionPedidosTiendasWeb
      Inherits Base

#Region "Properties"
      Public Event Avance(sender As Object, e As ImportacionPedidosTiendasWebEventArgs)
      Public Event Estado(sender As Object, e As SincronizacionTiendaWebEstadoEventArgs)
      Public Event ProcesoFinalizado(sender As Object, e As ProcesoFinalizadoEventArgs)

      Private _mensajeError As StringBuilder
      Private _clientesImportados As Integer
      Private _TipoTiendaWeb As Entidades.TiendasWeb
#End Region

#Region "Constructors"
      Private Sub New(accesoDatos As Datos.DataAccess)
         da = accesoDatos
      End Sub
      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub
#End Region

#Region "Methods"

      Private Sub GrabarMensajeError(id As String, sistemaDestino As String, err As String)
         My.Application.Log.WriteEntry(String.Format("SubidaTiendasWeb.Ejecutar - ERROR: {0}", err), TraceEventType.Information)

         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)
         rPTW.GrabarMensajeError(id, sistemaDestino, err)
      End Sub

      Private Function ValidarImportacion() As Boolean

         Select Case _TipoTiendaWeb
            Case Entidades.TiendasWeb.TIENDANUBE
               '# Valido la forma de pago del pedido
               If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosFormaDePago = -1 Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurada la Forma de Pago para la importación de Pedidos Tienda Nube. Debe configurarla para continuar.")
               End If

               If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosCriticidad = String.Empty Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurada la Criticadad para la importación de Pedidos Tienda Nube. Debe configurarla para continuar.")
               End If

               If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosTipoComprobante = String.Empty Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurado el Tipo de Comprobante para la importación de Pedidos Tienda Nube. Debe configurarlo para continuar.")
               End If

               Dim comprobanteXDefecto As String = "PEDIDOTN"
               If New Reglas.TiposComprobantes().GetUno(comprobanteXDefecto) Is Nothing Then
                  Throw New Exception(String.Format("ATENCIÓN: No se encuentra el comprobante por defecto para Tienda Nube ({0}). Debe configurarlo para continuar.", comprobanteXDefecto))
               End If
            Case Entidades.TiendasWeb.ARBOREA
               '# Valido la forma de pago del pedido
               If Publicos.TiendasWeb.Arborea.ArboreaPedidosFormaDePago = -1 Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurada la Forma de Pago para la importación de Pedidos Arborea. Debe configurarla para continuar.")
               End If

               If Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosCriticidad = String.Empty Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurada la Criticadad para la importación de Pedidos Arborea. Debe configurarla para continuar.")
               End If

               If Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosTipoComprobante = String.Empty Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurado el Tipo de Comprobante para la importación de Pedidos Arborea. Debe configurarlo para continuar.")
               End If

               Dim comprobanteXDefecto As String = "PEDIDOWEB"
               If New Reglas.TiposComprobantes().GetUno(comprobanteXDefecto) Is Nothing Then
                  Throw New Exception(String.Format("ATENCIÓN: No se encuentra el comprobante por defecto para Arborea ({0}). Debe configurarlo para continuar.", comprobanteXDefecto))
               End If

            Case Entidades.TiendasWeb.MERCADOLIBRE
               '# Valido la forma de pago del pedido
               If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosFormaDePago = -1 Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurada la Forma de Pago para la importación de Pedidos Mercado Libre. Debe configurarla para continuar.")
               End If

               If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosCriticidad = String.Empty Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurada la Criticadad para la importación de Pedidos Mercado Libre. Debe configurarla para continuar.")
               End If

               If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosTipoComprobante = String.Empty Then
                  Throw New Exception("ATENCIÓN: No se encuentra configurado el Tipo de Comprobante para la importación de Pedidos Mercado Libre. Debe configurarlo para continuar.")
               End If

               Dim comprobanteXDefecto As String = "PEDIDOWEB"
               If New Reglas.TiposComprobantes().GetUno(comprobanteXDefecto) Is Nothing Then
                  Throw New Exception(String.Format("ATENCIÓN: No se encuentra el comprobante por defecto para Mercado Libre ({0}). Debe configurarlo para continuar.", comprobanteXDefecto))
               End If

         End Select

         Return True
      End Function

      Private Sub TriggerEvent(tienda As Entidades.TiendasWeb,
                               estado As SincroTiendaWebEstados,
                               verb As SincroTiendaWebMetodos,
                               totalRegistros As Integer,
                               nroRegistroSubiendo As Integer,
                               queEstoySubiendo As String)
         RaiseEvent estado(Me, New SincronizacionTiendaWebEstadoEventArgs(tienda, estado, verb, totalRegistros, nroRegistroSubiendo, queEstoySubiendo, 0, 0))
      End Sub

      Public Sub Importar(sTipoTienda As Entidades.TiendasWeb)
         '-- Proceso Marca la Tienda.- --
         _Importar(Nothing, sTipoTienda)
      End Sub

      Public Sub _Importar(pedidosRecibidos As DataTable, sTipoTienda As Entidades.TiendasWeb)
         '-- Proceso Marca la Tienda.- --
         _TipoTiendaWeb = sTipoTienda
         '# Importo los clientes que no se encuentren cargados en el sistema
         EjecutaConConexion(Sub() _ImportarClientes(pedidosRecibidos))
         '---------------------------------------------
         '# Importo los pedidos 
         EjecutaConConexion(Sub() ImportarPedidos(pedidosRecibidos))
         '---------------------------------------------
      End Sub

      Private Sub _ImportarClientes(pedidosRecibidos As DataTable)
         '--------------------------
         RaiseEvent Avance(Me, New ImportacionPedidosTiendasWebEventArgs("Obteniendo información de Nuevos Clientes..."))
         '--------------------------

         _clientesImportados = 0

         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)
         Dim rClientes As Reglas.Clientes = New Reglas.Clientes(da)
         Dim eCliente As Entidades.Cliente = Nothing
         Dim rIdCliente As String = ""

         '# De los nuevos pedidos que tengo PENDIENTES/ERROR de importar, busco los clientes que no se encuentren agregados en el sistema para importarlos
         Dim count As Integer = 0
         Dim importados As Integer = 0
         Dim actualizados As Integer = 0
         Dim dt As DataTable

         If pedidosRecibidos IsNot Nothing AndAlso pedidosRecibidos.Rows.Count > 0 Then
            dt = pedidosRecibidos
         Else
            dt = rPTW.GetPedidosAImportar(_TipoTiendaWeb.ToString(), {"PENDIENTE", "ERROR"}, Nothing, desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Nothing)
         End If

         '--------------------------
         If dt.Rows.Count > 0 Then
            RaiseEvent Avance(Me, New ImportacionPedidosTiendasWebEventArgs(String.Format("Importando Nuevos Clientes...", dt.Rows.Count, If(dt.Rows.Count = 1, Nothing, "s"))))
            My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - {0} Nuevos Clientes por Importar/Actualizar.", dt.Rows.Count, _TipoTiendaWeb), TraceEventType.Information)
         End If
         '--------------------------
         For Each dr As DataRow In dt.Rows
            _mensajeError = New StringBuilder

            count += 1

            Select Case _TipoTiendaWeb
               Case Entidades.TiendasWeb.TIENDANUBE
                  rIdCliente = dr(Entidades.Cliente.Columnas.IdClienteTiendaNube.ToString()).ToString()
               Case Entidades.TiendasWeb.MERCADOLIBRE
                  rIdCliente = dr(Entidades.Cliente.Columnas.IdClienteMercadoLibre.ToString()).ToString()
               Case Entidades.TiendasWeb.ARBOREA
                  rIdCliente = dr(Entidades.Cliente.Columnas.IdClienteArborea.ToString()).ToString()
            End Select
            '# Si el cliente ya se encuentra cargado en el sistema, actualizo algunos de sus datos. Caso contrario lo doy de alta
            If Not String.IsNullOrEmpty(rIdCliente) Then

               eCliente = rClientes.GetClienteTiendaWeb(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdClienteTiendaWeb.ToString()), _TipoTiendaWeb.ToString())
               Me.ActualizarCliente(eCliente, dr)

               '# Controlo que no haya errores
               If String.IsNullOrEmpty(_mensajeError.ToString()) Then
                  My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Actualizando Cliente: {0}.", eCliente.NombreCliente, _TipoTiendaWeb.ToString()), TraceEventType.Information)
                  rClientes.Actualiza(eCliente)
               End If

            Else
               '# Valido que no se haya creado este cliente en alguna corrida previa
               If Not rClientes.ExisteClienteTiendaWeb(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdClienteTiendaWeb.ToString()), _TipoTiendaWeb.ToString()) Then
                  eCliente = Me.CrearCliente(dr)

                  '# Controlo que no haya errores
                  If String.IsNullOrEmpty(_mensajeError.ToString()) Then
                     My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Importando Nuevo Cliente: {0}.", eCliente.NombreCliente, _TipoTiendaWeb.ToString()), TraceEventType.Information)
                     rClientes.Inserta(eCliente, soloTransaccion:=True)

                     '# Luegos de ingresar el cliente, guardo su ID al datatable.
                     Select Case _TipoTiendaWeb
                        Case Entidades.TiendasWeb.TIENDANUBE
                           dr("IdClienteTiendaNube") = eCliente.IdClienteTiendaNube
                        Case Entidades.TiendasWeb.MERCADOLIBRE
                           dr("IdClienteMercadoLibre") = eCliente.IdClienteMercadoLibre
                        Case Entidades.TiendasWeb.ARBOREA
                           dr("IdClienteArborea") = eCliente.IdClienteArborea
                     End Select
                     dr("IdCliente") = eCliente.IdCliente

                     importados += 1
                  End If
               End If
            End If

            TriggerEvent(_TipoTiendaWeb, SincroTiendaWebEstados.Importando, SincroTiendaWebMetodos.GET, importados, importados, "CLIENTES")
         Next
         '--------------------------
         If importados > 0 Then
            RaiseEvent Avance(Me, New ImportacionPedidosTiendasWebEventArgs(String.Format("Se importaron {0} Nuevo{1} Cliente{1} y Actualizaron {2}.", importados, If(importados = 1, Nothing, "s"), actualizados)))
            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - {0} Nuevos Clientes - {1} Actualizados.", importados, actualizados), TraceEventType.Information)
         Else
            RaiseEvent Avance(Me, New ImportacionPedidosTiendasWebEventArgs(String.Format("No existen Nuevos Clientes a Importar.")))
            My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - No se importaron Nuevos Clientes"), TraceEventType.Information)
         End If
         '--------------------------

         _clientesImportados = importados

      End Sub

      Private Function ValidarLocalidad(dr As DataRow) As Integer

         '# Valido que la localidad existe. Primero la busco por CP, luego por nombre.
         Dim rLocalidades As Reglas.Localidades = New Reglas.Localidades
         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)

         If IsNumeric(dr(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal.ToString())) Then
            If rLocalidades.Existe(dr.Field(Of Integer)(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal.ToString())) Then
               Return dr.Field(Of Integer)(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal.ToString())
            ElseIf Not String.IsNullOrEmpty(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Localidad.ToString())) Then
               Dim t As DataTable = rLocalidades.GetPorNombre(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Localidad.ToString()))
               If t.Rows.Count > 0 Then
                  Return t.Rows(0).Field(Of Integer)(Entidades.Localidad.Columnas.IdLocalidad.ToString())
               Else '# Si no existe, grabo un mensaje de error
                  With _mensajeError
                     .AppendFormatLine("*** La localidad del Pedido {0} no se encuentra registrada en el sistema.", dr.Field(Of Long)("Numero"))
                  End With
                  Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
               End If
            Else
               With _mensajeError
                  .AppendFormatLine("*** La localidad del Pedido {0} no se encuentra registrada en el sistema.", dr.Field(Of Long)("Numero"))
               End With
               Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
            End If
         ElseIf Not String.IsNullOrEmpty(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Localidad.ToString())) Then
            Dim t As DataTable = rLocalidades.GetPorNombre(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Localidad.ToString()))
            If t.Rows.Count > 0 Then
               Return t.Rows(0).Field(Of Integer)(Entidades.Localidad.Columnas.IdLocalidad.ToString())
            Else '# Si no existe, grabo un mensaje de error
               With _mensajeError
                  .AppendFormatLine("*** La localidad del Pedido {0} no se encuentra registrada en el sistema.", dr.Field(Of Long)("Numero"))
               End With
               Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
            End If
         Else
            With _mensajeError
               .AppendFormatLine("*** La localidad del Pedido {0} no se encuentra registrada en el sistema.", dr.Field(Of Long)("Numero"))
            End With
            Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
         End If

         Return 0
      End Function

      Private Sub ActualizarCliente(c As Entidades.Cliente, dr As DataRow)
         '--------------------------
         With c
            .Usuario = actual.Nombre
            Select Case _TipoTiendaWeb
               Case Entidades.TiendasWeb.TIENDANUBE
                  If .NroDocCliente = 0 AndAlso Not IsDBNull(dr(Entidades.Cliente.Columnas.IdClienteTiendaNube.ToString())) AndAlso IsNumeric(dr(Entidades.Cliente.Columnas.IdClienteTiendaNube.ToString())) Then
                     .NroDocCliente = dr.Field(Of Long)(Entidades.PedidoTiendaWeb.Columnas.NroDocCliente.ToString())
                  End If
               Case Entidades.TiendasWeb.MERCADOLIBRE
                  If .NroDocCliente = 0 AndAlso Not IsDBNull(dr(Entidades.Cliente.Columnas.IdClienteMercadoLibre.ToString())) AndAlso IsNumeric(dr(Entidades.Cliente.Columnas.IdClienteMercadoLibre.ToString())) Then
                     .NroDocCliente = dr.Field(Of Long)(Entidades.PedidoTiendaWeb.Columnas.NroDocCliente.ToString())
                  End If
            End Select
            .CorreoElectronico = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Email.ToString())
            .Telefono = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Telefono.ToString())
            '--REQ-33935.- Se realiza un Replace para quitar comillas.- ---------------------------------------------------------------------
            .Direccion = Replace(String.Concat(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionCalle.ToString()) + " " +
                                       dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionNumero.ToString()) + " " +
                                       dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Adicional.ToString())).Truncar(100), "'", "")
            .Localidad.IdLocalidad = Me.ValidarLocalidad(dr)
            .IdLocalidad2 = .Localidad.IdLocalidad
            '-- REQ-34152.- -----------------------------------------------------------------------------------------------------------------
            .Observacion = String.Empty
            If Not String.IsNullOrEmpty(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Observacion.ToString())) Then
               .Observacion = Replace(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Observacion.ToString()), "'", "")
            End If
            '--------------------------------------------------------------------------------------------------------------------------------
         End With
         '--------------------------
      End Sub

      Private Function CrearCliente(dr As DataRow) As Entidades.Cliente
         Dim rCategorias As Reglas.Categorias = New Reglas.Categorias
         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)
         Dim cliente As Entidades.Cliente = New Entidades.Cliente
         '--------------------------
         With cliente
            .Usuario = actual.Nombre
            .EsClienteGenerico = True

            Select Case _TipoTiendaWeb
               Case Entidades.TiendasWeb.TIENDANUBE
                  .IdClienteTiendaNube = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdClienteTiendaWeb.ToString())
                  '--------------------------------------------------------------------------------------------------------------
                  If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCategoriaCliente = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Categoría para el cliente.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .IdCategoria = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCategoriaCliente
                  End If

                  If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCategoriaFiscalCliente = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Categoría Fiscal para el cliente.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .CategoriaFiscal.IdCategoriaFiscal = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeCategoriaFiscalCliente
                  End If

                  If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeVendedor = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado un Vendedor.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .Vendedor.IdEmpleado = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeVendedor
                  End If

                  If Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Lista de Precios.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .IdListaPrecios = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios
                  End If
                  '--------------------------------------------------------------------------------------------------------------

               Case Entidades.TiendasWeb.ARBOREA
                  .IdClienteArborea = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdClienteTiendaWeb.ToString())

                  '-- REQ-42380.- -----------------------------------------------------------------------------------------------
                  .CorreoAdministrativo = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Email.ToString())
                  '--------------------------------------------------------------------------------------------------------------

                  If Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaCliente = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Categoría para el cliente.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .IdCategoria = Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaCliente
                  End If

                  If Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaFiscalCliente = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Categoría Fiscal para el cliente.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .CategoriaFiscal.IdCategoriaFiscal = CShort(Reglas.Publicos.TiendasWeb.Arborea.ArboreaCategoriaFiscalCliente)
                  End If

                  If Reglas.Publicos.TiendasWeb.Arborea.ArboreaVendedor = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado un Vendedor.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .Vendedor.IdEmpleado = Reglas.Publicos.TiendasWeb.Arborea.ArboreaVendedor
                     .DadoAltaPor.IdEmpleado = Reglas.Publicos.TiendasWeb.Arborea.ArboreaVendedor
                  End If

                  .MonedaCredito = 1

                  .IdListaPrecios = Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPreciosCLNuevo
                  If Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPreciosCLNuevo = -1 Then
                     .IdListaPrecios = Reglas.Publicos.ListaPreciosPredeterminada
                  End If
                  '--------------------------------------------------------------------------------------------------------------
                  .PublicarEnArborea = True

               Case Entidades.TiendasWeb.MERCADOLIBRE
                  .IdClienteMercadoLibre = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.IdClienteTiendaWeb.ToString())
                  '--------------------------------------------------------------------------------------------------------------
                  If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaCliente = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Categoría para el cliente.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .IdCategoria = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaCliente
                  End If

                  If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaFiscalCliente = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Categoría Fiscal para el cliente.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .CategoriaFiscal.IdCategoriaFiscal = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCategoriaFiscalCliente
                  End If

                  If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreVendedor = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado un Vendedor.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .Vendedor.IdEmpleado = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreVendedor
                  End If

                  If Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios = -1 Then
                     With _mensajeError
                        .AppendLine("No se ha configurado una Lista de Precios.")
                     End With
                     Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), _mensajeError.ToString())
                  Else
                     .IdListaPrecios = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios
                  End If
                  '--------------------------------------------------------------------------------------------------------------
            End Select
            .CodigoCliente = 0
            .NombreCliente = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.NombreClienteTiendaWeb.ToString())
            .Direccion = String.Concat(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionCalle.ToString()) + " " +
                                       dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionNumero.ToString()) + " " +
                                       dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Adicional.ToString())).Truncar(100)

            .Localidad.IdLocalidad = Me.ValidarLocalidad(dr)

            If dr.Field(Of Long?)(Entidades.PedidoTiendaWeb.Columnas.NroDocCliente.ToString()).HasValue Then
               .NroDocCliente = dr.Field(Of Long?)(Entidades.PedidoTiendaWeb.Columnas.NroDocCliente.ToString()).Value
            End If
            .CorreoElectronico = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Email.ToString())
            .Telefono = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Telefono.ToString())

            .ZonaGeografica.IdZonaGeografica = "General" '# Parametrizar?

            .IdSucursal = actual.Sucursal.Id
            .Activo = True
            .FechaNacimiento = Date.Now
            .NroOperacion = 0
            .NombreTrabajo = ""
            .DireccionTrabajo = ""
            .IdLocalidadTrabajo = 0
            .IdLocalidad2 = .Localidad.IdLocalidad
            .TelefonoTrabajo = ""
            .CorreoTrabajo = ""
            .FechaIngresoTrabajo = Date.Now
            .SaldoPendiente = 0
            .TipoDocumentoGarante = ""
            .IdClienteGarante = 0
            .LimiteDeCredito = 0
            .IdSucursalAsociada = 0
            .NombreDeFantasia = ""
            .DescuentoRecargoPorc = 0
            .IngresosBrutos = ""
            .InscriptoIBStaFe = False
            .LocalIB = False
            .ConvMultilateralIB = False
            .NumeroLote = 0
            .PaginaWeb = ""
            .Calle.IdCalle = 1
            .Calle2.IdCalle = 1

            'van fijo por ahora-----------
            .EstadoCliente.IdEstadoCliente = New Reglas.EstadosClientes().GetTop1()
            .Cobrador.IdEmpleado = New Reglas.Empleados().GetTop1Cobrador()
            .TipoCliente.IdTipoCliente = New Reglas.TiposClientes().GetIdTop1()
            '-----------------------

            .UsaArchivoAImprimir2 = False
            .CantidadVisitas = 0
            .HabilitarVisita = True
            .CantidadVisitas = 1
            .NivelAutorizacion = 0

            .ValorizacionFacturacionMensual = 0
            .ValorizacionCoeficienteFacturacion = 0
            .ValorizacionFacturacion = 0
            .ValorizacionImporteAdeudado = 0
            .ValorizacionCoeficienteDeuda = 0
            .ValorizacionDeuda = 0
            .ValorizacionProyecto = 0
            .ValorizacionCliente = 0
            .ValorizacionEstrellas = 0
            .PublicarEnWeb = True
            .IdEstadoCivil = New Reglas.EstadosCiviles().GetPrimerEstado().IdEstadoCivil
         End With
         '--------------------------
         Return cliente
      End Function

      Private Sub ImportarPedidos(pedidosRecibidos As DataTable)
         If Not ValidarImportacion() Then Exit Sub
         '-----------------------------------------
         RaiseEvent Avance(Me, New ImportacionPedidosTiendasWebEventArgs("Obteniendo información de Nuevos Pedidos..."))
         '-----------------------------------------

         Dim rPedidos As Reglas.Pedidos = New Reglas.Pedidos(da)
         Dim rPTW As Reglas.PedidosTiendasWeb = New Reglas.PedidosTiendasWeb(da)
         Dim rPPTW As Reglas.PedidosProductosTiendasWeb = New Reglas.PedidosProductosTiendasWeb(da)
         Dim rProductos As Reglas.Productos = New Reglas.Productos
         Dim rCliente As Reglas.Clientes = New Reglas.Clientes
         Dim rEmpleado As Reglas.Empleados = New Reglas.Empleados
         Dim sVendedor As New Eniac.Entidades.Empleado

         Dim rCaja As New Reglas.CajasNombres
         Dim sCaja As New Entidades.CajaNombre

         Dim rTransportista As New Reglas.Transportistas
         Dim sTransportista As New Entidades.Transportista

         Dim rTComprobantes As Reglas.TiposComprobantes = New Reglas.TiposComprobantes
         Dim rSincronizaciones As Reglas.FechasSincronizaciones = New Reglas.FechasSincronizaciones(da)

         Dim sistemaDestino As String = _TipoTiendaWeb.ToString()
         Dim estadosPedidosAImportar As String() = {"PENDIENTE", "ERROR"}
         Dim estados As String = String.Empty
         For Each w As String In estadosPedidosAImportar
            estados += w + ","
         Next

         My.Application.Log.WriteEntry(String.Format("Bajada{0}.Ejecutar - Importando Pedidos de {0} en estado {1}.", sistemaDestino, estados), TraceEventType.Information)

         '# Si ya recibi los pedidos a importar, utilizo esos, sino busco en la tabla los que tenga pendientes de importar
         Dim dtPedidos As DataTable
         If pedidosRecibidos IsNot Nothing AndAlso pedidosRecibidos.Rows.Count > 0 Then
            dtPedidos = pedidosRecibidos
         Else
            dtPedidos = rPTW.GetPedidosAImportar(sistemaDestino, estadosPedidosAImportar, Nothing, desde:=Nothing, hasta:=Nothing, tipoFechaFiltro:=Nothing)
         End If

         Dim eCliente As Entidades.Cliente
         Dim eProducto As Entidades.Producto
         Dim estadoVisita As Entidades.EstadoVisita = New Reglas.EstadosVisitas().GetTodos()(0)
         Dim ordenCompra As Long = 0

         Dim listaPrecios As Entidades.ListaDePrecios = Nothing
         Dim criticidad As Entidades.CriticidadPedido = Nothing
         Dim eTComprobanteFact As Entidades.TipoComprobante = Nothing
         Dim eFP As Entidades.VentaFormaPago = Nothing
         Dim rComprobante As String = ""

         Select Case _TipoTiendaWeb
            Case Entidades.TiendasWeb.TIENDANUBE
               listaPrecios = New Reglas.ListasDePrecios().GetUno(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeListaDePrecios)
               criticidad = New Reglas.PedidosCriticidades().GetUno(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosCriticidad)
               eTComprobanteFact = New Reglas.TiposComprobantes().GetUno(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosTipoComprobante)
               eFP = New Reglas.VentasFormasPago().GetUna(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubePedidosFormaDePago)
               sVendedor = rEmpleado.GetUno(Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeVendedor)
               sTransportista = Nothing
               sCaja = Nothing
               rComprobante = "PEDIDOTN"
            Case Entidades.TiendasWeb.MERCADOLIBRE
               listaPrecios = New Reglas.ListasDePrecios().GetUno(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreListaDePrecios)
               criticidad = New Reglas.PedidosCriticidades().GetUno(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosCriticidad)
               eTComprobanteFact = New Reglas.TiposComprobantes().GetUno(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosTipoComprobante)
               eFP = New Reglas.VentasFormasPago().GetUna(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibrePedidosFormaDePago)
               '-- Asigan Vendedor.- --
               sVendedor = rEmpleado.GetUno(Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreVendedor)
               '-- Asigna Caja.- --
               sCaja = rCaja.GetUna(actual.Sucursal.IdSucursal, Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreCajaDefault)
               '-- Asigna Transportista.- --
               Dim idTransport = rTransportista.GetCodigoMinimo()
               sTransportista = rTransportista.GetUno(idTransport)
               '-- Asigna Tipo de Comprobante.- --
               rComprobante = "PEDIDOML"
            Case Entidades.TiendasWeb.ARBOREA
               listaPrecios = New Reglas.ListasDePrecios().GetUno(Reglas.Publicos.TiendasWeb.Arborea.ArboreaListasPrecios01)
               criticidad = New Reglas.PedidosCriticidades().GetUno(Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosCriticidad)
               eTComprobanteFact = New Reglas.TiposComprobantes().GetUno(Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosTipoComprobante)
               eFP = New Reglas.VentasFormasPago().GetUna(Reglas.Publicos.TiendasWeb.Arborea.ArboreaPedidosFormaDePago)
               sVendedor = rEmpleado.GetUno(Reglas.Publicos.TiendasWeb.Arborea.ArboreaVendedor)
               sTransportista = Nothing
               sCaja = Nothing
               rComprobante = "PEDIDOARB"
         End Select
         Dim anchoObservacionProducto = New Reglas.Publicos().GetAnchoCampo(Entidades.Pedido.NombreTabla, Entidades.Pedido.Columnas.Observacion.ToString())

         Dim importados As Integer = 0
         Dim conError As Integer = 0
         Dim productoEnvio As Entidades.Producto = Nothing
         Dim rProductoEnvio As String = ""
         Dim modificoPrecioManual As Integer = 0
         '------------------------------------------
         Dim [error] As Boolean
         _mensajeError = New StringBuilder
         For Each dr As DataRow In dtPedidos.Rows

            My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Obteniendo información del Cliente del Pedido {0}.", dr.Field(Of String)("Id"), _TipoTiendaWeb), TraceEventType.Information)
            [error] = False

            If Not IsDBNull(dr("IdCliente")) Then
               eCliente = rCliente.GetUno(dr.Field(Of Long)(Entidades.Cliente.Columnas.IdCliente.ToString()))

               If eCliente IsNot Nothing Then
                  '-- Si el cliente tiene asignado una lista de precios Tomo la asignada al cliente.-
                  listaPrecios = New Reglas.ListasDePrecios().GetUno(eCliente.IdListaPrecios)

                  '# Si el cliente tiene configurado un tipo de comprobante, tomo ese.
                  If Not String.IsNullOrEmpty(eCliente.IdTipoComprobante) Then
                     My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Tomando Tipo de Comprobante del Cliente ({0}).", eCliente.IdTipoComprobante, _TipoTiendaWeb), TraceEventType.Information)
                     eTComprobanteFact = New Reglas.TiposComprobantes().GetUno(eCliente.IdTipoComprobante)
                  End If

                  ''# Observaciones del producto
                  Dim observaciones As String = dr.Field(Of String)("ObservacionesTiendaWeb")
                  '# Por ahora se trunca directamente al ancho del campo observaciones en SIGA
                  observaciones = observaciones.Truncar(anchoObservacionProducto)

                  My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Creando cabecera del Pedido.", eCliente.IdTipoComprobante, _TipoTiendaWeb), TraceEventType.Information)
                  Dim pedido As Entidades.Pedido = rPedidos.CrearPedido(rTComprobantes.GetUno(rComprobante),
                                                                         eCliente,
                                                                         String.Empty,
                                                                         Nothing,
                                                                         dr.Field(Of Long)("Numero"),
                                                                         dr.Field(Of DateTime)("FechaPedido"),
                                                                         sVendedor,
                                                                         sCaja,
                                                                         sTransportista,
                                                                         eFP,
                                                                         eTComprobanteFact,
                                                                         observaciones,
                                                                         estadoVisita,
                                                                         ordenCompra,
                                                                         descuentoRecargoPorc:=Nothing,
                                                                         clienteVinculado:=Nothing,
                                                                         idMoneda:=Entidades.Moneda.Peso, cotizacionDolar:=Nothing, 0, 0)

                  '# IdPedidoTiendaNube
                  Select Case _TipoTiendaWeb
                     Case Entidades.TiendasWeb.TIENDANUBE
                        pedido.IdPedidoTiendaNube = dr.Field(Of String)("Id")
                        rProductoEnvio = Reglas.Publicos.TiendasWeb.TiendaNube.TiendaNubeIdProductoEnvio
                     Case Entidades.TiendasWeb.MERCADOLIBRE
                        pedido.IdPedidoMercadoLibre = dr.Field(Of String)("Id")
                        rProductoEnvio = Reglas.Publicos.TiendasWeb.MercadoLibre.MercadoLibreIdProductoEnvio
                  End Select


                  '# Valido que el Pedido no haya sido registrado anteriormente
                  If Not rPedidos.ExistePedido(actual.Sucursal.Id, pedido.TipoComprobante.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido) Then

                     Dim dtPProductos As DataTable = rPPTW.GetAll(_TipoTiendaWeb.ToString(), dr.Field(Of String)("Id"))
                     For Each row As DataRow In dtPProductos.Rows

                        '# Si el producto no existe o no se encuentra, se graba un mensaje de error en el pedido y se continua con el resto de pedidos a importar
                        eProducto = rProductos.GetProductoTiendaWeb(row.Field(Of String)(Entidades.PedidoProductoTiendaWeb.Columnas.IdProductoTiendaWeb.ToString()), _TipoTiendaWeb.ToString())
                        If eProducto Is Nothing Then
                           My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - No se encontró el Producto con Cód. Tienda Web: {0}", row.Field(Of String)("Id"), _TipoTiendaWeb), TraceEventType.Information)
                           Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), String.Format("*** No se encontró el Producto con Cód. {1}: {0}", row.Field(Of String)("IdProductoTiendaWeb"), _TipoTiendaWeb))
                           _mensajeError.AppendFormatLine(String.Format("*** No se encontró el Producto con Cód. {1}: {0}", row.Field(Of String)("IdProductoTiendaWeb"), _TipoTiendaWeb))
                           [error] = True
                           conError += 1
                        Else

                           My.Application.Log.WriteEntry(String.Format("Subida{2}.Ejecutar - Agregando Producto {1}({0}) al pedido.", row.Field(Of String)("Id"), eProducto.IdProducto, _TipoTiendaWeb), TraceEventType.Information)
                           rPedidos.AgregarLinea(pedido, rPedidos.CrearPedidoProducto(eProducto,
                                                                                      eProducto.NombreProducto,
                                                                                      0D, 0D,
                                                                                      row.Field(Of Decimal)("Precio"), row.Field(Of Decimal)("Cantidad"),
                                                                                      New Reglas.TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.IVA),
                                                                                      Nothing, listaPrecios, criticidad, pedido.Fecha, pedido, 2, Nothing, 0,
                                                                                      eProducto.Tamano,
                                                                                      eProducto.UnidadDeMedida.IdUnidadDeMedida,
                                                                                      eProducto.Moneda,
                                                                                      eProducto.Espmm,
                                                                                      eProducto.EspPulgadas,
                                                                                      eProducto.CodigoSAE,
                                                                                      Nothing, Nothing, 0, 0, 0, Nothing, "", 0,
                                                                                      Entidades.Producto.TiposOperaciones.NORMAL, String.Empty, costo:=0))
                        End If
                     Next
                     '####################################################################################################
                     '# Si el pedido tiene Costo de Envío > $0, se agrega el producto "Envío" parametrizado por defecto  #
                     '####################################################################################################
                     Dim costoEnvio As Decimal? = dr.Field(Of Decimal?)("CostoEnvio")

                     If costoEnvio.HasValue AndAlso costoEnvio.Value > 0 Then

                        '# Primero verifico que se haya configurado correctamente el producto.
                        If String.IsNullOrEmpty(rProductoEnvio) Then
                           My.Application.Log.WriteEntry(String.Format("Bajada{1}.Ejecutar - ERROR: El Pedido {0} tiene Costo de Envío y el Producto para Envío no existe.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                           Me.GrabarMensajeError(dr.Field(Of String)("Id"), dr.Field(Of String)("SistemaDestino"), String.Format("*** El Pedido {0} tiene Costo de Envío y el Producto para Envío no existe.", dr.Field(Of Long)("Numero")))
                           [error] = True
                           conError += 1
                        Else
                           productoEnvio = rProductos.GetUno(rProductoEnvio, accion:=AccionesSiNoExisteRegistro.Nulo)
                           If productoEnvio Is Nothing Then
                              My.Application.Log.WriteEntry(String.Format("Bajada{1}.Ejecutar - ERROR: El Pedido {0} tiene Costo de Envío y el Producto para Envío no existe.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                              Me.GrabarMensajeError(dr.Field(Of String)("Id"), dr.Field(Of String)("SistemaDestino"), String.Format("*** El Pedido {0} tiene Costo de Envío y el Producto para Envío no existe.", dr.Field(Of Long)("Numero")))
                              [error] = True
                              conError += 1
                              Throw New Exception(String.Format("Bajada{1}.Ejecutar - ERROR: El Pedido {0} tiene Costo de Envío y el Producto para Envío no existe.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb))
                           Else

                              '# Grabo el producto envío junto con el resto de los productos de envío
                              My.Application.Log.WriteEntry(String.Format("Bajada{2}.Ejecutar - Agregando Producto {1}({0}) al pedido.", dr.Field(Of Long)("Numero"), productoEnvio.IdProducto, _TipoTiendaWeb), TraceEventType.Information)
                              Dim eProPed = rPedidos.CrearPedidoProducto(productoEnvio,
                                                                                          productoEnvio.NombreProducto,
                                                                                          0D, 0D,
                                                                                          If(costoEnvio.HasValue, costoEnvio.Value, 0D), 1D,
                                                                                          New Reglas.TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.IVA),
                                                                                          Nothing, listaPrecios, criticidad, pedido.Fecha, pedido, 2, Nothing, 0,
                                                                                          productoEnvio.Tamano,
                                                                                          productoEnvio.UnidadDeMedida.IdUnidadDeMedida,
                                                                                          productoEnvio.Moneda,
                                                                                          productoEnvio.Espmm,
                                                                                          productoEnvio.EspPulgadas,
                                                                                          productoEnvio.CodigoSAE,
                                                                                          Nothing, Nothing, 0, 0, 0, Nothing, "", 0,
                                                                                          Entidades.Producto.TiposOperaciones.NORMAL, String.Empty, costo:=0)
                           End If
                        End If
                     End If

                     '###################################################
                     '# Agrego las observaciones detalladas del Pedido  #
                     '###################################################

                     My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Agregando Observaciones detalladas al Pedido {0}.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                     If Not [error] Then

                        '# Como observaciones detalladas voy a agregar el tipo de entrega e información relacionada a él.

                        Dim obsDetallada As Entidades.PedidoObservacion = Nothing
                        Dim listaObs As List(Of Entidades.PedidoObservacion) = New List(Of Entidades.PedidoObservacion)
                        Dim maxLenghtObservaciones As Integer = New Reglas.Publicos().GetAnchoCampo("PedidosObservaciones", "Observacion")

                        Select Case _TipoTiendaWeb
                           Case Entidades.TiendasWeb.TIENDANUBE
                              Dim json = New JavaScriptSerializer().Deserialize(Of Entidades.JSonEntidades.TiendasWeb.TiendaNube.PedidosTN)(dr.Field(Of String)("Json"))

                              If json.shipping_pickup_type = "ship" Then
                                 obsDetallada = New Entidades.PedidoObservacion
                                 Dim direccionEnvio As String() = String.Concat({"Envío a Domicilio: ", json.shipping_address.address, " ", json.shipping_address.number, " ", json.shipping_address.floor, ", ", json.shipping_address.province, " (", json.shipping_option, ")"}).DivideEnPartes(100)
                                 listaObs.AddRange(direccionEnvio.ToList().ConvertAll(Function(s) New Entidades.PedidoObservacion() With {.Observacion = s}))
                              End If
                              If json.shipping_pickup_type = "pickup" Then
                                 obsDetallada = New Entidades.PedidoObservacion
                                 Dim direccionEnvio As String() = String.Concat({json.shipping_option}).DivideEnPartes(100)
                                 listaObs.AddRange(direccionEnvio.ToList().ConvertAll(Function(s) New Entidades.PedidoObservacion() With {.Observacion = s}))
                              End If
                           Case Entidades.TiendasWeb.MERCADOLIBRE
                              '-- Valida el Tipo de Envio.- --
                              If dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.TipoEnvio) = "shipping" Then
                                 obsDetallada = New Entidades.PedidoObservacion
                                 Dim direccionEnvio As String() = String.Concat({"Envío a Domicilio: ",
                                                                             dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionCalle), "",
                                                                             dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionNumero), " ",
                                                                             dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Adicional), ", ",
                                                                             dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Provincia), " (",
                                                                             dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal), ")"}).DivideEnPartes(100)
                                 listaObs.AddRange(direccionEnvio.ToList().ConvertAll(Function(s) New Entidades.PedidoObservacion() With {.Observacion = s}))
                              End If
                        End Select

                        '# Agrego las observaciones al pedido
                        pedido.PedidosObservaciones = listaObs


                        '-- REQ-31636.- - Verifica Codigo Postal.- --
                        Dim rLocalidad = New Reglas.Localidades
                        Dim CodPostal = CInt(dr.Field(Of Integer?)(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal.ToString()))

                        If rLocalidad.Existe(CodPostal) Then
                           '# Seteo la información de facturación al pedido
                           pedido.Direccion = String.Concat(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionCalle.ToString()), " ", dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.DireccionNumero.ToString()))
                           pedido.IdLocalidad = dr.Field(Of Integer?)(Entidades.PedidoTiendaWeb.Columnas.CodigoPostal.ToString())
                           pedido.TipoDocCliente = pedido.Cliente.TipoDocCliente
                           pedido.NroDocCliente = dr.Field(Of Long?)(Entidades.PedidoTiendaWeb.Columnas.NroDocCliente.ToString())
                           pedido.NombreClienteGenerico = dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.NombreClienteTiendaWeb.ToString())
                        Else
                           My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - ERROR: La Localidad configurada para Envío no existe. Pedido {0}.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                           Me.GrabarMensajeError(dr.Field(Of String)("Id"), dr.Field(Of String)("SistemaDestino"), String.Format("***{0}*** La Localidad configurada para Envío no existe.", _TipoTiendaWeb))
                           _mensajeError.AppendFormatLine(String.Format("***{0}*** La Localidad configurada para Envío no existe.", _TipoTiendaWeb))
                           [error] = True
                           conError += 1
                        End If
                     End If
                     '----------------------------------------------

                     '# Create Pedido
                     If Not [error] Then

                        '# Valido que el Pedido no haya sido registrado anteriormente
                        If Not rPedidos.ExistePedido(actual.Sucursal.Id, pedido.TipoComprobante.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido) Then
                           My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Grabando Pedido {0}.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)

                           '-- Limpia el numero de Pedido.- -Dado que el numero de ML es muy grande-
                           If Entidades.TiendasWeb.MERCADOLIBRE = _TipoTiendaWeb Then
                              pedido.NumeroPedido = 0
                           End If

                           '# Controlo la grabación del pedido por posibles errores
                           Try
                              rPedidos.Inserta(pedido)

                              '# Marco el pedido como Procesado
                              '-- REQ-31745.- --
                              Select Case _TipoTiendaWeb
                                 Case Entidades.TiendasWeb.TIENDANUBE
                                    My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Actualizando estado Pedido {0}.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                                    rPTW.ActualizarEstadoPedidoTiendaWeb(pedido.IdPedidoTiendaNube, _TipoTiendaWeb.ToString(), "PROCESADO", quitarMensajeError:=True)
                                 Case Entidades.TiendasWeb.MERCADOLIBRE
                                    My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - Actualizando estado Pedido {0}.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                                    rPTW.ActualizarEstadoPedidoTiendaWeb(pedido.IdPedidoMercadoLibre, _TipoTiendaWeb.ToString(), "PROCESADO", quitarMensajeError:=True)
                              End Select

                              importados += 1
                              Me.TriggerEvent(_TipoTiendaWeb, SincroTiendaWebEstados.Importando, SincroTiendaWebMetodos.GET, importados, importados, "PEDIDOS")
                           Catch ex As Exception
                              My.Application.Log.WriteEntry(String.Format("Subida{2}.Ejecutar - Error en la grabación del Pedido: {0} - {1}", dr.Field(Of Long)("Numero"), ex.Message, _TipoTiendaWeb), TraceEventType.Information)
                              Me.GrabarMensajeError(dr.Field(Of String)(Entidades.PedidoTiendaWeb.Columnas.Id.ToString()), _TipoTiendaWeb.ToString(), String.Format("SubidaTiendaNube.Ejecutar - Error en la grabación del Pedido: {0} - {1}", dr.Field(Of Long)("Numero"), ex.Message))
                              conError += 1
                           End Try

                        End If
                     End If
                  Else
                     My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - ERROR: El Pedido {0} ya se encuentra registrado en el Sistema.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                     Me.GrabarMensajeError(dr.Field(Of String)("Id"), dr.Field(Of String)("SistemaDestino"), String.Format("ERROR: El Pedido {0} ya se encuentra registrado en el Sistema.", dr.Field(Of Long)("Numero")))
                     _mensajeError.AppendFormatLine(String.Format("ERROR: El Pedido {0} ya se encuentra registrado en el Sistema.", dr.Field(Of Long)("Numero")))
                     [error] = True
                     conError += 1
                  End If
               Else
                  My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - ERROR: No se encontró el Cliente del Pedido {0}.", dr.Field(Of Long)("Numero")), TraceEventType.Information)
                  Me.GrabarMensajeError(dr.Field(Of String)("Id"), dr.Field(Of String)("SistemaDestino"), String.Format("ERROR: No se encontró el Cliente del Pedido {0}.", dr.Field(Of Long)("Numero")))
                  _mensajeError.AppendFormatLine(String.Format("ERROR: No se encontró el Cliente del Pedido {0}.", dr.Field(Of Long)("Numero")))
                  [error] = True
                  conError += 1
               End If
            Else

               '# Si no se encontró el cliente, es posible que haya saltado una validación en la creación o actualización del mismo.
               '# Verifico que no haya grabado un error.
               Dim mensaje As String = String.Empty
               If Not String.IsNullOrEmpty(dr.Field(Of String)("MensajeError").ToString()) Then
                  mensaje = dr.Field(Of String)("MensajeError").ToString()
               Else
                  My.Application.Log.WriteEntry(String.Format("Subida{1}.Ejecutar - ERROR: No se encontró el Cliente (IdCliente NULL) del Pedido {0}.", dr.Field(Of Long)("Numero"), _TipoTiendaWeb), TraceEventType.Information)
                  mensaje = String.Format("ERROR: No se encontró el Cliente (IdCliente NULL) del Pedido {0}.", dr.Field(Of Long)("Numero"))
               End If

               Me.GrabarMensajeError(dr.Field(Of String)("Id"), dr.Field(Of String)("SistemaDestino"), mensaje)
               _mensajeError.AppendFormatLine(mensaje)
               [error] = True
               conError += 1
            End If
         Next
         If conError > 0 Then
            Throw New Exception(_mensajeError.ToString())
         End If
         '# Guardo la fecha de sincronización 
         My.Application.Log.WriteEntry(String.Format("SubidaTiendaNube.Ejecutar - Grabando Fecha de Ult. Sincronización."), TraceEventType.Information)
         rSincronizaciones._Merge(New Entidades.FechaSincronizacion With {.SistemaDestino = _TipoTiendaWeb.ToString(),
                                                                          .Tabla = Entidades.Pedido.NombreTabla,
                                                                          .FechaActualizacion = Now,
                                                                          .FechaBajada = Now,
                                                                          .IdUsuario = actual.Nombre,
                                                                          .NroVersionAplicacion = String.Format("{0} {1}", Publicos.IDAplicacionSinergia, System.Windows.Forms.Application.ProductVersion)})
         '-----------------------------------------
         RaiseEvent Avance(Me, New ImportacionPedidosTiendasWebEventArgs(String.Format("Se importaron {0} Nuevo{1} Pedido{1}.", importados, If(importados <> 1, "s", Nothing))))
         RaiseEvent ProcesoFinalizado(Me, New ProcesoFinalizadoEventArgs("Proceso de Importación finalizado correctamente !!!", importados, conError, _clientesImportados))
         '-----------------------------------------

      End Sub
#End Region

#Region "Events"

#End Region

   End Class

   Public Class ProcesoFinalizadoEventArgs
      Inherits EventArgs
      Public Sub New(mensaje As String, correctos As Integer, conError As Integer, nuevosClientes As Integer)
         Me.Mensaje = mensaje
         Me.ConError = conError
         Me.Correctos = correctos
         Me.NuevosClientes = nuevosClientes
      End Sub

      Public Property Mensaje As String
      Public Property ConError As Integer
      Public Property Correctos As Integer
      Public Property NuevosClientes As Integer
   End Class

   Public Class ImportacionPedidosTiendasWebEventArgs
      Inherits EventArgs
      Public Sub New(mensaje As String)
         Me.Mensaje = mensaje
      End Sub
      Public Sub New(mensaje As String, metodo As String, url As Uri)
         Me.New(mensaje)
         Me.Metodo = metodo
         Me.Url = url
      End Sub
      Public Sub New(mensaje As String, metodo As String, url As Uri, totalRegistrosSubidos As Long)
         Me.New(mensaje, metodo, url, totalRegistrosSubidos, nombre:=String.Empty)
      End Sub
      Public Sub New(mensaje As String, metodo As String, url As Uri, totalRegistrosSubidos As Long, nombre As String)
         Me.New(mensaje, metodo, url)
         Me.TotalRegistrosSubidos = totalRegistrosSubidos
         Me.Nombre = nombre
      End Sub

      Public Property Mensaje As String
      Public Property Metodo As String
      Public Property Url As Uri
      Public Property TotalRegistrosSubidos As Long
      Public Property Nombre As String
   End Class
End Namespace
