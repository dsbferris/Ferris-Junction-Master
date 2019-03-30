using Monitor.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferris_Game_Mover
{
    public class JunctionPointExample
    {
        JunctionPointExample()
        {
            bool b = false;
            if (b)
            {
                // Creates a Junction Point at 
                // C:\Foo\JunctionPoint that points to the directory C:\Bar.
                // Fails if there is already a file, 
                // directory or Junction Point with the specified path.

                JunctionPoint.Create(@"C:\Foo\JunctionPoint", @"C:\Bar", false /*don't overwrite*/);

                // Creates a Junction Point at C:\Foo\JunctionPoint that points to 
                // the directory C:\Bar.
                // Replaces an existing Junction Point if found at the specified path.
                JunctionPoint.Create(@"C:\Foo\JunctionPoint", @"C:\Bar", true /*overwrite*/);


                // Delete a Junction Point at C:\Foo\JunctionPoint if it exists.
                // Does nothing if there is no such Junction Point.
                // Fails if the specified path refers to an existing file or 
                // directory rather than a Junction Point.
                JunctionPoint.Delete(@"C:\Foo\JunctionPoint");


                // Returns true if there is a Junction Point at C:\Foo\JunctionPoint.
                // Returns false if the specified path refers to an existing file 
                // or directory rather than a Junction Point
                // or if it refers to the vacuum of space.
                bool exists = JunctionPoint.Exists(@"C:\Foo\JunctionPoint");


                // Create a Junction Point for demonstration purposes whose target is C:\Bar.
                JunctionPoint.Create(@"C:\Foo\JunctionPoint", @"C:\Bar", false);

                // Returns the full path of the target of the Junction Point at 
                // C:\Foo\JunctionPoint.
                // Fails if the specified path does not refer to a Junction Point.
                string target = JunctionPoint.GetTarget(@"C:\Foo\JunctionPoint");

                // target will be C:\Bar
            }

        }
    }
}
