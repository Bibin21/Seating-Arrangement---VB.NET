Imports System
Imports System.Collections

Namespace arrangements
    Class Program
        Protected Function arrangements(ByVal inputs As String) As String
            Dim val As String = inputs
            Dim count As Integer = 0, j As Integer = 0
            Dim arr As String()
            Dim col As String = "", res As String = "", dep As String = "", rollno As String = "", temproll As String = "", prevyear As String = "", prevcol As String = "", prevdep As String = "", prevrol As String = "", year As String = "", temp As String = "", start As String = "", [end] As String = ""
            Dim indexes As ArrayList = New ArrayList()
            indexes.Add(1)

            For Each ch In val
                j += 1

                If ch = ","c Then
                    indexes.Add(j)
                    count += 1
                End If
            Next

            indexes.Add(j)
            Dim len As Integer = j
            Dim years As ArrayList = New ArrayList()
            Dim flag1 As Integer = 0, flag2 As Integer = 0
            Dim Colleges As ArrayList = New ArrayList()
            Dim depts As ArrayList = New ArrayList()
            Dim count1 As Integer = 0, count2 As Integer = 0

            For i As Integer = 0 To count
                prevyear = year
                prevdep = dep
                prevcol = col
                prevrol = rollno
                dep = ""
                col = ""
                year = ""
                rollno = ""
                flag2 = 0
                flag1 = 0

                For j = CInt(indexes(i)) - 1 To CInt(indexes(i + 1)) - 1

                    If (Char.IsLetter(val(j))) AndAlso (flag1 = 0) Then
                        col = col & val(j)
                    ElseIf (Char.IsDigit(val(j))) AndAlso (flag2 = 0) Then
                        year = year & val(j)
                        flag1 = 1
                    ElseIf (Char.IsLetter(val(j))) AndAlso (flag1 = 1) Then
                        flag2 = 1
                        dep = dep & val(j)
                    ElseIf (Char.IsDigit(val(j))) AndAlso (flag2 = 1) Then
                        rollno = rollno & val(j)
                    End If
                Next

                If (prevyear = year) AndAlso (prevdep = dep) AndAlso (prevcol = col) AndAlso (Int16.Parse(prevrol) = Int16.Parse(rollno) - 1) Then
                    If count1 = 0 Then start = prevrol
                    [end] = rollno
                    count1 += 1
                ElseIf (prevyear = year) AndAlso (prevdep = dep) AndAlso (prevcol = col) Then

                    If [end] <> "" Then
                        res = res & ", " & col & year & dep & start & "-" & [end]
                    Else
                        res = res & ", " & col & year & dep & prevrol
                    End If

                    start = ""
                    [end] = ""
                    count1 = 0
                Else

                    If [end] <> "" Then
                        res = res & ", " & prevcol & prevyear & prevdep & start & "-" & [end]
                    Else
                        res = res & ", " & prevcol & prevyear & prevdep & prevrol
                    End If

                    count1 = 0
                    start = ""
                    [end] = ""
                End If
            Next

            If [end] <> "" Then
                res = res & ", " & col & year & dep & start & "-" & [end]
            Else
                res = res & ", " & col & year & dep & rollno
            End If
            Dim trimchars() As Char = {",", " "}
            res = res.Trim(trimchars)
            Return res
        End Function

        Public Shared Sub Main(ByVal args As String())
            Dim P As Program = New Program()
            Dim res As String = P.arrangements("CET21EE001, PTA21EE003, PTA21EE004, PTA21EE005, PTA21EE006, PTA21EE007, PTA21EE008, PTA21EE009, PTA21EE010, PTA21EE011")
            Console.WriteLine(res)
        End Sub
    End Class
End Namespace
