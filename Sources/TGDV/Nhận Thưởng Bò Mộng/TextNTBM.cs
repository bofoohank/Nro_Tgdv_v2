using System.Collections.Generic;
using NRO_Server.Application.IO;

namespace NRO_Server.TGDV.Nhận_THưởng_Bò_Mộng
{
	public class TextNTBM
	{
		private static TextNTBM _instance;
        public TextNTBM(){}
        public static TextNTBM Gi()
        {
            if (_instance == null) _instance = new TextNTBM();
            return _instance;
        }
		
		public List<string> TextNhanThuong = new List<string>()
        {
            "Ngươi muốn ta giúp gì",//0
			"Khi tham gia server, nếu ngươi đạt được các mốc dưới đây sẽ nhận được phần quà có giá trị :)",//1
			"Người sẽ nhận được phần thưởng nếu ngươi đạt",//2 sức mạnh
			"Người sẽ nhận được phần thưởng nếu ngươi đạt",//3 sức đánh
			"Người sẽ nhận được phần thưởng nếu ngươi đạt",//4 sức đánh
			"Người sẽ nhận được phần thưởng nếu ngươi đạt: ",//5 sức đánh
        };
        public List<List<string>> MenuNhanThuong = new List<List<string>>()
        {
            new List<string>() //0
            {
                "Giftcode",
				"Nhận thưởng",
            },
			new List<string>() //1
            {
                "Sức mạnh",
				"Chỉ số",
            },
			new List<string>() //2
            {
                "10 Tr",
				"100 Tr",
				"10 Tỷ",
				"100 Tỷ"
            },
			new List<string>() //3
            {
                "Sức đánh",
				"Hp",
				"Ki",
            },
			new List<string>() //4
            {
                "11k Sức đánh gốc",
				"24k Sức đánh gốc",
				"32k Sức đánh gốc",
            },
			new List<string>() //5
            {
                "220k Hp gốc",
				"500k Hp gốc",
				"750k Hp gốc",
            },
			new List<string>() //6
            {
                "220k Ki gốc",
				"500k Ki gốc",
				"750k Ki gốc",
            },
        };
	}
}