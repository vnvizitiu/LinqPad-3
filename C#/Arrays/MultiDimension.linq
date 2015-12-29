<Query Kind="Program" />

void Main() //http://csharp.2000things.com/2010/10/19/124-declaring-and-instantiating-multidimensional-arrays/
{
	// 2-dimensional array
	int[,] hourlyTempsForWeek = new int[7, 24];
	hourlyTempsForWeek[2, 12] = 45;     // Tuesday, 12PM
	hourlyTempsForWeek[6, 23] = 30;     // Saturday, 11PM

	// 3-dimensional array, R/G/B values for each pixel on screen
	byte[,,] pixelRGBValues = new byte[1024, 768, 3];
	pixelRGBValues[0, 0, 0] = 255;  // R value at (0,0)
	pixelRGBValues[0, 0, 1] = 0;    // G value at (0,0)
	pixelRGBValues[0, 0, 2] = 255;  // B value at (0,0)

	// 4-dimensional array, R/G/B values for each pixel on screen
	byte[,,,] pixelRGBValues4 = new byte[1024, 768, 3,9];
	pixelRGBValues[0, 0, 0] = 255;  // R value at (0,0)
	pixelRGBValues[0, 0, 1] = 0;    // G value at (0,0)
	pixelRGBValues[0, 0, 2] = 255;  // B value at (0,0)
	pixelRGBValues[0, 0, 3] = 255;  // B value at (0,0)

 
	 
}

