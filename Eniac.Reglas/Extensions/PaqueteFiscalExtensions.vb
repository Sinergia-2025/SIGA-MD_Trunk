Imports System.Runtime.CompilerServices
Imports LibreriaFiscalV2

Public Module PaqueteFiscalExtensions
   <Extension>
   Public Function GetCampo(Of T)(paqueteFiscal As PaqueteFiscal, index As Integer) As T
      If paqueteFiscal.Campos.Count <= index Then
         Throw New Exception(String.Format("No existe Campo Fiscal {0} en el Paquete Fiscal", index))
      End If

      Try
         Return DirectCast(Convert.ChangeType(paqueteFiscal.Campos(index).ToString(), GetType(T)), T)
      Catch ex As Exception
         Throw New Exception(String.Format("No se puede obtener el valor del Campo Fiscal {0} en el Paquete Fiscal: {1}", index, ex.Message), ex)
      End Try
   End Function
End Module