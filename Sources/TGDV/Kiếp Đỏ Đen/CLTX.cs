using NRO_Server.Model.Character;
using System;
using System.Collections.Generic;
using NRO_Server.Main.Menu;
using NRO_Server.Application.Constants;
using NRO_Server.Application.IO;
using NRO_Server.Application.Main;
using NRO_Server.Application.Threading;
using NRO_Server.Application.Manager;
using NRO_Server.DatabaseManager;
using NRO_Server.DatabaseManager.Player;
using NRO_Server.Model.Template;
using NRO_Server.Model.Option;
using NRO_Server.Application.Map;
using System.Runtime.CompilerServices;
using System.Threading;
using NRO_Server.TGDV.Kiếp_Đỏ_Đen;

namespace NRO_Server.TGDV.Kiếp_Đỏ_Đen
{
    public static class CLTX
    {
        public static void HandleCuocChan(Character character, string soThoiVangInputC)
        {
            var soThoiVangC = Int32.Parse(soThoiVangInputC);
            var thoiVangC = ItemCache.GetItemDefault(457);
            var slotHanhTrangC = character.LengthBagNull();
            if (soThoiVangC < 1000 && soThoiVangC >= 10 && character.CharacterHandler.GetItemBagById(457) != null)
            {
                if (character.CharacterHandler.GetItemBagById(457).Quantity < soThoiVangC || soThoiVangC % 10 != 0 || character.CharacterHandler.GetItemBagById(457) == null)
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Thỏi Vàng\nHoặc Nhập sai giá trị"));
                    return;
                }
                if (soThoiVangC < character.CharacterHandler.GetItemBagById(457).Quantity)
                {
                    character.CharacterHandler.RemoveItemBagById(457, soThoiVangC, reason: "CLTX_Đặt chẵn");
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt Chẵn Thành Công"));
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Kết quả sẽ có sau 10 giây"));
                    int timeSeconds = 10;
                    while (timeSeconds > 0)
                    {
                        timeSeconds--;
                        Thread.Sleep(1000);
                    }
                    int so1 = ServerUtils.RandomNumber(1, 9);
                    int so2 = ServerUtils.RandomNumber(1, 9);
                    int so3 = ServerUtils.RandomNumber(1, 9);
                    int so4 = ServerUtils.RandomNumber(1, 9);
                    int tong = (so1 + so2 + so3 + so4);

                    if (tong % 2 != 0)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả : " + so1 + " " + so2 + " " + so3 + " " + so4
                                                    + " | Tổng là : " + tong
													+ " | Ra : Lẻ\n"
                                                    + "\nBạn đã cược : " + soThoiVangC + " Thỏi Vàng vào Chẵn\n" 
                                                    + "\nĐen lắm cu\n"));

                        return;
                    }
                    else if (tong % 2 == 0)
                    {

                        if (slotHanhTrangC < 3)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        thoiVangC.Quantity = (soThoiVangC * 2) - (soThoiVangC / 10);
                        character.CharacterHandler.AddItemToBag(true, thoiVangC, "CLTX_Nhận");
                        character.CharacterHandler.SendMessage(Service.SendBag(character));
                        character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, (soThoiVangC * 2) - (soThoiVangC / 10))));
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả là : " + so1 + " " + so2 + " " + so3 + " " + so4
                                                    + " | Tổng là : " + tong
													+ " | Ra : Chẵn\n"
                                                    + "\nBạn đã cược : " + soThoiVangC + " Thỏi Vàng vào Chẵn\n"
                                                    + "\nBạn nhận được :" + ((soThoiVangC * 2) - (soThoiVangC / 10)) + "Thỏi Vàng\n"
                                                    + "\nGhê ghê\n"));
                        return;
                    }
                }
                else
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Vàng\nHoặc Nhập sai giá trị"));
                }
                return;
            }
            character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt bé Hơn 1000Thỏi"));
        }

        public static void HandleCuocLe(Character character, string soThoiVangInputL)
        {
            var soThoiVangL = Int32.Parse(soThoiVangInputL);
            var thoiVangL = ItemCache.GetItemDefault(457);
            var slotHanhTrangL = character.LengthBagNull();
            if (soThoiVangL < 1000 && soThoiVangL >= 10 && character.CharacterHandler.GetItemBagById(457) != null)
            {
                if (character.CharacterHandler.GetItemBagById(457).Quantity < soThoiVangL || soThoiVangL % 10 != 0 || character.CharacterHandler.GetItemBagById(457) == null)
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Thỏi Vàng\nHoặc Nhập sai giá trị"));
                    return;
                }
                if (soThoiVangL < character.CharacterHandler.GetItemBagById(457).Quantity)
                {
                    character.CharacterHandler.RemoveItemBagById(457, soThoiVangL, reason: "CLTX_Đặt lẻ");
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt Lẻ Thành Công"));
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Kết quả sẽ có sau 10 giây"));
                    int timeSeconds = 10;
                    while (timeSeconds > 0)
                    {
                        timeSeconds--;
                        Thread.Sleep(1000);
                    }
                    int so1 = ServerUtils.RandomNumber(1, 9);
                    int so2 = ServerUtils.RandomNumber(1, 9);
                    int so3 = ServerUtils.RandomNumber(1, 9);
                    int so4 = ServerUtils.RandomNumber(1, 9);
                    int tong = (so1 + so2 + so3 + so4);

                    if (tong % 2 == 0)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả : " + so1 + " " + so2 + " " + so3 + " " + so4
                                                    + " | Tổng là : " + tong
													+ " | Ra : Chẵn\n"
                                                    + "\nBạn đã cược : " + soThoiVangL + " Thỏi Vàng vào Lẻ\n"
                                                    + "\nĐen lắm cu"));

                        return;
                    }
                    else if (tong % 2 != 0)
                    {

                        if (slotHanhTrangL < 3)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        thoiVangL.Quantity = (soThoiVangL * 2) - (soThoiVangL / 10);
                        character.CharacterHandler.AddItemToBag(true, thoiVangL, "CLTX_Nhận");
                        character.CharacterHandler.SendMessage(Service.SendBag(character));
                        character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, (soThoiVangL * 2) - (soThoiVangL / 10))));
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả là : " + so1 + " " + so2 + " " + so3 + " " + so4
                                                    + " | Tổng là : " + tong
													+ " | Ra : Lẻ\n"
                                                    + "\nBạn đã cược : " + soThoiVangL + " Thỏi Vàng vào Lẻ\n"
                                                    + "\nBạn nhận được :" + ((soThoiVangL * 2) - (soThoiVangL / 10)) + "Thỏi Vàng\n"
                                                    + "\nGhê ghê"));
                        return;
                    }
                }
                else
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Vàng\nHoặc Nhập sai giá trị"));
                }
                return;
            }
            character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt bé Hơn 1000Thỏi"));
        }

        public static void HandleCuocTai(Character character, string soThoiVangInputL)
        {
            var soThoiVangT = Int32.Parse(soThoiVangInputL);
            var thoiVangT = ItemCache.GetItemDefault(457);
            var slotHanhTrangT = character.LengthBagNull();
            if (soThoiVangT < 1000 && soThoiVangT >= 10 && character.CharacterHandler.GetItemBagById(457) != null)
            {
                if (character.CharacterHandler.GetItemBagById(457).Quantity < soThoiVangT || soThoiVangT % 10 != 0 || character.CharacterHandler.GetItemBagById(457) == null)
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Thỏi Vàng\nHoặc Nhập sai giá trị"));
                    return;
                }
                if (soThoiVangT < character.CharacterHandler.GetItemBagById(457).Quantity)
                {
                    character.CharacterHandler.RemoveItemBagById(457, soThoiVangT, reason: "CLTX_Đặt Tài");
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt Tài Thành Công"));
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Kết quả sẽ có sau 10 giây"));
                    int timeSeconds = 10;
                    while (timeSeconds > 0)
                    {
                        timeSeconds--;
                        Thread.Sleep(1000);
                    }
                    int so1 = ServerUtils.RandomNumber(1, 6);
                    int so2 = ServerUtils.RandomNumber(1, 6);
                    int so3 = ServerUtils.RandomNumber(1, 6);
					int tong = (so1 + so2 + so3);
					
					if (4 <= tong && tong <= 10)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả : " + so1 + " " + so2 + " " + so3
                                                    + " | Tổng là : " + tong
													+ " | Ra : Xỉu\n"
                                                    + "\nBạn đã cược : " + soThoiVangT + " Thỏi Vàng vào Tài\n"
                                                    + "\nĐen lắm cu"));
                        return;
                    }
					else if (so1 == so2 && so1 == so3)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả : " + so1 + " " + so2 + " " + so3
                                        + " | Tổng là : " + tong
										+ " | Ra : Tam hoa\n"
                                        + "\nBạn đã cược : " + soThoiVangT + " Thỏi Vàng vào Tài\n"
                                        + "\nĐen lắm cu"));
                        return;
                    }
                    else if (tong > 10)
                    {

                        if (slotHanhTrangT < 3)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        thoiVangT.Quantity = (soThoiVangT * 2) - (soThoiVangT / 10);
                        character.CharacterHandler.AddItemToBag(true, thoiVangT, "CLTX_Nhận");
                        character.CharacterHandler.SendMessage(Service.SendBag(character));
                        character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, (soThoiVangT * 2) - (soThoiVangT / 10))));
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả là : " + so1 + " " + so2 + " " + so3
                                                    + " | Tổng là : " + tong
													+ " | Ra : Tài\n"
                                                    + "\nBạn đã cược : " + soThoiVangT + " Thỏi Vàng vào Tài\n"
                                                    + "\nBạn nhận được :" + ((soThoiVangT * 2) - (soThoiVangT / 10)) + "Thỏi Vàng\n"
                                                    + "\nGhê ghê"));
                        return;
                    }
                }
                else
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Vàng\nHoặc Nhập sai giá trị"));
                }
                return;
            }
            character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt bé Hơn 1000Thỏi"));
        }
		
		public static void HandleCuocXiu(Character character, string soThoiVangInputX)
        {
            var soThoiVangX = Int32.Parse(soThoiVangInputX);
            var thoiVangX = ItemCache.GetItemDefault(457);
            var slotHanhTrangX = character.LengthBagNull();
            if (soThoiVangX < 1000 && soThoiVangX >= 10 && character.CharacterHandler.GetItemBagById(457) != null)
            {
                if (character.CharacterHandler.GetItemBagById(457).Quantity < soThoiVangX || soThoiVangX % 10 != 0 || character.CharacterHandler.GetItemBagById(457) == null)
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Thỏi Vàng\nHoặc Nhập sai giá trị"));
                    return;
                }
                if (soThoiVangX < character.CharacterHandler.GetItemBagById(457).Quantity)
                {
                    character.CharacterHandler.RemoveItemBagById(457, soThoiVangX, reason: "CLTX_Đặt Xỉu");
                    character.CharacterHandler.SendMessage(Service.SendBag(character));
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt Xỉu Thành Công"));
                    character.CharacterHandler.SendMessage(Service.ServerMessage("Kết quả sẽ có sau 10 giây"));
                    int timeSeconds = 10;
                    while (timeSeconds > 0)
                    {
                        timeSeconds--;
                        Thread.Sleep(1000);
                    }
                    int so1 = ServerUtils.RandomNumber(1, 6);
                    int so2 = ServerUtils.RandomNumber(1, 6);
                    int so3 = ServerUtils.RandomNumber(1, 6);
					int tong = (so1 + so2 + so3);
					
					if (4 > tong || tong > 10)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả: " + so1 + " " + so2 + " " + so3
                                                    + " | Tổng: " + tong
													+ " | Tài\n"
                                                    + "\nBạn đã cược : " + soThoiVangX + " Thỏi Vàng vào Xỉu\n"
                                                    + "\nĐen lắm cu"));
						return;
                    }
					else if (so1 == so2 && so1 == so3)
                    {
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả: " + so1 + " " + so2 + " " + so3
                                        + " | Tổng: " + tong
										+ " | Tam hoa\n"
                                        + "\nBạn đã cược: " + soThoiVangX + " Thỏi Vàng vào Xỉu\n"
                                        + "\nĐen lắm cu"));
                        return;
                    }
                    else if (tong <= 10 && tong >= 4)
                    {

                        if (slotHanhTrangX < 3)
                        {
                            character.CharacterHandler.SendMessage(Service.ServerMessage(TextServer.gI().NOT_ENOUGH_BAG));
                            return;
                        }
                        thoiVangX.Quantity = (soThoiVangX * 2) - (soThoiVangX / 10);
                        character.CharacterHandler.AddItemToBag(true, thoiVangX, "CLTX_Xỉu");
                        character.CharacterHandler.SendMessage(Service.SendBag(character));
                        character.CharacterHandler.SendMessage(Service.ServerMessage(string.Format(TextServer.gI().GET_GOLD_BAR, (soThoiVangX * 2) - (soThoiVangX / 10))));
                        character.CharacterHandler.SendMessage(Service.DialogMessage("Kết Quả: " + so1 + " " + so2 + " " + so3 
						                            + " | Tổng: " + tong
													+ " | Xỉu\n"
                                                    + "\nBạn đã cược: " + soThoiVangX + " Thỏi Vàng vào Xỉu\n"
                                                    + "\nBạn nhận được:" + ((soThoiVangX * 2) - (soThoiVangX / 10)) + "Thỏi Vàng\n"
                                                    + "\nGhê ghê"));
                        return;
                    }
                }
                else
                {
                    character.CharacterHandler.SendMessage(Service.DialogMessage("Không đủ Vàng\nHoặc Nhập sai giá trị"));
                }
                return;
            }
            character.CharacterHandler.SendMessage(Service.DialogMessage("Đặt bé Hơn 1000Thỏi"));
        }
	}
}
