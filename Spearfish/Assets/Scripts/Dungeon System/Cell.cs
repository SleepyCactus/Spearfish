using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace GridSystem
{
    public class Cell
    {
        #region Variables
        public Vector2 position;
        public float heat = 0;
        private Dictionary<Vector2, Cell> m_neighbours = new Dictionary<Vector2, Cell>()
        {
            {Vector2.up, null},
            {Vector2.right, null},
            {Vector2.down, null},
            {Vector2.left, null}
        };
        private string m_cellContent;
        public Color cellDebugColour;
        #endregion

        public Cell(Vector2 _pos)
        {
            position = _pos;
            m_cellContent = "Empty";
            cellDebugColour = Color.magenta;
        }

        #region Private Functions
         
        #endregion

        #region Public Functions
        public string GetCellContent()
        {
            return m_cellContent;
        }
        public Cell GetNeighbour(Vector2 _direction)
        { 
            return m_neighbours[_direction];
        }
        public Cell GetRandomWeightedNeighbour()
        {
            float[] weights = new float[4] { 0, 0, 0, 0 };
            int n = 0;
            foreach (KeyValuePair<Vector2, Cell> entry in m_neighbours)
            {
                if(entry.Value != null)
                {
                    weights[n] = 1-entry.Value.heat;
                }
                n++;
            }
            float[] randoms = new float[4]
            {
                Random.Range(0,weights[0]),
                Random.Range(0,weights[1]),
                Random.Range(0,weights[2]),
                Random.Range(0,weights[3])
            };
            int iLargest = 0;
            float largest = 0;
            for (int i = 0; i < randoms.Length; i++)
            {
                if (randoms[i]>largest)
                {
                    largest = randoms[i];
                    iLargest = i;
                }
            }

            Cell c = GetRandomNeighbour(iLargest);

            return c;
        }
        public Cell GetRandomNeighbour(int _r)
        {   
            Vector2 direction = Vector2.down;
            switch (_r)
            {
                case 0:
                    direction = Vector2.up;
                    break;
                case 1:
                    direction = Vector2.right;
                    break;
                case 2:
                    direction = Vector2.down;
                    break;
                case 3:
                    direction = Vector2.left;
                    break;

            }
            return m_neighbours[direction];
        }

        public void SetNeighbours(Cell _up, Cell _right, Cell _down, Cell _left)
        {
            if(_up == null || _right == null || _down == null || _left == null)
            {
                heat = 1;
            }
            m_neighbours[Vector2.up] = _up;
            m_neighbours[Vector2.right] = _right;
            m_neighbours[Vector2.down] = _down;
            m_neighbours[Vector2.left] = _left;
        }

        public void DebugCell()
        {
            Debug.Log("Neighbours:\n"
                        + "-Up "    + m_neighbours[Vector2.up]   + "\n"
                        + "-Right " + m_neighbours[Vector2.right]+ "\n"
                        + "-Down "  + m_neighbours[Vector2.down] + "\n"
                        + "-Left "  + m_neighbours[Vector2.left] + "\n"
                    + "Position:"
                        + position + "\n"
                    + "Content:"
                        + m_cellContent 
                    + "\n "
                    );
        }
        #endregion Private Functions



    }

}

