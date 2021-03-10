using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Core.Entity
{
    public class File
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string ContentType { get; set; }
        public byte[] Conteudo { get; set; }
        public string Extensao { get; set; }
    }
}
