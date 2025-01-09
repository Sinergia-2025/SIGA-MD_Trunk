Public Class CreaConexionExcel
   Public Shared Function AbrirExcel(archivoXLS As String) As OleDb.OleDbConnection
      Dim m_sConn1 As String

      If archivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & archivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & archivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If

      Dim conexionExcel = New OleDb.OleDbConnection(m_sConn1)

      Return conexionExcel
   End Function
   Public Shared Function CreaDataAdapter(rango As String, conexion As OleDb.OleDbConnection) As OleDb.OleDbDataAdapter
      Return New OleDb.OleDbDataAdapter(String.Format("Select * From {0}", rango), conexion)
   End Function
End Class