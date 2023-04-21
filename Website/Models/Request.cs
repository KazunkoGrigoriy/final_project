using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string status { get; set; }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }

    public class Status
    {
        public string Received { get => "Получена"; }
        public string InWork { get => "В работе"; }
        public string Completed { get => "Выполнена"; }
        public string Rejected { get => "Отклонена"; }
        public string Canceled { get => "Отменена"; }
     }
}
