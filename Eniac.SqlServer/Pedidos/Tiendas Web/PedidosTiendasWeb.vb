Public Class PedidosTiendasWeb
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub PedidosTiendasWeb_I(id As String,
                                  sistemaDestino As String,
                                  numero As Long,
                                  idClienteTiendaWeb As String,
                                  nombreClienteTiendaWeb As String,
                                  observacionesTiendaWeb As String,
                                  idMoneda As String,
                                  tipoEnvio As String,
                                  direccionEnvio As String,
                                  fechaPedido As DateTime,
                                  costoEnvio As Decimal?,
                                  importeTotal As Decimal,
                                  subTotal As Decimal,
                                  idUsuarioEstado As String,
                                  fechaEstado As DateTime,
                                  idUsuarioDescarga As String,
                                  fechaDescarga As DateTime,
                                  idEstadoPedidoTiendaWeb As String,
                                  mensajeError As String,
                                  JSON As String,
                                  nroDocCliente As Long?,
                                  email As String,
                                  telefono As String,
                                  direccionCalle As String,
                                  direccionNumero As String,
                                  adicional As String,
                                  codigoPostal As Integer?,
                                  localidad As String,
                                  provincia As String,
                                  observacion As String,
                                  packsidtiendaweb As String)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO PedidosTiendasWeb (")
         .AppendFormatLine("	 Id")
         .AppendFormatLine("	,SistemaDestino")
         .AppendFormatLine("	,Numero")
         .AppendFormatLine("	,IdClienteTiendaWeb")
         .AppendFormatLine("	,NombreClienteTiendaWeb")
         .AppendFormatLine("	,ObservacionesTiendaWeb")
         .AppendFormatLine("	,IdMoneda")
         .AppendFormatLine("	,TipoEnvio")
         .AppendFormatLine("	,DireccionEnvio")
         .AppendFormatLine("	,FechaPedido")
         .AppendFormatLine("	,CostoEnvio")
         .AppendFormatLine("	,ImporteTotal")
         .AppendFormatLine("	,SubTotal")
         .AppendFormatLine("	,IdUsuarioEstado")
         .AppendFormatLine("	,FechaEstado")
         .AppendFormatLine("	,IdUsuarioDescarga")
         .AppendFormatLine("	,FechaDescarga")
         .AppendFormatLine("	,IdEstadoPedidoTiendaWeb")
         .AppendFormatLine("	,MensajeError")
         .AppendFormatLine("	,JSON")
         .AppendFormatLine("	,NroDocCliente")
         .AppendFormatLine("	,Email")
         .AppendFormatLine("	,Telefono")
         .AppendFormatLine("	,DireccionCalle")
         .AppendFormatLine("	,DireccionNumero")
         .AppendFormatLine("	,Adicional")
         .AppendFormatLine("	,CodigoPostal")
         .AppendFormatLine("	,Localidad")
         .AppendFormatLine("	,Provincia")
         .AppendFormatLine("	,Observacion")
         .AppendFormatLine("	,PacksIdTiendaWeb")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	 '{0}'", id)
         .AppendFormatLine("	,'{0}'", sistemaDestino)
         .AppendFormatLine("	,{0}", numero)
         .AppendFormatLine("	,'{0}'", idClienteTiendaWeb)
         .AppendFormatLine("	,'{0}'", Replace(nombreClienteTiendaWeb, "'", "´"))
         .AppendFormatLine("	,'{0}'", Replace(observacionesTiendaWeb, "'", "´"))
         .AppendFormatLine("	,'{0}'", idMoneda)
         .AppendFormatLine("	,'{0}'", tipoEnvio)
         .AppendFormatLine("	,'{0}'", Replace(direccionEnvio, "'", "´"))
         .AppendFormatLine("	,'{0}'", ObtenerFecha(fechaPedido, True))
         If costoEnvio.HasValue Then
            .AppendFormatLine("	,{0}", costoEnvio.Value)
         Else
            .AppendFormatLine("	,NULL")
         End If
         .AppendFormatLine("	,{0}", importeTotal)
         .AppendFormatLine("	,{0}", subTotal)
         .AppendFormatLine("	,'{0}'", idUsuarioEstado)
         .AppendFormatLine("	,'{0}'", ObtenerFecha(fechaEstado, True))
         .AppendFormatLine("	,'{0}'", idUsuarioDescarga)
         .AppendFormatLine("	,'{0}'", ObtenerFecha(fechaDescarga, True))
         .AppendFormatLine("	,'{0}'", idEstadoPedidoTiendaWeb)
         .AppendFormatLine("	,'{0}'", mensajeError)
         .AppendFormatLine("	,@JSON")

         If nroDocCliente.HasValue Then
            .AppendFormatLine("	,{0}", nroDocCliente)
         Else
            .AppendFormatLine("	,NULL")
         End If

         .AppendFormatLine("	,'{0}'", email)
         .AppendFormatLine("	,'{0}'", telefono)
         .AppendFormatLine("	,'{0}'", Replace(direccionCalle, "'", "´"))
         .AppendFormatLine("	,'{0}'", direccionNumero)
         .AppendFormatLine("	,'{0}'", adicional)

         If codigoPostal.HasValue Then
            .AppendFormatLine("	,{0}", codigoPostal)
         Else
            .AppendFormatLine("	,NULL")
         End If

         .AppendFormatLine("	,'{0}'", localidad)
         .AppendFormatLine("	,'{0}'", provincia)
         .AppendFormatLine("	,'{0}'", Replace(observacion, "'", "´"))
         .AppendFormatLine("	,'{0}'", packsidtiendaweb)
         .AppendFormatLine(")")
      End With

      ''Aquí defino el parámetro
      Me._da.Command.CommandText = query.ToString()
      Me._da.Command.CommandType = CommandType.Text
      Dim oParameter As Data.Common.DbParameter = Nothing
      If Me._da.Command.Parameters.Count = 0 Then
         oParameter = Me._da.Command.CreateParameter()
         oParameter.ParameterName = "@JSON"
         oParameter.DbType = DbType.String
         oParameter.Size = JSON.Length
         oParameter.Value = JSON
         Me._da.Command.Parameters.Add(oParameter)
      End If
      Me._da.Command.Connection = Me._da.Connection
      Me._da.Command.Transaction = Me._da.Transaction

      Me._da.ExecuteNonQuery(Me._da.Command)

   End Sub

   Public Sub PedidosTiendasWeb_U(id As String,
                                  sistemaDestino As String,
                                  numero As Long,
                                  idClienteTiendaWeb As String,
                                  nombreClienteTiendaWeb As String,
                                  observacionesTiendaWeb As String,
                                  idMoneda As String,
                                  tipoEnvio As String,
                                  direccionEnvio As String,
                                  fechaPedido As DateTime,
                                  costoEnvio As Decimal?,
                                  importeTotal As Decimal,
                                  subTotal As Decimal,
                                  idUsuarioEstado As String,
                                  fechaEstado As DateTime,
                                  idUsuarioDescarga As String,
                                  fechaDescarga As DateTime,
                                  idEstadoPedidoTiendaWeb As String,
                                  mensajeError As String,
                                  JSON As String,
                                  nroDocCliente As Long?,
                                  email As String,
                                  telefono As String,
                                  direccionCalle As String,
                                  direccionNumero As String,
                                  adicional As String,
                                  codigoPostal As Integer?,
                                  localidad As String,
                                  provincia As String,
                                  observacion As String,
                                  packsidtiendaweb As String)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE PTW SET")
         .AppendFormatLine("	Numero = {0}", numero)
         .AppendFormatLine("	,IdClienteTiendaWeb = '{0}'", idClienteTiendaWeb)
         .AppendFormatLine("	,NombreClienteTiendaWeb = '{0}'", Replace(nombreClienteTiendaWeb, "'", "´"))
         .AppendFormatLine("	,ObservacionesTiendaWeb = '{0}'", Replace(observacionesTiendaWeb, "'", "´"))
         .AppendFormatLine("	,IdMoneda = '{0}'", idMoneda)
         .AppendFormatLine("	,TipoEnvio = '{0}'", tipoEnvio)
         .AppendFormatLine("	,DireccionEnvio = '{0}'", Replace(direccionEnvio, "'", "´"))
         .AppendFormatLine("	,FechaPedido = '{0}'", ObtenerFecha(fechaPedido, True))
         If costoEnvio.HasValue Then
            .AppendFormatLine("	,{0}", costoEnvio.Value)
         Else
            .AppendFormatLine("	,NULL")
         End If
         .AppendFormatLine("	,ImporteTotal = {0}", importeTotal)
         .AppendFormatLine("	,SubTotal = {0}", subTotal)
         .AppendFormatLine("	,IdUsuarioEstado = '{0}'", idUsuarioEstado)
         .AppendFormatLine("	,FechaEstado = '{0}'", fechaEstado)
         .AppendFormatLine("	,IdUsuarioDescarga = '{0}'", idUsuarioDescarga)
         .AppendFormatLine("	,FechaDescarga = '{0}'", fechaDescarga)
         .AppendFormatLine("	,IdEstadoPedidoTiendaWeb = '{0}'", idEstadoPedidoTiendaWeb)
         .AppendFormatLine("	,MensajeError = '{0}'", mensajeError)
         .AppendFormatLine("	,JSON = '{0}'", JSON)
         .AppendFormatLine("	,NroDocCliente = {0}", nroDocCliente)
         .AppendFormatLine("	,Email = '{0}'", Replace(email, "'", "´"))
         .AppendFormatLine("	,Telefono = '{0}'", telefono)
         .AppendFormatLine("	,DireccionCalle = '{0}'", Replace(direccionCalle, "'", "´"))
         .AppendFormatLine("	,DireccionNumero = '{0}'", direccionNumero)
         .AppendFormatLine("	,Adicional = '{0}'", adicional)
         .AppendFormatLine("	,CodigoPostal = {0}", codigoPostal)
         .AppendFormatLine("	,Provincia = '{0}'", provincia)
         .AppendFormatLine("	,Observacion = '{0}'", Replace(observacion, "'", "´"))
         .AppendFormatLine("FROM PedidosTiendasWeb PWT")
         .AppendFormatLine("WHERE Id = '{0}' AND SistemaDestino = '{1}'", id, sistemaDestino)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub PedidosTiendasWeb_D(id As String, sistemaDestino As String)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE Pedidos WHERE Id = '{0}' AND SistemaDestino = '{1}'", id, sistemaDestino)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function PedidosTiendasWeb_GA() As DataTable
      Dim query As StringBuilder = New StringBuilder
      Me.SelectTexto(query)

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function PedidosTiendasWeb_G1(id As String, sistemaDestino As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         Me.SelectTexto(query)
         .AppendFormatLine("WHERE Id = '{0}' AND SistemaDestino = '{1}'", id, sistemaDestino)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetMaxId(sistemaDestino As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT MAX(Id) Id FROM PedidosTiendasWeb WHERE SistemaDestino = '{0}'", sistemaDestino)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ExistePedido(id As String, sistemaDestino As String) As Boolean
      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendFormatLine("WHERE Id = '{0}' AND SistemaDestino = '{1}'", id, sistemaDestino)
      End With
      Return Me.GetDataTable(query.ToString()).Rows.Count > 0
   End Function

   Public Sub ActualizarEstadoPedidoTiendaWeb(id As String, sistemaDestino As String, estado As String, quitarMensajeError As Boolean)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE PTW SET PTW.IdEstadoPedidoTiendaWeb = '{0}' ", estado)
         If quitarMensajeError Then .AppendFormatLine("   ,PTW.MensajeError = ''")
         .AppendFormatLine("FROM PedidosTiendasWeb PTW")
         .AppendFormatLine("WHERE PTW.Id = '{0}' AND PTW.SistemaDestino = '{1}'", id, sistemaDestino)
      End With
      Me.Execute(query.ToString())
   End Sub

   Public Function GetPedidosAImportar(sistemaDestino As String,
                                       estados As String(),
                                       nroPedido As Long?,
                                       desde As DateTime?,
                                       hasta As DateTime?,
                                       tipoFechaFiltro As String) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT C.IdCliente{0},C.IdCliente,PTW.* FROM PedidosTiendasWeb PTW", sistemaDestino)
         .AppendFormatLine("  LEFT JOIN Clientes C ON PTW.IdClienteTiendaWeb = C.IdCliente{0} AND PTW.SistemaDestino = '{0}'", sistemaDestino)
         .AppendFormatLine("WHERE 1 = 1")
         If estados IsNot Nothing Then GetListaMultiples(query, estados, "PTW", "IdEstadoPedidoTiendaWeb")
         If nroPedido.HasValue AndAlso nroPedido.Value <> 0 Then .AppendFormatLine("  AND PTW.Numero = {0}", nroPedido.Value)

         If Not String.IsNullOrEmpty(tipoFechaFiltro) Then
            If tipoFechaFiltro = "FechaPedido" Then
               .AppendFormatLine("  AND PTW.FechaPedido >= {0} AND PTW.FechaPedido <= {1}", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))
            ElseIf tipoFechaFiltro = "FechaDescarga" Then
               .AppendFormatLine("  AND PTW.FechaDescarga >= {0} AND PTW.FechaDescarga <= {1}", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))
            ElseIf tipoFechaFiltro = "FechaEstado" Then
               .AppendFormatLine("  AND PTW.FechaEstado >= {0} AND PTW.FechaEstado <= {1}", ObtenerFecha(desde, True), ObtenerFecha(hasta, True))
            End If
         End If
         .AppendFormatLine("  AND PTW.SistemaDestino = '{0}'", sistemaDestino)

      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	 PTW.Id")
         .AppendFormatLine("	,PTW.SistemaDestino")
         .AppendFormatLine("	,PTW.Numero")
         .AppendFormatLine("	,PTW.IdClienteTiendaWeb")
         .AppendFormatLine("	,PTW.IdMoneda")
         .AppendFormatLine("	,PTW.TipoEnvio")
         .AppendFormatLine("	,PTW.DireccionEnvio")
         .AppendFormatLine("	,PTW.FechaPedido")
         .AppendFormatLine("	,PTW.CostoEnvio")
         .AppendFormatLine("	,PTW.ImporteTotal")
         .AppendFormatLine("	,PTW.SubTotal")
         .AppendFormatLine("	,PTW.IdUsuarioEstado")
         .AppendFormatLine("	,PTW.FechaEstado")
         .AppendFormatLine("	,PTW.IdUsuarioDescarga")
         .AppendFormatLine("	,PTW.FechaDescarga")
         .AppendFormatLine("	,PTW.IdEstadoPedidoTiendaWeb")
         .AppendFormatLine("	,PTW.MensajeError")
         .AppendFormatLine("	,PTW.JSON")
         .AppendFormatLine("	,PTW.NroDocCliente")
         .AppendFormatLine("	,PTW.Email")
         .AppendFormatLine("	,PTW.Telefono")
         .AppendFormatLine("	,PTW.DireccionCalle")
         .AppendFormatLine("	,PTW.DireccionNumero")
         .AppendFormatLine("	,PTW.Adicional")
         .AppendFormatLine("	,PTW.CodigoPostal")
         .AppendFormatLine("	,PTW.Localidad")
         .AppendFormatLine("	,PTW.Provincia")
         .AppendFormatLine("	,PTW.Observacion")
         .AppendFormatLine("FROM PedidosTiendasWeb PTW")
      End With
   End Sub

   Public Sub GrabarMensajeError(id As String, sistemaDestino As String, mensaje As String)
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE PTW SET PTW.MensajeError = '{0}', PTW.IdEstadoPedidoTiendaWeb = 'ERROR' FROM PedidosTiendasWeb PTW", mensaje)
         .AppendFormatLine("  WHERE PTW.Id = '{0}' AND PTW.SistemaDestino = '{1}'", id, sistemaDestino)
      End With
      Me.Execute(query.ToString())
   End Sub

End Class