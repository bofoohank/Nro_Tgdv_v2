﻿
/* 
*                                                          *****    ****    ****    *     *
*                                                            *     *        *   *   *     *
*                                                            *     *   **   *    *   *   *
*                                                            *     *    *   *   *     * *
*                                                            *      ****    ****       *
*/

using System;
using System.Linq;
using System.Collections.Generic;
using NRO_Server.Application.Constants;
using NRO_Server.Application.Interfaces.Character;
using NRO_Server.Application.IO;
using NRO_Server.Model.Item;
using NRO_Server.Model.Option;
using NRO_Server.Application.Main;
using NRO_Server.Application.Manager;

namespace NRO_Server.Application.Handlers.Item
{
    public static class LeaveItemHandler
    {
        #region Vàng
        public static ItemMap LeaveGold(int charId, int quantity)
        {
            if (ServerUtils.RandomNumber(100) > 25) return null;
            var item = ItemCache.GetItemDefault(76);
            switch (quantity)
            {
                case >= 350 and < 5500:
                    item = ItemCache.GetItemDefault(188);
                    break;
                case >= 5500 and < 15000:
                    item = ItemCache.GetItemDefault(189);
                    break;
                case > 15000:
                    item = ItemCache.GetItemDefault(190);
                    break;
            }

            item.Quantity = quantity;
            return new ItemMap(charId, item);
        }

        public static ItemMap LeaveGoldPlayer(int charId, int quantity)
        {
            if (quantity == 0) return null;
            var item = ItemCache.GetItemDefault(76);
            item.Quantity = quantity;
            return new ItemMap(charId, item);
        }
        #endregion

        #region Vật phẩm từ quái
        public static ItemMap LeaveMonsterItem(ICharacter character, int leaveItemType, int goldPlusPercent = 0, int mapId = 0, short monsterId = 0)
        {
            var charId = Math.Abs(character.Id);
            var percentSuccess = ServerUtils.RandomNumber(100);
			
			#region Vật phẩm rơi theo map
			switch (mapId)
			{
				case 155:
				{
					if (percentSuccess <= 60)
					{
						var item = ItemCache.GetItemDefault(1115);
                        item.Quantity = 1;
                        return new ItemMap(charId, item);
					}
					break;
				}
			}
			#endregion
			
			#region Vật phẩm nhiệm vụ
            switch (character.InfoChar.Task.Id)
            {
                case 2:
                    {
                        if (character.InfoChar.Task.Index == 0 && character.InfoChar.Task.Count < 10)
                        {
                            if (leaveItemType == 1 && percentSuccess <= 100)
                            {
                                var item = ItemCache.GetItemDefault(73);
                                item.Quantity = 1;
                                return new ItemMap(charId, item);
                            }
                        }
                        break;
                    }
                case 8:
                    {
                        if (character.InfoChar.Task.Index == 1)
                        {
                            if (percentSuccess <= 20)
                            {
                                if (monsterId == 10 || monsterId == 11 || monsterId == 12)
                                {
                                    var item = ItemCache.GetItemDefault(20);
                                    item.Quantity = 1;
                                    return new ItemMap(charId, item);
                                }
                            }
                        }
                        break;
                    }
                case 15:
                    {
                        if (character.InfoChar.Task.Index == 1)
                        {
                            if (percentSuccess <= 20)
                            {
                                if (monsterId == 13 || monsterId == 14 || monsterId == 15)
                                {
                                    var item = ItemCache.GetItemDefault(85);
                                    item.Quantity = 1;
                                    return new ItemMap(charId, item);
                                }
                            }
                        }
                        break;
                    }
                case 30:
                    {
                        if (character.InfoChar.Task.Index == 1)
                        {
                            if (percentSuccess <= 5)
                            {
                                if (leaveItemType == 8)
                                {
                                    var charReal = (Model.Character.Character)character;
                                    if (charReal.InfoBuff.MayDoCSKB)
                                    {
                                        var item_cskb = ItemCache.GetItemDefault(380);
                                        item_cskb.Quantity = 1;
                                        return new ItemMap(charId, item_cskb);
                                    }
                                }
                            }
                        }
                        break;
                    }
            }
            #endregion

            #region Vật phẩm sự kiện
            //8.3
            if (percentSuccess < 10)
            {
                var Item = ItemCache.GetItemDefault(723);
                Item.Options.Clear();
                return new ItemMap(charId, Item);

            }

            //Trung thu
            if (percentSuccess < 0)
            {
                if (DatabaseManager.Manager.gI().SuKienTrungThu && character.Id > 0)
                {
                    int rateNguyenLieu = ServerUtils.RandomNumber(100);
                    int rateDropNguyenLieu = 15;
                    if (character.ItemBody[5] != null && (character.ItemBody[5].Id == 463 || character.ItemBody[5].Id == 464))
                    {
                        rateDropNguyenLieu = 30;
                    }

                    if (character.Id > 0)
                    {
                        var charReal = (Model.Character.Character)character;
                        if (charReal.InfoBuff.CuCarot)
                        {
                            rateDropNguyenLieu += 5;
                        }
                    }

                    if (rateNguyenLieu < rateDropNguyenLieu)
                    {
                        var random = new Random();
                        int index = random.Next(DataCache.ListEventTrungThu.Count);
                        short iditem = DataCache.ListEventTrungThu[index];
                        var item = ItemCache.GetItemDefault(iditem);
                        item.Quantity = 1;
                        return new ItemMap(charId, item);
                    }
                }
                return null;
            }
            #endregion

            #region Ngọc rồng
            if (percentSuccess <= 20)
            {
                var item = ItemCache.GetItemDefault(20);
                var percentDragonBall = ServerUtils.RandomNumber(100);
                if (percentDragonBall <= 5)
                {
                    item = ItemCache.GetItemDefault(17);
                    item.Quantity = 1;
                }
                else if (percentDragonBall <= 10)
                {
                    item = ItemCache.GetItemDefault(18);
                    item.Quantity = 1;
                }
                else if (percentDragonBall <= 20)
                {
                    item = ItemCache.GetItemDefault(19);
                    item.Quantity = 1;
                }
                return new ItemMap(charId, item);
            }
            #endregion
            
            #region SKH
            if (percentSuccess <= 15)// 
            {
                var percentSKH = ServerUtils.RandomNumber(0.0, 100.0);
                if (percentSKH <= 60.0)
                {
                    return LeaveSKH(character, mapId, rare: 2);
                }
                else if (percentSKH <= 60.0)
                {
                    return LeaveSKH(character, mapId, rare: 3);
                }
                else if (percentSKH <= 60.0)
                {
                    return LeaveSKH(character, mapId, rare: 2);
                }
                else if (percentSKH <= 60.0)
                {
                    return LeaveSKH(character, mapId, rare: 3);
                }
            }
            #endregion
			
            #region Vật phẩm rơi theo leaveItemType của quái
            //Map cơ bản
            if (leaveItemType <= 4)
            {
                // 70% ra vàng ( 5-7-10-12k ),10% ra sao pha lê ,15% ra đá nâng cấp,10% ra ngọc rồng 7-5s
                var percentDrop = ServerUtils.RandomNumber(100);
                if (percentDrop > 50)
                {
                    return null;
                }
                var item = ItemCache.GetItemDefault(76);
                item.Quantity = 5000;
                if (goldPlusPercent > 0)
                {
                    item.Quantity += item.Quantity * goldPlusPercent / 100;
                }
                if (percentDrop <= 10)
                {
                    if (leaveItemType == 1)
                    {
                        item = ItemCache.GetItemDefault(188);
                        item.Quantity = 5000;
                    }
                    else if (leaveItemType == 2)
                    {
                        item = ItemCache.GetItemDefault(189);
                        item.Quantity = 7000;
                    }
                    else if (leaveItemType == 3)
                    {
                        item = ItemCache.GetItemDefault(189);
                        item.Quantity = 10000;
                    }
                    else if (leaveItemType == 4)
                    {
                        item = ItemCache.GetItemDefault(189);
                        item.Quantity = 12000;
                    }

                    if (goldPlusPercent > 0)
                    {
                        item.Quantity += item.Quantity * goldPlusPercent / 100;
                    }
                }
                // sao pha lê
                else if (percentDrop <= (20))
                {
                    var CaiTrangDSPL = character.ItemBody[5];
                    if (CaiTrangDSPL == null || CaiTrangDSPL?.Options?.FirstOrDefault(option => option.Id == 110) == null) return null;
                    var random = new Random();
                    int index = random.Next(DataCache.ListSaoPhaLe.Count);
                    short idSaoPhaLe = DataCache.ListSaoPhaLe[index];
                    item = ItemCache.GetItemDefault(idSaoPhaLe);
                    item.Quantity = 1;
                }
                else if (percentDrop <= (30))
                {
                    var randomTheSuuTam = ServerUtils.RandomNumber(20);
                    if (randomTheSuuTam <= 2)
                    {
                        if (monsterId == 1)
                        {
                            item = ItemCache.GetItemDefault(828);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 2)
                        {
                            item = ItemCache.GetItemDefault(829);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 3)
                        {
                            item = ItemCache.GetItemDefault(830);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 4)
                        {
                            item = ItemCache.GetItemDefault(831);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 5)
                        {
                            item = ItemCache.GetItemDefault(832);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 6)
                        {
                            item = ItemCache.GetItemDefault(833);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 7)
                        {
                            item = ItemCache.GetItemDefault(834);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 8)
                        {
                            item = ItemCache.GetItemDefault(835);
                            item.Quantity = 1;
                        }
                        else if (monsterId == 9)
                        {
                            item = ItemCache.GetItemDefault(836);
                            item.Quantity = 1;
                        }
                    }
                    else
                    {
                        var random = new Random();
                        int index = random.Next(DataCache.ListDaNangCap.Count);
                        short idDaNangCap = DataCache.ListDaNangCap[index];
                        item = ItemCache.GetItemDefault(idDaNangCap);
                        item.Quantity = 1;
                    }
                }
                else if (percentDrop <= (35))
                {
                    var percentDragonBall = ServerUtils.RandomNumber(100);
                    if (percentDragonBall <= 10)
                    {
                        item = ItemCache.GetItemDefault(18);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 20)
                    {
                        item = ItemCache.GetItemDefault(19);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 30)
                    {
                        item = ItemCache.GetItemDefault(20);
                        item.Quantity = 1;
                    }
                }
                return new ItemMap(charId, item);
            }
            //Tương lai
            else if (leaveItemType <= 9)
            {
                // 70% ra vàng ( 20k ),30% ra sao pha lê ,20% ra đá nâng cấp,15% ra ngọc rồng 7-5s,5% ngọc rồng 4s
                var percentDrop = ServerUtils.RandomNumber(140);

                if (percentDrop > 60)
                {
                    return null;
                }

                // Dò capsule
                if (ServerUtils.RandomNumber(100) <= (21 + leaveItemType) && character.Id > 0)
                {
                    var charReal = (Model.Character.Character)character;
                    if (charReal.InfoBuff.MayDoCSKB)
                    {
                        var item_cskb = ItemCache.GetItemDefault(380);
                        item_cskb.Quantity = 1;
                        return new ItemMap(charId, item_cskb);
                    }
                }

                var item = ItemCache.GetItemDefault(76);
                item.Quantity = 7000;
                if (goldPlusPercent > 0)
                {
                    item.Quantity += item.Quantity * goldPlusPercent / 100;
                }

                // thucan
                if (percentDrop <= 20)
                {
                    if (leaveItemType == 8)
                    {
                        item = ItemCache.GetItemDefault(190);
                        item.Quantity = 5000;
                    }
                    else if (leaveItemType == 9)
                    {
                        item = ItemCache.GetItemDefault(190);
                        item.Quantity = 5000;
                    }

                    if (goldPlusPercent > 0)
                    {
                        item.Quantity += item.Quantity * goldPlusPercent / 100;
                    }
                }

                else if (percentDrop <= 25)
                {
                    var percentDragonBall = ServerUtils.RandomNumber(100);
                    if (percentDragonBall <= 10)
                    {
                        item = ItemCache.GetItemDefault(18);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 20)
                    {
                        item = ItemCache.GetItemDefault(19);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 30)
                    {
                        item = ItemCache.GetItemDefault(20);
                        item.Quantity = 1;
                    }
                }
                return new ItemMap(charId, item);
            }
            //Cooler
            else if (leaveItemType == 10)
            {
	
				var IsMapCold = DataCache.IdMapCold.Contains(mapId);
                // 70% vàng ,30% sao pha lê , 20% đá nâng cấp,15'% ngọc rồng 7-4s,3% đồ thần linh ( các hành tinh),1% đồ hủy diệt
                var percentDrop = ServerUtils.RandomNumber(1, 200);
                var item = ItemCache.GetItemDefault(76);
                item.Quantity = 10000;
                if (goldPlusPercent > 0)
                {
                    item.Quantity += item.Quantity * goldPlusPercent / 100;
                }
                var IsMapThanhDia = DataCache.IdMapThanhDia.Contains(mapId);
                if (ServerUtils.RandomNumber(0.0, 500.0) < 0.1)
                {
                    if (!IsMapCold) return null;
                    var random = new Random();
                    int index = random.Next(DataCache.ListDoThanLinh.Count);
                    short idDoThanLinh = DataCache.ListDoThanLinh[index];
                    item = ItemCache.GetItemDefault(idDoThanLinh);
                    item.Quantity = 1;

                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat($"{character.Name} vừa đánh rơi {ItemCache.ItemTemplate(item.Id).Name} tại map {character.Zone.Map.TileMap.Name}"));
                }
                else if (percentDrop <= 30)
                {
                    var random = new Random();
                    if (ServerUtils.RandomNumber(100) <= 100 && character.Id > 0)
                    {
                        var charReal = (Model.Character.Character)character;
                        if (charReal.InfoSet.IsFullSetThanLinh)
                        {
                            int index = random.Next(DataCache.ListThucAn.Count);
                            short idThucHan = DataCache.ListThucAn[index];
                            item = ItemCache.GetItemDefault(idThucHan);
                            item.Quantity = 1;
                            item.Options.Add(new OptionItem()
                            {
                                Id = 30,
                                Param = 1
                            });
                        }
                    }
                    else
                    {
                        int index = random.Next(DataCache.ListDaNangCap.Count);
                        short idDaNangCap = DataCache.ListDaNangCap[index];
                        item = ItemCache.GetItemDefault(idDaNangCap);
                        item.Quantity = 1;
                    }
                }
                else if (percentDrop <= 35)
                {
                    var percentDragonBall = ServerUtils.RandomNumber(100);
                    if (percentDragonBall <= 5)
                    {
                        item = ItemCache.GetItemDefault(17);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 15)
                    {
                        item = ItemCache.GetItemDefault(18);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 20)
                    {
                        item = ItemCache.GetItemDefault(19);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 40)
                    {
                        item = ItemCache.GetItemDefault(20);
                        item.Quantity = 1;
                    }
                }
				
				
                return new ItemMap(charId, item);
            }
            // Thánh địa
            else if (leaveItemType == 11)
            {
				// 70% ra vàng ( 13-15-17k ),30% ra sao pha lê ,15% ra đá nâng cấp,10% ra ngọc rồng 7-5s,5% ngoc rồng 4s 
				var percentDrop = ServerUtils.RandomNumber(130);
                if (percentDrop > 60)
                {
                    return null;
                }
                var item = ItemCache.GetItemDefault(76);
                var IsMapThanhDia = DataCache.IdMapThanhDia.Contains(mapId);
                if (IsMapThanhDia && percentDrop <= 30)
                {
                    if (mapId == 156 || mapId == 157)
                    {
                        item = ItemCache.GetItemDefault(933);
                        item.Quantity = 1;
                    }
                    else
                    {
                        item = ItemCache.GetItemDefault(934);
                        item.Quantity = 1;
                    }
                    return new ItemMap(charId, item);
                }
                //Ngũ hành sơn
				else if (mapId == 123)
                {
                    var charReal = (Model.Character.Character)character;
                    if (charReal.InfoSet.IsFullSetHuyDiet)
                    {
                        var itemtype = ServerUtils.RandomNumber(0, 6);
                        if (percentDrop <= 2)
                        {
                            if (itemtype == 2 || itemtype == 4)
                            {
                                item = ItemCache.GetItemDefault(1066);
                                item.Quantity = 1;
                                return new ItemMap(charId, item);
                            }
                            else if (itemtype == 1)
                            {
                                item = ItemCache.GetItemDefault(1067);
                                item.Quantity = 1;
                                return new ItemMap(charId, item);
                            }
                            else if (itemtype == 6)
                            {
                                item = ItemCache.GetItemDefault(1068);
                                item.Quantity = 1;
                                return new ItemMap(charId, item);
                            }
                            else if (itemtype == 3)
                            {
                                item = ItemCache.GetItemDefault(1069);
                                item.Quantity = 1;
                                return new ItemMap(charId, item);
                            }
                            else if (itemtype == 5)
                            {
                                item = ItemCache.GetItemDefault(1070);
                                item.Quantity = 1;
                                return new ItemMap(charId, item);
                            }
                        }
                    }

                }

                if (percentDrop <= 40)
                {
                    if (leaveItemType == 5)
                    {
                        item = ItemCache.GetItemDefault(189);
                        item.Quantity = 7000;
                    }
                    else if (leaveItemType == 6)
                    {
                        item = ItemCache.GetItemDefault(189);
                        item.Quantity = 10000;
                    }
                    else if (leaveItemType == 7)
                    {
                        item = ItemCache.GetItemDefault(190);
                        item.Quantity = 13000;
                    }

                    if (goldPlusPercent > 0)
                    {
                        item.Quantity += item.Quantity * goldPlusPercent / 100;
                    }
                }
                else if (percentDrop <= (50) && !IsMapThanhDia)
                {
                    var CaiTrangDSPL = character.ItemBody[5];
                    if (CaiTrangDSPL == null || CaiTrangDSPL?.Options?.FirstOrDefault(option => option.Id == 110) == null) return null;
                    var random = new Random();
                    int index = random.Next(DataCache.ListSaoPhaLe.Count);
                    short idSaoPhaLe = DataCache.ListSaoPhaLe[index];
                    item = ItemCache.GetItemDefault(idSaoPhaLe);
                    item.Quantity = 1;
                }
                else if (percentDrop <= (60))
                {
                    var random = new Random();
                    int index = random.Next(DataCache.ListDaNangCap.Count);
                    short idDaNangCap = DataCache.ListDaNangCap[index];
                    item = ItemCache.GetItemDefault(idDaNangCap);
                    item.Quantity = 1;
                }
                else if (percentDrop <= (70))
                {
                    var percentDragonBall = ServerUtils.RandomNumber(100);
                    if (percentDragonBall <= 10)
                    {
                        item = ItemCache.GetItemDefault(18);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 20)
                    {
                        item = ItemCache.GetItemDefault(19);
                        item.Quantity = 1;
                    }
                    else if (percentDragonBall <= 30)
                    {
                        item = ItemCache.GetItemDefault(20);
                        item.Quantity = 1;
                    }
                }
                return new ItemMap(charId, item);
            }
            return null;
            #endregion
        }
        #endregion

        #region Rơi SKH
        public static ItemMap LeaveSKH(ICharacter character, int mapId = 0, sbyte rare = 0)
        {
            if (character.Id < 0) return null;
			if (character.InfoChar.Power > 10000000000) return null;
            if (mapId != 1 && mapId != 2 && mapId != 3 && mapId != 8 && mapId != 9
            && mapId != 15 && mapId != 16 && mapId != 17) return null;
            var gender = character.InfoChar.Gender;
            // TD hiếm Găng và RADAR 21,
            var listItem = new List<short>() { 0 };
            // Sôn gô ku hiếm 129
            var listSKH = new List<int>() { 127, 128 };

            switch (rare)
            {
                case 0: //độ hiếm thường
                    {
                        if (gender == 1)
                        {
                            // NM hiếm Giầy và Radar 28
                            listItem = new List<short>() { 0 };
                            // bộ picolo hiếm
                            listSKH = new List<int>() { 131, 132 };
                        }
                        else if (gender == 2)
                        {
                            //XD hiếm quần và Radar 8
                            listItem = new List<short>() { 0 };
                            // bộ nappa hiếm 135
                            listSKH = new List<int>() { 133, 134 };
                        }
                        break;
                    }
                case 1: //độ hiếm cơ bản
                    {
                        listItem = new List<short>() { 0, 6, 12, 21, 27 };
                        listSKH = new List<int>() { 127, 128 };

                        if (gender == 1)
                        {
                            listItem = new List<short>() { 1, 7, 12, 22, 28 };
                            listSKH = new List<int>() { 131, 132 };
                        }
                        else if (gender == 2)
                        {
                            listItem = new List<short>() { 2, 8, 12, 23, 29 };
                            listSKH = new List<int>() { 133, 134 };
                        }
                        break;
                    }
                case 2: //độ hiếm tốt
                    {
                        // TD hiếm Găng và RADAR
                        listItem = new List<short>() { 0, 6, 12, 21, 27 };
                        listSKH = new List<int>() { 127, 128, 129 };

                        if (gender == 1)
                        {
                            listItem = new List<short>() { 1, 7, 12, 22, 28 };
                            listSKH = new List<int>() { 130, 131, 132 };
                        }
                        else if (gender == 2)
                        {
                            listItem = new List<short>() { 2, 8, 12, 23, 29 };
                            listSKH = new List<int>() { 133, 134, 135 };
                        }
                        break;
                    }
                case 3: //độ hiếm cực
                    {
                        // TD hiếm Găng và RADAR
                        listItem = new List<short>() { 0 };
                        listSKH = new List<int>() { 127, 128, 129 };

                        if (gender == 1)
                        {
                            listItem = new List<short>() { 0 };
                            listSKH = new List<int>() { 130, 131, 132 };
                        }
                        else if (gender == 2)
                        {
                            listItem = new List<short>() { 0 };
                            listSKH = new List<int>() { 133, 134, 135 };
                        }
                        break;
                    }
            }


            var item = ItemCache.GetItemDefault(listItem[ServerUtils.RandomNumber(listItem.Count)]);
            item.Quantity = 1;
            var idSKH = listSKH[ServerUtils.RandomNumber(listSKH.Count)];
            item.Options.Add(new OptionItem()
            {
                Id = idSKH,
                Param = 0,
            });
            item.Options.Add(new OptionItem()
            {
                Id = GetSKHDescOption(idSKH),
                Param = 0,
            });
            item.Options.Add(new OptionItem()
            {
                Id = 30,
                Param = 0,
            });
            return new ItemMap(character.Id, item);
        }

        public static int GetSKHDescOption(int skhId)
        {
            switch (skhId)
            {
                case 127: return 139;
                case 128: return 140;
                case 129: return 141;
                case 130: return 142;
                case 131: return 143;
                case 132: return 144;
                case 133: return 136;
                case 134: return 137;
                case 135: return 138;
            }
            return 73;
        }
        #endregion
    }
}