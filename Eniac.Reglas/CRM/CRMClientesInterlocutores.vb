Option Strict On
Option Explicit On
Public Class CRMClientesInterlocutores
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

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
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
      Catch
         da.RollbakTransaction()
         Throw
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
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMClientesInterlocutores(Me.da).CRMClientesInterlocutores_GA()
   End Function

   Public Overloads Function GetAll(idCliente As Long) As System.Data.DataTable
      Return New SqlServer.CRMClientesInterlocutores(Me.da).CRMClientesInterlocutores_GA(idCliente)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CRMClienteInterlocutor = DirectCast(entidad, Entidades.CRMClienteInterlocutor)

      Dim sqlC As SqlServer.CRMClientesInterlocutores = New SqlServer.CRMClientesInterlocutores(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.CRMClientesInterlocutores_I(en.IdCliente, en.Interlocutor)
         Case TipoSP._U

         Case TipoSP._D

      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CRMClienteInterlocutor, ByVal dr As DataRow)
      With o
         .IdCliente = Long.Parse(dr(Entidades.CRMClienteInterlocutor.Columnas.IdCliente.ToString()).ToString())
         .Interlocutor = dr(Entidades.CRMClienteInterlocutor.Columnas.Interlocutor.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetTodos(idCliente As Long) As List(Of Entidades.CRMClienteInterlocutor)
      Dim dt As DataTable = Me.GetAll(idCliente)
      Dim o As Entidades.CRMClienteInterlocutor
      Dim oLis As List(Of Entidades.CRMClienteInterlocutor) = New List(Of Entidades.CRMClienteInterlocutor)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMClienteInterlocutor()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class
