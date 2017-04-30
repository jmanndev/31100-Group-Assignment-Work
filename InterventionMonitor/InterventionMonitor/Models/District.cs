using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class District
    {
        public int ID
        {
            get;
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
        public readonly District UrbanIndonesia = new District() { Name = "Urban Indonesia" };
        public readonly District RuralIndonesia = new District() { Name = "Rural Indonesia" };
        public readonly District UrbanPapuaNewGuinea = new District() { Name = "Urban Papua New Guinea" };
        public readonly District RuralPapuaNewGuinea = new District() { Name = "Rural Papua New Guinea" };
        public readonly District Sydney = new District() { Name = "Sydney" };
        public readonly District RuralNewSouthWales = new District() { Name = "Rural New South Wales" };
        public readonly List<District> AllDistricts = new List<District>();
    }
}