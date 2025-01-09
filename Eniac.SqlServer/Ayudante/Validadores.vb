Option Strict On
Option Explicit On
Namespace Ayudante
   Public Class Validadores
      Inherits Comunes

      Public Sub New(ByVal da As Eniac.Datos.DataAccess)
         MyBase.New(da)
      End Sub

      Public Function ValidaCuit(cuit As String,
                                 donde As Entidades.Ayudante.Validadores.ValidarExistenciaEn,
                                 campo As String,
                                 condicion As String) As Boolean
         Dim nombreCount As String = "cantidad"
         Dim myQuery As StringBuilder = New StringBuilder()
         With myQuery
            .AppendFormat("SELECT COUNT(1) AS {3} FROM {0} WHERE {1} = '{2}'", donde.ToString(), campo, cuit, nombreCount)
            If Not String.IsNullOrWhiteSpace(condicion) Then
               .AppendFormat(" AND {0}", condicion)
            End If
         End With
         Dim dt As DataTable = Me.GetDataTable(myQuery.ToString())
         If dt IsNot Nothing AndAlso dt.Rows.Count > 0 AndAlso IsNumeric(dt.Rows(0)(nombreCount)) AndAlso Integer.Parse(dt.Rows(0)(nombreCount).ToString()) = 0 Then
            Return True
         End If
         Return False
      End Function

   End Class
End Namespace