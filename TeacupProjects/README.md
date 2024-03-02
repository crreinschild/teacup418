# Teacup418 Website

This is a series of webpages where I can display information and links for various projects and services that I am hosting on my home network.

## Battleship

This is an implementation of the classic battleship board game as a sort of exercise. It's still on-going but here are the list of current features and future features that may be implemented (as a reminder to myself)

### Current Features

- Create a generic page/room ID to join
- Any room ID can be used (by customizing the URL)
- You can share this URL (room) to any number of other people
- When you join, you are assigned a random ID
- You can give yourself any name and change it at-will
- You can broadcast a message to the room
- You can place 5 ships on the board
- You can rotate a ship by right-clicking before placing (*bug*: does not update until you move your cursor to a different square)
- Once you place all 5 ships, it declares you as ready to other players in the room

### Todo

- Create a countdown once at least 2 players in the room (including yourself) is ready.  The countdown resets whenever another player declares ready.
- Once the countdown hits 0 the game begins
- Show a number of boards equal to the number of players in the round. 
- Each round lasts a number of seconds. A countdown shows how many seconds remaining in the round.
- Each round, each player may guess up to a number of squares across all boards equal to that player's remaining number of ships this round. For example, if you have 3 ships remaining, you may place 3 shots across all boards.
- When the countdown reaches 0 (with delay), all clients declare their players' guesses. Each client is responsible for truthfully declaring misses/hits/sunks on their own board to the rest of the room.
- The rounds continue until only 1 player remains. That player is the winner. After a few seconds the game ends, leaving the room in a state where the players remain, but the boards are cleared.