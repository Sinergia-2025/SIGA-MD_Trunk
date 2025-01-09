Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text

#End Region

Public Class RubrosConceptos

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "RubrosConceptos"
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
         .Append("SELECT ")
         .Append(" R.IdRubroConcepto ")
         .Append(", R.NombreRubroConcepto ")
         .Append(" FROM  ")
         .Append("RubrosConceptos R ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.DataServer().GetDataTable(stbQuery.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RubrosConceptos(Me.da).RubrosConceptos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim RubroConcepto As Entidades.RubroConcepto = DirectCast(entidad, Entidades.RubroConcepto)

      Try
         da.OpenConection()
         da.BeginTransaction()


         Dim sql As SqlServer.RubrosConceptos = New SqlServer.RubrosConceptos(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.RubrosConceptos_I(RubroConcepto.IdRubroConcepto, RubroConcepto.NombreRubroConcepto)

            Case TipoSP._U
               sql.RubrosConceptos_U(RubroConcepto.IdRubroConcepto, RubroConcepto.NombreRubroConcepto)

            Case TipoSP._D
               sql.RubrosConceptos_D(RubroConcepto.IdRubroConcepto)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try


   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Function GetPorCodigo(ByVal codigo As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdRubroConcepto,")
         .Append("	NombreRubroConcepto")
         .Append("  FROM RubrosConceptos")
         If codigo > 0 Then
            .Append("	WHERE IdRubroConcepto= ")
            .Append(codigo)
         End If
         .Append("	ORDER BY NombreRubroConcepto")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdRubroConcepto,")
         .Append("	NombreRubroConcepto")
         .Append("  FROM RubrosConceptos")
         .Append("	WHERE NombreRubroConcepto LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreRubroConcepto")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetCodigoMaximo() As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(IdRubroConcepto) as maximo ")
         .Append(" FROM RubrosConceptos")
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
