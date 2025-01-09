Imports System.Data.Common

Namespace Extensiones
   Module CommandExtensions
      <Extension>
      Public Function AddParameter(cmd As DbCommand, name As String, value As String) As DbParameter
         Return cmd.AddParameter(name, value, DbType.String)
      End Function
      <Extension>
      Public Function AddParameter(cmd As DbCommand, name As String, value As Integer) As DbParameter
         Return cmd.AddParameter(name, value, DbType.Int32)
      End Function
      <Extension>
      Public Function AddParameter(cmd As DbCommand, name As String, value As Object, dataType As DbType) As DbParameter
         Dim param = cmd.CreateParameter()
         param.ParameterName = name
         param.DbType = dataType
         param.Value = value
         cmd.Parameters.Add(param)
         Return param
      End Function
   End Module
End Namespace