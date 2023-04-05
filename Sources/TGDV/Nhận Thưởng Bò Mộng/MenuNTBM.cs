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
using NRO_Server.TGDV.Nhận_THưởng_Bò_Mộng;

namespace NRO_Server.TGDV.Nhận_THưởng_Bò_Mộng
{
	public class MenuNTBM
	{
		private static MenuNTBM _instance;
        public MenuNTBM()
        {
        }
        public static MenuNTBM Gi()
        {
            if (_instance == null) _instance = new MenuNTBM();
            return _instance;
        }
		
		public void OpenMenuNTBM(NRO_Server.Model.Character.Character character, int npcId, int menu)
        {
			if (menu == 0)
			{
                character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[0], TextNTBM.Gi().MenuNhanThuong[0], character.InfoChar.Gender));
                character.TypeMenu = 0;
            }
			if (menu == 1)
			{
                var inputGiftcode = new List<InputBox>();
				var inputCode = new InputBox()
				{
                    Name = "Nhập mã quà tặng",
                    Type = 1,
                };
				inputGiftcode.Add(inputCode);
                character.CharacterHandler.SendMessage(Service.ShowInput("Giftcode", inputGiftcode));
                character.TypeInput = 1;
            }
			if (menu == 2)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[1], TextNTBM.Gi().MenuNhanThuong[1], character.InfoChar.Gender));
                character.TypeMenu = 1;
			}
			if (menu == 3)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[2], TextNTBM.Gi().MenuNhanThuong[2], character.InfoChar.Gender));
                character.TypeMenu = 2;
			}
			if (menu == 4)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[1], TextNTBM.Gi().MenuNhanThuong[3], character.InfoChar.Gender));
                character.TypeMenu = 3;
			}
			if (menu == 5)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[3], TextNTBM.Gi().MenuNhanThuong[4], character.InfoChar.Gender));
                character.TypeMenu = 4;
			}
			if (menu == 6)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[4], TextNTBM.Gi().MenuNhanThuong[5], character.InfoChar.Gender));
                character.TypeMenu = 5;
			}
			if (menu == 7)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextNTBM.Gi().TextNhanThuong[5], TextNTBM.Gi().MenuNhanThuong[6], character.InfoChar.Gender));
                character.TypeMenu = 6;
			}

        }
		public void ConfirmMenuNTBM(NRO_Server.Model.Character.Character character, int npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
				{
					switch (select)
					{
						case 0://Menu giftcode
						{
							OpenMenuNTBM(character, npcId, 1);
							break;
						}
						case 1://Menu nhận thưởng
						{
							OpenMenuNTBM(character, npcId, 2);
							break;
						}
					}
					break;
				}
				case 1:
				{
					switch (select)
					{
						case 0://Sức mạnh
						{
							OpenMenuNTBM(character, npcId, 3);
							break;
						}
						case 1://Chỉ số
						{
							OpenMenuNTBM(character, npcId, 4);
							break;
						}
					}
					break;
				}
				case 2:
                    {
						switch (select)
						{
							case 0:
							{
								if (character.InfoChar.Power > 10000000 && character.InfoChar.DiemSucManh == 0)
								{
									var gift = ItemCache.GetItemDefault(457);
                                    gift.Quantity = 1;
                                    character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng sức mạnh");
                                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								    character.InfoChar.DiemSucManh +=1;
								    return;
								}
								else if (character.InfoChar.Power > 10000000 && character.InfoChar.DiemSucManh != 0)
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								    return;
							    }
							    else
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
                                    return;
							    }
							}
							case 1:
							{
								if (character.InfoChar.Power > 100000000 && character.InfoChar.DiemSucManh == 1)
								{
									var gift = ItemCache.GetItemDefault(457);
                                    gift.Quantity = 1;
                                    character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng sức mạnh");
                                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								    character.InfoChar.DiemSucManh +=1;
								    return;
								}
								else if (character.InfoChar.Power > 100000000 && character.InfoChar.DiemSucManh != 1)
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								    return;
							    }
							    else
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
                                    return;
							    }
							}
							case 2:
							{
								if (character.InfoChar.Power > 10000000000 && character.InfoChar.DiemSucManh == 2)
								{
									var gift = ItemCache.GetItemDefault(457);
                                    gift.Quantity = 1;
                                    character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng sức mạnh");
                                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								    character.InfoChar.DiemSucManh +=1;
								    return;
								}
								else if (character.InfoChar.Power > 10000000000 && character.InfoChar.DiemSucManh != 2)
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								    return;
							    }
							    else
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
                                    return;
							    }
							}
							case 3:
							{
								if (character.InfoChar.Power > 100000000000 && character.InfoChar.DiemSucManh == 3)
								{
									var gift = ItemCache.GetItemDefault(457);
                                    gift.Quantity = 1;
                                    character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng sức mạnh");
                                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                                    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								    character.InfoChar.DiemSucManh +=1;
								    return;
								}
								else if (character.InfoChar.Power > 100000000000 && character.InfoChar.DiemSucManh != 3)
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								    return;
							    }
							    else
							    {
								    character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
                                    return;
							    }
							}
						}
						break;
					}
				case 3:
				{
					switch (select)
					{
						case 0://Menu Sức đánh
						{
							OpenMenuNTBM(character, npcId, 5);
							break;
						}
						case 1://Menu Hp
						{
							OpenMenuNTBM(character, npcId, 6);
							break;
						}
						case 2://Menu Ki
						{
							OpenMenuNTBM(character, npcId, 7);
							break;
						}
					}
					break;
				}
				case 4://Sức đánh
				{
					switch (select)
					{
						case 0:
						{
							if (character.InfoChar.OriginalDamage >= 11000 && character.InfoChar.DiemChiSoSD == 0)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Sd");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoSD +=1;
								return;
							}
							else if(character.InfoChar.OriginalDamage >= 11000 && character.InfoChar.DiemChiSoSD != 0)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
						case 1:
						{
							if (character.InfoChar.OriginalDamage >= 24000 && character.InfoChar.DiemChiSoSD == 1)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Sd");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoSD +=1;
								return;
							}
							else if(character.InfoChar.OriginalDamage >= 24000 && character.InfoChar.DiemChiSoSD != 1)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
						case 2:
						{
							if (character.InfoChar.OriginalDamage >= 32000 && character.InfoChar.DiemChiSoSD == 2)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Sd");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoSD +=1;
								return;
							}
							else if(character.InfoChar.OriginalDamage >= 32000 && character.InfoChar.DiemChiSoSD != 2)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
					}
					break;
				}
				case 5://Hp
				{
					switch (select)
					{
						case 0:
						{
							if (character.InfoChar.OriginalHp >= 220000 && character.InfoChar.DiemChiSoHP == 0)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Hp");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoHP +=1;
								return;
							}
							else if(character.InfoChar.OriginalHp >= 220000 && character.InfoChar.DiemChiSoHP != 0)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
						case 1:
						{
							if (character.InfoChar.OriginalHp >= 500000 && character.InfoChar.DiemChiSoHP == 1)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Hp");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoHP +=1;
								return;
							}
							else if(character.InfoChar.OriginalHp >= 500000 && character.InfoChar.DiemChiSoHP != 1)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
						case 2:
						{
							if (character.InfoChar.OriginalHp >= 750000 && character.InfoChar.DiemChiSoHP == 2)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Hp");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoHP +=1;
								return;
							}
							else if(character.InfoChar.OriginalHp >= 750000 && character.InfoChar.DiemChiSoHP != 2)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
					}
					break;
				}
				case 6://Mp
				{
					switch (select)
					{
						case 0:
						{
							if (character.InfoChar.OriginalMp >= 220000 && character.InfoChar.DiemChiSoMP == 0)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Hp");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoMP +=1;
								return;
							}
							else if(character.InfoChar.OriginalMp >= 220000 && character.InfoChar.DiemChiSoMP != 0)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
						case 1:
						{
							if (character.InfoChar.OriginalMp >= 500000 && character.InfoChar.DiemChiSoMP == 1)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Hp");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoMP +=1;
								return;
							}
							else if(character.InfoChar.OriginalMp >= 500000 && character.InfoChar.DiemChiSoMP != 1)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
						case 2:
						{
							if (character.InfoChar.OriginalMp >= 750000 && character.InfoChar.DiemChiSoMP == 2)
							{
								var gift = ItemCache.GetItemDefault(457);
                                gift.Quantity = 1;
                                character.CharacterHandler.AddItemToBag(true, gift, "Nhận thưởng chỉ số Hp");
                                character.CharacterHandler.SendMessage(Service.SendBag(character));
                                character.CharacterHandler.SendMeMessage(Service.ServerMessage("Đã nhận phần thưởng, hãy kiểm tra trong túi đồ"));
								character.InfoChar.DiemChiSoMP +=1;
								return;
							}
							else if(character.InfoChar.OriginalMp >= 750000 && character.InfoChar.DiemChiSoMP != 2)
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi đã nhận phần thưởng này rồi"));
								return;
							}
							else
							{
								character.CharacterHandler.SendMeMessage(Service.ServerMessage("Ngươi chưa đạt điều kiện để nhận phần thưởng này"));
								return;
							}
						}
					}
					break;
				}
			}
		}
	}
}