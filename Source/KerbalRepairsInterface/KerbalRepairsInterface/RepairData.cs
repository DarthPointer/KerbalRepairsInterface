using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerbalRepairsInterface
{
    public class RepairData
    {
        IRepairable repairTarget;
        string repairOptionDescription;
        Dictionary<string, double> requestedResources;

        bool inProgress = false;
        bool completed = false;
        public double progressRatio;                // [0; 1]
        public double quality;                      // [0; 1]

        public IKRISerializedCustomData customControllerData;
        public IKRISerializedCustomData customTargetData;

        public RepairData(IRepairable repairTarget, string repairOptionDescription, Dictionary<string, double> requestedResources,
            bool inProgress = false, bool completed = false, float progressRatio = 0)
        {
            this.repairTarget = repairTarget;
            this.repairOptionDescription = repairOptionDescription;
            this.requestedResources = requestedResources;

            this.inProgress = inProgress;
            this.completed = completed;
            this.progressRatio = progressRatio;
        }

        public string RepairOptionDescription => repairOptionDescription;
        public bool InProgress => inProgress;

        public void Start()
        {
            inProgress = true;
            repairTarget.RepairStarted(this);
        }

        public void Stop()
        {
            inProgress = false;
            repairTarget.RepairStopped(this);
        }

        public void Toggle()
        {
            inProgress = !inProgress;
            if (inProgress)
            {
                repairTarget.RepairStarted(this);
            }
            else
            {
                repairTarget.RepairStopped(this);
            }
        }

        public void Finish()
        {
            completed = true;
            progressRatio = 1;

            repairTarget.RepairFinished(this);
        }
    }
}
