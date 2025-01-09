Public Class Buscadores
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess(CadenaSegura))
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Buscadores", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConConexion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Buscador), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Buscador), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Buscador), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.Buscadores(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Buscadores(da).Buscadores_GA()
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.Buscador, tipo As TipoSP)
      Dim sqlC = New SqlServer.Buscadores(da)
      Dim rCampos = New BuscadoresCampos(da)
      Select Case tipo
         Case TipoSP._I
            Throw New NotImplementedException("No se puede agregar un buscador desde el sistema")
            'sqlC.Buscadores_I(en.IdBuscador, en.Titulo, en.AnchoAyuda, en.IniciaConFocoEn, en.ColumnaBusquedaInicial)
         Case TipoSP._U
            sqlC.Buscadores_U(en.IdBuscador, en.Titulo, en.AnchoAyuda, en.IniciaConFocoEn, en.ColumnaBusquedaInicial)
            rCampos._Actualizar(en)
         Case TipoSP._D
            Throw New NotImplementedException("No se puede borrar un buscador desde el sistema")
            'sqlC.Buscadores_D(en.IdBuscador)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.Buscador, dr As DataRow)
      With o
         o.IdBuscador = dr.Field(Of Integer)(Entidades.Buscador.Columnas.IdBuscador.ToString())
         o.Titulo = dr.Field(Of String)(Entidades.Buscador.Columnas.Titulo.ToString())
         o.AnchoAyuda = dr.Field(Of Integer)(Entidades.Buscador.Columnas.AnchoAyuda.ToString())
         o.IniciaConFocoEn = dr.Field(Of String)(Entidades.Buscador.Columnas.IniciaConFocoEn.ToString()).StringToEnum(Entidades.Buscador.IniciaConFocoEnList.Grilla)
         o.ColumnaBusquedaInicial = dr.Field(Of String)(Entidades.Buscador.Columnas.ColumaBusquedaInicial.ToString())

         o.Campos = New BuscadoresCampos(da).GetTodos(o.IdBuscador)
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Function GetUno(titulo As String) As Entidades.Buscador
      Return GetUno(titulo, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(titulo As String, accion As AccionesSiNoExisteRegistro) As Entidades.Buscador
      Return CargaEntidad(GetBuscador(titulo), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.Buscador,
                          accion, Function() String.Format("No existe Buscador con Titulo = '{0}'", titulo))
   End Function
   Public Function GetUno(idBuscador As Entidades.Buscador.Buscadores) As Entidades.Buscador
      Return GetUno(idBuscador, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idBuscador As Integer) As Entidades.Buscador
      Return GetUno(idBuscador, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idBuscador As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.Buscador
      Return CargaEntidad(GetBuscador(idBuscador), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.Buscador,
                          accion, Function() String.Format("No existe Buscador con IdBuscador = '{0}'", idBuscador))
   End Function
   'Public Function GetBuscador(titulo As String) As DataTable
   '   Return EjecutaConConexion(Function() _GetBuscador(titulo))
   'End Function
   Public Function GetBuscador(titulo As String) As DataTable
      Dim sql = New SqlServer.Buscadores(da)
      Return sql.GetBuscador(titulo, idBuscador:=Nothing)
   End Function
   Public Function GetBuscador(idBuscador As Entidades.Buscador.Buscadores) As DataTable
      Return GetBuscador(CInt(idBuscador)) ' EjecutaConConexion(Function() GetBuscador(idBuscador))
   End Function
   'Public Function GetBuscador(idBuscador As Integer) As DataTable
   '   Return EjecutaConConexion(Function() _GetBuscador(idBuscador))
   'End Function
   Public Function GetBuscador(idBuscador As Integer) As DataTable
      Dim sql = New SqlServer.Buscadores(da)
      Return sql.GetBuscador(titulo:=Nothing, idBuscador)
   End Function
   Public Function GetBuscadorCampos(idBuscador As Integer) As DataTable
      Return New BuscadoresCampos(da).GetBuscadorCampos(idBuscador)
   End Function
#End Region

End Class