using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.CompilerServices;

namespace ClassLibrary260
{
    public class Resource : IEquatable<Resource>
    {
        private Dictionary<ResourceType, float> DicRes = new Dictionary<ResourceType, float>();    //Dictionary material, quantity
        //////////////////////////////////////////////        // ///////////////////////////
        public float this[ResourceType i]
        {
            get { return DicRes[i]; }
            set { DicRes[i] = value; }
        }
        //////////////////////////////////////////////        // ///////////////////////////

        public Resource()
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;    //number of items in the enumerating
            for (int i = 0; i < Count; i++)
                DicRes.Add((ResourceType)i, 0);
        }

        #region   // block of constructors////////////////////////////////////////////////////////////////
        public Resource(ResourceType res1, int v1)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            for (int i = 0; i < Count; i++)
            {
                if (i == (int)res1)
                {
                    DicRes.Add(res1, v1);
                    continue;
                }
                DicRes.Add((ResourceType)i, 0);
            }
        }

        public Resource(ResourceType res1, int v1, ResourceType res2, int v2)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            for (int i = 0; i < Count; i++)
            {
                if (i == (int)res1)
                {
                    DicRes.Add(res1, v1);
                    continue;
                }
                if (i == (int)res2)
                {
                    DicRes.Add(res2, v2);
                    continue;
                }
                DicRes.Add((ResourceType)i, 0);
            }
        }

        public Resource(ResourceType res1, int v1, ResourceType res2, int v2, ResourceType res3, int v3)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            for (int i = 0; i < Count; i++)
            {
                if (i == (int)res1)
                {
                    DicRes.Add(res1, v1);
                    continue;
                }
                if (i == (int)res2)
                {
                    DicRes.Add(res2, v2);
                    continue;
                }
                if (i == (int)res3)
                {
                    DicRes.Add(res3, v3);
                    continue;
                }
            }
        }
        #endregion

        public Resource(Dictionary<ResourceType, float> r1)/////////////////////////////////////////////////////////////////
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;

            for (int i = 0; i < Count; i++)
            {
                if(r1.ContainsKey((ResourceType)i))
                    DicRes.Add((ResourceType)i, r1[(ResourceType)i]);
                else
                    DicRes.Add((ResourceType)i, 0);
            }
        }

        public static Resource operator +(Resource r1, Resource r2)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            Dictionary<ResourceType, float> DicRes1 = new Dictionary<ResourceType, float>();

            for (int i = 0; i < Count; i++)
                DicRes1.Add((ResourceType)i, r1.DicRes[(ResourceType)i] + r2.DicRes[(ResourceType)i]);

            Resource res = new Resource(DicRes1);
            return res;
        }

        public static Resource operator -(Resource r1, Resource r2)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            Dictionary<ResourceType, float> DicRes1 = new Dictionary<ResourceType, float>();

            for (int i = 0; i < Count; i++)
                DicRes1.Add((ResourceType)i, r1.DicRes[(ResourceType)i] - r2.DicRes[(ResourceType)i]);

            Resource res = new Resource(DicRes1);
            return res;
        }

        public static bool operator ==(Resource r1, Resource r2)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            for (int i = 0; i < Count; i++)
            {
                if (!r1.DicRes[(ResourceType)i].Equals(r2.DicRes[(ResourceType)i]))
                    return false;
            }
            return true;
        }

        public static bool operator !=(Resource r1, Resource r2)
        {
            return !(r1 == r2);
        }

        public override bool Equals(object other)
        {    
            if (other == null)
                return false;

            //If the links point to the same address, then their identity is guaranteed.
            if (object.ReferenceEquals(this, other))
                return true;

            if (this.GetType() != other.GetType())
                return false;

            return this.Equals(other as Resource);
        }

        public bool Equals(Resource other)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            for (int i = 0; i < Count; i++)
            {
                if (DicRes[(ResourceType)i] != other[(ResourceType)i]) 
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return ShiftAndWrap(this.DicRes[ResourceType.Gold].GetHashCode(),2) ^ this.DicRes[ResourceType.Stone].GetHashCode() ^ this.DicRes[ResourceType.Wood].GetHashCode();
        }

        private int ShiftAndWrap(int value, int positions)
        {
            positions = positions & 0x1F;

            // Save the existing bit pattern, but interpret it as an unsigned integer.
            uint number = BitConverter.ToUInt32(BitConverter.GetBytes(value), 0);
            // Preserve the bits to be discarded.
            uint wrapped = number >> (32 - positions);
            // Shift and wrap the discarded bits.
            return BitConverter.ToInt32(BitConverter.GetBytes((number << positions) | wrapped), 0);
        }

        public static Resource operator *(Resource r1, float ff)
        {
            int Count = Enum.GetValues(typeof(ResourceType)).Length;
            Dictionary<ResourceType, float> DicRes1 = new Dictionary<ResourceType, float>();  
            for (int i = 0; i < Count; i++)
                DicRes1.Add((ResourceType)i, r1.DicRes[(ResourceType)i] * ff);

            Resource res = new Resource(DicRes1);
            return res;
        }
    }
}
