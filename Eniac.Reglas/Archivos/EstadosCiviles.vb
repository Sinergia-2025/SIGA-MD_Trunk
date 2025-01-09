Public Class EstadosCiviles
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "EstadosCiviles"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "EstadosCiviles"
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
      Dim sql = New SqlServer.EstadosCiviles(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosCiviles(Me.da).EstadosCiviles_GA()
   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdEstadoCivil) AS Maximo")
         .Append(" FROM EstadosCiviles")
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
         Dim en As Entidades.EstadoCivil = DirectCast(entidad, Entidades.EstadoCivil)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.EstadosCiviles = New SqlServer.EstadosCiviles(da)

         Select Case tipo
            Case TipoSP._I
               sqlC.EstadosCiviles_I(en.IdEstadoCivil, en.NombreEstadoCivil)
            Case TipoSP._U
               sqlC.EstadosCiviles_U(en.IdEstadoCivil, en.NombreEstadoCivil)
            Case TipoSP._D
               sqlC.EstadosCiviles_D(en.IdEstadoCivil)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoCivil, ByVal dr As DataRow)
      With o
         .IdEstadoCivil = Integer.Parse(dr(Entidades.EstadoCivil.Columnas.IdEstadoCivil.ToString()).ToString())
         .NombreEstadoCivil = dr(Entidades.EstadoCivil.Columnas.NombreEstadoCivil.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idEstadoCivil As Integer) As Entidades.EstadoCivil
      Dim dt As DataTable = New SqlServer.EstadosCiviles(Me.da).EstadosCiviles_G1(idEstadoCivil)
      Dim o As Entidades.EstadoCivil = New Entidades.EstadoCivil()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.EstadoCivil)
      Dim dt = Me.GetAll()
      Dim o As Entidades.EstadoCivil
      Dim oLis = New List(Of Entidades.EstadoCivil)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.EstadoCivil()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Function GetUnoNombre(ByVal nombre As String) As Entidades.EstadoCivil
      Dim dt As DataTable = GetPorNombreExacto(nombre)
      Dim o As Entidades.EstadoCivil = New Entidades.EstadoCivil()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetPrimerEstado() As Entidades.EstadoCivil
      Dim dt = Me.GetAll()
      Dim o = New Entidades.EstadoCivil()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Private Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("  SELECT IdEstadoCivil")
         .AppendLine("      ,NombreEstadoCivil")
         .AppendLine("  FROM EstadosCiviles ")
         .AppendLine(" WHERE NombreEstadoCivil = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function
#End Region
End Class
