Option Explicit On
Option Strict On

Public Class AreasComunesABM

#Region "Overrides"

    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Me.tsbImprimir.Visible = False

        'SPC: Para mostrarle a Diego Rolla
        '' ''dgvDatos.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
        '' ''dgvDatos.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
    End Sub
    Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
        If estado = StateForm.Actualizar Then
            Return New AreasComunesDetalle(DirectCast(Me.GetEntidad(), Entidades.AreaComun))
        End If
        Return New AreasComunesDetalle(New Entidades.AreaComun)
    End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AreasComunes()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim AreaComun As Entidades.AreaComun ''= New Entidades.AreaComun
      With Me.dgvDatos.ActiveRow
         AreaComun = DirectCast(GetReglas(), Reglas.AreasComunes).GetUno(.Cells(Entidades.AreaComun.Columnas.IdAreaComun).Value.ToString())
         'AreaComun.IdAreaComun = .Cells(Entidades.AreaComun.Columnas.IdAreaComun).Value.ToString()
         'AreaComun.NombreAreaComun = .Cells(Entidades.AreaComun.Columnas.NombreAreaComun).Value.ToString()
      End With
      Return AreaComun
   End Function
   Protected Overrides Sub FormatearGrilla()
        With Me.dgvDatos.DisplayLayout.Bands(0)

            For Each column As UltraGridColumn In .Columns
                column.CellActivation = Activation.ActivateOnly
            Next

            .Columns(Entidades.AreaComun.Columnas.IdAreaComun.ToString()).Header.Caption = "Area Común"
            .Columns(Entidades.AreaComun.Columnas.IdAreaComun.ToString()).Width = 100
            .Columns(Entidades.AreaComun.Columnas.NombreAreaComun.ToString()).Header.Caption = "Nombre"
            .Columns(Entidades.AreaComun.Columnas.NombreAreaComun.ToString()).Width = 200
            .Columns(Entidades.AreaComun.Columnas.ParticipaExpensas.ToString()).Header.Caption = "Expensas"
            .Columns(Entidades.AreaComun.Columnas.ParticipaExpensas.ToString()).Width = 80

            .Columns(Entidades.Nave.Columnas.NombreNave.ToString()).Header.Caption = "Nave"
            .Columns(Entidades.Nave.Columnas.NombreNave.ToString()).Width = 130
            .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Cliente"
            .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Width = 140

            .Columns(Entidades.AreaComun.Columnas.Superficie.ToString()).Header.Caption = "Mts2"
            .Columns(Entidades.AreaComun.Columnas.Superficie.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(Entidades.AreaComun.Columnas.Superficie.ToString()).Width = 50

            .Columns(Entidades.AreaComun.Columnas.Coeficiente.ToString()).Header.Caption = "Coeficiente"
            .Columns(Entidades.AreaComun.Columnas.Coeficiente.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(Entidades.AreaComun.Columnas.Coeficiente.ToString()).Width = 80
            .Columns(Entidades.AreaComun.Columnas.Coeficiente.ToString()).Format = "N7"
            .Columns(Entidades.AreaComun.Columnas.Coeficiente.ToString()).MaskInput = "{double:-9.7}"

            .Columns(Entidades.AreaComun.Columnas.IdNave.ToString()).Hidden = True
            .Columns(Entidades.AreaComun.Columnas.IdCliente.ToString()).Hidden = True
        End With
    End Sub

#End Region

End Class
