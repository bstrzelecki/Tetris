using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    class Playground
    {
        private int sizeX;
        private int sizeY;
        private int textureSize = 32;
        SpriteBatch spriteBatch;
        public Block[,] map;
        private Figure currentFigure;
        private Point figurePosition;
        GraphicsDevice graphicsDevice;
        bool isRotated = false;
        public Playground(GraphicsDeviceManager graphics, int sizeX, int sizeY, GraphicsDevice gd)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            graphics.PreferredBackBufferHeight = sizeY * textureSize;
            graphics.PreferredBackBufferWidth = sizeX * textureSize;
            graphics.ApplyChanges();
            spriteBatch = new SpriteBatch(gd);
            graphicsDevice = gd;

            map = new Block[sizeX,sizeY];
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    map[x,y] = new Block();
                }
            }
            currentFigure = new TheT();
        }
        public void Update()
        {
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    Block block = map[x, y];
                    if (!block.isStable)
                    {
                        block.setActive(false);
                    }
                }
            }
            foreach (Point point in currentFigure.getFigure())
            {
                map[point.x + figurePosition.x, point.y + figurePosition.y].setActive(true);
            }
            KeyboardState state = Keyboard.GetState();



            if (state.IsKeyDown(Keys.A))
            {
                figurePosition.x -= 1;
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), -1))
                    figurePosition.x += 1;
            }
            if (state.IsKeyDown(Keys.D))
            {
                figurePosition.x += 1;
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), sizeX))
                {
                    figurePosition.x -= 1;
                }
            }
            if (state.IsKeyDown(Keys.R) && !isRotated)
            {
                currentFigure.Rotate(1);
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), sizeX))
                {
                    currentFigure.Rotate(-1);
                }
                isRotated = true;
            }
            if(state.IsKeyUp(Keys.R))isRotated = false;


        }

        public void Draw()
        {
            spriteBatch.Begin();
            for(int x = 0; x < sizeX;x++){
                for (int y = 0; y < sizeY; y++) {
                    Block block = map[x,y];
                    if (block.isActive)
                    {
                        spriteBatch.Draw(Game1.block, new Vector2(x*textureSize, y * textureSize),Color.White);
                    }
                }
            }
            spriteBatch.End();
        }
    }
}
