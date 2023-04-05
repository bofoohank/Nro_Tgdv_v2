
/* 
*                                                          *****    ****    ****    *     *
*                                                            *     *        *   *   *     *
*                                                            *     *   **   *    *   *   *
*                                                            *     *    *   *   *     * *
*                                                            *      ****    ****       *
*/

using System.Collections.Generic;

namespace NRO_Server.Application.Constants
{
    public class TextTask
    {
        public static string newGame = "Chào mừng {0} đến với sever!\nTao là {1} sẽ bám theo mày từ bây giờ đến hết đời.";

        public static List<string> NameHanhTinh = new List<string>() {
            "Trái Đất",
            "Namếc",
            "Xay da"
        };

        public static List<string> NameMob = new List<string>() {
            "Puaru",
            "Piano",
            "Icarus"
        };

        public static List<string> NameHome = new List<string>() {
            "Nhà Gôhan",
            "Nhà Moori",
            "Nhà Broly"
        };

        public static List<string> NameNpc = new List<string>() {
            "Ông Gôhan",
            "Ông Moori",
            "Ông Paragus"
        };

        public static List<string> NameCountry = new List<string>() {
            "Làng Aru",
            "Làng Moori",
            "Làng Kakarot"
        };

        public static string[][] Tasks = new string[][]{
            new string[]{
                "",
                "Hãy di chuyển đến %s, %s đang chờ mày ở đằng kia!",
                "%s đang chờ. Mày hãy đi đến gần và chạm nhanh 2 lần vào ông để trò chuyện",
                "Con mới đi đâu về thế? Con hãy đến rương đồ để lấy rađa, sau đó lại thu hoạch những hạt đậu trên cây đậu thần đằng kia!",
                "",
                "",
                "Tốt lắm, Rađa sẽ giúp con biết được HP và KI của mình ở góc trên màn hình\nĐậu thần sẽ giúp con hồi HP và KI khi con yếu đi\nBây giờ con hãy đi ra %s, đánh gục 5 mộc nhân để luyện tập, sau đó quay trở về đây gặp lại ta để nhận thường",
            },
            new string[] {
                ""
            }
        };
    }
}