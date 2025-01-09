Public Class ucNovedadesFuncionesAplicacion
#Region "Busqueda"
   Private Sub bscCodigoFuncion_BuscadorClick() Handles bscCodigoFuncion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaFunciones2(bscCodigoFuncion)
         bscCodigoFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(bscCodigoFuncion.Text, String.Empty)
      End Sub)
   End Sub
   Private Sub bscFuncion_BuscadorClick() Handles bscFuncion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaFunciones2(bscFuncion)
         bscFuncion.Datos = New Reglas.Funciones().GetFiltradoPorCodigoNombre(String.Empty, bscFuncion.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoFuncion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoFuncion.BuscadorSeleccion, bscFuncion.BuscadorSeleccion
      TryCatched(Sub() CargarDatosFuncion(e.FilaDevuelta))
   End Sub

   Private Sub CargarDatosFuncion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscFuncion.Text = dr.Cells("Nombre").Value.ToString()
         bscCodigoFuncion.Text = dr.Cells("Id").Value.ToString().Trim()
         Dim rFuncLinks = New Reglas.FuncionesDocumentos()
         Dim rFuncVinc = New Reglas.FuncionesVinculadas()

         Dim funcLinksPropios = rFuncLinks.GetTodos(bscCodigoFuncion.Text)
         Dim funcLinksAplic = rFuncLinks.GetTodos("SIGA")
         Dim funcVinculados = rFuncVinc.GetTodos(bscCodigoFuncion.Text)

         Dim cantidadTotalLinks = funcLinksPropios.Count + funcLinksAplic.Count

         lnkCantidadLinks.Text = String.Format("{0} Links", cantidadTotalLinks)

         ctxLinks.Items.Clear()

         If cantidadTotalLinks > 0 Then
            If funcLinksPropios.Count > 0 Then
               AgregarLink("Links Propios", funcLinksPropios)
            End If
            If funcLinksPropios.Count > 0 And funcLinksAplic.Count > 0 Then
               ctxLinks.Items.Add(New ToolStripSeparator())
            End If
            If funcLinksAplic.Count > 0 Then
               AgregarLink("Links Aplicación", funcLinksAplic)
            End If
         End If


         lnkFuncionesVinculadas.Text = String.Format("{0} Funciones Vinculadas", funcVinculados.CountSecure())
         ctxVinculados.Items.Clear()

         AgregarVinculadas(funcVinculados)

      End If
   End Sub

#End Region

#Region "Manejo de Links"
   Private Sub AgregarLink(header As String, links As List(Of Entidades.FuncionesDocumentos))
      Dim item = ctxLinks.Items.Add(header)
      item.Font = New Font(item.Font, FontStyle.Bold Or FontStyle.Underline)
      item.TextAlign = ContentAlignment.MiddleCenter

      For Each func As Entidades.FuncionesDocumentos In links
         ctxLinks.Items.Add(String.Format("{0}: {1}", func.DescripcionAbreviadaTipoLink.ToString(), func.Descripcion), Nothing,
                                     Sub(sender, e) TryCatched(Sub() Process.Start(func.Link)))
      Next
   End Sub

   Private Sub lnkCantidadLinks_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkCantidadLinks.LinkClicked
      TryCatched(Sub() ctxLinks.Show(lnkCantidadLinks, New Point(MousePosition.X - PointToScreen(lnkCantidadLinks.Location).X, MousePosition.Y - PointToScreen(lnkCantidadLinks.Location).Y)))
   End Sub
#End Region

#Region "Manejo de Vinculados"
   Private Sub AgregarVinculadas(vinculadas As List(Of Entidades.FuncionVinculada))
      If vinculadas.AnySecure() Then
         For Each vinc In vinculadas
            ctxVinculados.Items.Add(String.Format("{0} -> {1}", vinc.FuncionVinculada.IdPadre, vinc.FuncionVinculada.Nombre), Nothing) ',
            '                        Sub(sender, e) TryCatched(Sub() FindForm().ShowMessage(vinc.FuncionVinculada.Nombre)))
         Next
      End If
   End Sub
   Private Sub lnkFuncionesVinculadas_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFuncionesVinculadas.LinkClicked
      TryCatched(Sub() ctxVinculados.Show(lnkFuncionesVinculadas, New Point(MousePosition.X - PointToScreen(lnkFuncionesVinculadas.Location).X, MousePosition.Y - PointToScreen(lnkFuncionesVinculadas.Location).Y)))
   End Sub

#End Region

   Public Property IdFuncion() As String
      Get
         Return bscCodigoFuncion.Text
      End Get
      Set(value As String)
         Try
            bscCodigoFuncion.Text = value
            If Not String.IsNullOrWhiteSpace(value) Then
               bscCodigoFuncion.PresionarBoton()
            Else
               bscFuncion.Text = String.Empty
            End If
         Catch ex As Exception
            bscCodigoFuncion.Text = String.Empty
            bscFuncion.Text = String.Empty
            FindForm().ShowMessage(String.Format("No se pudo recuperar la Función: {0}", ex.Message))
         End Try
      End Set
   End Property

   Private Sub lnkNombre_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNombre.LinkClicked
      TryCatched(
      Sub()
         Const idFuncionSegFunciones = "SegFunciones"
         Dim func = New Reglas.Funciones().GetUna(bscCodigoFuncion.Text, cargaDocumentos:=True, cargaVinculadas:=True, Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
         Using frm = New FuncionesDetalle(func) With {.IdFuncion = idFuncionSegFunciones}
            frm.StateForm = If(New Reglas.Usuarios().TienePermisos(idFuncionSegFunciones), StateForm.Actualizar, StateForm.Consultar)
            If frm.ShowDialog(FindForm(), "tbpVinculadas") = DialogResult.OK Then
               bscCodigoFuncion.PresionarBoton()
            End If
         End Using
      End Sub)
   End Sub
End Class