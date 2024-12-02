using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace _Scripts
{
    public class CellView : MonoBehaviour
    {
        private Cell _cell;
        private TextMeshProUGUI _cellText;

        void Awake()
        {
            _cellText = GetComponentInChildren<TextMeshProUGUI>(); 
        }

        public void Initialize(Cell cell)
        {
            this._cell = cell;
            UpdateValue();

            cell.OnValueChanged += UpdateValue;
            cell.OnPositionChanged += UpdatePosition;
        }

        private (double x, double y) GetRealPosition((int, int) pos)
        {
            if(pos.Item1 == 0 && pos.Item2 == 0){return (-68.0625, 72.0);}
            if(pos.Item1 == 0 && pos.Item2 == 1){return (-22.6875, 72.0);}
            if(pos.Item1 == 0 && pos.Item2 == 2){return (22.6875, 72.0);}
            if(pos.Item1 == 0 && pos.Item2 == 3){return (68.0625, 72.0);}
            if(pos.Item1 == 1 && pos.Item2 == 0){return (-68.0625, 24.0);}
            if(pos.Item1 == 1 && pos.Item2 == 1){return (-22.6875, 24.0);}
            if(pos.Item1 == 1 && pos.Item2 == 2){return (22.6875, 24.0);}
            if(pos.Item1 == 1 && pos.Item2 == 3){return (68.0625, 24.0);}
            if(pos.Item1 == 2 && pos.Item2 == 0){return (-68.0625, -24.0);}
            if(pos.Item1 == 2 && pos.Item2 == 1){return (-22.6875, -24.0);}
            if(pos.Item1 == 2 && pos.Item2 == 2){return (22.6875, -24.0);}
            if(pos.Item1 == 2 && pos.Item2 == 3){return (68.0625, -24.0);}
            if(pos.Item1 == 3 && pos.Item2 == 0){return (-68.0625, -72.0);}
            if(pos.Item1 == 3 && pos.Item2 == 1){return (-22.6875, -72.0);}
            if(pos.Item1 == 3 && pos.Item2 == 2){return (22.6875, -72.0);}
            if(pos.Item1 == 3 && pos.Item2 == 3){return (68.0625, -72.0);}

            return (-1, -1);
        }

        private void UpdateValue()
        {
            _cellText.text = (_cell.Value*2).ToString();
        }
        

        private void UpdatePosition()
        {
            var realPos = GetRealPosition(_cell.Position);
            transform.localPosition = new Vector3((float)realPos.x, (float)realPos.y, 0);
        }
    }
}