using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class GameField : MonoBehaviour
    {
        public int width = 4;
        public int height = 4;
        private List<Cell> _cells = new List<Cell>();
        [SerializeField] public GameObject cellPrefab;

        void Start()
        {
            CreateCell();
            CreateCell(); // Создаем две клетки в начале
        }

        public (int x, int y) GetEmptyPosition()
        {
            List<(int, int)> emptyPositions = new List<(int, int)>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (!_cells.Exists(cell => cell.Position == (x, y)))
                    {
                        emptyPositions.Add((x, y));
                    }
                }
            }

            if (emptyPositions.Count > 0)
            {
                int randomIndex = Random.Range(0, emptyPositions.Count);
                return emptyPositions[randomIndex];
            }

            return (-1, -1); // нет пустых клеток
        }

        public void CreateCell()
        {
            var position = GetEmptyPosition();
            if (position != (-1, -1)) // проверка на наличие пустой клетки
            {
                int newValue = Random.value < 0.9f ? 1 : 2;
                Cell newCell = new Cell(position, newValue);
                _cells.Add(newCell);
                CreateCellView(newCell);
            }
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

        private void CreateCellView(Cell cell)
        {
            GameObject cellObject = Instantiate(cellPrefab, transform, true);
            var realPos = GetRealPosition(cell.Position);
            cellObject.transform.localPosition = new Vector3((float)realPos.x, (float)realPos.y, 0);

            CellView cellView = cellObject.GetComponent<CellView>();
            cellView.Initialize(cell);
        }

        
    }
}