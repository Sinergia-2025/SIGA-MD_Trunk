Public Class RecepcionNotasProveedoresF
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RecepcionNotasProveedoresF_I(ByVal idSucursal As Integer, _
                                           ByVal nroNota As Integer, _
                                           ByVal IdProveedor As Long, _
                                           ByVal fechaEntrega As Date, _
                                           ByVal observacion As String, _
                                           ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO RecepcionNotasProveedoresF")
         .Append("           (idSucursal")
         .Append("           ,NroNota")
         .Append("           ,IdProveedor")
         .Append("           ,FechaEntrega")
         .Append("           ,Observacion")
         .Append("           ,Usuario)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,{0}", nroNota)
         .AppendFormat("           ,{0}", IdProveedor)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaEntrega, True))
         .AppendFormat("           ,'{0}'", observacion)
         .AppendFormat("           ,'{0}')", usuario)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RecepcionNotasProveedoresF")

   End Sub

End Class
