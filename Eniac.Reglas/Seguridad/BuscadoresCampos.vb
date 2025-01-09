Imports System.Windows.Forms

Public Class BuscadoresCampos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess(CadenaSegura))
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("BuscadoresCampos", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConConexion(Sub() _Insertar(DirectCast(entidad, Entidades.BuscadorCampo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() _Actualizar(DirectCast(entidad, Entidades.BuscadorCampo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConConexion(Sub() _Borrar(DirectCast(entidad, Entidades.BuscadorCampo)))
   End Sub

   'Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
   '   Return New SqlServer.BuscadoresCampos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   'End Function

   'Public Overrides Function GetAll() As DataTable
   '   Return New SqlServer.BuscadoresCampos(da).Buscadores_GA()
   'End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.BuscadorCampo, tipo As TipoSP)
      Dim sqlC = New SqlServer.BuscadoresCampos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.BuscadoresCampos_I(en.IdBuscador, en.IdBuscadorNombreCampo, en.Orden, en.Titulo, en.Alineacion, en.Ancho, en.Formato, en.Condicion, en.ValorCondicion, en.ColorFilaCondicion)
         Case TipoSP._U
            sqlC.BuscadoresCampos_U(en.IdBuscador, en.IdBuscadorNombreCampo, en.Orden, en.Titulo, en.Alineacion, en.Ancho, en.Formato, en.Condicion, en.ValorCondicion, en.ColorFilaCondicion)
         Case TipoSP._D
            sqlC.BuscadoresCampos_D(en.IdBuscador, en.IdBuscadorNombreCampo)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.BuscadorCampo, dr As DataRow)
      With o
         o.IdBuscador = dr.Field(Of Integer)(Entidades.BuscadorCampo.Columnas.IdBuscador.ToString())
         o.IdBuscadorNombreCampo = dr.Field(Of String)(Entidades.BuscadorCampo.Columnas.IdBuscadorNombreCampo.ToString())
         o.Orden = dr.Field(Of Integer)(Entidades.BuscadorCampo.Columnas.Orden.ToString())
         o.Titulo = dr.Field(Of String)(Entidades.BuscadorCampo.Columnas.Titulo.ToString())
         o.Alineacion = CType(dr.Field(Of Integer)(Entidades.BuscadorCampo.Columnas.Alineacion.ToString()), DataGridViewContentAlignment)
         o.Ancho = dr.Field(Of Integer)(Entidades.BuscadorCampo.Columnas.Ancho.ToString())
         o.Formato = dr.Field(Of String)(Entidades.BuscadorCampo.Columnas.Formato.ToString())
         o.Condicion = dr.Field(Of String)(Entidades.BuscadorCampo.Columnas.Condicion.ToString()).StringToEnum(Entidades.BuscadorCampo.TipoCondicion.Igual)
         o.ValorCondicion = dr.Field(Of String)(Entidades.BuscadorCampo.Columnas.Valor.ToString())
         o.ColorFilaCondicion = dr.Field(Of String)(Entidades.BuscadorCampo.Columnas.ColorFila.ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.BuscadorCampo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.BuscadorCampo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.BuscadorCampo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Insertar(entidad As Entidades.Buscador)
      entidad.Campos.ForEach(
      Sub(en)
         en.IdBuscador = entidad.IdBuscador
         _Insertar(en)
      End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Buscador)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Buscador)
      _Borrar(New Entidades.BuscadorCampo() With {.IdBuscador = entidad.IdBuscador})
   End Sub

   Public Function GetTodos(idBuscador As Entidades.Buscador.Buscadores) As List(Of Entidades.BuscadorCampo)
      Return GetTodos(Convert.ToInt32(idBuscador))
   End Function
   Public Function GetTodos(idBuscador As Integer) As List(Of Entidades.BuscadorCampo)
      Return CargaLista(GetBuscadorCampos(idBuscador), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.BuscadorCampo)
   End Function
   'Public Function GetUno(idBuscador As Entidades.Buscador.Buscadores) As Entidades.BuscadorCampo
   '   Return GetUno(idBuscador, AccionesSiNoExisteRegistro.Excepcion)
   'End Function
   'Public Function GetUno(idBuscador As Integer) As Entidades.BuscadorCampo
   '   Return GetUno(idBuscador, AccionesSiNoExisteRegistro.Excepcion)
   'End Function
   'Public Function GetUno(idBuscador As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.BuscadorCampo
   '   Return CargaEntidad(GetBuscadorCampos(idBuscador), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.Buscador,
   '                       accion, Function() String.Format("No existe Buscador con IdBuscador = '{0}'", idBuscador))
   'End Function
   Public Function GetBuscadorCampos(IdBuscador As Integer) As DataTable
      Dim sql = New SqlServer.BuscadoresCampos(da)
      Return sql.GetBuscadorCampos(IdBuscador)
   End Function
#End Region

End Class