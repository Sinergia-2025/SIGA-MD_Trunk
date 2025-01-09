#Region "Option"
Option Explicit On
Option Strict On
#End Region
Public Class EstadosCheques
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.EstadoCheque.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosCheques(Me.da).EstadosCheques_GA()
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub CargarUno(o As Entidades.EstadoCheque, dr As DataRow)
      With o
         .IdEstadoCheque = dr(Entidades.EstadoCheque.Columnas.IdEstadoCheque.ToString()).ToString()
         .NombreEstadoCheque = dr(Entidades.EstadoCheque.Columnas.NombreEstadoCheque.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodos() As List(Of Entidades.EstadoCheque)
      Try
         Me.da.OpenConection()
         Return _GetTodos()
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function _GetTodos() As List(Of Entidades.EstadoCheque)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoCheque())
   End Function

   Public Function GetPorCodigo(codigo As String) As DataTable
      Return New SqlServer.EstadosCheques(Me.da).GetPorCodigo(codigo)
   End Function

   Public Function GetPorNombre(nombre As String) As DataTable
      Return New SqlServer.EstadosCheques(Me.da).GetPorNombre(nombre)
   End Function

   Public Function GetUno(idEstadoCheque As String) As Entidades.EstadoCheque
      Return GetUno(idEstadoCheque, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idEstadoCheque As String, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoCheque
      Return CargaEntidad(New SqlServer.EstadosCheques(Me.da).EstadosCheques_G1(idEstadoCheque),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.EstadoCheque(),
                          accion, Function() String.Format("No existe el Estado '{0}'.", idEstadoCheque))
   End Function

#End Region

End Class