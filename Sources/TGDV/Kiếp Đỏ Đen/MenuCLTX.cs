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
using NRO_Server.TGDV.Kiếp_Đỏ_Đen;

namespace NRO_Server.TGDV.Kiếp_Đỏ_Đen
{
    public class MenuCLTX
    {
        private static MenuCLTX _instance;
        public MenuCLTX()
        {
        }
        public static MenuCLTX Gi()
        {
            if (_instance == null) _instance = new MenuCLTX();
            return _instance;
        }
		
        public void OpenMenuCLTX(NRO_Server.Model.Character.Character character, int npcId, int menu)
        {
            var now = ServerUtils.TimeNow().Hour;
			if (menu == 0)
			{
				if (now >= 19 && now <=22)
				{
					character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuCLTX.Gi().TextKiepDoDen[0], TextMenuCLTX.Gi().MenuKiepDoDen[0], character.InfoChar.Gender));
                    character.TypeMenu = 0;
				}
				else
				{
					character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuCLTX.Gi().TextKiepDoDen[0], TextMenuCLTX.Gi().MenuKiepDoDen[0], character.InfoChar.Gender));
                    character.TypeMenu = 0;
				}
			}
			if (menu == 1)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuCLTX.Gi().TextKiepDoDen[0], TextMenuCLTX.Gi().MenuKiepDoDen[2], character.InfoChar.Gender));
                character.TypeMenu = 1;
			}
			if (menu == 2)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiConfirm((short)npcId, TextMenuCLTX.Gi().TextKiepDoDen[0], TextMenuCLTX.Gi().MenuKiepDoDen[3], character.InfoChar.Gender));
                character.TypeMenu = 2;
			}
			if (menu == 3)
			{
				character.CharacterHandler.SendMessage(Service.OpenUiSay(5, TextMenuCLTX.Gi().TextKiepDoDen[2]));
			}
        }
        public void ConfirmMenuCLTX(NRO_Server.Model.Character.Character character, int npcId, int select)
        {
            switch (character.TypeMenu)
            {
                case 0:
                    {
                        switch (select)
						{
							case 0:
							{
								OpenMenuCLTX(character, npcId, 1);
                                break;
							}
							case 1:
							{
								OpenMenuCLTX(character, npcId, 2);
                                break;
							}
							case 2:
							{
								OpenMenuCLTX(character, npcId, 3);
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
                                    var inputTienCuocChan = new List<InputBox>();

                                    var tienCuocChan = new InputBox()
                                    {
                                        Name = "Thỏi vàng",
                                        Type = 1,
                                    };
                                    inputTienCuocChan.Add(tienCuocChan);
                                    character.CharacterHandler.SendMessage(Service.ShowInput("Đặt Chẵn", inputTienCuocChan));
                                    character.TypeInput = 6;
                                    break;
                                }
                            case 1:
                                {
                                    var inputTienCuocLe = new List<InputBox>();

                                    var tienCuocLe = new InputBox()
                                    {
                                        Name = "Thỏi vàng",
                                        Type = 1,
                                    };
                                    inputTienCuocLe.Add(tienCuocLe);
                                    character.CharacterHandler.SendMessage(Service.ShowInput("Đặt Lẻ", inputTienCuocLe));
                                    character.TypeInput = 7;
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
                                    var inputTienCuocTai = new List<InputBox>();

                                    var tienCuocTai = new InputBox()
                                    {
                                        Name = "Thỏi vàng",
                                        Type = 1,
                                    };
                                    inputTienCuocTai.Add(tienCuocTai);
                                    character.CharacterHandler.SendMessage(Service.ShowInput("Đặt Tài", inputTienCuocTai));
                                    character.TypeInput = 8;
                                    break;
                                }
                            case 1:
                                {
                                    var inputTienCuocXiu = new List<InputBox>();

                                    var tienCuocXiu = new InputBox()
                                    {
                                        Name = "Thỏi vàng",
                                        Type = 1,
                                    };
                                    inputTienCuocXiu.Add(tienCuocXiu);
                                    character.CharacterHandler.SendMessage(Service.ShowInput("Đặt Xỉu", inputTienCuocXiu));
                                    character.TypeInput = 9;
                                    break;
                                }
                        }
						break;
                    }
            }
        }
    }
}