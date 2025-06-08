namespace Rogie;

public sealed class Render {
    Map _rMap = new();
    public Render(Map renderMap) {
        if (renderMap != null)
            _rMap = renderMap;

    }
}
