package main

import (
	"os"

	"github.com/EstefanyMontiel/p2p_chat/internal/peer"
)

func main(){

	operation  := os.Args[1]
	connection := os.Args[2]
	username := os.Args[3]
	
	if operation == "connect"{
		peer.ConnectToPeer(connection,username)	
	} else {
<<<<<<< Updated upstream
		peer.StarListening(connection,username)
=======
		peer.StartListening(connection,username)
>>>>>>> Stashed changes
	}
}
