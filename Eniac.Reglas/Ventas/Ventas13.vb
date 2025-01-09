Partial Class Ventas

   ''FICHAS

   Public Class Fichas
      Public Function CalcularIntereses(idFormaPago As Integer, cantCuotas As Integer, idCliente As Long, subTotal As Decimal) As CalcularInteresesResult
         Dim cliente As Entidades.Cliente = New Reglas.Clientes().GetUnoPorCodigo(idCliente)
         Dim categoria As Entidades.Categoria = New Reglas.Categorias().GetUno(cliente.IdCategoria)
         Return CalcularIntereses(idFormaPago, cantCuotas, categoria, subTotal)
      End Function
      Public Function CalcularIntereses(idFormaPago As Integer, cantCuotas As Integer, categoria As Entidades.Categoria, subTotal As Decimal) As CalcularInteresesResult
         If cantCuotas = 0 Then cantCuotas = 1
         Dim result As CalcularInteresesResult = New CalcularInteresesResult()
         Dim oInteres As Eniac.Reglas.InteresesDias = New Eniac.Reglas.InteresesDias()
         Dim interes As Decimal = 0

         If cantCuotas > 0 Then
            Dim porcInteres As Decimal = oInteres.GetInteresVentas(idFormaPago, cantCuotas, categoria.IdInteresCuotas)
            interes = subTotal * porcInteres / 100
            result.TotalIntereses = interes
            result.InteresesCuota = (interes / cantCuotas)
         End If
         Return result
      End Function

      Public Function CalcularTotalInteresesNuevo(fechaComprobante As DateTime, ultimoVencimiento As DateTime, categoria As Entidades.Categoria, subTotal As Decimal) As Decimal
         Dim rInteres As Eniac.Reglas.InteresesDias = New Eniac.Reglas.InteresesDias()

         Dim dias As Integer = Convert.ToInt32(Math.Truncate(ultimoVencimiento.Date.Subtract(fechaComprobante.Date).TotalDays))
         Dim porcInteres As Decimal = rInteres.GetPorcInteresVentas(dias, categoria.IdInteresCuotas)

         Return subTotal * porcInteres / 100
      End Function
      Public Class CalcularInteresesResult
         Public Property TotalIntereses As Decimal
         Public Property InteresesCuota As Decimal
      End Class


      Public Function CalcularImporteCuota(cantCuotas As Decimal, subTotal As Decimal, totalIntereses As Decimal) As CalcularImporteCuotaResult
         If cantCuotas = 0 Then cantCuotas = 1
         Dim result As CalcularImporteCuotaResult = New CalcularImporteCuotaResult()
         Dim interes As Decimal = totalIntereses

         result.ImporteCuota = Math.Round((subTotal + interes) / cantCuotas, 2)
         result.ImporteTotalCuotas = (result.ImporteCuota * cantCuotas)

         result.InteresesCuota = interes / cantCuotas
         result.CapitalCuota = result.ImporteCuota - result.InteresesCuota

         Return result
      End Function

      Public Class CalcularImporteCuotaResult
         Public Property ImporteCuota As Decimal
         Public Property ImporteTotalCuotas As Decimal
         Public Property InteresesCuota As Decimal
         Public Property CapitalCuota As Decimal

      End Class

   End Class

End Class
