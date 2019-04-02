using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnbarProgrami
{
    class UmumiMelumatlar
    {
        public class Qiymet
        {
            public static string mehsulid { get; set; }
            public static string qiymeti { get; set; }
        }
        public class SifarisciType
        {
            public static string sifarisciid { get; set; }
            public static string sifariscitype { get; set; }
        }
        public class MehsulMiqdar
        {
            public static string mehsulid { get; set; }
            public static string mehsulmiqdari { get; set; }
        }
        public class MehsulOlcuVahidi
        {
            public static string mehsulid { get; set; }
            public static string mehsulolcuvahidi { get; set; }
        }
        public class MehsulKategoriyIDsi
        {
            public static string mehsulid { get; set; }
            public static string mehsulkategoriyID { get; set; }
        }
        public class sifarisciID
        {
            public static string sifarisciid { get; set; }
            public static string qaimenomresi { get; set; }
        }
    }
}
