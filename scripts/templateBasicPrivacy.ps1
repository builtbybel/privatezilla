### Info: Run this template to apply the following policies at once. You can run each policy also individually by selecting it from the list below. ###
###- Disable telemetry in Windows 10
# As you use Windows 10, Microsoft will collect usage information. All its options are available in Settings -> Privacy - Feedback and Diagnostics. There you can set the options "Diagnostic and usage data" to Basic, Enhanced and Full.
# This will set diagnostic data to Basic, which is the lowest level available for all consumer versions of Windows 10
# NOTE: Diagnostic Data must be set to Full to get preview builds from Windows-Insider-Program! Just set the value of the AllowTelemetry key to "3" and run the script. All other changes remain unaffected.
New-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Policies\DataCollection" -Name "AllowTelemetry" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\Policies\DataCollection" -Name "MaxTelemetryAllowed" -Type DWord -Value 1 -Force
# Stop and Disable Diagnostic Tracking Service
New-ItemProperty -Path "HKLM:\SYSTEM\ControlSet001\Services\DiagTrack" -Name "Start" -Type DWord -Value 4 -Force
Stop-Service -Name DiagTrack
Set-Service -Name DiagTrack -StartupType Disabled
# Stop and Disable dmwappushservice Service
New-ItemProperty -Path "HKLM:\SYSTEM\ControlSet001\Services\dmwappushsvc" -Name "Start" -Type DWord -Value 4 -Force
Stop-Service -Name dmwappushservice
Set-Service -Name dmwappushservice -StartupType Disabled

###- Block suggestions and automatic Installation of apps
# Microsoft flushes various apps into the system without being asked, especially games such as Candy Crush Saga. Users have to uninstall these manually if they don't want them on their computer. 
# To prevent these downloads from starting in the first place, a small intervention in the registry helps. Suggested apps pinned to Start are basically just advertising. This script will also disable suggested apps (ex: Candy Crush Soda Saga) for all accounts.
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "ContentDeliveryAllowed" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "OemPreInstalledAppsEnabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "PreInstalledAppsEnabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "reInstalledAppsEverEnabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SilentInstalledAppsEnabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SubscribedContent-338387Enabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SubscribedContent-338388Enabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "ubscribedContent-338389Enabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SubscribedContent-353698Enabled" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\ContentDeliveryManager" -Name "SystemPaneSuggestionsEnabled" -Type DWord -Value 0 -Force
If (!(Test-Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent")) {
New-Item -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent" -Force | Out-Null}
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows\CloudContent" -Name "DisableWindowsConsumerFeatures" -Type DWord -Value 1 -Force

###- Disable Bing in Windows Search
# Like Google, Bing is a search engine that needs your data to improve its search results. Windows 10, by default, sends everything you search for in the Start Menu to their servers to give you results from Bing search.
# These searches are then uploaded to Microsoft's Privacy Dashboard.
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Search" -Name "CortanaConsent" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\Search" -Name "BingSearchEnabled" -Type DWord -Value 0 -Force

###- Disable Location tracking
# When Location Tracking is turned on, Windows and its apps are allowed to detect the current location of your computer or device. 
# This can be used to pinpoint your exact location, e.g. Map traces the location of PC and helps you in exploring nearby restaurants.
If (!(Test-Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location")) {
	New-Item -Path "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location" -Force | Out-Null
}
New-ItemProperty -Path "HKLM:\Software\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\location" -Name "Value" -Type String -Value "Deny" -Force
 
###- Turn off Advertising ID for Relevant Ads
# Windows 10 comes integrated with advertising. Microsoft assigns a unique identificator to track your activity in the Microsoft Store and on UWP apps to target you with relevant ads.
# If someone is giving you personalized ads, it means they are tracking your data. Turn off the advertising feature from Windows 10 with this script to stay secure.
New-ItemProperty -Path "HKCU:\SOFTWARE\Microsoft\Windows\CurrentVersion\AdvertisingInfo" -Name "Enabled" -Type DWord -Value 0 -Force

###- Turn off help Microsoft improve typing and writing
# When the Getting to know you privacy setting is turned on for inking & typing personalization in Windows 10, you can use your typing history and handwriting patterns to create a local user dictionary for you that is used to make better typing suggestions and improve handwriting recognition for each of the languages you use.
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\InputPersonalization" -Name "AllowInputPersonalization" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\InputPersonalization" -Name "RestrictImplicitInkCollection" -Type DWord -Value 1 -Force
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\InputPersonalization" -Name "RestrictImplicitTextCollection" -Type DWord -Value 1 -Force
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows\HandwritingErrorReports" -Name "PreventHandwritingErrorReports" -Type DWord -Value 1 -Force
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows\TabletPC" -Name "PreventHandwritingDataSharing" -Type DWord -Value 1 -Force

###- Do not show feedback notifications
# Windows 10 doesn’t just automatically collect information about your computer usage. It does do that, but it may also pop up from time to time and ask for feedback. 
# This information is used to improve Windows 10 - in theory. As of Windows 10’s “November Update,” the Windows Feedback application is installed by default on all Windows 10 PCs.
# If you are running Windows 10 in a corporate setting, you should likely disable the Windows Feedback prompts that appear every few weeks.
New-ItemProperty -Path "HKCU:\Software\Microsoft\Siuf\Rules" -Name "PeriodInNanoSeconds" -Type DWord -Value 0 -Force
New-ItemProperty -Path "HKCU:\Software\Microsoft\Siuf\Rules" -Name "NumberOfSIUFInPeriod" -Type DWord -Value 0 -Force

###- Disable Clipboard history
# With Windows 10 build 17666 or later, Microsoft has allowed cloud synchronization of clipboard. It is a special feature to sync clipboard content across all your devices connected with your Microsoft Account.
New-ItemProperty -Path "HKCU:\Software\Microsoft\Clipboard" -Name "EnableClipboardHistory" -Type DWord -Value 0 -Force

###- Disable Timeline history
# Microsoft made Timeline available to the public with Windows 10 build 17063. It collects a history of activities you've performed, including files you've opened and web pages you've viewed in Edge.
New-ItemProperty -Path "HKLM:\SOFTWARE\Policies\Microsoft\Windows\System" -Name "EnableActivityFeed" -Type DWord -Value 0 -Force

###- Disable off Wi-Fi Sense
# Wi-Fi Sense is a feature in Windows 10 that allows you to connect to your friends shared Wi-Fi connections. 
# That is, you and your friends may opt to share your or their Wi-Fi connections. If your computer is logged into a Microsoft account, by default it will share your Wi-Fi password with your Skype, Outlook and Facebook friends, which means your Wi-Fi password will be sent to Microsoft.
# You should at least stop your PC from sending your Wi-Fi password.
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\WcmSvc\wifinetworkmanager\config" -Name "AutoConnectAllowedOEM" -Type DWord -Value 0 -Force

###- Disable Customer Experience Improvement Program
Get-ScheduledTask -TaskPath "\Microsoft\Windows\Customer Experience Improvement Program\" | Disable-ScheduledTask

###- Disable Windows Error Reporting
# The error reporting feature in Windows is what produces those alerts after certain program or operating system errors, prompting you to send the information about the problem to Microsoft.
New-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Windows\Windows Error Reporting" -Name "Disabled" -Type DWord -Value 1 -Force
Get-ScheduledTask -TaskName "QueueReporting" | Disable-ScheduledTask

###- Prevent using diagnostic data ###
#Starting with Windows 10 build 15019, a new privacy setting to "let Microsoft provide more tailored experiences with relevant tips and recommendations by using your diagnostic data" has been added.
New-ItemProperty -Path "HKCU:\Software\Microsoft\Windows\CurrentVersion\Privacy" -Name "TailoredExperiencesWithDiagnosticDataEnabled" -Type DWord -Value 0 -Force

### Info: The execution of this template is recommended in case when reinstalling Windows or after major updates.