using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace ClassLibrary260
{
   public interface IResourceManager
    {
         bool IsEmpty(Resource Res);    //empty - true (empty dictionary value or not)
         bool IsEnough(Resource User, Resource UserNeed); //will the user have enough resusov (resources need more or equal)
         Resource Truncate(Resource User, Resource UserNeed); //truncate resources to the required size
    }
}
