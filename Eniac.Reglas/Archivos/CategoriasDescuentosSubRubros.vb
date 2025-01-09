Public Class CategoriasDescuentosSubRubros
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "CategoriasDescuentosSubRubros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CategoriasDescuentosSubRubros), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CategoriasDescuentosSubRubros), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.CategoriasDescuentosSubRubros), TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.CategoriasDescuentosSubRubros(da).CategoriasDescuentosSubRubros_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CategoriasDescuentosSubRubros, tipo As TipoSP)
      Dim sqlC As SqlServer.CategoriasDescuentosSubRubros = New SqlServer.CategoriasDescuentosSubRubros(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CategoriasDescuentosSubRubros_I(en.IdCategoria, en.IdSubRubro, en.IdRubro, en.DescuentoRecargoPorc1)
         Case TipoSP._U
            sqlC.CategoriasDescuentosSubRubros_U(en.IdCategoria, en.IdSubRubro, en.IdRubro, en.DescuentoRecargoPorc1)
         Case TipoSP._D
            sqlC.CategoriasDescuentosSubRubros_D(en.IdCategoria, en.IdSubRubro, en.IdRubro)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CategoriasDescuentosSubRubros, dr As DataRow)
      With o
         .IdCategoria = dr.Field(Of Integer)(Entidades.CategoriasDescuentosSubRubros.Columnas.IdCategoria.ToString())
         .IdSubRubro = dr.Field(Of Integer)(Entidades.CategoriasDescuentosSubRubros.Columnas.IdSubRubro.ToString())
         .IdRubro = dr.Field(Of Integer)(Entidades.CategoriasDescuentosSubRubros.Columnas.IdRubro.ToString())
         .DescuentoRecargoPorc1 = dr.Field(Of Decimal?)(Entidades.CategoriasDescuentosSubRubros.Columnas.DescuentoRecargoPorc1.ToString()).IfNull()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetPorId(idCategoria As Integer) As DataTable
      Return New SqlServer.CategoriasDescuentosSubRubros(da).CategoriasDescuentosSubRubros_GetAll(idCategoria)
   End Function

   Public Function GetPorNombreLike(nombre As String) As DataTable
      Return New SqlServer.CategoriasDescuentosSubRubros(da).CategoriasDescuentosSubRubros_G_PorRubroNombre(nombre, False)
   End Function

   Public Function GetUno(idCategoria As Integer) As Entidades.CategoriasDescuentosSubRubros
      Return CargaEntidad(New SqlServer.CategoriasDescuentosSubRubros(da).CategoriasDescuentosSubRubros_GetAll(idCategoria),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriasDescuentosSubRubros(),
                        AccionesSiNoExisteRegistro.Vacio, "")
   End Function

   Public Function GetTodos(idCategoria As Integer) As List(Of Entidades.CategoriasDescuentosSubRubros)
      Return CargaLista(New SqlServer.CategoriasDescuentosSubRubros(da).CategoriasDescuentosSubRubros_GetAll(idCategoria),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriasDescuentosSubRubros())
   End Function

   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.CategoriasDescuentosSubRubros(da).CategoriasDescuentosSubRubros_G_PorRubroNombre(nombre, True)
   End Function
#End Region

End Class