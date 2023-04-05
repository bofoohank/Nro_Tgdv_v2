
/* 
*                                                          *****    ****    ****    *     *
*                                                            *     *        *   *   *     *
*                                                            *     *   **   *    *   *   *
*                                                            *     *    *   *   *     * *
*                                                            *      ****    ****       *
*/

using System.Collections.Generic;
using NRO_Server.Application.IO;
namespace NRO_Server.Main.Menu
{
    public class MenuNpc
    {
        private static MenuNpc _instance;

        public MenuNpc()
        {

        }

        public static MenuNpc Gi()
        {
            if (_instance == null) _instance = new MenuNpc();
            return _instance;
        }

        #region MenuAdmin
        public List<List<string>> MenuAdmin = new List<List<string>>()
        {
            new List<string>()
            {
                "Item",
                "Boss",
                "Check\nGifcode",
                "Task",
                "DeathNote",
                "Map",
                "Ban",
                "Potential",
                "Point",
                "Money",
            },


         };
        #endregion

        #region BaOngGia
        public List<string> TextBaOngGia = new List<string>()
        {
            "Ta có thể giúp gì cho con?",
            "Con đã học kỹ năng thành công",
            "Hãy chọn máy chủ con muốn đổi"
        };

        public List<List<string>> MenuBaOngGia = new List<List<string>>()
        {
            new List<string>()
            {
                "Nhận ngọc",
                "Nhận vàng",
                //"Giftcode",
                //"Nhận Đệ tử",
                "Đổi\nMật khẩu",
                //"Bật/Tắt\nhiệu ứng\nđánh boss",
                //"BXH\nSự kiện\nTop nạp",
                //"BXH\nSự kiện\nSức mạnh",
                "Qua map\nluyện tập"
                // "Đổi máy chủ"
            },
            new List<string>()
            {
                "SV 01",
                "SV VIP"
            },
        };
        #endregion

        #region Đường tăng
        public List<string> TextDuongTang = new List<string>()
        {
            "A mi phò phò, thí chủ Khi full nhiệm vụ và set hủy diệt vào map up mảnh đồ thiên sứ\n"+"|7|MAP VIP NRO KUND",
            "Thí chủ muốn trở về sao ?",
            "A mi phò phò, thí chủ thu nhập bùa '[Giải Khai Phong Ấn]',Mỗi chữ 10 cái",
        };
        public List<List<string>> MenuDuongTang = new List<List<string>>()
        {
            new List<string>()
            {
                "Đồng ý",
                "Từ chối",
                //"Nhận thưởng",
            },
            new List<string>()
            {
                "Đồng ý",
                "Từ chối",
            },
            new List<string> ()
            {
            "Giải\nPhong Ấn",
            "Về\nLàng Aru",
            "Top\nHoa Quả",
            }
        };
        #endregion

        #region Bảng xếp hạng
        public List<string> TextBXH = new List<string>()
        {
            "Bảng xếp hạng"
        };

        public List<List<string>> MenuBXH = new List<List<string>>()
        {
            new List<string>()
            {
                "BXH\nSự kiện\nTop nạp",
                "BXH\nSự kiện\nSức mạnh"
            },
        };
        #endregion

        #region Con mèo bay bay
        public List<string> TextMeo = new List<string>()
        {
            "Bạn có muốn nâng cấp đậu thần không",
            "Bạn có muốn huỷ nâng cấp đậu thần không (nhận lại 50% vàng)",
            "Bạn có muốn kết bạn với {0} không?",
            "Bạn có muốn xoá kết bạn với {0} không?",
            "Bạn có muốn dịch chuyển tới người chơi {0} không?\bTốn 10 ngọc để dịch chuyển và thời gian tự do là 20 phút",
            "Bạn có chắc chắn muốn rời bang hội ?",
            "{0} (sức mạnh {1})\nBạn muốn cược bao nhiêu vàng?",
            "Bạn có muốn xoá {0} khỏi danh sách thù địch không?",
            "Bạn chưa từng kích hoạt mã bảo vệ lần nào\nBạn có muốn dùng 50k vàng để kích hoạt không, mã bảo vệ của bạn là: {0}",
            "Bạn có muốn mở khoá rương không?",
            "Bạn có muốn khoá rương lại không?",
        };

        public List<List<string>> MenuMeo = new List<List<string>>()
        {
            new List<string>()
            {
                "OK",
                "Huỷ",
            },
            new List<string>()
            {
                "Đồng ý",
                "Huỷ",
            },
            new List<string>()
            {
                "1,000\nvàng",
                "10,000\nvàng",
                "100,000\nvàng"
            },
        };
        #endregion

        #region Thần mèo
        public List<string> TextThanMeo = new List<string>()
        {
            "Muốn uống nước thánh không cưng?",
            $"{ServerUtils.Color("red")}Bảng đổi điểm sự kiện xem tại thông báo của NRO \b"+
             $"{ServerUtils.Color("blue")}300 điểm : x10 đá bảo vệ, 5 viên cs trung thu, 10 thỏi vàng\b" +
             $"{ServerUtils.Color("blue")}500 điểm : x15 đá bảo vệ, 10 viên cs trung thu, 10 thỏi vàng\b" +
             $"{ServerUtils.Color("blue")}1000 điểm : x20 đá bảo vệ, 25 viên cs trung thu, item Lồng đèn, 20 thỏi vàng\b" +
             $"{ServerUtils.Color("blue")}3000 điểm : x30 đá bảo vệ, x99 viên cs trung thu, item lồng đèn, 30 thỏi vàng\b" +
             $"{ServerUtils.Color("blue")}5000 điểm : x35 đá bảo vệ, x99 viên cs trung thu, item lồng đèn, 35 thỏi vàng, ngẫu nhiên (phóng lợn, mèo mun, v.v)\b" +
             $"{ServerUtils.Color("blue")}5000 điểm : x35 đá bảo vệ, x99 viên cs trung thu, item lồng đèn, 35 thỏi vàng, ngẫu nhiên (phóng lợn, mèo mun, v.v)\b" +
             $"{ServerUtils.Color("blue")}7000 điểm : x50 đá bảo vệ, x99 viên cs trung thu, item lồng đèn, 40 thỏi vàng, ngẫu nhiên item, trang bị hủy diệt 10% trở lên\b" +
             $"{ServerUtils.Color("blue")}10000 điểm : x99 đá bảo vệ, x99 viên cs trung thu, item lồng đèn, 50 thỏi vàng, ngẫu nhiên item, trang bị hủy diệt 12% trở lên\b" +
            $"{ServerUtils.Color("red")}BẠN CHỈ CÓ THỂ ĐỔI ĐIỂM DUY NHẤT MỘT LẦN",
            "Vui lòng chọn loại lồng đèn muốn nhận?",
        };

        public List<List<string>> MenuThanMeo = new List<List<string>>()
        {
            new List<string>()
            {
                "Đổi quà sự kiện", 
                //"Đổi quà tích nạp",
            },
            //đổi sự kiện
            new List<string>()
            {
                "Đổi",
                "Đóng",
            },
            //chọn lồng đèn
            new List<string>()
            {
                "SỨC ĐÁNH",
                "HP",
                "KI",
                "CHÍ MẠNG",
                "GIÁP",
            },
        };
        #endregion

        #region Bà hạt mít
        public List<string> TextBaHatMit = new List<string>()
        {
            "Ngươi tìm ta có việc gì ?",
            "|2|Con muốn biến 10 mảnh đá vụn thành\n1 viên đá nâng cấp ngẫu nhiên\b|1|Cần 10 Mảnh đá vụ\nCần 1 bình nước phép\b|2|Cần 2 k vàng",
            "Ngươi Muốn pha lê hoá trang bị bằng cách nào",
            "Ta sẽ biến trang bị mới cấp cao hơn của ngươi thành trang bị có cấp độ và sao pha lê của trang bị cũ"
        };

        public List<List<string>> MenuBaHatMit = new List<List<string>>()
        {
            new List<string>() // 0
            {
                "Thưởng Bùa Ngẫu Nhiên",
                "Cửa hàng Bùa",
                "Nâng cấp Vật phẩm",
                "Nhập Ngọc Rồng",
            },
            new List<string>() // 1
            {
                "Cửa hàng Bùa",
                "Nâng cấp Vật phẩm",
                "Nhập Ngọc Rồng",
            },
            new List<string>() // 2
            {
                "Bùa 1h",
                "Bùa 8h",
                "Bùa\n1 Tháng"
            },
            new List<string>() // 3
            {
                "Ép sao\ntrang bị",
                "Pha lê\nhoá\ntrang bị"
            },
            new List<string>() // 4
            {
                "Vào hành trang\nChọn trang bị\n(Áo,quần,găng,giày hoặc rada)\nChọn loại đá để nâng cấp\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho trang bị của ngươi\ntrở nên mạnh mẽ"
            },
            new List<string>() // 5
            {
                "Vào hành trang\nChọn 10 mảnh đá vụn\nChọn 1 bình nước phép\nSau đó chọn 'Làm phép'",
                "Ta sẽ phù phép\ncho 10 mảnh đá vụn\ntrở thành 1 đá nâng cấp "
            },
            new List<string>() // 6
            {
                "Vào hành trang\nChọn 7 viên ngọc cùng sao\nSau đó chọn 'Làm phép'",
                "Ta sẽ phù phép\ncho 7 viên Ngọc Rồng\nthành 1 viên Ngọc Rồng cấp cao"
            },
            new List<string>() // 7
            {
                "Làm phép\n2k vàng",
                "Từ chối"
            },
            new List<string>()  // 8
            {
                "Vào hành trang\nChọn trang bị\n(Áo,quần,găng,giày hoặc rada)\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho trang bị của ngươi\ntrở thành trang bị pha lê"
            },


            new List<string>()//9
            {
                "Bằng ngọc",
                "Từ chối"
            },

            new List<string>() // 10 
            {
                "Chuyển hoá\nDùng vàng",
                "Chuyển hoá\nDùng ngọc"
            },

            new List<string>() // 11
            {
                "Vào hành trang\nChọn trang bị\n(Áo,quần,găng,giày hoặc rada)có ô đặt\n sao pha lê\n Chọn loại sao pha lê\nSau đó chọn 'Nâng cấp'",
                "Ta sẽ phù phép\ncho trang bị của ngươi\ntrở nên mạnh mẽ"
            },

            new List<string>() // 12
            {
                "Vào hành trang\n Chọn trang bị gốc\n (Áo,quần,găng,giày,rada) \ntừ cấp 4 trở lên\nChọn tiếp trang bị mới\nchưa nâng cấp cần nhập thể\nsau đó chọn 'Nâng cấp'",
                "Lưu ý trang bị mới\n phải hơn trang bị cũ 1 bậc"
            },
        };
        #endregion

        #region Shop bán đồ 3 hành tinh
        public List<string> TextBumma = new List<string>()
        {
            "Cưng cần trang bị gì cứ đến chỗ chị nhé",
            "Chị chỉ bán đồ cho người Trái Đất thôi nha cưng!",
            "Chị cảm ơn cu nhé! hoa đẹp quá, để cảm ơn chị có món quà cho chu nè"
        };
        public List<string> TextDende = new List<string>()
        {
            "Anh, chị cần trang bị gì cứ đến chỗ em nhé",
            "Em... Chỉ bán đồ cho người Namếc thôi...!",
        };
        public List<string> TextAppule = new List<string>()
        {
            "Cậu cần trang bị gì cứ đến chỗ tôi nhé",
            "Ta chỉ bán đồ cho người Xayda siêu mạnh thôi, cút về hành tinh của ngươi mà mua đi!",
        };
        public List<List<string>> MenuShopDistrict = new List<List<string>>()
        {
            new List<string>()
            {
                "Cửa hàng",
                "Cu tặng\nchị hoa"
            },
            new List<string>()
            {
                "Cửa hàng",
                "Từ chối",
            },
        };
        #endregion

        #region Trạm tàu 3 hành tinh
        public List<string> TextBrief = new List<string>()
        {
            "Tàu vũ trụ Trái Đất sử dụng công nghệ mới nhất, có thể đưa ngươi đi bất kì đâu, miễn có tiền trả là được.",
            "Ta sẽ đưa ngươi trở về hành tinh của mình an toàn!",
        };

        public List<List<string>> MenuBrief = new List<List<string>>()
        {
            new List<string>()
            {
                "Đến Xayda",
                "Đến Namếc",
                "Siêu thị",
            },
            new List<string>()
            {
                "Đến Xayda",
                "Đến Namếc",
            },
        };

        public List<string> TextCargo = new List<string>()
        {
            "Tàu vũ trụ Namec sử dụng công nghệ mới nhất, có thể đưa ngươi đi bất kì đâu, miễn có tiền trả là được.",
        };

        public List<List<string>> MenuCargo = new List<List<string>>()
        {
            new List<string>()
            {
                "Đến\nTrái Đất",
                "Đến Xayda",
                "Siêu thị",
            },
            new List<string>()
            {
                "Đến\nTrái Đất",
                "Đến Xayda",
            },
        };

        public List<string> TextCui = new List<string>()
        {
            "Tàu vũ trụ Xayda sử dụng công nghệ mới nhất, có thể đưa ngươi đi bất kì đâu, miễn có tiền trả là được.",
            "Đội quân Fide đang ở thung lũng Nappa, ta sẽ đưa ngươi đến đó",
            "Ngươi muốn về thành phố Vegeta ?",
        };

        public List<List<string>> MenuCui = new List<List<string>>()
        {
            new List<string>()
            {
                "Đến\nTrái Đất", "Đến Namếc", "Siêu thị",
            },
            new List<string>()
            {
                "Đến\nTrái Đất", "Đến Namếc",
            },
            new List<string>()
            {
                "Đến Cold", "Đến Nappa", "Từ Chối"
            },
            new List<string>()
            {
                "Đồng ý", "Từ Chối"
            },
        };
        #endregion

        #region Quy lão
        public List<string> TextQuyLao = new List<string>()
        {
            "Con muốn hỏi gì nào?",
            "Chào con, to rất vui khi gặp con\nCon muốn làm gì nào?",
            "Mở vào ngày 10/11",
            "Con có muốn huỷ học kỹ năng này và nhận lại 50% số tiềm năng không ?",
            "Con muốn ta giúp gì?",
            "Ta sẽ giúp con bỏ qua nhiệm vụ hiện tại với giá 50 thỏi vàng",
            "Ta sẽ giúp con xóa bang hiện tại với phí 10 thỏi vàng"
        };

        public List<List<string>> MenuQuyLao = new List<List<string>>()
        {
            new List<string>()
            {
                "Nói\nchuyện", "Kho báu\ndưới biển", "Hỗ trợ"
            },
            new List<string>()
            {
                "Nhiệm vụ", "Học\nKỹ năng"
            },
            new List<string>()
            {
                "Top\nBang hội", "Thành\ntích bang", "Chọn\ncấp độ", "Từ chối"
            },
            new List<string>()
            {
                "Bỏ qua\nnhiệm vụ", "Rời bang"
            },
            new List<string>()
            {
                "Đồng ý", "Từ chối"
            }
        };
        #endregion

        #region Santa
        public List<string> TextSanta = new List<string>()
        {
            "Xin chào, ta có một số vật phẩm đặc biệt, cậu có muốn xem không?",
        };

        public List<List<string>> MenuSanta = new List<List<string>>()
        {
            new List<string>()
            {
                "Cửa\nhàng", "Tiệm\nHớt tóc"
            },
        };
        #endregion

        #region Quốc vương
        public List<string> TextQuocVuong = new List<string>()
        {
            "Con muốn nâng giới hạn sức mạnh\ncho bản thân hay đệ tử?"
        };

        public List<List<string>> MenuQuocVuong = new List<List<string>>()
        {
            new List<string>()
            {
                "Bản thân", "Đệ tử", "Từ chối"
            },
            new List<string>()
            {
                "Nâng\nGiới hạn\nSức mạnh","Nâng ngọc","OK"
            },
            new List<string>()
            {
                "Nâng ngay\ncho đệ tử\n%d ngọc","OK"
            },
        };
        #endregion

        #region Thượng đế
        public List<string> TextThuongDe = new List<string>()
        {
            "",
            "Con đã mạnh hơn ta, ta sẽ chỉ đường cho con đến Kaio để gặp thần Vũ Trụ Phương Bắc\nNgài là thần cai quản vũ trụ này, hãy theo ngài ấy học võ công",
            "Con có thể chọn từ 1 đến 7 viên\ngiá mỗi viên là 25 tr vàng\nƯu tiên dùng vé quay trước",
            "Con có chắc muốn xóa tất cả vật phẩm trong rương phụ không?"
        };

        public List<List<string>> MenuThuongDe = new List<List<string>>()
        {
            new List<string>()
            {
                "Bản thân"
            },
            new List<string>()
            {
                "Vòng quay\nMay mắn",
                "Đến\nKaio"
            },
            new List<string>()
            {
                "Vòng quay\nMay mắn",
                "Đóng",
            },
            new List<string>()
            {
                "Xóa",
                "Từ chối",
            },
        };
        #endregion

        #region Thần zũ trụ
        public List<string> TextThanVuTru = new List<string>()
        {
            "Con muốn điều gì?",
        };

        public List<List<string>> MenuThanVuTru = new List<List<string>>()
        {
            new List<string>()
            {
                "Về Thần Điện",
				"Đến\nThánh địa Kaio",
                "Từ chối"
            },
        };
        #endregion

        #region Rồng thần
        public string TextRongThan = "Ta sẽ ban cho ngươi 1 điều ước, hãy suy nghĩ thật kỹ trước khi quyết định";
        public List<string> MenuDieuUocRongThan = new List<string>()
        {
            "2 tỷ vàng",
            "+1 Găng tay trên người (Max 7)",
            "Đổi kỹ năng của đệ",
            "Đẹp trai nhất vũ trụ"
        };
        #endregion

        #region Rồn xương
        public string TextRongXuong = "Ta sẽ ban cho ngươi 1 điều ước, hãy suy nghĩ thật kỹ trước khi quyết định";
        public List<string> MenuDieuUocRongXuong = new List<string>()
        {
            "2 tỷ ngọc",
            "+1 Găng tay đệ tử (Max 7)",
            "Đổi kỹ năng 3, 4 đệ tử",
            "Xấu trai nhất vũ trụ"
        };
        #endregion

        #region Trứng bưu
        public List<string> TextQuaTrung = new List<string>()
        {
            "Bạn có chắc chắn thay thế để tự hiện tại thành đệ tử Ma Bư?",
            "Hãy chọn hành tinh cho đệ tử Ma Bư của bạn.",
        };

        public List<List<string>> MenuQuaTrung = new List<List<string>>()
        {
            new List<string>()
            {
                "{0}",
                "Nở Ngay\n1,1 Tỷ Vàng",
                "Đóng",
            },
            new List<string>()
            {
                "Nở",
                "Đóng",
            },
            new List<string>()
            {
                "Trái Đất",
                "Namếc",
                "Xayda"
            },
        };
        #endregion

        #region Nạp thẻ
        public List<string> TextNapThe = new List<string>()
        {
            "Con hãy chọn loại thẻ mà con muốn nạp.",
            "Tốt lắm, giờ con hãy chọn mệnh giá thẻ nạp trước khi nhập mã nha\nLưu ý: Khi chọn sai mệnh giá sẽ bị trừ 50%."
        };
        public List<List<string>> MenuNapThe = new List<List<string>>()
        {
            new List<string>()
            {
                "Viettel",
                "Vinaphone",
                "Mobifone",
                "Zing",
                "Hủy"
            },
            new List<string>()
            {
                "10,000đ",
                "20,000đ",
                "30,000đ",
                "50,000đ",
                "Mệnh giá\nkhác",
                "Hủy",
            },
            new List<string>()
            {
                "100,000đ",
                "200,000đ",
                "300,000đ",
                "500,000đ",
                "1,000,000đ",
                "Hủy",
            },
        };
        #endregion

        #region Nội tại
        public List<string> TextNoiTai = new List<string>()
        {
            "Nội tại là một kỹ năng bị động hỗ trợ đặc biệt\nBạn có muốn mở hoặc thay đổi nội tại không?",
            "Bạn có muốn đổi Nội Tại khác với giá là {0} ngọc?",
            "Bạn có muốn mở Nội Tại Bằng Vàng với giá là {0} vàng?"
        };

        public List<List<string>> MenuNoiTai = new List<List<string>>()
        {
            new List<string>()
            {
                "Xem\ntất cả\nNội tại",
                "Mở Nội Tại",
                "Mở Bằng Vàng",
                "Từ chối"
            },
            new List<string>()
            {
                "Mở Nội Tại",
                "Từ chối"
            },
            new List<string>()
            {
                "Mở Bằng Vàng",
                "Từ chối"
            },
        };
        #endregion

        #region Ca lích
        public List<string> TextCalich = new List<string>()
        {
            "Chào chú, cháu có thể giúp gì?",
            @"20 năm trước bọn Android sát thủ đã đánh bại nhóm bảo vệ trái đất của Sôngoku và Cađíc, Pôcôlô..
            Riêng Sôngoku vì bệnh tim đã chết trước đó nên không thể tham gia trận đánh...
            Từ đó đến nay bọn chúng tàn phá Trái Đất không hề thương tiếc. Cháu và mẹ may mắn sống sót nhờ lẩn trốn tại tầng hầm của công ty Capsule...
            Cháu tuy cũng là siêu Xayda nhưng cũng không thể làm gì được bọn Android sát thủ...
            Chỉ có Sôngoku mới có thể đánh bại bọn chúng, mẹ cháu đã chế tạo thành công cỗ máy thời gian và cháu quay về quá khứ để cứu Sôngoku...
            Bệnh của Gôku ở quá khứ là nan y, nhưng với trình độ y học tương lai chỉ cần uống thuốc là khỏi...
            Hãy đi theo cháu đến tương lai giúp nhóm Gôku đánh bại bọn Android sát thủ. Khi nào chú cần sự giúp đỡ của cháu hãy đến đây nhé.",
        };

        public List<List<string>> MenuCalich = new List<List<string>>()
        {
            new List<string>()
            {
                "Kể chuyện",
                "Đi đến\nTương lai",
                "Từ chối",
            },
            new List<string>()
            {
                "Quay về\nQuá khứ",
                "Từ chối",
            },
        };
        #endregion

        #region Giu ma
        public List<string> TextGiuMa = new List<string>()
        {
            "Ngươi đang muốn tìm mảnh vỡ và mảnh hồn bông tai Porata trong truyền thuyết, ta sẽ đưa ngươi đến đó.",
        };

        public List<List<string>> MenuGiuMa = new List<List<string>>()
        {
            new List<string>()
            {
                "OK",
                "Đóng",
            },
        };
        #endregion

        #region Bill
        public List<string> TextBill = new List<string>()
        {
            "Ngươi tìm ta có việc gì.",
            "Ngươi trang bị đủ bộ 5 món trang bị Thần\nvà mang 99 phần đồ ăn tới đây...\nrồi ta nói chuyện tiếp.",
            "Đói bụng quá...ngươi mang cho ta 99 phần đồ ăn, ta sẽ đổi cho một món đồ Hủy Diệt bằng THỎI VÀNG.\nNếu tâm trạng ta vui ngươi có thể nhận được trang bị tăng đến 15%"
        };
        public List<List<string>> MenuBill = new List<List<string>>()
        {
            new List<string>()
            {
                "Nói chuyện",
                "Từ chối",
            },
            new List<string>()
            {
                "OK",
            },
            new List<string>()
            {
                "OK",
                "Từ chối",
            },
        };
        #endregion

        #region Mabuu
        public List<string> TextMabuu = new List<string>()
        {
            "Mày muốn gì?"
        };

        public List<List<string>> MenuMabuu = new List<List<string>>()
        {
            new List<string>()
            {
                "Cửa hàng"
            }
        };
        #endregion

        #region Diễm my
        public List<string> TextDiemMy = new List<string>()
        {
            "|7|Hello, cưng muốn gì nạ...",
            "",
            "|0|Cưng đang có: {0} VND\nTổng Nạp: {1} VND",
            "|7|Cưng đang có: {0} VND",
            "|7|Cưng đang có: {0} VND\n|6|Muốn kích hoạt thành viên cần 20.000 VND",
            "|7|Cưng đang có: {0} VND\n|6|Cưng muốn đổi vàng hay ngọc ?",
            "|7|Cưng đang có: {0} VND\n|6|Cưng muốn đổi gì hay không?\n|0|Tùy chọn 1: Đá sắc màu [20k]",
        };

        public List<List<string>> MenuDiemMy = new List<List<string>>()
        {
            new List<string>()
            {
                "Ủng hộ server"
            },
            new List<string>()
            {
                "Nâng 200Tr\nGiá 200Tr", "Từ chối"
            },
            new List<string>()
            {
                "Đổi vàng", "Kích hoạt\nThành viên","Đại Gia", "Từ chối"
            },
            new List<string>()
            {
                "Đổi vàng"
            },
            new List<string>()
            {
                "10K","20K", "50K", "100k", "200k", "500k"
            },
            new List<string>()
            {
                "10K","20K", "50K", "100k", "200k", "500k"
            },
            new List<string>()
            {
                "OK","Hủy"
            },
            new List<string>()
            {
                "Tùy chọn\n1","Hủy"
            }
        };
        #endregion

        #region Bò mộng
        public List<string> TextBoMong = new List<string>()
        {
            "Nhập gift code ở đây nè...",
			"Khi tham gia server, nếu ngươi đạt được các mốc dưới đây sẽ nhận được phần quà có giá trị :)",
			"Chúc mừng ngươi"
        };

        public List<List<string>> MenuBoMong = new List<List<string>>()
        {
            new List<string>() //0
            {
                "Giftcode",
				"Nhận thưởng",
            },
			new List<string>() //1
            {
                "Sức mạnh",
				"Thể lực",
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
        };
        #endregion

        #region Robo
        public List<string> TextRoBo = new List<string>()
        {
            "Ngươi cần đồ gì ở ta?",
        };

        public List<List<string>> MenuRoBo = new List<List<string>>()
        {
            new List<string>()
            {
                "Cửa\nhàng"
            },
        };
        #endregion

        public List<List<string>> MenuVados = new List<List<string>>()
        {
            new List<string>()
            {
                "Nâng Áo",
                "Nâng Quần",
                 "Nâng Găng",
                  "Nâng Giày",
                   "Nâng Rada",
            },
             new List<string>()
            {
               "Nâng cấp",
               "Từ chối",
            },
             new List<string>()
            {
              "Hủy",
             },

        };

        #region Mrpopo
        public List<string> TextMrpopo = new List<string>()
        {
            "Ta sẽ đưa ngươi trở về làng",
        };

        public List<List<string>> MenuMrpopo = new List<List<string>>()
        {
            new List<string>()
            {
                "Ok luôn","Hủy"
            },
        };
        #endregion
		
		#region Berry
        public List<string> TextBerry = new List<string>()
        {
            "Ta có thể giúp gì cho ngươi?",
        };

        public List<List<string>> MenuBerry = new List<List<string>>()
        {
            new List<string>()
            {
                "Nâng SKH",
                "Khảm đá"
            },
        };
        #endregion
		
		#region Osin
        public List<List<string>> MenuOsin = new List<List<string>>()
        {
            new List<string>()
            {
                "Về\nHành tinh\nKaio",
                "Đến\nHành tinh\nbill",
                "Từ chối",
            },
            new List<string>()
            {
                "Về\nLãnh địa\nKaio",
                "Đến\nhành tinh\nngục tù",
            },
            new List<string>()
            {
                "Về\nHành tinh\nBill",
                "Từ chối",
            },
            new List<string>()
            {
                "Oke",
                "Từ chối",
            },
            new List<string>()
            {
                "Không có gì",
                "Ta muốn rời khỏi đây",
            },


        };
        #endregion

    }
}