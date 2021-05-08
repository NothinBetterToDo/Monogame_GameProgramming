using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class Enemy
    {
        public static List<Enemy> enimies = new List<Enemy>();

        private Vector2 position = new Vector2(0, 0);
        private int speed = 150;
        public SpriteAnimation anim;
        public int radius = 30;
        private bool dead = false;

        //constructor
        public Enemy(Vector2 newPos, Texture2D spriteSheet) //skull
        {
            position = newPos;
            anim = new SpriteAnimation(spriteSheet, 10, 6);
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }

        public void Update(GameTime gameTime, Vector2 playerPos, bool isPlayerDead)
        {
            anim.Position = new Vector2(position.X - 48, position.Y - 66); //width=96, height = 132 
            anim.Update(gameTime);

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!isPlayerDead)
            {
                Vector2 moveDir = playerPos - position; //player - enemy position
                moveDir.Normalize(); //get direction within 1
                position += moveDir * speed * dt; //exact distance per frame
            }
            
        }


    }
}
