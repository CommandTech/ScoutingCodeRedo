﻿using ScoutingCodeRedo.Dynamic;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ScoutingCodeRedo.Static.GamePadFolder
{
    class Controllers
    {
        public Stopwatch stopwatch = new Stopwatch();
        public TimeSpan Zero { get; private set; }

        private DynamicResponses dynamicGamepad = new DynamicResponses();

        private bool IsAxis(Guid objectType)
        {
            return objectType == ObjectGuid.XAxis ||
                   objectType == ObjectGuid.YAxis ||
                   objectType == ObjectGuid.ZAxis ||
                   objectType == ObjectGuid.RxAxis ||
                   objectType == ObjectGuid.RyAxis ||
                   objectType == ObjectGuid.RzAxis;
        }
        public Joystick[] GetSticks(DirectInput input)
        {
            List<Joystick> sticks = new List<Joystick>();
            foreach (DeviceInstance device in input.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    var stick = new Joystick(input, device.InstanceGuid);
                    stick.Acquire();

                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if (IsAxis(deviceObject.ObjectType))
                        {
                            var properties = stick.GetObjectPropertiesById(deviceObject.ObjectId);
                            if (properties != null)
                            {
                                properties.Range = new InputRange(-100, 100);
                            }
                        }
                    }

                    sticks.Add(stick);
                }
                catch (Exception) { }
            }
            return sticks.ToArray();
        }

        public RobotState getRobotState(int state)
        {
            state = Math.Max(0, state);
            state = Math.Min(5, state);
            return BackgroundCode.Robots[state]; //Shouldn't crash here but if it does, you do not have a controller connected
        }

        public GamePad[] getGamePads()
        {
            DirectInput input = new DirectInput();
            List<GamePad> gamepads = new List<GamePad>();

            foreach (var stick in GetSticks(input))
            {
                gamepads.Add(new GamePad(stick));
                Console.WriteLine(stick.Information.InstanceName);
            }

            return gamepads.ToArray();
        }
        public void readStick(GamePad[] gpArray, int controllerNumber)
        {
            GamePad gamepad = gpArray[controllerNumber];
            if (gamepad != null)
            {
                gamepad.Update();

                //Match events
                if (gamepad.RTHRight_Press && !BackgroundCode.Robots[controllerNumber].NoSho && !gamepad.XButton_Down)
                {
                    BackgroundCode.Robots[controllerNumber].cycleEventName(RobotState.CYCLE_DIRECTION.Up);
                }
                else if (gamepad.RTHLeft_Press && !BackgroundCode.Robots[controllerNumber].NoSho && !gamepad.XButton_Down)
                {
                    BackgroundCode.Robots[controllerNumber].cycleEventName(RobotState.CYCLE_DIRECTION.Down);
                }
                else if (gamepad.R3_Press && BackgroundCode.Robots[controllerNumber].match_event != RobotState.MATCHEVENT_NAME.Match_Event)
                {
                    DynamicResponses.transactToDatabase(BackgroundCode.Robots[controllerNumber], "Match_Event");
                    BackgroundCode.Robots[controllerNumber].match_event = RobotState.MATCHEVENT_NAME.Match_Event;
                }

                //Scouter names
                if (gamepad.LTHRight_Press && !gamepad.XButton_Down)
                {
                    BackgroundCode.Robots[controllerNumber].changeScouterName(RobotState.CYCLE_DIRECTION.Up);
                }
                if (gamepad.LTHLeft_Press && !gamepad.XButton_Down)
                {
                    BackgroundCode.Robots[controllerNumber].changeScouterName(RobotState.CYCLE_DIRECTION.Down);
                }

                dynamicGamepad.readStick(gpArray, controllerNumber);
            }
        }
    }
}
