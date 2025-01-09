Public Class Intereses
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.Interes.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Interes)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Interes)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Interes)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Intereses(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Intereses(da).Intereses_GA()
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.Intereses(da).GetCodigoMaximo()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Interes, tipo As TipoSP)
      Dim rDias = New InteresesDias(da)
      Dim sqlC = New SqlServer.Intereses(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Intereses_I(en.IdInteres, en.NombreInteres, en.AdicionalProporcinalDias, en.MetodoParaDeterminarRango, en.UtilizaVigencia, en.FechaVigenciaDesde, en.FechaVigenciaHasta,
                             en.VencimientoExcluyeSabado, en.VencimientoExcluyeDomingo, en.VencimientoExcluyeFeriados)
            rDias.Insertar(en.InteresesDias)
         Case TipoSP._U
            sqlC.Intereses_U(en.IdInteres, en.NombreInteres, en.AdicionalProporcinalDias, en.MetodoParaDeterminarRango, en.UtilizaVigencia, en.FechaVigenciaDesde, en.FechaVigenciaHasta,
                             en.VencimientoExcluyeSabado, en.VencimientoExcluyeDomingo, en.VencimientoExcluyeFeriados)
            rDias.Borrar(en.IdInteres)
            rDias.Insertar(en.InteresesDias)
         Case TipoSP._D
            rDias.Borrar(en.IdInteres)
            sqlC.Intereses_D(en.IdInteres)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Interes, dr As DataRow)
      With o
         .IdInteres = dr.Field(Of Integer)(Entidades.Interes.Columnas.IdInteres.ToString())
         .NombreInteres = dr.Field(Of String)(Entidades.Interes.Columnas.NombreInteres.ToString())
         .AdicionalProporcinalDias = dr.Field(Of Decimal)(Entidades.Interes.Columnas.AdicionalProporcinalDias.ToString())
         .MetodoParaDeterminarRango = dr.Field(Of String)(Entidades.Interes.Columnas.MetodoParaDeterminarRango.ToString())

         '-.PE-32074.-
         .UtilizaVigencia = dr.Field(Of Boolean)(Entidades.Interes.Columnas.UtilizaVigencia.ToString())
         .FechaVigenciaDesde = dr.Field(Of Date?)(Entidades.Interes.Columnas.FechaVigenciaDesde.ToString())
         .FechaVigenciaHasta = dr.Field(Of Date?)(Entidades.Interes.Columnas.FechaVigenciaHasta.ToString())

         .VencimientoExcluyeSabado = dr.Field(Of Boolean)(Entidades.Interes.Columnas.VencimientoExcluyeSabado.ToString())
         .VencimientoExcluyeDomingo = dr.Field(Of Boolean)(Entidades.Interes.Columnas.VencimientoExcluyeDomingo.ToString())
         .VencimientoExcluyeFeriados = dr.Field(Of Boolean)(Entidades.Interes.Columnas.VencimientoExcluyeFeriados.ToString())

         'Lo dejo a mi pesar porque no se donde puede impactar esto si lo saco.
         Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
         If blnAbreConexion Then da.OpenConection()
         Try
            .InteresesDias = New InteresesDias(da).GetTodas(.IdInteres)
         Finally
            If blnAbreConexion Then da.CloseConection()
         End Try
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.Interes)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Interes)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Interes)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idInteres As Integer) As Entidades.Interes
      Return GetUno(idInteres, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idInteres As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Interes
      Return CargaEntidad(New SqlServer.Intereses(da).Intereses_G1(idInteres),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Interes(),
                          accion, String.Format("No existe Interes con código {0}", idInteres))
   End Function
   Public Function GetTodos() As List(Of Entidades.Interes)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Interes())
   End Function

#End Region
End Class