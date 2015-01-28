using Microsoft.SPOT.Hardware;

namespace Angstrey.NETMF.Netduino.Leds
{
    public class RgbLed
    {
        private readonly SecretLabs.NETMF.Hardware.PWM _redPinPort;
        private readonly SecretLabs.NETMF.Hardware.PWM _greenPinPort;
        private readonly SecretLabs.NETMF.Hardware.PWM _bluePinPort;

        public RgbLed(Cpu.Pin redPin, Cpu.Pin greenPin, Cpu.Pin bluePin)
        {
            _redPinPort = new SecretLabs.NETMF.Hardware.PWM(redPin);
            _greenPinPort = new SecretLabs.NETMF.Hardware.PWM(greenPin);
            _bluePinPort = new SecretLabs.NETMF.Hardware.PWM(bluePin);
        }

        public void SetColor(int red, int green, int blue)
        {
            _redPinPort.SetDutyCycle(ToIntensity(red));
            _greenPinPort.SetDutyCycle(ToIntensity(green));
            _bluePinPort.SetDutyCycle(ToIntensity(blue));
        }

        private uint ToIntensity(int value)
        {
            return (uint)(100 * (value / 255.0));
        }
    }
}