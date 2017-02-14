using System.Collections.Generic;
using System.IO;

namespace Jansson.AdventOfCode.DaySeven
{
    public class IPValidator
    {
        private List<Ip> _ips;

        private string[] _lines;


        public int GetNumberOfValidatedTlsIps()
        {
            var validIPs = new List<Ip>();
            foreach (var ip in _ips)
                if (ip.SupportsTls())
                    validIPs.Add(ip);
            return validIPs.Count;
        }

        public int GetNumberOfValidatedSslIps()
        {
            var validIPs = new List<Ip>();
            foreach (var ip in _ips)
                if (ip.SupportsSsl())
                    validIPs.Add(ip);
            return validIPs.Count;
        }

        public void LoadIPs(string filename)
        {
            _lines = File.ReadAllLines(filename);
            _ips = new List<Ip>();

            foreach (var line in _lines)
                _ips.Add(new Ip(line));
        }
    }
}