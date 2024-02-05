using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApplication.Models;

namespace WebApiApplication
{
    public interface IMethods
    {
        public void AddRequest(Request request);
        public void DeleteRequest(int id);
        public IEnumerable<Request> GetRequests();
        public Request GetRequestId(int id);
        public void UpdateRequest(Request request);
    }
}
