using System.Collections.Generic;
using System.Linq;

namespace _Scripts
{
    public class CellsMoving
    {
        public static List<Cell> MoveCellsRow(List<Cell> newCells)
        {
            List<Cell> resultArray = new List<Cell>();
            int index = 0;
            while (true)
            {
                if (index >= newCells.Count) break;
                if(index == newCells.Count - 1) resultArray.Add(newCells[index]);
                else if (newCells[index].Value == newCells[index + 1].Value)
                {
                    resultArray.Add(new Cell(newCells[index].Position, newCells[index].Value*2));
                    index++;
                }
                else
                {
                    resultArray.Add(newCells[index]);
                }
                index++;
            }

            return resultArray;
        }

        public static List<Cell> MoveFieldLeft(List<Cell> cells)
        {
            List<Cell> row0 = cells.FindAll(cell => cell.Position.x == 0).OrderBy(cell=>cell.Position.y).ToList();
            List<Cell> row1 = cells.FindAll(cell => cell.Position.x == 1).OrderBy(cell=>cell.Position.y).ToList();
            List<Cell> row2 = cells.FindAll(cell => cell.Position.x == 2).OrderBy(cell=>cell.Position.y).ToList();
            List<Cell> row3 = cells.FindAll(cell => cell.Position.x == 3).OrderBy(cell=>cell.Position.y).ToList();

            List<Cell> movedRow0 = MoveCellsRow(row0);
            List<Cell> movedRow1 = MoveCellsRow(row1);
            List<Cell> movedRow2 = MoveCellsRow(row2);
            List<Cell> movedRow3 = MoveCellsRow(row3);

            List<Cell> resultField = new List<Cell>();
            for (int i = 0; i < movedRow0.Count; i++)
            {
                Cell cell = new Cell((0, i), movedRow0[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow1.Count; i++)
            {
                Cell cell = new Cell((1, i), movedRow1[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow2.Count; i++)
            {
                Cell cell = new Cell((2, i), movedRow2[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow3.Count; i++)
            {
                Cell cell = new Cell((3, i), movedRow3[i].Value);
                resultField.Add(cell);
            }

            return resultField;
        }
        
        public static List<Cell> MoveFieldRight(List<Cell> cells)
        {
            List<Cell> row0 = cells.FindAll(cell => cell.Position.x == 0).OrderByDescending(cell=>cell.Position.y).ToList();
            List<Cell> row1 = cells.FindAll(cell => cell.Position.x == 1).OrderByDescending(cell=>cell.Position.y).ToList();
            List<Cell> row2 = cells.FindAll(cell => cell.Position.x == 2).OrderByDescending(cell=>cell.Position.y).ToList();
            List<Cell> row3 = cells.FindAll(cell => cell.Position.x == 3).OrderByDescending(cell=>cell.Position.y).ToList();

            List<Cell> movedRow0 = MoveCellsRow(row0);
            List<Cell> movedRow1 = MoveCellsRow(row1);
            List<Cell> movedRow2 = MoveCellsRow(row2);
            List<Cell> movedRow3 = MoveCellsRow(row3);
            

            List<Cell> resultField = new List<Cell>();
            for (int i = 0; i < movedRow0.Count; i++)
            {
                Cell cell = new Cell((0, 3-i), movedRow0[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow1.Count; i++)
            {
                Cell cell = new Cell((1, 3-i), movedRow1[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow2.Count; i++)
            {
                Cell cell = new Cell((2, 3-i), movedRow2[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow3.Count; i++)
            {
                Cell cell = new Cell((3, 3-i), movedRow3[i].Value);
                resultField.Add(cell);
            }
            return resultField;
        }
        
        public static List<Cell> MoveFieldDown(List<Cell> cells)
        {
            List<Cell> row0 = cells.FindAll(cell => cell.Position.y == 0).OrderByDescending(cell=>cell.Position.x).ToList();
            List<Cell> row1 = cells.FindAll(cell => cell.Position.y == 1).OrderByDescending(cell=>cell.Position.x).ToList();
            List<Cell> row2 = cells.FindAll(cell => cell.Position.y == 2).OrderByDescending(cell=>cell.Position.x).ToList();
            List<Cell> row3 = cells.FindAll(cell => cell.Position.y == 3).OrderByDescending(cell=>cell.Position.x).ToList();

            List<Cell> movedRow0 = MoveCellsRow(row0);
            List<Cell> movedRow1 = MoveCellsRow(row1);
            List<Cell> movedRow2 = MoveCellsRow(row2);
            List<Cell> movedRow3 = MoveCellsRow(row3);
            

            List<Cell> resultField = new List<Cell>();
            for (int i = 0; i < movedRow0.Count; i++)
            {
                Cell cell = new Cell((3-i, 0), movedRow0[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow1.Count; i++)
            {
                Cell cell = new Cell((3-i, 1), movedRow1[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow2.Count; i++)
            {
                Cell cell = new Cell((3-i, 2), movedRow2[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow3.Count; i++)
            {
                Cell cell = new Cell((3-i, 3), movedRow3[i].Value);
                resultField.Add(cell);
            }
            return resultField;
        }
        
        public static List<Cell> MoveFieldUp(List<Cell> cells)
        {
            List<Cell> row0 = cells.FindAll(cell => cell.Position.y == 0).OrderBy(cell=>cell.Position.x).ToList();
            List<Cell> row1 = cells.FindAll(cell => cell.Position.y == 1).OrderBy(cell=>cell.Position.x).ToList();
            List<Cell> row2 = cells.FindAll(cell => cell.Position.y == 2).OrderBy(cell=>cell.Position.x).ToList();
            List<Cell> row3 = cells.FindAll(cell => cell.Position.y == 3).OrderBy(cell=>cell.Position.x).ToList();

            List<Cell> movedRow0 = MoveCellsRow(row0);
            List<Cell> movedRow1 = MoveCellsRow(row1);
            List<Cell> movedRow2 = MoveCellsRow(row2);
            List<Cell> movedRow3 = MoveCellsRow(row3);

            List<Cell> resultField = new List<Cell>();
            for (int i = 0; i < movedRow0.Count; i++)
            {
                Cell cell = new Cell((i, 0), movedRow0[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow1.Count; i++)
            {
                Cell cell = new Cell((i, 1), movedRow1[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow2.Count; i++)
            {
                Cell cell = new Cell((i, 2), movedRow2[i].Value);
                resultField.Add(cell);
            }
            for (int i = 0; i < movedRow3.Count; i++)
            {
                Cell cell = new Cell((i, 3), movedRow3[i].Value);
                resultField.Add(cell);
            }

            return resultField;
        }
        
        
    }
}