using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace VolControl
{
    public abstract class Knob 
    {

        public Knob() {

        }

        public const String up = "U";
        public const String down = "D";
        public const String button = "B";

        public abstract void HandleState(string message);
    }

    public class Knob1 : Knob
    {
        public Knob1()
        {

        }
        public override void HandleState(string message)
        {
            switch (message)
            {
                case up: break;
                case down: break;
                case button: break;
            }
        }
    }

    public class Knob2 : Knob
    {
        public Knob2()
        {

        }
        public override void HandleState(string message)
        {
            switch (message)
            {
                case up: break;
                case down: break;
                case button: break;
            }
        }
    }

    public class Knob3 : Knob
    {
        public Knob3()
        {

        }
        public override void HandleState(string message)
        {
            switch (message)
            {
                case up: break;
                case down: break;
                case button: break;
            }
        }
    }
}
