var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

io.on('connection', function (socket) {
    console.log('a user connected');

    socket.on('login', function (data) {
        socket.join(data);
        console.log(data + ' joined');
    });;

    socket.on('disconnect', function () {
        console.log('user disconnected');
    });

    socket.on('chat message', function (msg) {
        var message = JSON.parse(msg);
        console.log('message: ' + message.body);
        console.log('recipientName: ' + message.recipientName);
        io.sockets.in(message.recipientName).emit('chat message', msg);
    });

    socket.on('status', function (msg) {
        var message = JSON.parse(msg);
        console.log('status: ' + message.info);
        console.log('recipientName: ' + message.recipientName);
        io.sockets.in(message.recipientName).emit('status', msg);
    });

});

http.listen(3000, function () {
    console.log('listening on *:3000');
});