Namespace Ayudante.MasInfoCliente
   Public Class MostrarMasInfo
      Private Shared _pantalla As Pantalla?
      Public Shared Function Mostrar(idCliente As Long) As DialogResult
         Return Mostrar(If(idCliente > 0, New Reglas.Clientes().GetUno(idCliente, incluirFoto:=True), Nothing))
      End Function
      Public Shared Function Mostrar(ByRef cliente As Entidades.Cliente) As DialogResult
         Dim stateForm As Eniac.Win.StateForm

         If cliente IsNot Nothing Then
            cliente.Usuario = actual.Nombre
            stateForm = Win.StateForm.Actualizar
         Else
            cliente = New Entidades.Cliente()
            stateForm = Win.StateForm.Insertar
         End If

         If Not _pantalla.HasValue Then
            Dim rFunc = New Reglas.Funciones()
            If rFunc.ExisteFuncionPorPantalla(Pantalla.ClientesLiveABM.ToString()) Then  ' AndAlso
               'Not rFunc.ExisteFuncionPorPantalla(Pantalla.ClientesABM.ToString()) Then
               _pantalla = Pantalla.ClientesLiveABM
            Else
               _pantalla = Pantalla.ClientesABM
            End If
         End If

         Dim pantClienteBase As BaseDetalle
         If _pantalla = Pantalla.ClientesLiveABM Then
            pantClienteBase = New ClientesLIVEDetalle(cliente)
         Else
            pantClienteBase = New ClientesDetalle(cliente)
         End If

         pantClienteBase.CierraAutomaticamente = True
         pantClienteBase.StateForm = stateForm

         Return pantClienteBase.ShowDialog()
      End Function
      Private Enum Pantalla
         ClientesABM
         ClientesLiveABM
      End Enum
   End Class
End Namespace