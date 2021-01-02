using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProyectoMultio.Helper;
using ProyectoMultio.Modules.Options;
using ProyectoMultio.Modules.ScreenManagers;
using ProyectoMultio.Views;

namespace ProyectoMultio
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Arranque de las opciones del juego
            Globals.Options = new Options();

            graphics.PreferredBackBufferWidth = Globals.Resolution.X;
            graphics.PreferredBackBufferHeight = Globals.Resolution.Y;

            IsMouseVisible = true;
            //graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.SpriteBatch = spriteBatch;
            
            Globals.Content = this.Content;

            //cargas de recursos
            Textures.Load();
            Fonts.Load();
            Lang.Load();

            Globals.ScreenManager = new ScreenManager();
            //pantalla de inicio de la partida
            Globals.ScreenManager.AddScreen(new GameScreen()); 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Actualizacion del Input
            Input.Update();

            //Actualizacion de las pantallas
            Globals.ScreenManager.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Globals.SpriteBatch.Begin();
            Globals.ScreenManager.Draw();
            Globals.SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
