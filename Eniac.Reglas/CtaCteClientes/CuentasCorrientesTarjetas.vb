Public Class CuentasCorrientesTarjetas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.CuentaCorrienteTarjeta.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CuentaCorrienteTarjeta)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CuentaCorrienteTarjeta)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CuentaCorrienteTarjeta)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   <Obsolete("Usar GetAll(Integer, String, String, Integer, Integer)", True)>
   Public Overrides Function GetAll() As DataTable
      Throw New NotImplementedException("Usar GetAll(Integer, String, String, Integer, Integer)")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Return GetSql().CuentasCorrientesTarjetas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
#End Region
#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.CuentasCorrientesTarjetas
      Return New SqlServer.CuentasCorrientesTarjetas(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.CuentaCorrienteTarjeta, tipo As TipoSP)
      Dim sql = GetSql()
      Dim rConfig = New CuentasCorrientesTarjetas(da)
      Select Case tipo
         Case TipoSP._I
            If en.Orden = 0 Then
               en.Orden = GetOrdenMaximo(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante)
            End If
            sql.CuentasCorrientesTarjetas_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                            en.Orden, en.IdTarjeta, en.IdBanco,
                                            en.Monto, en.Cuotas, en.NumeroCupon, en.NumeroLote, en.IdTarjetaCupon)

         Case TipoSP._U
            sql.CuentasCorrientesTarjetas_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                            en.Orden, en.IdTarjeta, en.IdBanco,
                                            en.Monto, en.Cuotas, en.NumeroCupon, en.NumeroLote, en.IdTarjetaCupon)

         Case TipoSP._D
            sql.CuentasCorrientesTarjetas_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                            en.Orden, en.IdTarjeta, en.IdBanco)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CuentaCorrienteTarjeta, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(Entidades.CuentaCorrienteTarjeta.Columnas.IdTipoComprobante.ToString())
         .Letra = dr.Field(Of String)(Entidades.CuentaCorrienteTarjeta.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.CentroEmisor.ToString())
         .NumeroComprobante = dr.Field(Of Long)(Entidades.CuentaCorrienteTarjeta.Columnas.NumeroComprobante.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.Orden.ToString())
         .IdTarjeta = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjeta.ToString())
         .IdBanco = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdBanco.ToString())

         .IdTarjetaCupon = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjetaCupon.ToString())
         .Monto = dr.Field(Of Decimal)(Entidades.CuentaCorrienteTarjeta.Columnas.Monto.ToString())
         .Cuotas = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.Cuotas.ToString())
         .NumeroCupon = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.NumeroCupon.ToString())
         .NumeroLote = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.NumeroLote.ToString())
      End With
   End Sub
   Private Sub CargarUno(o As Entidades.VentaTarjeta, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdSucursal.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.Orden.ToString())
         .Banco = New Bancos(da).GetUno(dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdBanco.ToString()))
         .Tarjeta = New Reglas.Tarjetas(da)._GetUno(dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjeta.ToString()))

         .IdTarjetaCupon = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.IdTarjetaCupon.ToString())
         .Monto = dr.Field(Of Decimal)(Entidades.CuentaCorrienteTarjeta.Columnas.Monto.ToString())
         .Cuotas = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.Cuotas.ToString())
         .NumeroCupon = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.NumeroCupon.ToString())
         .NumeroLote = dr.Field(Of Integer)(Entidades.CuentaCorrienteTarjeta.Columnas.NumeroLote.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.CuentaCorrienteTarjeta)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.CuentaCorrienteTarjeta)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.CuentaCorrienteTarjeta)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(ctacte As Entidades.CuentaCorriente)
      _Borrar(New Entidades.CuentaCorrienteTarjeta() With {
                  .IdSucursal = ctacte.IdSucursal,
                  .IdTipoComprobante = ctacte.TipoComprobante.IdTipoComprobante,
                  .Letra = ctacte.Letra,
                  .CentroEmisor = ctacte.CentroEmisor,
                  .NumeroComprobante = ctacte.NumeroComprobante
               })
   End Sub

   Public Function Get1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                        orden As Integer, idTarjeta As Integer, idBanco As Integer) As DataTable
      Return GetSql().CuentasCorrientesTarjetas_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                   orden, idTarjeta, idBanco)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          orden As Integer, idTarjeta As Integer, idBanco As Integer) As Entidades.CuentaCorrienteTarjeta
      Return GetUno(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                    orden, idTarjeta, idBanco,
                    AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                          orden As Integer, idTarjeta As Integer, idBanco As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CuentaCorrienteTarjeta
      Return CargaEntidad(Get1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                               orden, idTarjeta, idBanco), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteTarjeta(),
                          accion, Function() String.Format("No existe Tarjeta con Id: {6} del Banco: {7} en la Cta Cte {0}/{1} {2} {3:0000}-{4:00000000} {5}",
                                                           idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                           orden, idTarjeta, idBanco))
   End Function
   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.CuentaCorrienteTarjeta)
      Return CargaLista(GetAll(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CuentaCorrienteTarjeta())
   End Function
   'TODO: Eventalmente modificar la clase para que use CuentasCorrientesTarjetas en lugar de VentasTarjetas.
   '      El problema es que hay que repasar muchos puntos críticos del sistema para asegurarse de no romper.
   Friend Function GetTodosAsVentasTarjetas(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As List(Of Entidades.VentaTarjeta)
      Return CargaLista(GetSql().CuentasCorrientesTarjetas_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.VentaTarjeta())
   End Function
   Public Overloads Function GetOrdenMaximo(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As Integer
      Return GetSql().GetOrdenMaximo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
#End Region

End Class
