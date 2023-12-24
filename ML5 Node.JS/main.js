const express = require('express');
const http = require('http');
const fs = require('fs');

const app = express();

app.use(express.static('./public')); // 用于提供静态文件（如HTML、CSS和JavaScript）

app.get('/', (req, res) => {
  const html = fs.readFileSync('index.html', 'utf8');
  res.send(html);
});

// 启动服务器
const server = http.createServer(app);
const PORT = 8855;
server.listen(PORT, '0.0.0.0', () => {
  console.log(`服务器运行在 http://0.0.0.0:${PORT}/`);
});
