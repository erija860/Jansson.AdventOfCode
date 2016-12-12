using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jansson.AdventOfCode.DayFour
{
    public class RoomValidator
    {
        private List<Room> _validRooms;

        public int GetSumOfSectorIdsOfRealRooms(string filename)
        {
            var rooms = InputParser.GetRooms(filename);
            _validRooms = new List<Room>();

            foreach (var room in rooms)
                if (room.IsValid())
                    _validRooms.Add(room);

            var sumOfSectorId = 0;

            foreach (var validRoom in _validRooms)
                sumOfSectorId = sumOfSectorId + validRoom.SectorId;

            return sumOfSectorId;
        }

        public int GetSectorIdOfNorthPoleObjectStorage()
        {
            foreach (var validRoom in _validRooms)
                if (validRoom.GetDecryptedName() == "northpole object storage")
                    return validRoom.SectorId;
            return 1;
        }
    }

    public static class InputParser
    {
        public static Room[] GetRooms(string filename)
        {
            var roomLines = File.ReadAllLines(filename);
            var rooms = new List<Room>();
            foreach (var roomLine in roomLines)
            {
                var room = new Room();
                var splitRoomLine = roomLine.Split('-').ToList();
                var checksumAndsectorId = splitRoomLine.Last().Split('[');
                checksumAndsectorId[1] = checksumAndsectorId[1].Replace("]", "");
                splitRoomLine.RemoveAt(splitRoomLine.Count - 1);

                foreach (var partOfName in splitRoomLine)
                    room.Name = string.Concat(room.Name, partOfName);

                for (var i = 0; i < splitRoomLine.Count; i++)
                {
                    room.OriginalName = room.OriginalName + splitRoomLine[i];

                    if (i < splitRoomLine.Count - 1)
                        room.OriginalName = room.OriginalName + "-";
                }

                room.Checksum = checksumAndsectorId[1];
                room.SectorId = int.Parse(checksumAndsectorId[0]);
                rooms.Add(room);
            }
            return rooms.ToArray();
        }
    }

    public class Room
    {
        public string Checksum { get; set; }
        public int SectorId { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }


        public bool IsValid()
        {
            var realchecksum = Name.ToCharArray().OrderBy(c => c)
                .GroupBy(c => c)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .Take(5);

            return new string(
                realchecksum.ToArray()).Equals(Checksum);
        }

        public string GetDecryptedName()
        {
            var decryptedName = string.Empty;

            foreach (var character in OriginalName)
            {
                var currentChar = (int)character;
                for (var i = 0; i < SectorId; i++)
                    if ((currentChar == 45) || (currentChar == 32))
                    {
                        currentChar = 32;
                    }
                    else
                    {
                        currentChar++;

                        if (currentChar == 123)
                            currentChar = 97;
                    }
                decryptedName = decryptedName + (char)currentChar;
            }
            return decryptedName;
        }
    }
}