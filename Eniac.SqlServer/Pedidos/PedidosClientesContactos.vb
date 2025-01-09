Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class PedidosClientesContactos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PedidosClientesContactos_I(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroPedido As Long,
                                         idCliente As Long,
                                         idContacto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO PedidosClientesContactos ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                       PedidoClienteContacto.Columnas.IdSucursal.ToString(),
                       PedidoClienteContacto.Columnas.IdTipoComprobante.ToString(),
                       PedidoClienteContacto.Columnas.Letra.ToString(),
                       PedidoClienteContacto.Columnas.CentroEmisor.ToString(),
                       PedidoClienteContacto.Columnas.NumeroPedido.ToString(),
                       PedidoClienteContacto.Columnas.IdCliente.ToString(),
                       PedidoClienteContacto.Columnas.IdContacto.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, {6})",
                       idSucursal, idTipoComprobante, letra,
                       centroEmisor, numeroPedido,
                       idCliente, idContacto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PedidosClientesContactos_U(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroPedido As Long,
                                         idCliente As Long,
                                         idContacto As Integer)
      Throw New NotImplementedException("El metodo de UPDATE no se implementa aún porque no hay atributos que no sean PK.")
      'Dim myQuery As StringBuilder = New StringBuilder()

      'With myQuery
      '   .Length = 0
      '   .AppendLine("UPDATE PedidosClientesContactos ")
      '   .AppendFormat("   SET {0} = '{1}'", PedidoClienteContacto.Columnas.NombreEstadoNovedad.ToString(), NombreEstadoNovedad).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", PedidoClienteContacto.Columnas.Posicion.ToString(), Posicion).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", PedidoClienteContacto.Columnas.SolicitaUsuario.ToString(), GetStringFromBoolean(SolicitaUsuario)).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", PedidoClienteContacto.Columnas.Finalizado.ToString(), GetStringFromBoolean(Finalizado)).AppendLine()
      '   .AppendFormat("     , {0} = '{1}'", PedidoClienteContacto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", PedidoClienteContacto.Columnas.PorDefecto.ToString(), GetStringFromBoolean(PorDefecto)).AppendLine()
      '   .AppendFormat(" WHERE {0} =  {1} ", PedidoClienteContacto.Columnas.IdEstadoNovedad.ToString(), IdEstadoNovedad)
      'End With
      'Me.Execute(myQuery.ToString())
   End Sub

   Public Sub PedidosClientesContactos_D(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroPedido As Long)
      PedidosClientesContactos_D(idSucursal,
                                 idTipoComprobante,
                                 letra,
                                 centroEmisor,
                                 numeroPedido,
                                 idCliente:=0,
                                 idContacto:=0)
   End Sub

   Public Sub PedidosClientesContactos_D(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroPedido As Long,
                                         idCliente As Long,
                                         idContacto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM PedidosClientesContactos")
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If centroEmisor > 0 Then
            .AppendFormat("   AND {0} = {1}", PedidoClienteContacto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND {0} = '{1}'", PedidoClienteContacto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND {0} = '{1}'", PedidoClienteContacto.Columnas.Letra.ToString(), letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND {0} = {1}", PedidoClienteContacto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND {0} = {1}", PedidoClienteContacto.Columnas.NumeroPedido.ToString(), numeroPedido).AppendLine()
         End If
         If idCliente > 0 Then
            .AppendFormat("   AND {0} = {1}", PedidoClienteContacto.Columnas.IdCliente.ToString(), idCliente).AppendLine()
         End If
         If idContacto > 0 Then
            .AppendFormat("   AND {0} = {1}", PedidoClienteContacto.Columnas.IdContacto.ToString(), idContacto).AppendLine()
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PCC.*").AppendLine()
         .AppendFormat("  FROM PedidosClientesContactos AS PCC").AppendLine()
      End With
   End Sub

   Public Function PedidosClientesContactos_GA() As DataTable
      Return PedidosClientesContactos_G(idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty,
                                        centroEmisor:=0, numeroPedido:=0, idCliente:=0, idContacto:=0)
   End Function
   Public Function PedidosClientesContactos_G(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Short,
                                              numeroPedido As Long) As DataTable
      Return PedidosClientesContactos_G(idSucursal, idTipoComprobante, letra,
                                        centroEmisor, numeroPedido, idCliente:=0, idContacto:=0)
   End Function
   Private Function PedidosClientesContactos_G(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroPedido As Long,
                                               idCliente As Long,
                                               idContacto As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", PedidoClienteContacto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PCC.{0} = '{1}'", PedidoClienteContacto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PCC.{0} = '{1}'", PedidoClienteContacto.Columnas.Letra.ToString(), letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", PedidoClienteContacto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         End If
         If numeroPedido > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", PedidoClienteContacto.Columnas.NumeroPedido.ToString(), numeroPedido).AppendLine()
         End If
         If idCliente > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", PedidoClienteContacto.Columnas.IdCliente.ToString(), idCliente).AppendLine()
         End If
         If idContacto > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", PedidoClienteContacto.Columnas.IdContacto.ToString(), idContacto).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function PedidosClientesContactos_G1(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroPedido As Long,
                                               idCliente As Long,
                                               idContacto As Integer) As DataTable
      Return PedidosClientesContactos_G(idSucursal, String.Empty, String.Empty, 0, 0, 0, 0)
   End Function

   Public Function PedidosClientesContactos_GetParaInforme(idSucursal As Integer,
                                            idTipoComprobante As String,
                                            letra As String,
                                            centroEmisor As Short,
                                            numeroComprobante As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PCC.IdContacto, CC.NombreContacto ,TC.NombreTipoContacto ,  CC.Direccion, CC.IdLocalidad, LO.NombreLocalidad, CC.Telefono, CC.Observacion ")
         .AppendLine(" FROM PedidosClientesContactos AS PCC ")
         .AppendLine(" INNER JOIN ClientesContactos CC ON CC.IdCliente = PCC.IdCliente ")
         .AppendLine(" AND CC.IdContacto = PCC.IdContacto ")
         .AppendLine(" INNER JOIN TiposContactos TC ON TC.IdTipoContacto = CC.IdTipoContacto ")
         .AppendLine(" INNER JOIN Localidades LO ON LO.IdLocalidad = CC.IdLocalidad ")
         .AppendLine(" WHERE PCC.IdSucursal = " & idSucursal)
         .AppendLine(" AND PCC.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine(" AND PCC.Letra = '" & letra & "'")
         .AppendLine(" AND PCC.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine(" AND PCC.NumeroPedido = " & numeroComprobante.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   'Public Sub CopiarPedidoClientesContacto(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroPedido As Long,
   '                                        idSucursalNuevo As Integer, idTipoComprobanteNuevo As String, letraNuevo As String, centroEmisorNuevo As Integer, numeroPedidoNuevo As Long)
   '   Dim myQuery As StringBuilder = New StringBuilder()
   '   With myQuery
   '      .AppendFormat("INSERT INTO PedidosClientesContactos").AppendLine()
   '      .AppendFormat("           (IdSucursal").AppendLine()
   '      .AppendFormat("           ,IdTipoComprobante").AppendLine()
   '      .AppendFormat("           ,Letra").AppendLine()
   '      .AppendFormat("           ,CentroEmisor").AppendLine()
   '      .AppendFormat("           ,NumeroPedido").AppendLine()
   '      .AppendFormat("           ,IdCliente").AppendLine()
   '      .AppendFormat("           ,IdContacto)").AppendLine()
   '      .AppendFormat("SELECT {0} idSucursal", idSucursalNuevo).AppendLine()
   '      .AppendFormat("      ,'{0}' IdTipoComprobante", idTipoComprobanteNuevo).AppendLine()
   '      .AppendFormat("      ,'{0}' Letra", letraNuevo).AppendLine()
   '      .AppendFormat("      ,{0} CentroEmisor", centroEmisorNuevo).AppendLine()
   '      .AppendFormat("      ,{0} NumeroPedido", numeroPedidoNuevo).AppendLine()
   '      .AppendFormat("      ,IdCliente").AppendLine()
   '      .AppendFormat("      ,IdContacto").AppendLine()
   '      .AppendFormat("  FROM PedidosClientesContactos").AppendLine()
   '      .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
   '      .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
   '      .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
   '      .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
   '      .AppendFormat("   AND NumeroPedido = {0}", numeroPedido).AppendLine()

   '   End With
   '   Me.Execute(myQuery.ToString())
   'End Sub

End Class