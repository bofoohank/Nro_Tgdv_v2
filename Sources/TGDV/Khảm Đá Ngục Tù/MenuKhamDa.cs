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
using NRO_Server.TGDV.Khảm_Đá_Ngục_Tù;

namespace NRO_Server.TGDV.Khảm_Đá_Ngục_Tù
{
	public class MenuKhamDa
	{
		private static MenuKhamDa _instance;
        public MenuKhamDa()
        {
        }
        public static MenuKhamDa Gi()
        {
            if (_instance == null) _instance = new MenuKhamDa();
            return _instance;
        }
		
		public void OpenMenuKhamDa(NRO_Server.Model.Character.Character character, int npcId, int menu)
        {
			if (menu == 0)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextKhamDa.Gi().TextKhamDaTrangBi[0], TextKhamDa.Gi().MenuKhamDaTrangBi[0], character.InfoChar.Gender));
                character.TypeMenu = 0;
            }
        }
		
		public void ConfirmMenuKhamDa(NRO_Server.Model.Character.Character character, int npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                    {
						switch (select)
                        {
                            case 0:
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextKhamDa.Gi().MenuKhamDaTrangBi[1]));
                                    character.ShopId = 11;
									break;
                                }
                            case 1:
                                {
									character.CharacterHandler.SendMessage(Service.SendCombinne0(TextKhamDa.Gi().MenuKhamDaTrangBi[2]));
                                    character.ShopId = 12;
									break;
                                }
                        }
                        break;
                    }
				case 1://Typemenu khảm đá
				{
					if (select != 0) return;
					var listArray = character.CombinneIndex;
					var itemBag = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
					var daNgucTu = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
					var soNgocCanNangCap = listArray[2];
                    var soVangCanNangCap = listArray[3]; 
					
					if (character.InfoChar.Gold < soVangCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_GOLD));
                        return;
                    }
                    if (character.AllDiamond() < soNgocCanNangCap)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage(TextServer.gI().NOT_ENOUGH_DIAMOND));
                        return;
                    }
					
					character.CharacterHandler.RemoveItemBagByIndex(daNgucTu.IndexUI, 10, false, reason: "Khảm đá");
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
					
					if (daNgucTu.Id == 1112)
					{
						var optionCheck = itemBag.Options.FirstOrDefault(opt => opt.Id == 233);
						if (optionCheck == null)
						{
							itemBag.Options.Add(new OptionItem()
                            {
                                Id = 233,
								Param = 100
                            });
						}
						else
                        {
                            optionCheck.Param += 100;
                        }
					}
					else if (daNgucTu.Id == 1113)
					{
						var optionCheck = itemBag.Options.FirstOrDefault(opt => opt.Id == 234);
						if (optionCheck == null)
						{
							itemBag.Options.Add(new OptionItem()
                            {
                                Id = 234,
								Param = 100
                            });
						}
						else
                        {
                            optionCheck.Param += 100;
                        }
					}
					else if (daNgucTu.Id == 1114)
					{
						var optionCheck = itemBag.Options.FirstOrDefault(opt => opt.Id == 234);
						if (optionCheck == null)
						{
							itemBag.Options.Add(new OptionItem()
                            {
                                Id = 234,
								Param = 100
                            });
						}
						else
                        {
                            optionCheck.Param += 100;
                        }
					}
					
					character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
					character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
					
					var checkitemBag = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var listIndexUi = new List<int>();
                    if (checkitemBag != null && checkitemBag.Id == checkitemBag.Id)
                    {
                        listIndexUi.Add(checkitemBag.IndexUI);
                    }
					
					var itemReturn = character.ItemBag.FirstOrDefault(item =>
                             item.Options.Count == itemBag.Options.Count && item.IndexUI != itemBag.IndexUI) ?? itemBag;
                        character.CharacterHandler.SendMessage(Service.SendCombinne1(new List<int>() { itemReturn.IndexUI }));

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 2://Tymenu ghép đá ngục tù
                    {
                        if (select != 0) return;
                        var bagNull = character.LengthBagNull();
                        var listArray = character.CombinneIndex;
                        var itemOld = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                        var idNew = (short)(1111 + ServerUtils.RandomNumber(1, 3));
                        var itemNew = ItemCache.GetItemDefault(idNew);

                        var itemBagNotMax = character.CharacterHandler.ItemBagNotMaxQuantity(itemNew.Id);
                        if (itemBagNotMax == null && bagNull < 1)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        switch (itemOld.Id)
                        {
                            case 1115:
                                {
                                    character.CharacterHandler.RemoveItemBagByIndex(itemOld.IndexUI, 5, false, reason: "Ghép đá ngục tù");
                                    break;
                                }
                        }
                        character.MineGold(2000);
                        character.CharacterHandler.AddItemToBag(true, itemNew, "Ghép đá ngục tù");
                        character.CharacterHandler.SendMessage(Service.BuyItem(character));
                        character.CharacterHandler.SendMessage(Service.SendBag(character));

                        var listIndexUi = new List<int>();
                        var itemReturn = character.CharacterHandler.GetItemBagByIndex(itemOld.IndexUI);
                        if (itemReturn != null && itemReturn.Id == itemOld.Id)
                        {
                            listIndexUi.Add(itemOld.IndexUI);
                        }

                        character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                        //character.CharacterHandler.SendMessage(Service.SendCombinne4(ItemCache.ItemTemplate(itemNew.Id).IconId));
						if (idNew == 1112)
						{
							character.CharacterHandler.SendMessage(Service.ServerMessage("Đã nhận x1 Đá ngục tù 1"));
						}
						else if (idNew == 1113)
						{
							character.CharacterHandler.SendMessage(Service.ServerMessage("Đã nhận x1 Đá ngục tù 2"));
						}
						else if (idNew == 1114)
						{
							character.CharacterHandler.SendMessage(Service.ServerMessage("Đã nhận x1 Đá ngục tù 3"));
						}
                        character.CombinneIndex.Clear();
                        character.CombinneIndex = null;
                        break;
                    }
			}
		}
	}
}