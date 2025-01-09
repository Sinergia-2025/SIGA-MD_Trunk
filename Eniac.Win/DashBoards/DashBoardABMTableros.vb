#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class DashBoardABMTableros
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   'Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
   '   If estado = StateForm.Actualizar Then
   '      Return New DashBoardABMTablerosDetalle(DirectCast(Me.GetEntidad(), Entidades.DashBoardTablero))
   '   End If
   '   Return New DashBoardABMTablerosDetalle(New Entidades.DashBoardTablero())
   'End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.DashBoardTableros()
   End Function
   ''' <summary>
   ''' Recupera Entidad.- --
   ''' </summary>
   ''' <returns></returns>
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      '-- Define Entidad DashBoard.- ---------
      Dim DashBoard = New Entidades.DashBoardTablero
      '---------------------------------------
      With Me.dgvDatos.ActiveRow
         DashBoard = New Reglas.DashBoardTableros().GetUno(Integer.Parse(.Cells("IdTablero").Value.ToString()))
      End With
      Return DashBoard
   End Function
   ''' <summary>
   ''' 
   ''' </summary>
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         '-----------------------------------------------------------------------------------------------------------------------
         .Columns(Entidades.DashBoardTablero.Columnas.IdTableros.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.DashBoardTablero.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 200)
         .Columns(Entidades.DashBoardTablero.Columnas.Estados.ToString()).FormatearColumna("Estados", col, 90, HAlign.Right)
         '-----------------------------------------------------------------------------------------------------------------------
      End With
   End Sub
#End Region
End Class