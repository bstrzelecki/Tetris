using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Tetris
{
    class Playground
    {
        private int sizeX;
        private int sizeY;
        private int textureSize = 32;
        SpriteBatch spriteBatch;
        public Block[,] map;
        public List<Point> blockMap;
        private Figure currentFigure;
        private Point figurePosition;
        GraphicsDevice graphicsDevice;
        bool isRotated = false;
        bool isMoved = false;

        float fallCooldown;

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
            blockMap = Reference.getStartMap(sizeX, sizeY);
            currentFigure = new TheT();
        }
        private void DropFigure()
        {
            figurePosition.y++;
            if(Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), blockMap))
            {
                figurePosition.y--;
                foreach (Point point in currentFigure.getFigure()) {
                    blockMap.Add(new Point(point.x + figurePosition.x, point.y + figurePosition.y));
                }
                foreach (Point point in currentFigure.getFigure())
                {
                    if (point.x + figurePosition.x > sizeX || point.x + figurePosition.x < 0) continue;
                    if (point.y + figurePosition.y > sizeY || point.y + figurePosition.y < 0) continue;
                    map[point.x + figurePosition.x, point.y + figurePosition.y].setStable(true);
                }
                figurePosition = new Point(0,0);
                currentFigure = Figure.getRandomFigure();
            }
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
                try
                {
                    map[point.x + figurePosition.x, point.y + figurePosition.y].setActive(true);
                }catch(Exception e)
                {

                }
            }
            KeyboardState state = Keyboard.GetState();


            if (state.IsKeyDown(Keys.A) && !isMoved)
            {
                figurePosition.x -= 1;
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), -1))
                {
                    figurePosition.x += 1;
                }
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), blockMap))
                {
                    figurePosition.x += 1;
                }
                isMoved = true;
            }

            if (state.IsKeyDown(Keys.D) && !isMoved)
            {
                figurePosition.x += 1;
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), sizeX))
                {
                    figurePosition.x -= 1;
                }
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), blockMap))
                {
                    figurePosition.x -= 1;
                }
                isMoved = true;
            }

            if (state.IsKeyUp(Keys.A) && state.IsKeyUp(Keys.D)) isMoved = false;

            if (state.IsKeyDown(Keys.R) && !isRotated)
            {
                currentFigure.Rotate(1);
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), sizeX))
                {
                    currentFigure.Rotate(-1);
                }
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), -1))
                {
                    currentFigure.Rotate(-1);
                }
                if (Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), blockMap))
                {
                    currentFigure.Rotate(-1);
                }
                isRotated = true;
            }
            if(state.IsKeyUp(Keys.R))isRotated = false;

            if(fallCooldown > 10)
            {

                DropFigure();
                fallCooldown = 0;
            }
            else
            {
                fallCooldown += 0.5f;
            }
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
