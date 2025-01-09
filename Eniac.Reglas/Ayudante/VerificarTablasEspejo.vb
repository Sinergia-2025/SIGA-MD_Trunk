Namespace Ayudante
   Public Class VerificarTablasEspejo
      Inherits Base
#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub
      Friend Sub New(accesoDatos As Datos.DataAccess)
         MyBase.New("Marcas", accesoDatos)
      End Sub

#End Region

      Public Function VerificaTablasEspejo() As String
         Dim result = New StringBuilder()
         VerificaTablasEspejo(result)
         Return result.ToString()
      End Function

      Protected Overridable Sub VerificaTablasEspejo(result As StringBuilder)
         Verifica_Clientes_AuditoriaClientes(result)
         Verifica_Prospectos_AuditoriaProspectos(result)
         Verifica_Clientes_Prospectos(result)
         Verifica_Productos_AuditoriaProductos(result)
         Verifica_CRMNovedades_AuditoriaCRMNovedades(result)
      End Sub
      Protected Overridable Sub Verifica_CRMNovedades_AuditoriaCRMNovedades(result As StringBuilder)
         ControlaErrores(VerificaTablasEspejo("CRMNovedades", "AuditoriaCRMNovedades"), result)
      End Sub
      Protected Overridable Sub Verifica_Clientes_AuditoriaClientes(result As StringBuilder)
         ControlaErrores(VerificaTablasEspejo("Clientes", "AuditoriaClientes"), result)
      End Sub
      Protected Overridable Sub Verifica_Prospectos_AuditoriaProspectos(result As StringBuilder)
         ControlaErrores(VerificaTablasEspejo("Prospectos", "AuditoriaProspectos"), result)
      End Sub
      Protected Overridable Sub Verifica_Clientes_Prospectos(result As StringBuilder)
         If actual.Sistema = "SiGA" Then
            ControlaErrores(VerificaTablasEspejo("Clientes", "Prospectos", "Prospecto", "Cliente"), result)
            ControlaErrores(VerificaTablasEspejo("ClientesDirecciones", "ProspectosDirecciones", "Prospecto", "Cliente"), result)
         End If
      End Sub
      Protected Overridable Sub Verifica_Productos_AuditoriaProductos(result As StringBuilder)
         ControlaErrores(VerificaTablasEspejo("Productos", "AuditoriaProductos"), result)
      End Sub

      Protected Sub ControlaErrores(errores As Entidades.Ayudante.VerificarTablasEspejo, stb As StringBuilder)
         If errores.ConError Then
            stb.AppendFormatLine("Diferencias entre las tablas {0} y {1}", errores.TablaOrigen, errores.TablaDestino)
            For Each campos In errores.Campos
               If campos.ConError Then
                  stb.AppendFormatLine("    {0}: {1} ""{2}""", campos.NombreCampo, campos.Motivo, campos.TipoDato)
               End If
            Next
         End If
      End Sub

      Public Function VerificaTablasEspejo(tablaOrigen As String, tablaDestino As String) As Entidades.Ayudante.VerificarTablasEspejo
         Return VerificaTablasEspejo(tablaOrigen, tablaDestino, replaceOrigen:=String.Empty, replaceDestico:=String.Empty)
      End Function

      Public Function VerificaTablasEspejo(tablaOrigen As String, tablaDestino As String,
                                           replaceOrigen As String,
                                           replaceDestico As String) As Entidades.Ayudante.VerificarTablasEspejo
         Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
         Try
            If blnAbreConexion Then da.OpenConection()
            Dim sql = New SqlServer.Ayudante.VerificarTablasEspejo(da)
            Dim camposOrigen = sql.ObtenerCamposDeTabla(tablaOrigen)
            Dim camposDestino = sql.ObtenerCamposDeTabla(tablaDestino, replaceOrigen, replaceDestico)

            For Each kvCampoOrigen In camposOrigen
               Dim campoOrigen = camposOrigen(kvCampoOrigen.Key)
               If Not camposDestino.ContainsKey(kvCampoOrigen.Key) Then
                  campoOrigen.ConError = True
                  campoOrigen.Motivo = "Falta campo"
               Else
                  Dim campoDestino = camposDestino(kvCampoOrigen.Key)
                  If Not campoOrigen.TipoDato.Equals(campoDestino.TipoDato) Then
                     campoOrigen.ConError = True
                     campoOrigen.Motivo = "Diferencia en Tipo de Datos"
                  End If
               End If
            Next
            Dim arrayCampos(camposOrigen.Count - 1) As Entidades.Ayudante.VerificarTablasEspejo.CamposTabla
            camposOrigen.Values.CopyTo(arrayCampos, 0)
            Return New Entidades.Ayudante.VerificarTablasEspejo(arrayCampos, tablaOrigen, tablaDestino)
         Finally
            If blnAbreConexion Then da.CloseConection()
         End Try
      End Function
   End Class
End Namespace