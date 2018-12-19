using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace EveOnlineApp
{
    [Serializable]
    class ItemDatabase //: Serializable
    {
        [DataMember]
        Dictionary<int,EveItemModel> ItemDic;

        [field: NonSerialized()]
        APIHelper APIHelper = new APIHelper();

        public ItemDatabase()
        {
            ItemDic = new Dictionary<int, EveItemModel>();   
        }

        public async Task<string> GetItemName(int typeID)
        {
            String s = "";
            //check if item exists in dictionary
            if(ItemDic.ContainsKey(typeID))
            {
                s = ItemDic[typeID].name;
            }
            //else add the item
            else
            {
               int i = await AddItem(typeID);

                s = ItemDic[typeID].name;
            }

            return s;
        }

        public async Task<int> AddItem(int typeID)
        {
            EveItemModel n = await APIHelper.GetItem(typeID);
            ItemDic.Add(n.type_id, n);
            return 1;
        }

    }
}
