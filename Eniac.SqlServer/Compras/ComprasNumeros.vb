Public Class ComprasNumeros
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasNumeros_U(ByVal idSucursal As Integer, _
                                   ByVal idTipoComprobante As String, _
                                  ByVal letraFiscal As String, _
                                  ByVal centroEmisor As Short, _
                                  ByVal numero As Long)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .Append("IF NOT EXISTS ( ")
         .Append("SELECT ")
         .Append(" Numero ")
         .Append(" FROM ComprasNumeros")
         .Append(" WHERE ")
         .Append(" IdSucursal = " & idSucursal.ToString)
         .Append(" AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .Append(" AND LetraFiscal = '" & letraFiscal & "'")
         .Append(" AND CentroEmisor = " & centroEmisor.ToString())
         .Append(") ")
         .Append("BEGIN ")
         .Append(" INSERT INTO ComprasNumeros")
         .Append(" (IdSucursal, ")
         .Append(" IdTipoComprobante, ")
         .Append(" LetraFiscal, ")
         .Append(" CentroEmisor, ")
         .Append(" Numero) ")
         .Append("VALUES ( ")
         .Append(idSucursal.ToString & ", ")
         .Append(" '" & idTipoComprobante & "', ")
         .Append(" '" & letraFiscal & "', ")
         .Append(centroEmisor.ToString & ", ")
         .Append(numero.ToString & ")")
         .Append("END ")
      End With

      Me.Execute(myQuery.ToString())

      With myQuery
         .Length = 0
         .Append("UPDATE  ")
         .Append("ComprasNumeros  ")
         .Append("SET  ")
         .Append("Numero = " & numero & " ")
         .Append("WHERE ")
         .Append(" IdSucursal = " & idSucursal.ToString)
         'modificado para que inserte al comprobante relacionado
         .Append(" AND ( IdTipoComprobante = '" & idTipoComprobante & "' or IdTipoComprobanteRelacionado LIKE '%" & idTipoComprobante & "%' )")
         .Append(" AND LetraFiscal = '" & letraFiscal & "'")
         .Append(" AND CentroEmisor = " & centroEmisor.ToString)
      End With
      Me.Execute(myQuery.ToString())

      Me.Sincroniza_I(myQuery.ToString(), "ComprasNumeros")

   End Sub

End Class
