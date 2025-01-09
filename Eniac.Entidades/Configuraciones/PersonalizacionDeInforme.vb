Imports System.ComponentModel
Public Class PersonalizacionDeInforme
   Inherits Entidad
   Public Enum Columnas
      IdInforme
      NombreArchivo
      Embebido
   End Enum

   Public Enum Informes
      <Description("Reparto")> Reparto
      <Description("Informe de Cta. Cte. de Clientes")> InfCtaCteClientes
      <Description("Informe de Cta. Cte. de Clientes por Vendedor")> InfCtaCteClientesPorVendedor
      <Description("Informe de Cta. Cte. de Clientes por Hoja")> InfCtaCteClientesUnoPorHoja
      <Description("Informe de Cta. Cte. de Detallado Clientes")> InfCtaCteDetalladoClientes
      <Description("Informe de Cta. Cte. de Detallado Clientes por Vendedor")> InfCtaCteDetalladoClientesPorVendedor
      <Description("Informe de Cta. Cte. de Detallado Clientes por Hoja")> InfCtaCteDetalladoClientesUnoPorHoja
      <Description("Informe de Cta. Cte. de Cliente - Debe y Haber")> InfConsultarCtaCteClientesDH
      <Description("Informe de Cta. Cte. de Cliente - Debe y Haber")> InfConsultarCtaCteDetalladoClientesDH
      <Description("Saldos Cta. Cte. de Clientes")> SaldosCtaCteClientes
      <Description("Saldos Cta. Cte. de Clientes por Vendedor")> SaldosCtaCteClientesPorVendedor
      <Description("Logistica - Consolidado de Carga")> SiLIVE_ConsolidadoDeCarga
      <Description("Logistica - Cons. de Carga Tp. Oper")> SiLIVE_ConsolidadoDeCargaOperacion
      <Description("Logistica - Listado de Clientes")> SiLIVE_ListadoDeClientes
      <Description("Logistica - Listado de Clientes con Envases")> SiLIVE_ListadoDeClientesConEnvases
      <Description("Fichas para Cliente")> FichaParaClientes
      <Description("Lista de Costos Alfabético")> ListaDeCostos_Alfabetico
      <Description("Lista de Costos Importar Productos")> ListaDeCostos_ImportarP
      <Description("Lista de Costos por Marcas")> ListaDeCostos_Marcas
      <Description("Lista de Costos por Rubros")> ListaDeCostos_Rubros
      <Description("Lista de Precios para Clientes Imagen Marca")> ListaDePreciosParaClientesImagen_Marca
      <Description("Lista de Precios para Clientes por Marca")> ListaDePreciosParaClientes_PorMarca
      <Description("Lista de Precios para Clientes por Marca 2C")> ListaDePreciosParaClientes_PorMarca2C
      <Description("Lista de Precios para Clientes por Marca Rubro")> ListaDePreciosParaClientes_PorMarcaRubro
      <Description("Lista de Precios para Clientes por Marca Rubro 2C")> ListaDePreciosParaClientes_PorMarcaRubro2C
      <Description("Lista de Precios para Clientes Imagen Rubro")> ListaDePreciosParaClientesImagen_Rubro
      <Description("Lista de Precios para Clientes por Rubro")> ListaDePreciosParaClientes_PorRubro
      <Description("Lista de Precios para Clientes por Rubro 2C")> ListaDePreciosParaClientes_PorRubro2C
      <Description("Lista de Precios para Clientes por Rubro Marca")> ListaDePreciosParaClientes_PorRubroMarca
      <Description("Lista de Precios para Clientes por Rubro Marca 2C")> ListaDePreciosParaClientes_PorRubroMarca2C
      <Description("Lista de Precios para Clientes por Rubro Marca 2C Mini")> ListaDePreciosParaClientes_PorRubroMarca2CMini
      <Description("Lista de Precios para Clientes por SubRubro")> ListaDePreciosParaClientes_SubRubro
      <Description("Lista de Precios para Clientes Imagen SubRubro")> ListaDePreciosParaClientesImagen_SubRubro
      <Description("Lista de Precios para Clientes Imagen RubroSubRubro")> ListaDePreciosParaClientesImagen_RubroSubRubro
      <Description("Lista de Precios para Clientes Imagen MarcaRubroSubRubro")> ListaDePreciosParaClientesImagen_MarcaRubroSubRubro
      <Description("Lista de Precios para Clientes Imagen RubroSubRubroSubSubRubro")> ListaDePreciosParaClientesImagen_RubroSubRubroSubSubRubro
      <Description("Ticket Movimiento de Caja")> TicketCajaMovimiento
      <Description("Planilla de Movimiento Caja")> CajaDetalles
      <Description("Planilla de Movimiento Caja Horizontal")> CajaDetallesHorizontal
      <Description("Planilla de Movimiento Caja Observación")> CajaDetallesObservacion
      <Description("Registración de Pagos Resumen Detallado")> RegistracionPagosResumenDetallado
      <Description("Emisión de Etiquetas para Bultos")> EmisionEtiquetasParaBultos
      <Description("Informe Ordenes de Produccion Detallado")> InfOrdenesProduccionDetallado

   End Enum


   Public Property IdInforme As String
   Public Property NombreInforme As String
   Public Property NombreArchivo As String
   Public Property Embebido As Boolean

End Class
Public Class InformePersonalizadoResuelto
   Public Property NombreArchivo As String
   Public Property ReporteEmbebido As Boolean
   Public Sub New(nombreArchivoDefault As String)
      NombreArchivo = nombreArchivoDefault
      ReporteEmbebido = True
   End Sub
End Class