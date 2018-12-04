using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EveOnlineApp
{
    /// <summary>
    /// This is simply the members of the EveObjModel objects. The DataContract and DataMember contracts is used
    /// in coordination with the Newtonsoft.Json library. We basically use the to identify what to cast the JSON objects to. 
    /// </summary>
    [DataContract]
    public class EveObjModel
    {
        [DataMember]
        public bool is_buy_order { get; set; }

        [DataMember]
        public long price { get; set; }

        [DataMember]
        public int type_id { get; set; }

    }
}
