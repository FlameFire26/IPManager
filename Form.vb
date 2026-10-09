Friend Class Form1
	Inherits Form
	Private Declare Function GetSystemMenu Lib "User32" (ByVal hwnd As Integer, ByVal bRevert As Integer) As Integer
	Private Declare Function RemoveMenu Lib "User32" (ByVal hMenu As Integer, ByVal nPosition As Integer, ByVal wFlags As Integer) As Integer
	Private Declare Function GetAsyncKeyState Lib "User32" (ByVal vKey As Integer) As Short
	Private Declare Function GetTickCount Lib "kernel32" () As Integer

	Public Function GetTime() As Date
		Return Hour(Now) & ":" & Minute(Now)
	End Function

	Public Sub ChangeOldIP()
		Dim p As New Process()
		p.StartInfo.FileName = "cmd.exe"
		p.StartInfo.UseShellExecute = False
		p.StartInfo.RedirectStandardInput = True
		p.StartInfo.RedirectStandardOutput = True
		p.StartInfo.RedirectStandardError = True
		p.StartInfo.CreateNoWindow = True
		p.Start()
		p.StandardInput.WriteLine("netsh interface ip set address " + " ""本地连接"" " + " static 10.20.1.236 255.255.255.0 10.20.1.254")
		'p.StandardInput.WriteLine("netsh -c interface ip set dns name=" + " ""本地连接"" " + " source=static addr=220.189.127.107 register=PRIMARY")
		p.StandardInput.WriteLine("exit")
		Dim strMessage As String = p.StandardOutput.ReadToEnd()
		p.Close()
	End Sub

	Public Sub ChangeNewIP()
		Dim p As New Process()
		p.StartInfo.FileName = "cmd.exe"
		p.StartInfo.UseShellExecute = False
		p.StartInfo.RedirectStandardInput = True
		p.StartInfo.RedirectStandardOutput = True
		p.StartInfo.RedirectStandardError = True
		p.StartInfo.CreateNoWindow = True
		p.Start()
		p.StandardInput.WriteLine("netsh interface ip set address " + " ""本地连接"" " + " static 10.20.1.98 255.255.255.0 10.20.1.254")
		'p.StandardInput.WriteLine("netsh -c interface ip set dns name=" + " ""本地连接"" " + " source=static addr=220.189.127.107 register=PRIMARY")
		p.StandardInput.WriteLine("exit")
		Dim strMessage As String = p.StandardOutput.ReadToEnd()
		p.Close()
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		If GetTime() > "5:30" And GetTime() < "6:50" Then
			ChangeNewIP()
		Else
			ChangeOldIP()
		End If
	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		MsgBox(GetTime() = "17:24")
	End Sub
End Class