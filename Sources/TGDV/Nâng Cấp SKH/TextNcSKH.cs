using System.Collections.Generic;
using NRO_Server.Application.IO;

namespace NRO_Server.TGDV.Nâng_Cấp_SKH
{
	public class TextNcSKH
	{
		private static TextNcSKH _instance;
        public TextNcSKH(){}
        public static TextNcSKH Gi()
        {
            if (_instance == null) _instance = new TextNcSKH();
            return _instance;
        }
		
		public List<string> TextNangCapSKH = new List<string>()
        {
            "abc",//0
			"Ngươi muốn đổi SKH từ: ",//1
        };
        public List<List<string>> MenuNangCapSKH = new List<List<string>>()
        {
            new List<string>() //0
            {
                "Đổi SKH",
				"Nâng Cấp SKH",
            },
			new List<string>() //1
            {
                "Trang bị thần linh",
				"Trang bị SKH",
            },
			new List<string>() //2
            {
                "Chọn 2 món trang bị Thần linh\n(Áo,quần,găng,giày hoặc rada)\nSau đó chọn 'Nâng cấp'\nSau khi đổi sẽ nhận được 1 món SKH mới",
				"\n               _TGDV_                                  ",
            },
			new List<string>() //3
            {
                "Chọn 3 món trang bị SKH\n(Áo,quần,găng,giày hoặc rada)\nSau đó chọn 'Nâng cấp'\nSau khi đổi sẽ nhận được 1 món SKH mới",
				"\n               _TGDV_                                  ",
            },
			new List<string>() //4
            {
                "Vào hành trang\nChọn mảnh đá ngục tù\nSau đó chọn 'Nâng cấp'",
				"\n               _TGDV_                                  ",
            },
        };
	}
}