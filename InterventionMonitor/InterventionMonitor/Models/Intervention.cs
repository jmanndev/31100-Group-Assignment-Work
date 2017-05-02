using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InterventionMonitor.DataAccess;

namespace InterventionMonitor.Models
{
    public class Intervention : ITestableValidModel
    {
        class DBColumnConstants
        {
            public const string Id = "Id";
            public const string ClientId = "ClientId";
            public const string InterventionTypeId = "InterventionTypeId";
            public const string LabourHours = "LabourHours";
            public const string MaterialCost = "MaterialCost";
            public const string SiteEngineerId = "SiteEngineerId";
            public const string Date = "Date";
            public const string InterventionStatusId = "InterventionStatus";
            public const string Notes = "Notes";
            public const string Life = "Life";
            public const string ApprovedById = "ApprovedBy";
        }

        public static class DBQueries
        {
            public static string SelectAll
            {
                get
                {
                    return @"SELECT Id, ClientId, InterventionTypeId, LabourHours, MaterialCost,
                        SiteEngineerId, Date, InterventionStatus, Notes, Life, ApprovedBy FROM Intervention";
                }
            }
        }

        public Intervention()
        {
            Status = InterventionStatuses.Instance.Proposed;
        }

        public Intervention(SqlDataReader reader)
        {
            ID = (int)reader[DBColumnConstants.Id];

            var clientId = (int)reader[DBColumnConstants.ClientId];
            Client = Monitor.Instance.FindClient(clientId);

            var typeId = (int)reader[DBColumnConstants.InterventionTypeId];
            Type = InterventionTypes.Instance.FindType(typeId);

            HoursRequired = (decimal)reader[DBColumnConstants.LabourHours];
            CostRequired = (decimal)reader[DBColumnConstants.MaterialCost];

            var engineerId = reader[DBColumnConstants.SiteEngineerId].ToString();
            SiteEngineer = Monitor.Instance.FindSiteEngineer(engineerId);

            Date = (DateTime)reader[DBColumnConstants.Date];

            var statusId = (int)reader[DBColumnConstants.InterventionStatusId];
            Status = InterventionStatuses.Instance.FindStatus(statusId);

            Notes = reader[DBColumnConstants.Notes].ToString();
            Life = (int)reader[DBColumnConstants.Life];

            var approvedById = reader[DBColumnConstants.ApprovedById].ToString();
            ApprovedBy = Monitor.Instance.FindApprover(approvedById);
        }

        public Intervention(SiteEngineer siteEngineer, Client client, InterventionType interventionType)
            : this()
        {
            SiteEngineer = siteEngineer;
            Client = client;
            Type = interventionType;
        }

        public Intervention(SiteEngineer engineer, Client client, DateTime date, InterventionType interventionType,
            decimal? overridingHoursRequired, decimal? overridingCostRequired, int remainingLife, string notes)
            : this()
        {
            ID = Monitor.Instance.Interventions.Count + 1;
            SiteEngineer = engineer;
            Client = client;
            Date = date;
            Type = interventionType;
            HoursRequired = overridingHoursRequired != null ? (decimal)overridingHoursRequired : Type.LabourHours;
            CostRequired = overridingCostRequired != null ? (decimal)overridingCostRequired : Type.MaterialCost;
            Life = remainingLife;
            Notes = notes;

            AddInterventionToDB();
        }

        void AddInterventionToDB()
        {
#if DEBUG
            if (!UnitTestDetector.IsInUnitTest)
#endif
            {
                var connection = DatabaseConnections.GetDataConnection();
                var query = @"INSERT INTO Intervention (ClientId, InterventionTypeId, LabourHours, MaterialCost, 
                    SiteEngineerId, Date, InterventionStatus, Notes, Life, ApprovedBy)
                    VALUES (@ClientId, @InterventionTypeId, @LabourHours, @MaterialCost, 
                    @SiteEngineerId, @Date, @InterventionStatus, @Notes, @Life, @ApprovedBy)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", Client.ID);
                command.Parameters.AddWithValue("@InterventionTypeId", Type.ID);
                command.Parameters.AddWithValue("@LabourHours", HoursRequired);
                command.Parameters.AddWithValue("@MaterialCost", CostRequired);
                command.Parameters.AddWithValue("@SiteEngineerId", SiteEngineer.Id);
                command.Parameters.AddWithValue("@Date", Date);
                command.Parameters.AddWithValue("@InterventionStatus", Status.ID);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@Life", Life);
                command.Parameters.AddWithValue("@ApprovedBy", ApprovedBy != null ? (object)ApprovedBy.Id : DBNull.Value);
                connection.Open();
                var reader = command.ExecuteReader();
                connection.Close();
            }
        }

        #region Properties Stored In DB (Persistent Properties)

        [Key]
        public int ID
        {
            get;
            set;
        }

        public Client Client
        {
            get;
            set;
        }

        public InterventionType Type
        {
            get;
            set;
        }

        public decimal HoursRequired
        {
            get;
            set;
        }

        public decimal CostRequired
        {
            get;
            set;
        }

        public SiteEngineer SiteEngineer
        {
            get;
            set;
        }
        
        public DateTime Date
        {
            get;
            set;
        }

        public InterventionStatus Status
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public int Life
        {
            get;
            set;
        }

        public Approver ApprovedBy
        {
            get;
            set;
        }

        #endregion

        public bool IsApproved
        {
            get { return Status == InterventionStatuses.Instance.Approved; }
        }

        public void MarkedAsApproved(Approver approver)
        {
            if (Status == InterventionStatuses.Instance.Proposed)
            {
                ApprovedBy = approver;
                Status = InterventionStatuses.Instance.Approved;

                UpdateInterventionToDB();
            }
        }

        public void Update(int life, string notes)
        {
            Life = life;
            Notes = notes;
            UpdateInterventionToDB();
        }

        public void Complete(int life, string notes)
        {
            if (IsApproved)
            {
                Status = InterventionStatuses.Instance.Completed;
                Update(life, notes);
            }
        }

        public void Cancel(int life, string notes)
        {
            if (IsApproved)
            {
                Status = InterventionStatuses.Instance.Cancelled;
                Update(life, notes);
            }
        }

        void UpdateInterventionToDB()
        {
#if DEBUG
            if (!UnitTestDetector.IsInUnitTest)
#endif
            {
                var connection = DatabaseConnections.GetDataConnection();
                var query = @"UPDATE Intervention SET
                                InterventionStatus = @InterventionStatus,
                                Notes = @Notes,
                                Life = @Life,
                                ApprovedBy = @ApprovedBy
                                WHERE Id = @Id";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", ID);
                command.Parameters.AddWithValue("@InterventionStatus", Status.ID);
                command.Parameters.AddWithValue("@Notes", Notes);
                command.Parameters.AddWithValue("@Life", Life);
                command.Parameters.AddWithValue("@ApprovedBy", ApprovedBy != null ? (object)ApprovedBy.Id : DBNull.Value);
                connection.Open();
                var reader = command.ExecuteReader();
                connection.Close();
            }
        }

        public DateTime LastVisitDate
        {
            get
            {
                return Date;
            }
        }

        #region Fields to be bound to controls

        public string DisplayClient
        {
            get { return Client.Name; }
        }

        public string DisplayDistrict
        {
            get { return Client.District.Name; }
        }

        public string DisplayType
        {
            get { return Type.Name; }
        }

        public string DisplayDate
        {
            get { return Date.ToLongDateString(); }
        }

        public string DisplayHours
        {
            get { return HoursRequired.ToString(); }
        }

        public string DisplayCost
        {
            get { return string.Format("{0}AUD", CostRequired); }
        }

        public string DisplayStatus
        {
            get { return Status.Name; }
        }

        #endregion

        #region Test-only code
#if DEBUG
        public void FillInValidTestData()
        {
            var engineer = new SiteEngineer();
            engineer.FillInValidTestData();
            var client = new Client();
            client.FillInValidTestData();

            SiteEngineer = engineer;
            Client = client;
            Date = DateTime.Now;
            Type = InterventionTypes.Instance.SupplyAndInstallStormproofHomeKit;
            HoursRequired = InterventionTypes.Instance.SupplyAndInstallStormproofHomeKit.LabourHours;
            CostRequired = InterventionTypes.Instance.SupplyAndInstallStormproofHomeKit.MaterialCost;
            Life = 100;
            Notes = "";
        }
#endif
        #endregion
    }
}
 