using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterventionMonitor.Models
{
    interface ITestableValidModel
    {
        #region Test-only code
#if DEBUG
        void FillInValidTestData();
#endif
        #endregion
    }
}
