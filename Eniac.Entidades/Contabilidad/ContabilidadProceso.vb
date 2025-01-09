<Serializable()>
<Description("ContabilidadProceso")>
Public Class ContabilidadProceso
   Inherits Eniac.Entidades.Entidad

   Public Enum Procesos As Integer
      <Description("Ventas")>
      VENTAS = 1
      <Description("CC. Clientes")>
      CuentaCte = 2
      <Description("Compras")>
      COMPRAS = 3
      <Description("CC. Proveedores")>
      PagoProv = 4
      <Description("Caja")>
      MOVCAJA = 5
      <Description("Bancos")>
      MOVBANCO = 6
      <Description("Manuales")>
      MANUALES = 7
      <Browsable(False)>
      STOCK = 8
      <Browsable(False)>
      STOCKXVTAS = 9
      <Browsable(False)>
      AJUSTE = 10
      '<Browsable(False)>
      'Anulaciones
      '<Browsable(False)>
      'BANCOS
   End Enum
End Class