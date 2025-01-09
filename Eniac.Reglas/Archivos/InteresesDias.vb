Public Class InteresesDias
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "InteresesDias"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "InteresesDias"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.InteresDias)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.InteresDias)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.InteresDias)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.InteresesDias(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.InteresesDias(da).InteresesDias_GA()
   End Function
   Public Overloads Function GetAll(idInteres As Integer?) As DataTable
      Return New SqlServer.InteresesDias(da).InteresesDias_GA(idInteres)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.InteresDias.Columnas.DiasHasta.ToString()))
   End Function
   Public Function GetCodigoMaximo(campo As String) As Long
      Return New SqlServer.InteresesDias(da).GetCodigoMaximo(campo)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.InteresDias, tipo As TipoSP)
      Dim sqlC = New SqlServer.InteresesDias(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.InteresesDias_I(en.IdInteres, en.DiasDesde, en.DiasHasta, en.Interes)
         Case TipoSP._U
            sqlC.InteresesDias_U(en.IdInteres, en.DiasDesde, en.DiasHasta, en.Interes)
         Case TipoSP._D
            sqlC.InteresesDias_D(en.IdInteres, en.DiasDesde, en.DiasHasta)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.InteresDias, dr As DataRow)
      With o
         .IdInteres = dr.Field(Of Integer)(Entidades.InteresDias.Columnas.IdInteres.ToString())
         .DiasDesde = dr.Field(Of Integer)(Entidades.InteresDias.Columnas.DiasDesde.ToString())
         .DiasHasta = dr.Field(Of Integer)(Entidades.InteresDias.Columnas.DiasHasta.ToString())
         .Interes = dr.Field(Of Decimal)(Entidades.InteresDias.Columnas.Interes.ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.InteresDias)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.InteresDias)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.InteresDias)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overloads Sub Borrar(idInteres As Integer)
      Dim sqlC = New SqlServer.InteresesDias(da)
      sqlC.InteresesDias_D(idInteres, Nothing, Nothing)
   End Sub

   Public Overloads Sub Insertar(interesesDias As List(Of Entidades.InteresDias))
      For Each enDias In interesesDias
         EjecutaSP(enDias, TipoSP._I)
      Next
   End Sub

   Public Function Get1(idInteres As Integer, diasDesde As Integer, diasHasta As Integer) As DataTable
      Return New SqlServer.InteresesDias(da).InteresesDias_G1(idInteres, diasDesde, diasHasta)
   End Function
   Public Function GetUno(idInteres As Integer, diasDesde As Integer, diasHasta As Integer) As Entidades.InteresDias
      Return GetUno(idInteres, diasDesde, diasHasta, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idInteres As Integer, diasDesde As Integer, diasHasta As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.InteresDias
      Return CargaEntidad(Get1(idInteres, diasDesde, diasHasta),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.InteresDias(),
                          accion, Function() String.Format("No existen días de Interes para Id {0} desde {1:dd/MM/yyyy} hasta {2:dd/MM/yyyy}", idInteres, diasDesde, diasHasta))
   End Function

   Public Function GetTodas() As List(Of Entidades.InteresDias)
      Return GetTodas(Nothing)
   End Function

   Public Function GetTodas(idInteres As Integer?) As List(Of Entidades.InteresDias)
      Return CargaLista(GetAll(idInteres), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.InteresDias())
   End Function

   Public Function GetInteres(formaPago As Integer, cuotas As Integer, idInteres As Integer) As Decimal
      Return EjecutaConConexion(Function() New SqlServer.InteresesDias(da).GetInteres(formaPago, cuotas, idInteres))
   End Function

   Public Function GetInteresVentas(formaPago As Integer, cuotas As Integer, idInteres As Integer) As Decimal
      Return EjecutaConConexion(Function() New SqlServer.InteresesDias(da).GetInteresVentas(formaPago, cuotas, idInteres))
   End Function

   Public Function GetPorcInteresVentas(dias As Integer, idInteres As Integer) As Decimal
      Return EjecutaConConexion(Function() New SqlServer.InteresesDias(da).GetInteresVentasSegunDias(dias, idInteres))
   End Function

#End Region
End Class