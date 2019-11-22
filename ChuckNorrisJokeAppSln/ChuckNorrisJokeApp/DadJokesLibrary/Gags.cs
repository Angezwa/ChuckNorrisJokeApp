using System;
using System.Collections.Generic;
using System.Text;

namespace DadJokesLibrary
{
    public class Attachment
    {
        public string fallback { get; set; }
        public string footer { get; set; }
        public string text { get; set; }
    }

    public class Gag
    {
        public List<Attachment> attachments { get; set; }
        // this shows that there is a list of Attachments, refernce class above, showing the structure of one attachment... called attachments
        // the structure above shows the structure of the json file
        // its called attachents coz it has attachments in it.
        public string response_type { get; set; }
        public string username { get; set; }
    }
}
