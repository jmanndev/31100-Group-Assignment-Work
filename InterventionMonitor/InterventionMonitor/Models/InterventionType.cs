using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class InterventionType
    {
        [Key]
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal LabourHours
        {
            get;
            set;
        }

        public decimal MaterialCost
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }
    }

    // Thread-safe singleton pattern for InterventionTypes that cannot be overridden by another class.
    public sealed class InterventionTypes
    {
        static InterventionTypes()
        {
        }

        private InterventionTypes()
        {
            SupplyMosquitoNet = new InterventionType();
            SupplyMosquitoNet.ID = 1;
            SupplyMosquitoNet.Name = "Supply Mosquito Net";
            SupplyMosquitoNet.MaterialCost = 100;
            SupplyMosquitoNet.LabourHours = 2;

            SupplyAndInstallPortableToilet = new InterventionType();
            SupplyAndInstallPortableToilet.ID = 2;
            SupplyAndInstallPortableToilet.Name = "Supply and Install Portable Toilet";
            SupplyAndInstallPortableToilet.MaterialCost = 1000;
            SupplyAndInstallPortableToilet.LabourHours = 10;

            HepatitisAvoidanceTraining = new InterventionType();
            HepatitisAvoidanceTraining.ID = 3;
            HepatitisAvoidanceTraining.Name = "Hepatitis Avoidance Training";
            HepatitisAvoidanceTraining.MaterialCost = 500;
            HepatitisAvoidanceTraining.LabourHours = 20;

            SupplyAndInstallStormproofHomeKit = new InterventionType();
            SupplyAndInstallStormproofHomeKit.ID = 4;
            SupplyAndInstallStormproofHomeKit.Name = "Supply and Install Storm-proof HomeKit";
            SupplyAndInstallStormproofHomeKit.MaterialCost = 5000;
            SupplyAndInstallStormproofHomeKit.LabourHours = 20;

            AllTypes.Add(SupplyMosquitoNet);
            AllTypes.Add(SupplyAndInstallPortableToilet);
            AllTypes.Add(HepatitisAvoidanceTraining);
            AllTypes.Add(SupplyAndInstallStormproofHomeKit);
        }

        private static readonly InterventionTypes _instance = new InterventionTypes();
        public static InterventionTypes Instance
        {
            get
            {
                return _instance;
            }
        }

        public InterventionType FindType(int typeId)
        {
            return AllTypes.FirstOrDefault(x => x.ID == typeId);
        }

        // These match with what's in the DB
        public readonly InterventionType SupplyMosquitoNet;
        public readonly InterventionType SupplyAndInstallPortableToilet;
        public readonly InterventionType HepatitisAvoidanceTraining;
        public readonly InterventionType SupplyAndInstallStormproofHomeKit;
        public readonly List<InterventionType> AllTypes = new List<InterventionType>();
    }
}