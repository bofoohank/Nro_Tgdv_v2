
/* 
*                                                          *****    ****    ****    *     *
*                                                            *     *        *   *   *     *
*                                                            *     *   **   *    *   *   *
*                                                            *     *    *   *   *     * *
*                                                            *      ****    ****       *
*/

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections.Generic;
using NRO_Server.Main.Menu;
using NRO_Server.Application.Constants;
using NRO_Server.Application.IO;
using NRO_Server.Application.Main;
using NRO_Server.Application.Threading;
using NRO_Server.DatabaseManager;
using NRO_Server.DatabaseManager.Player;
using NRO_Server.Model.Option;
using NRO_Server.Model.Template;
using NRO_Server.Model.Character;
using Newtonsoft.Json;
using MySqlX.XDevAPI;

namespace NRO_Server.Application.Handlers.Client
{
    public static class Giftcode
    {
        public static void HandleUseGiftcode(Model.Character.Character character, string code)
        {
            var timeServer = ServerUtils.CurrentTimeMillis();
            if (character.Delay.UseGiftCode > timeServer)
            {
                var delay = (character.Delay.UseGiftCode - timeServer) / 1000;
                if (delay < 1)
                {
                    delay = 1;
                }

                character.CharacterHandler.SendMessage(Service.DialogMessage(string.Format(TextServer.gI().DELAY_SEC,
                        delay)));
                return;
            }
            // kiểm tra hạn gift code
            // kiểm tra đã dùng gift code chưa
            var codeType = GiftcodeDB.CheckCodeValidType(code);
            if (codeType == -1)
            {
                character.Delay.UseGiftCode = timeServer + 30000;
                character.CharacterHandler.SendMessage(Service.DialogMessage("Giftcode đã hết hạn hoặc hết lượt sử dụng."));
                return;
            }

            var isUsedThisCode = GiftcodeDB.CheckCharacterAlreadyUsedCode(code, character.Name, codeType);

            if (isUsedThisCode)
            {
                character.Delay.UseGiftCode = timeServer + 30000;
                character.CharacterHandler.SendMessage(Service.DialogMessage("Bạn đã dùng Giftcode này rồi."));
                return;
            }
            // Sử dụng gift code
            character.Delay.UseGiftCode = timeServer + 30000;
            UseCode(character, code, codeType);

        }

        private static void UseCode(Model.Character.Character character, string code, int codeType)
        {
            if (codeType == 0)//code test
            {
                if (character.LengthBagNull() < 1)
                {
                    character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().NOT_ENOUGH_BAG + "\n cần 1 chỗ để chứa vật phẩm")));
                    return;
                }
                var thoivang = ItemCache.GetItemDefault((short)457);
                thoivang.Quantity = 10000;
                character.CharacterHandler.AddItemToBag(true, thoivang, "Giftcode");

                character.CharacterHandler.SendMessage(Service.SendBag(character));
                character.CharacterHandler.SendMessage(Service.DialogMessage("Nhận Giftcode thành công."));
            }

            else if (codeType == 1)//code 10 bộ nr
            {
                if (character.LengthBagNull() < 7)
                {
                    character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().NOT_ENOUGH_BAG + "\n cần 7 chỗ để chứa vật phẩm")));
                    return;
                }

                var nro1s = ItemCache.GetItemDefault((short)14);
                nro1s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro1s, "Giftcode:tgdvx10nr");

                var nro2s = ItemCache.GetItemDefault((short)15);
                nro2s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro2s, "Giftcode:tgdvx10nr");

                var nro3s = ItemCache.GetItemDefault((short)16);
                nro3s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro3s, "Giftcode:tgdvx10nr");

                var nro4s = ItemCache.GetItemDefault((short)17);
                nro4s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro4s, "Giftcode:tgdvx10nr");

                var nro5s = ItemCache.GetItemDefault((short)18);
                nro5s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro5s, "Giftcode:tgdvx10nr");

                var nro6s = ItemCache.GetItemDefault((short)19);
                nro6s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro6s, "Giftcode:tgdvx10nr");

                var nro7s = ItemCache.GetItemDefault((short)20);
                nro7s.Quantity = 10;
                character.CharacterHandler.AddItemToBag(true, nro7s, "Giftcode:tgdvx10nr");

                character.CharacterHandler.SendMessage(Service.SendBag(character));
                character.CharacterHandler.SendMessage(Service.MeLoadInfo(character));
                character.CharacterHandler.SendMessage(Service.DialogMessage("Nhận Giftcode thành công."));
            }

            GiftcodeDB.UsedCode(code, character.Name, codeType);
        }
    }
}