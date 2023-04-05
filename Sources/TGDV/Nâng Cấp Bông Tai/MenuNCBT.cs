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
using NRO_Server.TGDV.Nâng_Cấp_Bông_Tai;

namespace NRO_Server.TGDV.Nâng_Cấp_Bông_Tai
{
    public class MenuNCBT
    {
        private static MenuNCBT _instance;
        public MenuNCBT()
        {
        }
        public static MenuNCBT Gi()
        {
            if (_instance == null) _instance = new MenuNCBT();
            return _instance;
        }
		
        public void OpenMenuNCBT(NRO_Server.Model.Character.Character character, int npcId, int menu)
        {
			if (menu == 0)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuNCBT.Gi().TextNangBongTai[0], TextMenuNCBT.Gi().MenuNangBongTai[0], character.InfoChar.Gender));
                character.TypeMenu = 0;
            }
			if (menu == 1)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuNCBT.Gi().TextNangBongTai[0], TextMenuNCBT.Gi().MenuNangBongTai[1], character.InfoChar.Gender));
                character.TypeMenu = 1;
			}
			if (menu == 2)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuNCBT.Gi().TextNangBongTai[0], TextMenuNCBT.Gi().MenuNangBongTai[2], character.InfoChar.Gender));
                character.TypeMenu = 2;
			}
        }
        public void ConfirmMenuNCBT(NRO_Server.Model.Character.Character character, int npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                    {
                        switch (select)
						{
							case 0://Nâng cấp bông tai
							{
                                OpenMenuNCBT(character, npcId, 1);
                                break;
							}
							case 1://Mở chỉ số bông tai
							{
                                OpenMenuNCBT(character, npcId, 2);
                                break;
							}
						}
						break;
						
                    }
                case 1:
                    {
						switch (select)
                        {
                            case 0://Nâng cấp btc2
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextMenuNCBT.Gi().MenuNangBongTai[3]));
                                    character.ShopId = 5;
									break;
                                }
                            case 1://Nâng cấp btc3
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextMenuNCBT.Gi().MenuNangBongTai[4]));
                                    character.ShopId = 6;
									break;
                                }
                            case 2://Nâng cấp btc4
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextMenuNCBT.Gi().MenuNangBongTai[5]));
                                    character.ShopId = 7;
									break;
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        switch (select)
                        {
                            case 0://Mở CS btc2
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextMenuNCBT.Gi().MenuNangBongTai[6]));
                                    character.ShopId = 8;
									break;
                                }
                            case 1://Mở CS btc3
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextMenuNCBT.Gi().MenuNangBongTai[7]));
                                    character.ShopId = 9;
									break;
                                }
                            case 2://Mở CS btc4
                                {
                                    character.CharacterHandler.SendMessage(Service.SendCombinne0(TextMenuNCBT.Gi().MenuNangBongTai[8]));
                                    character.ShopId = 10;
									break;
                                }
                        }
                        break;
                    }
				case 3://TypeMenu Nâng cấp bông tai c2
				{
					if (select != 0) return;
					
					var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var soNgocCanNangCap = listArray[2];
                    var soVangCanNangCap = listArray[3];
                    var percentSuccess = listArray[4];
                    var isThanhCong = false;
					
					//Kiểm tra vàng ngọc
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
					
					//Tỉ lệ
					var optionCheck = manhVoBongTai.Options.FirstOrDefault(option => option.Id == 31);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
					{
						if (optionCheck != null)
						{
							optionCheck.Param -= 99;
							if (optionCheck.Param <= 0)
                            {
                                character.CharacterHandler.RemoveItemBagByIndex(manhVoBongTai.IndexUI, 1, false, reason: "Nâng cấp Porata");
                            }
						}
						character.CharacterHandler.RemoveItemBagByIndex(bongTaiPorata.IndexUI, 1, false, reason: "Nâng cấp Porata");
                        var itemAdd = ItemCache.GetItemDefault(921);
						itemAdd.Quantity = 1;
						character.CharacterHandler.AddItemToBag(false, itemAdd, "Nâng cấp porata");
                        //character.CharacterHandler.SendMessage(Service.SendCombinne2());
                        character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
						isThanhCong = true;
					}
					else
					{
						if (optionCheck != null)
						{
							optionCheck.Param -= 49;
						}
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thất bại"));
						//character.CharacterHandler.SendMessage(Service.SendCombinne3());
					}
					
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var checkManhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var listIndexUi = new List<int>();
                    if (!isThanhCong)
					{
						if (checkManhVoBongTai != null && checkManhVoBongTai.Id == manhVoBongTai.Id)
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                            listIndexUi.Add(manhVoBongTai.IndexUI);
                        }
						else
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                        }
					}
					character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 4://TypeMenu Nâng cấp bông tai c3
				{
					if (select != 0) return;
					
					var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var soNgocCanNangCap = listArray[2];
                    var soVangCanNangCap = listArray[3];
                    var percentSuccess = listArray[4];
                    var isThanhCong = false;
					
					//Kiểm tra vàng ngọc
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
					
					//Tỉ lệ
					var optionCheck = manhVoBongTai.Options.FirstOrDefault(option => option.Id == 31);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
					{
						if (optionCheck != null)
						{
							optionCheck.Param -= 999;
							if (optionCheck.Param <= 0)
                            {
                                character.CharacterHandler.RemoveItemBagByIndex(manhVoBongTai.IndexUI, 1, false, reason: "Nâng cấp Porata3");
                            }
						}
						character.CharacterHandler.RemoveItemBagByIndex(bongTaiPorata.IndexUI, 1, false, reason: "Nâng cấp Porata3");
                        var itemAdd = ItemCache.GetItemDefault(1108);
						itemAdd.Quantity = 1;
						character.CharacterHandler.AddItemToBag(false, itemAdd, "Nâng cấp porata3");
                        //character.CharacterHandler.SendMessage(Service.SendCombinne2());
                        character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
						isThanhCong = true;
					}
					else
					{
						if (optionCheck != null)
						{
							optionCheck.Param -= 499;
						}
						//character.CharacterHandler.SendMessage(Service.SendCombinne3());
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thất bại"));
					}
					
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var checkManhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var listIndexUi = new List<int>();
                    if (!isThanhCong)
					{
						if (checkManhVoBongTai != null && checkManhVoBongTai.Id == manhVoBongTai.Id)
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                            listIndexUi.Add(manhVoBongTai.IndexUI);
                        }
						else
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                        }
					}
					character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				
				case 5://TypeMenu Nâng cấp bông tai c4
				{
					if (select != 0) return;
					
					var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var soNgocCanNangCap = listArray[2];
                    var soVangCanNangCap = listArray[3];
                    var percentSuccess = listArray[4];
                    var isThanhCong = false;
					
					//Kiểm tra vàng ngọc
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
					
					//Tỉ lệ
					var optionCheck = manhVoBongTai.Options.FirstOrDefault(option => option.Id == 31);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
					{
						if (optionCheck != null)
						{
							optionCheck.Param -= 9999;
							if (optionCheck.Param <= 0)
                            {
                                character.CharacterHandler.RemoveItemBagByIndex(manhVoBongTai.IndexUI, 1, false, reason: "Nâng cấp Porata4");
                            }
						}
						character.CharacterHandler.RemoveItemBagByIndex(bongTaiPorata.IndexUI, 1, false, reason: "Nâng cấp Porata4");
                        var itemAdd = ItemCache.GetItemDefault(1110);
						itemAdd.Quantity = 1;
						character.CharacterHandler.AddItemToBag(false, itemAdd, "Nâng cấp porata4");
                        //character.CharacterHandler.SendMessage(Service.SendCombinne2());
                        character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
						isThanhCong = true;
					}
					else
					{
						if (optionCheck != null)
						{
							optionCheck.Param -= 4999;
						}
						//character.CharacterHandler.SendMessage(Service.SendCombinne3());
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thất bại"));
					}
					
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
                    character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));

                    var checkManhVoBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var listIndexUi = new List<int>();
                    if (!isThanhCong)
					{
						if (checkManhVoBongTai != null && checkManhVoBongTai.Id == manhVoBongTai.Id)
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                            listIndexUi.Add(manhVoBongTai.IndexUI);
                        }
						else
                        {
                            listIndexUi.Add(bongTaiPorata.IndexUI);
                        }
					}
					character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 6://Typemenu mở chỉ số btc2
				{
					if (select != 0) return;
					var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhHonBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var daXanhLam = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
                    var soNgocCanNangCap = listArray[3];
                    var soVangCanNangCap = listArray[4];
                    var percentSuccess = listArray[5];
					
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
					character.CharacterHandler.RemoveItemBagByIndex(manhHonBongTai.IndexUI, 99, false, reason: "Mở chỉ số Porata2");
                    character.CharacterHandler.RemoveItemBagByIndex(daXanhLam.IndexUI, 1, false, reason: "Mở chỉ số Porata2");
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
					
					var optionCheck = bongTaiPorata.Options.FirstOrDefault(option => option.Id != 72);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
					{
						var optionRandom = NCBT.OptionPorata2[ServerUtils.RandomNumber(NCBT.OptionPorata2.Count)];
						if (optionCheck != null)
						{
							optionCheck.Id = optionRandom[0];
                            optionCheck.Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2]);
						}
						else
						{
							bongTaiPorata.Options.Add(new OptionItem()
                            {
                                Id = optionRandom[0],
                                Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2])
                            });
						}
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
					}
					else
					{
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thất bại"));
					}
					
					character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
					
					var checkbongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var listIndexUi = new List<int>();
                    if (checkbongTaiPorata != null && checkbongTaiPorata.Id == bongTaiPorata.Id)
                    {
                        listIndexUi.Add(bongTaiPorata.IndexUI);
                    }

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 7://Typemenu mở chỉ số btc3
				{
					if (select != 0) return;
					var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhHonBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var daXanhLam = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
                    var soNgocCanNangCap = listArray[3];
                    var soVangCanNangCap = listArray[4];
                    var percentSuccess = listArray[5];
					
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
					character.CharacterHandler.RemoveItemBagByIndex(manhHonBongTai.IndexUI, 199, false, reason: "Mở chỉ số Porata3");
                    character.CharacterHandler.RemoveItemBagByIndex(daXanhLam.IndexUI, 5, false, reason: "Mở chỉ số Porata3");
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
					
					var optionCheck = bongTaiPorata.Options.FirstOrDefault(option => option.Id != 72);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
					{
						var optionRandom = NCBT.OptionPorata2[ServerUtils.RandomNumber(NCBT.OptionPorata2.Count)];
						if (optionCheck != null)
						{
							optionCheck.Id = optionRandom[0];
                            optionCheck.Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2]);
						}
						else
						{
							bongTaiPorata.Options.Add(new OptionItem()
                            {
                                Id = optionRandom[0],
                                Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2])
                            });
						}
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
					}
					else
					{
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thất bại"));
					}
					
					character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
					
					var checkbongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var listIndexUi = new List<int>();
                    if (checkbongTaiPorata != null && checkbongTaiPorata.Id == bongTaiPorata.Id)
                    {
                        listIndexUi.Add(bongTaiPorata.IndexUI);
                    }

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
				case 8://Typemenu mở chỉ số btc4
				{
					if (select != 0) return;
					var listArray = character.CombinneIndex;
                    var bongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var manhHonBongTai = character.CharacterHandler.GetItemBagByIndex(listArray[1]);
                    var daXanhLam = character.CharacterHandler.GetItemBagByIndex(listArray[2]);
                    var soNgocCanNangCap = listArray[3];
                    var soVangCanNangCap = listArray[4];
                    var percentSuccess = listArray[5];
					
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
					character.CharacterHandler.RemoveItemBagByIndex(manhHonBongTai.IndexUI, 299, false, reason: "Mở chỉ số Porata4");
                    character.CharacterHandler.RemoveItemBagByIndex(daXanhLam.IndexUI, 10, false, reason: "Mở chỉ số Porata4");
					character.MineGold(soVangCanNangCap);
                    character.MineDiamond(soNgocCanNangCap);
					
					var optionCheck = bongTaiPorata.Options.FirstOrDefault(option => option.Id != 72);
                    var percentRandom = ServerUtils.RandomNumber(100) < percentSuccess;
                    if (percentRandom)
					{
						var optionRandom = NCBT.OptionPorata2[ServerUtils.RandomNumber(NCBT.OptionPorata2.Count)];
						if (optionCheck != null)
						{
							optionCheck.Id = optionRandom[0];
                            optionCheck.Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2]);
						}
						else
						{
							bongTaiPorata.Options.Add(new OptionItem()
                            {
                                Id = optionRandom[0],
                                Param = ServerUtils.RandomNumber(optionRandom[1], optionRandom[2])
                            });
						}
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thành công"));
					}
					else
					{
						character.CharacterHandler.SendMessage(Service.ServerMessage("Thất bại"));
					}
					
					character.CharacterHandler.SendMessage(Service.BuyItem(character));
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
					
					var checkbongTaiPorata = character.CharacterHandler.GetItemBagByIndex(listArray[0]);
                    var listIndexUi = new List<int>();
                    if (checkbongTaiPorata != null && checkbongTaiPorata.Id == bongTaiPorata.Id)
                    {
                        listIndexUi.Add(bongTaiPorata.IndexUI);
                    }

                    character.CharacterHandler.SendMessage(Service.SendCombinne1(listIndexUi));
                    character.CombinneIndex.Clear();
                    character.CombinneIndex = null;
                    break;
				}
            }
        }
    }
}