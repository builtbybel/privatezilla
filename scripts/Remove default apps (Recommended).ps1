### This script allows you to remove unwanted Apps that come with Windows within a GUI. ###
### Press <CTRL> if you want to select and remove mutliple apps at the same time
Get-AppxPackage -AllUsers | Out-GridView -PassThru | Remove-AppxPackage