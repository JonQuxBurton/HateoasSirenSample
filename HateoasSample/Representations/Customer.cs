using System;
using System.Collections.Generic;

namespace HateoasSample.Representations
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PhoneLine PhoneLine { get; set; }
        public Broadband Broadband { get; set; }
        public StaticIp StaticIp { get; set; }
    }
}
