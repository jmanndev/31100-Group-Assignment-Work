using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
    public class District
    {
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
        }

        private static readonly Districts _instance = new Districts();
        public static Districts Instance
        {
            get
            {
                return _instance;
            }
        }
        public District UrbanIndonesia = new District() { Name = "Urban Indonesia" };
        public District RuralIndonesia = new District() { Name = "Rural Indonesia" };
        public District UrbanPapuaNewGuinea = new District() { Name = "Urban Papua New Guinea" };
        public District RuralPapuaNewGuinea = new District() { Name = "Rural Papua New Guinea" };
        public District Sydney = new District() { Name = "Sydney" };
        public District RuralNewSouthWales = new District() { Name = "Rural New South Wales" };
    }
}