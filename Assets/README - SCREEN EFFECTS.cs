/*
 * So this package comes with three files:
 *      ScreenEffectsManager, ScreenShake, and ScreenFlash
 * 
 * Please create an empty game object to place your ScreenEffectsManager script onto.
 * 
 * For screen shake you will need to turn off the Camera Controller as I was not able to figure out how to make my shake work
 * while the camera was following the player. This is an ongoing thing I hopefully will have worked out.
 * 
 * For the ScreenFlash, I have included a Panel that has the script on it.
 * You just need to drag this somewhere in your hierarchy.
 *
 * To implement this code you will need to go into your GameController file.
 * For me this is where I create my variables:
 *    public float duration;
 *    public float magnitude;
 *    public Color flashColor;
 * 
 * They are public so you can edit them within unity where your GameController script lives.
 * 
 * I set mine to .5 duration and 1 magnitude. For the color you will be shows a eyedropper
 * and you can change what you want the color flash to be.
 *
 */