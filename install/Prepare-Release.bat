@echo off
setlocal enableextensions

set PLUGIN=FsiFriendly

mkdir %PLUGIN%.7.1 2> NUL
copy /y ..\src\resharper-fsi-friendly\bin\Release\*.* %PLUGIN%.7.1\
