
/* 
*                                                          *****    ****    ****    *     *
*                                                            *     *        *   *   *     *
*                                                            *     *   **   *    *   *   *
*                                                            *     *    *   *   *     * *
*                                                            *      ****    ****       *
*/

using System.Collections.Generic;
using Newtonsoft.Json;
using NRO_Server.Model.Map;
using NRO_Server.Model.SkillCharacter;
using NRO_Server.Model.Template;

namespace NRO_Server.TGDV.Nâng_Cấp_Bông_Tai
{
    public class NCBT
    {
        public static JsonSerializerSettings SettingNull = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
		
		//Bông tai cấp 2
		public static List<int> PercentNangCapPorata2 = new List<int> { 100, 500000000, 50 };//{ngọc, vàng, phần trăm thành công}

        public static List<int> PercentMoChiSoPorata2 = new List<int> { 100, 200000000, 40 };//{ngọc, vàng, phần trăm thành công}

        public static List<List<int>> OptionPorata2 = new List<List<int>>(){
			//{option id, min, max}
            new List<int>() {50, 7, 20},//Sức đánh
            new List<int>() {77, 10, 20},//Hp
            new List<int>() {108, 5, 20},//Né
            new List<int>() {103, 10, 20},//Ki
            new List<int>() {94, 5, 20},//Giáp
            new List<int>() {14, 2, 15},//Chí mạng
        };
		
		//Bông tai cấp 3
		public static List<int> PercentNangCapPorata3 = new List<int> { 100, 500000000, 50 };//{ngọc, vàng, phần trăm thành công}

        public static List<int> PercentMoChiSoPorata3 = new List<int> { 100, 200000000, 40 };//{ngọc, vàng, phần trăm thành công}

        public static List<List<int>> OptionPorata3 = new List<List<int>>(){
			//{option id, min, max}
            new List<int>() {50, 7, 25},//Sức đánh
            new List<int>() {77, 10, 25},//Hp
            new List<int>() {108, 5, 25},//Né
            new List<int>() {103, 10, 25},//Ki
            new List<int>() {94, 5, 25},//Giáp
            new List<int>() {14, 2, 20},//Chí mạng
        };
		
		//Bông tai cấp 4
		public static List<int> PercentNangCapPorata4 = new List<int> { 100, 500000000, 50 };//{ngọc, vàng, phần trăm thành công}

        public static List<int> PercentMoChiSoPorata4 = new List<int> { 100, 200000000, 40 };//{ngọc, vàng, phần trăm thành công}

        public static List<List<int>> OptionPorata4 = new List<List<int>>(){
			//{option id, min, max}
            new List<int>() {50, 7, 30},//Sức đánh
            new List<int>() {77, 10, 30},//Hp
            new List<int>() {108, 5, 30},//Né
            new List<int>() {103, 10, 30},//Ki
            new List<int>() {94, 5, 30},//Giáp
            new List<int>() {14, 2, 25},//Chí mạng
        };
	}
}