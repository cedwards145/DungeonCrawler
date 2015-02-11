﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SimpleRPG.Windows
{
    public class MessageWindow : Window
    {
        protected string message;
        protected int messageLength;
        protected Boolean removeMe = false;

        public MessageWindow(Game1 game, string reqMessage)
            :base(game, new Point(), 300 * game.getGraphicsScale(), 64 * game.getGraphicsScale(), "windowskin")
        {
            message = reqMessage;
            setPosition(new Point(GraphicsHelper.calculateCenterPositionP(width, height).X, 
                                  game.getHeight() - height - (10 * game.getGraphicsScale())));
        }

        public override void update()
        {
            base.update();
            if (opacity >= 1 && messageLength < message.Length)
                messageLength++;

            if (Input.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter) && messageLength < message.Length)
                messageLength = message.Length;
            else if (Input.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
                removeMe = true;
        }

        public bool isFinished()
        {
            return removeMe;
        }

        public override void draw(SpriteBatch spriteBatch)
        {
            base.draw(spriteBatch);
            string messageSubString = message.Substring(0, messageLength);
            spriteBatch.DrawString(font, messageSubString, new Vector2(location.X + 10, location.Y + 10), Color.White * opacity);
        }
    }
}
