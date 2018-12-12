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
    /// <summary>
    /// Author: All
    /// This is simply the members of the EveObjModel objects. The DataContract and DataMember contracts is used
    /// in coordination with the Newtonsoft.Json library. We basically use the to identify what to cast the JSON objects to. 
    /// </summary>
    [DataContract]
    public class EveObjModel : IComparable<EveObjModel>
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public bool is_buy_order { get; set; }

        [DataMember]
        public long price { get; set; }

        [DataMember]
        public int type_id { get; set; }

        public override string ToString()
        {
            string toStringyString = "";

            if (this.is_buy_order)
                toStringyString = $"Item {this.name} (Type ID: {this.type_id}) is a buy item. Cost; {this.price}";
            else
                toStringyString = $"Item {this.name.ToString()} (Type ID: {this.type_id.ToString()}) is a sell item. Cost: {this.price.ToString()}";

            return toStringyString;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as EveObjModel;

            if (this.name == other.name && this.type_id == other.type_id && this.price == other.price)
                return true;
            else
                return false;
        }

        int IComparable<EveObjModel>.CompareTo(EveObjModel other)
        {
            if (other != null)
                return this.price.CompareTo(other.price);
            else
                throw new ArgumentException("Can only compare two Eve items");
        }
    }
}
