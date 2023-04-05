
/* 
*                                                          *****    ****    ****    *     *
*                                                            *     *        *   *   *     *
*                                                            *     *   **   *    *   *   *
*                                                            *     *    *   *   *     * *
*                                                            *      ****    ****       *
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NRO_Server.Application.IO;
using NRO_Server.Application.Main;
using NRO_Server.Application.Manager;
using NRO_Server.Application.Constants;
using Org.BouncyCastle.Math.Field;
using NRO_Server.Model;
using NRO_Server.Model.Character;
using NRO_Server.DatabaseManager;
using System.Security.Cryptography;

namespace NRO_Server.Application.Threading
{
    public class BossRunTime
    {
        private static BossRunTime Instance { get; set; } = null;

        public static bool IsStop = false;

        #region Khai báo Boss

        #region Broly
        private static List<int> BrolyMaps = new List<int> { 5, 29, 13, 20, 36, 38, 33 };

        //Map, khu broly hiện tại
        private static int CurrentBrolyMapId = 0;
        private static int CurrentBrolyZoneId = 0;

        private static Boss Broly = null;
        private static Boss SuperBroly = null;

        private static bool IsBrolySpawn = false;
        private static bool IsBrolyNotify = false;
        private static int BrolyId = -1;
        private static long BrolySpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();

        private static bool IsSuperBrolySpawn = false;
        private static bool IsSuperBrolyNotify = false;
        private static int SuperBrolyId = -1;

        #endregion
		
		#region Boss nhiệm vụ
		//Kuku, Mập đầu đinh, Rambo
		private static List<int> KuKuMaps = new List<int> { 74,75,76,77 };
		
		private static Boss KuKu = null;
        private static Boss MDD = null;
		private static Boss RamBo = null;
		
		private static bool IsKuKuSpawn = false;
        private static bool IsKuKuNotify = false;
        private static int KuKuId = -1;
        private static long KuKuSpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();
		
		private static bool IsMDDSpawn = false;
        private static bool IsMDDNotify = false;
        private static int MDDId = -1;
        private static long MDDSpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();
		
		private static bool IsRamBoSpawn = false;
        private static bool IsRamBoNotify = false;
        private static int RamBoId = -1;
        private static long RamBoSpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();
		
		//Tiểu đội sát thủ
		private static List<int> So4Maps = new List<int> { 79, 82, 83 };
        private static Boss So4 = null;
        private static Boss So3 = null;
        private static Boss So2 = null;
        private static Boss So1 = null;
        private static Boss Tieudoitruong = null;
        private static bool IsSo4Spawn = false;
        private static int So4Id = -1;
        private static long TieudoisatthuSpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();
        private static bool IsSo3Spawn = false;
        private static int So3Id = -1;
        private static bool IsSo2Spawn = false;
        private static int So2Id = -1;
        private static bool IsSo1Spawn = false;
        private static int So1Id = -1;
        private static bool IsTieudoitruongSpawn = false;
        private static bool IsTieudoisatthuNotify = false;
        private static int TieudoitruongId = -1;
		
		//Fide 1 2 3
		private static List<int> FideMaps = new List<int> { 80 };
        private static int CurrentFideMapId = 0;
        private static int CurrentFideZoneId = 0;
        private static Boss fide01 = null;
        private static Boss fide02 = null;
        private static Boss fide03 = null;
        private static bool IsFide01Spawn = false;
        private static bool IsFide01Notify = false;
        private static int fide01Id = -1;
        private static long fide01SpawnTimeDelay = 70000 + ServerUtils.CurrentTimeMillis();
        private static bool IsFide02Spawn = false;
        private static bool IsFide02Notify = false;
        private static int fide02Id = -1;
        private static bool IsFide03Spawn = false;
        private static bool IsFide03Notify = false;
        private static int fide03Id = -1;
		
		//Androi 19 20 21
		private static List<int> android19Maps = new List<int> { 104 };
        private static int Currentandroid19MapId = 0;
        private static int Currentandroid19ZoneId = 0;
        private static Boss android19 = null;
        private static Boss android20 = null;
        private static bool Isandroid19Spawn = false;
        private static bool Isandroid19Notify = false;
        private static int android19Id = -1;
        private static long android19SpawnTimeDelay = 70000 + ServerUtils.CurrentTimeMillis();
        private static bool Isandroid20Spawn = false;
        private static bool Isandroid20Notify = false;
        private static int android20Id = -1;
		
		//Android13 14 15
		private static List<int> android15Maps = new List<int> { 104 };
        private static int Currentandroid15MapId = 0;
        private static int Currentandroid15ZoneId = 0;
        private static Boss android13 = null;
        private static Boss android14 = null;
        private static Boss android15 = null;
        private static bool Isandroid15Spawn = false;
        private static bool Isandroid15Notify = false;
        private static int android15Id = -1;
        private static long android15SpawnTimeDelay = 55000 + ServerUtils.CurrentTimeMillis();
        private static bool Isandroid14Spawn = false;
        private static bool Isandroid14Notify = false;
        private static int android14Id = -1;
        private static bool Isandroid13Spawn = false;
        private static bool Isandroid13Notify = false;
        private static int android13Id = -1;
		
		//Pic poc kingkong
		private static List<int> pocMaps = new List<int> { 97 };
        private static int CurrentpocMapId = 0;
        private static int CurrentpocZoneId = 0;
        private static Boss poc = null;
        private static Boss pic = null;
        private static Boss kinhkong = null;
        private static bool IspocSpawn = false;
        private static bool IspocNotify = false;
        private static int pocId = -1;
        private static long pocSpawnTimeDelay = 80000 + ServerUtils.CurrentTimeMillis();
        private static bool IspicSpawn = false;
        private static bool IspicNotify = false;
        private static int picId = -1;
        private static bool IskinhkongSpawn = false;
        private static bool IskinhkongNotify = false;
        private static int kinhkongId = -1;
		
		//Xên 1 2 3
		private static List<int> CellMaps = new List<int> { 99,100 };
        private static Boss cell01 = null;
        private static Boss cell02 = null;
        private static Boss cell03 = null;
        private static bool IsCell01Spawn = false;
        private static bool IsCell02Spawn = false;
        private static bool IsCell03Spawn = false;
        private static bool IsCellNotify = false;
        private static int cell01Id = -1;
        private static int cell02Id = -1;
        private static int cell03Id = -1;
        private static long cellSpawnTimeDelay = 75000 + ServerUtils.CurrentTimeMillis();
		
		//7 Xên con
		private static List<int> xenconMaps = new List<int> { 103 };
        private static Boss xen1 = null;
        private static Boss xen2 = null;
        private static Boss xen3 = null;
        private static Boss xen4 = null;
        private static Boss xen5 = null;
        private static Boss xen6 = null;
        private static Boss xen7 = null;

        private static bool Isxen1Spawn = false;
        private static int xen1Id = -1;
        private static long xenconSpawnTimeDelay = 800000 + ServerUtils.CurrentTimeMillis();
        private static bool Isxen2Spawn = false;
        private static int xen2Id = -1;
        private static bool Isxen3Spawn = false;
        private static int xen3Id = -1;
        private static bool Isxen4Spawn = false;
        private static int xen4Id = -1;
        private static bool Isxen5Spawn = false;
        private static bool IsxenconNotify = false;
        private static int xen5Id = -1;
        private static bool Isxen6Spawn = false;
        private static int xen6Id = -1;
        private static bool Isxen7Spawn = false;
        private static int xen7Id = -1;
		
		//Siêu bọ hung
		private static List<int> SBHMaps = new List<int> { 103 };
        private static Boss SBH = null;
        private static bool IsSBHSpawn = false;
        private static bool IsSBHNotify = false;
        private static int SBHId = -1;
        private static long SBHSpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();
		
		#endregion
		
		#region Cumber
        private static List<int> CumberMaps = new List<int> { 154 };

        //Map, khu broly hiện tại
        private static int CurrentCumberMapId = 0;
        private static int CurrentCumberZoneId = 0;

        private static Boss Cumber = null;
        private static Boss SuperCumber = null;

        private static bool IsCumberSpawn = false;
        private static bool IsCumberNotify = false;
        private static int CumberId = -1;
        private static long CumberSpawnTimeDelay = 60000 + ServerUtils.CurrentTimeMillis();

        private static bool IsSuperCumberSpawn = false;
        private static bool IsSuperCumberNotify = false;
        private static int SuperCumberId = -1;

        #endregion

        #endregion

        public static BossRunTime Gi()
        {
            return Instance ??= new BossRunTime();
        }

        public BossRunTime()
        {

        }

        #region Time spawn Boss
        public void BossDie(int bossId)
        {
            try
            {
                #region Broly
                if (bossId == BrolyId && IsBrolySpawn)
                {
                    Broly = null;
                    IsBrolySpawn = false;
                    BrolyId = -1;
                    BrolySpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                    if (!IsSuperBrolySpawn)
                    {
                        SpawnSuperBroly();
                    }
                }
                #endregion
				
				#region KuKu, MDD, RamBo
				else if (bossId == KuKuId && IsKuKuSpawn)
                {
                    KuKu = null;
                    IsKuKuSpawn = false;
                    KuKuId = -1;
                    KuKuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == MDDId && IsMDDSpawn)
                {
                    MDD = null;
                    IsMDDSpawn = false;
                    MDDId = -1;
                    MDDSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
				else if (bossId == RamBoId && IsRamBoSpawn)
                {
                    RamBo = null;
                    IsRamBoSpawn = false;
                    RamBoId = -1;
                    RamBoSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region TDST
				else if (bossId == So4Id && IsSo4Spawn)
                {
                    So4 = null;
                    IsSo4Spawn = false;
                    So4Id = -1;
                    TieudoisatthuSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == So3Id && IsSo3Spawn)
                {
                    So3 = null;
                    IsSo3Spawn = false;
                    So3Id = -1;
                    TieudoisatthuSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == So2Id && IsSo2Spawn)
                {
                    So2 = null;
                    IsSo2Spawn = false;
                    So2Id = -1;
                    TieudoisatthuSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == So1Id && IsSo1Spawn)
                {
                    So1 = null;
                    IsSo1Spawn = false;
                    So1Id = -1;
                    TieudoisatthuSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == TieudoitruongId && IsTieudoitruongSpawn)
                {
                    Tieudoitruong = null;
                    IsTieudoitruongSpawn = false;
                    TieudoitruongId = -1;
                    TieudoisatthuSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region Fide 1 2 3
				else if (bossId == fide01Id && IsFide01Spawn)
                {
                    fide01 = null;
                    IsFide01Spawn = false;
                    fide01Id = -1;
                    fide01SpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!IsFide02Spawn)
                    {
                        SpawnFideBoss(2);
                    }
                }
                else if (bossId == fide02Id && IsFide02Spawn)
                {
                    fide02 = null;
                    IsFide02Spawn = false;
                    fide02Id = -1;
                    fide01SpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!IsFide03Spawn)
                    {
                        SpawnFideBoss(3);
                    }
                }
                else if (bossId == fide03Id && IsFide03Spawn)
                {
                    fide03 = null;
                    IsFide03Spawn = false;
                    fide03Id = -1;
                    fide01SpawnTimeDelay = 200000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region Androi19 20 21
				else if (bossId == android19Id && Isandroid19Spawn)
                {
                    android19 = null;
                    Isandroid19Spawn = false;
                    android19Id = -1;
                    android19SpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!Isandroid20Spawn)
                    {
                        Spawnandroid19Boss(2);
                    }
                }
                else if (bossId == android20Id && Isandroid20Spawn)
                {
                    android20 = null;
                    Isandroid20Spawn = false;
                    android20Id = -1;
                    android19SpawnTimeDelay = 200000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region Android13 14 15
				else if (bossId == android15Id && Isandroid15Spawn)
                {
                    android15 = null;
                    Isandroid15Spawn = false;
                    android15Id = -1;
                    android15SpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!Isandroid14Spawn)
                    {
                        Spawnandroid15Boss(2);
                    }
                }
                else if (bossId == android14Id && Isandroid14Spawn)
                {
                    android14 = null;
                    Isandroid14Spawn = false;
                    android14Id = -1;
                    android15SpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!Isandroid13Spawn)
                    {
                        Spawnandroid15Boss(3);
                    }
                }
                else if (bossId == android13Id && Isandroid13Spawn)
                {
                    android13 = null;
                    Isandroid13Spawn = false;
                    android13Id = -1;
                    android15SpawnTimeDelay = 200000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region Pic Poc KK
				else if (bossId == picId && IspicSpawn)
                {
                    pic = null;
                    IspicSpawn = false;
                    picId = -1;
                    pocSpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!IspocSpawn)
                    {
                        Spawnpoc(2);
                    }
                }
                else if (bossId == pocId && IspocSpawn)
                {
                    poc = null;
                    IspocSpawn = false;
                    pocId = -1;
                    pocSpawnTimeDelay = 10 + ServerUtils.CurrentTimeMillis();
                    if (!IskinhkongSpawn)
                    {
                        Spawnpoc(3);
                    }
                }
                else if (bossId == kinhkongId && IskinhkongSpawn)
                {
                    kinhkong = null;
                    IskinhkongSpawn = false;
                    kinhkongId = -1;
                    pocSpawnTimeDelay = 200000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region Xên 1 2 3
				else if (bossId == cell01Id && IsCell01Spawn)
                {
                    cell01 = null;
                    IsCell01Spawn = false;
                    cell01Id = -1;
                    cellSpawnTimeDelay = 240000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == cell02Id && IsCell02Spawn)
                {
                    cell02 = null;
                    IsCell02Spawn = false;
                    cell02Id = -1;
                    cellSpawnTimeDelay = 240000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == cell03Id && IsCell03Spawn)
                {
                    cell03 = null;
                    IsCell03Spawn = false;
                    cell03Id = -1;
                    cellSpawnTimeDelay = 240000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region 7 xên con
				else if (bossId == xen1Id && Isxen1Spawn)
                {
                    xen1 = null;
                    Isxen1Spawn = false;
                    xen1Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == xen2Id && Isxen2Spawn)
                {
                    xen2 = null;
                    Isxen2Spawn = false;
                    xen2Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == xen3Id && Isxen3Spawn)
                {
                    xen3 = null;
                    Isxen3Spawn = false;
                    xen3Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == xen4Id && Isxen4Spawn)
                {
                    xen4 = null;
                    Isxen4Spawn = false;
                    xen4Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == xen5Id && Isxen5Spawn)
                {
                    xen5 = null;
                    Isxen5Spawn = false;
                    xen5Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();
                }
                else if (bossId == xen6Id && Isxen6Spawn)
                {
                    xen6 = null;
                    Isxen6Spawn = false;
                    xen6Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();

                }
                else if (bossId == xen7Id && Isxen7Spawn)
                {
                    xen7 = null;
                    Isxen7Spawn = false;
                    xen7Id = -1;
                    xenconSpawnTimeDelay = 160000 + ServerUtils.CurrentTimeMillis();
                }
				#endregion
				
				#region SBH
                if (bossId == SBHId && IsSBHSpawn)
                {
                    SBH = null;
                    IsSBHSpawn = false;
                    SBHId = -1;
                    SBHSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                }
                #endregion
				
				#region Cumber
                if (bossId == CumberId && IsCumberSpawn)
                {
                    Cumber = null;
                    IsCumberSpawn = false;
                    CumberId = -1;
                    CumberSpawnTimeDelay = 600000 + ServerUtils.CurrentTimeMillis();
                    if (!IsSuperCumberSpawn)
                    {
                        SpawnSuperCumber();
                    }
                }
                #endregion
				
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error BossDie in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }

        }
        #endregion

        public void StartBossRunTime()
        {
            new Thread(new ThreadStart(() =>
            {
                while (Server.Gi().IsRunning)
                {
                    var now = ServerUtils.TimeNow();
                    try
                    {
                        #region Broly
                        if (BrolySpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            BrolySpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsBrolySpawn && !IsSuperBrolySpawn)
                            {
                                IsBrolySpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(2, 19);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(BrolyMaps.Count);
                                int sbRandomMap = BrolyMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentBrolyMapId = sbRandomMap;
                                CurrentBrolyZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    Broly = new Boss();
                                    Broly.CreateBoss(DataCache.BOSS_BROLY_TYPE);
                                    Broly.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Broly);
                                    BrolyId = Broly.Id;
                                    IsBrolySpawn = true;
                                    IsBrolyNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Broly " + BrolyId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Broly xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!IsBrolyNotify && IsBrolySpawn && BrolyId != -1 && Broly != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Broly " + " vừa xuất hiện tại " + Broly.Zone.Map.TileMap.Name));
                                IsBrolyNotify = true;
                            }
							else if (!IsSuperBrolyNotify && IsSuperBrolySpawn && SuperBrolyId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Super Broly " + " vừa xuất hiện tại " + SuperBroly.Zone.Map.TileMap.Name));
                                IsSuperBrolyNotify = true;
                            }

                        }
                        else
                        {
                            IsBrolyNotify = false;
                            IsSuperBrolyNotify = false;
                        }
                        #endregion
						
						#region KuKu, MDD, RamBo
						if (KuKuSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
						{
							KuKuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
							if (!IsKuKuSpawn)
							{
								IsKuKuSpawn = true;
								int sbRandomZoneNum = ServerUtils.RandomNumber(3, 15);
								int sbRandomMapIndex = ServerUtils.RandomNumber(KuKuMaps.Count);
                                int sbRandomMap = KuKuMaps[sbRandomMapIndex];
								var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
								if (zone != null)
								{
									KuKu = new Boss();
									KuKu.CreateBoss(DataCache.BOSS_KUKU_TYPE);
									KuKu.CharacterHandler.SetUpInfo();
									zone.ZoneHandler.AddBoss(KuKu);
									KuKuId = KuKu.Id;
									IsKuKuSpawn = true;
									IsKuKuNotify = true;
									ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss KuKu " + KuKuId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
								    Server.Gi().Logger.Print($"KuKu xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
								}
							}
							else if (!IsKuKuNotify && KuKu != null && KuKuId != -1)
							{
								ClientManager.Gi().SendMessageCharacter(Service.ServerChat("KuKu " + " vừa xuất hiện tại " + KuKu.Zone.Map.TileMap.Name));
                                IsKuKuNotify = true;
							}
						}
						
						if (MDDSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
						{
							MDDSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
							if (!IsMDDSpawn)
							{
								IsMDDSpawn = true;
								int sbRandomZoneNum = ServerUtils.RandomNumber(3, 15);
								int sbRandomMapIndex = ServerUtils.RandomNumber(KuKuMaps.Count);
                                int sbRandomMap = KuKuMaps[sbRandomMapIndex];
								var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
								if (zone != null)
								{
									MDD = new Boss();
									MDD.CreateBoss(DataCache.BOSS_MDD_TYPE);
									MDD.CharacterHandler.SetUpInfo();
									zone.ZoneHandler.AddBoss(MDD);
									MDDId = MDD.Id;
									IsMDDSpawn = true;
									IsMDDNotify = true;
									ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Mập đầu đinh " + MDDId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
								    Server.Gi().Logger.Print($"Mập đầu đinh xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
								}
							}
							else if (!IsMDDNotify && MDD != null && MDDId != -1)
							{
								ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Mập đầu đinh " + " vừa xuất hiện tại " + MDD.Zone.Map.TileMap.Name));
                                IsMDDNotify = true;
							}
						}
						
						if (RamBoSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
						{
							RamBoSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
							if (!IsRamBoSpawn)
							{
								IsRamBoSpawn = true;
								int sbRandomZoneNum = ServerUtils.RandomNumber(3, 15);
								int sbRandomMapIndex = ServerUtils.RandomNumber(KuKuMaps.Count);
                                int sbRandomMap = KuKuMaps[sbRandomMapIndex];
								var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
								if (zone != null)
								{
									RamBo = new Boss();
									RamBo.CreateBoss(DataCache.BOSS_RAMBO_TYPE);
									RamBo.CharacterHandler.SetUpInfo();
									zone.ZoneHandler.AddBoss(RamBo);
									RamBoId = RamBo.Id;
									IsRamBoSpawn = true;
									IsRamBoNotify = true;
									ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Rambo " + RamBoId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
								    Server.Gi().Logger.Print($"Rambo xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
								}
							}
							else if (!IsRamBoNotify && RamBo != null && RamBoId != -1)
							{
								ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Rambo " + " vừa xuất hiện tại " + RamBo.Zone.Map.TileMap.Name));
                                IsRamBoNotify = true;
							}
						}
						#endregion
						
						#region TDST
                        if (TieudoisatthuSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            TieudoisatthuSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsSo4Spawn && !IsSo3Spawn && !IsSo2Spawn && !IsSo1Spawn && !IsTieudoitruongSpawn)
                            {

                                int sbRandomZoneNum = ServerUtils.RandomNumber(3, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(So4Maps.Count);
                                int sbRandomMap = So4Maps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    So4 = new Boss();
                                    So4.CreateBoss(DataCache.BOSS_SO4_TYPE);
                                    So4.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(So4);
                                    So4Id = So4.Id;

                                    So3 = new Boss();
                                    So3.CreateBoss(DataCache.BOSS_SO3_TYPE);
                                    So3.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(So3);
                                    So3Id = So3.Id;

                                    So2 = new Boss();
                                    So2.CreateBoss(DataCache.BOSS_SO2_TYPE);
                                    So2.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(So2);
                                    So2Id = So2.Id;

                                    So1 = new Boss();
                                    So1.CreateBoss(DataCache.BOSS_SO1_TYPE);
                                    So1.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(So1);
                                    So1Id = So1.Id;

                                    Tieudoitruong = new Boss();
                                    Tieudoitruong.CreateBoss(DataCache.BOSS_TDT_TYPE);
                                    Tieudoitruong.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Tieudoitruong);
                                    TieudoitruongId = Tieudoitruong.Id;

                                    IsSo4Spawn = true;
                                    IsSo3Spawn = true;
                                    IsSo2Spawn = true;
                                    IsSo1Spawn = true;
                                    IsTieudoitruongSpawn = true;
                                    IsTieudoisatthuNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss  Số 4 vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"TDST vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                                else if (!IsTieudoisatthuNotify)
                                {
                                    if (So4 != null && So4Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Số 4 vừa xuất hiện tại " + So4.Zone.Map.TileMap.Name));
                                    }
                                    else if (So3 != null && So3Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Số 3 vừa xuất hiện tại " + So3.Zone.Map.TileMap.Name));
                                    }
                                    else if (So2 != null && So2Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Số 2 vừa xuất hiện tại " + So2.Zone.Map.TileMap.Name));
                                    }
                                    else if (So1 != null && So1Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Số 1 vừa xuất hiện tại " + So1.Zone.Map.TileMap.Name));
                                    }
                                    else if (Tieudoitruong != null && TieudoitruongId != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Tiểu Đội Trưởng vừa xuất hiện tại " + Tieudoitruong.Zone.Map.TileMap.Name));
                                    }
                                    IsTieudoisatthuNotify = true;
                                }
                                // Get Random Map
                            }
                            else
                            {
                                IsTieudoisatthuNotify = false;
                            }
                        }
                        #endregion
						
						#region Fide 1 2 3
						if (fide01SpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            fide01SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsFide01Spawn && !IsFide02Spawn && !IsFide03Spawn)
                            {
                                IsFide01Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(0, 3);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(FideMaps.Count);
                                int sbRandomMap = FideMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentFideMapId = sbRandomMap;
                                CurrentFideZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    fide01 = new Boss();
                                    fide01.CreateBoss(DataCache.BOSS_FIDE_01_TYPE);
                                    fide01.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(fide01);
                                    fide01Id = fide01.Id;
                                    IsFide01Spawn = true;
                                    IsFide01Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Boss Fide 1 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Fide1 vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!IsFide01Notify && IsFide01Spawn && fide01Id != -1 && fide01 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Fide1 " + " vừa xuất hiện tại " + fide01.Zone.Map.TileMap.Name));
                                IsFide01Notify = true;
                            }
                            else if (!IsFide02Notify && IsFide02Spawn && fide02Id != -1 && fide02 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Fide2 " + " vừa xuất hiện tại " + fide02.Zone.Map.TileMap.Name));
                                IsFide02Notify = true;
                            }
                            else if (!IsFide03Notify && IsFide03Spawn && fide03Id != -1 && fide03 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Fide3 " + " vừa xuất hiện tại " + fide03.Zone.Map.TileMap.Name));
                                IsFide03Notify = true;
                            }
                        }

                        // Get Random Map

                        else
                        {
                            IsFide01Notify = false;
                            IsFide02Notify = false;
                            IsFide03Notify = false;
                        }
						#endregion
						
						#region Androi 19 20 21
                        if (android19SpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            android19SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!Isandroid19Spawn && !Isandroid20Spawn)
                            {
                                Isandroid19Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(3, 6);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(android19Maps.Count);
                                int sbRandomMap = android19Maps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                Currentandroid19MapId = sbRandomMap;
                                Currentandroid19ZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    android19 = new Boss();
                                    android19.CreateBoss(DataCache.BOSS_ANDROID_19_TYPE);
                                    android19.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(android19);
                                    android19Id = android19.Id;
                                    Isandroid19Spawn = true;
                                    Isandroid19Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android19 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Android19 vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!Isandroid19Notify && Isandroid19Spawn && android19Id != -1 && android19 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android19 " + " vừa xuất hiện tại " + android19.Zone.Map.TileMap.Name));
                                Isandroid19Notify = true;
                            }
                            else if (!Isandroid20Notify && Isandroid20Spawn && android20Id != -1 && android20 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android20 " + " vừa xuất hiện tại " + android20.Zone.Map.TileMap.Name));
                                Isandroid20Notify = true;
                            }
                        }

                        // Get Random Map

                        else
                        {
                            Isandroid19Notify = false;
                            Isandroid20Notify = false;
                        }
						#endregion
						
						#region Android13 14 15
						if (android15SpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            android15SpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!Isandroid13Spawn && !Isandroid14Spawn && !Isandroid15Spawn)
                            {
                                Isandroid15Spawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(7, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(android15Maps.Count);
                                int sbRandomMap = android15Maps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                Currentandroid15MapId = sbRandomMap;
                                Currentandroid15ZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    android15 = new Boss();
                                    android15.CreateBoss(DataCache.BOSS_ANDROID_15_TYPE);
                                    android15.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(android15);
                                    android15Id = android15.Id;
                                    Isandroid15Spawn = true;
                                    Isandroid15Notify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android15 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Android15 vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!Isandroid15Notify && Isandroid15Spawn && android15Id != -1 && android15 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android13 " + " vừa xuất hiện tại " + android15.Zone.Map.TileMap.Name));
                                Isandroid15Notify = true;
                            }
                            else if (!Isandroid14Notify && Isandroid14Spawn && android14Id != -1 && android14 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android14 " + " vừa xuất hiện tại " + android14.Zone.Map.TileMap.Name));
                                Isandroid14Notify = true;
                            }
                            else if (!Isandroid13Notify && Isandroid13Spawn && android13Id != -1 && android13 != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss Android13 " + " vừa xuất hiện tại " + android13.Zone.Map.TileMap.Name));
                                Isandroid13Notify = true;
                            }
                        }

                        // Get Random Map

                        else
                        {
                            Isandroid13Notify = false;
                            Isandroid14Notify = false;
                            Isandroid15Notify = false;
                        }
						#endregion
						
						#region Pic Poc KK
                        if (pocSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            pocSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IspocSpawn && !IspicSpawn && !IskinhkongSpawn)
                            {
                                IspicSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(3, 15);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(pocMaps.Count);
                                int sbRandomMap = pocMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentpocMapId = sbRandomMap;
                                CurrentpocZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    pic = new Boss();
                                    pic.CreateBoss(DataCache.BOSS_PIC_TYPE);
                                    pic.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(pic);
                                    picId = pic.Id;
                                    IspicSpawn = true;
                                    IspicNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss POC " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Poc Pic KingKong vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!IspocNotify && IspocSpawn && pocId != -1 && poc != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss POC " + " vừa xuất hiện tại " + poc.Zone.Map.TileMap.Name));
                                IspocNotify = true;
                            }
                            else if (!IspicNotify && IspicSpawn && picId != -1 && pic != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss PIC " + " vừa xuất hiện tại " + pic.Zone.Map.TileMap.Name));
                                IspicNotify = true;
                            }
                            else if (!IskinhkongNotify && IskinhkongSpawn && kinhkongId != -1 && kinhkong != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Boss KINH KONG " + " vừa xuất hiện tại " + kinhkong.Zone.Map.TileMap.Name));
                                IskinhkongNotify = true;
                            }
                        }

                        // Get Random Map

                        else
                        {
                            IspocNotify = false;
                            IspicNotify = false;
                            IskinhkongNotify = false;
                        }
                        #endregion
						
						#region Xên 1 2 3
						if (cellSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                            {
                                cellSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                                if (!IsCell01Spawn && !IsCell02Spawn && !IsCell03Spawn)
                                {

                                    int sbRandomZoneNum = ServerUtils.RandomNumber(0, 15);
                                    int sbRandomMapIndex = ServerUtils.RandomNumber(CellMaps.Count);
                                    int sbRandomMap = CellMaps[sbRandomMapIndex];
                                    var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                    if (zone != null)
                                    {
                                        cell01 = new Boss();
                                        cell01.CreateBoss(DataCache.BOSS_XEN_01_TYPE);
                                        cell01.CharacterHandler.SetUpInfo();
                                        zone.ZoneHandler.AddBoss(cell01);
                                        cell01Id = cell01.Id;

                                        cell02 = new Boss();
                                        cell02.CreateBoss(DataCache.BOSS_XEN_02_TYPE);
                                        cell02.CharacterHandler.SetUpInfo();
                                        zone.ZoneHandler.AddBoss(cell02);
                                        cell02Id = cell02.Id;

                                        cell03 = new Boss();
                                        cell03.CreateBoss(DataCache.BOSS_XEN_HT_TYPE);
                                        cell03.CharacterHandler.SetUpInfo();
                                        zone.ZoneHandler.AddBoss(cell03);
                                        cell03Id = cell03.Id;

                                        IsCell01Spawn = true;
                                        IsCell02Spawn = true;
                                        IsCell03Spawn = true;
                                        IsCellNotify = true;
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Bộ ba Xên Bọ Hung vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                        Server.Gi().Logger.Print($"Bộ ba Xên Bọ Hung vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                    }
                                }
                                else if (!IsCellNotify)
                                {
                                    if (cell01 != null && cell01Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Bộ ba Xên Bọ Hung vừa xuất hiện tại " + cell01.Zone.Map.TileMap.Name));
                                    }
                                    else if (cell02 != null && cell02Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Bộ ba Xên Bọ Hung vừa xuất hiện tại " + cell02.Zone.Map.TileMap.Name));
                                    }
                                    else if (cell03 != null && cell03Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Bộ ba Xên Bọ Hung vừa xuất hiện tại " + cell03.Zone.Map.TileMap.Name));
                                    }
                                    IsCellNotify = true;
                                }
                                // Get Random Map
                            }
                            else
                            {
                                IsCellNotify = false;
                            }
						#endregion
						
						#region 7 xên con
                        if (xenconSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                           xenconSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!Isxen1Spawn && !Isxen2Spawn && !Isxen3Spawn && !Isxen4Spawn && !Isxen5Spawn && !Isxen6Spawn && !Isxen7Spawn)
                            {

                                int sbRandomZoneNum = ServerUtils.RandomNumber(1, 3);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(xenconMaps.Count);
                                int sbRandomMap = xenconMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    xen1 = new Boss();
                                    xen1.CreateBoss(DataCache.BOSS_XEN_CON_01_TYPE);
                                    xen1.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen1);
                                    xen1Id = xen1.Id;

                                    xen2 = new Boss();
                                    xen2.CreateBoss(DataCache.BOSS_XEN_CON_02_TYPE);
                                    xen2.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen2);
                                    xen2Id = xen2.Id;

                                    xen3 = new Boss();
                                    xen3.CreateBoss(DataCache.BOSS_XEN_CON_03_TYPE);
                                    xen3.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen3);
                                    xen3Id = xen3.Id;

                                    xen4 = new Boss();
                                    xen4.CreateBoss(DataCache.BOSS_XEN_CON_04_TYPE);
                                    xen4.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen4);
                                    xen4Id = xen4.Id;

                                    xen5 = new Boss();
                                    xen5.CreateBoss(DataCache.BOSS_XEN_CON_05_TYPE);
                                    xen5.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen5);
                                    xen5Id = xen5.Id;
                                    
                                    xen6 = new Boss();
                                    xen6.CreateBoss(DataCache.BOSS_XEN_CON_06_TYPE);
                                    xen6.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen6);
                                    xen6Id = xen6.Id;
                                    
                                    xen7 = new Boss();
                                    xen7.CreateBoss(DataCache.BOSS_XEN_CON_07_TYPE);
                                    xen5.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(xen7);
                                    xen7Id = xen7.Id;

                                    Isxen1Spawn = true;
                                    Isxen2Spawn = true;
                                    Isxen3Spawn = true;
                                    Isxen4Spawn = true;
                                    Isxen5Spawn = true;
                                    Isxen6Spawn = true;
                                    Isxen7Spawn = true;
                                    IsxenconNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Boss 7 đứa con của xên vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"7 Xên con vừa xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                                else if (!IsxenconNotify)
                                {
                                    if (xen1 != null && xen1Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen1.Zone.Map.TileMap.Name));
                                    }
                                    else if (xen2 != null && xen2Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen2.Zone.Map.TileMap.Name));
                                    }
                                    else if (xen3 != null && xen3Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen3.Zone.Map.TileMap.Name));
                                    }
                                    else if (xen4 != null && xen4Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen4.Zone.Map.TileMap.Name));
                                    }
                                    else if (xen5 != null && xen5Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen5.Zone.Map.TileMap.Name));
                                    }
                                    else if (xen6 != null && xen6Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen6.Zone.Map.TileMap.Name));
                                    }
                                    else if (xen7 != null && xen7Id != -1)
                                    {
                                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("  Xên con vừa xuất hiện tại " + xen7.Zone.Map.TileMap.Name));
                                    }
                                    IsxenconNotify = true;
                                }
                                // Get Random Map
                            }
                            else
                            {
                                IsxenconNotify = false;
                            }
                        }
                        #endregion
						
						#region SBH
                        if (SBHSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            SBHSpawnTimeDelay = 300000 + ServerUtils.CurrentTimeMillis();
                            if (!IsSBHSpawn)
                            {
                                IsSBHSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(2, 13);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(SBHMaps.Count);
                                int sbRandomMap = SBHMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                if (zone != null)
                                {
                                    SBH = new Boss();
                                    SBH.CreateBoss(DataCache.BOSS_SBH_TYPE);
                                    SBH.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(SBH);
                                    SBHId = SBH.Id;
                                    IsSBHSpawn = true;
                                    IsSBHNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Siêu bọ hung " + BrolyId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Siêu bọ hung xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!IsSBHNotify && IsSBHSpawn && SBHId != -1 && SBH != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Siêu bọ hung " + " vừa xuất hiện tại " + SBH.Zone.Map.TileMap.Name));
                                IsSBHNotify = true;
                            }
                        }
                        else
                        {
                            IsSBHNotify = false;
                        }
                        #endregion
						
						#region Cumber
                        if (CumberSpawnTimeDelay < ServerUtils.CurrentTimeMillis())
                        {
                            CumberSpawnTimeDelay = 600000 + ServerUtils.CurrentTimeMillis();
                            if (!IsCumberSpawn && !IsSuperCumberSpawn)
                            {
                                IsCumberSpawn = true;
                                int sbRandomZoneNum = ServerUtils.RandomNumber(2, 10);
                                int sbRandomMapIndex = ServerUtils.RandomNumber(CumberMaps.Count);
                                int sbRandomMap = CumberMaps[sbRandomMapIndex];
                                var zone = MapManager.Get(sbRandomMap)?.GetZoneById(sbRandomZoneNum);
                                CurrentCumberMapId = sbRandomMap;
                                CurrentCumberZoneId = sbRandomZoneNum;
                                if (zone != null)
                                {
                                    Cumber = new Boss();
                                    Cumber.CreateBoss(DataCache.BOSS_CUMBER_TYPE);
                                    Cumber.CharacterHandler.SetUpInfo();
                                    zone.ZoneHandler.AddBoss(Cumber);
                                    CumberId = Cumber.Id;
                                    IsCumberSpawn = true;
                                    IsCumberNotify = true;
                                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Cumber " + BrolyId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                                    Server.Gi().Logger.Print($"Cumber xuất hiện tại :{zone.Map.TileMap.Name} {sbRandomMap} | khu {sbRandomZoneNum}");
                                }
                            }
                            else if (!IsCumberNotify && IsCumberSpawn && CumberId != -1 && Cumber != null)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Cumber " + " vừa xuất hiện tại " + Cumber.Zone.Map.TileMap.Name));
                                IsCumberNotify = true;
                            }
							else if (!IsSuperCumberNotify && IsSuperCumberSpawn && SuperCumberId != -1)
                            {
                                ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Super Cumber " + " vừa xuất hiện tại " + SuperCumber.Zone.Map.TileMap.Name));
                                IsSuperCumberNotify = true;
                            }
                        }
                        else
                        {
                            IsCumberNotify = false;
                            IsSuperCumberNotify = false;
                        }
                        #endregion
						
                    }
                    catch (Exception e)
                    {
                        Server.Gi().Logger.Error($"Error StartBossRunTime in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
                    }
                    Thread.Sleep(1000);
                }
                Server.Gi().Logger.Print("Boss Runtime is close Success...");
                IsStop = true;
            })).Start();
        }

        public void SpawnSuperBroly()
        {
            try
            {
                IsSuperBrolySpawn = true;
                var zone = MapManager.Get(CurrentBrolyMapId)?.GetZoneById(CurrentBrolyZoneId);
                if (zone != null)
                {
                    SuperBroly = new Boss();
                    SuperBroly.CreateBoss(DataCache.BOSS_SUPER_BROLY_TYPE);
                    SuperBroly.CharacterHandler.SetUpInfo();
                    zone.ZoneHandler.AddBoss(SuperBroly);
                    SuperBrolyId = SuperBroly.Id;
                    IsSuperBrolyNotify = true;
                    IsSuperBrolySpawn = true;
                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Super Broly " + SuperBrolyId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                    Server.Gi().Logger.Print($"Super Broly xuất hiện tại :{zone.Map.TileMap.Name}");
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnFideBoss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
		
		public void SpawnFideBoss(int type)
        {
            try
            {
                if (type == 2)
                {
                    IsFide02Spawn = true;
                    var zone = MapManager.Get(CurrentFideMapId)?.GetZoneById(CurrentFideZoneId);
                    if (zone != null)
                    {
                        fide02 = new Boss();
                        fide02.CreateBoss(DataCache.BOSS_FIDE_02_TYPE);
                        fide02.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(fide02);
                        fide02Id = fide02.Id;
                        IsFide02Notify = true;
                        IsFide02Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Fide 2 "  + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"Fide2 xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
                else
                {
                    IsFide03Spawn = true;
                    var zone = MapManager.Get(CurrentFideMapId)?.GetZoneById(CurrentFideZoneId);
                    if (zone != null)
                    {
                        fide03 = new Boss();
                        fide03.CreateBoss(DataCache.BOSS_FIDE_03_TYPE);
                        fide03.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(fide03);
                        fide03Id = fide03.Id;
                        IsFide03Notify = true;
                        IsFide03Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Fide 3 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"Fide3 xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnFideBoss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
		
		public void Spawnandroid19Boss(int type)
        {
            try
            {
                if (type == 2)
                {
                    Isandroid20Spawn = true;
                    var zone = MapManager.Get(Currentandroid19MapId)?.GetZoneById(Currentandroid19ZoneId);
                    if (zone != null)
                    {
                        android20 = new Boss();
                        android20.CreateBoss(DataCache.BOSS_ANDROID_20_TYPE);
                        android20.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(android20);
                        android20Id = android20.Id;
                        Isandroid20Notify = true;
                        Isandroid20Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Android20 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"Android20 xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error Spawnandroid19Boss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
		
		public void Spawnandroid15Boss(int type)
        {
            try
            {
                if (type == 2)
                {
                    Isandroid14Spawn = true;
                    var zone = MapManager.Get(Currentandroid15MapId)?.GetZoneById(Currentandroid15ZoneId);
                    if (zone != null)
                    {
                        android14 = new Boss();
                        android14.CreateBoss(DataCache.BOSS_ANDROID_14_TYPE);
                        android14.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(android14);
                        android14Id = android14.Id;
                        Isandroid14Notify = true;
                        Isandroid14Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Android14 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"Android14 xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
                else
                {
                    Isandroid13Spawn = true;
                    var zone = MapManager.Get(Currentandroid15MapId)?.GetZoneById(Currentandroid15ZoneId);
                    if (zone != null)
                    {
                        android13 = new Boss();
                        android13.CreateBoss(DataCache.BOSS_ANDROID_13_TYPE);
                        android13.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(android13);
                        android13Id = android13.Id;
                        Isandroid13Notify = true;
                        Isandroid13Spawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" Android13 " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"Android13 xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error Spawnandroid13Boss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
		
		public void Spawnpoc(int type)
        {
            try
            {
                if (type == 2)
                {
                    IspocSpawn = true;
                    var zone = MapManager.Get(CurrentpocMapId)?.GetZoneById(CurrentpocZoneId);
                    if (zone != null)
                    {
                        poc = new Boss();
                        poc.CreateBoss(DataCache.BOSS_POC_TYPE);
                        poc.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(poc);
                        pocId = poc.Id;
                        IspocNotify = true;
                        IspocSpawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat(" PIC " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"Pic xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
                else
                {
                    IskinhkongSpawn = true;
                    var zone = MapManager.Get(CurrentpocMapId)?.GetZoneById(CurrentpocZoneId);
                    if (zone != null)
                    {
                        kinhkong = new Boss();
                        kinhkong.CreateBoss(DataCache.BOSS_KINGKONG_TYPE);
                        kinhkong.CharacterHandler.SetUpInfo();
                        zone.ZoneHandler.AddBoss(kinhkong);
                        kinhkongId = kinhkong.Id;
                        IskinhkongNotify = true;
                        IskinhkongSpawn = true;
                        ClientManager.Gi().SendMessageCharacter(Service.ServerChat("KINH KONG " + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                        Server.Gi().Logger.Print($"KingKong xuất hiện tại :{zone.Map.TileMap.Name}");
                    }
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnpocBoss in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
		
		public void SpawnSuperCumber()
        {
            try
            {
                IsSuperCumberSpawn = true;
                var zone = MapManager.Get(CurrentCumberMapId)?.GetZoneById(CurrentCumberZoneId);
                if (zone != null)
                {
                    SuperCumber = new Boss();
                    SuperCumber.CreateBoss(DataCache.BOSS_SUPER_CUMBER_TYPE);
                    SuperCumber.CharacterHandler.SetUpInfo();
                    zone.ZoneHandler.AddBoss(SuperCumber);
                    SuperCumberId = SuperCumber.Id;
                    IsSuperCumberNotify = true;
                    IsSuperCumberSpawn = true;
                    ClientManager.Gi().SendMessageCharacter(Service.ServerChat("Super Cumber " + SuperCumberId + " vừa xuất hiện tại " + zone.Map.TileMap.Name));
                    Server.Gi().Logger.Print($"Super Cumber xuất hiện tại :{zone.Map.TileMap.Name}");
                }
            }
            catch (Exception e)
            {
                Server.Gi().Logger.Error($"Error SpawnCumber in BossRunTime.cs: {e.Message} \n {e.StackTrace}", e);
            }
        }
    }
}