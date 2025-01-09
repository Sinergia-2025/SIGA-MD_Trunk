Public Class ZonasGeograficas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.ZonaGeografica.TableName
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Inserta(DirectCast(entidad, Entidades.ZonaGeografica)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.ZonaGeografica)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.ZonaGeografica)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.ZonaGeografica(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ZonaGeografica(da).ZonaGeografica_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ZonaGeografica, tipo As TipoSP)
      Dim sql = New SqlServer.ZonaGeografica(da)
      Select Case tipo
         Case TipoSP._I
            sql.ZonaGeografica_I(en.IdZonaGeografica, en.NombreZonaGeografica)
         Case TipoSP._U
            sql.ZonaGeografica_U(en.IdZonaGeografica, en.NombreZonaGeografica)
         Case TipoSP._D
            sql.ZonaGeografica_D(en.IdZonaGeografica)
      End Select
   End Sub

   Private Sub CargarUno(dr As DataRow, o As Entidades.ZonaGeografica)
      With o
         .IdZonaGeografica = dr.Field(Of String)(Entidades.ZonaGeografica.Columnas.IdZonaGeografica.ToString())
         .NombreZonaGeografica = dr.Field(Of String)(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Inserta(entidad As Entidades.ZonaGeografica)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.ZonaGeografica)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.ZonaGeografica)
      EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Function GetTodas() As List(Of Entidades.ZonaGeografica)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(dr, o), Function() New Entidades.ZonaGeografica())
   End Function

   Public Function GetUno(idZonaGeografica As String) As Entidades.ZonaGeografica
      Return GetUno(idZonaGeografica, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idZonaGeografica As String, accion As AccionesSiNoExisteRegistro) As Entidades.ZonaGeografica
      Return CargaEntidad(New SqlServer.ZonaGeografica(da).ZonaGeografica_G1(idZonaGeografica),
                          Sub(o, dr) CargarUno(dr, o), Function() New Entidades.ZonaGeografica(),
                          accion, Function() String.Format("No existe Zona Geográfica con Id {0}", idZonaGeografica))
   End Function

   Public Function GetPrimerIdZonaGeografica() As String
      Dim dt = New SqlServer.ZonaGeografica(da).ZonaGeografica_GetPrimerZonaGeografica()
      Return If(dt.Rows.Count = 0, String.Empty, dt.Rows(0).Field(Of String)(Entidades.ZonaGeografica.Columnas.IdZonaGeografica.ToString()))
   End Function

   Public Function GetPorCodigo(codigo As String) As DataTable
      Return New SqlServer.ZonaGeografica(da).ZonaGeografica_GA_PorCodigo(codigo, exacto:=False)
   End Function
   Public Function GetPorCodigoExacto(codigo As String) As DataTable
      Return New SqlServer.ZonaGeografica(da).ZonaGeografica_GA_PorCodigo(codigo, exacto:=True)
   End Function

   Public Function GetPorNombre(nombre As String) As DataTable
      Return New SqlServer.ZonaGeografica(da).ZonaGeografica_GA_PorNombre(nombre, exacto:=False)
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.ZonaGeografica(da).ZonaGeografica_GA_PorNombre(nombre, exacto:=True)
   End Function

#End Region

End Class