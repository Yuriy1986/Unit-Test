using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary260
{
    public class ResourceManager : IResourceManager
    {
        public bool IsEmpty(Resource Res)
        {
            return (Res == new Resource());    //compare sent with empty
        }

        public bool IsEnough(Resource User, Resource UserNeed) //will the user have enough resusov (resources need more or equal)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            Resource Temp = User - UserNeed;
            for (int i = 0; i < Count; i++)
            {
                if (Temp[(ResourceType)i] < 0)
                    return false;
            }
            return true;
        }

        public Resource Truncate(Resource User, Resource UserNeed)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            for (int i = 0; i < Count; i++)
            {
                if (User[(ResourceType)i] > UserNeed[(ResourceType)i])
                    User[(ResourceType)i] = UserNeed[(ResourceType)i];
            }
            return User;
        }
    }

}
