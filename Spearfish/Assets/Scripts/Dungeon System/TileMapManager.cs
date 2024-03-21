using GridSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    public static TileMapManager Inst;
    public CustomTile[] AllTiles;
    public Dictionary<String, CustomTile> TileDict = new Dictionary<string, CustomTile>();
    [SerializeField] private Tilemap m_tileMap;
    public void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Inst != null && Inst != this)
        {
            Destroy(this);
        }
        else
        {
            Inst = this;
        }
        for (int i = 0; i < AllTiles.Length; i++)
        {
            TileDict.Add(AllTiles[i].Name, AllTiles[i]);
        }
    }

    public CustomTile GetTile(String _name)
    {
        CustomTile newTile = null;
        if (TileDict.ContainsKey(_name))
        {
            newTile = TileDict[_name];
        }
        else 
        {
            newTile = new CustomTile();
            newTile.Colour = Color.magenta;
            newTile.Name = "BackUp Tile";
        }  
        
        return newTile;

        
    }

    public void DisplayGrid(Grid _grid)
    {
        Tile tile = new Tile();

        for (int iX = 0; iX < _grid.m_xSize; iX++)
        {
            for (int iY = 0; iY < _grid.m_ySize; iY++)
            {
                Cell currentCell = _grid.cells[iX, iY];
                tile.sprite = currentCell.cellContent.Sprite;
                tile.colliderType = currentCell.cellContent.ColliderType;
                m_tileMap.SetTile(new Vector3Int(iX, iY, 0), tile);
            }
        }
        
    }
}

[Serializable]
public class CustomTile
{
    public string Name;
    public Sprite Sprite;
    public Color Colour;
    public Tile.ColliderType ColliderType;
}
