Imports System.Xml
Imports System.Text

Public Class AFIPPN3
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      da = New Eniac.Datos.DataAccess()
      Me._urlPN3 = "https://awshomo.afip.gov.ar/padron-puc-ws/services/select.ContribuyenteNivel3SelectServiceImpl"
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      da = accesoDatos
      Me._urlPN3 = "https://awshomo.afip.gov.ar/padron-puc-ws/services/select.ContribuyenteNivel3SelectServiceImpl"
   End Sub

#End Region

#Region "Campos"

   Private _urlPN3 As String
   Private _autorizacionV1 As WSFEv1.FEAuthRequest

#End Region

#Region "Metodos comunes"

   Private Sub ControlaAutorizacionV1()

      Dim awsaa As AFIPWSAA = New AFIPWSAA(Me.da)
      awsaa.CrearCertificado("WSPN3")
      Me.CreaAutorizacionv1()
   End Sub

   Private Sub CreaAutorizacionv1()
      Dim m_xmld As XmlDocument
      Dim m_nodelist As XmlNodeList
      Dim m_node As XmlNode
      m_xmld = New XmlDocument()
      Dim sql As SqlServer.ParametrosArchivos = New SqlServer.ParametrosArchivos(Me.da)
      m_xmld.LoadXml(sql.GetValor(actual.Sucursal.IdEmpresa, Entidades.ParametroArchivo.Parametros.TICKETACCESOFE.ToString()))
      m_nodelist = m_xmld.SelectNodes("/loginTicketResponse/credentials")
      Me._autorizacionV1 = New WSFEv1.FEAuthRequest()
      For Each m_node In m_nodelist
         Me._autorizacionV1.Token = m_node.ChildNodes.Item(0).InnerText
         Me._autorizacionV1.Sign = m_node.ChildNodes.Item(1).InnerText
         Me._autorizacionV1.Cuit = Long.Parse(New Reglas.Parametros(Me.da)._GetValor(Entidades.Parametro.Parametros.CUITEMPRESA))
      Next
      'End If
   End Sub

   Private Function GetContribuyente(cuit As String) As String
      Dim con As StringBuilder = New StringBuilder()
      With con
         .Append("<?xml version=""1.0"" encoding=""UTF-8""?>")
         .Append("<contribuyentePK> ")
         .AppendFormat("<id>{0}</id> ", cuit.Replace("-", ""))
         .Append("</contribuyentePK>")
      End With
      Return con.ToString()
   End Function

   Private Function GetToken() As String
      Dim con As StringBuilder = New StringBuilder()
      With con
         .Append("-----BEGIN SSOTOKENBASE64-----").AppendLine()
         '.AppendFormat("{0}", Me._autorizacionV1.Token)
         .Append("PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9InllcyI/Pgo8c3NvIHZlcnNpb249IjIuMCI+CiAgICA8aWQgdW5pcXVlX2lkPSI5NzI4MjIxMDUiIHNyYz0iQ049d3NhYSwgTz1BRklQLCBDPUFSLCBTRVJJQUxOVU1CRVI9Q1VJVCAzMzY5MzQ1MDIzOSIgZ2VuX3RpbWU9IjEzMjYzNjM1MjkiIGV4cF90aW1lPSIxMzI2NDA2Nzg5IiBkc3Q9IkNOPXdzZmUsIE89QUZJUCwgQz1BUiIvPgogICAgPG9wZXJhdGlvbiB2YWx1ZT0iZ3JhbnRlZCIgdHlwZT0ibG9naW4iPgogICAgICAgIDxsb2dpbiB1aWQ9IkM9YXIsIE89Y3VlbmNhIG1hcmlhIGFuZHJlYSwgU0VSSUFMTlVNQkVSPUNVSVQgMjcyMjg4OTY1MTQsIENOPWFuZHJlYS1wYyIgc2VydmljZT0id3NmZSIgcmVnbWV0aG9kPSIyMiIgZW50aXR5PSIzMzY5MzQ1MDIzOSIgYXV0aG1ldGhvZD0iY21zIj4KICAgICAgICAgICAgPHJlbGF0aW9ucz4KICAgICAgICAgICAgICAgIDxyZWxhdGlvbiByZWx0eXBlPSI0IiBrZXk9IjI3MjI4ODk2NTE0Ii8+CiAgICAgICAgICAgIDwvcmVsYXRpb25zPgogICAgICAgIDwvbG9naW4+CiAgICA8L29wZXJhdGlvbj4KPC9zc28+Cgo=")
         .Append("-----END SSOTOKENBASE64-----")
      End With
      Return con.ToString()
   End Function

   Private Function GetSign() As String
      Dim con As StringBuilder = New StringBuilder()
      With con
         .Append("-----BEGIN SSOSIGNBASE64-----").AppendLine()
         .AppendFormat("{0}", Me._autorizacionV1.Sign).AppendLine()
         .Append("-----END SSOSIGNBASE64-----")
      End With
      Return con.ToString()
   End Function

#End Region

#Region "WSPN3"

   Public Function GetDatosContribuyento(cuit As String) As String
      Me.ControlaAutorizacionV1()

      Dim ws As WSPN3.ContribuyenteNivel3SelectServiceImplService = New WSPN3.ContribuyenteNivel3SelectServiceImplService()

      Dim valor As String = ws.dummy()

      Dim resp As String = ws.get(Me.GetContribuyente(cuit), Me.GetToken(), Me.GetSign())

      Return resp
   End Function

#End Region

End Class
