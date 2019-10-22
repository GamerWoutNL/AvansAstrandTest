using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public interface StateCallback
    {
        void StartState();
        void StopState();
    }
}
