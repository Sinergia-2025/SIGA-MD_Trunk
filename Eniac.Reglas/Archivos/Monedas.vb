Public Class Monedas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Monedas"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Moneda), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Moneda), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Moneda), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Monedas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Monedas(da).Monedas_GA()
   End Function

   Public Sub ActualizarCotizacion(idMoneda As Integer, cotizacion As Decimal)
      Dim moneda = GetUna(idMoneda)
      moneda.FactorConversion = cotizacion
      Actualizar(moneda)
   End Sub
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Moneda, tipo As TipoSP)
      Dim rAudit = New Auditorias(da)
      Dim sql = New SqlServer.Monedas(da)

      Select Case tipo
         Case TipoSP._I
            sql.Monedas_I(en.IdMoneda, en.NombreMoneda, en.IdTipoMoneda, en.OperadorConversion, en.FactorConversion, en.IdBanco, en.Simbolo, en.Predeterminada)
            rAudit.Insertar("Monedas", Entidades.OperacionesAuditorias.Alta, actual.Nombre, String.Format("IdMoneda = '{0}'", en.IdMoneda), False)

         Case TipoSP._U
            sql.Monedas_U(en.IdMoneda, en.NombreMoneda, en.IdTipoMoneda, en.OperadorConversion, en.FactorConversion, en.IdBanco, en.Simbolo, en.Predeterminada)
            rAudit.Insertar("Monedas", Entidades.OperacionesAuditorias.Modificacion, actual.Nombre, String.Format("IdMoneda = '{0}'", en.IdMoneda), False)

         Case TipoSP._D
            rAudit.Insertar("Monedas", Entidades.OperacionesAuditorias.Baja, actual.Nombre, String.Format("IdMoneda = '{0}'", en.IdMoneda), False)
            sql.Monedas_D(en.IdMoneda)

      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.Moneda, dr As DataRow)
      With o
         .IdMoneda = Integer.Parse(dr(Entidades.Moneda.Columnas.IdMoneda).ToString())
         .NombreMoneda = dr(Entidades.Moneda.Columnas.NombreMoneda).ToString()
         .IdTipoMoneda = dr(Entidades.Moneda.Columnas.IdTipoMoneda).ToString()
         .OperadorConversion = dr(Entidades.Moneda.Columnas.OperadorConversion).ToString()
         .FactorConversion = Decimal.Parse(dr(Entidades.Moneda.Columnas.FactorConversion).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Moneda.Columnas.IdBanco).ToString()) Then
            .IdBanco = Integer.Parse(dr(Entidades.Moneda.Columnas.IdBanco).ToString())
         End If
         .Simbolo = dr(Entidades.Moneda.Columnas.Simbolo).ToString()
         .Predeterminada = CBool(dr(Entidades.Moneda.Columnas.Predeterminada).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.Moneda)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.Moneda())
   End Function
   Public Function GetUna(idMoneda As Integer) As Entidades.Moneda
      Return GetUna(idMoneda, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idMoneda As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Moneda
      Return CargaEntidad(New SqlServer.Monedas(da).Monedas_G1(idMoneda),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.Moneda(),
                          accion, Function() String.Format("No existe moneda con ID: {0}", idMoneda))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Monedas(da).GetCodigoMaximo()
   End Function

   Public Function GetAuditoriasMonedas(fechaDesde As Date, fechaHasta As Date, idMoneda As Integer, tipoOperacion As String) As DataTable

      Return New SqlServer.Monedas(da).GetAuditoriasMonedas(fechaDesde, fechaHasta, idMoneda, tipoOperacion)

   End Function
#End Region

End Class