# Battleship
The client side of a 2D turn-based game I developed using Unity. The server side can be found at https://github.com/cezara98t/GameRestApi.
A video demo is available in the repository (gameplay.mp4).

The game can be played in 2, the server takes care of this by numbering the players, when a second one enters (or any even number), the opposing player is set, which starts the game on the client. The player must select 6 boxes in which to hide his gold, and after the opponent enters the game, he must find all the money hidden by him. The players take turns to select squares, searching for gold. When the player finds gold, he receives 10 points, and when he does not hit, 1 point is deducted. The first to discover all the opponent's gold can "run" with it, by pressing the now available button, "Run with the money", which opens a new scene in which he controls a thief with the keyboard arrow keys. If the thief touches a wall, 10% of the score is deducted and his position is reset to the initial one. In the scene there is also an animation of a gold coin, and if the thief takes it, the score doubles. The game ends when the thief reaches the green area.

![alt text](https://github.com/cezara98t/Battleship/blob/master/Gameplay.png)
