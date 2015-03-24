var Tscr_LOOK0 = {
	// scroller box size: [width, height]
	'size' : [400, 100],
	// image for 'pause' control (autoscroll mode only)
	// [left, top, width, height, sorce_file]
	'pa' : [360, 80, 16, 16],
	// image for 'resume' control (autoscroll mode only)
	// [left, top, width, height, sorce_file]
	're' : [360, 80, 16, 16],
	// image for 'next item' control (autoscroll mode only)
	// [left, top, width, height, sorce_file]
	'nx' : [380, 80, 16, 16],
	// image for 'previous item' control (autoscroll mode only)
	// [left, top, width, height, sorce_file]
	'pr' : [340, 80, 16, 16]
},
Tscr_BEHAVE0 = {
	// if scrolling mode is auto (true / false); 
	'auto'  : true,
	// if scrolling direction is vertical (true / false, false means horisontal)
	'vertical' : true,
	// scrolling speed, pixels per 50 miliseconds;
	// for auto mode use negative value to reverse scrolling direction
	'speed' : 3,
	// buttons visible on mouse over - true, always visible - false
	'hide_buttons' : true
}

// a data to build scroll window content
Tscr_ITEMS0 = [
{
	// file to get content for item from; if is set 'content' property doesn't matter
	// only body of HTML document is taken to become scroller item content
	// note: external files require time for loading 
	// it is RECOMMENDED to use content property to speed loading up
	// doesn't work in Opera
	'file': 's0_data/cont1.html',
	// string to be displayed as item content, 
	// is RECOMMENDED to be used as an alternative to 'file' property
	'content': 'Alternative content for NS4.x and Opera',
	// pause duration when item top gets top of the scroller box, seconds
	// ignored in on-demand mode while scrolling forward
	'pause_b': 2,
	// pause duration when item bottom gets bottom of the scroller box, seconds
	// ignored in on-demand mode while scrolling backward
	'pause_a' : 2,
	// transition effect the for the item [index, duration]
	// IE 5+ ONLY
	// choose index of following:
	// 0 - Box in.  
	// 1 - Box out.  
	// 2 - Circle in.  
	// 3 - Circle out.  
	// 4 - Wipe up.  
	// 5 - Wipe down.  
	// 6 - Wipe right.  
	// 7 - Wipe left.  
	// 8 - Vertical blinds.  
	// 9 - Horizontal blinds.  
	// 10 - Checkerboard across.  
	// 11 - Checkerboard down.  
	// 12 - Random dissolve. 
	// 13 - Split vertical in. 
	// 14 - Split vertical out.  
	// 15 - Split horizontal in.  
	// 16 - Split horizontal out.  
	// 17 - Strips left down.  
	// 18 - Strips left up.  
	// 19 - Strips right down.  
	// 20 - Strips right up.  
	// 21 - Random bars horizontal.  
	// 22 - Random bars vertical.  
	// 23 - Random of aboves  
	// 24 - Blending 
	'transition' : [24, 0.5]
},
{
	'file': 's0_data/cont2.html',
	'content': '<img src="tsp.gif" width="350" height="80" border="0" alt="Tigra Scroller PRO">',
	'pause_b': 2,
	'pause_a': 1,
	'transition' : [24, 0.5]
}
];