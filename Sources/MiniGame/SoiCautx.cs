using NRO_Server.Application.Constants;
using NRO_Server.Application.Threading;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRO_Server.MiniGame
{
    internal class SoiCautx
    {
        private static SoiCautx Ienstance { get; set; } = null;
        public static SoiCautx Gi()
        {
            return Ienstance ??= new SoiCautx();
        }

        public static List<string> soicauTX = new List<string>();
        public static void SoiCautxe(string name, string item, string time)
        {
            string[] authors = {name, item, time};
            soicauTX.AddRange(authors);

        }


    }
}
