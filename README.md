# AI ESP
 AI ESP
# 项目未完成！
## 项目介绍
C#的项目目前有很大的BUG，所使用的模型无法正常检测屏幕上的人体。
而Node.JS和ML5的版本可以正确运行
但是由于浏览器前端的限制（或者我的技术限制？）
运行起来检测和处理摄像头视频流时十分卡顿

# 安装和使用
## 安装
### C#
C#直接使用Visual Studio打开项目运行即可

如果你没有Visual Studio，可以下载[Visual Studio Code](https://code.visualstudio.com/)，然后安装[C#插件](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
### Node.JS
#### Windows
如果你使用Windows系统，那么我已经在Node.JS ML5文件夹中添加了一个[Start.bat]，直接运行它即可
#### Linux
如果你使用Linux系统，那么你需要安装Node.JS和npm
使用以下指令进行安装
``` bash
sudo apt-get update
```
```bash
sudo apt-get install nodejs
```
```bash
sudo apt-get install npm
```
```bash
sudo npm install
```
```bash
mkdir AI-ESP
```
```bash
cd AI-ESP
```
```bash
git clone https://github.com/Sm4Z0n3/AI-ESP.git
```
```bash
node main.js
```
#### Termux
如果你使用Android系统的Termux，那么你可以使用以下指令进行安装
``` bash
sudo apt update
```
```bash
apt upgrade
```
```bash
apt install coreutils
```
```bash
sudo apt install nodejs
```
```bash
sudo apt install npm
```
```bash
sudo npm install
```
```bash
sudo apt install git
```
```bash
mkdir AI-ESP
```
```bash
cd AI-ESP
```
```bash
git clone https://github.com/Sm4Z0n3/AI-ESP.git
```
```bash
node main.js
```

## 使用
### C#
安装OBS，在[来源]添加[显示器采集]、或者[游戏采集]和[窗口采集]
然后点击右侧[启动虚拟摄像机]，点击右侧设置按钮，选择你刚刚添加的来源
然后启动C#程序
<pre>
1. e2eSoft iVCam
2. OBS Virtual Camera
请输入摄像头序号以开始接收视频流：
>>> 2
</pre>
### Node.JS
安装OBS，在[来源]添加[显示器采集]、或者[游戏采集]和[窗口采集]
然后点击右侧[启动虚拟摄像机]，点击右侧设置按钮，选择你刚刚添加的来源
然后使用
```
node main.js
```
启动程序
可以自行在浏览器内设置摄像机视频源信息