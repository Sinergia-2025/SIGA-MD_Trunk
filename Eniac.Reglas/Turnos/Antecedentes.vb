Public Class Antecedentes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Antecedentes"
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
      Dim sql As SqlServer.Antecedentes = New SqlServer.Antecedentes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Antecedentes(Me.da).Antecedentes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Antecedente = DirectCast(entidad, Entidades.Antecedente)

      Dim sql As SqlServer.Antecedentes = New SqlServer.Antecedentes(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.Antecedentes_I(en.IdAntecedente, en.NombreAntecedente, en.TipoAntecedente.IdTipoAntecedente)
         Case TipoSP._U
            sql.Antecedentes_U(en.IdAntecedente, en.NombreAntecedente, en.TipoAntecedente.IdTipoAntecedente)
         Case TipoSP._D
            sql.Antecedentes_D(en.IdAntecedente)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Antecedente, ByVal dr As DataRow)
      With o
         .IdAntecedente = Int32.Parse(dr(Entidades.Antecedente.Columnas.IdAntecedente.ToString()).ToString())
         .NombreAntecedente = dr(Entidades.Antecedente.Columnas.NombreAntecedente.ToString()).ToString()
         .TipoAntecedente = New Reglas.TiposAntecedentes(Me.da).GetUno(Int32.Parse(dr(Entidades.Antecedente.Columnas.IdTipoAntecedente.ToString()).ToString()))
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.Antecedente)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.Antecedente
      Dim oLis As List(Of Entidades.Antecedente) = New List(Of Entidades.Antecedente)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.Antecedente()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idAntecedente As Integer) As Entidades.Antecedente
      Dim sql As SqlServer.Antecedentes = New SqlServer.Antecedentes(Me.da)

      Dim dt As DataTable = sql.Antecedentes_G1(idAntecedente)

      Dim o As Entidades.Antecedente = New Entidades.Antecedente()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Antecedente.")
      End If
      Return o
   End Function

   Public Function GetProximoId() As Integer
      Return New SqlServer.Antecedentes(Me.da).GetProximoId()
   End Function


#End Region

End Class
