using System.Collections.Generic;
using NRO_Server.Application.IO;

namespace NRO_Server.TGDV.Kiếp_Đỏ_Đen
{
    public class TextMenuCLTX
    {
        private static TextMenuCLTX _instance;
        public TextMenuCLTX(){}
        public static TextMenuCLTX Gi()
        {
            if (_instance == null) _instance = new TextMenuCLTX();
            return _instance;
        }

        public List<string> TextKiepDoDen = new List<string>()
        {
            "Cờ bạc là bác thằng bần",
            "Hãy quay lại sau 19H",
			@"Chào mừng đến với nhà cái đến từ Châu Phi
              Bạn chỉ có thể đặt cược bằng thỏi vàng ít nhất là 10 Thỏi, nhiều nhất là 990 thỏi
              Phần thưởng khi giành chiến thắng x190% (ví dụ: đặt 100 Thỏi vàng sẽ nhận lại 190 Thỏi vàng)
			  Quy luật: Chẵn lẻ sẽ random 4 số và lấy tổng, Tài Xỉu random 3 số nếu tổng lớn hơn 10 là Tài, nhỏ hơn hoặc bằng 10 là Xỉu, 3 số giống nhau là Tam hoa
			  Lưu ý: Sau khi đặt thành công sẽ có thông báo 'Kết quả sẽ có sau 10 giây' vui lòng đứng im không thao tác thêm gì
			  Nếu hết tiền đừng nản lòng hãy gặp NPC Mỹ Duyên để có thêm Thỏi vàng :)
			 ",
			"Kết quả:{0} {1} {2} | Tổng {3} | Tài\nBạn đã đặt: {4} Thỏi vàng vào Xỉu\nĐen lắm cu",
        };
        public List<List<string>> MenuKiepDoDen = new List<List<string>>()
        {
            new List<string>()
            {
                "Chẵn Lẻ",
                "Tài Xỉu",
                "Luật chơi",
            },
            new List<string>()
            {
                "OK",
            },
            new List<string>()
            {
                "Đặt chẵn",
                "Đặt lẻ",
            },
            new List<string>()
            {
                "Đặt tài",
                "Đặt xỉu",
            }
        };

    }
}
