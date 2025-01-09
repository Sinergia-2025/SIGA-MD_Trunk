Option Explicit On
Option Strict On

Imports System.Text

Public Class TiposDocumento
    Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposDocumento"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
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
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT")
         .Append(" T.TipoDocumento ")
         .Append(", T.NombreTipoDocumento ")
         .Append(", T.EsAutoincremental ")
         .Append(" FROM  ")
         .Append("TiposDocumento T ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Overloads Function GetAll(validoAFIP As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.TiposDocumento(Me.da).TiposDocumento_GA(validoAFIP)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim tipoDoc As Entidades.TipoDocumento = DirectCast(entidad, Entidades.TipoDocumento)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.TiposDocumento = New SqlServer.TiposDocumento(Me.da)
         Select Case tipo
            Case TipoSP._I
               sql.TiposDocumento_I(tipoDoc.TipoDocumento, tipoDoc.NombreTipoDocumento, tipoDoc.EsAutoincremental)
            Case TipoSP._U
               sql.TiposDocumento_U(tipoDoc.TipoDocumento, tipoDoc.NombreTipoDocumento, tipoDoc.EsAutoincremental)
            Case TipoSP._D
               sql.TiposDocumento_D(tipoDoc.TipoDocumento)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoDocumento, ByVal dr As DataRow)
      With o
         .TipoDocumento = dr("TipoDocumento").ToString()
         If Not String.IsNullOrEmpty(dr("NombreTipoDocumento").ToString()) Then
            .NombreTipoDocumento = dr("NombreTipoDocumento").ToString()
         End If
         If Not String.IsNullOrEmpty(dr("EsAutoincremental").ToString()) Then
            .EsAutoincremental = Boolean.Parse(dr("EsAutoincremental").ToString())
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TipoDocumento)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.TipoDocumento
      Dim oLis As List(Of Entidades.TipoDocumento) = New List(Of Entidades.TipoDocumento)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoDocumento()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal tipoDocumento As String) As Entidades.TipoDocumento
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT * ")
         .Append("  FROM ")
         .Append(Me.NombreEntidad)
         .AppendFormat("  WHERE TipoDocumento = '{0}'", tipoDocumento)
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())

      Dim o As Entidades.TipoDocumento = New Entidades.TipoDocumento()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Tipo de Documento.")
      End If
      Return o
   End Function

#End Region

End Class
