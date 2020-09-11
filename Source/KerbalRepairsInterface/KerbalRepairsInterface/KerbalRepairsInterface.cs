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
        void RepairDeselected(RepairData repairData);
        void RepairFinished(RepairData repairData);
        void RepairOpsStarted();
        void RepairOpsFinished();
    }

    public interface IDifferentiatedRepairable              // Opt-in. For modules that represent separate devices so repairs can be initiated for a single "device" while other can keep running.
    {                                                       // WARNING! If a part contains several IDR-implementing modules, every module should get a RepairOpsStarted call
        List<string> GetRepairableDevicesIDs();             // (even if the given deviceID is not "determined" by some IDRs). This "design" is the "initial" one, implemented by KerbalReconstructionTape.
        void RepairOpsStarted(string deviceID);             // I'm open to discussions about changing it. My point of view is that this will force "users" use collision-proof IDs if making different modules
        void RepairOpsFinished(string deviceID);            // react on the same call isn't desired.
    }

    public interface IRepairsController
    {
        void AddRepair(RepairData repairData);
        void RemoveRepair(RepairData repairData);
    }
}
