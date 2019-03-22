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
        private Figure nextFigure;
        private Point figurePosition = new Point(4,0);
        GraphicsDevice graphicsDevice;
        bool isRotated = false;
        bool isMoved = false;
        public int uiSize = 3;
        float fallCooldown;
        private float fallRecover = 1f;
        bool figureChanged = false;
        int score = 0;
        public bool isGameOver = false;
        public int highScore;
        public Playground(GraphicsDeviceManager graphics, int sizeX, int sizeY, GraphicsDevice gd)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            graphics.PreferredBackBufferHeight = sizeY * textureSize;
            graphics.PreferredBackBufferWidth = sizeX * textureSize + uiSize * textureSize;
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
            currentFigure = Figure.getRandomFigure();
            nextFigure = Figure.getRandomFigure();
            highScore = Serializer.getHighScore();
        }
        private void DropFigure()
        {
            if (isGameOver) return;
            figurePosition.y++;
            if(Physics.CheckCollisions(Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition), blockMap))
            {
                figurePosition.y--;
                CheckLost();
                foreach (Point point in currentFigure.getFigure()) {
                    blockMap.Add(new Point(point.x + figurePosition.x, point.y + figurePosition.y));
                }
                foreach (Point point in currentFigure.getFigure())
                {
                    try
                    {
                        map[point.x + figurePosition.x, point.y + figurePosition.y].setStable(true);
                    }
                    catch { }
                }
                figurePosition = new Point(4, 0);
                currentFigure = nextFigure;
                nextFigure = Figure.getRandomFigure();
                figureChanged = true;
                fallRecover += 0.05f;
            }
            CheckFullRow();
        }
        private void CheckFullRow()
        {
            for(int y = 0; y < sizeY; y++)
            {
                int count = 0;
                foreach(Point point in blockMap)
                {
                    if (point.y == y) count++;
                }
                if(count == 10)
                RemoveRow(y);
            }
        }
        private void RemoveRow(int y)
        {
            score++;
            List<Point> temp = new List<Point>();

            foreach(Point point in blockMap)
            {
                
                if(point.y < y)
                {
                    temp.Add(new Point(point.x, point.y + 1));
                }else if(point.y > y)
                {
                    temp.Add(point);
                } 
            }
            blockMap = temp;
        }
        private void CheckLost()
        {
            if (figurePosition.y < 4){
                isGameOver = true;
                if (score > highScore)
                    Serializer.setHighScore(score);
            }
        }
        public void Update()
        {
            if (isGameOver) return;
            CheckFullRow();
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

            if(fallCooldown > 10 || (state.IsKeyDown(Keys.Space) && !figureChanged))
            {
                DropFigure();
                fallCooldown = 0;
            }
            else
            {
                fallCooldown += fallRecover;
            }
            if (state.IsKeyUp(Keys.Space)) figureChanged = false;
        }
        public void Draw()
        {
            spriteBatch.Begin();
            foreach (Point block in blockMap)
            {
                spriteBatch.Draw(Game1.block, new Vector2(block.x * textureSize, block.y * textureSize), Color.White);
            }
            List<Point> temp = Physics.ToWorldPosition(currentFigure.getFigure(), figurePosition);
            foreach(Point block in temp)
            {
                spriteBatch.Draw(Game1.block, new Vector2(block.x * textureSize, block.y * textureSize), Color.White);
            }
            spriteBatch.DrawString(Game1.font, "Next", new Vector2(sizeX * textureSize, 0), Color.White);
            foreach(Point block in nextFigure.getFigure())
            {
                spriteBatch.Draw(Game1.block, new Vector2(sizeX * textureSize + block.x * textureSize, 30 + block.y * textureSize), Color.White);
            }
            spriteBatch.DrawString(Game1.font, "Score", new Vector2(sizeX * textureSize, 5 * textureSize), Color.White);
            spriteBatch.DrawString(Game1.font, score.ToString(), new Vector2(sizeX * textureSize, 5 * textureSize + 20), Color.White);
            spriteBatch.DrawString(Game1.font, "High Score", new Vector2(sizeX * textureSize, 5 * textureSize + 40), Color.White);
            spriteBatch.DrawString(Game1.font, highScore.ToString(), new Vector2(sizeX * textureSize, 5 * textureSize + 60), Color.White);
            if (isGameOver)
                spriteBatch.DrawString(Game1.font, "GameOver", new Vector2(sizeX * textureSize / 2 - 70, sizeY * textureSize / 2), Color.White,0,Vector2.Zero,new Vector2(2,2),SpriteEffects.None,0);
            spriteBatch.End();
        }
    }
}
