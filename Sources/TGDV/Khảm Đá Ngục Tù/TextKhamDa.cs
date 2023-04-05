using System.Collections.Generic;
using NRO_Server.Application.IO;

namespace NRO_Server.TGDV.Khảm_Đá_Ngục_Tù
{
    public class TextKhamDa
    {
        private static TextKhamDa _instance;
        public TextKhamDa(){}
        public static TextKhamDa Gi()
        {
            if (_instance == null) _instance = new TextKhamDa();
            return _instance;
        }

        public List<string> TextKhamDaTrangBi = new List<string>()
        {
            "Alo anh Bình Gold đấy phải không ạ",
			"|2|Ngươi muốn ghép 5 mảnh đá ngục tù thành\n1 viên đá ngục tù ngẫu nhiên\b|1|Cần 5 Mảnh đá ngục tù\b|2|Cần 2 k vàng",
        };
        public List<List<string>> MenuKhamDaTrangBi = new List<List<string>>()
        {
            new List<string>() //0
            {
                "Khảm đá\nNgục tù",
                "Ghép đá\nNgục tù",
            },
            new List<string>() //1
            {
                "Vào hành trang\nChọn trang bị\n(Áo,quần,găng,giày hoặc rada)\nChọn loại đá ngục tù để nâng cấp\nSau đó chọn 'Nâng cấp'",
				"\n               _TGDV_                                  ",
            },
			new List<string>() //2
            {
                "Vào hành trang\nChọn mảnh đá ngục tù\nSau đó chọn 'Nâng cấp'",
				"\n               _TGDV_                                  ",
            },
			new List<string>() // 3
            {
                "Làm phép\n2k vàng",
                "Từ chối"
            },
        };
		
		public readonly string THIEU_NGUYEN_LIEU = "Cần chọn đồ cần khảm và đá ngục tù";
        public readonly string THIEU_NGUYEN_LIEU_TRANG_BI = "Trang bị không phù hợp";
        public readonly string THIEU_NGUYEN_LIEU_DA_NGUC_TU = "Thiếu đá ngục tù";
		public readonly string THIEU_NGUYEN_LIEU_MANH_DA_NGUC_TU = "Cần 5 mảnh đá ngục tù";
		
    }
}
