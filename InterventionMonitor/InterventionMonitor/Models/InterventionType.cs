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
            SupplyMosquitoNet.Name = "Supply Mosquito Net";
            SupplyMosquitoNet.MaterialCost = 100;
            SupplyMosquitoNet.LabourHours = 2;

            SupplyandInstallPortableToilet = new InterventionType();
            SupplyandInstallPortableToilet.Name = "Supply and Install Portable Toilet";
            SupplyandInstallPortableToilet.MaterialCost = 1000;
            SupplyandInstallPortableToilet.LabourHours = 10;

            HepatitisAvoidanceTraining = new InterventionType();
            HepatitisAvoidanceTraining.Name = "Hepatitis Avoidance Training";
            HepatitisAvoidanceTraining.MaterialCost = 500;
            HepatitisAvoidanceTraining.LabourHours = 20;

            SupplyandInstallStormproofHomeKit = new InterventionType();
            SupplyandInstallStormproofHomeKit.Name = "Supply and Install Storm-proof HomeKit";
            SupplyandInstallStormproofHomeKit.MaterialCost = 5000;
            SupplyandInstallStormproofHomeKit.LabourHours = 20;
        }

        private static readonly InterventionTypes _instance = new InterventionTypes();
        public static InterventionTypes Instance
        {
            get
            {
                return _instance;
            }
        }

        public InterventionType SupplyMosquitoNet;
        public InterventionType SupplyandInstallPortableToilet;
        public InterventionType HepatitisAvoidanceTraining;
        public InterventionType SupplyandInstallStormproofHomeKit;
    }
}