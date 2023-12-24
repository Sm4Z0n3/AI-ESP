@echo off
color 0e
node -v > nul 2>&1
if %ERRORLEVEL% equ 0 (
    echo Node.js is installed
    echo Starting [main.js]
    echo ����������������豸������ҳ��������鿴����IP
    echo ----------------------------------------------------------------------------
    ipconfig
    echo ----------------------------------------------------------------------------
    echo .
    echo ����ͨ��http://localhost:8855/����
    node main.js
    echo "Server Closing..."
) else (
    color 0c
    echo Node.js is not installed
    echo Please download Node.js from
    echo https://cdn.npmmirror.com/binaries/node/v18.19.0/node-v18.19.0-x64.msi
)
pause