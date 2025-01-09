Option Strict On
Option Explicit On
Public Class CRMProspectosInterlocutores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMProspectosInterlocutores"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMProspectosInterlocutores"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Protected Overridable Function GetSqlServer() As Eniac.SqlServer.CRMProspectosInterlocutores
      Return New SqlServer.CRMProspectosInterlocutores(da)
   End Function

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim en As Entidades.CRMProspectoInterlocutor = DirectCast(entidad, Entidades.CRMProspectoInterlocutor)
      Try
         da.OpenConection()
         da.BeginTransaction()

         GetSqlServer().CRMProspectosInterlocutores_I(en)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   ''' <summary>
   ''' CRMProspectosInterlocutores_I es capaz de insertar y actualizar ProspectosInterlocutor
   ''' </summary>
   ''' <param name="entidad"></param>
   ''' <remarks></remarks>
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim en As Entidades.CRMProspectoInterlocutor = DirectCast(entidad, Entidades.CRMProspectoInterlocutor)
      Try
         da.OpenConection()
         da.BeginTransaction()

         GetSqlServer().CRMProspectosInterlocutores_I(en)

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

   '      GetSqlServer().CRMProspectosInterlocutores_D(en)

   '      da.CommitTransaction()
   '   Catch
   '      da.RollbakTransaction()
   '      Throw
   '   Finally
   '      da.CloseConection()
   '   End Try
   'End Sub


   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetSqlServer().CRMProspectosInterlocutores_GA()
   End Function

   Public Overloads Function GetAll(idProspecto As Long) As System.Data.DataTable
      Return GetSqlServer().CRMProspectosInterlocutores_GA(idProspecto)
   End Function

   Private Sub CargarUno(ByVal o As Entidades.CRMProspectoInterlocutor, ByVal dr As DataRow)
      With o
         .IdProspecto = Long.Parse(dr(Entidades.CRMProspectoInterlocutor.Columnas.IdProspecto.ToString()).ToString())
         .Interlocutor = dr(Entidades.CRMProspectoInterlocutor.Columnas.Interlocutor.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetTodos(idProspecto As Long) As List(Of Entidades.CRMProspectoInterlocutor)
      Dim dt As DataTable = Me.GetAll(idProspecto)
      Dim o As Entidades.CRMProspectoInterlocutor
      Dim oLis As List(Of Entidades.CRMProspectoInterlocutor) = New List(Of Entidades.CRMProspectoInterlocutor)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMProspectoInterlocutor()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region

End Class
