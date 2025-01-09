Public Class AFIPTiposDocumentos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "AFIPTiposDocumentos"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "AFIPTiposDocumentos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.AFIPTiposDocumentos(da).AFIPTiposComprobantes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(o As Entidades.AFIPTipoDocumento, dr As DataRow)
      With o
         .IdAFIPTipoDocumento = Integer.Parse(dr(Entidades.AFIPTipoDocumento.Columnas.IdAFIPTipoDocumento.ToString()).ToString())
         .NombreAFIPTipoDocumento = dr(Entidades.AFIPTipoDocumento.Columnas.NombreAFIPTipoDocumento.ToString()).ToString()
         .TipoDocumento = dr(Entidades.AFIPTipoDocumento.Columnas.TipoDocumento.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Function GetIdTipoDocumento(idAFIPTipoDocumento As Integer) As String
      Try
         Me.da.OpenConection()

         Return New SqlServer.AFIPTiposDocumentos(Me.da).GetIdTipoDoc(idAFIPTipoDocumento)
      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   'Public Function GetIdTipoDocparaAFIP(idTipoDocumento As String) As Integer
   '   Return GetIdTipoDocparaAFIP(idTipoDocumento, AccionesSiNoExisteRegistro.Excepcion)
   'End Function

   Public Function GetIdTipoDocparaAFIP(idTipoDocumento As String, accion As AccionesSiNoExisteRegistro) As Integer
      Dim id = New SqlServer.AFIPTiposDocumentos(Me.da).GetIdTipoDocparaAFIP(idTipoDocumento)
      If id.HasValue Then
         Return id.Value
      End If
      If accion = AccionesSiNoExisteRegistro.Excepcion Then
         Throw New Exception(String.Format("Falta cargar el Tipo de Documento {0} en las tablas del AFIP.", idTipoDocumento))
      End If
      Return 0
   End Function

   Public Function GetTodos() As List(Of Entidades.AFIPTipoDocumento)
      Return CargaLista(GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AFIPTipoDocumento())
   End Function

#End Region

End Class