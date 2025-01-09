#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class CategoriasDescuentosRubros
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasDescuentosRubros"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.CategoriasDescuentosRubros)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.CategoriasDescuentosRubros)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.CategoriasDescuentosRubros)))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasDescuentosRubros(Me.da).CategoriasDescuentosRubros_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.CategoriasDescuentosRubros, tipo As TipoSP)
      Dim sqlC As SqlServer.CategoriasDescuentosRubros = New SqlServer.CategoriasDescuentosRubros(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CategoriasDescuentosRubros_I(en.IdCategoria, en.IdRubro, en.DescuentoRecargoPorc1)
         Case TipoSP._U
            sqlC.CategoriasDescuentosRubros_U(en.IdCategoria, en.IdRubro, en.DescuentoRecargoPorc1)
         Case TipoSP._D
            sqlC.CategoriasDescuentosRubros_D(en.IdCategoria, en.IdRubro)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.CategoriasDescuentosRubros, dr As DataRow)
      With o
         .IdCategoria = dr.ValorNumericoPorDefecto(Entidades.CategoriasDescuentosRubros.Columnas.IdCategoria.ToString(), 0I)
         .IdRubro = dr.ValorNumericoPorDefecto(Entidades.CategoriasDescuentosRubros.Columnas.IdRubro.ToString(), 0I)
         .DescuentoRecargoPorc1 = dr.ValorNumericoPorDefecto(Entidades.CategoriasDescuentosRubros.Columnas.DescuentoRecargoPorc1.ToString(), 0D)
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Friend Sub _Insertar(entidad As Entidades.CategoriasDescuentosRubros)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Friend Sub _Actualizar(entidad As Entidades.CategoriasDescuentosRubros)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Friend Sub _Borrar(entidad As Entidades.CategoriasDescuentosRubros)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Function GetPorId(idCategoria As Integer) As DataTable
      Return New SqlServer.CategoriasDescuentosRubros(Me.da).CategoriasDescuentosRubros_GetAll(idCategoria)
   End Function

   Public Function GetPorNombreLike(nombre As String) As DataTable
      Return New SqlServer.CategoriasDescuentosRubros(da).CategoriasDescuentosRubros_G_PorRubroNombre(nombre, exacto:=False)
   End Function
   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.CategoriasDescuentosRubros(da).CategoriasDescuentosRubros_G_PorRubroNombre(nombre, exacto:=True)
   End Function

   Public Function GetUno(idCategoria As Integer, idRubro As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.CategoriasDescuentosRubros
      Return CargaEntidad(New SqlServer.CategoriasDescuentosRubros(Me.da).CategoriasDescuentosRubros_G1(idCategoria, idRubro),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriasDescuentosRubros(),
                          accion, Function() String.Format("No existe Descuento para la Categoría {0} y Rubro {1}", idCategoria, idRubro))
   End Function
   Public Function GetTodos(idCategoria As Integer) As List(Of Entidades.CategoriasDescuentosRubros)
      Return CargaLista(GetPorId(idCategoria),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CategoriasDescuentosRubros())
   End Function
#End Region

End Class