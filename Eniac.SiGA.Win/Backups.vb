
Public Class Backups
   Public Shared base1 As String = Ayudantes.Conexiones.Base ' System.Configuration.ConfigurationManager.AppSettings("BaseBackup").ToString()
   Public Shared baseSegu1 As String = System.Configuration.ConfigurationManager.AppSettings("BaseBackupSegu").ToString()
   Public Shared path1 As String = System.Configuration.ConfigurationManager.AppSettings("PathBackup").ToString()
   Public Shared pathSegu1 As String = System.Configuration.ConfigurationManager.AppSettings("PathBackupSegu").ToString()
   'Public Shared postExt As String = 

   Public Sub New()
      MyBase.New(base1, baseSegu1, String.Format("{0}_{1:yyyyMMdd_HHmmss}_v{2}.bak", base1, DateTime.Now, Application.ProductVersion), _
                 String.Format("{0}_{1:yyyyMMdd_HHmmss}_v{2}.bak", baseSegu1, DateTime.Now, Application.ProductVersion), path1, pathSegu1)
   End Sub

 
End Class