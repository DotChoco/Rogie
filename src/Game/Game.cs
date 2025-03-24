using System;
using System.IO;
using RDE.Behavior;

namespace Rogie;

public sealed class Room {
    public Walls walls { get; set; } = new();
    public Door[] doors { get; set; } = Array.Empty<Door>();
}

public sealed class Walls {
    public short TopWall { get; set; }
    public short BottonWall { get; set; }
    public short RightWall { get; set; }
    public short LeftWall { get; set; }
}

public struct Door {
    public short Pos { get; set; }
    public sbyte DoorType { get; set; }
    public sbyte RoomNum { get; set; }
}

public sealed class Game {
    
    #region Variables
    
    public Room[] Rooms { get; set; } = new Room[3];
    string path = string.Empty;
    
    #endregion
    
    
    public Game(){
        path = $@"{Application.AssetsPath}\stages\stage1";
        // RenderMap();
        // UI ui = new();
        // Player player = new();
    }


    void RenderMap(){
        StreamReader sr = new(path);
        byte roomIndex = 0;
        var line = sr.ReadToEnd().Split('\n');

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i].StartsWith('r') && !line[i].StartsWith("rw")){
                Room room = new();
                room.walls = new(){
                    TopWall = short.Parse(line[i+1].Split(':')[1]),
                    RightWall = short.Parse(line[i+2].Split(':')[1]),
                    BottonWall = short.Parse(line[i+3].Split(':')[1]),
                    LeftWall = short.Parse(line[i+4].Split(':')[1])
                };

                if(line[i+5].Length > 0 && line[i+5].StartsWith('d')){
                    byte doorsConter = 0;
                    for (int j = i + 5; j < line.Length; j++)
                    {
                        i = j;
                        if(line[j].Length > 0 && line[j].StartsWith('d')){
                            room.doors[doorsConter] = 
                                GetDoor(line[j].Split(':')[1], room.walls);
                            doorsConter++;
                        }
                        else
                            break;
                    }
                }

                Rooms[roomIndex] = room;
                roomIndex++;
            }
        }

    
    }


    Door GetDoor(string line, Walls walls){
        Door door = new();
        //line example: [3,rw,2]
        string lineEdited = line.Remove(line.Length - 1);
        lineEdited = lineEdited.Remove(0,1);
        
        //Result example:  3,rw,2
        string[] data = lineEdited.Split(',');
        
        door.Pos = short.Parse(data[0]);

        if(data[1] == "tw")
            door.DoorType = 1;
        if(data[1] == "rw")
            door.DoorType = 2;
        if(data[1] == "bw")
            door.DoorType = 3;
        if(data[1] == "lw")
            door.DoorType = 4;

        door.RoomNum = sbyte.Parse(data[2]);
        return door;
    }


    
}


