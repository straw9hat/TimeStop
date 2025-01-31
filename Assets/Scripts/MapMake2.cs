﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class MapMake2 : MonoBehaviour
{
    // Models it use to spawn
    public GameObject grass_hex, water_hex, desert_hex;
    
    // 2D Map, each cell is a TileType for data storage
    public TileType[,] tileTypesMap;

    // Size of the map in terms of hex tiles
    public int width, height;

    // Private and local variable
    private GameObject spawnHex;
    private Type spawnType;
    private bool isWater = false;
    private float xOffset = 1.73f;
    private float zOffset = 1.5f;

    public void MapMake(int level)
    {
        /* Makes a map for scene *Map2*
         * Make and save seed
         * Make a 2d list of cords of hexs
         */
        Random.InitState(level);

        // Allocate our map tiles
        tileTypesMap = new TileType[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;

                // On the odd row
                if (y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }
                
                int randomMin = 0;
                int randomMax = 3;
                int tile1Match = 0;
                int tile2Match = 0;
                int tile3Match = 0;
                if (x > 0 && y > 0 && x < width - 1 && y < height - 1)
                {
                    // get tempTile1 = x-1,y-1 tile type
                    Type tempTileType1 = tileTypesMap[x - 1, y - 1].type;
                    // get tempTileType2 = x-1,y tile type
                    Type tempTileType2 = tileTypesMap[x - 1, y].type;
                    // get tempTile3 = x,y-1 tile type
                    Type tempTileType3 = tileTypesMap[x, y - 1].type;

                    if (tempTileType1 == Type.Grass)
                    {
                        tile1Match++;
                    } else if (tempTileType1 == Type.Water)
                    {
                        tile2Match++;
                    } else if (tempTileType1 == Type.Desert)
                    {
                        tile3Match++;
                    }

                    if (tempTileType2 == Type.Grass)
                    {
                        tile1Match++;
                    } else if (tempTileType2 == Type.Water)
                    {
                        tile2Match++;
                    } else if (tempTileType2 == Type.Desert)
                    {
                        tile3Match++;
                    }
                    
                    if (tempTileType3 == Type.Grass)
                    {
                        tile1Match++;
                    } else if (tempTileType3 == Type.Water)
                    {
                        tile2Match++;
                    } else if (tempTileType3 == Type.Desert)
                    {
                        tile3Match++;
                    }

                    randomMax = 6;
                    
                    int randomHexInt = Random.Range(randomMin, randomMax);
                    
                    switch (randomHexInt)
                    {
                        case 0:
                            spawnHex = grass_hex;
                            spawnType = Type.Grass;
                            break;
                            
                        case 1:
                            spawnHex = water_hex;
                            spawnType = Type.Water;
                            isWater= true;
                            break;
                        case 2:
                            spawnHex = desert_hex;
                            spawnType = Type.Desert;
                            break;
                            
                    }
                    
                    if (tile1Match == 1 && tile2Match == 1 && tile3Match == 1)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            
                            case 4:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 5:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                        }
                    } else if (tile1Match == 2 && tile2Match == 1 && tile3Match == 0)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            
                            case 4:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            case 5:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                        }
                    } else if (tile1Match == 3 && tile2Match == 0 && tile3Match == 0)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            
                            case 4:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            case 5:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                        }
                    } else if (tile1Match == 2 && tile2Match == 0 && tile3Match == 1)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            
                            case 4:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            case 5:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                        }
                    } else if (tile1Match == 1 && tile2Match == 2 && tile3Match == 0)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            
                            case 4:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 5:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                        }
                    } else if (tile1Match == 0 && tile2Match == 2 && tile3Match == 1)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 4:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 5:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                        }
                    } else if (tile1Match == 0 && tile2Match == 3 && tile3Match == 0)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 4:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 5:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                        }
                    } else if (tile1Match == 1 && tile2Match == 0 && tile3Match == 2)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = grass_hex;
                                spawnType = Type.Grass;
                                break;
                            
                            case 4:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                            case 5:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                        }
                    } else if (tile1Match == 0 && tile2Match == 1 && tile3Match == 2)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                            case 4:
                                spawnHex = water_hex;
                                spawnType = Type.Water;
                                isWater= true;
                                break;
                            case 5:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                        }
                    } else if (tile1Match == 0 && tile2Match == 0 && tile3Match == 3)
                    {
                        switch (randomHexInt)
                        {
                            case 3:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                            
                            case 4:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                            case 5:
                                spawnHex = desert_hex;
                                spawnType = Type.Desert;
                                break;
                        }
                    }
                    
                }
                else
                {
                    int randomHexInt = Random.Range(randomMin, randomMax);

                    // Get Temp Model and Type
                    switch (randomHexInt)
                    {
                        case 0:
                            spawnHex = grass_hex;
                            spawnType = Type.Grass;
                            break;
                            
                        case 1:
                            spawnHex = water_hex;
                            spawnType = Type.Water;
                            isWater= true;
                            break;
                        case 2:
                            spawnHex = desert_hex;
                            spawnType = Type.Desert;
                            break;
                            
                    }
                    
                }


                // Spawns and render new Hex into the Game
                GameObject hex_tile = Instantiate(spawnHex, new Vector3(xPos, 0, y * zOffset), spawnHex.transform.rotation) as GameObject;
                if(hex_tile.transform.childCount > 0)
                {
                    hex_tile = hex_tile.transform.GetChild(0).gameObject;
                }
                _ = hex_tile.AddComponent<MeshCollider>();

                // Set Name and Tag, Set Current Object using this script as parent
                hex_tile.gameObject.tag = "HexTile";
                hex_tile.name = "Hex_" + x + "_" + y;
                hex_tile.transform.SetParent(this.transform);
                hex_tile.GetComponent<ClickableTile>().setTilePositionAndType(x, y, spawnType);

                //hex_tile.setTileXY(x, y);
                //allTiles.Add(x*1000+y, hex_tile);

                /*
                if (spawnHex == grass_hex)
                {
                    hex_tile.gameObject.tag = "Grass Tile";
                }
                */

                //Generate data for the map | TileType(string name, Type type, int XPos, int YPos, bool isWater)
                tileTypesMap[x, y] = new TileType(hex_tile.name, spawnType, x, y, isWater);
                isWater = false;
            }
        }
    }
    public TileType[,] getTileTypeMap()
    {
        return this.tileTypesMap;
    }

    public Vector2Int getTileTypePos()
    {
        return new Vector2Int(0, 0);
    }

    public void deleteTilesTypeMapData()
    {
        //Set every cell to NULL then deletes the table
        //Gives tiles to Other Script
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                this.tileTypesMap[x, y] = null;
            }
        }
        this.tileTypesMap = null;
    }
}
