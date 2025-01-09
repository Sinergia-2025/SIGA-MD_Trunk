Public Class MovilRuta
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "MovilRutas"
   Public Enum Columnas
      IdRuta
      NombreRuta
      Activa
      IdDispositivoPorDefecto
      IdVendedor
      IdTransportista
      PuedeModificarPrecio
      PrecioConImpuestos
      Usuario
      PermiteIngresarPorcentajeDescuentos
      PermiteCobroParcial
      EsDeCobranza
      EsDePedidos
      EsDeGestion
      ConfiguraClienteSegun
      DescuentoMax
      RecargaMax

   End Enum

   Public Sub New()
      Activa = True
      ListasDePrecio = New List(Of MovilRutaListaDePrecios)()
   End Sub

   Public Property IdRuta As Integer
   Public Property NombreRuta As String
   Public Property Activa As Boolean
   Public Property IdDispositivoPorDefecto As String
   Public Property IdVendedor As Integer
   Public Property IdTransportista As Integer?
   Public Property PuedeModificarPrecio As Boolean
   Public Property PrecioConImpuestos As Boolean
   Public Property PermiteIngresarPorcentajeDescuentos As Boolean
   Public Property PermiteCobroParcial As Boolean
   Public Property EsDeCobranza As Boolean
   Public Property EsDePedidos As Boolean
   Public Property EsDeGestion As Boolean
   Public Property ConfiguraClienteSegun As OrigenConfiguraClienteSegun
   Public Property DescuentoMax As Decimal
   Public Property RecargaMax As Decimal



   Public Property ListasDePrecio As List(Of Entidades.MovilRutaListaDePrecios)

   Public Function ExisteListaDePrecios(listaDePrecios As Eniac.Entidades.ListaDePrecios) As Boolean
      Return ExisteListaDePrecios(listaDePrecios.IdListaPrecios)
   End Function
   Public Function ExisteListaDePrecios(idListaPrecios As Integer) As Boolean
      For Each rutaLista As Entidades.MovilRutaListaDePrecios In ListasDePrecio
         If rutaLista.IdListaPrecios = IdListaPrecios Then
            Return True
         End If
      Next
      Return False
   End Function
   Public Function CuentaListaDePreciosPorDefecto() As Integer
      Return ListasDePrecio.Where(Function(x) x.PorDefecto).Count()
   End Function

End Class
Public Enum OrigenConfiguraClienteSegun
   <Description("Ruta/Día")> RUTADIA
   <Description("Cliente")> CLIENTE
   '<Description("Movimiento")> MOVIMIENTO
End Enum