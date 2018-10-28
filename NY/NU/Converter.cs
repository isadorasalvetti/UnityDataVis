using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOT IN USE!

namespace CoordConversion
{	
	public class ScreeConditions{
		public double centerLat, centerLon;
		public int width, height;
		public float zoom;

		public ScreeConditions(){}
		
		public ScreeConditions(double cL, double cN, int w, int h, float z){
			this.centerLat = cL;
			this.centerLon = cN;
			this.width = w;
			this.height = h;
			this.zoom = z;
		}
		
	}

	public class LL{
		public static double[] convertLLtoScreen(double lat, double lon, ScreeConditions s){
			double latDisp = s.centerLat - lat;
			double lonDisp = s.centerLon - lon;
			return new double[] {latDisp, lonDisp};
		}
	}

}