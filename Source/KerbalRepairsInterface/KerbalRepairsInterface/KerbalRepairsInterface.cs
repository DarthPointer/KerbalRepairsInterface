using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerbalRepairsInterface
{
    public interface IRepairable
    {
        void AcceptRepairsController(IRepairsController repairsController);
        void RepairStarted(RepairData repairData);
        void RepairStopped(RepairData repairData);
        void RepairFinished(RepairData repairData);
        void RequestRepairs();
    }

    public interface IRepairsController
    {
        void AddRepair(RepairData repairData);
        void RemoveRepair(RepairData repairData);
    }
}
