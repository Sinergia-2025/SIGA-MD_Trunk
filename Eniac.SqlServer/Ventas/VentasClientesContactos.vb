Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class VentasClientesContactos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasClientesContactos_I(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroComprobante As Long,
                                         idCliente As Long,
                                         idContacto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO VentasClientesContactos ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
                       VentaClienteContacto.Columnas.IdSucursal.ToString(),
                       VentaClienteContacto.Columnas.IdTipoComprobante.ToString(),
                       VentaClienteContacto.Columnas.Letra.ToString(),
                       VentaClienteContacto.Columnas.CentroEmisor.ToString(),
                       VentaClienteContacto.Columnas.NumeroComprobante.ToString(),
                       VentaClienteContacto.Columnas.IdCliente.ToString(),
                       VentaClienteContacto.Columnas.IdContacto.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}', '{2}', {3}, {4}, {5}, {6})",
                       idSucursal, idTipoComprobante, letra,
                       centroEmisor, numeroComprobante,
                       idCliente, idContacto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasClientesContactos_U(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroComprobante As Long,
                                         idCliente As Long,
                                         idContacto As Integer)
      Throw New NotImplementedException("El metodo de UPDATE no se implementa aún porque no hay atributos que no sean PK.")
      'Dim myQuery As StringBuilder = New StringBuilder()

      'With myQuery
      '   .Length = 0
      '   .AppendLine("UPDATE VentasClientesContactos ")
      '   .AppendFormat("   SET {0} = '{1}'", VentaClienteContacto.Columnas.NombreEstadoNovedad.ToString(), NombreEstadoNovedad).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", VentaClienteContacto.Columnas.Posicion.ToString(), Posicion).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", VentaClienteContacto.Columnas.SolicitaUsuario.ToString(), GetStringFromBoolean(SolicitaUsuario)).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", VentaClienteContacto.Columnas.Finalizado.ToString(), GetStringFromBoolean(Finalizado)).AppendLine()
      '   .AppendFormat("     , {0} = '{1}'", VentaClienteContacto.Columnas.IdTipoNovedad.ToString(), idTipoNovedad).AppendLine()
      '   .AppendFormat("     , {0} =  {1} ", VentaClienteContacto.Columnas.PorDefecto.ToString(), GetStringFromBoolean(PorDefecto)).AppendLine()
      '   .AppendFormat(" WHERE {0} =  {1} ", VentaClienteContacto.Columnas.IdEstadoNovedad.ToString(), IdEstadoNovedad)
      'End With
      'Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasClientesContactos_D(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroComprobante As Long)
      VentasClientesContactos_D(idSucursal,
                                 idTipoComprobante,
                                 letra,
                                 centroEmisor,
                                 numeroComprobante,
                                 idCliente:=0,
                                 idContacto:=0)
   End Sub

   Public Sub VentasClientesContactos_D(idSucursal As Integer,
                                         idTipoComprobante As String,
                                         letra As String,
                                         centroEmisor As Short,
                                         numeroComprobante As Long,
                                         idCliente As Long,
                                         idContacto As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM VentasClientesContactos")
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If centroEmisor > 0 Then
            .AppendFormat("   AND {0} = {1}", VentaClienteContacto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND {0} = '{1}'", VentaClienteContacto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND {0} = '{1}'", VentaClienteContacto.Columnas.Letra.ToString(), letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND {0} = {1}", VentaClienteContacto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         End If
         If numeroComprobante > 0 Then
            .AppendFormat("   AND {0} = {1}", VentaClienteContacto.Columnas.NumeroComprobante.ToString(), numeroComprobante).AppendLine()
         End If
         If idCliente > 0 Then
            .AppendFormat("   AND {0} = {1}", VentaClienteContacto.Columnas.IdCliente.ToString(), idCliente).AppendLine()
         End If
         If idContacto > 0 Then
            .AppendFormat("   AND {0} = {1}", VentaClienteContacto.Columnas.IdContacto.ToString(), idContacto).AppendLine()
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PCC.*").AppendLine()
         .AppendFormat("  FROM VentasClientesContactos AS PCC").AppendLine()
      End With
   End Sub

   Public Function VentasClientesContactos_GA() As DataTable
      Return VentasClientesContactos_G(idSucursal:=0, idTipoComprobante:=String.Empty, letra:=String.Empty,
                                        centroEmisor:=0, numeroComprobante:=0, idCliente:=0, idContacto:=0)
   End Function
   Public Function VentasClientesContactos_G(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Short,
                                              numeroComprobante As Long) As DataTable
      Return VentasClientesContactos_G(idSucursal, idTipoComprobante, letra,
                                        centroEmisor, numeroComprobante, idCliente:=0, idContacto:=0)
   End Function

   Public Function VentasClientesContactos_GetParaInforme(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           numeroComprobante As Long) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("SELECT PCC.IdContacto, CC.NombreContacto ,TC.NombreTipoContacto ,  CC.Direccion, CC.IdLocalidad, LO.NombreLocalidad, CC.Telefono, CC.Observacion ")
         .AppendLine(" FROM VentasClientesContactos AS PCC ")
         .AppendLine(" INNER JOIN ClientesContactos CC ON CC.IdCliente = PCC.IdCliente ")
         .AppendLine(" AND CC.IdContacto = PCC.IdContacto ")
         .AppendLine(" INNER JOIN TiposContactos TC ON TC.IdTipoContacto = CC.IdTipoContacto ")
         .AppendLine(" INNER JOIN Localidades LO ON LO.IdLocalidad = CC.IdLocalidad ")
         .AppendLine(" WHERE PCC.IdSucursal = " & idSucursal)
         .AppendLine(" AND PCC.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine(" AND PCC.Letra = '" & letra & "'")
         .AppendLine(" AND PCC.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine(" AND PCC.NumeroComprobante = " & numeroComprobante.ToString())
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Private Function VentasClientesContactos_G(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroComprobante As Long,
                                               idCliente As Long,
                                               idContacto As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat(" WHERE 1 = 1").AppendLine()
         If idSucursal > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", VentaClienteContacto.Columnas.IdSucursal.ToString(), idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND PCC.{0} = '{1}'", VentaClienteContacto.Columnas.IdTipoComprobante.ToString(), idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND PCC.{0} = '{1}'", VentaClienteContacto.Columnas.Letra.ToString(), letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", VentaClienteContacto.Columnas.CentroEmisor.ToString(), centroEmisor).AppendLine()
         End If
         If numeroComprobante > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", VentaClienteContacto.Columnas.NumeroComprobante.ToString(), numeroComprobante).AppendLine()
         End If
         If idCliente > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", VentaClienteContacto.Columnas.IdCliente.ToString(), idCliente).AppendLine()
         End If
         If idContacto > 0 Then
            .AppendFormat("   AND PCC.{0} = {1}", VentaClienteContacto.Columnas.IdContacto.ToString(), idContacto).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function VentasClientesContactos_G1(idSucursal As Integer,
                                               idTipoComprobante As String,
                                               letra As String,
                                               centroEmisor As Short,
                                               numeroComprobante As Long,
                                               idCliente As Long,
                                               idContacto As Integer) As DataTable
      Return VentasClientesContactos_G(idSucursal, String.Empty, String.Empty, 0, 0, 0, 0)
   End Function

End Class