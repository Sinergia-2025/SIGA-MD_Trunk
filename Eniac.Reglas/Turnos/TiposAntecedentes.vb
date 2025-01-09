Public Class TiposAntecedentes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposAntecedentes"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TiposAntecedentes = New SqlServer.TiposAntecedentes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposAntecedentes(Me.da).TiposAntecedentes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.TipoAntecedente = DirectCast(entidad, Entidades.TipoAntecedente)

      Dim sql As SqlServer.TiposAntecedentes = New SqlServer.TiposAntecedentes(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.TiposAntecedentes_I(en.IdTipoAntecedente, en.NombreTipoAntecedente)
         Case TipoSP._U
            sql.TiposAntecedentes_U(en.IdTipoAntecedente, en.NombreTipoAntecedente)
         Case TipoSP._D
            sql.TiposAntecedentes_D(en.IdTipoAntecedente)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoAntecedente, ByVal dr As DataRow)
      With o
         .IdTipoAntecedente = Int32.Parse(dr(Entidades.TipoAntecedente.Columnas.IdTipoAntecedente.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()).ToString()) Then
            .NombreTipoAntecedente = dr(Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()).ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TipoAntecedente)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.TipoAntecedente
      Dim oLis As List(Of Entidades.TipoAntecedente) = New List(Of Entidades.TipoAntecedente)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoAntecedente()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idTipoAntecedente As Integer) As Entidades.TipoAntecedente
      Dim sql As SqlServer.TiposAntecedentes = New SqlServer.TiposAntecedentes(Me.da)

      Dim dt As DataTable = sql.TiposAntecedentes_G1(idTipoAntecedente)

      Dim o As Entidades.TipoAntecedente = New Entidades.TipoAntecedente()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Tipo de Antecedente.")
      End If
      Return o
   End Function

   Public Function GetProximoId() As Integer
      Return New SqlServer.TiposAntecedentes(Me.da).GetProximoId()
   End Function

#End Region

End Class
