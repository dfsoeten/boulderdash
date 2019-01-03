namespace Boulderdash.app.models
{
    public interface IMoveable
    {
        Tile Move(Tile from, Tile to);
    }
}