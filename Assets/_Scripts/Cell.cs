using System;


namespace _Scripts
{
    public class Cell
    {
        public event Action OnValueChanged;
        public event Action OnPositionChanged;

        private int _value;
        private (int x, int y) _position;

        public int Value
        {
            get => _value;
            set
            {
                this._value = value;
                OnValueChanged?.Invoke();
            }
        }

        public (int x, int y) Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPositionChanged?.Invoke();
            }
        }

        public Cell((int, int) initialPosition, int initialValue)
        {
            Position = initialPosition;
            Value = initialValue;
        }
    }
}