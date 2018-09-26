/* Copyright (C) 2016 Calvin Sauer - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Calvin Sauer <calvin.j.sauer@gmail.com>, July 2016
 * Feel free to email me with questions or feature requests!
 */
 
 ======================
 DragRigidBody2D v0.6 README
 ======================

EXTREMELY IMPORTANT:
You can NOT drag objects around with the mouse in the editor if you are building for mobile!!
This is because Unity does not simulate mouse clicks as touch events within the editor. To get around this,
download the Unity Remote app onto your Android or iOS device and follow the instructions for setting that up.
This app allows you to test Unity scenes on your mobile device without needing to keep recompiling the entire project. Use it!!

To get started, drag the DragRigidBody2D script onto your main camera. That's it! Now you can create some Rigidbody2D objects in your scene,
assign them to a draggable layer (see below), and drag them around! Have fun!

 
 Important parameters:
 
	- Draggable Layers
		This layer mask denotes which layers are affected by dragging. An object's layer MUST be in this mask if you want it to be draggable.
		
	- Drag Damping
		This float affects how fast you would like the object to follow your mouse/touch. A higher damping makes for sluggish dragging, while a lower damping makes for snappy dragging
		Can NOT be 0!
		
	- Freeze Rotation
		Should the dragged object's rotation be frozen while it is being dragged?
		
	- Snap to Center
		If this is true, the dragged object will be picked up by its midpoint.
		Otherwise, it will be picked up by the initial contact point.
		
	- Snap Speed
		If Snap to Center is set to true, this float determines how quickly the object should be snapped
		
	- Relative to Rigidbody
		A Rigidbody2D that the dragged object will be dragged relative to. Please see the RelativeToDemo scene for an exmaple. 


HINT:
If you're getting some strange behavior with your Rigidbody2D objects passing through other physics objects while dragging,
try setting the draggable object's collision detection mode to "Continous" in the Rigidbody2D component.