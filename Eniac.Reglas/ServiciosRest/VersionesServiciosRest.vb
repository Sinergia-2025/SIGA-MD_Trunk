Option Strict On
Option Explicit On
Imports Eniac.Reglas.ServiciosRest.CobranzasMovil
Namespace ServiciosRest.SSSServicioWeb
   Public Class VersionesServiciosRest
      Public Event Avance(sender As Object, e As SincronizacionSubidaMovil.SincronizacionSubidaMovilEventArgs)

      Private Class VersionAdmin
         Public Property VersionWebMovilAdmin As String
         Public Property VersionApi As String
      End Class

      Public Sub ImportarAutomaticamente()
         Dim rCliente As Reglas.Clientes = New Reglas.Clientes()

         OnAvanceImportarAutomaticamente("Buscando clientes con servidores propios")

         Dim dtVersionesApi As DataTable = rCliente.GetClientesConVersionApi()

         Dim rSincro As ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil = New ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil()
         For Each dr As DataRow In dtVersionesApi.Rows
            Dim codigoCliente As Long = Long.Parse(dr("CodigoCliente").ToString())
            Dim nombreCliente As String = dr("NombreCliente").ToString()
            dr("NroVersionWebmovilPropio") = GetVersion(rSincro, dr("URLWebmovilPropio").ToString(), codigoCliente, nombreCliente)
            dr("NroVersionWebmovilAdminPropio") = GetVersion(rSincro, dr("URLWebmovilAdminPropio").ToString(), codigoCliente, nombreCliente)
            dr("NroVersionSimovilGestionPropio") = GetVersion(rSincro, dr("URLSimovilGestionPropio").ToString(), codigoCliente, nombreCliente)
            dr("NroVersionActualizadorPropio") = GetVersionSOAP(dr("URLActualizadorPropio").ToString(), codigoCliente, nombreCliente)
         Next
         dtVersionesApi.AcceptChanges()
         rCliente.ActualizaClientesConVersionApi(dtVersionesApi)

      End Sub

      Private Function GetVersion(rSincro As ServiciosRest.CobranzasMovil.SincronizacionSubidaMovil, url As String, codigoCliente As Long, nombreCliente As String) As String
         Dim version As String = String.Empty
         If Not String.IsNullOrWhiteSpace(url) Then
            OnAvanceImportarAutomaticamente(String.Format("Obteniendo versión {1} ({0}) - {2}", codigoCliente, nombreCliente, url))
            version = rSincro.GetVersion(url)
            If version.StartsWith("{") Then
               Dim a As VersionAdmin = New Web.Script.Serialization.JavaScriptSerializer().Deserialize(Of VersionAdmin)(version)
               If Not String.IsNullOrWhiteSpace(a.VersionWebMovilAdmin) Then
                  version = a.VersionWebMovilAdmin
               Else
                  version = a.VersionApi
               End If
            End If
            OnAvanceImportarAutomaticamente(String.Format("Versión {3} en {1} ({0}) - {2}", codigoCliente, nombreCliente, url, version))
         End If
         Return version
      End Function

      Private Function GetVersionSOAP(url As String, codigoCliente As Long, nombreCliente As String) As String
         Dim version As String = String.Empty
         If Not String.IsNullOrWhiteSpace(url) Then
            OnAvanceImportarAutomaticamente(String.Format("Obteniendo versión {1} ({0}) - {2}", codigoCliente, nombreCliente, url))
            Using ws As New WSActualiza.WSActualizador()
               ws.Url = url
               Dim vers As WSActualiza.Version1 = ws.GetVersionWS()
               version = String.Format("{0:00}.{1:00}.{2:00}.{3}", vers._Major, vers._Minor, vers._Build, vers._Revision)
            End Using
            OnAvanceImportarAutomaticamente(String.Format("Versión {3} en {1} ({0}) - {2}", codigoCliente, nombreCliente, url, version))
         End If
         Return version
      End Function

#Region "Evento Control de Avance"
      Public Event AvanceImportarAutomaticamente(sender As Object, e As AvanceImportarAutomaticamenteEventArgs)
      Protected Overridable Sub OnAvanceImportarAutomaticamente(etapa As String)
         RaiseEvent AvanceImportarAutomaticamente(Me, New AvanceImportarAutomaticamenteEventArgs(etapa))
      End Sub
      Public Class AvanceImportarAutomaticamenteEventArgs
         Inherits EventArgs
         Public Property Etapa As String
         Public Sub New(etapa As String)
            Me.Etapa = etapa
         End Sub
      End Class

#End Region

   End Class
End Namespace