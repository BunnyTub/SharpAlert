Option Explicit

Dim fso, shell, result, path

Set fso = CreateObject("Scripting.FileSystemObject")
Set shell = CreateObject("WScript.Shell")

path = shell.ExpandEnvironmentStrings("%LOCALAPPDATA%\SharpAlert")

result = MsgBox("Do you want to delete all SharpAlert data, including your settings, exports, archives, and plugins?", vbYesNo + vbQuestion, "SharpAlert - Uninstaller")

If result = vbYes Then
    If fso.FolderExists(path) Then
        On Error Resume Next
        fso.DeleteFolder path, True
        If Err.Number = 0 Then
            MsgBox "All SharpAlert data was deleted.", vbInformation, "SharpAlert - Uninstaller"
        Else
            MsgBox "Couldn't delete the SharpAlert data. You may try manually deleting it here: %LocalAppData%\SharpAlert", vbExclamation, "SharpAlert - Uninstaller"
        End If
        On Error GoTo 0
    Else
	MsgBox "There is no SharpAlert data to delete.", vbInformation, "SharpAlert - Uninstaller"
    End If
End If

WScript.Sleep 1000

MsgBox "Thank you for using SharpAlert. You can find more of BunnyTub's software at https://bunnytub.com!", vbInformation, "SharpAlert - Uninstaller"
