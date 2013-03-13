/*
 * Created by SharpDevelop.
 * User: stevens
 * Date: 04/03/2013
 * Time: 13:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Stravan;
using Stravan.Json;
using System.Collections.Generic;

namespace TCX_Parser
{
	/// <summary>
	/// Description of ViewerStrava.
	/// </summary>
	public partial class ViewerStrava : Form
	{
		private string _token;
		private string _user;
		private int _user_id;
		
		public ViewerStrava(string token, string username, int user_id)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			_token = token;
			_user = username;
			_user_id = user_id;
		}
		
		void ViewerStravaShown(object sender, EventArgs e)
		{
			this.Refresh();
			StravaWebClient wc = new StravaWebClient();
			AthleteService p = new AthleteService(wc);
			Athlete a = p.Show(_token, _user_id);
			
			lblProfileName.Text = a.Name;
			grpProfile.Refresh();
			
			int page = 0;
			int pageCount = 50;
			List<Ride> rides;
			
			RideService ride_service = new RideService(wc);

			do{
				rides = ride_service.Index(null, a.Id, null, null, null, null, page*pageCount);
				
				for(int r=0;r<rides.Count;r++){
					string[] row = {
						rides[r].Id.ToString(),
						"",
						rides[r].Name,
						"",
						"",
						"",
						"",
						"",
						"",
						"",
						""
					};
					lstStravaRides.Items.Add(new ListViewItem(row));
				}
				
				lblTotalActivities.Text = ((page*pageCount) + rides.Count).ToString();
				lblTotalActivities.Refresh();
				if(rides.Count == 50){
					page++;
				}
			}while(rides.Count == 50);
			
			// load the extended ride information
			pbLoading.Maximum = lstStravaRides.Items.Count;
			pbLoading.Step = 1;
			pbLoading.Value = 0;
			lstStravaRides.Refresh();
			lblLoadingStatus.Text = "Loading Extended Activity Information ... this may take a while";
			lblLoadingStatus.Refresh();
			for(int i = 0; i < lstStravaRides.Items.Count; i++){
				Ride r = ride_service.Show(Convert.ToInt32(lstStravaRides.Items[i].SubItems[0].Text));
				
				lstStravaRides.Items[i].SubItems[1].Text = r.StartDate;
				lstStravaRides.Items[i].SubItems[3].Text = r.Distance.ToString();
				lstStravaRides.Items[i].SubItems[4].Text = r.ElapsedTime.ToString();
				lstStravaRides.Items[i].SubItems[5].Text = r.MovingTime.ToString();
				lstStravaRides.Items[i].SubItems[6].Text = r.AverageSpeed.ToString();
				lstStravaRides.Items[i].SubItems[7].Text = r.ElevationGain.ToString();
				lstStravaRides.Items[i].SubItems[8].Text = r.Bike.Name;
				lstStravaRides.Items[i].SubItems[9].Text = r.IsCommute.ToString();
				lstStravaRides.Items[i].SubItems[10].Text = r.IsTrainer.ToString();
				
				lstStravaRides.Refresh();
				pbLoading.Value += pbLoading.Step;
			}
			
		}
	}
}
