using NRO_Server.Application.IO;
using NRO_Server.Application.Main;
using NRO_Server.Model.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NRO_Server.Main.Menu;
using NRO_Server.Application.Constants;
using NRO_Server.Application.Threading;
using NRO_Server.Application.Manager;
using NRO_Server.DatabaseManager;
using NRO_Server.DatabaseManager.Player;
using NRO_Server.Model.Template;
using NRO_Server.Model.Option;
using System.Runtime.CompilerServices;
using NRO_Server.Application.Interfaces.Character;
using NRO_Server.Application.Handlers.Client;
using NRO_Server.TGDV.Nâng_Cấp_SKH;

namespace NRO_Server.TGDV.Nâng_Cấp_SKH
{
	public class MenuNcSKH
	{
		private static MenuNcSKH _instance;
        public MenuNcSKH()
        {
        }
        public static MenuNcSKH Gi()
        {
            if (_instance == null) _instance = new MenuNcSKH();
            return _instance;
        }
		
		public void OpenMenuNcSKH(NRO_Server.Model.Character.Character character, int npcId, int menu)
        {
			if (menu == 0)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNcSKH.Gi().TextNangCapSKH[0], TextNcSKH.Gi().MenuNangCapSKH[0], character.InfoChar.Gender));
                character.TypeMenu = 0;
            }
			if (menu == 1)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNcSKH.Gi().TextNangCapSKH[1], TextNcSKH.Gi().MenuNangCapSKH[1], character.InfoChar.Gender));
                character.TypeMenu = 1;
            }
			if (menu == 2)
			{
                character.CharacterHandler.SendMessage(Service.SendCombinne0(TextNcSKH.Gi().MenuNangCapSKH[3]));
                character.ShopId = 15;
            }
        }
		public void ConfirmMenuNcSKH(NRO_Server.Model.Character.Character character, int npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
				{
					switch (select)
					{
						case 0:
						{
							OpenMenuNcSKH(character, npcId, 1);
							break;
						}
						case 1:
						{
							OpenMenuNcSKH(character, npcId, 2);
							break;
						}
					}
					break;
				}
				case 1:
                    {
						switch (select)
                        {
							case 0:
							{
								character.CharacterHandler.SendMessage(Service.SendCombinne0(TextNcSKH.Gi().MenuNangCapSKH[2]));
                                character.ShopId = 13;
								break;
							}
							case 1:
							{
								character.CharacterHandler.SendMessage(Service.SendCombinne0(TextNcSKH.Gi().MenuNangCapSKH[3]));
                                character.ShopId = 14;
								break;
							}
						}
						break;
					}
				case 2:
				{
					var listArray = character.CombinneIndex;
                    var item1 = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var item2 = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
                    HandlerDoiSKH(character, ItemCache.ItemTemplate(item1.Id).Type, ItemCache.ItemTemplate(item1.Id).Gender, 1);
                    character.CharacterHandler.RemoveItemBagByIndex(item1.IndexUI, 1, false, reason: "Đổi SKH");
                    character.CharacterHandler.RemoveItemBagByIndex(item2.IndexUI, 1, false, reason: "Đổi SKH");
                    character.MineGold(100000000);
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 3:
				{
					var listArray = character.CombinneIndex;
                    var item1 = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
					var item2 = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
					var item3 = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
                    HandlerDoiSKH(character, ItemCache.ItemTemplate(item1.Id).Type, ItemCache.ItemTemplate(item1.Id).Gender, 1);
                    character.CharacterHandler.RemoveItemBagByIndex(item1.IndexUI, 1, false, reason: "Đổi SKH");
					character.CharacterHandler.RemoveItemBagByIndex(item2.IndexUI, 1, false, reason: "Đổi SKH");
					character.CharacterHandler.RemoveItemBagByIndex(item3.IndexUI, 1, false, reason: "Đổi SKH");
                    character.MineGold(100000000);
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 4:
				{
                    var listArray = character.CombinneIndex;
                    var item1 = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
					var item2 = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
					var item3 = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
					var item4 = character.CharacterHandler.GetItemBagByIndex(listArray[3]);
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
					var listOptionTd = new List<int>() {127,128,129};
                    var listOptionTd2 = new List<int>() {139,140,141};
					var listOptionNm = new List<int> {130, 131, 132};
					var listOptionNm2 = new List<int> {142,143,144};
					var listOptionXd = new List<int> {130, 131, 132};
					var listOptionXd2 = new List<int> {136, 137, 138};
					if (item1.Id == 0)
					{
						var itemNew = ItemCache.GetItemDefault(3);
						itemNew.Options.Add(new OptionItem()
                        {
                            Id = listOptionTd[ServerUtils.RandomNumber(listOptionTd.Count)],
                            Param = 0,
                        });
						itemNew.Options.Add(new OptionItem()
                        {
                            Id = listOptionTd2[ServerUtils.RandomNumber(listOptionTd2.Count)],
                            Param = 0,
                        });
						character.CharacterHandler.AddItemToBag(false, itemNew);
					}
                    character.CharacterHandler.RemoveItemBagByIndex(item1.IndexUI, 1, false, reason: "Đổi SKH");
					character.CharacterHandler.RemoveItemBagByIndex(item2.IndexUI, 1, false, reason: "Đổi SKH");
					character.CharacterHandler.RemoveItemBagByIndex(item3.IndexUI, 1, false, reason: "Đổi SKH");
					character.CharacterHandler.RemoveItemBagByIndex(item4.IndexUI, 1, false, reason: "Đổi SKH");
                    character.MineGold(0);
                    character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
			}
		}
		private void HandlerDoiSKH(NRO_Server.Model.Character.Character character,int typeItem,int gender, int type = 0)
        {
            var listItem = new List<int>() { };
            var listOption = new List<int>() { };
            var listOption2 = new List<int>() { };
            switch (typeItem)
            {
                case 0: // ao
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 0 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 1 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 2 };
                                    break;
                                }
                        }
                        break;
                    }
                case 1: // quan
                    { 
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 6 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 7 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 8 };
                                    break;
                                }
                        }
                        break;
                    }
                case 2: // găng
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 21 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 22 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 23 };
                                    break;
                                }
                        }
                        break;
                    }
                case 3: // giay
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 27 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 28 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 29 };
                                    break;
                                }
                        }
                        break;
                    }
                case 4: // rada
                    {
                        listItem = new List<int> { 12 };
                        break;
                    }
                
            }
            switch (gender)
            {
                case 0:
                    {
                        listOption = new List<int> {127,128,129 };
                        listOption2 = new List<int> {139,140,141};
                        break;
                    }
                case 1:
                    {
                        listOption = new List<int> { 130, 131, 132 };
                        listOption2 = new List<int> { 142,143,144 };
                        break;
                    }
                case 2:
                    {
                        listOption = new List<int> { 130, 131, 132 };
                        listOption2 = new List<int> { 136, 137, 138 };
                        break;
                    }
            }
            var item = ItemCache.GetItemDefault(((short)listItem[ServerUtils.RandomNumber(listItem.Count)]));
            if (type == 0)//normal
            {
                item = ItemCache.GetItemDefault(((short)listItem[0]));
            }
            item.Options.Add(new OptionItem()
            {
                Id = listOption[ServerUtils.RandomNumber(listOption.Count)],
                Param = 0,
            });
            item.Options.Add(new OptionItem()
            {
                Id = listOption2[ServerUtils.RandomNumber(listOption2.Count)],
                Param = 0,
            });
            character.CharacterHandler.AddItemToBag(false, item);
        }
		private void HandlerNangCapSKH(NRO_Server.Model.Character.Character character,int typeItem,int gender, int type = 0)
        {
            var listItem = new List<int>() { };
            var listOption = new List<int>() { };
            var listOption2 = new List<int>() { };
            switch (typeItem)
            {
                case 0: // ao
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 0, 3, 33, 34, 136, 137, 138, 139, 230, 231, 232, 233, 555 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 1, 4, 41, 42, 152, 153, 154, 155, 234, 235, 236, 237, 557 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 2, 5, 49, 50, 168, 169, 170, 171, 238, 239, 240, 241, 559 };
                                    break;
                                }
                        }
                        break;
                    }
                case 1: // quan
                    { 
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 6, 9, 35, 36, 140, 141, 142, 143, 242, 243, 244, 245, 556 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 7, 10, 43, 44, 156, 157, 158, 159, 246, 247, 248, 249, 558 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 8, 11, 51, 52, 172, 173, 174, 175, 250, 251, 252, 253, 560 };
                                    break;
                                }
                        }
                        break;
                    }
                case 2: // găng
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 21, 24, 37, 38, 144, 145, 146, 147, 254, 255, 256, 257, 562 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 22, 25, 45, 46, 160, 161, 162, 163, 258, 259, 260, 261, 564 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 23, 26, 53, 54, 176, 177, 178, 179, 262, 263, 264, 265, 566 };
                                    break;
                                }
                        }
                        break;
                    }
                case 3: // giay
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 27, 30, 39, 40, 148, 149, 150, 151, 266, 267, 268, 269, 563 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 28, 31, 47, 48, 164, 165, 166, 167, 270, 271, 272, 273, 565 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 29, 32, 55, 56, 180, 181, 182, 183, 274, 275, 276, 277, 567 };
                                    break;
                                }
                        }
                        break;
                    }
                case 4: // rada
                    {
                        listItem = new List<int> { 12, 57, 58, 59, 184, 185, 186, 187, 278, 279, 280, 281, 561 };
                        break;
                    }
                
            }
            switch (gender)
            {
                case 0:
                    {
                        listOption = new List<int> {127,128,129 };
                        listOption2 = new List<int> {139,140,141};
                        break;
                    }
                case 1:
                    {
                        listOption = new List<int> { 130, 131, 132 };
                        listOption2 = new List<int> { 142,143,144 };
                        break;
                    }
                case 2:
                    {
                        listOption = new List<int> { 130, 131, 132 };
                        listOption2 = new List<int> { 136, 137, 138 };
                        break;
                    }
            }
			if (listItem.Count == 0)
			{
				var item = ItemCache.GetItemDefault(3);
				item.Options.Add(new OptionItem()
				{
                    Id = listOption[ServerUtils.RandomNumber(listOption.Count)],
                    Param = 0,
                });
				item.Options.Add(new OptionItem()
				{
                    Id = listOption2[ServerUtils.RandomNumber(listOption.Count)],
                    Param = 0,
                });
				character.CharacterHandler.AddItemToBag(false, item);
			}
        }
		
		private void HandlerGhepTrangBiHuyDiet(NRO_Server.Model.Character.Character character,int typeItem,int gender, int type = 0)
        {
            var listItem = new List<int>() { };
            var listOption = new List<int>() { };
            var listOption2 = new List<int>() { };
            switch (typeItem)
            {
                case 0: // ao
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 0, 3, 33, 34, 136, 137, 138, 139, 230, 231, 232, 233, 555 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 1, 4, 41, 42, 152, 153, 154, 155, 234, 235, 236, 237, 557 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 2, 5, 49, 50, 168, 169, 170, 171, 238, 239, 240, 241, 559 };
                                    break;
                                }
                        }
                        break;
                    }
                case 1: // quan
                    { 
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 6, 9, 35, 36, 140, 141, 142, 143, 242, 243, 244, 245, 556 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 7, 10, 43, 44, 156, 157, 158, 159, 246, 247, 248, 249, 558 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 8, 11, 51, 52, 172, 173, 174, 175, 250, 251, 252, 253, 560 };
                                    break;
                                }
                        }
                        break;
                    }
                case 2: // găng
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 21, 24, 37, 38, 144, 145, 146, 147, 254, 255, 256, 257, 562 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 22, 25, 45, 46, 160, 161, 162, 163, 258, 259, 260, 261, 564 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 23, 26, 53, 54, 176, 177, 178, 179, 262, 263, 264, 265, 566 };
                                    break;
                                }
                        }
                        break;
                    }
                case 3: // giay
                    {
                        switch (gender)
                        {
                            case 0: // trai dat
                                {
                                    listItem = new List<int> { 27, 30, 39, 40, 148, 149, 150, 151, 266, 267, 268, 269, 563 };
                                    break;
                                }
                            case 1: // namec
                                {
                                    listItem = new List<int> { 28, 31, 47, 48, 164, 165, 166, 167, 270, 271, 272, 273, 565 };
                                    break;
                                }
                            case 2: // xayda
                                {
                                    listItem = new List<int> { 29, 32, 55, 56, 180, 181, 182, 183, 274, 275, 276, 277, 567 };
                                    break;
                                }
                        }
                        break;
                    }
                case 4: // rada
                    {
                        listItem = new List<int> { 12, 57, 58, 59, 184, 185, 186, 187, 278, 279, 280, 281, 561 };
                        break;
                    }
                
            }
            switch (gender)
            {
                case 0:
                    {
                        listOption = new List<int> {127,128,129 };
                        listOption2 = new List<int> {139,140,141};
                        break;
                    }
                case 1:
                    {
                        listOption = new List<int> { 130, 131, 132 };
                        listOption2 = new List<int> { 142,143,144 };
                        break;
                    }
                case 2:
                    {
                        listOption = new List<int> { 130, 131, 132 };
                        listOption2 = new List<int> { 136, 137, 138 };
                        break;
                    }
            }
            var item = ItemCache.GetItemDefault(((short)listItem[ServerUtils.RandomNumber(listItem.Count)]));
            if (type == 0)//normal
            {
                item = ItemCache.GetItemDefault(((short)listItem[0]));
            }
            item.Options.Add(new OptionItem()
            {
                Id = listOption[ServerUtils.RandomNumber(listOption.Count)],
                Param = 0,
            });
            item.Options.Add(new OptionItem()
            {
                Id = listOption2[ServerUtils.RandomNumber(listOption2.Count)],
                Param = 0,
            });
            character.CharacterHandler.AddItemToBag(false, item);
        }
	}
}