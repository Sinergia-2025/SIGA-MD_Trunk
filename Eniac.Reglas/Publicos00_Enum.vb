Imports System.ComponentModel
Partial Class Publicos

#Region "Enums"
   Public Enum FechaFacturacionEnum As Integer
      <Description("Fecha Actual")>
      FechaActual = 0
      <Description("Primer Día Período Actual")>
      PrimerDiaPeriodoActual = 1
      <Description("Último Día Período Actual")>
      UltimoDiaPeriodoActual = 2
      <Description("Primer Día Período Siguiente")>
      PrimerDiaPeriodoSiguiente = 3
      <Description("Último Día Período Siguiente")>
      UltimoDiaPeriodoSiguiente = 4
      <Description("Primer Día Período Anterior")>
      PrimerDiaPeriodoAnterior = 5
      <Description("Último Día Período Anterior")>
      UltimoDiaPeriodoAnterior = 6
   End Enum

   Public Enum PeriodoFacturacionEnum As Integer
      <Description("Periodo Actual")>
      PeriodoActual = 0
      <Description("Período Siguiente")>
      PeriodoSiguiente = 1
   End Enum

   Public Enum TodosEnum As Integer
      <Description("Marcar Todos")> MararTodos = 0
      <Description("Desmarcar Todos")> DesmarcarTodos = 1
      <Description("Marcar Filtrados")> MarcarFiltrados = 2
      <Description("Desmarcar Filtrados")> DesmarcarFiltrados = 3
      <Description("Invertir Marcas Todos")> InvertirMarcasTodos = 4
      <Description("Invertir Marcas Filtrados")> InvertirMarcasFiltrados = 5
   End Enum

   Public Enum TipoOperacionesTiempos
      <Description("PUESTA A PUNTO")> PUESTAPUNTO
      '<Description("HORAS MAQUINA")> HORASMAQUINA
      <Description("HORAS HOMBRE")> HORASHOMBRE
      <Description("TIEMPO NO PRODUCTIVO")> TIEMPONOPRODUCTIVO
   End Enum

   <Obsolete("Usar Entidades.MRPProcesoProductivoOperacion")>
   Public Enum EstadoAsignaTarea
      <Description("PENDIENTE")> PENDIENTE
      <Description("LIBERADA")> LIBERADA
      <Description("PAUSADA")> PAUSADA
      <Description("FINALIZADA")> FINALIZADA
   End Enum

   Public Enum TodosEnumSI As Integer
      <Description("Marcar Todos")> MarcarTodos = 0
      <Description("Desmarcar Todos")> DesmarcarTodos = 1
      <Description("Invertir Marcas Todos")> InvertirMarcasTodos = 2
   End Enum
   Public Enum ExportacionVentasEnum As Integer
      <Description("Ventas PDA")> PDA = 0
      <Description("Ventas Holistor")> Holistor = 1
      <Description("Sell Out")> SellOut = 2
      <Description("Ventas Mostrador")> Mostrador = 3
   End Enum
   Public Enum ExportacionComprasEnum As Integer
      <Description("Compras Holistor")> Holistor = 0
   End Enum
   Public Enum ClaveLoteDespachoImportacionEnum As Integer
      <Description("Número Despacho")> DESPACHO = 0
      <Description("Número Manifiesto")> MANIFIESTO = 1
   End Enum

   Public Enum ActualizarTiendasWeb As Integer
      <Description("Nunca Actualiza")> NUNCA = 0
      <Description("En el Alta")> ALTA = 1
      <Description("En la Modificación")> MODIFICA = 2
      <Description("En el Alta y la Modificacion")> AMBAS = 3
   End Enum
   Public Enum MonedaProductoTiendasWeb As Integer
      <Description("Pesos")> PESOS = 1
      <Description("Dolares")> DOLARES = 2
      <Description("Del Producto")> DELPRODUCTO = 3
   End Enum
   Public Enum SiempreNuncaPreguntar
      <Description("Siempre")> SIEMPRE
      <Description("Nunca")> NUNCA
      <Description("Preguntar")> PREGUNTAR
   End Enum

   Public Enum FormatoVisualizaPrecioDolares As Integer
      <Description("Pesos")> PESOS = 1
      <Description("Dolares")> DOLARES = 2
      <Description("Ambos")> AMBOS = 3
   End Enum

   Public Enum BancosImportacionCheques
      <Description("MACRO")> MACRO
      <Description("BBVA")> BBVA
   End Enum

   Public Enum ExpensasRegistraComprasPorEnum As Integer
      <Description("NoAplica")> NoAplica = -1
      <Description("Área Común")> AreaComun = 0
      <Description("Grupo de Camas")> GrupoCama = 1
   End Enum

   Public Enum TipoImpresionMRP As Integer
      <Description("Hoja de Ruta de Ordenes Produccion")> PorOrdenProduccion = 0
      <Description("Hoja de Ruta de un Producto")> PorOrdenProduccionProducto = 1
      <Description("Hoja de Ruta de una Operacion")> PorOrdenProduccionOperacion = 2
   End Enum

#End Region

End Class