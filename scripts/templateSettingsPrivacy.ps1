### This template will turn off all options under Windows 10 Settings > Privacy page ###
# Windows 10 provides a wealth of data access to make apps useful and valuable to you. 
# These capabilities, which are security constructs that gate access to personal data, include things like Calendar, Contacts, Call History, and more. 
# Each capability has its own privacy settings page so that you can control it and what apps and services can use that capability.

###- Disable app access to account info
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userAccountInformation" -Name Value -Type String -Value Deny -Force

###- Disable app access to calendar
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appointments" -Name Value -Type String -Value Deny -Force

###- Disable app access to call history
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCallHistory" -Name Value -Type String -Value Deny -Force

###- Disable app access to call
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\phoneCall" -Name Value -Type String -Value Deny -Force

###- Disable app access to contacts
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\contacts" -Name Value -Type String -Value Deny -Force

###- Disable app access to diagnostic information
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\appDiagnostics" -Name Value -Type String -Value Deny -Force

###- Disable app access to documents
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\documentsLibrary" -Name Value -Type String -Value Deny -Force

###- Disable app access to email
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\email" -Name Value -Type String -Value Deny -Force

###- Disable app access to file system
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\broadFileSystemAccess" -Name Value -Type String -Value Deny -Force

###- Disable app access to location
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location" -Name Value -Type String -Value Deny -Force

###- Disable app access to messaging
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\chat" -Name Value -Type String -Value Deny -Force

###- Disable app access to microphone
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone" -Name Value -Type String -Value Deny -Force

###- Disable app access to motion
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\activity" -Name Value -Type String -Value Deny -Force

###- Disable app access to notifications
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userNotificationListener" -Type String -Name Value -Value Deny -Force

###- Disable app access to other devices
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\bluetooth" -Name Value -Type String -Value Deny -Force
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\bluetoothSync" -Name Value -Type String -Value Deny -Force

###- Disable app access to pictures
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\picturesLibrary" -Name Value -Type String -Value Deny -Force

###- Disable app access to radios
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\radios" -Name Value -Type String -Value Deny -Force

###- Disable app access to tasks
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\userDataTasks" -Name Value -Type String -Value Deny -Force

###- Disable app access to videos
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\videosLibrary" -Name Value -Type String -Value Deny -Force

###- Disable app access to webcam
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam" -Name Value -Type String -Value Deny -Force

###- Disable apps from running in background
# Disabling this function means, Windows 10 apps have no more permission to run in the background so they can't update their live tiles, fetch new data, and receive notifications.
New-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\BackgroundAccessApplications" -Name GlobalUserDisabled -Type DWord -Value 1 -Force

###- Disable tracking of app starts
# Windows can personalize your Start menu based on the apps that you launch. 
# This allows you to quickly have access to your list of Most used apps both in the Start menu and when you search your device.
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\Advanced" -Name Start_TrackProgs -Type DWord -Value 0 -Force

###- Open privacy settings
$Result = [System.Windows.Forms.MessageBox]::Show("Script has been successfully executed.`r`n`r`nWould you like to open the Settings > Privcay page to check the results?","Spydish",4)
If ($Result -eq "Yes")
{
    Start-Process "ms-settings:privacy-general"
}
