Public Class RecepcionNotasEstados
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub RecepcionNotasEstados_I(ByVal idSucursal As Integer, _
                                      ByVal nroNota As Integer, _
                                      ByVal idEstado As Integer, _
                                      ByVal fechaEstado As Date, _
                                      ByVal observacion As String, _
                                      ByVal usuario As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("INSERT INTO RecepcionNotasEstados")
         .Append("           (IdSucursal")
         .Append("           ,NroNota")
         .Append("           ,FechaEstado")
         .Append("           ,IdEstado")
         .Append("           ,Observacion")
         .Append("           ,Usuario)")
         .Append("     VALUES")
         .AppendFormat("           ({0}", idSucursal)
         .AppendFormat("           ,{0}", nroNota)
         .AppendFormat("           ,'{0}'", Me.ObtenerFecha(fechaEstado, True))
         .AppendFormat("           ,{0}", idEstado)
         .AppendFormat("           ,'{0}'", observacion)
         .AppendFormat("           ,'{0}')", usuario)
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "RecepcionNotasEstados")

   End Sub

End Class
