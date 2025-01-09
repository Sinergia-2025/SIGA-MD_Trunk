Public Class UnidadesDeMedidasConversiones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.UnidadDeMedidaConversion.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.UnidadDeMedidaConversion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.UnidadDeMedidaConversion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.UnidadDeMedidaConversion)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSql().UnidadesDeMedidasConversiones_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSql() As SqlServer.UnidadesDeMedidasConversiones
      Return New SqlServer.UnidadesDeMedidasConversiones(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.UnidadDeMedidaConversion, tipo As TipoSP)
      Dim sql = GetSql()
      Select Case tipo
         Case TipoSP._I
            sql.UnidadesDeMedidasConversiones_I(en.IdUnidadMedidaDesde, en.IdUnidadMedidaHacia, en.FactorConversion, en.Fija)

         Case TipoSP._U
            sql.UnidadesDeMedidasConversiones_U(en.IdUnidadMedidaDesde, en.IdUnidadMedidaHacia, en.FactorConversion, en.Fija)

         Case TipoSP._D
            sql.UnidadesDeMedidasConversiones_D(en.IdUnidadMedidaDesde, en.IdUnidadMedidaHacia)

      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.UnidadDeMedidaConversion, dr As DataRow)
      With o
         .IdUnidadMedidaDesde = dr.Field(Of String)(Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaDesde.ToString())
         .IdUnidadMedidaHacia = dr.Field(Of String)(Entidades.UnidadDeMedidaConversion.Columnas.IdUnidadMedidaHacia.ToString())
         .FactorConversion = dr.Field(Of Decimal)(Entidades.UnidadDeMedidaConversion.Columnas.FactorConversion.ToString())
         .Fija = dr.Field(Of Boolean)(Entidades.UnidadDeMedidaConversion.Columnas.Fija.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.UnidadDeMedidaConversion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.UnidadDeMedidaConversion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.UnidadDeMedidaConversion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String) As DataTable
      Return GetSql().UnidadesDeMedidasConversiones_G1(idUnidadMedidaDesde, idUnidadMedidaHacia)
   End Function
   Public Function GetUno(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String) As Entidades.UnidadDeMedidaConversion
      Return GetUno(idUnidadMedidaDesde, idUnidadMedidaHacia, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String, accion As AccionesSiNoExisteRegistro) As Entidades.UnidadDeMedidaConversion
      Return CargaEntidad(Get1(idUnidadMedidaDesde, idUnidadMedidaHacia),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UnidadDeMedidaConversion(),
                          accion, Function() String.Format("No existe Conversión de Unidad de Mededa Desde: {0} / Hacia: {1}",
                                                           idUnidadMedidaDesde, idUnidadMedidaHacia))
   End Function

   Public Function GetFactorConversion(idUnidadMedidaDesde As String, idUnidadMedidaHacia As String) As Entidades.UnidadDeMedidaConversion
      Dim umc = GetUno(idUnidadMedidaDesde, idUnidadMedidaHacia, AccionesSiNoExisteRegistro.Nulo)
      If umc IsNot Nothing Then
         Return umc
      End If
      umc = GetUno(idUnidadMedidaHacia, idUnidadMedidaDesde, AccionesSiNoExisteRegistro.Nulo)
      If umc IsNot Nothing Then
         Return umc.GetInvertida()
      End If
      Return Nothing
   End Function

   Public Function GetTodos() As List(Of Entidades.UnidadDeMedidaConversion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.UnidadDeMedidaConversion())
   End Function

#End Region
End Class