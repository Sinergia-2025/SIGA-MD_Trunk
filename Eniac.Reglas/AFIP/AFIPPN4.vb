Imports System.Xml
Public Class AFIPPN4
   Inherits Base

#Region "Campos"
   Private _urlPN4 As String
   Private _autorizacionV1 As WSFEv1.FEAuthRequest
   Public ws As WSPN4.PersonaServiceA5

#End Region

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
      ws = New WSPN4.PersonaServiceA5
      ws.Url = New Parametros().GetValorPD(Entidades.Parametro.Parametros.URLWSPN4.ToString(), "https://awshomo.afip.gov.ar/sr-padron/webservices/personaServiceA5?WSDL")
   End Sub

#End Region

#Region "Metodos comunes"
   Private Sub ControlaAutorizacionV1()
      Dim awsaa = New AFIPWSAA(Me.da)
      awsaa.CrearCertificado("ws_sr_constancia_inscripcion")
      CreaAutorizacionv1()
   End Sub
   Private Sub CreaAutorizacionv1()
      Dim m_xmld As XmlDocument
      Dim m_nodelist As XmlNodeList
      Dim m_node As XmlNode
      m_xmld = New XmlDocument()
      Dim sql = New SqlServer.ParametrosArchivos(Me.da)
      m_xmld.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOPN4.ToString()))
      m_nodelist = m_xmld.SelectNodes("/loginTicketResponse/credentials")
      Me._autorizacionV1 = New WSFEv1.FEAuthRequest()
      For Each m_node In m_nodelist
         Me._autorizacionV1.Token = m_node.ChildNodes.Item(0).InnerText
         Me._autorizacionV1.Sign = m_node.ChildNodes.Item(1).InnerText
         Me._autorizacionV1.Cuit = Long.Parse(Publicos.CuitEmpresa)
      Next
   End Sub
   Private Function getToken() As String
      Dim con As StringBuilder = New StringBuilder()
      With con
         .AppendFormat("{0}", Me._autorizacionV1.Token).AppendLine()
      End With
      Return con.ToString()
   End Function
   Private Function getSign() As String
      Dim con As StringBuilder = New StringBuilder()
      With con
         .AppendFormat("{0}", Me._autorizacionV1.Sign).AppendLine()
      End With
      Return con.ToString()
   End Function
#End Region

#Region "WSPN4"
   Public Function VerificaEstadoAFIP() As WSPN4.dummyReturn
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         ControlaAutorizacionV1()

         Me.da.CommitTransaction()

         Return ws.dummy()
      Catch ex As Exception
         Dim erro = New Entidades.EniacException(ex.Message)
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Function
   Public Function GetDatosContribuyento(cuit As Long) As WSPN4.personaReturn
      Try
         Return ws.getPersona(getToken(), getSign(), Long.Parse(Publicos.CuitEmpresa), cuit)
      Catch ex As Exception
         Dim erro = New Entidades.EniacException(ex.Message)
         Throw
      End Try

   End Function
#End Region
End Class
