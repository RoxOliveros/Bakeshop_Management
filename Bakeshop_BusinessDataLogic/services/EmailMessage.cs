using System.Collections.Generic;

namespace Bakeshop_BusinessLogic.Services
{
    public class EmailMessage
    {
        public IList<string> To { get; set; } = new List<string>();
        public string Subject { get; set; }
        public string BodyHtml { get; set; }
        public string BodyText { get; set; }
    }
}
