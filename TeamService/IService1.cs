using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TeamService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        RetreveAllPlayers retreveAllPlayers();
        [OperationContract]
        RetreveAllPlayerByPosition retreveAllPlayerByPosition(string pos);
        [OperationContract]
        RetreveAllPlayersByTeam retreveAllPlayersByTeam(int id);
        [OperationContract]
        RetreveTeamWinLoss retreveTeamWinLoss();
        [OperationContract]
        string UpdateTeamMembber(UpdateTeamMember utm);

        [OperationContract]
        RetreveTeamDetails retreveTeamDetails(int id);

        [OperationContract]
        RetreveSponsor retreveSponsor();

        [OperationContract]
        RetreveAllTeams retreveAllTeams();
    }
    [DataContract]
    public class RetreveAllTeams
    {
        [DataMember]
        public DataSet dt { get; set; }
    }

    [DataContract]
    public class UpdateTeamMember
    {
        int id;
        int teamID;
        string name;
        int number;
        string position;
        [DataMember]
        public int Id { get { return id; } set { id = value; } }
        [DataMember]
        public string Name { get { return name; } set { name = value; } }
        [DataMember]
        public int TeamId { get { return teamID; } set { teamID = value; } }
        public int Number { get { return number; } set { number = value; } }
        [DataMember]
        public string Position { get { return position; } set { position = value; } }

    }

    [DataContract]
    public class RetreveTeamWinLoss
    {
        [DataMember]
        public DataSet dt { get; set; }


    }

    [DataContract]
    public class RetreveSponsor
    {
        [DataMember]
        public DataSet dt { get; set; }


    }
    [DataContract]
    public class RetreveTeamDetails
    {
        [DataMember]
        public DataSet dt { get; set; }
    }
    [DataContract]
    public class RetreveAllPlayersByTeam
    {
        [DataMember]
        public DataSet dt { get; set; }
    }

    [DataContract]
    public class RetreveAllPlayerByPosition
    {
        [DataMember]
        public DataSet dt { get; set; }
    }

    [DataContract]
    public class RetreveAllPlayers
    {
        [DataMember]
        public DataSet dt { get; set; }
    }
 
}
