using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class District
    {
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

        public string Notes
        {
            get;
            set;
        }
    }

    // Thread-safe singleton pattern for Districts that cannot be overridden by another class.
    public sealed class Districts
    {
        static Districts()
        {
        }

        private Districts()
        {
            AllDistricts.Add(UrbanIndonesia);
            AllDistricts.Add(RuralIndonesia);
            AllDistricts.Add(UrbanPapuaNewGuinea);
            AllDistricts.Add(RuralPapuaNewGuinea);
            AllDistricts.Add(Sydney);
            AllDistricts.Add(RuralNewSouthWales);
        }

        private static readonly Districts _instance = new Districts();
        public static Districts Instance
        {
            get
            {
                return _instance;
            }
        }

        public District FindDistrict(int districtId)
        {
            return AllDistricts.FirstOrDefault(x => x.ID == districtId);
        }

        // These match with what's in the DB
        public readonly District UrbanIndonesia = new District() { ID = 1, Name = "Urban Indonesia" };
        public readonly District RuralIndonesia = new District() { ID = 2, Name = "Rural Indonesia" };
        public readonly District UrbanPapuaNewGuinea = new District() { ID = 3, Name = "Urban Papua New Guinea" };
        public readonly District RuralPapuaNewGuinea = new District() { ID = 4, Name = "Rural Papua New Guinea" };
        public readonly District Sydney = new District() { ID = 5, Name = "Sydney" };
        public readonly District RuralNewSouthWales = new District() { ID = 6, Name = "Rural New South Wales" };
        public readonly List<District> AllDistricts = new List<District>();
    }
}