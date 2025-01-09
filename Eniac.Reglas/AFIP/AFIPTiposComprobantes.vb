Option Strict On
Option Explicit On
Public Class AFIPTiposComprobantes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.AFIPTipoComprobante.NombreTabla
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
      Dim sql As SqlServer.AFIPTiposComprobantes = New SqlServer.AFIPTiposComprobantes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.AFIPTiposComprobantes(Me.da).AFIPTiposComprobantes_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.AFIPTipoComprobante = DirectCast(entidad, Entidades.AFIPTipoComprobante)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.AFIPTiposComprobantes = New SqlServer.AFIPTiposComprobantes(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AFIPTiposComprobantes_I(en.IdAFIPTipoComprobante, en.NombreAFIPTipoComprobante, en.IdAFIPTipoDocumento, en.IncluyeFechaVencimiento)
            Case TipoSP._U
               sqlC.AFIPTiposComprobantes_U(en.IdAFIPTipoComprobante, en.NombreAFIPTipoComprobante, en.IdAFIPTipoDocumento, en.IncluyeFechaVencimiento)
            Case TipoSP._D
               sqlC.AFIPTiposComprobantes_D(en.IdAFIPTipoComprobante)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.AFIPTipoComprobante, ByVal dr As DataRow)
      With o
         .IdAFIPTipoComprobante = Integer.Parse(dr(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoComprobante.ToString()).ToString())
         .NombreAFIPTipoComprobante = dr(Entidades.AFIPTipoComprobante.Columnas.NombreAFIPTipoComprobante.ToString()).ToString()
         If IsNumeric(dr(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoDocumento.ToString())) Then
            .IdAFIPTipoDocumento = Integer.Parse(dr(Entidades.AFIPTipoComprobante.Columnas.IdAFIPTipoDocumento.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.AFIPTipoComprobante.Columnas.IncluyeFechaVencimiento.ToString()).ToString()) Then
            .IncluyeFechaVencimiento = Boolean.Parse(dr(Entidades.AFIPTipoComprobante.Columnas.IncluyeFechaVencimiento.ToString()).ToString())
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idTipoComprobante As String, letra As String) As Entidades.AFIPTipoComprobante
      Return CargaEntidad(New SqlServer.AFIPTiposComprobantes(Me.da).AFIPTiposComprobantes_G_PorTipoLetra(idTipoComprobante, letra),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AFIPTipoComprobante(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No se encontró un comprobante AFIP para '{0}' y letra '{1}'", idTipoComprobante, letra))
   End Function

   Public Function GetUno(idAFIPTipoComprobante As Integer) As Entidades.AFIPTipoComprobante
      Dim dt As DataTable = New SqlServer.AFIPTiposComprobantes(Me.da).AFIPTiposComprobantes_G1(idAFIPTipoComprobante)
      Dim o As Entidades.AFIPTipoComprobante = New Entidades.AFIPTipoComprobante()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.AFIPTipoComprobante)
      Return CargaLista(New SqlServer.AFIPTiposComprobantes(Me.da).AFIPTiposComprobantes_GA())
   End Function

   Private Function CargaLista(dt As DataTable) As List(Of Entidades.AFIPTipoComprobante)
      Dim o As Entidades.AFIPTipoComprobante
      Dim oLis As List(Of Entidades.AFIPTipoComprobante) = New List(Of Entidades.AFIPTipoComprobante)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.AFIPTipoComprobante()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class