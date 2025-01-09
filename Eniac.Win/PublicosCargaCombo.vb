Partial Class Publicos


   Public Sub CargaComboCRMTiposComentariosNovedades(combo As Eniac.Controles.ComboBox, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString()
         .ValueMember = Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString()
         .DataSource = New Reglas.CRMTiposComentariosNovedades().GetTodos(idTipoNovedad, True)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMTiposComentariosNovedades(combo As Infragistics.Win.UltraWinEditors.UltraComboEditor, Optional idTipoNovedad As String = "")
      With combo
         .DisplayMember = Entidades.CRMTipoComentarioNovedad.Columnas.NombreTipoComentarioNovedad.ToString()
         .ValueMember = Entidades.CRMTipoComentarioNovedad.Columnas.IdTipoComentarioNovedad.ToString()
         .DataSource = New Reglas.CRMTiposComentariosNovedades().GetTodos(idTipoNovedad, True)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboTiposDocumentosFunciones(combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = Entidades.TipoDocumentoFuncion.Columnas.Descripcion.ToString()
         .ValueMember = Entidades.TipoDocumentoFuncion.Columnas.IdTipoLink.ToString()
         .DataSource = New Reglas.TiposDocumentosFunciones().GetTodos(ordenarPosicion:=True)
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboCRMEstadosCiclosPlanificacion(combo As Controles.ComboBox, Optional iniciaPorDefecto As Boolean = True)
      With combo
         .DisplayMember = Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()
         .ValueMember = Entidades.CRMEstadoCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()
         Dim lst = New Reglas.CRMEstadosCiclosPlanificacion().GetTodos()
         .DataSource = lst
         Dim porDefecto = lst.FirstOrDefault(Function(x) x.PorDefecto)
         If iniciaPorDefecto AndAlso porDefecto IsNot Nothing Then
            .SelectedValue = porDefecto.PorDefecto
         Else
            .SelectedValue = -1
         End If
      End With
   End Sub

End Class