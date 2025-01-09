Public Class CallesABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CallesDetalle(DirectCast(Me.GetEntidad(), Entidades.Calle))
      End If
      Return New CallesDetalle(New Entidades.Calle)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Calles()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim o As Entidades.Calle = New Entidades.Calle()
      With Me.dgvDatos.ActiveCell.Row
         o = New Reglas.Calles().GetUna(Int32.Parse(.Cells(Entidades.Calle.Columnas.IdCalle.ToString()).Value.ToString()))
         o.IdSucursal = Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal
         o.Usuario = Eniac.Entidades.Usuario.Actual.Nombre
      End With
      Return o
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Personal.Win.Calles.rdlc", "ControlPersonal_Calles", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = ""
         frmImprime.Show()
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Calle.Columnas.IdCalle.ToString()).Header.Caption = "Id"
         .Columns(Entidades.Calle.Columnas.IdCalle.ToString()).Width = 60

         .Columns(Entidades.Calle.Columnas.NombreCalle.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.Calle.Columnas.NombreCalle.ToString()).Width = 250

         .Columns(Entidades.Calle.Columnas.IdLocalidad.ToString()).Header.Caption = "C.P."
         .Columns(Entidades.Calle.Columnas.IdLocalidad.ToString()).Width = 50

         .Columns("NombreLocalidad").Header.Caption = "Localidad"
         .Columns("NombreLocalidad").Width = 120

      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.Calle.Columnas.NombreCalle.ToString()})
   End Sub

#End Region

End Class

