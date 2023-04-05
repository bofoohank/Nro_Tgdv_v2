using System.Collections.Generic;
using NRO_Server.Application.IO;

namespace NRO_Server.TGDV.Nâng_Cấp_Bông_Tai
{
    public class TextMenuNCBT
    {
        private static TextMenuNCBT _instance;
        public TextMenuNCBT(){}
        public static TextMenuNCBT Gi()
        {
            if (_instance == null) _instance = new TextMenuNCBT();
            return _instance;
        }

        public List<string> TextNangBongTai = new List<string>()
        {
            "Ngươi muốn ta giúp gì",
        };
        public List<List<string>> MenuNangBongTai = new List<List<string>>()
        {
            new List<string>() //0
            {
                "Nâng cấp\nBông tai",
                "Mở chỉ số\nBông tai",
            },
            new List<string>() //1
            {
                "Bông tai cấp 2",
                "Bông tai cấp 3",
                "Bông tai cấp 4",
            },
            new List<string>() //2
            {
                "Mở chỉ số\nBông tai cấp 2",
                "Mở chỉ số\nBông tai cấp 3",
                "Mở chỉ số\nBông tai cấp 4",
            },
			new List<string>()  //3
            {
                "Vào hành trang\nChọn bông tai Porata\nChọn mảnh vỡ bông tai để nâng cấp, số lượng\n99 cái\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho bông tai Porata của người\nthành cấp 2"
            },
			new List<string>()  //4
            {
                "Vào hành trang\nChọn bông tai Porata\nChọn mảnh vỡ bông tai 2 để nâng cấp, số lượng\n999 cái\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho bông tai Porata của người\nthành cấp 3"
            },
			new List<string>()  //5
            {
                "Vào hành trang\nChọn bông tai Porata\nChọn mảnh vỡ bông tai 3 để nâng cấp, số lượng\n9999 cái\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho bông tai Porata của người\nthành cấp 4"
            },
			new List<string>()  //6
            {
                "Vào hành trang\nChọn bông tai Porata cấp 2\nChọn mảnh hồn porata số lượng 99 cái và\nđá xanh lam để nâng cấp.\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho bông tai Porata cấp 2 của người\ncó 1 chỉ số ngẫu nhiên"
            },
			new List<string>()  //7
            {
                "Vào hành trang\nChọn bông tai Porata cấp 3\nChọn mảnh hồn porata số lượng 199 cái và\nđá xanh lam số lượng 5 cái để nâng cấp.\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho bông tai Porata cấp 3 của người\ncó 1 chỉ số ngẫu nhiên"
            },
			new List<string>()  //8
            {
                "Vào hành trang\nChọn bông tai Porata cấp 4\nChọn mảnh hồn porata số lượng 999 cái và\nđá xanh lam số lượng 10 cái để nâng cấp.\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho bông tai Porata cấp 4 của người\ncó 1 chỉ số ngẫu nhiên"
            },
        };
		
		public readonly string TRANG_BI_LOI_PORATA_2 = "Cần chọn đúng bông tai porata và mảnh vỡ bông tai";
        public readonly string TRANG_BI_LOI_PORATA_2_FIRST = "Bạn cần chọn bông tai Porata bỏ vào trước";
        public readonly string TRANG_BI_LOI_PORATA_2_SECOND = "Bạn cần bỏ vào đủ 99 mảnh vỡ bông tai";
        public readonly string UPGRADE_OPTION_PORATA_2_LOI_COUNT = "Cần chọn đúng bông tai Porata cấp 2, mảnh hồn porata và đá xanh lam, theo đúng thứ tự";
        public readonly string UPGRADE_OPTION_PORATA_2_FIRST = "Bạn cần chọn bông tai Porata cấp 2 bỏ vào trước";
        public readonly string UPGRADE_OPTION_PORATA_2_SECOND = "Bạn cần bỏ vào mảnh hồn bông tai x99 cái";
        public readonly string UPGRADE_OPTION_PORATA_2_THIRD = "Bạn cần bỏ vào đá xanh làm cuối cùng";
		
		public readonly string TRANG_BI_LOI_PORATA_3 = "Cần chọn đúng bông tai porata 2 và mảnh vỡ bông tai";
        public readonly string TRANG_BI_LOI_PORATA_3_FIRST = "Bạn cần chọn bông tai Porata 2 bỏ vào trước";
        public readonly string TRANG_BI_LOI_PORATA_3_SECOND = "Bạn cần bỏ vào đủ 999 mảnh vỡ bông tai";
        public readonly string UPGRADE_OPTION_PORATA_3_LOI_COUNT = "Cần chọn đúng bông tai Porata cấp 3, mảnh hồn porata và đá xanh lam, theo đúng thứ tự";
        public readonly string UPGRADE_OPTION_PORATA_3_FIRST = "Bạn cần chọn bông tai Porata cấp 3 bỏ vào trước";
        public readonly string UPGRADE_OPTION_PORATA_3_SECOND = "Bạn cần bỏ vào mảnh hồn bông tai x199 cái";
        public readonly string UPGRADE_OPTION_PORATA_3_THIRD = "Bạn cần bỏ vào đá xanh làm cuối cùng";
		
		public readonly string TRANG_BI_LOI_PORATA_4 = "Cần chọn đúng bông tai porata 3 và mảnh vỡ bông tai";
        public readonly string TRANG_BI_LOI_PORATA_4_FIRST = "Bạn cần chọn bông tai Porata 3 bỏ vào trước";
        public readonly string TRANG_BI_LOI_PORATA_4_SECOND = "Bạn cần bỏ vào đủ 9999 mảnh vỡ bông tai";
        public readonly string UPGRADE_OPTION_PORATA_4_LOI_COUNT = "Cần chọn đúng bông tai Porata cấp 4, mảnh hồn porata và đá xanh lam, theo đúng thứ tự";
        public readonly string UPGRADE_OPTION_PORATA_4_FIRST = "Bạn cần chọn bông tai Porata cấp 4 bỏ vào trước";
        public readonly string UPGRADE_OPTION_PORATA_4_SECOND = "Bạn cần bỏ vào mảnh hồn bông tai x299 cái";
        public readonly string UPGRADE_OPTION_PORATA_4_THIRD = "Bạn cần bỏ vào đá xanh làm cuối cùng";
    }
}
