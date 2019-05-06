# Game-Engines-2-Project
Name: Tom Eustace

Student Number: C16304583
# Description of the assignment
This project is an autonomous sci-fi cutscene based on the film The Matrix(1999), initially we see the Nebuchanezzar stationary at the entrance to a tunnel, after a few seconds it begins to move and when it makes it to the end of the tunnel we see that it is being pursued by enemy sentinelles. As the Nebuchanezzar escapes the tunnel we see hundreds more enemies swarming. The Nebuchanezzar fends them off with bullets and EMPS and on the second EMP all of the sentinelles freeze. The Nebuchanezzar uses this time to park in a tunnel and turn off it's power, cloaking it. At the end we see the sentinelles start up again and pass by the tunnel unknowingly.
# Instructions
All you have to do is press play
# How it works
The Nebuchanezzar uses both the Path and Flee behaviour scripts depending on how close the sentinelles are, The Sentinelles alter between Seek, Offset Pursue and a script that I wrote called Seperate. The Sentinelles initially follow the Seek behaviour until they get close enough to the Nebuchanezzar at which point they switch to Offset Pursue to realign instead of crashing into it. If at any point they get too close to another Sentinelle their other behaviours are overidden by the Seperate. A script on the Nebuchanezzar controls the shooting and EMP aspects and also tells the Sentinelles when to freeze.
# What I am most proud of in this assignment
I am most proud of the Sentinelle's behaviours, I was happy to see that my Seperate script worked as intended. It can be a little janky at times but overall I was pleased with it. I also like how the sentinelles merge and cross over eachother at the beginning when you first see them as well as the visual of the wide-shot where the EMP first goes off and all the Sentinelles are visible.

Youtube video of Assignment:
[![](https://www.youtube.com/upload_thumbnail?v=LDsHeReBJmo&t=hqdefault&ts=1557182686741)](https://youtu.be/LDsHeReBJmo)]

![](sent.gif)

![Nebuchadnezzar](https://images4.alphacoders.com/962/thumb-1920-962514.jpg)
