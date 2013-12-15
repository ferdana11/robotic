Imports NKH.MindSqualls

Namespace robotik_informatika_ITN_lego

    Public Class info_sensor

#Region "variable dan informasi robot"
        Friend Shared sensor_US As NxtUltrasonicSensor
        Friend Shared sensor_touch As NxtTouchSensor
        Friend Shared sensor_kompas As HiTechnic.HiTechnicCompassSensor
        Friend Shared sensor_cahaya As NxtLightSensor
        Friend Shared sensor_suara As NxtSoundSensor
        Friend Shared hidupkan_lampu_sens_cahaya As Boolean


#End Region



#Region "enumerasi sensor"


        Public Enum port As Integer
            port1 = 1
            port2 = 2
            port3 = 3
            port4 = 4


        End Enum
#End Region

    End Class


#Region "sensor"

    Public Class sensor_sentuh


#Region "sensor touch"
        Public Shared Sub pasangkan(ByVal port As info_sensor.port)
            Select Case port
                Case info_sensor.port.port1
                    info_sensor.sensor_touch = New NxtTouchSensor
                    nxt.robot.Sensor1 = info_sensor.sensor_touch
                    info_sensor.sensor_touch.PollInterval = 1
                Case info_sensor.port.port2
                    info_sensor.sensor_touch = New NxtTouchSensor
                    nxt.robot.Sensor2 = info_sensor.sensor_touch
                    info_sensor.sensor_touch.PollInterval = 1
                Case info_sensor.port.port3
                    info_sensor.sensor_touch = New NxtTouchSensor
                    nxt.robot.Sensor3 = info_sensor.sensor_touch
                    info_sensor.sensor_touch.PollInterval = 1
                Case info_sensor.port.port4
                    info_sensor.sensor_touch = New NxtTouchSensor
                    nxt.robot.Sensor4 = info_sensor.sensor_touch
                    info_sensor.sensor_touch.PollInterval = 1

            End Select

        End Sub

        Public Shared ReadOnly Property apakah_ditekan As Boolean
            Get
                Return info_sensor.sensor_touch.IsPressed
            End Get
        End Property


#End Region
    End Class


    Public Class sensor_ultrasonik
#Region "sensor US"

        Public Shared Sub pasangkan(ByVal port As info_sensor.port)
            Select Case port
                Case info_sensor.port.port1
                    info_sensor.sensor_US = New NxtUltrasonicSensor

                    nxt.robot.Sensor1 = info_sensor.sensor_US
                    info_sensor.sensor_US.PollInterval = 1

                Case info_sensor.port.port2
                    info_sensor.sensor_US = New NxtUltrasonicSensor

                    nxt.robot.Sensor2 = info_sensor.sensor_US
                    info_sensor.sensor_US.PollInterval = 1

                Case info_sensor.port.port3
                    info_sensor.sensor_US = New NxtUltrasonicSensor

                    nxt.robot.Sensor3 = info_sensor.sensor_US
                    info_sensor.sensor_US.PollInterval = 1

                Case info_sensor.port.port4
                    info_sensor.sensor_US = New NxtUltrasonicSensor

                    nxt.robot.Sensor4 = info_sensor.sensor_US
                    info_sensor.sensor_US.PollInterval = 1

            End Select

        End Sub

        Public Shared ReadOnly Property jarak As Byte
            Get
                Return info_sensor.sensor_US.DistanceCm

            End Get
        End Property

#End Region
    End Class


    Public Class sensor_cahaya

#Region "sensor light"
        Public Shared Sub pasangkan(ByVal port As info_sensor.port)
            Select Case port
                Case info_sensor.port.port1
                    info_sensor.sensor_cahaya = New NxtLightSensor

                    nxt.robot.Sensor1 = info_sensor.sensor_cahaya
                    info_sensor.sensor_cahaya.PollInterval = 1

                Case info_sensor.port.port2
                    info_sensor.sensor_cahaya = New NxtLightSensor

                    nxt.robot.Sensor2 = info_sensor.sensor_cahaya
                    info_sensor.sensor_cahaya.PollInterval = 1

                Case info_sensor.port.port3
                    info_sensor.sensor_cahaya = New NxtLightSensor

                    nxt.robot.Sensor3 = info_sensor.sensor_cahaya
                    info_sensor.sensor_cahaya.PollInterval = 1

                Case info_sensor.port.port4
                    info_sensor.sensor_cahaya = New NxtLightSensor

                    nxt.robot.Sensor4 = info_sensor.sensor_cahaya
                    info_sensor.sensor_cahaya.PollInterval = 1

            End Select

        End Sub

        Public Shared ReadOnly Property intensitas_cahaya As Byte
            Get
                Return info_sensor.sensor_cahaya.Intensity

            End Get
        End Property

        Public Shared Property hidupkan_lampu As Boolean
            Get
                Return info_sensor.hidupkan_lampu_sens_cahaya

            End Get
            Set(ByVal value As Boolean)
                If value = True Then
                    info_sensor.sensor_cahaya.GenerateLight = True
                    info_sensor.hidupkan_lampu_sens_cahaya = True
                ElseIf value = False Then
                    info_sensor.sensor_cahaya.GenerateLight = False
                    info_sensor.hidupkan_lampu_sens_cahaya = False

                End If
            End Set
        End Property
#End Region
    End Class


    Public Class sensor_suara

#Region "sensor sound"
        Public Shared Sub pasangkan(ByVal port As info_sensor.port)
            Select Case port
                Case info_sensor.port.port1
                    info_sensor.sensor_suara = New NxtSoundSensor

                    nxt.robot.Sensor1 = info_sensor.sensor_suara
                    info_sensor.sensor_suara.PollInterval = 1

                Case info_sensor.port.port2
                    info_sensor.sensor_suara = New NxtSoundSensor

                    nxt.robot.Sensor2 = info_sensor.sensor_suara
                    info_sensor.sensor_suara.PollInterval = 1

                Case info_sensor.port.port3
                    info_sensor.sensor_suara = New NxtSoundSensor

                    nxt.robot.Sensor3 = info_sensor.sensor_suara
                    info_sensor.sensor_suara.PollInterval = 1

                Case info_sensor.port.port4
                    info_sensor.sensor_suara = New NxtSoundSensor

                    nxt.robot.Sensor4 = info_sensor.sensor_suara
                    info_sensor.sensor_suara.PollInterval = 1
            End Select

        End Sub

        Public Shared ReadOnly Property intensitas_suara As Byte
            Get
                Return info_sensor.sensor_suara.Intensity

            End Get
        End Property
#End Region
    End Class


    Public Class sensor_compas

#Region "sensor compas"
        Public Shared Sub pasangkan(ByVal port As info_sensor.port)
            Select Case port
                Case info_sensor.port.port1
                    info_sensor.sensor_kompas = New HiTechnic.HiTechnicCompassSensor
                    nxt.robot.Sensor1 = info_sensor.sensor_kompas
                    info_sensor.sensor_kompas.PollInterval = 1

                Case info_sensor.port.port2
                    info_sensor.sensor_kompas = New HiTechnic.HiTechnicCompassSensor
                    nxt.robot.Sensor2 = info_sensor.sensor_kompas
                    info_sensor.sensor_kompas.PollInterval = 1

                Case info_sensor.port.port3
                    info_sensor.sensor_kompas = New HiTechnic.HiTechnicCompassSensor
                    nxt.robot.Sensor3 = info_sensor.sensor_kompas
                    info_sensor.sensor_kompas.PollInterval = 1

                Case info_sensor.port.port4
                    info_sensor.sensor_kompas = New HiTechnic.HiTechnicCompassSensor
                    nxt.robot.Sensor4 = info_sensor.sensor_kompas
                    info_sensor.sensor_kompas.PollInterval = 1
            End Select

        End Sub
        Public Shared ReadOnly Property magnitudo As UShort
            Get
                Return info_sensor.sensor_kompas.Heading

            End Get
        End Property


#End Region

    End Class


#End Region



End Namespace


