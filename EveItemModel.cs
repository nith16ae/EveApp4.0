using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EveOnlineApp
{
    [DataContract]
    public class EveItemModel
    {
        [DataMember]
        public String name { get; set; }

        [DataMember]
        public int type_id { get; set; }

        [DataMember]
        public String description { get; set; }
    }
}
