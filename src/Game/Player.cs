//RDE means "Rogie Dot Engine"
using RDE.Core.Structs;

namespace Rogie;
public sealed class Player {

    //Const
    const char _skinDefault = '\u0040';

    //Private
    Vector2 _pos;
    char _skin;

    //Encapsulated
    public char Skin { get => _skin; set => _skin = value; }
    public Vector2 Position { get => _pos; set => _pos = value; }


    public Player(char skin = _skinDefault) {
        _skin = skin != _skinDefault ? skin : _skinDefault;
        _pos = new();
    }


}
