
/*
 * Expanded Movement 
 * 
 * - For this package I've included a test scene with a test map to try and test out the different movement options.
 * 
 * - In this package you will find, a sprint function, jump & double jump function, wall jump function, and air dash function
 * 
 * - 3 scripts, one that has all the movement things in it labeled "Expanded Movement"
 *  2 extra scripts known as, Camera, and CameraFollow
 *  
 * - Camera follow is a script that allows for the player movement to be linked to the direction the camera is facing, aka holding W foes forward regardless of how ball is facing,
 *  this camera option can be toggeled on by pressing T once to activate it, then pressing T to turn it off. If you want to use this script add it to the player object
 *  
 * - Camera is used to actually follow the ball, you use your mouse to drag the camera, and can use the scroll wheel to zoom in or out. If you want to use this script put
 *  it in the main camera object. Once it's in there drag the player object into the area that says "Target", this is so it will follow the ball
 *  
 * - For expanded movements, put that in the player object
 * 
 * - All 3 of these scripts have customizable fields when added to their objects, so you can disable any feature by making the number 0
 * 
 * - For expanded movement things like double jump can be edited to have as many jumps as you want, and air dash can be edited to have a cool down, as per request,
 *  as well as how much more different options.
 *  
 * - You don't have to use the other 2 camera scripts I added, I did this just since my game isn't going to be top down so I needed them to test more specific stuff, but
 *  they are there if you want them
 *  
 *  Controls:
 *  Sprint: Hold down shift, ball will accelerate, can change accleration speed as well as max speed
 *  
 *  Jump + double jump: Space bar on ground, then space again mid air to jump a second time, amount of jumps & jump force (height) can be edited
 *  
 *  Wall Jump: Press space when against a wall, usually makes you jump in the other direction, you can edit how much vertical and horiontal force you have when you jump off the wall
 *  
 *  Air dash: Press shift while in the air, this dash keeps your current height, once it finishes you start to drop. You can change the cooldown timer, dash speed
 *  as well as how long you want it to last
 *  
 *  Optional Camera stuff:
 *  I've added optional sentivity stuff for if you want to change camera speed at all as well as the zoom feature
 */