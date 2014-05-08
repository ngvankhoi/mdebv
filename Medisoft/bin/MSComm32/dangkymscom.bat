@ECHO OFF
Echo Dang ky file MSCOMM32.ocx
copy .\MSCOMM32.OCX "C:\WINDOWS\system32\" >null
cd C:\WINDOWS\system32
regsvr32 "C:\WINDOWS\system32\MSCOMM32.OCX" 
@ECHO ON