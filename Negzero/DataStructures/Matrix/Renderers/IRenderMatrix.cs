namespace Negzero.DataStructures.Matrix.Renderers
{
    public interface IRenderMatrix
    {
        void RenderTile((int x, int y) position, byte value);
    }
}