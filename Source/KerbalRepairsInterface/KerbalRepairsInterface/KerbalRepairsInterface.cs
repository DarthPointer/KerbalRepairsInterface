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
        void RepairSelected(RepairData repairData);
        void RepairDeselected(RepairData repairData);               // Call only after setting repairData
        void RepairFinished(RepairData repairData);
    }

    public interface IRepairsController
    {
        void AddRepair(RepairData repairData);
        void RemoveRepair(RepairData repairData);
    }
}
