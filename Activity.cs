/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 28/02/2013
 * Time: 12:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TCX_Parser
{
	/// <summary>
	/// Description of Activity.
	/// </summary>
	public class Activity
	{
		public string _notes;
		public DateTime _startTime;
		public double _duration;
		public double _avgHeartRate;
		public double _maxHeartRate;
		public double _avgCadence;
		public double _maxCadence;
		public double _totalAscent;
		public double _totalDescent;
		public double _distance;
		public double _avgSpeed;
		public double _maxSpeed;
		public double _calories;
		public List<Trackpoint> trackpoints;
		public List<Double> _lstHeartRate;
		public List<Double> _lstSpeed;
		public List<Double> _lstCadence;
		public List<Double> _lstTemperature;
		public List<Double> _lstAltitude;
		
		public Activity()
		{
		}
	}
	
	public class Trackpoint
	{
		public double _cadence;
		public double _speed;
		public double _heart;
		public double _temperature;
		public double _altitude;
		public double _timestamp; // seconds since start of activity
		public double _lng;
		public double _lat;
		
		public Trackpoint(double timestamp, double lng, double lat, double altitude, double cadence, double speed, double heart, double temperature)
		{
			_timestamp = timestamp;
			_cadence = cadence;
			_speed = speed;
			_heart = heart;
			_temperature = temperature;
			_altitude = altitude;
			_lng = lng;
			_lat = lat;
		}
	}
}
