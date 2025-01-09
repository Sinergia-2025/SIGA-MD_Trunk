#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region

Public Class TiposContactos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposContactos"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposContactos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(entidad)

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

         Me.Actualiza(entidad)

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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT")
         .Append(" M.IdTipoContacto")
         .Append(", M.NombreTipoContacto ")
         .Append(", M.NombreAbrevTipoContacto ")
         .Append(" FROM  ")
         .Append("TiposContactos M ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposContactos(Me.da).TiposContactos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim TiposContactos As Entidades.TipoContacto = DirectCast(entidad, Entidades.TipoContacto)
      Dim sql As SqlServer.TiposContactos = New SqlServer.TiposContactos(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.TiposContactos_I(TiposContactos.IdTipoContacto, TiposContactos.NombreTipoContacto, TiposContactos.NombreAbrevTipoContacto)
         Case TipoSP._U
            sql.TiposContactos_U(TiposContactos.IdTipoContacto, TiposContactos.NombreTipoContacto, TiposContactos.NombreAbrevTipoContacto)
         Case TipoSP._D
            sql.TiposContactos_D(TiposContactos.IdTipoContacto)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoContacto, ByVal dr As DataRow)

      With o
         .IdTipoContacto = Integer.Parse(dr(Entidades.TipoContacto.Columnas.IdTipoContacto).ToString())
         .NombreTipoContacto = dr(Entidades.TipoContacto.Columnas.NombreTipoContacto).ToString()
         .NombreAbrevTipoContacto = dr(Entidades.TipoContacto.Columnas.NombreAbrevTipoContacto).ToString()
      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Function GetTodas() As List(Of Entidades.TipoContacto)
      Try
         Me.da.OpenConection()
         Return _GetTodas()
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function _GetTodas() As List(Of Entidades.TipoContacto)
      Try
         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.TipoContacto
         Dim oLis As List(Of Entidades.TipoContacto) = New List(Of Entidades.TipoContacto)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.TipoContacto()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function

   Public Function GetUna(ByVal IdTipoContacto As Integer) As Entidades.TipoContacto
      Dim sql As SqlServer.TiposContactos = New SqlServer.TiposContactos(Me.da)
      Dim dt As DataTable = sql.TiposContactos_G1(IdTipoContacto)
      Dim o As Entidades.TipoContacto = New Entidades.TipoContacto()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Tipo de Contacto.")
      End If
      Return o
   End Function

   Public Function GetPorCodigo(ByVal codigo As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdTipoContacto,")
         .Append("       NombreTipoContacto,")
         .Append("	    NombreAbrevTipoContacto")
         .Append("  FROM TiposContactos")
         If codigo > 0 Then
            .Append(" WHERE IdTipoContacto = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreTipoContacto")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdTipoContacto,")
         .Append("	    NombreTipoContacto,")
         .Append("	    NombreAbrevTipoContacto")
         .Append("  FROM TiposContactos")
         .Append("	WHERE NombreTipoContacto LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreTipoContacto")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdTipoContacto,")
         .AppendLine("       NombreTipoContacto")
         .AppendLine("  FROM TiposContactos")
         .AppendLine(" WHERE NombreTipoContacto = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("select ")
         .Append(" max(IdTipoContacto) as maximo ")
         .Append(" from TiposContactos")
      End With

      'Para el Importador de Productos (Airoldi y Generico)
      'Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())

      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

#End Region

End Class

