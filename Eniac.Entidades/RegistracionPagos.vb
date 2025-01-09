Imports System.ComponentModel

Public Class RegistracionPagos

   Public Enum ModoConsultarComprobantes
      <Description("Reparto Seleccionado")> SoloRepartoSeleccionado
      <Description("Clientes del Reparto")> ComprobantesClientesReparto
      <Description("Todos los pendientes")> ComprobantesPendientesPago
   End Enum
End Class
