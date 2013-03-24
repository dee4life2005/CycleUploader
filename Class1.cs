/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 26/02/2013
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Diagnostics;

namespace CycleUploader
{
public class GeoMath
{
    /// <summary>
    /// The distance type to return the results in.
    /// </summary>
    public enum MeasureUnits { Miles, Kilometers };

	public static DateTime UnixTimeStampToDateTime( double unixTimeStamp )
	{
	    // Unix timestamp is seconds past epoch
	    System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0);
	    dtDateTime = dtDateTime.AddSeconds( unixTimeStamp ).ToLocalTime();
	    return dtDateTime;
	}
    
    /// <summary>
    /// Returns the distance in miles or kilometers of any two
    /// latitude / longitude points. (Haversine formula)
    /// </summary>
    public static double Distance(double latitudeA, double longitudeA, double latitudeB, double longitudeB, MeasureUnits units)
    {
        if (latitudeA <= -90 || latitudeA >= 90 || longitudeA <= -180 || longitudeA >= 180
            || latitudeB <= -90 && latitudeB >= 90 || longitudeB <= -180 || longitudeB >= 180)
        {
            throw new ArgumentException(String.Format("Invalid value point coordinates. Points A({0},{1}) B({2},{3}) ",
                                                      latitudeA,
                                                      longitudeA,
                                                      latitudeB,
                                                      longitudeB));
        }


        double R = (units == MeasureUnits.Miles) ? 3960 : 6371;
        double dLat = toRadian(latitudeB - latitudeA);
        double dLon = toRadian(longitudeB - longitudeA);
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
        Math.Cos(toRadian(latitudeA)) * Math.Cos(toRadian(latitudeB)) *
        Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
        double d = R * c;
        return d;
    }

    public static double Gradient(double distance, double elev1, double elev2)
    {
    	return Math.Atan(Math.Abs(elev1-elev2)/distance);
    }

    /// <summary>
    /// Convert to Radians.
    /// </summary>      
    private static double toRadian(double val)
    {
        return (Math.PI / 180) * val;
    }   
    
    public static double semicircle_to_degrees(double semicircle)
    {
    	return (semicircle * (180 / Math.Pow(2,31)));
    }
    
    public static double degrees_to_semicircle(double degrees)
    {
    	
    	return (degrees * (Math.Pow(2,31) / 180));
    }
    
    /// <summary>
	/// Methods to convert DateTime to Unix time stamp
	/// </summary>
	/// <param name="_UnixTimeStamp">Unix time stamp to convert</param>
	/// <returns>Return Unix time stamp as long type</returns>
	public static long DateTimeToUnixTimestamp(DateTime _DateTime)
	{
		TimeSpan _UnixTimeSpan = (_DateTime - new DateTime(1970, 1, 1, 0, 0, 0));
		return (long)_UnixTimeSpan.TotalSeconds;
	}
}
}
