Option Strict On
Option Explicit On
Imports Eniac.Entidades
Public Class TiposNaves
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "TiposNaves"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposNaves"
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
      Dim sql As SqlServer.TiposNaves = New SqlServer.TiposNaves(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposNaves(Me.da).TiposNaves_GA()
   End Function

   Public Function GetCodigoMaximo() As Short
      Return Convert.ToInt16(GetCodigoMaximo(Entidades.TipoNave.Columnas.IdTipoNave.ToString()))
   End Function
   Public Function GetCodigoMaximo(ByVal campo As String) As Long
      Return New SqlServer.TiposNaves(Me.da).GetCodigoMaximo(campo)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.TipoNave = DirectCast(entidad, Entidades.TipoNave)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.TiposNaves = New SqlServer.TiposNaves(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.TiposNaves_I(en)
            Case TipoSP._U
               sqlC.TiposNaves_U(en)
            Case TipoSP._D
               sqlC.TiposNaves_D(en.IdTipoNave)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.TipoNave, ByVal dr As DataRow)
      With o
         .IdTipoNave = Short.Parse(dr(TipoNave.Columnas.IdTipoNave.ToString()).ToString())
         .NombreTipoNave = dr(TipoNave.Columnas.NombreTipoNave.ToString()).ToString()
         .Seco = CBool(dr(TipoNave.Columnas.Seco.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(ByVal idNave As Integer) As Entidades.TipoNave
      Dim dt As DataTable = New SqlServer.TiposNaves(Me.da).TiposNaves_G1(idNave)
      Dim o As Entidades.TipoNave = New Entidades.TipoNave()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodas() As List(Of Entidades.TipoNave)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.TipoNave
      Dim oLis As List(Of Entidades.TipoNave) = New List(Of Entidades.TipoNave)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.TipoNave()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
#End Region
End Class
