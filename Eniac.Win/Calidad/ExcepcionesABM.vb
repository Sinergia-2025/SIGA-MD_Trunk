Public Class ExcepcionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False

      AgregarFiltroEnLinea(dgvDatos, {})
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ExcepcionesDetalle(DirectCast(Me.GetEntidad(), Entidades.Excepcion))
      End If
      Return New ExcepcionesDetalle(New Entidades.Excepcion())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Excepciones()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim en As Entidades.Excepcion = New Entidades.Excepcion()
      With Me.dgvDatos.ActiveCell.Row
         en.IdExcepcion = Integer.Parse(.Cells(Entidades.Excepcion.Columnas.IdExcepcion.ToString()).Value.ToString())
         en = New Reglas.Excepciones().GetUno(en.IdExcepcion)
      End With
      Return en
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns(Entidades.Excepcion.Columnas.IdListaControlTipo.ToString()).FormatearColumna("", pos, 150, , True)
         .Columns(Entidades.Excepcion.Columnas.IdExcepcionTipo.ToString()).FormatearColumna("", pos, 150, , True)
         .Columns(Entidades.Excepcion.Columnas.IdExcepcion.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.Excepcion.Columnas.Dpto.ToString()).FormatearColumna("Departamento", pos, 100, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.IdUsuario.ToString()).FormatearColumna("Solicitante", pos, 80, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.FechaExcepcion.ToString()).FormatearColumna("Fecha", pos, 80, HAlign.Left)
         .Columns(Entidades.ListaControlTipo.Columnas.NombreListaControlTipo.ToString()).FormatearColumna("Sección", pos, 100, HAlign.Left)
         .Columns(Entidades.ExcepcionTipo.Columnas.NombreExcepcionTipo.ToString()).FormatearColumna("Tipo", pos, 150, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.Item.ToString()).FormatearColumna("Item", pos, 100, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.Motivo.ToString()).FormatearColumna("Motivo", pos, 300, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.AccionesCorrectivas.ToString()).FormatearColumna("Acciones Correctivas", pos, 300, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.IdUsuario1.ToString()).FormatearColumna("Autorizante 1", pos, 80, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.FechaUsuario1.ToString()).FormatearColumna("Fecha", pos, 80, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.IdUsuario2.ToString()).FormatearColumna("Autorizante 2", pos, 80, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.FechaUsuario2.ToString()).FormatearColumna("Fecha", pos, 80, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.IdUsuario3.ToString()).FormatearColumna("Autorizante 3", pos, 80, HAlign.Left)
         .Columns(Entidades.Excepcion.Columnas.FechaUsuario3.ToString()).FormatearColumna("Fecha", pos, 80, HAlign.Left)

      End With
   End Sub
#End Region

End Class