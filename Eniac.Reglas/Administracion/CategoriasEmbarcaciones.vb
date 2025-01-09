Imports Eniac.Reglas

Public Class CategoriasEmbarcaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CategoriasEmbarcaciones"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasEmbarcaciones"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CategoriasEmbarcaciones = New SqlServer.CategoriasEmbarcaciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasEmbarcaciones(Me.da).CategoriasEmbarcacion_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdCategoriaEmbarcacion) AS Maximo")
         .Append(" FROM CategoriasEmbarcaciones")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CategoriaEmbarcacion = DirectCast(entidad, Entidades.CategoriaEmbarcacion)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CategoriasEmbarcaciones = New SqlServer.CategoriasEmbarcaciones(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.CategoriasEmbarcacion_I(en.IdCategoriaEmbarcacion, en.NombreCategoriaEmbarcacion, en.IdTipoEmbarcacion, en.ImporteExpensas, en.ImporteAlquiler, en.PorcDescAlquiler, en.ImporteGastosAdmin, en.ImporteGastosIntermAlq, en.ExpensasRelacionCategoria,
                                            en.Alto, en.Ancho, en.Largo, en.IdInteres)
            Case TipoSP._U
               sqlC.CategoriasEmbarcacion_U(en.IdCategoriaEmbarcacion, en.NombreCategoriaEmbarcacion, en.IdTipoEmbarcacion, en.ImporteExpensas, en.ImporteAlquiler, en.PorcDescAlquiler, en.ImporteGastosAdmin, en.ImporteGastosIntermAlq, en.ExpensasRelacionCategoria,
                                            en.Alto, en.Ancho, en.Largo, en.IdInteres)
            Case TipoSP._D
               sqlC.CategoriasEmbarcacion_D(en.IdCategoriaEmbarcacion)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CategoriaEmbarcacion, ByVal dr As DataRow)
      With o
         .IdCategoriaEmbarcacion = Integer.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.IdCategoriaEmbarcacion.ToString()).ToString())
         .NombreCategoriaEmbarcacion = dr(Entidades.CategoriaEmbarcacion.Columnas.NombreCategoriaEmbarcacion.ToString()).ToString()
         .IdTipoEmbarcacion = Integer.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.IdTipoEmbarcacion.ToString()).ToString())
         .ImporteExpensas = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.ImporteExpensas.ToString()).ToString())
         .ImporteAlquiler = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.ImporteAlquiler.ToString()).ToString())
         .PorcDescAlquiler = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.PorcDescAlquiler.ToString()).ToString())
         .ImporteGastosAdmin = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosAdmin.ToString()).ToString())
         .ImporteGastosIntermAlq = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.ImporteGastosIntermAlq.ToString()).ToString())
         .ExpensasRelacionCategoria = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.ExpensasRelacionCategoria.ToString()).ToString())

         .Alto = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.Alto.ToString()).ToString())
         .Ancho = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.Ancho.ToString()).ToString())
         .Largo = Decimal.Parse(dr(Entidades.CategoriaEmbarcacion.Columnas.Largo.ToString()).ToString())

         'PE-31303
         'If Not String.IsNullOrWhiteSpace(dr(Entidades.Categoria.Columnas.IdInteres.ToString()).ToString()) Then
         '   .Interes = New Eniac.Reglas.Intereses(da).GetUno(Integer.Parse(dr(Entidades.Categoria.Columnas.IdInteres.ToString()).ToString()))
         'End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.Categoria.Columnas.IdInteres.ToString()).ToString()) Then
            .Interes = New Intereses().GetUno(Integer.Parse(dr(Entidades.Categoria.Columnas.IdInteres.ToString()).ToString()))
         End If
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal IdCategoriaEmbarcacion As Integer) As Entidades.CategoriaEmbarcacion
      Dim dt As DataTable = New SqlServer.CategoriasEmbarcaciones(Me.da).CategoriasEmbarcacion_G1(IdCategoriaEmbarcacion)
      Dim o As Entidades.CategoriaEmbarcacion = New Entidades.CategoriaEmbarcacion()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.CategoriaEmbarcacion)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.CategoriaEmbarcacion
      Dim oLis As List(Of Entidades.CategoriaEmbarcacion) = New List(Of Entidades.CategoriaEmbarcacion)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CategoriaEmbarcacion()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetTodos() As List(Of Entidades.CategoriaEmbarcacion)
      Return CargaLista(New SqlServer.CategoriasEmbarcaciones(Me.da).CategoriasEmbarcacion_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.CategoriaEmbarcacion())
   End Function

#End Region


   Public Function GetPorNombreExacto(nombreCategoriaEmbarcacion As String) As DataTable
      Dim openConnection As Boolean = False
      Try
         If da.Connection.State <> ConnectionState.Open Then
            da.OpenConection()
            openConnection = True
         End If
         Return New SqlServer.CategoriasEmbarcaciones(da).GetPorNombreExacto(nombreCategoriaEmbarcacion)
      Finally
         If openConnection Then da.CloseConection()
      End Try

   End Function

   Public Function ExistePorNombreExacto(nombreCategoriaEmbarcacion As String) As Boolean
      Return GetPorNombreExacto(nombreCategoriaEmbarcacion).Rows.Count > 0
   End Function

End Class
