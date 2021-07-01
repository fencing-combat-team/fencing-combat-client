using System;
using System.Collections.Generic;
using Core;
using Enums;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace Managers
{
    public abstract class InputProvider
    {
        private Dictionary<FencingKey, bool> downLastFrame = new Dictionary<FencingKey, bool>();

        public void UpdateKey(FencingKey key)
        {
            downLastFrame[key] = GetKey(key);
        }

        public bool GetKeyDown(FencingKey key)
        {
            var result = GetKey(key) && (!(downLastFrame.ContainsKey(key) && downLastFrame[key]));
            UpdateKey(key);
            return result;
        }

        public abstract bool GetKey(FencingKey key);

        public abstract int GetHorizontalAxis();

        private static Dictionary<int, InputProvider> _playerInputMap = new Dictionary<int, InputProvider>
        {
            {1, new MainKeyboardInput()},
            {2, new KeypadInput()},
            {3, new GamePadInput(0)},
            {4, new GamePadInput(1)},
        };

        public static InputProvider GetPlayerInput(int playerId)
        {
            if (_playerInputMap.TryGetValue(playerId, out var result))
            {
                return result;
            }

            return DummyInputProvider.Instance;
        }
    }

    public class DummyInputProvider : InputProvider
    {
        private static DummyInputProvider _dummy = new DummyInputProvider();

        private DummyInputProvider()
        {
        }

        public static DummyInputProvider Instance => _dummy;
        public override bool GetKey(FencingKey key) => false;
        public override int GetHorizontalAxis() => 0;
    }

    public abstract class KeyBoardInput : InputProvider
    {
        protected enum DirectionKey
        {
            Left,
            Right
        }

        protected abstract KeyControl GetKeyControl(FencingKey key);
        protected abstract KeyControl GetKeyControl(DirectionKey key);

        public override bool GetKey(FencingKey key)
            => GetKeyControl(key).isPressed;

        public override int GetHorizontalAxis()
            => (GetKeyControl(DirectionKey.Left).isPressed ? -1 : 0) +
               (GetKeyControl(DirectionKey.Right).isPressed ? 1 : 0);
    }


    /// <summary>
    /// Ö÷¼üÅÌ
    /// </summary>
    public class MainKeyboardInput : KeyBoardInput
    {
        protected override KeyControl GetKeyControl(FencingKey key) => key switch
        {
            FencingKey.Attack => Keyboard.current.jKey,
            FencingKey.Jump => Keyboard.current.wKey,
            FencingKey.Defend => Keyboard.current.kKey,
        };

        protected override KeyControl GetKeyControl(DirectionKey key) => key switch
        {
            DirectionKey.Left => Keyboard.current.aKey,
            DirectionKey.Right => Keyboard.current.dKey,
        };
    }

    /// <summary>
    /// Ð¡¼üÅÌ
    /// </summary>
    public class KeypadInput : KeyBoardInput
    {
        protected override KeyControl GetKeyControl(FencingKey key) => key switch
        {
            FencingKey.Attack => Keyboard.current.numpad1Key,
            FencingKey.Jump => Keyboard.current.upArrowKey,
            FencingKey.Defend => Keyboard.current.numpad2Key,
        };

        protected override KeyControl GetKeyControl(DirectionKey key) => key switch
        {
            DirectionKey.Left => Keyboard.current.leftArrowKey,
            DirectionKey.Right => Keyboard.current.rightArrowKey,
        };
    }

    public class GamePadInput : InputProvider
    {
        private int _index;
        public GamePadInput(int index)
        {
            _index = index;
        }

        private ButtonControl GetButtonControl(FencingKey key)
        {
            if (_index >= Gamepad.all.Count)
                return null;
            Gamepad gamepad = Gamepad.all[_index];
            return key switch
            {
                FencingKey.Attack => gamepad.buttonSouth,
                FencingKey.Jump => gamepad.buttonNorth,
                FencingKey.Defend => gamepad.buttonEast,
            };
        }

        public override bool GetKey(FencingKey key)
            => GetButtonControl(key)?.isPressed ?? false;
        
        public override int GetHorizontalAxis()
        {
            if (_index >= Gamepad.all.Count)
                return 0;
            Gamepad gamepad = Gamepad.all[_index];
            var value = gamepad.leftStick.x.ReadValue();
            if (value > 0.01f)
                return 1;
            if (value < -0.01f)
                return -1;
            return 0;
        }
    }
}