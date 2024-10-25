using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Net1711_231_ASM3_SE172092_NGUYENHOANGSON.Service
{
    public class Travel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public decimal Price { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Note { get; set; }
    }
}