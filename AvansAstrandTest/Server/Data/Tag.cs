using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProgram.Data
{
	public enum Tag
	{
		// Page 16
		ET, // Elapsed time
		DT, // Distance travelled
		SP, // Speed
		HR, // Heartrate

		// Page 25
		EC, // Event count
		IC, // Instanteous cadence
		AP, // Accumulated power
		IP, // Instanteous power

		// Extra
		EOF,// End Of File
		AC, // Action
		UN, // Username
		PW, // Password
		ID, // Tag of Ergometer / simulator ID
		TS, // Timestamp
		MT, // The Message type of the message
		SR, // Set resistance percentage
		DM,  // Doctors message
		PNU, // The number of the patient
		DATA, // Data tag
		LR,  //Login Reaction
		PA,

		// Patient
		PNA, // The name of the patient
		PAG, //age
		PGE, //gender
		PWE //weight
	}
}
