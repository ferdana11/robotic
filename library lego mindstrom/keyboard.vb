Imports System.Windows.Forms

Namespace robotik_informatika_controller

    ''' <summary>
    ''' class yang berfungsi untuk mendapatkan nilai pada keyboard
    ''' </summary>
    ''' <remarks></remarks>
    Public Class keyboard
        Private Declare Function GetAsyncKeyState Lib "user32" (ByVal key As Int32) As Int16

        ''' <summary>
        ''' fungsi untuk mendapatkan nilai ketukan tonbol keyboard
        ''' </summary>
        ''' <param name="kode">kode keyboard nilai true menunjukkan tombol ditekan false menunjukkan tombol tidak ditekan </param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function tekan_tombol(ByVal kode As Keys) As Boolean
            Dim tekan As Boolean

            tekan = GetAsyncKeyState(kode)

            If tekan = True Then
                Return True
            ElseIf tekan = False Then
                Return False

            End If
        End Function
    End Class

End Namespace