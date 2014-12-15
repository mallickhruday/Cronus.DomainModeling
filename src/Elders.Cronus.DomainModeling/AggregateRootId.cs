using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Elders.Cronus.DomainModeling
{
    [DataContract(Name = "b3e2fc15-1996-437d-adfc-64f3b5be3244")]
    public class AggregateRootId : IAggregateRootId
    {
        protected AggregateRootId()
        {
            RawId = new byte[0];
            AggregateRootName = string.Empty;
        }

        [DataMember(Order = 10)]
        public byte[] RawId { get; protected set; }

        [DataMember(Order = 11)]
        public string AggregateRootName { get; protected set; }

        public override bool Equals(System.Object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!typeof(AggregateRootId).IsAssignableFrom(obj.GetType())) return false;
            return Equals((AggregateRootId)obj);
        }

        public virtual bool Equals(IAggregateRootId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ByteArrayCompare(RawId, other.RawId);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return HashCodeModifier.AggregateRootId ^ ComputeHash(RawId);
            }
        }

        public static int ComputeHash(params byte[] data)
        {
            unchecked
            {
                const int p = 16777619;
                int hash = (int)2166136261;

                for (int i = 0; i < data.Length; i++)
                    hash = (hash ^ data[i]) * p;

                hash += hash << 13;
                hash ^= hash >> 7;
                hash += hash << 3;
                hash ^= hash >> 17;
                hash += hash << 5;
                return hash;
            }
        }

        public static bool operator ==(AggregateRootId left, AggregateRootId right)
        {
            if (ReferenceEquals(null, left) && ReferenceEquals(null, right)) return true;
            if (ReferenceEquals(null, left))
                return false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(AggregateRootId a, AggregateRootId b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return RawId.ToString();
        }

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);

        static bool ByteArrayCompare(byte[] b1, byte[] b2)
        {
            // Validate buffers are the same length.
            // This also ensures that the count does not exceed the length of either buffer.  
            return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
        }

        public static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] rv = new byte[first.Length + second.Length];
            System.Buffer.BlockCopy(first, 0, rv, 0, first.Length);
            System.Buffer.BlockCopy(second, 0, rv, first.Length, second.Length);
            return rv;
        }
    }

    internal static class HashCodeModifier
    {
        public static int AggregateRootId = 101;
        public static int TransportMessage = 103;
        //  107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997 
    }
}