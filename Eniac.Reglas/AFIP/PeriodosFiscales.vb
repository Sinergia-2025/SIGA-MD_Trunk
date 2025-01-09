Public Class PeriodosFiscales
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.PeriodoFiscal.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.PeriodoFiscal)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.PeriodoFiscal)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.PeriodoFiscal)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.PeriodosFiscales(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.PeriodosFiscales(da).PeriodosFiscales_GA(actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetAll2(idEmpresa As Integer, estado As String) As DataTable
      Return New SqlServer.PeriodosFiscales(da).PeriodosFiscales_GA(idEmpresa, estado)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.PeriodoFiscal, tipo As TipoSP)
      Dim sql = New SqlServer.PeriodosFiscales(da)
      Select Case tipo
         Case TipoSP._I
            sql.PeriodosFiscales_I(en.IdEmpresa, en.PeriodoFiscal,
                                   en.TotalNetoVentas, en.TotalImpuestosVentas, en.TotalVentas,
                                   en.TotalNetoCompras, en.TotalImpuestosCompras, en.TotalNetoCompras,
                                   en.Posicion,
                                   en.TotalRetenciones, en.TotalPercepciones, en.PosicionFinal,
                                   en.FechaCierre, en.UsuarioCierre, en.VentasHabilitadas)
         Case TipoSP._U
            If Not en.VentasHabilitadas Then
               Dim enActual = GetUno(en.IdEmpresa, en.PeriodoFiscal, AccionesSiNoExisteRegistro.Excepcion)
               If enActual.VentasHabilitadas Then
                  Dim rVtaNro = New VentasNumeros(da)
                  Dim controlNumeracion = rVtaNro.ControlSaltoNumeracion(en.IdEmpresa, {en.PeriodoFiscal}.ToList())
                  If controlNumeracion.Any() Then
                     Dim msg = String.Format("No es posible deshabilitar las ventas del período fiscal {1}.{0}{0}Existen {2} saltos en la numeración de ventas.",
                                             Environment.NewLine, en.PeriodoFiscal, controlNumeracion.Count)
                     Throw New Exception(msg)
                  End If
               End If
            End If

            sql.PeriodosFiscales_U(en.IdEmpresa, en.PeriodoFiscal,
                                   en.TotalNetoVentas, en.TotalImpuestosVentas, en.TotalVentas,
                                   en.TotalNetoCompras, en.TotalImpuestosCompras, en.TotalNetoCompras,
                                   en.Posicion,
                                   en.TotalRetenciones, en.TotalPercepciones, en.PosicionFinal,
                                   en.FechaCierre, en.UsuarioCierre, en.VentasHabilitadas)

         Case TipoSP._D
            sql.PeriodosFiscales_D(en.IdEmpresa, en.PeriodoFiscal)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.PeriodoFiscal, dr As DataRow)
      With o
         .IdEmpresa = dr.Field(Of Integer)(Entidades.PeriodoFiscal.Columnas.IdEmpresa.ToString())
         .PeriodoFiscal = dr.Field(Of Integer)(Entidades.PeriodoFiscal.Columnas.PeriodoFiscal.ToString())

         .TotalNetoVentas = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalNetoVentas.ToString())
         .TotalImpuestosVentas = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalImpuestosVentas.ToString())
         .TotalVentas = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalVentas.ToString())
         .TotalNetoCompras = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalNetoCompras.ToString())
         .TotalImpuestosCompras = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalImpuestosCompras.ToString())
         .TotalCompras = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalCompras.ToString())
         .Posicion = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.Posicion.ToString())
         .TotalRetenciones = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalRetenciones.ToString())
         .TotalPercepciones = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.TotalPercepciones.ToString())
         .PosicionFinal = dr.Field(Of Decimal)(Entidades.PeriodoFiscal.Columnas.PosicionFinal.ToString())

         .FechaCierre = dr.Field(Of Date?)(Entidades.PeriodoFiscal.Columnas.FechaCierre.ToString()).IfNull()
         .UsuarioCierre = dr.Field(Of String)(Eniac.Entidades.PeriodoFiscal.Columnas.UsuarioCierre.ToString()).IfNull()

         .VentasHabilitadas = dr.Field(Of Boolean)(Entidades.PeriodoFiscal.Columnas.VentasHabilitadas.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.PeriodoFiscal)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.PeriodoFiscal)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.PeriodoFiscal)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodos() As List(Of Entidades.PeriodoFiscal)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PeriodoFiscal())
   End Function

   Public Function GetUno(idEmpresa As Integer, periodoFiscal As Integer) As Entidades.PeriodoFiscal
      Return GetUno(idEmpresa, periodoFiscal, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idEmpresa As Integer, periodoFiscal As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.PeriodoFiscal
      Return CargaEntidad(Get1(idEmpresa, periodoFiscal), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.PeriodoFiscal(),
                          accion, Function() String.Format("No existe el Periodo Fiscal {0} en la empresa {1}.", periodoFiscal, idEmpresa))
   End Function

   Public Function Get1(idEmpresa As Integer, PeriodoFiscal As Integer) As DataTable
      Return New SqlServer.PeriodosFiscales(da).PeriodosFiscales_G1(idEmpresa, PeriodoFiscal)
   End Function

   Public Function GetPeriodoMaximo(idEmpresa As Integer) As Integer
      Return New SqlServer.PeriodosFiscales(da).PeriodosFiscales_GetPeriodoMaximo(idEmpresa)
   End Function

   Public Sub CrearUnoEnBlanco(PeriodoFiscal As Integer)
      Dim PF = New Entidades.PeriodoFiscal()
      With PF
         .IdEmpresa = actual.Sucursal.IdEmpresa
         .PeriodoFiscal = PeriodoFiscal
         .TotalNetoVentas = 0
         .TotalImpuestosVentas = 0
         .TotalVentas = 0
         .TotalNetoCompras = 0
         .TotalImpuestosCompras = 0
         .TotalCompras = 0

         .VentasHabilitadas = Publicos.AFIPHabilitaVentasPeriodoAutomaticamente
      End With

      Insertar(PF)
   End Sub

   Public Sub ActualizarPosicion(idEmpresa As Integer, periodoFiscal As Integer,
                                 importeNetoVentas As Decimal, importeImpuestosVentas As Decimal, importeVentas As Decimal,
                                 importeNetoCompras As Decimal, importeImpuestosCompras As Decimal, importeCompras As Decimal,
                                 importeRetenciones As Decimal, importePercepciones As Decimal)
      Dim sql = New SqlServer.PeriodosFiscales(da)
      sql.PeriodosFiscales_UPosicion(idEmpresa, periodoFiscal,
                                     importeNetoVentas, importeImpuestosVentas, importeVentas,
                                     importeNetoCompras, importeImpuestosCompras, importeCompras,
                                     importeRetenciones, importePercepciones)
   End Sub

#End Region

End Class