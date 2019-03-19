using InfiniteChestsV3;
using Terraria;
using TShockAPI;

namespace ChestroomPlugin
{
	public static class Utils
	{
		public static void ConvertToAutoRefill(int start, int end)
		{
			for (int i = start; i < start + end; i++)
			{
				Chest c = Main.chest[i];

				if (c == null)
					continue;

				DB.AddChest(new InfChest(_userid: -1, _x: c.x, _y: c.y, _worldid: Main.worldID)
				{
					items = c.item,
					isPublic = true,
				});
			}
		}

		public static void informplayers(bool hard = false)
		{
			foreach (TSPlayer ts in TShock.Players)
			{
				if (ts == null || !ts.Active)
					continue;

				for (int i = 0; i < 255; i++)
				{
					for (int j = 0; j < Main.maxSectionsX; j++)
					{
						for (int k = 0; k < Main.maxSectionsY; k++)
							Netplay.Clients[i].TileSections[j, k] = false;
					}
				}
			}
		}
	}
}
