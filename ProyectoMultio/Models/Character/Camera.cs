using Microsoft.Xna.Framework;
using ProyectoMultio.Helper;
using ProyectoMultio.Models.Character;

namespace ProyectoMultio.Models.Character
{
    public class Camera
    {
        public Point Position { get; set; }
        public Vector2 RenderTiles { get; set; }

        private Player player;

        public Camera(Player player)
        {
            this.player = player;

            Position = new Point(1, 1);

            RenderTiles = new Vector2()
            {
                X = Globals.Resolution.X / Globals.TileSize.X,
                Y = Globals.Resolution.Y / Globals.TileSize.Y
            };
        }

        public void MoveCamera()
        {
            Point destination = new Point()
            {
                X = Globals.Resolution.X / Globals.TileSize.X / 2,
                Y = Globals.Resolution.Y / Globals.TileSize.Y / 2
            };
            Position = Utils.SubstractPoints(destination, player.Position);
        }
    }
}
