#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace BugSmash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        //found this line of code on a website
        //used it to fix problem of random nums generating too fast (created too similar numbers)
        Random random = new Random(Guid.NewGuid().GetHashCode());
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fontPlay;
        //pixel texture allows us to draw simple rectangles
        //will be replaced with actual textures later
        private Texture2D pixel;
        private Texture2D blanket;
        //lists that update and maintain bugs & splats in game
        private List<Splat> splatlist = new List<Splat>();
        private List<Bug> buglist = new List<Bug>();
        private int level = 1;
        public int score = 0;
        public int highScore;
        private int lives = 3;
        private int lifeReplenish;
        public int screen = 0;
        public bool gameOver;
        Vector2 fontPos;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 25;
        //creates menu screen
        MenuScreen menu = new MenuScreen();
        //used for drawing color filled rectangles
        Color[] colordata = { Color.White };
        //used to make game fullscreen
        public int screenWidth { get; set; }
        public int screenHeight { get; set; }
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
       
        protected override void Initialize()
        {
            //creates bugs for level 1
            int num = ((Vars.screenWidth * 17) / 16);
            for (int i = buglist.Count; i < (level); i++)
            {
                switch (random.Next(0, 2))
                {
                    case 0: buglist.Add(new Bug(random.Next(0, num), 0 - (Vars.screenWidth / 16), 0)); break;
                    case 1: buglist.Add(new Bug(((Vars.screenWidth * 17) / 16), random.Next(0, ((Vars.screenHeight * 90) / 100)), 0)); break;
                }
            }
            this.IsMouseVisible = true;
            gameOver = false;
            graphics.IsFullScreen = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //for now this just makes the spritebatch and loads the blanket image
            spriteBatch = new SpriteBatch(GraphicsDevice);
            blanket = Content.Load<Texture2D>("Blanket");
            fontPlay = Content.Load<SpriteFont>("playFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //states keep track of what screen the game should be displaying
            //0 = menu
            //1 = game
            //2 = gameOver
            //might replace with enums later on
            if (screen == 0)
            {
                //draws colored rectangles
                pixel = new Texture2D(GraphicsDevice, 1, 1);
                pixel.SetData<Color>(colordata);
                //checks if play button is clicked
                //if true the screen is changed and variables are reset (allows games to be played in succession)
                menu.checkButton();
                if (menu.clicked == true) { screen = 1; buglist.Clear(); splatlist.Clear(); level = 0; menu.clicked = false; }
            }
            else if (screen == 1)
            {
                //each level lasts until all bugs are killed
                if (buglist.Count > 0)
                {
                    //can't edit amount of bugs in the list (due to foreach restrictions)
                    //workaround by using an array
                    foreach (Bug b in buglist) b.checkDeath();
                    foreach (Bug b in buglist.ToArray())
                    {
                        //if a bug dies, remove it from buglist and add to splatlist
                        if (b.dead == true)
                        {
                            splatlist.Add(new Splat(b.X, b.Y));
                            buglist.Remove(b);
                            score++;
                            lifeReplenish++;
                        }
                        //player gets a life for every 25 kills
                        if (lifeReplenish == 25)
                        {
                            lives++;
                            lifeReplenish = 0;
                        }
                    }
                    //we had framerate issues (everything was moving superfast)
                    //regulates time between frames
                    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        timeSinceLastFrame -= millisecondsPerFrame;
                        //checks to see if any bugs made it to the blanket
                        //if bug made it to the blanket subtract lives and score
                        //if a bug hits the blanket and there are no more lives end the game
                        //shows game over screen
                        foreach (Bug a in buglist)
                        {
                            gameOver = a.Move();
                            if (gameOver) { lives -= 1; a.Dead = true; score -= 1; }
                            if (gameOver && lives == 0) { screen = 2; break; }

                        }
                    }
                }
                //if no game over criteria are met
                //go to the next level (repopulates bug list)
                else
                {
                    level += 1;
                    splatlist.Clear();
                    for (int i = buglist.Count; i < (level * level); i++)
                    {
                        int ranny = random.Next(0, 2);
                        switch (ranny)
                        {
                            case 0: buglist.Add(new Bug(random.Next(0, (Vars.screenWidth * 17) / 16), 0 - (Vars.screenWidth / 16), 0)); break;
                            case 1: buglist.Add(new Bug(((Vars.screenWidth * 17) / 16), random.Next(0, ((Vars.screenHeight * 90) / 100)), 0)); break;
                        }

                    }
                }
            }
            //if player clicks on the gameover screen transition back to menu screen
            else if (screen == 2)
            {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    score = 0;
                    lives = 3;
                    lifeReplenish = 0;
                    screen = 0;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Vars.screenHeight = Window.ClientBounds.Height;
            Vars.screenWidth = Window.ClientBounds.Width;
            spriteBatch.Begin();
            if (screen == 0)
            {
                GraphicsDevice.Clear(Color.Bisque);
                spriteBatch.Draw(pixel, new Rectangle(((Vars.screenWidth * 80) / 100), ((Vars.screenHeight * 78) / 100), Vars.screenWidth / 5, ((Vars.screenHeight * 22) / 100)), Color.Green);
                spriteBatch.Draw(pixel, new Rectangle(((Vars.screenWidth * 0) / 100), ((Vars.screenHeight * 78) / 100), Vars.screenWidth / 5, ((Vars.screenHeight * 22) / 100)), Color.Blue);
                fontPos.X = Vars.screenWidth / 2;
                fontPos.Y = Vars.screenHeight / 2;
                spriteBatch.DrawString(fontPlay, "Bug Smash", fontPos, Color.Black);
                fontPos.X = (Vars.screenWidth * 85) / 100;
                fontPos.Y = (Vars.screenHeight * 85) / 100;
                spriteBatch.DrawString(fontPlay, "Play", fontPos, Color.Black);
                fontPos.X = (Vars.screenWidth * 2) / 100;
                fontPos.Y = (Vars.screenHeight * 85) / 100;
                spriteBatch.DrawString(fontPlay, "Change game files", fontPos, Color.Black);


            }
            else if (screen == 1)
            {

                GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Draw(pixel, new Rectangle(0, 0, Vars.screenWidth, Vars.screenHeight), Color.WhiteSmoke);
                spriteBatch.Draw(blanket, new Rectangle(0, ((Vars.screenHeight * 2) / 3), Vars.screenWidth / 4, Vars.screenHeight / 3), Color.White);
                //spriteBatch.Draw(pixel, new Rectangle(0, ((Vars.screenHeight * 3) / 4), Vars.screenWidth / 5, Vars.screenHeight / 4), Color.Black);
                foreach (Splat s in splatlist)
                {
                    spriteBatch.Draw(pixel, new Rectangle(s.X, s.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.Green);
                }
                //draw each bug based on its current direction (we used ratios to maintain object sizes)
                foreach (Bug b in buglist)
                {
                    switch (b.Direction)
                    {
                        case 0: spriteBatch.Draw(pixel, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.Red); break;
                        case 1: spriteBatch.Draw(pixel, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.Red); break;
                        case 2: spriteBatch.Draw(pixel, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.Red); break;
                        case 3: spriteBatch.Draw(pixel, new Rectangle(b.X, b.Y, ((Vars.screenWidth) / 16), ((Vars.screenWidth) / 16)), Color.Red); break;
                    }
                }
                fontPos.X = (Vars.screenWidth * 4) / 6;
                fontPos.Y = (Vars.screenHeight / 20);
                spriteBatch.DrawString(fontPlay, "Score: " + score + " Lives: " + lives + " Level: " + level, fontPos, Color.Black);
            }
            //prevents score from being less than 0
            //happens if first three bugs hit the blanket
            //will be handled better in later milestones
            else if (screen == 2)
            {
                GraphicsDevice.Clear(Color.Black);
                if (score < 0)
                {
                    score = 0;
                }
                fontPos.X = (Vars.screenWidth / 2);
                fontPos.Y = (Vars.screenHeight / 2);
                spriteBatch.DrawString(fontPlay, "Game Over", fontPos, Color.White);
                fontPos.X = (Vars.screenWidth / 2);
                fontPos.Y = (Vars.screenHeight * 2) / 3;
                spriteBatch.DrawString(fontPlay, "Your score: " + score, fontPos, Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
    //had issues with variable accessibility
    //solved by creating Vars class
    public static class Vars
    {
        public static int screenHeight { get; set; }
        public static int screenWidth { get; set; }
    }
}
