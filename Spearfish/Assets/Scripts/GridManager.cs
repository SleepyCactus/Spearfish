using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private int m_xSize;
    [SerializeField] private int m_ySize;
    private Grid m_grid;
    #endregion

    #region Private Functions
    private void OnEnable()
    {
        m_grid = new Grid(m_xSize, m_ySize);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if(m_grid == null)
        {
            return;
        }
        for (int iX = 0; iX < m_xSize; iX++)
        {
            for (int iY = 0; iY < m_ySize; iY++)
            {
                Gizmos.color = m_grid.cells[iX, iY].cellDebugColour;
                Gizmos.DrawCube(new Vector3(iX,0,iY),Vector3.one/2);
            }
        }

    }

    #endregion

    #region Public Functions
    #endregion
}
