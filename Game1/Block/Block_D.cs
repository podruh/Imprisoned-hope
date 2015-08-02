using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imprisoned_Hope
{
	public partial class Block
	{

		public bool IsNearToPlayer(Player player)
		{
			if (this.X == player.Rectangle.X && this.Y +this.Texture.Height == player.Rectangle.Y)
			{
				return true;
			}
			else if(this.X==player.Rectangle.X+player.Texture.Width && this.Y == player.Rectangle.Y)
			{
				return true;
			}
			else if (this.X == player.Rectangle.X && this.Y == player.Rectangle.Y + player.Texture.Height)
			{
				return true;
			}
			else if (this.X + this.Texture.Width == player.Rectangle.X && this.Y == player.Rectangle.Y)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
