@echo off
color 0e
node -v > nul 2>&1
if %ERRORLEVEL% equ 0 (
    echo Node.js is installed
    echo Starting [main.js]
    echo 你可以在内网任意设备访问网页，在下面查看内网IP
    echo ----------------------------------------------------------------------------
    ipconfig
    echo ----------------------------------------------------------------------------
    echo .
    echo 本机通过http://localhost:8855/访问
    node main.js
    echo "Server Closing..."
) else (
    color 0c
    echo Node.js is not installed
    echo Please download Node.js from
    echo https://cdn.npmmirror.com/binaries/node/v18.19.0/node-v18.19.0-x64.msi
)
pause