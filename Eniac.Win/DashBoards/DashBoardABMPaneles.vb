#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class DashBoardABMPaneles
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New DashBoardABMPanelesDetalle(DirectCast(Me.GetEntidad(), Entidades.DashBoardPaneles))
      End If
      Return New DashBoardABMPanelesDetalle(New Entidades.DashBoardPaneles())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.DashBoardsPaneles()
   End Function
   ''' <summary>
   ''' Recupera Entidad.- --
   ''' </summary>
   ''' <returns></returns>
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      '-- Define Entidad DashBoard.- ---------
      Dim DashBoard = New Entidades.DashBoardPaneles
      '---------------------------------------
      With Me.dgvDatos.ActiveRow
         DashBoard = New Reglas.DashBoardsPaneles().GetUno(Integer.Parse(.Cells("IdDashBoard").Value.ToString()))
      End With
      Return DashBoard
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.DashBoardPaneles.Columnas.IdDashBoard.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.DashBoardPaneles.Columnas.Nombre.ToString()).FormatearColumna("Nombre", col, 200)
         .Columns(Entidades.DashBoardPaneles.Columnas.Descripcion.ToString()).FormatearColumna("Tipo DashBoard", col, 100, HAlign.Left)
         .Columns(Entidades.DashBoardPaneles.Columnas.Modelo.ToString()).FormatearColumna("Tipo Modelo", col, 100, HAlign.Left)
         .Columns(Entidades.DashBoardPaneles.Columnas.Titulo.ToString()).FormatearColumna("Titulo", col, 250)
         .Columns(Entidades.DashBoardPaneles.Columnas.Comentario.ToString()).FormatearColumna("Comentario", col, 250)
         .Columns(Entidades.DashBoardPaneles.Columnas.AutoRefresh.ToString()).FormatearColumna("AutoRefresh", col, 90, HAlign.Right)

         .Columns(Entidades.DashBoardPaneles.Columnas.ValorObjetivo.ToString()).FormatearColumna("Valor Máximo", col, 90, HAlign.Right)
         .Columns(Entidades.DashBoardPaneles.Columnas.ValorMinimo.ToString()).FormatearColumna("Valor Mínimo", col, 90, HAlign.Right)

         .Columns(Entidades.DashBoardPaneles.Columnas.Estado.ToString()).FormatearColumna("Estado", col, 90, HAlign.Right)
         .Columns(Entidades.DashBoardPaneles.Columnas.Orden.ToString()).FormatearColumna("Orden", col, 90, HAlign.Right)

         '-- Campos Ocultos de la Grilla.- ------
         .Columns("TipoDashBoard").Hidden = True
         .Columns("SentenciaSQL").Hidden = True
         .Columns("TimerRefresh").Hidden = True
         .Columns("ImagenDashBoard").Hidden = True
         .Columns("Area3DStyle").Hidden = True
         .Columns("ModeloDashBoard").Hidden = True
         .Columns("ShowValueLabel").Hidden = True
         .Columns("AxisTitleX").Hidden = True
         .Columns("AxisTitleY").Hidden = True
         .Columns("TipoRefresh").Hidden = True
         '---------------------------------------
      End With
   End Sub
#End Region
End Class