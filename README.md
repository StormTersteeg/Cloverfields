![image](https://user-images.githubusercontent.com/42808385/140091995-cb36ff20-a8fa-4071-bee6-0bf7780be79e.png)
# Cloverfields

C# console based sandbox "game".

Change your console font to a rasterfont that preferably has a 1:1 fontsize:<br><br>
![image](https://user-images.githubusercontent.com/42808385/140091774-a5fd2674-59fc-4255-b05b-ce414fd5070e.png)

## Features
Currently, the game has a small set of features that allow the player to place custom objects that consist of the following properties:
- Name (displayed on the interaction list)
- Character (displayed on the map)
- Foreground color (text color)
- Background color (color displayed behind the text)


There are basic "filling" features that allow the player to mark an area that has to be filled with a specific object.
Similar to Minecraft world edit, this system works with 2 points.
- Press `,` to place the marker
- Walk your character to the second location (to form a rectangle)
- Press `.` to fill the area between the marker and the player with an object of choice
- Press `/` to delete all objects in the market area

## Saving
There is a VERY basic saving system available. `]` will export all created objects in the console, this export can be copied and saved into for example a text file. These same objects can be imported again at a later time by pressing `[`, and pasting this export into the game again.
