Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos
Imports System.IO

#End Region

Public Class Documentos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Documento"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Documento"
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
      Dim sql As SqlServer.Documentos = New SqlServer.Documentos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Documentos(Me.da).Documentos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.Documento = DirectCast(entidad, Entidades.Documento)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.Documentos = New SqlServer.Documentos(da)

         Select Case tipo
            Case TipoSP._I
               en.idDocumento = Me.GetCodigoMaximo(Entidades.Documento.Columnas.idDocumento.ToString()) + 1
               sqlC.Documentos_I(en)

            Case TipoSP._U
               sqlC.Documentos_U(en)

            Case TipoSP._D
               sqlC.Documentos_D(en.idDocumento)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Documento, ByVal dr As DataRow)
      With o
         .idDocumento = Integer.Parse(dr(Entidades.Documento.Columnas.idDocumento.ToString()).ToString())
         .Nombre = dr(Entidades.Documento.Columnas.Nombre.ToString()).ToString()
         .Grupo = dr(Entidades.Documento.Columnas.Grupo.ToString()).ToString()
         .Version = Decimal.Parse(dr(Entidades.Documento.Columnas.Version.ToString()).ToString())
         .Documento = CType(dr(Entidades.Documento.Columnas.Documento.ToString()), Byte())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarDocumento(ByVal doc As String)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.Documentos = New SqlServer.Documentos(da)

         sql.GrabarDocumento("d:\cez.xlsx")

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub ExportarDocumento(ByVal idDocumento As Long, ByVal path As String)
      Dim oDoc As Eniac.Entidades.Documento = New SqlServer.Documentos(Me.da).GetDocumento(idDocumento)

      Try
         File.WriteAllBytes(path, oDoc.Documento)
      Catch ex As Exception
         MsgBox("Error escribiendo archivo" & ex.Message)
      End Try

   End Sub

   Public Function GetUno(ByVal idDocumento As Integer) As Entidades.Documento
      Dim dt As DataTable = New SqlServer.Documentos(Me.da).Documentos_G1(idDocumento)
      Dim o As Entidades.Documento = New Entidades.Documento()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetCodigoMaximo(ByVal Campo As String) As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(" & Campo & ") AS Maximo")
         .Append(" FROM Documentos")
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

End Class
