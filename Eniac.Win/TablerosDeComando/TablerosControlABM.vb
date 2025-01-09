Imports Eniac.Entidades
Imports Eniac.Reglas
Public Class TablerosControlABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
   End Sub
   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As Win.BaseDetalle
      Dim eControl As Entidades.TableroControl = DirectCast(Me.GetEntidad(), Entidades.TableroControl)
      Dim idTabCtrlPanel As Integer = 0
      If eControl IsNot Nothing Then idTabCtrlPanel = eControl.IdTableroControlPanel1
      If estado = StateForm.Actualizar Then
         If eControl Is Nothing Then Throw New Exception("Seleccione un Control a modificar.")
         Return New TablerosControlDetalle(idTabCtrlPanel, eControl)
      End If
      Return New TablerosControlDetalle(idTabCtrlPanel, New Entidades.TableroControl())
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Base
      Return New Reglas.TablerosControl()
   End Function
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidad
      Dim eTabCtrl As Entidades.TableroControl = New Entidades.TableroControl
      If dgvDatos.ActiveRow IsNot Nothing Then
         With Me.dgvDatos.ActiveRow
            eTabCtrl = New Reglas.TablerosControl().GetUno(Integer.Parse(.Cells("IdTableroControl").Value.ToString()))
         End With
      End If
      Return eTabCtrl
   End Function
   'IMPRIMIR no hay rdlc por el momento
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub
   'FORMATEAR GRILLAS
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.TableroControl.Columnas.IdTableroControl.ToString()).FormatearColumna("Código Control", col, 80, HAlign.Right)
         .Columns(Entidades.TableroControl.Columnas.NombreTableroControl.ToString()).FormatearColumna("Nombre", col, 150, HAlign.Left)
         .Columns(Entidades.TableroControl.Columnas.IdTableroControlPanel1.ToString()).FormatearColumna("Código Panel de Control 1", col, 80, HAlign.Right)
         '.Columns(Entidades.TableroControlPanel.Columnas.NombrePanel.ToString()).FormatearColumna("Nombre Panel de Controll", col, 150)
         .Columns(Entidades.TableroControl.Columnas.IdTableroControlPanel2.ToString()).FormatearColumna("Código Panel de Control 2", col, 80, HAlign.Right)
         .Columns(Entidades.TableroControl.Columnas.IdTableroControlPanel3.ToString()).FormatearColumna("Código Panel de Control 3", col, 80, HAlign.Right)
         .Columns(Entidades.TableroControl.Columnas.IdTableroControlPanel4.ToString()).FormatearColumna("Código Panel de Control 4", col, 80, HAlign.Right)
         .Columns(Entidades.TableroControl.Columnas.IdTableroControlPanel5.ToString()).FormatearColumna("Código Panel de Control 5", col, 80, HAlign.Right)
         .Columns(Entidades.TableroControl.Columnas.IdTableroControlPanel6.ToString()).FormatearColumna("Código Panel de Control 6", col, 80, HAlign.Right)
         .Columns(Entidades.TableroControl.Columnas.IdControllerFiltro.ToString()).FormatearColumna("Filtro", col, 250, HAlign.Left)
      End With
   End Sub
#End Region
End Class