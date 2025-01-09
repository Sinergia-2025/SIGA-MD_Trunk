Namespace Ayudante
   Public Class Validadores

      Public Enum ValidarExistenciaEn
         Ninguno
         <Description("Cliente, Proveedor, Despachante o Agente Transporte")> Todos
         <Description("Cliente")> Clientes
         <Description("Proveedor")> Proveedores
         <Description("Despachante")> AduanasDespachantes
         <Description("Agente Transporte")> AduanasAgentesTransporte
      End Enum

   End Class
End Namespace