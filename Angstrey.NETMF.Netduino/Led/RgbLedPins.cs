using Microsoft.SPOT.Hardware;

namespace Angstrey.NETMF.Netduino.Leds
{
    public class RgbLedPins
    {
        public RgbLedPins(Cpu.Pin redPin, Cpu.Pin greenPin, Cpu.Pin bluePin)
        {
            RedPin = redPin;
            GreenPin = greenPin;
            BluePin = bluePin;
        }

        public Cpu.Pin RedPin { get; private set; }

        public Cpu.Pin GreenPin { get; private set; }

        public Cpu.Pin BluePin { get; private set; }
    }
}