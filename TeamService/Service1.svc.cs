using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TeamService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
      // Retreve Players based of of their position 
        public RetreveAllPlayerByPosition retreveAllPlayerByPosition(string pos)
        {
            //Create new object
            RetreveAllPlayerByPosition r = new RetreveAllPlayerByPosition();
            //Create sql connection variable
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            //generate query to be sent to dbb
            SqlCommand cmd = new SqlCommand("Select * from Player where Position ='" + pos +"'", con);
            //Adapter for data
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Generate local dataset
            DataSet ds = new DataSet();
            //populate dataset
            da.Fill(ds);
            //set obbject prop to local dataset
            r.dt = ds;
            //close sql connection
            con.Close();
            //return object
            return r;
        }
        //Retreve All players 
        public RetreveAllPlayers retreveAllPlayers()
        {
            //create new object
            RetreveAllPlayers r = new RetreveAllPlayers();
            //Create sql connection variable
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            //generate query to be sent to dbb
            SqlCommand cmd = new SqlCommand("Select * from Player", con);
            //Adapter for data
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //Generate local dataset
            DataSet ds = new DataSet();
            //populate dataset
            da.Fill(ds);
            //set obbject prop to local dataset
            r.dt = ds;
            //close sql connection
            con.Close();
            //return object
            return r;
        }
        public RetreveTeamDetails retreveTeamDetails(int id)
        {
            RetreveTeamDetails r = new RetreveTeamDetails();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Team where ID = " + id, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            r.dt = ds;
            con.Close();
            return r;
        }


        //Retreve list of players based off of team id
        public RetreveAllPlayersByTeam retreveAllPlayersByTeam(int id)
        {
            RetreveAllPlayersByTeam r = new RetreveAllPlayersByTeam();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Player where TeamID = " + id, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            r.dt = ds;
            con.Close();
            return r;
        }
        //Retreve all teams
        public RetreveAllTeams retreveAllTeams()
        {
            RetreveAllTeams r = new RetreveAllTeams();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Team", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            r.dt = ds;
            con.Close();
            return r;
        }
        //Retreve teams win loss
        public RetreveTeamWinLoss retreveTeamWinLoss()
        {
            RetreveTeamWinLoss s = new RetreveTeamWinLoss();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from WinLoss", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            s.dt = ds;
            con.Close();
            return s;
        }
        //Retreve teams sponsor
        public RetreveSponsor retreveSponsor()
        {
            RetreveSponsor s = new RetreveSponsor();
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Sponsor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            s.dt = ds;
            con.Close();
            return s;
        }
        //Update a team member
        public string UpdateTeamMembber(UpdateTeamMember utm)
        {
            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["HockeyTeamsDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("Update Player set Name=@Name, TeamID=@TeamID, Number=@Number, Position=@Position where id=@Id", con);
            cmd.Parameters.AddWithValue("@Name", utm.Name);
            cmd.Parameters.AddWithValue("@TeamID", utm.TeamId);
            cmd.Parameters.AddWithValue("@Number", utm.Number);
            cmd.Parameters.AddWithValue("@Position", utm.Position);
            cmd.Parameters.AddWithValue("@Id", utm.Id);
            int val = cmd.ExecuteNonQuery();
            string msg = string.Empty;
            if (val == 1)
                msg = "Player updated successfully!";
            else
                msg = "Player update failed";
            con.Close();
            return msg;
        }
    }

   
}
