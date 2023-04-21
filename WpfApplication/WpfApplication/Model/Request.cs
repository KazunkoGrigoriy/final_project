using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApplication.Model
{
    public class Request
    {
        private string _status;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public DateTime DateTime { get; set; }
        public string Message { get; set; }

    }

}
