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
        public Score scoreHeader;

        void Start()
        {
            scoreHeader = FindFirstObjectByType<Score>();
            CreateCell();
            CreateCell(); 
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

            return (-1, -1); 
        }

        public void CreateCell()
        {
            var position = GetEmptyPosition();
            if (position != (-1, -1)) 
            {
                int newValue = Random.value < 0.8f ? 1 : 2;
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
        public void MoveCells(Vector2 direction)
        {
            if (direction == Vector2.left)
            {
                for (int i = 0; i < _cells.Count; i++)
                {
                    DestroyCellView(_cells[i]);
                    Debug.Log("ДО: " + _cells[i].Position);
                }
                _cells = CellsMoving.MoveFieldLeft(_cells);
                for (int i = 0; i < _cells.Count; i++)
                {
                    CreateCellView(_cells[i]);
                    Debug.Log("ПОСЛЕ: " + _cells[i].Position);
                }
                CreateCell();
            }
            if (direction == Vector2.right)
            {
                for (int i = 0; i < _cells.Count; i++)
                {
                    DestroyCellView(_cells[i]);
                    Debug.Log("ДО: " + _cells[i].Position);
                }
                _cells = CellsMoving.MoveFieldRight(_cells);
                for (int i = 0; i < _cells.Count; i++)
                {
                    CreateCellView(_cells[i]);
                    Debug.Log("ПОСЛЕ: " + _cells[i].Position);
                }
                CreateCell();
            }
            if (direction == Vector2.up)
            {
                for (int i = 0; i < _cells.Count; i++)
                {
                    DestroyCellView(_cells[i]);
                    Debug.Log("ДО: " + _cells[i].Position);
                }
                _cells = CellsMoving.MoveFieldUp(_cells);
                for (int i = 0; i < _cells.Count; i++)
                {
                    CreateCellView(_cells[i]);
                    Debug.Log("ПОСЛЕ: " + _cells[i].Position);
                }
                CreateCell();
            }
            if (direction == Vector2.down)
            {
                for (int i = 0; i < _cells.Count; i++)
                {
                    DestroyCellView(_cells[i]);
                    Debug.Log("ДО: " + _cells[i].Position);
                }
                _cells = CellsMoving.MoveFieldDown(_cells);
                for (int i = 0; i < _cells.Count; i++)
                {
                    CreateCellView(_cells[i]);
                    Debug.Log("ПОСЛЕ: " + _cells[i].Position);
                }
                CreateCell();
            }
            scoreHeader.UpdateScore(CalculateScore());
        }

        
        private void UpdateCellView(Cell cell)
        {
            var cellView = FindCellView(cell);
            if (cellView != null)
            {
                var realPos = GetRealPosition(cell.Position);
                cellView.transform.localPosition = new Vector3((float)realPos.x, (float)realPos.y, 0);
                cellView.UpdateValue(cell.Value);
            }
        }

        private CellView FindCellView(Cell cell)
        {
            foreach (Transform child in transform)
            {
                var cellView = child.GetComponent<CellView>();
                if (cellView != null && cellView.GetCell() == cell)
                {
                    return cellView;
                }
            }
            return null;
        }
        
        

        private void DestroyCellView(Cell cell)
        {
            var cellView = FindCellView(cell);
            if (cellView != null)
            {
                Destroy(cellView.gameObject);
            }
        }

        private int CalculateScore()
        {
            int score = 0;
            for (int i = 0; i < _cells.Count; i++)
            {
                Debug.Log(_cells[i].Value);
                score += _cells[i].Value;
            }
            return score*2;
        }
        
    }
}