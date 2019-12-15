using System;

namespace VolControl
{
    public class Device 
    {
        Knob1 knob1;
        Knob2 knob2;
        Knob3 knob3;

        public Device()
        {
            knob1 = new Knob1();
            knob2 = new Knob2();
            knob3 = new Knob3();
        }

        public void HandleInput(String message)
        {
            int knobIndex = Convert.ToInt32(message.Substring(0, 1));
            string knobState = message.Substring(1, 1);
            switch (knobIndex) {
                case 1:
                    if (knob1 == null) { break; }
                    knob1.HandleState(knobState);
                    break;
                case 2:
                    if (knob2 == null) { break; }
                    knob2.HandleState(knobState);
                    break;
                case 3:
                    if (knob3 == null) { break; }
                    knob3.HandleState(knobState);
                    break;
            }

        }
    }
}
