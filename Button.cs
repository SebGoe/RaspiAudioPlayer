using System;
using System.Linq;
using Unosquare.RaspberryIO.Gpio;
using System.Threading;


namespace music_player
{
    class Button
    {   
        private GpioPin pin;
        public static Button Create(int pinNumber, Action doOnChange)
        {
            var button = new Button(pinNumber, doOnChange);
            button.Init();
            return button;
        }

        private readonly int _pinNumber;
        private readonly Action _doOnChange;

        private Button(int pinNumber, Action doOnChange)
        {
            Console.WriteLine($"Connect Pin{pinNumber}");
            _pinNumber = pinNumber;
            _doOnChange = doOnChange;
        }

        public bool IsPressed
        {
            get{ return pin.Read();}  
        }

        public void Test()
        {
            Console.WriteLine($"Pin {_pinNumber} {pin.Read()}" );
        }

        public void Init()
        {
            var controller = GpioController.Instance;
            pin = controller.Pins.First(p => p.PinNumber == _pinNumber);

            if(pin.Capabilities.All( c => c != PinCapability.GP)) return;
            pin.PinMode = GpioPinDriveMode.Input;
            pin.RegisterInterruptCallback(EdgeDetection.FallingEdge, () => 
                { 
                    _doOnChange(); 
                    Thread.Sleep(300);                    
                });
        }
    }
}

