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

        bool isSelected = false;
        bool completed = false;
        public double progressRatio;                // [0; 1]
        public double quality;                      // [0; 1]

        public object customControllerData;
        public object customTargetData;

        public RepairData(IRepairable repairTarget, string repairOptionDescription, Dictionary<string, double> requestedResources,
            bool isSelected = false, bool completed = false, float progressRatio = 0)
        {
            this.repairTarget = repairTarget;
            this.repairOptionDescription = repairOptionDescription;
            this.requestedResources = requestedResources;

            this.isSelected = isSelected;
            this.completed = completed;
            this.progressRatio = progressRatio;
        }

        public string RepairOptionDescription => repairOptionDescription;
        public bool IsSelected => isSelected;

        public Dictionary<string, double> RequestedResources => requestedResources;

        public void Select()
        {
            isSelected = true;
            repairTarget.RepairSelected(this);
        }

        public void Deselect()
        {
            isSelected = false;
            repairTarget.RepairDeselected(this);
        }

        public void ToggleSelection()
        {
            isSelected = !isSelected;
            if (isSelected)
            {
                repairTarget.RepairSelected(this);
            }
            else
            {
                repairTarget.RepairDeselected(this);
            }
        }

        public void Finish()
        {
            completed = true;
            progressRatio = 1;

            repairTarget.RepairFinished(this);
        }

        public string Serialize()
        {
            string result = "";

            if (customControllerData as IKRISerializedCustomData != null)
            {
                string cCDString = (customControllerData as IKRISerializedCustomData).Serialize();
                result += $"CustomControllerData {cCDString.Length} :{cCDString}";
            }
            if (customTargetData as IKRISerializedCustomData != null)
            {
                string cTDString = (customTargetData as IKRISerializedCustomData).Serialize();
                result += $"CustomTargetData {cTDString.Length} :{cTDString}";
            }

            return result;
        }

        public void Deserialize(string serialized)
        {
        }
    }
}
