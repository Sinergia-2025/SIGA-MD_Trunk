#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class ConcesionariosAdicionales
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = Entidades.ConcesionariosAdicionales.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ConcesionariosAdicionales.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionariosAdicionales), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionariosAdicionales), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionariosAdicionales), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ConcesionariosAdicionales = New SqlServer.ConcesionariosAdicionales(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ConcesionariosAdicionales(Me.da).ConcesionariosAdicionales_GA()
   End Function
#End Region

#Region "Métodos Públicos"
   'GET UNO
   Public Function GetUno(idAdicional As Integer) As Entidades.ConcesionariosAdicionales
      Return GetUno(idAdicional, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdAdicional As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionariosAdicionales
      Return CargaEntidad(New SqlServer.ConcesionariosAdicionales(Me.da).ConcesionariosAdicionales_G1(IdAdicional),
               Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionariosAdicionales(),
               accion, Function() String.Format("No existe el Adicional con Id: {0}", IdAdicional))
   End Function

   'GET TODOS
   Public Function GetTodos() As List(Of Entidades.ConcesionariosAdicionales)
      Return CargaLista(New SqlServer.ConcesionariosAdicionales(Me.da).ConcesionariosAdicionales_GA(),
            Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionariosAdicionales())
   End Function

   'GET CODIGO MAXIMO
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ConcesionariosAdicionales(Me.da).GetCodigoMaximo()
   End Function

#End Region

#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionariosAdicionales, tipo As TipoSP)
      Dim sConAd As SqlServer.ConcesionariosAdicionales = New SqlServer.ConcesionariosAdicionales(da)
      Select Case tipo
         Case TipoSP._I
            sConAd.ConcesionariosAdicionales_I(en.IdAdicional, en.NombreAdicional, en.DescripcionAdicional, en.SolicitaDetalle)
         Case TipoSP._U
            sConAd.ConcesionariosAdicionales_U(en.IdAdicional, en.NombreAdicional, en.DescripcionAdicional, en.SolicitaDetalle)
         Case TipoSP._D
            sConAd.ConcesionariosAdicionales_D(en.IdAdicional, en.NombreAdicional)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionariosAdicionales, dr As DataRow)
      With o
         .IdAdicional = dr.Field(Of Integer)(Entidades.ConcesionariosAdicionales.Columnas.IdAdicional.ToString())
         .NombreAdicional = dr.Field(Of String)(Entidades.ConcesionariosAdicionales.Columnas.NombreAdicional.ToString())
         .DescripcionAdicional = dr.Field(Of String)(Entidades.ConcesionariosAdicionales.Columnas.DescripcionAdicional.ToString())
         .SolicitaDetalle = dr.Field(Of Boolean)(Entidades.ConcesionariosAdicionales.Columnas.SolicitaDetalle.ToString())
      End With
   End Sub
#End Region
End Class
