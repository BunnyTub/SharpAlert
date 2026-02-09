Option Explicit

Dim shell, result, shortcut, exe, install

install = WScript.Arguments.Named("InstPath")

Set shell = CreateObject("WScript.Shell")

shortcut = shell.ExpandEnvironmentStrings("%APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup\SharpAlert.lnk")

'exe = shell.ExpandEnvironmentStrings("%LOCALAPPDATA%\SharpAlert\SharpAlert.exe")
exe = install & "\SharpAlert.exe"

result = MsgBox("Do you want SharpAlert to start automatically in the background when you sign in to your computer?", vbYesNo + vbQuestion, "SharpAlert - Startup")

If result = vbYes Then
    On Error Resume Next
    Dim shortcut
    Set shortcut = shell.CreateShortcut(shortcut)
    shortcut.TargetPath = exe
    shortcut.WorkingDirectory = shell.ExpandEnvironmentStrings("%LOCALAPPDATA%\SharpAlert")
    shortcut.WindowStyle = 1
    shortcut.Description = "This shortcut was created specifically to be run from the user's startup folder."
    shortcut.Save

    If Err.Number = 0 Then
        'MsgBox "Startup shortcut created successfully! x3", vbInformation, "SharpAlert - Installer"
    Else
        MsgBox "Couldn't create the startup shortcut. You may not have permissions to change the apps that start when you sign in.", vbExclamation, "SharpAlert - Installer"
    End If
    On Error GoTo 0
End If
