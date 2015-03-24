
var Tscr_LOOK1 = {
	//alert('Entre');
	// scroller box size: [width, height]
	'size' : [320, 300],
	// a length of a gap between two neighboring items, pixels
	'distance' : 3,
	'item_w' : 1,
	// for on-demand mode: image for scrolling items backward 
	// [left, top, width, height, sorce_file]
	'up' : [50, 80, 16, 16, 'themes/Dezina_Amor/tsp_files/alf.gif'], 
	// for on-demand mode: image for scrolling items forward 
	// [left, top, width, height, sorce_file]
	'dn' : [50, 80, 16, 16, 'themes/Dezina_Amor/tsp_files/art.gif']
	
},

Tscr_BEHAVE1 = {

	// if scrolling mode is auto (true / false); 
	'auto'  : true, 
	// if scrolling direction is vertical (true / false, false means horisontal)
	'vertical' : false, 
	// scrolling speed, pixels per 50 miliseconds;
	// for auto mode use negative value to reverse scrolling direction
	'speed' : 10,
	// buttons visible on mouse over - true, always visible - false
	'hide_buttons' : false
}

