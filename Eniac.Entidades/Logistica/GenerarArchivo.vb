Imports System.ComponentModel
Imports System.Runtime.Serialization

<DataContract()>
Public Class GenerarArchivo
   Inherits Eniac.Entidades.Entidad

   Public Enum FormatosExportacion
      <Description("Sync v1")> Sync
      <Description("Sync v2")> Sync2
   End Enum

   Public Enum BusquedaClientes
      <Description("Por Nombre")> nombre
      <Description("Por Dirección")> direccion
   End Enum

   Public Enum OrdenarProductos
      <Description("Por Descripción")> descripcion
      <Description("Por Código")> codigo
   End Enum

   Public Enum PreferenciasKeys
      buscar_cliente             'busqueda_de_clientes
      orden_producto             'ordenar_productos
      solicita_cierre            'solicita_estado_visita
      fecha_exportacion          'usar_fecha_exportacion
      ocultar_envio_mail         'ocultar_exportar_email

      'Nuevos
      plazo_entrega_dv           'plazo_entrega_dv
      porc_max_decuento          'porc_max_decuento
      porc_max_recargo           'porc_max_recargo
      envia_mail_cliente
      envia_mail_empresa
      ocultar_resumen_promedio
      plazo_entrega_pedido
      plazo_entrega_linea

      'Nuevo de la ruta
      puede_modificar_precios

   End Enum



   Public Class TagsSync2
      Public Const TAG_RUTAS As String = "simovil.rutas"

      Public Const TAG_CLIENTES As String = "simovil.clientes"
      Public Const TAG_PRODUCTOS As String = "simovil.productos"
      Public Const TAG_HISTORICOS As String = "simovil.historico"
      Public Const TAG_RUBROS As String = "simovil.rubros"

      Public Const TAG_CTACTECLTE As String = "simovil.ctacte"
      Public Const TAG_PLAZOS As String = "simovil.plazos"
      'Public Const TAG_EMAILS As String = "simovil.emails"
      Public Const TAG_CONFIGURACIONES As String = "simovil.configuraciones"
      Public Const TAG_LISTASPRECIOS As String = "simovil.listas.precios"
   End Class

End Class