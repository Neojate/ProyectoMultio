using MapMaker.Actions;
using MapMaker.Helpers;
using MapMaker.MapMaker;
using MapMaker.Models.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using ProyectoMultio.Models.Elements;
using ProyectoMultio.Models.Map;
using System.Collections.Generic;

namespace MapMaker
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Tile TileOnMemory;

        private List<UIElement> uIElements;

        Map map = new Map();

        MouseState mouseState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Globals.ScreenSize = new Point(1900, 1080);

            graphics.PreferredBackBufferWidth = Globals.ScreenSize.X;
            graphics.PreferredBackBufferHeight = Globals.ScreenSize.Y;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.SpriteBatch = spriteBatch;
            Globals.Content = Content;

            //carga de texturas y fuentes
            Textures.Load();
            Fonts.Load();

            //pantalla
            createWindow();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                foreach (IClickable i in uIElements.FindAll(ui => ui is IClickable))
                    i.onClick(mousePosition);

                for (int y = 0; y < map.Size.Y; y++)
                    for (int x = 0; x < map.Size.X; x++)
                        if (new Rectangle(x * 32 + 310, y * 32 + 10, 32, 32).Contains(mousePosition))
                            map.Scenario[x, y] = TileOnMemory;
            }

            foreach (IClickable i in uIElements.FindAll(ui => ui is IClickable))
                i.onHover(mousePosition);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var sceneario = map.Scenario;

            spriteBatch.Begin();

            //dibujar la UI
            foreach (IRenderizable i in uIElements)
                i.Render();

            //dibujado del mapa de pega
            for (int y = 0; y < map.Size.Y; y++)
                for (int x = 0; x < map.Size.X; x++)
                    spriteBatch.Draw(Textures.Tiles, new Vector2(32 * x + 310, 32 * y + 10), new Rectangle(sceneario[x, y].SourcePoint.X, sceneario[x, y].SourcePoint.Y, 32, 32), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void createWindow()
        {
            uIElements = new List<UIElement>()
            {
                new Panel
                {
                    Bounds = new Rectangle(0, 0, Globals.ScreenSize.X, Globals.ScreenSize.Y),
                    SourceRectangle = new Rectangle(160, 50, 1, 1),
                    BackgroundColor = Color.Red
                },
                new Panel
                {
                    Bounds = new Rectangle(0, 0, 300, Globals.ScreenSize.Y),
                    SourceRectangle = new Rectangle(75, 50, 1, 1),
                    BackgroundColor = Color.Red
                },
                new TileButton()
                {
                    Bounds = new Rectangle(10, 10, 32, 32),
                    Texture = Textures.Tiles,
                    SourceRectangle = new Rectangle(96, 32, 32, 32),
                    Tile = Utils.GetTile(TileType.Road)
                },
                new TileButton()
                {
                    Bounds = new Rectangle(74, 10, 32, 32),
                    Texture = Textures.Tiles,
                    SourceRectangle = new Rectangle(192, 32, 32, 32),
                    Tile = Utils.GetTile(TileType.Grass)
                },
                new TileButton()
                {
                    Bounds = new Rectangle(138, 10, 32, 32),
                    Texture = Textures.Tiles,
                    SourceRectangle = new Rectangle(288, 0, 32, 32),
                    Tile = Utils.GetTile(TileType.Land)
                },
                new Button()
                {
                    Bounds = new Rectangle(100, 800, 20, 30),
                    SourceRectangle = new Rectangle(0, 0, 1, 1),
                    Text = "Guardar Partida",
                    ActionClick = new Button.Click(SaveMap)
                },
                new Button()
                {
                    Bounds = new Rectangle(100, 900, 20, 30),
                    SourceRectangle = new Rectangle(0, 0, 1, 1),
                    Text = "Cargar Partida",
                    ActionClick = new Button.Click(LoadMap)
                },
                new Button()
                {
                    Bounds = new Rectangle(100, 700, 20, 30),
                    SourceRectangle = new Rectangle(0, 0, 1, 1),
                    Text = "Prueba",
                    ActionClick = new Button.Click(map.Prueba)
                }
            };
            map.X.Add(new Door()
            {
                Bounds = new Rectangle(0, 0, 0, 0),
                IsOpen = false,
                SourceRectangle = new Rectangle(0, 0, 0, 0)
            });
        }

        private void SaveMap()
        {
            map.SaveMap("Mundo30x30");
        }

        private void LoadMap()
        {
            map = map.LoadMap("Mundo30x30");
        }

    }
}
