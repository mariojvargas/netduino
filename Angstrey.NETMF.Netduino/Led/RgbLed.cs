using System;

namespace Angstrey.NETMF.Netduino.Leds
{
    public class RgbLed
    {
        private const int MaximumColorValue = 255;
        private const int MinimumColorValue = 0;

        private readonly SecretLabs.NETMF.Hardware.PWM _redPinPort;
        private readonly SecretLabs.NETMF.Hardware.PWM _greenPinPort;
        private readonly SecretLabs.NETMF.Hardware.PWM _bluePinPort;

        public RgbLed(RgbLedPins pins)
        {
            _redPinPort = new SecretLabs.NETMF.Hardware.PWM(pins.RedPin);
            _greenPinPort = new SecretLabs.NETMF.Hardware.PWM(pins.GreenPin);
            _bluePinPort = new SecretLabs.NETMF.Hardware.PWM(pins.BluePin);
        }

        public void SetColor(int red, int green, int blue)
        {
            EnsureColorIsInRange(red, "red");
            EnsureColorIsInRange(green, "green");
            EnsureColorIsInRange(blue, "blue");

            _redPinPort.SetDutyCycle(GetIntensityPercentage(red));
            _greenPinPort.SetDutyCycle(GetIntensityPercentage(green));
            _bluePinPort.SetDutyCycle(GetIntensityPercentage(blue));
        }

        private static void EnsureColorIsInRange(int value, string parameterName)
        {
            if (MinimumColorValue < value || value > MaximumColorValue)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Color colorValue must be between 0 and 255. Value = " + value);
            }
        }

        private uint GetIntensityPercentage(int colorValue)
        {
            return (uint)(100.0 * (colorValue / (double)MaximumColorValue));
        }
    }
}