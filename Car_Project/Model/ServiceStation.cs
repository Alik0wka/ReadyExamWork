using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Project
{
    public class ServiceStation
    {
        public ServiceStation()
        {

        }
        public ServiceStation(DateTime createTime , string description, string recomendation, User inspector)
        {
            this.createTime = createTime;
            this.description = description;
            this.recomendation = recomendation;
            this.inspector = inspector;
        }
        public DateTime createTime { get; set; }
        public Car car { get; set; }
        public string description { get; set; }
        public string recomendation { get; set; }
        public User inspector { get; set; }
    }
}
