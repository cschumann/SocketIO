var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

app.get('/', function(req, res){
  res.sendfile('index.html');
});

io.on('connection', function(socket){
  console.log('a user connected');

  socket.on('login', function(data){
    socket.join(data);
    console.log(data + ' joined');
  });;

  socket.on('disconnect', function(){
    console.log(socket);
  });

  socket.on('chat message', function(msg){
    var message = JSON.parse(msg);
    console.log('message: ' + message.body);
    console.log('recipientName: ' + message.recipientName);
    io.sockets.in(message.recipientName).emit('chat message', msg);
  });  
});

http.listen(3000, function(){
  console.log('listening on *:3000');
});