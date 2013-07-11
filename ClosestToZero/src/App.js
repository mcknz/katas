function closestToZeroCalculator(arr) {
	if (arr.length == 0 ) return null;

	var closest = arr[0];
	
	for(var i=1; i < arr.length; i++) {
		if ( Math.abs(arr[i]) < Math.abs(closest) )  {
			closest = arr[i];
		} else {
			if(Math.abs(arr[i]) == Math.abs(closest) && arr[i] > closest) {
				closest = arr[i];
			}
		}
	}

	return closest;    	
}