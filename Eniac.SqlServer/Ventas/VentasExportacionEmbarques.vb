Option Strict On
Option Explicit On
Public Class VentasExportacionEmbarques
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasExportacionEmbarques_I(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           numeroComprobante As Long,
                                           idPermisoEmbarque As String,
                                           idDestinoEmbarque As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("INSERT INTO VentasExportacionEmbarque")
         .AppendLine("           (IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,LetraComprobante")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,IdPermisoEmbarque")
         .AppendLine("           ,IdDestinoDespacho")

         .Append("           )")
         .Append("     VALUES (")

         .AppendFormat("             {0} ", idSucursal)
         .AppendFormat("           ,'{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           , {0} ", centroEmisor)
         .AppendFormat("           , {0} ", numeroComprobante)
         .AppendFormat("           ,'{0}'", idPermisoEmbarque)
         .AppendFormat("           ,'{0}'", idDestinoEmbarque)

         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub VentasExportacionEmbarques_D(idSucursal As Integer,
                                           idTipoComprobante As String,
                                           letra As String,
                                           centroEmisor As Short,
                                           numeroComprobante As Long)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .Append("DELETE FROM VentasExportacionEmbarque ")
         .Append(" WHERE ")
         .AppendFormat("   IdSucursal = {0}", idSucursal)
         .AppendFormat("   and IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   and LetraComprobante = '{0}'", letra)
         .AppendFormat("   and CentroEmisor = {0}", centroEmisor)
         .AppendFormat("   and NumeroComprobante = {0}", numeroComprobante)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function VentasExportacionEmbarque_C(IdSucursal As Integer,
                                          IdTipoComprobante As String,
                                          Letra As String,
                                          CentroEmisor As Integer,
                                          NumeroComprobante As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .Append("SELECT * FROM VentasExportacionEmbarque VE ")
         .AppendFormat(" WHERE ")
         .AppendFormat("      VE.IdSucursal = {0} ", IdSucursal)
         .AppendFormat("      AND VE.IdTipoComprobante = '{0}'", IdTipoComprobante)
         .AppendFormat("      AND VE.LetraComprobante = '{0}'", Letra)
         .AppendFormat("      AND VE.CentroEmisor = {0}", CentroEmisor)
         .AppendFormat("      AND VE.NumeroComprobante = {0}", NumeroComprobante)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class






