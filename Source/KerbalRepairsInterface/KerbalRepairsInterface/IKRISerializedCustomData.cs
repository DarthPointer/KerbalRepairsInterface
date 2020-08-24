using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KerbalRepairsInterface
{
    public interface IKRISerializedCustomData
    {
        string Serialize();
        void Deserialize(string serialized);
    }
}
