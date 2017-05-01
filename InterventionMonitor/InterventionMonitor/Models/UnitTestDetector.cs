using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterventionMonitor.Models
{
#if DEBUG
    /// <summary>
    /// Detects if we are running inside a unit test.
    /// Source: http://stackoverflow.com/a/3598990/1007496
    /// </summary>
    public static class UnitTestDetector
    {
        static UnitTestDetector()
        {
            string testAssemblyName = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
            IsInUnitTest = AppDomain.CurrentDomain.GetAssemblies().Any(a => a.FullName.StartsWith(testAssemblyName));
        }

        public static bool IsInUnitTest { get; private set; }
    }
#endif
}