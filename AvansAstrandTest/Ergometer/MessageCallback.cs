using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErgoConnect
{
    public interface MessageCallback
    {
        void MessageReceived(string message);
        void CadenceReceived(string message);
        void ResistanceReceived(string message);
        void PowerReceived(string message);
        void HeartrateReceived(string message);
		void StartTimers();
    }
}
