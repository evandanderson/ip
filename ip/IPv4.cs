using System.Text.RegularExpressions;

namespace ip
{
    public partial class IPv4
    {
        public uint Address { get; }
        private static readonly Regex pattern = MyRegex();

        [GeneratedRegex("(?:\\d{1,3}\\.){3}\\d{1,3}")]
        private static partial Regex MyRegex();

        public IPv4()
        {
            Address = 0;
        }

        public IPv4(string address)
        {
            if (!pattern.IsMatch(address))
            {
                throw new ArgumentException("IPv4 address must be provided in proper dotted decimal notation.");
            }

            Address = ToUInt32(address);
        }

        public IPv4(uint address)
        {
            Address = address;
        }

        /// <summary>
        /// Returns the unsigned integer representation of an IPv4 address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static uint ToUInt32(string address)
        {
            List<string> octets = address.Split('.').ToList();

            return (uint)octets.Select((octet, index) => uint.Parse(octet) << (octets.Count - (index + 1)) * 8).Sum(x => x);
        }

        /// <summary>
        /// Returns the IPv4 address in dotted decimal notation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Logical AND trims leading bits when shifted
            return string.Join('.', Enumerable.Range(0, 4).Select(index => Address >> (4 - (index + 1)) * 8 & 255));
        }
    }
}