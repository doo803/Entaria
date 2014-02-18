using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Entaria
{
    public class Player
    {
        Texture2D texture, leftTexture, upTexture, rightTexture, downTexture;
        Vector2 position;
        int direction; // 1 = Up, 2 = Right, 3 = Down, 4 = Left
        int speed, i, walkTime;
        bool isVisible, canMoveTo;

        // Constructor
        public Player()
        {
            direction = 3;
            isVisible = true;
            position = new Vector2(44, 20);
            speed = 40;
            canMoveTo = true;
            walkTime = 20;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            // Change texture based on direction player is facing
            #region
            switch (direction)
            {
                case 1: 
                    {
                        texture = upTexture;
                        break;
                    }
                    
                case 2:
                    {
                        texture = rightTexture;
                        break;
                    }

                case 3:
                    {
                        texture = downTexture;
                        break;
                    }
                case 4:
                    {
                        texture = leftTexture;
                        break;
                    }
            }
            #endregion

            // Change the way player is facing (Not moving player)
            #region
            // Up
            if(keyState.IsKeyDown(Keys.Up))
            {
                direction = 1;
            }

            // Right
            else if (keyState.IsKeyDown(Keys.Right))
            {
                direction = 2;
            }

            // Down
            else if (keyState.IsKeyDown(Keys.Down))
            {
                direction = 3;
            }

            // Left
            else if (keyState.IsKeyDown(Keys.Left))
            {
                direction = 4;
            }
            #endregion

            // Move the player
            #region
            // Up
            if (keyState.IsKeyDown(Keys.Up) && canMoveTo)
            {
                i++;
                if(i == 1)
                {
                    position.Y -= speed;
                }

                if(i >= walkTime)
                {
                    i = 0;
                }
            }

            // Right
            else if (keyState.IsKeyDown(Keys.Right) && canMoveTo)
            {
                i++;
                if (i == 1)
                {
                    position.X += speed;
                }

                if (i >= walkTime)
                {
                    i = 0;
                }
            }

            // Down
            else if (keyState.IsKeyDown(Keys.Down) && canMoveTo)
            {
                i++;
                if (i == 1)
                {
                    position.Y += speed;
                }

                if (i >= walkTime)
                {
                    i = 0;
                }
            }

            // Left
            else if (keyState.IsKeyDown(Keys.Left) && canMoveTo)
            {
                i++;
                if (i == 1)
                {
                    position.X -= speed;
                }

                if (i >= walkTime)
                {
                    i = 0;
                }
            }

            #endregion
        }

        // Load Content
        public void LoadContent(ContentManager Content)
        {
            // Load player sprites
            #region
            downTexture = Content.Load<Texture2D>("character/player/downtexture");
            rightTexture = Content.Load<Texture2D>("character/player/righttexture");
            upTexture = Content.Load<Texture2D>("character/player/uptexture");
            leftTexture = Content.Load<Texture2D>("character/player/lefttexture");
            #endregion
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the player if isVisible = true
            #region
            if (isVisible == true)
            {
                spriteBatch.Draw(texture, position, null,
                Color.White, 0f, Vector2.Zero, 2, SpriteEffects.None, 0f);
            }
            #endregion
        }
    }
}
