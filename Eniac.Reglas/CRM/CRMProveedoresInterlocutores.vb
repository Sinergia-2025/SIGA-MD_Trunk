Option Strict On
Option Explicit On
Public Class CRMProveedoresInterlocutores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMClientesInterlocutores"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMClientesInterlocutores"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.CRMProveedoresInterlocutores
      Return New SqlServer.CRMProveedoresInterlocutores(da)
   End Function

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim en As Entidades.CRMProveedorInterlocutor = DirectCast(entidad, Entidades.CRMProveedorInterlocutor)
      Try
         da.OpenConection()
         da.BeginTransaction()

         GetSqlServer().CRMProveedoresInterlocutores_I(en)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   ''' <summary>
   ''' CRMProveedoresInterlocutores_I es capaz de insertar y actualizar ProveedoresInterlocutor
   ''' </summary>
   ''' <param name="entidad"></param>
   ''' <remarks></remarks>
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim en As Entidades.CRMProveedorInterlocutor = DirectCast(entidad, Entidades.CRMProveedorInterlocutor)
      Try
         da.OpenConection()
         da.BeginTransaction()

         GetSqlServer().CRMProveedoresInterlocutores_I(en)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   'Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
   '   Try
   '      da.OpenConection()
   '      da.BeginTransaction()

   '      GetSqlServer().CRMProveedoresInterlocutores_D(en)

   '      da.CommitTransaction()
   '   Catch
   '      da.RollbakTransaction()
   '      Throw
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub


   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetSqlServer().CRMProveedoresInterlocutores_GA()
   End Function

   Public Overloads Function GetAll(idCliente As Long) As System.Data.DataTable
      Return GetSqlServer().CRMProveedoresInterlocutores_GA(idCliente)
   End Function

   Private Sub CargarUno(ByVal o As Entidades.CRMProveedorInterlocutor, ByVal dr As DataRow)
      With o
         .IdProveedor = Long.Parse(dr(Entidades.CRMProveedorInterlocutor.Columnas.IdProveedor.ToString()).ToString())
         .Interlocutor = dr(Entidades.CRMProveedorInterlocutor.Columnas.Interlocutor.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetTodos(idProveedor As Long) As List(Of Entidades.CRMProveedorInterlocutor)
      Dim dt As DataTable = Me.GetAll(idProveedor)
      Dim o As Entidades.CRMProveedorInterlocutor
      Dim oLis As List(Of Entidades.CRMProveedorInterlocutor) = New List(Of Entidades.CRMProveedorInterlocutor)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMProveedorInterlocutor()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region

End Class
