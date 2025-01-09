Option Explicit On
Option Strict On

Imports Eniac.Win
'Imports Eniac.SiSeN.Entidades

Public Class DocumentosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New DocumentosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Documento))
      End If
      Return New DocumentosDetalle(New Entidades.Documento)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Documentos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim Documento As Entidades.Documento = New Entidades.Documento
      With Me.dgvDatos.ActiveCell.Row
         Documento.idDocumento = Integer.Parse(.Cells(Entidades.Documento.Columnas.idDocumento.ToString()).Value.ToString())
         Documento = New Reglas.Documentos().GetUno(Documento.idDocumento)
      End With
      Return Documento
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.Documento.Columnas.idDocumento.ToString()).Hidden = True
         .Columns(Entidades.Documento.Columnas.Nombre.ToString()).Header.Caption = "Nombre"
         .Columns(Entidades.Documento.Columnas.Nombre.ToString()).Width = 400
         .Columns(Entidades.Documento.Columnas.Version.ToString()).CellAppearance.TextHAlign = HAlign.Right
         .Columns(Entidades.Documento.Columnas.Version.ToString()).Header.Caption = "Version"
         .Columns(Entidades.Documento.Columnas.Version.ToString()).Width = 70
         .Columns(Entidades.Documento.Columnas.Grupo.ToString()).Header.Caption = "Grupo"
         .Columns(Entidades.Documento.Columnas.Grupo.ToString()).Width = 100
         .Columns(Entidades.Documento.Columnas.Documento.ToString()).Hidden = True
      End With
   End Sub

#End Region

End Class