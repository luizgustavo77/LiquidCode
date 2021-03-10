using System.ComponentModel;

namespace Commom.Dto.Sales
{
    public class CoinsDto
    {
        [DisplayName("")]
        public string Value{ get; set; }

        [DisplayName("R$0,01")]
        public int One { get; set; } = 0;

        [DisplayName("R$0,05")]
        public int Five { get; set; } = 0;

        [DisplayName("R$0,10")]
        public int Ten { get; set; } = 0;

        [DisplayName("R$0,25")]
        public int TwentyFive { get; set; } = 0;

        [DisplayName("R$0,50")]
        public int Fifty { get; set; } = 0;

        [DisplayName("R$1,00")]
        public int OneHundred { get; set; } = 0;
    }
}
