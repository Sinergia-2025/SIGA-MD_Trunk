Option Strict Off
Public Class CategoriasCamas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CategoriasCamas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasCamas"
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
      Dim sql As SqlServer.CategoriasCamas = New SqlServer.CategoriasCamas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasCamas(Me.da).CategoriasCamas_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(idCategoriaCama) AS Maximo")
         .Append(" FROM CategoriasCamas")
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
         Dim en As Entidades.CategoriaCama = DirectCast(entidad, Entidades.CategoriaCama)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CategoriasCamas = New SqlServer.CategoriasCamas(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.CategoriasCamas_I(en.IdCategoriaCama, en.NombreCategoriaCama,
                                      en.CantidadAccionesRequeridas,
                                      en.Alto,
                                      en.Ancho,
                                      en.Largo,
                                      en.TasaMunicipal,
                                      en.ImporteExpensas,
                                      en.ImporteAlquiler,
                                      en.PorcDescAlquiler,
                                      en.ImporteGastosAdmin,
                                      en.ImporteGastosIntermAlq)
            Case TipoSP._U
               sqlC.CategoriasCamas_U(en.IdCategoriaCama, en.NombreCategoriaCama,
                                      en.CantidadAccionesRequeridas,
                                      en.Alto,
                                      en.Ancho,
                                      en.Largo,
                                      en.TasaMunicipal,
                                      en.ImporteExpensas,
                                      en.ImporteAlquiler,
                                      en.PorcDescAlquiler,
                                      en.ImporteGastosAdmin,
                                      en.ImporteGastosIntermAlq)
            Case TipoSP._D
               sqlC.CategoriasCamas_D(en.IdCategoriaCama)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CategoriaCama, ByVal dr As DataRow)
      With o
         .IdCategoriaCama = Integer.Parse(dr(Entidades.CategoriaCama.Columnas.IdCategoriaCama.ToString()).ToString())
         .NombreCategoriaCama = dr(Entidades.CategoriaCama.Columnas.NombreCategoriaCama.ToString()).ToString()
         .CantidadAccionesRequeridas = Integer.Parse(dr(Entidades.CategoriaCama.Columnas.CantidadAccionesRequeridas.ToString()).ToString())
         .Alto = dr(Entidades.CategoriaCama.Columnas.Alto.ToString())
         .Ancho = dr(Entidades.CategoriaCama.Columnas.Ancho.ToString())
         .Largo = dr(Entidades.CategoriaCama.Columnas.Largo.ToString())
         .TasaMunicipal = dr(Entidades.CategoriaCama.Columnas.TasaMunicipal.ToString())
         .ImporteExpensas = CDec(dr(Entidades.CategoriaCama.Columnas.ImporteExpensas.ToString()))
         .ImporteAlquiler = CDec(dr(Entidades.CategoriaCama.Columnas.ImporteAlquiler.ToString()))
         .PorcDescAlquiler = CDec(dr(Entidades.CategoriaCama.Columnas.PorcDescAlquiler.ToString()))
         .ImporteGastosAdmin = CDec(dr(Entidades.CategoriaCama.Columnas.ImporteGastosAdmin.ToString()))
         .ImporteGastosIntermAlq = CDec(dr(Entidades.CategoriaCama.Columnas.ImporteGastosIntermAlq.ToString()))
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idCategoriaCama As Integer) As Entidades.CategoriaCama
      Dim dt As DataTable = New SqlServer.CategoriasCamas(Me.da).CategoriasCamas_G1(idCategoriaCama)
      Dim o As Entidades.CategoriaCama = New Entidades.CategoriaCama()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.CategoriaCama)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.CategoriaCama
      Dim oLis As List(Of Entidades.CategoriaCama) = New List(Of Entidades.CategoriaCama)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CategoriaCama()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region

End Class

