Imports ColumnasAgenda = Eniac.Entidades.SistemaE.MensajeMailAgenda.Columnas
Namespace Sistema
   Public Class MensajeMailAgenda
      Inherits Comunes
      Public Sub New(da As Datos.DataAccess)
         MyBase.New(da)
      End Sub
      Public Function GetAgendaUsuarios() As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("SELECT Id {0}, Nombre {1}, ISNULL(NULLIF(CorreoElectronico, ''), MailDireccion) {2}",
                              ColumnasAgenda.IdUsuario.ToString(), ColumnasAgenda.NombreUsuario.ToString(), ColumnasAgenda.MailDireccion.ToString())
            .AppendFormatLine("  FROM Usuarios")
            .AppendFormatLine(" WHERE ISNULL(NULLIF(CorreoElectronico, ''), MailDireccion) <> ''")
         End With
         Return GetDataTable(myQuery)
      End Function
      Public Function GetAgendaClientes() As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("SELECT C.{0}, C.{1}, C.{2}", ColumnasAgenda.IdCliente.ToString(), ColumnasAgenda.CodigoCliente.ToString(), ColumnasAgenda.NombreCliente.ToString())
            .AppendFormatLine("     , C.CorreoElectronico AS {0}", ColumnasAgenda.CorreoPrincipal.ToString())
            .AppendFormatLine("     , C.CorreoAdministrativo AS {0}", ColumnasAgenda.CorreoAdministrativo.ToString())
            .AppendFormatLine("     , C.CorreoElectronico + ';' + C.CorreoAdministrativo AS {0}", ColumnasAgenda.CorreoAdminyPrincipal.ToString())
            .AppendFormatLine("     , CASE WHEN ISNULL(C.CorreoAdministrativo, '') = '' THEN C.CorreoElectronico ELSE C.CorreoAdministrativo END AS {0}", ColumnasAgenda.CorreoAdminoPrincipal.ToString())
            .AppendFormatLine("  FROM Clientes C")
            .AppendFormatLine(" WHERE (C.CorreoAdministrativo <> '' OR C.CorreoElectronico <> '')")
         End With
         Return GetDataTable(myQuery)
      End Function
      Public Function GetAgendaProveedores() As DataTable
         Dim myQuery = New StringBuilder()
         With myQuery
            .AppendFormatLine("SELECT P.{0}, P.{1}, P.{2}", ColumnasAgenda.IdProveedor.ToString(), ColumnasAgenda.CodigoProveedor.ToString(), ColumnasAgenda.NombreProveedor.ToString())
            .AppendFormatLine("     , P.CorreoElectronico AS {0}", ColumnasAgenda.CorreoPrincipal.ToString())
            .AppendFormatLine("     , P.CorreoAdministrativo AS {0}", ColumnasAgenda.CorreoAdministrativo.ToString())
            .AppendFormatLine("     , P.CorreoElectronico + ';' + P.CorreoAdministrativo AS {0}", ColumnasAgenda.CorreoAdminyPrincipal.ToString())
            .AppendFormatLine("     , CASE WHEN ISNULL(P.CorreoAdministrativo, '') = '' THEN P.CorreoElectronico ELSE P.CorreoAdministrativo END AS {0}", ColumnasAgenda.CorreoAdminoPrincipal.ToString())
            .AppendFormatLine("  FROM Proveedores P")
            .AppendFormatLine(" WHERE (P.CorreoAdministrativo <> '' OR P.CorreoElectronico <> '')")
         End With
         Return GetDataTable(myQuery)
      End Function
   End Class
End Namespace