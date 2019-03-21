using Microsoft.Xna.Framework;
namespace Tetris
{
    class Playground
    {
        private int sizeX;
        private int sizeY;
        private int textureSize = 32;

        public Playground(GraphicsDeviceManager graphics, int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            graphics.PreferredBackBufferHeight = sizeY * textureSize;
            graphics.PreferredBackBufferWidth = sizeX * textureSize;
            graphics.ApplyChanges();
        }

        public void Render()
        {

        }
    }
}
