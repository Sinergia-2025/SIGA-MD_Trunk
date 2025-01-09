Imports System.ComponentModel
Imports System.Drawing
Imports System.IO

Public Class Publicos

   Public Class Reportes
      Public Enum NivelAgrupamientoStock
         Sucursal
         Deposito
         Ubicacion
      End Enum
   End Class

   Public Enum SiteTiendaWeb
      MLA
   End Enum

   Public Enum TipoContribuyente As Integer
      CLIENTE = 0
      PROVEEDOR = 1
   End Enum

   Public Enum TiendasWeb As Integer
      TiendaNube = 1
      MercadoLibre = 2
   End Enum

   Public Enum TipoPublicacion
      gold_pro
      gold_premium
      gold_special
      gold
      silver
      bronze
      free
   End Enum

   Public Enum TiposEmpleados
      COMPRADOR
      VENDEDOR
      COBRADOR
      RESPPROD
      TODOS
   End Enum

   Public Enum AfectaCaja
      TODOS = -1
      NO = 0
      SI = 1
   End Enum

   Public Enum SiNo As Integer
      SI = 1
      NO = 0
   End Enum

   Public Enum AjustaStock As Integer
      NOAJUSTA = 0
      CONSUMIR = 1
      REVERTIR = 2
      RESERVAR = 3
      DEVRESERVAR = 4
   End Enum

   Public Enum LecturaEscrituraTodos As Integer
      TODOS = 0
      LECTURA = 1
      ESCRITURA = 2
   End Enum
   Public Enum SiNoTodos As Integer
      TODOS = 0
      SI = 1
      NO = 2
   End Enum
   Public Enum PermitirNoPermitir As Integer
      PERMITIR = 0
      NOPERMITIR = 1
      AVISARYPERMITIR = 2
   End Enum

   Public Enum AndOr
      [And]
      [Or]
   End Enum

   Public Enum Dias As Integer
      Domingo = 0
      Lunes = 1
      Martes = 2
      Miercoles = 3
      Jueves = 4
      Viernes = 5
      Sabado = 6
      Otros = 7
   End Enum

   Public Enum OperadoresRelacionales
      <Description("MAYOR IGUAL QUE")> MAYORIGUAL
      <Description("MENOR IGUAL QUE")> MENORIGUAL
      <Description("MAYOR QUE")> MAYOR
      <Description("MENOR QUE")> MENOR
      <Description("IGUAL QUE")> IGUAL
      <Description("DISTINTO QUE")> DISTINTO
   End Enum

   Public Enum SiNoDefault As Integer
      <Description("Por Defecto")> [DEFAULT] = 0
      <Description("Si")> SI = 1
      <Description("No")> NO = 2
   End Enum

   Public Enum TipoRefreshDashBoard As Integer
      <Description("Datos")> DATOS = 1
      <Description("Full")> FULL = 2
   End Enum

   Public Enum InformesCtaCte
      <Description("Informe de Cta. Cte. de Clientes")> CTACTE
      <Description("Informe de Cta. Cte. - Debe Haber")> CTACTEDH
      <Description("Informe de Cta. Cte. Detalle de Clientes")> CTACTEDET
      <Description("Consulta Cta. Cte. Det. de Clientes - Debe Haber")> CTACTEDETDH
   End Enum

   Public Enum ComprasPrecioCosto
      <Description("COSTO ACTUAL")> ACTUAL
      <Description("COSTO PROMEDIO PONDERADO")> PROMPOND
   End Enum

   Public Enum NecesarioResultanteTodos As Integer
      TODOS = 0
      NECESARIO = 1
      RESULTANTE = 2
   End Enum

   Private Shared _driverBase As String = "C:\"
   Public Shared Property DriverBase() As String
      Get
         Return _driverBase
      End Get
      Set(ByVal value As String)
         _driverBase = value
      End Set
   End Property

   Public Shared ReadOnly Property CarpetaEniac() As String
      Get
         Return DriverBase + "Eniac\"
      End Get
   End Property

   Public Shared ReadOnly Property CarpetaLOGs() As String
      Get
         Return DriverBase & "Eniac\" & My.Application.Info.ProductName & "\LOGs\"
      End Get
   End Property

   Public Enum ComparativoDiario_CampoTotalizar
      <Description("Cantidad")> CANTIDAD
      <Description("Importe")> IMPORTE
   End Enum
   Public Enum ComparativoDiario_ColumnasMostrar
      <Description("Ventas y Devoluciones")> SEPARADO
      <Description("Consolidado")> CONSOLIDADO
   End Enum

   Public Enum FormatoLike
      <Description("Contiene")> CONTIENE
      <Description("Comienza Con")> COMIENZA
      <Description("Finaliza Con")> FINALIZA
   End Enum

   Public Enum FormatoIvaCero
      <Description("No Gravado")> NOGRAVADO
      <Description("Exento")> EXENTO
      <Description("Gravado")> GRAVADO
      <Description("Zona Franca")> ZONAFRANCA
   End Enum

   Public Enum SemaforoCalculoMuestra
      Rentabilidad
      <Description("Contribución Marginal")> ContribucionMarginal
   End Enum

   Public Enum FacturacionOrdenesDeTitulo
      <Description("Vendedor - Caja")> VENDEDORCAJA
      <Description("Caja - Vendedor")> CAJAVENDEDOR
   End Enum

   Public Enum FacturacionOrdenesDeColor
      <Description("Vendedor")> VENDEDOR
      <Description("Caja")> CAJA
      <Description("Tipo Comprobante")> TIPOCOMPROBANTE
   End Enum

   Public Enum PeriodosCalendarios
      <Description("Día")> Dia
      <Description("Mes")> Mes
      <Description("Año")> Anio
   End Enum
   ''' <summary>
   ''' Facturacion y Facturacion Rapida.- --
   ''' </summary>
   Public Enum VisualizaPrecioCosto
      <Description("No Mostrar")> NOMOSTRAR
      <Description("Mostrar")> MOSTRAR
      <Description("Modificable")> MODIFICABLE
   End Enum
   ''' <summary>
   ''' Facturacion y Facturacion Rapida.- --
   ''' </summary>
   Public Enum BusquedasClientesFacturacion
      <Description("CUIT")> CUIT
      <Description("DOMICILIO")> DOMICILIO
      <Description("EMBARCACION"), Browsable(False)> EMBARCACION
      <Description("CAMA"), Browsable(False)> CAMA

   End Enum

   ''' <summary>
   ''' Facturacion y Facturacion Rapida.- --
   ''' </summary>
   Public Enum VendedorComprobanteInvocado
      <Description("NO")> NO
      <Description("Del Comprobante Invocado")> INVOCADO
      <Description("Asignado al Cliente")> CLIENTE
   End Enum

   Public Enum CotizacionDolarComprobanteInvocado
      <Description("Actual o del Invocador")> NO
      <Description("Del Comprobante Invocado")> INVOCADO
      <Description("Preguntar al usuario si difiere")> PREGUNTAR
   End Enum

   Public Shared Function GetFotoFromBites(foto As Byte()) As System.Drawing.Image
      If foto IsNot Nothing Then
         Using ms As MemoryStream = New MemoryStream(foto)
            Dim rIma As Image = Image.FromStream(ms)
            Return rIma
         End Using
      Else
         Return Nothing
      End If
   End Function

   Public Shared Function GetFotoFromImage(foto As System.Drawing.Image, extension As String) As Byte()
      Dim ms As MemoryStream = New MemoryStream()
      If extension.ToUpper() = ".PNG" Then
         foto.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
      Else
         foto.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
      End If
      Return ms.ToArray()
   End Function

   Public Shared Function EnumToArray(Of T)(Optional ordenar As Boolean = False) As IEnumerable(Of T)
      Dim enumArray = [Enum].GetValues(GetType(T)).OfType(Of T)()
      If ordenar Then
         Array.Sort([Enum].GetNames(GetType(T)).ToArray(), enumArray.ToArray())
      End If

      Return enumArray
   End Function

End Class