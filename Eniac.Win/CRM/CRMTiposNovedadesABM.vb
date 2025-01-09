Option Strict On
Option Explicit On
Imports Eniac.Win
Public Class CRMTiposNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMTiposNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMTipoNovedad))
      End If
      Return New CRMTiposNovedadesDetalle(New Eniac.Entidades.CRMTipoNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMTiposNovedades()
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = GetReglas()
               Me._entidad = Me.GetEntidad()
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.CRMTiposNovedades().GetUno(.Cells("IdTipoNovedad").Value.ToString())
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString()),
                                          "Código", col, 90)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()),
                                          "Descripción", col, 250)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.UnidadDeMedida.ToString()),
                                          "U.M.", col, 60, HAlign.Center)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.UsuarioRequerido.ToString()),
                                          "Usuario Requerido", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.UsuarioPorDefecto.ToString()),
                                          "Usuario x Defecto", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.ProximoContactoRequerido.ToString()),
                                          "Próximo Contacto Requerido", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.DiasProximoContacto.ToString()),
                                          "Días Próx. Contacto", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString()),
                                          "Primer Orden", col, 120, , True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenDesc.ToString()),
                                          "Desc.", col, 60, , True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString()),
                                          "Segundo Orden", col, 120, , True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenDesc.ToString()),
                                          "Desc.", col, 60, , True)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.VisualizaOtrasNovedades.ToString()),
                                          "Visualiza Otras", col, 60)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.VisualizaRevisionAdministrativa.ToString()),
                                          "Visualiza Rev. Admin.", col, 60)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.PermiteBorrarComentarios.ToString()),
                                 "Permite Borrar Comentarios", col, 60)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.PermiteIngresarNumero.ToString()),
                                 "Permite Ingresar Número", col, 60)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.ReportaAvance.ToString()),
                        "Reporta Avance", col, 60)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.ReportaCantidad.ToString()),
                        "Reporta Cantidad", col, 60)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.VerCambios.ToString()),
                       "Ver Cambios", col, 60)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.Reporte.ToString()), "Reporte", col, 200)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.Embebido.ToString()), "Embebido", col, 65)

         If Not .Columns.Exists(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString() + "_desc") Then
            .Columns.Add(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString() + "_desc")
            Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString() + "_desc"),
                                             "Primer Orden", col, 120)
         End If
         If Not .Columns.Exists(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString() + "_desc") Then
            .Columns.Add(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString() + "_desc")
            Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString() + "_desc"),
                                             "Segundo Orden", col, 120)
         End If

         FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.CantidadCopias.ToString()), "Copias", col, 55, HAlign.Right)

         FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.LetrasHabilitadas.ToString()), "Letras Habilitadas", col, 55, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.RequierePadre.ToString()), "Requiere Padre", col, 55, HAlign.Center)
         FormatearColumna(.Columns(Entidades.CRMTipoNovedad.Columnas.SolapaPorDefecto.ToString()), "Solapa por Defecto", col, 80, HAlign.Left)
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()})
   End Sub

#End Region

   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         With Me.dgvDatos.DisplayLayout.Bands(0)
            Dim valor As String
            Dim valorOriginal As String
            If .Columns.Exists(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString() + "_desc") Then
               valorOriginal = e.Row.Cells(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString()).Value.ToString()
               valor = Publicos.GetEnumString(DirectCast([Enum].Parse(GetType(Entidades.CRMNovedad.ColInformeDeNovedades), valorOriginal), Entidades.CRMNovedad.ColInformeDeNovedades))
               e.Row.Cells(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString() + "_desc").Value = valor
            End If

            If .Columns.Exists(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString() + "_desc") Then
               valorOriginal = e.Row.Cells(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString()).Value.ToString()
               If Not String.IsNullOrWhiteSpace(valorOriginal) Then
                  valor = Publicos.GetEnumString(DirectCast([Enum].Parse(GetType(Entidades.CRMNovedad.ColInformeDeNovedades), valorOriginal), Entidades.CRMNovedad.ColInformeDeNovedades))
                  e.Row.Cells(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString() + "_desc").Value = valor
               End If
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class