using System;
using System.Collections.Generic;

namespace EntityModel
{
    public partial class DeviceLocationHistoryAudit
    {
        public int DeviceId { get; set; }
        public string Activity { get; set; }
        public string DoneBy { get; set; }
        public int? OldLocationId { get; set; }
        public int? NewLocationId { get; set; }
        public string OldLocation { get; set; }
        public string NewLocation { get; set; }
        public int DlhistoryId { get; set; }
    }
}
