using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace TelegrammBot
{
    public class Request
    {
        private string _status;
        private string[] _statusList = { "Получена", "В работе", "Выполнена", "Отклонена", "Отменена" };
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (_statusList.Contains(value))
                {
                    _status = value;
                }
            }
        }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
    }
}
