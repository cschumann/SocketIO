//
//  FirstViewController.swift
//  ChatTest
//
//  Created by Christopher Schumann on 05/08/2015.
//  Copyright (c) 2015 Frequency 21. All rights reserved.
//

import UIKit

class FirstViewController: UIViewController {
    
    let socket = SocketIOClient(socketURL: "http://192.168.0.5:3000", opts:["log":true])
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        self.socket.on("connect") {data, ack in
            println("socket connected")
            self.socket.emit("login","Jack");
        }
        
        self.socket.on("chat message") {data, ack in
            println("Chat message received")
            
        }
        
        
        self.socket.connect()
        

        // Do any additional setup after loading the view, typically from a nib.
    }

    @IBAction func buttonTapped(sender: AnyObject) {
        NSLog("Button tapped");
        
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

