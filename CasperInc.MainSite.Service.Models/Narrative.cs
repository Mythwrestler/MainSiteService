using System;
using System.Collections.Generic;

namespace CasperInc.MainSite.Service.Models
{
    public class Narrative
    {

        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public string BodyHtml { get; set; }

        public List<Tag> Tags { get; set; }

    }
}
