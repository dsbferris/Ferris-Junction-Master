using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferris_Junction_Master
{
    public class JunctionsList
    {
        public StringCollection Junctions {
            get
            {
                return Properties.Settings.Default.ListOfJunctions;
            }
            set
            {
                Properties.Settings.Default.ListOfJunctions = value;
                Properties.Settings.Default.Save();
            }
        }
        JunctionsList()
        {
            List<string> Junctions = Properties.Settings.Default.ListOfJunctions.Cast<string>().ToList();
            var junc = Properties.Settings.Default.ListOfJunctions;
        }
    }
}
