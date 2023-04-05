
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

namespace NRO_Server.TGDV.Khảm_Đá_Ngục_Tù
{
    public class KhamDa
    {
        public static JsonSerializerSettings SettingNull = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
		
		//Bông tai cấp 2
		public static List<int> CountKhamDa = new List<int> { 100, 500000000, 50 };//{ngọc, vàng, phần trăm thành công}

	}
}