Public Class SubirScriptVersion
   Public Sub SincronizarScriptsdeVersion(listaVersionScript As IEnumerable(Of Entidades.VersionScript))
      Try
         'Dim wsS As WSActualiza.VersionScript
         Dim sincronizarListaScripts = New List(Of WSActualiza.VersionScript)()
         Dim idAplicacion = String.Empty
         For Each ent In listaVersionScript
            idAplicacion = ent.Aplicacion.IdAplicacion

            Dim wsS = New WSActualiza.VersionScript()
            wsS.Aplicacion = New WSActualiza.Aplicacion()
            wsS.Aplicacion.IdAplicacion = idAplicacion
            wsS.NroVersion = ent.Version.NroVersion
            wsS.Orden = ent.Orden
            wsS.OrdenSpecified = True
            wsS.Nombre = ent.Nombre
            wsS.Script = ent.Script
            wsS.Obligatorio = ent.Obligatorio
            wsS.ObligatorioSpecified = True
            If ent.Cliente.CodigoCliente > 0 Then
               wsS.Cliente.CodigoCliente = ent.Cliente.CodigoCliente
               wsS.Cliente.CodigoClienteSpecified = True
            End If
            sincronizarListaScripts.Add(wsS)
         Next

         Using ws = New WSActualiza.WSActualizador()
            ws.Url = Publicos.URLActualizacion
            ws.SubirScriptsVersion(idAplicacion, sincronizarListaScripts.ToArray())
         End Using

      Catch
         Throw
      End Try
   End Sub

   Public Sub EliminarScriptsdeVersion(idAplication As String, nroVersion As String)
      Using ws = New WSActualiza.WSActualizador()
         ws.Url = Publicos.URLActualizacion
         ws.EliminarScriptsVersion(idAplication, nroVersion)
      End Using
   End Sub

End Class